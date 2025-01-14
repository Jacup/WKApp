﻿namespace WKApp.Domain.DAL;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();

    T? GetById(Guid id);

    void Insert(T entity);

    void Update(T entity);
}
