﻿// <auto-generated />
using System;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(HarryPotterContext))]
    partial class HarryPotterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("authorId");

                    b.Property<string>("AuthorName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("authorName");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("AuthorId")
                        .HasName("PK__author__8E2731B93441940C");

                    b.ToTable("author", (string)null);

                    b.HasData(
                        new
                        {
                            AuthorId = new Guid("6e6a84dd-04a6-4a70-b316-710636cc487f"),
                            AuthorName = "J.K. Rowling",
                            IsDeleted = false
                        },
                        new
                        {
                            AuthorId = new Guid("a72db391-9ccf-44a2-a2a6-fe67754e0bd3"),
                            AuthorName = "J.R.R. Tolkien",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Domain.Models.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("bookId");

                    b.Property<string>("ArticleNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("authorId");

                    b.Property<string>("Genre")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("genre");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("Pages")
                        .HasColumnType("int")
                        .HasColumnName("pages");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PubYear")
                        .HasColumnType("datetime")
                        .HasColumnName("pubYear");

                    b.Property<decimal?>("Rating")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("rating");

                    b.Property<string>("Summary")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("summary");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("title");

                    b.HasKey("BookId")
                        .HasName("PK__book__8BE5A10DE068B40D");

                    b.HasIndex("AuthorId");

                    b.ToTable("book", (string)null);

                    b.HasData(
                        new
                        {
                            BookId = new Guid("eb623ae5-22a4-4d0e-8f5b-4268516ba439"),
                            ArticleNumber = "78100468-aaf3-4be2-91a6-03eea6b24c5f",
                            AuthorId = new Guid("6e6a84dd-04a6-4a70-b316-710636cc487f"),
                            Genre = "Fantasy",
                            IsDeleted = true,
                            Pages = 223,
                            Price = 20,
                            PubYear = new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 4.5m,
                            Summary = "A young wizard starts his journey.",
                            Title = "Harry Potter and the Sorcerer's Stone"
                        },
                        new
                        {
                            BookId = new Guid("8968fbc4-ff3a-4efa-9f8f-7688a945fd3d"),
                            ArticleNumber = "e999f343-5d08-465e-93e3-16ec11f7422d",
                            AuthorId = new Guid("a72db391-9ccf-44a2-a2a6-fe67754e0bd3"),
                            Genre = "Fantasy",
                            IsDeleted = false,
                            Pages = 310,
                            Price = 15,
                            PubYear = new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 4.7m,
                            Summary = "A hobbit's adventure.",
                            Title = "The Hobbit"
                        });
                });

            modelBuilder.Entity("Domain.Models.PurchaseHistory", b =>
                {
                    b.Property<Guid>("PurchaseHistoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("purchaseHistoryId");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.HasKey("PurchaseHistoryId")
                        .HasName("PK__purchase__0261226C79359CBF");

                    b.HasIndex("UserId");

                    b.ToTable("purchaseHistory", (string)null);

                    b.HasData(
                        new
                        {
                            PurchaseHistoryId = new Guid("bb52e8bb-0875-494b-9af2-13a7e2c12979"),
                            UserId = new Guid("a10a835e-3510-4b94-b5a5-99c3646cd20b")
                        });
                });

            modelBuilder.Entity("Domain.Models.Receipt", b =>
                {
                    b.Property<Guid>("ReceiptId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ReceiptId");

                    b.Property<Guid?>("BookId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("bookId");

                    b.Property<DateTime?>("DateDetail")
                        .HasColumnType("datetime")
                        .HasColumnName("dateDetail");

                    b.Property<Guid?>("PurchaseHistoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("purchaseHistoryId");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("ReceiptId")
                        .HasName("PK__purchase__FA43B55BADA17CED");

                    b.HasIndex("PurchaseHistoryId");

                    b.ToTable("Receipt", (string)null);

                    b.HasData(
                        new
                        {
                            ReceiptId = new Guid("b3e48d10-685d-428f-a9d7-bcdf404b031b"),
                            BookId = new Guid("eb623ae5-22a4-4d0e-8f5b-4268516ba439"),
                            DateDetail = new DateTime(2024, 2, 4, 17, 46, 56, 583, DateTimeKind.Utc).AddTicks(106),
                            PurchaseHistoryId = new Guid("bb52e8bb-0875-494b-9af2-13a7e2c12979"),
                            Quantity = 1,
                            TotalPrice = 20
                        });
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("firstName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("surName");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("telephoneNumber");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("userName");

                    b.HasKey("UserId")
                        .HasName("PK__user__CB9A1CFF7FE751DC");

                    b.ToTable("user", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("a10a835e-3510-4b94-b5a5-99c3646cd20b"),
                            Email = "mail@gmail.com",
                            FirstName = "Test",
                            Password = "$2a$11$zrnTwAxFkpaAFxHgw2a0YeDW0391buXJCtg6NZdZX2kWTle3LNTua",
                            SurName = "Test",
                            TelephoneNumber = "+467000000",
                            UserName = "AnvändareTest"
                        },
                        new
                        {
                            UserId = new Guid("6997040a-d2fc-4d03-8fe3-887d48ca0814"),
                            Email = "admin@gmail.com",
                            FirstName = "Admin",
                            Password = "$2a$11$i9TQgQDcg493dltN05ksEeEc90UzqR.1/2330qhvwRCLW9y9ypxO2",
                            SurName = "Admin",
                            TelephoneNumber = "+4671111111",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Domain.Models.Wallet", b =>
                {
                    b.Property<Guid>("WalletId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("walletId");

                    b.Property<int>("Balance")
                        .HasColumnType("int")
                        .HasColumnName("balance");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.HasKey("WalletId")
                        .HasName("PK__wallet__3785C8706E62B1A8");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("wallet", (string)null);

                    b.HasData(
                        new
                        {
                            WalletId = new Guid("085a365a-038d-448b-b577-df945570cd3d"),
                            Balance = 100,
                            UserId = new Guid("a10a835e-3510-4b94-b5a5-99c3646cd20b")
                        });
                });

            modelBuilder.Entity("Domain.Models.Book", b =>
                {
                    b.HasOne("Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK__book__authorId__4222D4EF");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Domain.Models.PurchaseHistory", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("PurchaseHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__purchaseH__userI__412EB0B6");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Receipt", b =>
                {
                    b.HasOne("Domain.Models.PurchaseHistory", "PurchaseHistories")
                        .WithMany("Receipts")
                        .HasForeignKey("PurchaseHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__purchaseD__purch__4316F928");

                    b.Navigation("PurchaseHistories");
                });

            modelBuilder.Entity("Domain.Models.Wallet", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithOne("Wallet")
                        .HasForeignKey("Domain.Models.Wallet", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Domain.Models.PurchaseHistory", b =>
                {
                    b.Navigation("Receipts");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("PurchaseHistories");

                    b.Navigation("Wallet")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
