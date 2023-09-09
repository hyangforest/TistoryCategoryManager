using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TistoryCategoryManager;

public class AppDbContext : DbContext
{
    //private readonly string _connectionString;

    #region Table
    public DbSet<HabitCategory> HabitCategories { get; set; }

    public DbSet<ImprovementCategory> ImprovementCategories { get; set; }
    #endregion

    #region Stored Procedurese
    public DbSet<spHabitCategory> sp_HabitCategories { get; set; }
    public DbSet<spImprovementCategory> sp_ImprovementCategories { get; set; }
    #endregion

    #region 생성
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<HabitCategory>();
        //modelBuilder.Entity<ImprovementCategory>();
        //modelBuilder.Entity<spHabitCategory>().HasNoKey();
    }
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-26M1QHH\SQLEXPRESS;Database=HyangForest;User Id=hyang;Password=dmdrk103!;TrustServerCertificate=True;");
        //optionsBuilder.UseSqlServer(@"Server=ms1901.gabiadb.com;Database=hyangforest;User Id=hyang;Password=hyangrimlee93*;TrustServerCertificate=True;");
    }




}
