using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebMovie.Models;

public partial class MovieContext : DbContext
{
    public MovieContext()
    {
    }

    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CUONGSEVEN\\MSSQLSERVER01;Initial Catalog=Movie;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.ToTable("Actor");

            entity.Property(e => e.ActorId).HasColumnName("ActorID");
            entity.Property(e => e.ActorName).HasMaxLength(50);
            entity.Property(e => e.Nationaly).HasMaxLength(50);
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AdminName).HasMaxLength(50);
            entity.Property(e => e.PassWord)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.Comment1).HasColumnName("Comment");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DirectorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("DirectorID");
            entity.Property(e => e.DirectorName).HasMaxLength(50);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("Movie");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.DirectorId).HasColumnName("DirectorID");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.Rating)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsersId);

            entity.ToTable("User");

            entity.Property(e => e.UsersId).HasColumnName("UsersID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.PassWord).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    internal async Task GetMovieAsync(string title)
    {
        throw new NotImplementedException();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
