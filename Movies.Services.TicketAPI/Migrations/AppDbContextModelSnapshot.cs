﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movies.Services.TicketAPI.Data;

#nullable disable

namespace Movies.Services.TicketAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Movies.Services.TicketAPI.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<string>("TicketCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TicketPrice")
                        .HasColumnType("float");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            TicketId = 1,
                            TicketCode = "123A",
                            TicketPrice = 10.0
                        },
                        new
                        {
                            TicketId = 2,
                            TicketCode = "123B",
                            TicketPrice = 15.0
                        },
                        new
                        {
                            TicketId = 3,
                            TicketCode = "123C",
                            TicketPrice = 17.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
