using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStoreApp.Api.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser> //inherits from IdentityDbContext and should look to ApiUser (my class)
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //pernaw sto IdentityDbContext to model builder gua na boun kai ta modela mou

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Summary).HasMaxLength(250);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId);
            });

            //add defualt roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                   Name = "User",
                   NormalizedName = "USER", //capitalized version of the name
                   Id = "3cb9691c-6cd9-48b8-95d2-7453b28e0966"
                },
                 new IdentityRole
                 {
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR", //capitalized version of the name
                     Id = "2193e614-a340-4538-8963-e547f9d4d71b"
                 }
            );

            //add defualt users

            var hasher = new PasswordHasher<ApiUser>(); //to hash password to default users

            modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                     Id = "892a2d96-b408-4ec7-b1dd-a37762b0a930",
                     Email = "admin@bookstore.com",
                     NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                     UserName = "admin@bookstore.com",
                     NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                     FirstName = "System",
                     LastName = "Admin",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1")
                },
                 new ApiUser
                 {
                     Id = "2353ed45-0f07-4744-89b2-8b66508fb603",
                     Email = "user@bookstore.com",
                     NormalizedEmail = "USER@BOOKSTORE.COM",
                     UserName = "user@bookstore.com",
                     NormalizedUserName = "USER@BOOKSTORE.COM",
                     FirstName = "System",
                     LastName = "User",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1")
                 }
            );

            //assign role to default users
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "3cb9691c-6cd9-48b8-95d2-7453b28e0966",
                    UserId = "2353ed45-0f07-4744-89b2-8b66508fb603"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2193e614-a340-4538-8963-e547f9d4d71b",
                    UserId = "892a2d96-b408-4ec7-b1dd-a37762b0a930"
                }
           );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
