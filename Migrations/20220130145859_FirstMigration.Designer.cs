// <auto-generated />
using System;
using ClientApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClientApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220130145859_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClientApi.Models.Chargings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ChargingMonth")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ChargingVariantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RequestsCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChargingVariantId");

                    b.HasIndex("ClientId");

                    b.ToTable("Chargings");
                });

            modelBuilder.Entity("ClientApi.Models.ChargingVariants", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EndDate")
                        .HasColumnType("int");

                    b.Property<int>("MaxRequestsCount")
                        .HasColumnType("int");

                    b.Property<int>("MinRequestsCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartDate")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ChargingVariants");
                });

            modelBuilder.Entity("ClientApi.Models.ClientRequests", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientRequests");
                });

            modelBuilder.Entity("ClientApi.Models.Clients", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ClientApi.Models.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activated")
                        .HasColumnType("bit");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClientApi.Models.Chargings", b =>
                {
                    b.HasOne("ClientApi.Models.ChargingVariants", "ChargingVariant")
                        .WithMany("Chargings")
                        .HasForeignKey("ChargingVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClientApi.Models.Clients", "Client")
                        .WithMany("Chargings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChargingVariant");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ClientApi.Models.ClientRequests", b =>
                {
                    b.HasOne("ClientApi.Models.Clients", "Client")
                        .WithMany("ClientRequests")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ClientApi.Models.Users", b =>
                {
                    b.HasOne("ClientApi.Models.Clients", "Client")
                        .WithMany("Users")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ClientApi.Models.ChargingVariants", b =>
                {
                    b.Navigation("Chargings");
                });

            modelBuilder.Entity("ClientApi.Models.Clients", b =>
                {
                    b.Navigation("Chargings");

                    b.Navigation("ClientRequests");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
