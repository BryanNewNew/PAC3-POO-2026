using Microsoft.EntityFrameworkCore;
using Planillas.API.Entities;

namespace Planillas.API.Database
{
    public class PlanillasDbContext : DbContext//Esta clase es la base de datos como tal
    {
        public PlanillasDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<EmployeeEntity> Employees { get; set; }//Esta va a ser la tabla, 
        //es una tabla dentro de la base de datos que es todo el contexto de arriba

    }
}