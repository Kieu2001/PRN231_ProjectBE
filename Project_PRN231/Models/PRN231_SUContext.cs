using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project_PRN231.Models
{
    public partial class PRN231_SUContext : DbContext
    {
        public PRN231_SUContext()
        {
        }

        public PRN231_SUContext(DbContextOptions<PRN231_SUContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignTask> AssignTasks { get; set; } = null!;
        public virtual DbSet<CategoriesNewsSeen> CategoriesNewsSeens { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<NewsSeen> NewsSeens { get; set; } = null!;
        public virtual DbSet<ReplyComment> ReplyComments { get; set; } = null!;
        public virtual DbSet<ReportTask> ReportTasks { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WritingTask> WritingTasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = PRN231_SU;uid=sa;pwd=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignTask>(entity =>
            {
                entity.ToTable("AssignTask");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.GenreId).HasColumnName("Genre_Id");

                entity.Property(e => e.LeaderId).HasColumnName("Leader_Id");

                entity.Property(e => e.ReporterId).HasColumnName("Reporter_Id");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(1000);

                entity.Property(e => e.WriterId).HasColumnName("Writer_Id");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.AssignTasks)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__AssignTas__Genre__4AB81AF0");

                entity.HasOne(d => d.Leader)
                    .WithMany(p => p.AssignTaskLeaders)
                    .HasForeignKey(d => d.LeaderId)
                    .HasConstraintName("FK__AssignTas__Leade__47DBAE45");

                entity.HasOne(d => d.Reporter)
                    .WithMany(p => p.AssignTaskReporters)
                    .HasForeignKey(d => d.ReporterId)
                    .HasConstraintName("FK__AssignTas__Repor__49C3F6B7");

                entity.HasOne(d => d.Writer)
                    .WithMany(p => p.AssignTaskWriters)
                    .HasForeignKey(d => d.WriterId)
                    .HasConstraintName("FK__AssignTas__Write__48CFD27E");
            });

            modelBuilder.Entity<CategoriesNewsSeen>(entity =>
            {
                entity.ToTable("CategoriesNewsSeen");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Content).HasMaxLength(1000);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.NewsId).HasColumnName("News_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK__Comment__News_Id__5629CD9C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Comment__User_Id__5535A963");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(225);

                entity.Property(e => e.GenreName)
                    .HasMaxLength(225)
                    .HasColumnName("Genre_Name");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.CreateBy).HasMaxLength(225);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.GenreId).HasColumnName("Genre_Id");

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.UpdateBy).HasMaxLength(225);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__News__Genre_Id__3E52440B");
            });

            modelBuilder.Entity<NewsSeen>(entity =>
            {
                entity.ToTable("NewsSeen");

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.CateId).HasColumnName("Cate_Id");

                entity.Property(e => e.NewsId).HasColumnName("News_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.NewsSeens)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK__NewsSeen__Cate_I__44FF419A");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.NewsSeens)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK__NewsSeen__News_I__440B1D61");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NewsSeens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__NewsSeen__User_I__4316F928");
            });

            modelBuilder.Entity<ReplyComment>(entity =>
            {
                entity.HasKey(e => new { e.CommentId, e.UserId })
                    .HasName("PK__ReplyCom__8BFACDCC206444FD");

                entity.ToTable("ReplyComment");

                entity.Property(e => e.CommentId).HasColumnName("Comment_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.Content).HasMaxLength(1000);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.ReplyComments)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReplyComm__Comme__59063A47");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReplyComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReplyComm__User___59FA5E80");
            });

            modelBuilder.Entity<ReportTask>(entity =>
            {
                entity.ToTable("ReportTask");

                entity.Property(e => e.CreateBy).HasMaxLength(225);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(3000);

                entity.Property(e => e.Image).HasMaxLength(1000);

                entity.Property(e => e.TaskId).HasColumnName("Task_Id");

                entity.Property(e => e.Title).HasMaxLength(3000);

                entity.Property(e => e.UpdateBy).HasMaxLength(225);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.ReportTasks)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__ReportTas__Task___52593CB8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReportTasks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ReportTas__User___5165187F");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(250)
                    .HasColumnName("Role_Name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Address).HasMaxLength(225);

                entity.Property(e => e.Email).HasMaxLength(225);

                entity.Property(e => e.FullName).HasMaxLength(225);

                entity.Property(e => e.Password).HasMaxLength(225);

                entity.Property(e => e.Phone).HasMaxLength(12);

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__Role_Id__398D8EEE");
            });

            modelBuilder.Entity<WritingTask>(entity =>
            {
                entity.ToTable("WritingTask");

                entity.Property(e => e.Comment).HasMaxLength(3000);

                entity.Property(e => e.CreateBy).HasMaxLength(225);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(3000);

                entity.Property(e => e.Image).HasMaxLength(1000);

                entity.Property(e => e.TaskId).HasColumnName("Task_Id");

                entity.Property(e => e.Title).HasMaxLength(3000);

                entity.Property(e => e.UpdateBy).HasMaxLength(225);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.WritingTasks)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__WritingTa__Task___4E88ABD4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WritingTasks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__WritingTa__User___4D94879B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
