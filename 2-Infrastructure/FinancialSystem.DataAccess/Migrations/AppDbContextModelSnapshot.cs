﻿// <auto-generated />
using FinancialSystem.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinancialSystem.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("FS")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("FinancialSystem.Domain.Invoices.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Amount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("FinancialSystem.Domain.Invoices.Entities.InvoiceNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceNote");
                });

            modelBuilder.Entity("FinancialSystem.Domain.Invoices.Entities.InvoiceNote", b =>
                {
                    b.HasOne("FinancialSystem.Domain.Invoices.Entities.Invoice", null)
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
