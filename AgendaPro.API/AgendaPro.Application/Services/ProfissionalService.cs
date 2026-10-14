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
                throw new NotImplementedException();
            }
            if (request.horaInicio <= TimeSpan.Zero || request.horaFim <= TimeSpan.Zero)
            {
                throw new NotImplementedException();
            }
            if (request.horaInicio >= request.horaFim)
            {
                throw new NotImplementedException();
            }

            var profissionais = await _geralrepo.PegarTodos<Profissional>();
            foreach (Profissional p in profissionais)
            {
                //Lançando uma excessao em caso de email que ja existe
                if (p.email == request.email)
                {
                    throw new NotImplementedException();
                }
                if (p.telefone == request.telefone)
                {
                    throw new NotImplementedException();
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
            if(request == null)
            {
                throw new NotImplementedException();
            }
            if(request.horaInicio <= TimeSpan.Zero || request.horaFim <= TimeSpan.Zero)
            {
                throw new NotImplementedException();
            }
            if(request.horaInicio >= request.horaFim)
            {
                throw new NotImplementedException();
            }
            

            var profissionais = await _geralrepo.PegarTodos<Profissional>();
            foreach (Profissional p in profissionais)
            {
                //Lançando uma excessao em caso de email que ja existe
                if (p.email == request.email)
                {
                    throw new NotImplementedException();
                }
                if(p.telefone == request.telefone)
                {
                    throw new NotImplementedException();
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
                throw new NotImplementedException();
            }

            profissional.ativo = false;

            await _geralrepo.Atualizar<Profissional>(profissional);
            return profissional;
        }

        public async Task<Profissional> PegarProfissionalId(int id)
        {
            var profissional = await _geralrepo.PegarPorId<Profissional>(id);
            if(profissional == null)
            {
                throw new NotImplementedException();
            }
            return profissional;
        }

        public async Task<List<Profissional>> PegarProfissionals()
        {
            var profissionais = await _geralrepo.PegarTodos<Profissional>();
            if (profissionais == null)
            {
                throw new NotImplementedException();
            }
            return profissionais;

        }
    }
}
