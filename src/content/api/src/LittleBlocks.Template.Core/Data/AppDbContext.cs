﻿using LittleBlocks.Ef;
using LittleBlocks.Http;
using Microsoft.EntityFrameworkCore;

namespace LittleBlocks.Template.Core.Data
{
    public sealed class AppDbContext : DbContextBase
    {
        public AppDbContext(DbContextOptions options, IOperationContext context) : base(options, context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Add the mappings here
        }
    }
}