using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SbsLib
{
    public class SbsContext: DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<Owner> SquareOwners { get; set; }

        public SbsContext(DbContextOptions<SbsContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().HasMany<Square>().WithOne(square => square.Board);
            modelBuilder.Entity<Board>().HasOne<Owner>().WithMany(owner => owner.Boards);
            modelBuilder.Entity<Square>().HasOne<Owner>().WithMany(owner => owner.Squares);
            modelBuilder.Entity<Owner>().HasMany<Square>().WithOne(square => square.Owner);
            modelBuilder.Entity<Owner>().HasMany<Board>().WithOne(board => board.Owner);
            base.OnModelCreating(modelBuilder);
        }
    }
}
