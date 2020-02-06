﻿// <auto-generated />
using System;
using EGobX.NTemplate.Infraestructure.EFCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EGobX.NTemplate.Infraestructure.EFCore.SqlServer.Migrations
{
    [DbContext(typeof(TemplateContext))]
    [Migration("20191127214744_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EGobX.NTemplate.Domain.Entities.Template", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TemplateId");

                    b.Property<int>("Folio").ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("IsActive")
                        .HasColumnName("Active");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id")
                        .HasName("PK_Template_TemplateId");

                    b.ToTable("Template","catalog");
                });
#pragma warning restore 612, 618
        }
    }
}
