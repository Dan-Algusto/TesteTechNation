using Microsoft.EntityFrameworkCore;
using TechNationTeste.Models;

namespace TesteTechNation.Models
{
    public class Contexto : DbContext
    {
        public Contexto (DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<NotaFiscal> notasFiscais { get; set; }

    }
}
