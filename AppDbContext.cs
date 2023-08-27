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

    public DbSet<RecordCategory> RecordCategories { get; set; }
    public DbSet<ImprovementCategory> ImprovementCategories { get; set; }
    #endregion

    #region Stored Procedurese
    public DbSet<spHabitCategory> sp_HabitCategories { get; set; }

    #endregion

    #region 생성
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<HabitCategory>();
    //    modelBuilder.Entity<spHabitCategory>().HasNoKey();
    //    modelBuilder.Entity<RecordCategory>();
    //    modelBuilder.Entity<ImprovementCategory>();
    //}
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=HYANGRIMLEE-LAP\SQLEXPRESS;Database=HyangForest;User Id=hyang;Password=dmdrk103!;TrustServerCertificate=True;");
    }




}
