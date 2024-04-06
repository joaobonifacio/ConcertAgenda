using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Infrastructure.Data;

public partial class ConcertsAgendaContext : DbContext
{
    public ConcertsAgendaContext()
    {
    }

    public ConcertsAgendaContext(DbContextOptions<ConcertsAgendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Concert> Concerts { get; set; }

    public virtual DbSet<ConcertArtist> ConcertArtists { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<SubGenre> SubGenres { get; set; }

    public virtual DbSet<TicketOption> TicketOptions { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseSqlServer("DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("PK__Artists__25706B50CB9EAF78");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Genre).WithMany(p => p.Artists)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_Artists_Genre");

            entity.HasMany(d => d.SubGenres).WithMany(p => p.Artists)
                .UsingEntity<Dictionary<string, object>>(
                    "ArtistSubGenre",
                    r => r.HasOne<SubGenre>().WithMany()
                        .HasForeignKey("SubGenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ArtistSub__SubGe__5CD6CB2B"),
                    l => l.HasOne<Artist>().WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ArtistSub__Artis__5BE2A6F2"),
                    j =>
                    {
                        j.HasKey("ArtistId", "SubGenreId").HasName("PK__ArtistSu__A066F4605093ABF8");
                    });
        });

        modelBuilder.Entity<Concert>(entity =>
        {
            entity.HasKey(e => e.ConcertId).HasName("PK__Concerts__06ED37ACB4A6CDDE");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Venue).WithMany(p => p.Concerts)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Concerts__VenueI__4D94879B");
        });

        modelBuilder.Entity<ConcertArtist>(entity =>
        {
            entity.HasKey(e => e.ConcertArtistId).HasName("PK__ConcertA__9D9A38C1272D59E0");

            entity.Property(e => e.PerformanceStartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Artist).WithMany(p => p.ConcertArtists)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ConcertAr__Artis__5165187F");

            entity.HasOne(d => d.Concert).WithMany(p => p.ConcertArtists)
                .HasForeignKey(d => d.ConcertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ConcertAr__Conce__5070F446");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385057EE461D2BA");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubGenre>(entity =>
        {
            entity.HasKey(e => e.SubGenreId).HasName("PK__SubGenre__5169F309B877EF55");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Genre).WithMany(p => p.SubGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubGenres__Genre__59063A47");
        });

        modelBuilder.Entity<TicketOption>(entity =>
        {
            entity.HasKey(e => e.TicketOptionId).HasName("PK__TicketOp__E71CA699E218D1E4");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Concert).WithMany(p => p.TicketOptions)
                .HasForeignKey(d => d.ConcertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TicketOpt__Conce__5441852A");
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.VenueId).HasName("PK__Venues__3C57E5F21DAA0F2D");

            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
