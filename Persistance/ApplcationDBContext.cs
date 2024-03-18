﻿using Microsoft.EntityFrameworkCore;
using Reddit.Models;

namespace Reddit.Persistance
{
    public class ApplcationDBContext : DbContext
    {
        public ApplcationDBContext(DbContextOptions<ApplcationDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Community> Community { get; set; }
    }
}
