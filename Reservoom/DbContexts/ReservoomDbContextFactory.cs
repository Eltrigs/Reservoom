using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.DbContexts
{
   public class ReservoomDbContextFactory
   {
        private readonly string m_connectionString;

        public ReservoomDbContextFactory(string connectionString)
        {
            m_connectionString = connectionString;
        }

        public ReservoomDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(m_connectionString).Options;

            return new ReservoomDbContext(options);
        }
   }
}
