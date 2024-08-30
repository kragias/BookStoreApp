﻿using BookStoreApp.Api.Models;

namespace BookStoreApp.Api.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
        Task<VirtualizeResponse<TResult>> GetAllAsync<TResult>(QueryParameters queryParams) where TResult : class;
    }
}
