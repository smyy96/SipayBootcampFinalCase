﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.Data;

#nullable disable

namespace WebApi.Data.Migrations
{
    [DbContext(typeof(SiteManagementDbContext))]
    partial class SiteManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApi.Data.Entity.Apartment", b =>
                {
                    b.Property<int>("ApartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApartmentID"), 1L, 1);

                    b.Property<string>("ApartmentNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int?>("ResidentId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ApartmentID");

                    b.HasIndex("ApartmentNumber")
                        .IsUnique();

                    b.HasIndex("ResidentId")
                        .IsUnique();

                    b.ToTable("Apartment", "dbo");
                });

            modelBuilder.Entity("WebApi.Data.Entity.Bill", b =>
                {
                    b.Property<int>("BillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BillID"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("ApartmentID")
                        .HasColumnType("int");

                    b.Property<string>("BillType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("BillID");

                    b.HasIndex("ApartmentID");

                    b.ToTable("Bill", "dbo");
                });

            modelBuilder.Entity("WebApi.Data.Entity.Dues", b =>
                {
                    b.Property<int>("DuestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DuestID"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("ApartmentID")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("DuestID");

                    b.HasIndex("ApartmentID");

                    b.ToTable("Dues", "dbo");
                });

            modelBuilder.Entity("WebApi.Data.Entity.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManagerId"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManagerId");

                    b.ToTable("Manager", "dbo");
                });

            modelBuilder.Entity("WebApi.Data.Entity.ManagerMessage", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int>("ReceiverResidentId")
                        .HasColumnType("int");

                    b.Property<int>("SenderManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiverResidentId");

                    b.HasIndex("SenderManagerId");

                    b.ToTable("ManagerMessage", "dbo");
                });

            modelBuilder.Entity("WebApi.Data.Entity.Resident", b =>
                {
                    b.Property<int>("ResidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResidentId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TCNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("VehiclePlate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ResidentId");

                    b.ToTable("Resident", "dbo");
                });

            modelBuilder.Entity("WebApi.Data.Entity.ResidentMessage", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int>("ReceiverManagerId")
                        .HasColumnType("int");

                    b.Property<int>("SenderResidentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiverManagerId");

                    b.HasIndex("SenderResidentId");

                    b.ToTable("ResidentMessage", "dbo");
                });

            modelBuilder.Entity("WebApi.Data.Entity.Apartment", b =>
                {
                    b.HasOne("WebApi.Data.Entity.Resident", "Resident")
                        .WithOne("Apartment")
                        .HasForeignKey("WebApi.Data.Entity.Apartment", "ResidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("WebApi.Data.Entity.Bill", b =>
                {
                    b.HasOne("WebApi.Data.Entity.Apartment", "Apartments")
                        .WithMany("Bills")
                        .HasForeignKey("ApartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("WebApi.Data.Entity.Dues", b =>
                {
                    b.HasOne("WebApi.Data.Entity.Apartment", "Apartment")
                        .WithMany("Dueses")
                        .HasForeignKey("ApartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("WebApi.Data.Entity.ManagerMessage", b =>
                {
                    b.HasOne("WebApi.Data.Entity.Resident", "ReceiverResident")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ReceiverResidentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApi.Data.Entity.Manager", "SenderManager")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ReceiverResident");

                    b.Navigation("SenderManager");
                });

            modelBuilder.Entity("WebApi.Data.Entity.ResidentMessage", b =>
                {
                    b.HasOne("WebApi.Data.Entity.Manager", "ReceiverManager")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ReceiverManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApi.Data.Entity.Resident", "SenderResident")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderResidentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ReceiverManager");

                    b.Navigation("SenderResident");
                });

            modelBuilder.Entity("WebApi.Data.Entity.Apartment", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Dueses");
                });

            modelBuilder.Entity("WebApi.Data.Entity.Manager", b =>
                {
                    b.Navigation("ReceivedMessages");

                    b.Navigation("SentMessages");
                });

            modelBuilder.Entity("WebApi.Data.Entity.Resident", b =>
                {
                    b.Navigation("Apartment")
                        .IsRequired();

                    b.Navigation("ReceivedMessages");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
