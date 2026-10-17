using AgendaPro.Application.Exceptions;
using AgendaPro.Application.DTOs.ServicoDTO;
using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Models;
using AgendaPro.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Application.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IGeralRepo _geralrepo;
        public ServicoService(IGeralRepo geralrepo)
        {
            _geralrepo = geralrepo;
        }
        public async Task<Servico> AtualizarServico(int id, AtualizarServicoRequest request)
        {
            if (request == null)
            {
                throw new ValidationException("os dados para atualizar o servico sao nulos");
            }
            if (request.duracaoMinutos <= TimeSpan.Zero)
            {
                throw new ValidationException("a duracao do servico deve ser maior que 0");
            }
            if (request.preco < 0)
            {
                throw new ValidationException("o preco do servico nao pode ser negativo");
            }
            var servicos = await _geralrepo.PegarTodos<Servico>();
            foreach (Servico s in servicos)
            {
                if (s.nome == request.nome)
                {
                    throw new ConflictException("ja existe um servico com esse nome");
                }
            }

            var servico = await _geralrepo.PegarPorId<Servico>(id);


            servico.duracaoMinutos = request.duracaoMinutos;
            servico.preco = request.preco;
            servico.descricao = request.descricao;
            servico.nome = request.nome;

            await _geralrepo.Atualizar<Servico>(servico);
            return servico;

        }

        public async Task<Servico> CriarServico(CriarServicoRequest request)
        {
            if (request == null)
            {
                throw new ValidationException("os dados para criar o servico sao nulos");
            }
            if (request.duracaoMinutos <= TimeSpan.Zero)
            {
                throw new ValidationException("a duracao do servico deve ser maior que 0");
            }
            if (request.preco < 0)
            {
                throw new ValidationException("o preco do servico nao pode ser negativo");
            }
            var servicos = await _geralrepo.PegarTodos<Servico>();
            foreach (Servico s in servicos)
            {
                if (s.nome == request.nome)
                {
                    throw new ConflictException("ja existe um servico com esse nome");
                }
            }

            var servico = new Servico
            {
                nome = request.nome,
                descricao = request.descricao,
                duracaoMinutos = request.duracaoMinutos,
                preco = request.preco,
                ativo = true
            };

            await _geralrepo.Adicionar<Servico>(servico);
            return servico;
        }

        public async Task<Servico> DeletarServico(int id)
        {
            var servico = await _geralrepo.PegarPorId<Servico>(id);
            if (servico == null)
            {
                throw new NotFoundException("o servico nao existe");
            }

            servico.ativo = false;
            await _geralrepo.Atualizar<Servico>(servico);
            return servico;
        }

        public async Task<Servico> PegarServicoId(int id)
        {
            var servico = await _geralrepo.PegarPorId<Servico>(id);
            if (servico == null)
            {
                throw new NotFoundException("o servico nao existe");
            }

            return servico;
        }

        public async Task<List<Servico>> PegarServicos()
        {
            var servicos = await _geralrepo.PegarTodos<Servico>();
            if (servicos == null)
            {
                throw new NotFoundException("nenhum servico encontrado");
            }

            return servicos;
        }
    }
}