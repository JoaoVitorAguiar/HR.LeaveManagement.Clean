using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly HrDatabaseContext _context;

    public GenericRepository(HrDatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        var records =  await _context.SaveChangesAsync();
        return (records > 0); 
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _context.Remove(entity);
        var records = await _context.SaveChangesAsync();
        return (records > 0);
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        var records = await _context.SaveChangesAsync();
        return (records > 0);
    }
}
