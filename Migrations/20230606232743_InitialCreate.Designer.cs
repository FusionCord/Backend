﻿// <auto-generated />
using System;
using BackendChatRoom.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendChatRoom.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230606232743_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("BackendChatRoom.models.Channel", b =>
                {
                    b.Property<int>("channelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ServerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("channelId");

                    b.HasIndex("ServerId");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("BackendChatRoom.models.Message", b =>
                {
                    b.Property<int>("messageid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<int>("channelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("messageid");

                    b.HasIndex("channelId");

                    b.HasIndex("userId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("BackendChatRoom.models.Server", b =>
                {
                    b.Property<int>("ServerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ServerId");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("BackendChatRoom.models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ServerUser", b =>
                {
                    b.Property<int>("ServersServerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersuserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ServersServerId", "UsersuserId");

                    b.HasIndex("UsersuserId");

                    b.ToTable("ServerUser");
                });

            modelBuilder.Entity("BackendChatRoom.models.Channel", b =>
                {
                    b.HasOne("BackendChatRoom.models.Server", null)
                        .WithMany("Channels")
                        .HasForeignKey("ServerId");
                });

            modelBuilder.Entity("BackendChatRoom.models.Message", b =>
                {
                    b.HasOne("BackendChatRoom.models.Channel", "Channel")
                        .WithMany("Messages")
                        .HasForeignKey("channelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendChatRoom.models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Channel");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ServerUser", b =>
                {
                    b.HasOne("BackendChatRoom.models.Server", null)
                        .WithMany()
                        .HasForeignKey("ServersServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendChatRoom.models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersuserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackendChatRoom.models.Channel", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("BackendChatRoom.models.Server", b =>
                {
                    b.Navigation("Channels");
                });
#pragma warning restore 612, 618
        }
    }
}