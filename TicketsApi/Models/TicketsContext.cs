using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TicketsApi.Models;

public partial class TicketsContext : DbContext
{
    public TicketsContext()
    {
    }

    public TicketsContext(DbContextOptions<TicketsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriesDic> CategoriesDics { get; set; }

    public virtual DbSet<ExpertsDic> ExpertsDics { get; set; }

    public virtual DbSet<ImpactDic> ImpactDics { get; set; }

    public virtual DbSet<PriorityDic> PriorityDics { get; set; }

    public virtual DbSet<StatesDic> StatesDics { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:TicketDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriesDic>(entity =>
        {
            entity.ToTable("Categories_Dic");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<ExpertsDic>(entity =>
        {
            entity.ToTable("Experts_Dic");

            entity.Property(e => e.ExpertName).HasMaxLength(50);
        });

        modelBuilder.Entity<ImpactDic>(entity =>
        {
            entity.ToTable("Impact_Dic");

            entity.Property(e => e.ImpactName).HasMaxLength(50);
        });

        modelBuilder.Entity<PriorityDic>(entity =>
        {
            entity.ToTable("Priority_Dic");

            entity.Property(e => e.PriorityName).HasMaxLength(50);
        });

        modelBuilder.Entity<StatesDic>(entity =>
        {
            entity.ToTable("States_Dic");

            entity.Property(e => e.StateName).HasMaxLength(50);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.Property(e => e.Asignee).HasColumnName("asignee");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Impact).HasColumnName("impact");
            entity.Property(e => e.LongDesc)
                .HasMaxLength(500)
                .HasColumnName("longDesc");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.Requestor).HasColumnName("requestor");
            entity.Property(e => e.SerialNumber).HasMaxLength(12);
            entity.Property(e => e.ShortDesc)
                .HasMaxLength(100)
                .HasColumnName("shortDesc");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
