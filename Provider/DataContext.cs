﻿using Microsoft.EntityFrameworkCore;
using APIWebApp.Models;

namespace APIWebApp.Provider
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }

    }
}
