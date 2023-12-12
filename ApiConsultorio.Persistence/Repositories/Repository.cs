﻿using ApiConsultorio.Domain.Common;
using ApiConsultorio.Domain.Interfaces;
using ApiConsultorio.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiConsultorio.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly AppDbContext _db;
    protected readonly DbSet<TEntity> DbSet;
    protected Repository(AppDbContext db)
    {
        _db = db;
        DbSet = db.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int? id)
    {
        var entity = await DbSet.FindAsync(id);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await DbSet.ToListAsync(cancellationToken);
        return entities;
    }

    public async Task AddAsync(TEntity entity)
    {
        DbSet.Add(entity);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveAsync(int? id)
    {
        var entity = await DbSet.FindAsync(id);
        DbSet.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db?.Dispose();
    }
}
