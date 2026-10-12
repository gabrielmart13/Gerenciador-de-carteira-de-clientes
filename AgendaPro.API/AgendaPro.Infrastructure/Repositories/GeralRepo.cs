using AgendaPro.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaPro.Infrastructure.Repositories
{
    public class GeralRepo : IGeralRepo
    {
        private readonly DataContext _dataContext;

        public GeralRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<T> Adicionar<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Atualizar<T>(T entity) where T : class
        {
            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> PegarPorId<T>(int id) where T : class
        {
            var entity = await _dataContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<List<T>> PegarTodos<T>(T entity) where T : class
        {
            var entities = await _dataContext.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> Remover<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

    }
}
