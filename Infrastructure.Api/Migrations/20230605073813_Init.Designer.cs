﻿// <auto-generated />
using System;
using Infrastructure.Api.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230605073813_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Api.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("author");

                    b.Property<Guid?>("CommentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("text");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid")
                        .HasColumnName("post");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CommentId");

                    b.HasIndex("PostId");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("Domain.Api.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid")
                        .HasColumnName("author");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("Domain.Api.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Domain.Api.IdentityEntity.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Domain.Api.IdentityEntity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.Property<Guid>("PermissionsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RolesId")
                        .HasColumnType("uuid");

                    b.HasKey("PermissionsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("PermissionRole");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("Domain.Api.Entities.Comment", b =>
                {
                    b.HasOne("Domain.Api.Entities.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Api.Entities.Comment", null)
                        .WithMany("ChildComments")
                        .HasForeignKey("CommentId");

                    b.HasOne("Domain.Api.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Domain.Api.Entities.Post", b =>
                {
                    b.HasOne("Domain.Api.Entities.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.HasOne("Domain.Api.IdentityEntity.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Api.IdentityEntity.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Domain.Api.IdentityEntity.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Api.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Api.Entities.Comment", b =>
                {
                    b.Navigation("ChildComments");
                });

            modelBuilder.Entity("Domain.Api.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Domain.Api.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
