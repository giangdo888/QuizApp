﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuizApp.AppDbContext;

#nullable disable

namespace QuizApp.Migrations
{
    [DbContext(typeof(QuizAppDbContext))]
    [Migration("20241114051123_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuestionsQuizzes", b =>
                {
                    b.Property<int>("QuestionsId")
                        .HasColumnType("integer");

                    b.Property<int>("QuizzesId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionsId", "QuizzesId");

                    b.HasIndex("QuizzesId");

                    b.ToTable("QuestionsQuizzes");

                    b.HasData(
                        new
                        {
                            QuestionsId = 1,
                            QuizzesId = 1
                        },
                        new
                        {
                            QuestionsId = 2,
                            QuizzesId = 1
                        },
                        new
                        {
                            QuestionsId = 3,
                            QuizzesId = 1
                        },
                        new
                        {
                            QuestionsId = 4,
                            QuizzesId = 1
                        },
                        new
                        {
                            QuestionsId = 5,
                            QuizzesId = 1
                        },
                        new
                        {
                            QuestionsId = 6,
                            QuizzesId = 2
                        },
                        new
                        {
                            QuestionsId = 7,
                            QuizzesId = 2
                        },
                        new
                        {
                            QuestionsId = 8,
                            QuizzesId = 2
                        },
                        new
                        {
                            QuestionsId = 9,
                            QuizzesId = 2
                        },
                        new
                        {
                            QuestionsId = 10,
                            QuizzesId = 2
                        });
                });

            modelBuilder.Entity("QuizApp.Models.Answers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<int>("QuestionsId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionsId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCorrect = true,
                            QuestionsId = 1,
                            Text = "Paris"
                        },
                        new
                        {
                            Id = 2,
                            IsCorrect = false,
                            QuestionsId = 1,
                            Text = "Berlin"
                        },
                        new
                        {
                            Id = 3,
                            IsCorrect = false,
                            QuestionsId = 1,
                            Text = "Madrid"
                        },
                        new
                        {
                            Id = 4,
                            IsCorrect = false,
                            QuestionsId = 1,
                            Text = "Rome"
                        },
                        new
                        {
                            Id = 5,
                            IsCorrect = true,
                            QuestionsId = 2,
                            Text = "Africa"
                        },
                        new
                        {
                            Id = 6,
                            IsCorrect = false,
                            QuestionsId = 2,
                            Text = "Asia"
                        },
                        new
                        {
                            Id = 7,
                            IsCorrect = false,
                            QuestionsId = 2,
                            Text = "Europe"
                        },
                        new
                        {
                            Id = 8,
                            IsCorrect = false,
                            QuestionsId = 2,
                            Text = "South America"
                        },
                        new
                        {
                            Id = 9,
                            IsCorrect = false,
                            QuestionsId = 3,
                            Text = "Nile"
                        },
                        new
                        {
                            Id = 10,
                            IsCorrect = true,
                            QuestionsId = 3,
                            Text = "Amazon"
                        },
                        new
                        {
                            Id = 11,
                            IsCorrect = false,
                            QuestionsId = 3,
                            Text = "Yangtze"
                        },
                        new
                        {
                            Id = 12,
                            IsCorrect = false,
                            QuestionsId = 3,
                            Text = "Mississippi"
                        },
                        new
                        {
                            Id = 13,
                            IsCorrect = true,
                            QuestionsId = 4,
                            Text = "Himalayas"
                        },
                        new
                        {
                            Id = 14,
                            IsCorrect = false,
                            QuestionsId = 4,
                            Text = "Andes"
                        },
                        new
                        {
                            Id = 15,
                            IsCorrect = false,
                            QuestionsId = 4,
                            Text = "Rockies"
                        },
                        new
                        {
                            Id = 16,
                            IsCorrect = false,
                            QuestionsId = 4,
                            Text = "Alps"
                        },
                        new
                        {
                            Id = 17,
                            IsCorrect = true,
                            QuestionsId = 5,
                            Text = "Pacific"
                        },
                        new
                        {
                            Id = 18,
                            IsCorrect = false,
                            QuestionsId = 5,
                            Text = "Atlantic"
                        },
                        new
                        {
                            Id = 19,
                            IsCorrect = false,
                            QuestionsId = 5,
                            Text = "Indian"
                        },
                        new
                        {
                            Id = 20,
                            IsCorrect = false,
                            QuestionsId = 5,
                            Text = "Arctic"
                        },
                        new
                        {
                            Id = 21,
                            IsCorrect = true,
                            QuestionsId = 6,
                            Text = "Vatican City"
                        },
                        new
                        {
                            Id = 22,
                            IsCorrect = false,
                            QuestionsId = 6,
                            Text = "Monaco"
                        },
                        new
                        {
                            Id = 23,
                            IsCorrect = false,
                            QuestionsId = 6,
                            Text = "San Marino"
                        },
                        new
                        {
                            Id = 24,
                            IsCorrect = false,
                            QuestionsId = 6,
                            Text = "Liechtenstein"
                        },
                        new
                        {
                            Id = 25,
                            IsCorrect = true,
                            QuestionsId = 7,
                            Text = "Australia"
                        },
                        new
                        {
                            Id = 26,
                            IsCorrect = false,
                            QuestionsId = 7,
                            Text = "USA"
                        },
                        new
                        {
                            Id = 27,
                            IsCorrect = false,
                            QuestionsId = 7,
                            Text = "Brazil"
                        },
                        new
                        {
                            Id = 28,
                            IsCorrect = false,
                            QuestionsId = 7,
                            Text = "South Africa"
                        },
                        new
                        {
                            Id = 29,
                            IsCorrect = false,
                            QuestionsId = 8,
                            Text = "France"
                        },
                        new
                        {
                            Id = 30,
                            IsCorrect = false,
                            QuestionsId = 8,
                            Text = "Russia"
                        },
                        new
                        {
                            Id = 31,
                            IsCorrect = false,
                            QuestionsId = 8,
                            Text = "USA"
                        },
                        new
                        {
                            Id = 32,
                            IsCorrect = true,
                            QuestionsId = 8,
                            Text = "France"
                        },
                        new
                        {
                            Id = 33,
                            IsCorrect = true,
                            QuestionsId = 9,
                            Text = "Sahara"
                        },
                        new
                        {
                            Id = 34,
                            IsCorrect = false,
                            QuestionsId = 9,
                            Text = "Gobi"
                        },
                        new
                        {
                            Id = 35,
                            IsCorrect = false,
                            QuestionsId = 9,
                            Text = "Kalahari"
                        },
                        new
                        {
                            Id = 36,
                            IsCorrect = false,
                            QuestionsId = 9,
                            Text = "Arabian"
                        },
                        new
                        {
                            Id = 37,
                            IsCorrect = true,
                            QuestionsId = 10,
                            Text = "South America"
                        },
                        new
                        {
                            Id = 38,
                            IsCorrect = false,
                            QuestionsId = 10,
                            Text = "Africa"
                        },
                        new
                        {
                            Id = 39,
                            IsCorrect = false,
                            QuestionsId = 10,
                            Text = "Asia"
                        },
                        new
                        {
                            Id = 40,
                            IsCorrect = false,
                            QuestionsId = 10,
                            Text = "Europe"
                        });
                });

            modelBuilder.Entity("QuizApp.Models.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Text = "What is the capital of France?"
                        },
                        new
                        {
                            Id = 2,
                            Text = "Which continent is known as the 'Dark Continent'?"
                        },
                        new
                        {
                            Id = 3,
                            Text = "What is the longest river in the world?"
                        },
                        new
                        {
                            Id = 4,
                            Text = "Mount Everest is located in which mountain range?"
                        },
                        new
                        {
                            Id = 5,
                            Text = "Which ocean is the largest by surface area?"
                        },
                        new
                        {
                            Id = 6,
                            Text = "What is the smallest country in the world?"
                        },
                        new
                        {
                            Id = 7,
                            Text = "In which country is the Great Barrier Reef located?"
                        },
                        new
                        {
                            Id = 8,
                            Text = "Which country has the most time zones?"
                        },
                        new
                        {
                            Id = 9,
                            Text = "What is the largest desert in the world?"
                        },
                        new
                        {
                            Id = 10,
                            Text = "The Andes mountain range is located on which continent?"
                        });
                });

            modelBuilder.Entity("QuizApp.Models.Quizzes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 11, 14, 5, 11, 22, 638, DateTimeKind.Utc).AddTicks(5701),
                            Name = "Quiz set 1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 11, 14, 5, 11, 22, 638, DateTimeKind.Utc).AddTicks(5706),
                            Name = "Quiz set 2"
                        });
                });

            modelBuilder.Entity("QuizApp.Models.Records", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AttemptedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("QuizzesId")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("QuizApp.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuestionsQuizzes", b =>
                {
                    b.HasOne("QuizApp.Models.Questions", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizApp.Models.Quizzes", null)
                        .WithMany()
                        .HasForeignKey("QuizzesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizApp.Models.Answers", b =>
                {
                    b.HasOne("QuizApp.Models.Questions", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizApp.Models.Questions", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
