using AluraFlix.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AluraFlix.Infrastructure.Context;
public static class InitialConfigDB
{
    public static void CategorialInicial(this ModelBuilder builder)
    {
        var categoria = new Categoria 
        {
            Id = 1,
            Titulo = "LIVRE",
            Cor = "#FFFFFF"
        };
        builder.Entity<Categoria>().HasData(categoria);
    }
}

