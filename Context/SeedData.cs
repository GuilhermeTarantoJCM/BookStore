using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.Context
{
    public static class SeedData
    {
        public static void Initialize()
        {
            Console.WriteLine("Iniciando migração...");
        }

            
    }
}
