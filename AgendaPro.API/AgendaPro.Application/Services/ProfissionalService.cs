using AgendaPro.Application.Exceptions;
using AgendaPro.Application.DTOs.ProfissionalDTO;
using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Models;
using AgendaPro.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.Services
{
    public class ProfissionalService : IProfissionalService
    {
        private readonly IGeralRepo _geralrepo;
        public ProfissionalService(IGeralRepo geralrepo)
        {
            _geralrepo = geralrepo;
        }
        public async Task<Profissional> AtualizarProfissional(int id, AtualizarProfissionalRequest request)
        {
            if (request == null)
            {
                throw new ValidationException("os dados para atualizar o profissional sao nulos");
            }
            if (request.horaInicio <= TimeSpan.Zero || request.horaFim <= TimeSpan.Zero)
            {
                throw new ValidationException("O horario de inicio e de fim devem ser maiores que 0");
            }
            if (request.horaInicio >= request.horaFim)
            {
                throw new ValidationException("O horario de inicio deve ser anterior ao horario de fim");
            }

            var profissionais = await _geralrepo.PegarTodos<Profissional>();
            foreach (Profissional p in profissionais)
            {
                //Lançando uma excessao em caso de email que ja existe
                if (p.email == request.email)
                {
                    throw new ConflictException("o email ja existe");
                }
                if (p.telefone == request.telefone)
                {
                    throw new ConflictException("o telefone ja existe");
                }
            }

            var profissional = await _geralrepo.PegarPorId<Profissional>(id);

            profissional.horaFinal = request.horaFim;
            profissional.horaInicio = request.horaInicio;
            profissional.email = request.email;
            profissional.nome = request.nome;
            profissional.telefone = request.telefone;

            await _geralrepo.Atualizar(profissional);
            return profissional;
        }

        public async Task<Profissional> CriarProfissional(CriarProfissionalRequest request)
        {
            if (request == null)
            {
                throw new ValidationException("os dados para criar o profissional sao nulos");
            }
            if (request.horaInicio <= TimeSpan.Zero || request.horaFim <= TimeSpan.Zero)
            {
                throw new ValidationException("O horario de inicio e de fim devem ser maiores que 0");
            }
            if (request.horaInicio >= request.horaFim)
            {
                throw new ValidationException("O horario de inicio deve ser anterior ao horario de fim");
            }


            var profissionais = await _geralrepo.PegarTodos<Profissional>();
            foreach (Profissional p in profissionais)
            {
                //Lançando uma excessao em caso de email que ja existe
                if (p.email == request.email)
                {
                    throw new ConflictException("o email ja existe");
                }
                if (p.telefone == request.telefone)
                {
                    throw new ConflictException("o telefone ja existe");
                }
            }

            var profissional = new Profissional
            {
                nome = request.nome,
                email = request.email,
                telefone = request.telefone,
                horaFinal = request.horaFim,
                horaInicio = request.horaInicio,
                ativo = true
            };


            await _geralrepo.Adicionar<Profissional>(profissional);
            return profissional;

        }

        public async Task<Profissional> DeletarProfissional(int id)
        {
            var profissional = await _geralrepo.PegarPorId<Profissional>(id);
            if (profissional == null)
            {
                throw new NotFoundException("o profissional nao existe");
            }

            profissional.ativo = false;

            await _geralrepo.Atualizar<Profissional>(profissional);
            return profissional;
        }

        public async Task<Profissional> PegarProfissionalId(int id)
        {
            var profissional = await _geralrepo.PegarPorId<Profissional>(id);
            if (profissional == null)
            {
                throw new NotFoundException("o profissional nao existe");
            }
            return profissional;
        }

        public async Task<List<Profissional>> PegarProfissionals()
        {
            var profissionais = await _geralrepo.PegarTodos<Profissional>();
            if (profissionais == null)
            {
                throw new NotFoundException("nenhum profissional encontrado");
            }
            return profissionais;

        }
    }
}