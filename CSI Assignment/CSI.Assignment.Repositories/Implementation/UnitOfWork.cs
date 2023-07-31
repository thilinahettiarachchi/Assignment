using CSI.Assignment.Entity.Context;
using CSI.Assignment.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Assignment.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<Type, object> repositories;

        private readonly DataContext _context;
        public IEmployeeRepository Employees { get; }

        public UnitOfWork(DataContext employeeDbContext,
            IEmployeeRepository employeeRepository)
        {
            this._context = employeeDbContext;

            this.Employees = employeeRepository;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
