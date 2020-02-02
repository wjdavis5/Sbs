using Microsoft.EntityFrameworkCore;

namespace SbsWeb.Data
{
    public class SbsContext: DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public SbsContext(DbContextOptions<SbsContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasIndex(owner => owner.EmailAddress);

                modelBuilder.Entity<Square>()
                .HasOne<Board>(s => s.Board)
                .WithMany(board => board.Squares)
                .HasForeignKey(square => square.BoardId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Square>()
                .HasOne<Owner>(o => o.Owner)
                .WithMany(owner => owner.Squares)
                .HasForeignKey(square => square.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Board>()
                .HasOne<Owner>(o => o.Owner)
                .WithMany(b => b.Boards)
                .HasForeignKey(board => board.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Square>(builder =>
            //{
            //    builder.HasKey(x => x.Id);
            //    builder.HasOne<Owner>(x => x.Owner)
            //        .WithMany()
            //        .HasForeignKey(square => square.OwnerId)
            //        .OnDelete(DeleteBehavior.NoAction);

            //    builder.HasOne<Board>(x => x.Board)
            //        .WithMany()
            //        .HasForeignKey(x => x.BoardId)
            //        .OnDelete(DeleteBehavior.NoAction);
            //});


            //modelBuilder.Entity<Board>(builder =>
            //{
            //    builder.HasKey(x => x.Id);
            //    builder.HasOne<Owner>(x => x.Owner)
            //        .WithMany()
            //        .HasForeignKey(board => board.OwnerId)
            //        .OnDelete(DeleteBehavior.NoAction);
            //});


            base.OnModelCreating(modelBuilder);
        }
    }
}
