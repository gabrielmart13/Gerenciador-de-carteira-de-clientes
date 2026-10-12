using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Infrastructure.Repositories.Interfaces
{
    public interface IGeralRepo
    {
        Task<T> Adicionar<T>(T entity) where T : class;
        Task<T> Atualizar<T>(T entity) where T : class;
        Task<T?> PegarPorId<T>(int id) where T : class;
        Task <List<T>> PegarTodos<T>(T entity) where T : class;
        Task<T> Remover<T>(T entity) where T : class;

    }
}
