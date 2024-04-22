﻿// <auto-generated />
using System;
using ITStudy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ITStudy.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240422073537_10")]
    partial class _10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ITStudy.Models.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("QuantityCourse")
                        .HasColumnType("bigint");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TotalPrice")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("ITStudy.Models.CartItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<long>("CoursesId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CoursesId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("ITStudy.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ITStudy.Models.Courses", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Durations")
                        .HasColumnType("integer");

                    b.Property<int?>("LectureCount")
                        .HasColumnType("integer");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ITStudy.Models.Instructors", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Avatars")
                        .HasColumnType("text");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CoursesTaught")
                        .HasColumnType("bigint");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Posts")
                        .HasColumnType("bigint");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("ITStudy.Models.Lectures", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Descriptions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Durations")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Video")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("ITStudy.Models.Posts", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<int?>("CommentCount")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Dislikes")
                        .HasColumnType("integer");

                    b.Property<long>("InstructorId")
                        .HasColumnType("bigint");

                    b.Property<int>("Likes")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("PostTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ITStudy.Models.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ITStudy.Models.Users", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ITStudy.Models.Vouchers", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<int>("Discount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Expire_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Public_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TeacherId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("UsersId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("UsersId");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("ITStudy.Models.Cart", b =>
                {
                    b.HasOne("ITStudy.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ITStudy.Models.CartItem", b =>
                {
                    b.HasOne("ITStudy.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITStudy.Models.Courses", "Courses")
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ITStudy.Models.Courses", b =>
                {
                    b.HasOne("ITStudy.Models.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITStudy.Models.Student", null)
                        .WithMany("Courses")
                        .HasForeignKey("StudentId");

                    b.HasOne("ITStudy.Models.Instructors", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ITStudy.Models.Instructors", b =>
                {
                    b.HasOne("ITStudy.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ITStudy.Models.Lectures", b =>
                {
                    b.HasOne("ITStudy.Models.Courses", "Course")
                        .WithMany("Lectures")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ITStudy.Models.Posts", b =>
                {
                    b.HasOne("ITStudy.Models.Instructors", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ITStudy.Models.Student", b =>
                {
                    b.HasOne("ITStudy.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ITStudy.Models.Vouchers", b =>
                {
                    b.HasOne("ITStudy.Models.Courses", "Course")
                        .WithMany("Voucher")
                        .HasForeignKey("CourseId");

                    b.HasOne("ITStudy.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("ITStudy.Models.Instructors", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.HasOne("ITStudy.Models.Users", null)
                        .WithMany("Voucher")
                        .HasForeignKey("UsersId");

                    b.Navigation("Course");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ITStudy.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("ITStudy.Models.Category", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ITStudy.Models.Courses", b =>
                {
                    b.Navigation("Lectures");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("ITStudy.Models.Instructors", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ITStudy.Models.Student", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ITStudy.Models.Users", b =>
                {
                    b.Navigation("Voucher");
                });
#pragma warning restore 612, 618
        }
    }
}
