﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto.ControleEscolar.Infra.SqlServer.Contexts;

#nullable disable

namespace Projeto.ControleEscolar.Infra.SqlServer.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20230722113859_Inclusao Avaliacao e Mensalidade")]
    partial class InclusaoAvaliacaoeMensalidade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlunoTurma", b =>
                {
                    b.Property<Guid>("AlunosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Turma1Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AlunosId", "Turma1Id");

                    b.HasIndex("Turma1Id");

                    b.ToTable("AlunoTurma");
                });

            modelBuilder.Entity("DisciplinaTurma", b =>
                {
                    b.Property<Guid>("DisciplinasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DisciplinasId", "TurmaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("DisciplinaTurma");
                });

            modelBuilder.Entity("ProfessorTurma", b =>
                {
                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TurmasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProfessorId", "TurmasId");

                    b.HasIndex("TurmasId");

                    b.ToTable("ProfessorTurma");
                });

            modelBuilder.Entity("Projeto.ControleEscolar.Domain.Entities.Aluno", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("Projeto.ControleEscolar.Domain.Entities.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DisciplinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Media")
                        .HasMaxLength(10)
                        .HasPrecision(2, 1)
                        .HasColumnType("decimal(2,1)");

                    b.Property<decimal>("N1")
                        .HasMaxLength(10)
                        .HasPrecision(2, 1)
                        .HasColumnType("decimal(2,1)");

                    b.Property<decimal>("N2")
                        .HasMaxLength(10)
                        .HasPrecision(2, 1)
                        .HasColumnType("decimal(2,1)");

                    b.Property<decimal>("N3")
                        .HasMaxLength(10)
                        .HasPrecision(2, 1)
                        .HasColumnType("decimal(2,1)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Projeto.ControleEscolar.Domain.Entities.Disciplina", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("Projeto.ControleEscolar.Domain.Entities.Mensalidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormaPagamento")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Mensalidade");
                });

            modelBuilder.Entity("Projeto.ControleEscolar.Domain.Entities.Professor", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("Projeto.ControleEscolar.Domain.Entities.Turma", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("Projeto.ControleEscolar.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Permision")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("AlunoTurma", b =>
                {
                    b.HasOne("Projeto.ControleEscolar.Domain.Entities.Aluno", null)
                        .WithMany()
                        .HasForeignKey("AlunosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto.ControleEscolar.Domain.Entities.Turma", null)
                        .WithMany()
                        .HasForeignKey("Turma1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DisciplinaTurma", b =>
                {
                    b.HasOne("Projeto.ControleEscolar.Domain.Entities.Disciplina", null)
                        .WithMany()
                        .HasForeignKey("DisciplinasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto.ControleEscolar.Domain.Entities.Turma", null)
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProfessorTurma", b =>
                {
                    b.HasOne("Projeto.ControleEscolar.Domain.Entities.Professor", null)
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto.ControleEscolar.Domain.Entities.Turma", null)
                        .WithMany()
                        .HasForeignKey("TurmasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projeto.ControleEscolar.Domain.Entities.Aluno", b =>
                {
                    b.HasOne("Projeto.ControleEscolar.Domain.Entities.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Projeto.ControleEscolar.Domain.Entities.Avaliacao", b =>
                {
                    b.HasOne("Projeto.ControleEscolar.Domain.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId");

                    b.HasOne("Projeto.ControleEscolar.Domain.Entities.Disciplina", "Disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaId");

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("Projeto.ControleEscolar.Domain.Entities.Mensalidade", b =>
                {
                    b.HasOne("Projeto.ControleEscolar.Domain.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId");

                    b.Navigation("Aluno");
                });
#pragma warning restore 612, 618
        }
    }
}
