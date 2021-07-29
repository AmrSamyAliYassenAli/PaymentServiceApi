﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentServices.DataAccess.DomainRepository;

namespace PaymentServices.DataAccess.Migrations
{
    [DbContext(typeof(MiddlewareDbContext))]
    [Migration("20210310063359_changesincompany")]
    partial class changesincompany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaymentServices.Models.Domain.Lookups.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<int>("currencyId")
                        .HasColumnType("int");

                    b.Property<bool>("isDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("isoCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sortOrder")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Country", "Lookup");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Lookups.Currency", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("convertionRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sortOrder")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Currency", "Lookup");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Lookups.Language", b =>
                {
                    b.Property<int>("Languageid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ISOcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Languageid");

                    b.ToTable("Language", "Lookup");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Packages.SubscriptionPackagePrices", b =>
                {
                    b.Property<int>("packagePriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("countryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("isMonthly")
                        .HasColumnType("bit");

                    b.Property<bool>("isYearly")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("packageId")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("packagePriceId");

                    b.HasIndex("countryId");

                    b.HasIndex("packageId");

                    b.ToTable("SubscriptionPackagePrices", "Packages");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Packages.SubscriptionPackages", b =>
                {
                    b.Property<int>("packageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("noOfBranches")
                        .HasColumnType("int");

                    b.Property<int>("noOfUsers")
                        .HasColumnType("int");

                    b.HasKey("packageId");

                    b.ToTable("SubscriptionPackages", "Packages");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Subscriptions.AccessPermissions", b =>
                {
                    b.Property<int>("permissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("actionId")
                        .HasColumnType("int");

                    b.Property<int>("configId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isAllowed")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("isPolicy")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.HasKey("permissionId");

                    b.HasIndex("roleId");

                    b.ToTable("AccessPermissions", "Subscription");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Subscriptions.AccessRoles", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("accessType")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("AccessRoles", "Subscription");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Subscriptions.CompanyProfile", b =>
                {
                    b.Property<int>("companyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("businessType")
                        .HasColumnType("int");

                    b.Property<string>("companyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("faxCountry")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isVerificationNeeded")
                        .HasColumnType("bit");

                    b.Property<int>("languageId")
                        .HasColumnType("int");

                    b.Property<int>("packageId")
                        .HasColumnType("int");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phoneCountry")
                        .HasColumnType("int");

                    b.Property<int>("sectorId")
                        .HasColumnType("int");

                    b.Property<string>("slogan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("companyId");

                    b.HasIndex("packageId");

                    b.ToTable("CompanyProfile", "Subscription");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Subscriptions.CompanyUsers", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("about")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.Property<int>("salutationId")
                        .HasColumnType("int");

                    b.HasKey("userId");

                    b.HasIndex("companyId");

                    b.HasIndex("roleId");

                    b.ToTable("CompanyUsers", "Subscription");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Subscriptions.SubscriptionTransaction", b =>
                {
                    b.Property<int>("subscriptionTransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("companyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("createdBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("isPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("modifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("packagePriceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("subscriptionId")
                        .HasColumnType("int");

                    b.HasKey("subscriptionTransactionId");

                    b.ToTable("SubscriptionTransaction", "Subscription");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Packages.SubscriptionPackagePrices", b =>
                {
                    b.HasOne("PaymentServices.Models.Domain.Lookups.Country", "country")
                        .WithMany()
                        .HasForeignKey("countryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaymentServices.Models.Domain.Packages.SubscriptionPackages", "Package")
                        .WithMany("Prices")
                        .HasForeignKey("packageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");

                    b.Navigation("Package");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Subscriptions.AccessPermissions", b =>
                {
                    b.HasOne("PaymentServices.Models.Domain.Subscriptions.AccessRoles", "role")
                        .WithMany("permissions")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Subscriptions.CompanyProfile", b =>
                {
                    b.HasOne("PaymentServices.Models.Domain.Packages.SubscriptionPackages", "Package")
                        .WithMany()
                        .HasForeignKey("packageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Subscriptions.CompanyUsers", b =>
                {
                    b.HasOne("PaymentServices.Models.Domain.Subscriptions.CompanyProfile", "CompanyProfile")
                        .WithMany()
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaymentServices.Models.Domain.Subscriptions.AccessRoles", "AccessRole")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessRole");

                    b.Navigation("CompanyProfile");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Packages.SubscriptionPackages", b =>
                {
                    b.Navigation("Prices");
                });

            modelBuilder.Entity("PaymentServices.Models.Domain.Subscriptions.AccessRoles", b =>
                {
                    b.Navigation("permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
