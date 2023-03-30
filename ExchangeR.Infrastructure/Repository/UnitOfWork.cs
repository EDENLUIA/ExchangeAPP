using ExchangeR.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeR.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }


        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
