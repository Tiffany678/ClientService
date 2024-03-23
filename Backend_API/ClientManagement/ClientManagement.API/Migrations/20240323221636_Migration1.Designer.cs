﻿// <auto-generated />
using System;
using ClientManagement.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClientManagement.API.Migrations
{
    [DbContext(typeof(ClientsDbContext))]
    [Migration("20240323221636_Migration1")]
    partial class Migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClientManagement.API.Models.Domain.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HelpServicesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HelpServicesId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ClientManagement.API.Models.Domain.HelpService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HelpServices");

                    b.HasData(
                        new
                        {
                            Id = new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                            Description = "Family Service League provides prevention and comprehensive addiction treatment services to Suffolk county adults and adolescents—along with help and support to the families who love them. Our program features screenings, assessments and evaluations to determine the level of care needed to support outpatient recovery and abstinence.",
                            ServiceName = "Addiction Treatment Services"
                        },
                        new
                        {
                            Id = new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                            Description = "Family Service League provides a wide range of children and family services to help ensure that every child in Suffolk county has the opportunity to excel and choose the right path no matter their home situation.",
                            ServiceName = "Children Services"
                        },
                        new
                        {
                            Id = new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                            Description = "Chronic unemployment and underemployment are often at the root of individual and family hardship and dysfunction. Family Service League has a series of proven job training and vocational programs designed to build skills and confidence.",
                            ServiceName = "Training & Employment"
                        });
                });

            modelBuilder.Entity("ClientManagement.API.Models.Domain.Client", b =>
                {
                    b.HasOne("ClientManagement.API.Models.Domain.HelpService", "HelpServices")
                        .WithMany()
                        .HasForeignKey("HelpServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HelpServices");
                });
#pragma warning restore 612, 618
        }
    }
}
