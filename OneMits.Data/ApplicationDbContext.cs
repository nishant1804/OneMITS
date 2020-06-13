using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneMits.Data.Models;
using System;

namespace OneMits.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StatusCategory> StatusCategories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<LikeAnswer> LikeAnswers { get; set; }
        public DbSet<LikeQuestion> LikeQuestions { get; set; }
        public DbSet<LoginTime> LoginTime { get; set; }
        public DbSet<Visits> Visits { get; set; }
        public DbSet<OtpTable> OtpTable { get; set; }
        public DbSet<TeacherTable> TeacherTable { get; set; }
        public DbSet<ConnectedList> ConnectedList { get; set; }
        public DbSet<ConnectingList> ConnectingList { get; set; }
        public DbSet<Notification> Notification { get; set; }
    }
}
