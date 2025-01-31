﻿using DistributedCaching.Models;
using Microsoft.EntityFrameworkCore;

namespace DistributedCaching.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}


    public DbSet<User> User { get; set; }

}
