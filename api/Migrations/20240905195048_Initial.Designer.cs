﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Context;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240905195048_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("api.Models.Bookmark", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostID")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("api.Models.Chat", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("api.Models.Image", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("PostID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("api.Models.Member", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChatID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ChatID");

                    b.HasIndex("UserID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("api.Models.Message", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReadDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReceiverID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReplyID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SenderID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("ReplyID");

                    b.HasIndex("SenderID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("api.Models.Post", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("PreviousPostID")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("PreviousPostID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api.Models.Bookmark", b =>
                {
                    b.HasOne("api.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostID");

                    b.HasOne("api.Models.User", "User")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserID");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Image", b =>
                {
                    b.HasOne("api.Models.Post", "Post")
                        .WithMany("Images")
                        .HasForeignKey("PostID");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("api.Models.Member", b =>
                {
                    b.HasOne("api.Models.Chat", "Chat")
                        .WithMany("Members")
                        .HasForeignKey("ChatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.Message", b =>
                {
                    b.HasOne("api.Models.Chat", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Message", "Reply")
                        .WithMany()
                        .HasForeignKey("ReplyID");

                    b.HasOne("api.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderID");

                    b.Navigation("Receiver");

                    b.Navigation("Reply");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("api.Models.Post", b =>
                {
                    b.HasOne("api.Models.Post", "PreviousPost")
                        .WithMany()
                        .HasForeignKey("PreviousPostID");

                    b.HasOne("api.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserID");

                    b.Navigation("PreviousPost");

                    b.Navigation("User");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.HasOne("api.Models.User", null)
                        .WithMany("Followers")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("api.Models.Chat", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("api.Models.Post", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("Followers");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
