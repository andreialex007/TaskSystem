﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TaskSystem.DL;

namespace TaskSystem.DL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180115204143_add_Document_UploadedDate")]
    partial class add_Document_UploadedDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskSystem.DL.Entities.Articles.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleCategoryId");

                    b.Property<string>("Content");

                    b.HasKey("Id");

                    b.HasIndex("ArticleCategoryId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Articles.ArticleAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleId");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("ArticleAttachments");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Articles.ArticleCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ParentArticleCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ParentArticleCategoryId");

                    b.ToTable("ArticleCategories");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<string>("Notes");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Customers.CustomerUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerUsers");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Invoices.CommonInvoiceElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<string>("Description");

                    b.Property<int>("InvoiceElementCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceElementCategoryId");

                    b.ToTable("CommonInvoiceElements");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Invoices.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<int>("Status");

                    b.Property<int>("TaskId");

                    b.Property<int?>("WorkTaskId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WorkTaskId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Invoices.InvoiceElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<string>("Description");

                    b.Property<int>("InvoiceElementCategoryId");

                    b.Property<int>("InvoiceId");

                    b.Property<decimal>("Qty");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceElementCategoryId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceElements");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Invoices.InvoiceElementCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("InvoiceElementCategories");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Invoices.InvoicePayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("InvoiceId");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<int>("PaymentType");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoicePayments");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Tasks.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<DateTime>("UploadedDate");

                    b.Property<int?>("UserId");

                    b.Property<int>("WorkTaskId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkTaskId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Tasks.WorkTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<int?>("CustomerUserId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Priority");

                    b.Property<int>("Status");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerUserId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkTasks");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Tasks.WorkTaskNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Note");

                    b.Property<int>("UserId");

                    b.Property<int?>("WorkTaskId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkTaskId");

                    b.ToTable("WorkTaskNotes");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Articles.Article", b =>
                {
                    b.HasOne("TaskSystem.DL.Entities.Articles.ArticleCategory", "ArticleCategory")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Articles.ArticleAttachment", b =>
                {
                    b.HasOne("TaskSystem.DL.Entities.Articles.Article", "Article")
                        .WithMany("ArticleAttachments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaskSystem.DL.Entities.User", "User")
                        .WithMany("ArticleAttachments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Articles.ArticleCategory", b =>
                {
                    b.HasOne("TaskSystem.DL.Entities.Articles.ArticleCategory", "ParentArticleCategory")
                        .WithMany()
                        .HasForeignKey("ParentArticleCategoryId");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Customers.CustomerUser", b =>
                {
                    b.HasOne("TaskSystem.DL.Entities.Customers.Customer", "Customer")
                        .WithMany("CustomerUsers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Invoices.CommonInvoiceElement", b =>
                {
                    b.HasOne("TaskSystem.DL.Entities.Invoices.InvoiceElementCategory", "InvoiceElementCategory")
                        .WithMany("CommonInvoiceElements")
                        .HasForeignKey("InvoiceElementCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Invoices.Invoice", b =>
                {
                    b.HasOne("TaskSystem.DL.Entities.Customers.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaskSystem.DL.Entities.Tasks.WorkTask")
                        .WithMany("Invoices")
                        .HasForeignKey("WorkTaskId");
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Invoices.InvoiceElement", b =>
                {
                    b.HasOne("TaskSystem.DL.Entities.Invoices.InvoiceElementCategory", "InvoiceElementCategory")
                        .WithMany("InvoiceElements")
                        .HasForeignKey("InvoiceElementCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaskSystem.DL.Entities.Invoices.Invoice", "Invoice")
                        .WithMany("InvoiceElements")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Invoices.InvoicePayment", b =>
                {
                    b.HasOne("TaskSystem.DL.Entities.Invoices.Invoice", "Invoice")
                        .WithMany("InvoicePayments")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Tasks.Document", b =>
                {
                    b.HasOne("TaskSystem.DL.Entities.User", "User")
                        .WithMany("Documents")
                        .HasForeignKey("UserId");

                    b.HasOne("TaskSystem.DL.Entities.Tasks.WorkTask", "WorkTask")
                        .WithMany("Documents")
                        .HasForeignKey("WorkTaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Tasks.WorkTask", b =>
                {
                    b.HasOne("TaskSystem.DL.Entities.Customers.Customer", "Customer")
                        .WithMany("WorkTask")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaskSystem.DL.Entities.Customers.CustomerUser", "CustomerUser")
                        .WithMany("WorkTasks")
                        .HasForeignKey("CustomerUserId");

                    b.HasOne("TaskSystem.DL.Entities.User", "User")
                        .WithMany("WorkTasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaskSystem.DL.Entities.Tasks.WorkTaskNote", b =>
                {
                    b.HasOne("TaskSystem.DL.Entities.User", "User")
                        .WithMany("WorkTaskNotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaskSystem.DL.Entities.Tasks.WorkTask", "WorkTask")
                        .WithMany("WorkTaskNotes")
                        .HasForeignKey("WorkTaskId");
                });
#pragma warning restore 612, 618
        }
    }
}
