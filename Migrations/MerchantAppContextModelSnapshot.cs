﻿// <auto-generated />
using System;
using MerchantApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MerchantApp.Migrations
{
    [DbContext(typeof(MerchantAppContext))]
    partial class MerchantAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MerchantApp.Models.Merchants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CheckoutType")
                        .HasColumnName("checkout_type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficialUrl")
                        .HasColumnName("official_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("MerchantApp.Models.OfferCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OfferCategories");
                });

            modelBuilder.Entity("MerchantApp.Models.Offers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpiredAt")
                        .HasColumnName("expired_at")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FanRewardAmount")
                        .HasColumnName("fan_reward_amount")
                        .HasColumnType("int");

                    b.Property<string>("FanRewardLabel")
                        .HasColumnName("fan_reward_label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FanRewardType")
                        .HasColumnName("fan_reward_type")
                        .HasColumnType("int");

                    b.Property<int?>("FriendRewardAmount")
                        .HasColumnName("friend_reward_amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FriendRewardExpiredAt")
                        .HasColumnName("friend_reward_expired_at")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("FriendRewardIsPercent")
                        .HasColumnName("friend_reward_is_percent")
                        .HasColumnType("bit");

                    b.Property<int>("FriendRewardType")
                        .HasColumnName("friend_reward_type")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnName("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MerchantsId")
                        .HasColumnName("merchant_id")
                        .HasColumnType("int");

                    b.Property<int>("OfferCategoriesId")
                        .HasColumnName("offer_category_id")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnName("slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnName("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MerchantsId");

                    b.HasIndex("OfferCategoriesId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("MerchantApp.Models.Offers", b =>
                {
                    b.HasOne("MerchantApp.Models.Merchants", "Merchants")
                        .WithMany("Offers")
                        .HasForeignKey("MerchantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MerchantApp.Models.OfferCategories", "OfferCategories")
                        .WithMany("Offers")
                        .HasForeignKey("OfferCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
