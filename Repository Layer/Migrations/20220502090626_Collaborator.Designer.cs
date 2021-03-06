// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository_Layer.Context;

namespace Repository_Layer.Migrations
{
    [DbContext(typeof(FundooContext))]
    [Migration("20220502090626_Collaborator")]
    partial class Collaborator
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repository_Layer.Entity.Collaborator", b =>
                {
                    b.Property<int>("collaboratorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CollabEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NoteId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("collaboratorId");

                    b.HasIndex("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("Collaborators");
                });

            modelBuilder.Entity("Repository_Layer.Entity.Label", b =>
                {
                    b.Property<int>("LabelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LabelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NoteId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LabelId");

                    b.HasIndex("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("Repository_Layer.Entity.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BGColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReminder")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTrash")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Repository_Layer.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("registerdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Repository_Layer.Entity.Collaborator", b =>
                {
                    b.HasOne("Repository_Layer.Entity.Note", "Note")
                        .WithMany()
                        .HasForeignKey("NoteId");

                    b.HasOne("Repository_Layer.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Note");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Repository_Layer.Entity.Label", b =>
                {
                    b.HasOne("Repository_Layer.Entity.Note", "Note")
                        .WithMany("Labels")
                        .HasForeignKey("NoteId");

                    b.HasOne("Repository_Layer.Entity.User", "User")
                        .WithMany("Labels")
                        .HasForeignKey("UserId");

                    b.Navigation("Note");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Repository_Layer.Entity.Note", b =>
                {
                    b.HasOne("Repository_Layer.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Repository_Layer.Entity.Note", b =>
                {
                    b.Navigation("Labels");
                });

            modelBuilder.Entity("Repository_Layer.Entity.User", b =>
                {
                    b.Navigation("Labels");
                });
#pragma warning restore 612, 618
        }
    }
}
