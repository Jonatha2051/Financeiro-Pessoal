using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Financeiro_Pessoal.Models;

namespace Financeiro_Pessoal.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
            
        }

        public DbSet<Individuo> Individuos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Financeiro> Financeiro { get; set; }
    }
}