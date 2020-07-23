using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySql.Data.MySqlClient;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using Sensa_questionnaireSystem.Model;

namespace Sensa_questionnaireSystem.Context
{
    public partial class QuestionnaireSystemContext : DbContext
    {
        public QuestionnaireSystemContext()
        {
        }

        public QuestionnaireSystemContext(DbContextOptions<QuestionnaireSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Questiongroups> Questiongroups { get; set; }
        public virtual DbSet<Questionnaires> Questionnaires { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Qusers> Qusers { get; set; }
        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Usergroupings> Usergroupings { get; set; }
        public virtual DbSet<Usergroups> Usergroups { get; set; }
        public virtual DbSet<Userroles> Userroles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;uid=root;pwd=Sipos@0303;database=sensa_kerdoiv", x => x.ServerVersion("8.0.20-mysql"));
                MySqlConnection connection = new MySqlConnection("erver=localhost;uid=root;pwd=Sipos@0303;database=sensa_kerdoiv");
                Debug.WriteLine(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answers>(entity =>
            {
                entity.HasKey(e => e.AnswerId)
                    .HasName("PRIMARY");

                entity.ToTable("answers");

                entity.HasIndex(e => new { e.QuestionId, e.UserId })
                    .HasName("question_id");

                entity.Property(e => e.AnswerId).HasColumnName("answer_id");

                entity.Property(e => e.CrCritical)
                    .HasColumnName("cr_critical")
                    .HasColumnType("enum('n','y')")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.CrImproved)
                    .HasColumnName("cr_improved")
                    .HasColumnType("enum('n','y')")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params")
                    .HasColumnType("text")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Pos).HasColumnName("pos");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Questiongroups>(entity =>
            {
                entity.HasKey(e => e.QuestiongroupId)
                    .HasName("PRIMARY");

                entity.ToTable("questiongroups");

                entity.HasIndex(e => e.QuestionnaireId)
                    .HasName("questionnaire_id");

                entity.Property(e => e.QuestiongroupId).HasColumnName("questiongroup_id");

                entity.Property(e => e.ImportantNum).HasColumnName("important_num");

                entity.Property(e => e.Lead)
                    .IsRequired()
                    .HasColumnName("lead")
                    .HasColumnType("text")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Pos).HasColumnName("pos");

                entity.Property(e => e.QuestionnaireId).HasColumnName("questionnaire_id");

                entity.Property(e => e.StandardMax).HasColumnName("standard_max");

                entity.Property(e => e.StandardMaxText)
                    .IsRequired()
                    .HasColumnName("standard_max_text")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.StandardMaxTextAlt)
                    .IsRequired()
                    .HasColumnName("standard_max_text_alt")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.StandardMin).HasColumnName("standard_min");

                entity.Property(e => e.StandardMinText)
                    .IsRequired()
                    .HasColumnName("standard_min_text")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.StandardMinTextAlt)
                    .IsRequired()
                    .HasColumnName("standard_min_text_alt")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.StartNum).HasColumnName("start_num");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.TitleAlt)
                    .IsRequired()
                    .HasColumnName("title_alt")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("enum('s','i','o','p','coaching')")
                    .HasDefaultValueSql("'s'")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");
            });

            modelBuilder.Entity<Questionnaires>(entity =>
            {
                entity.HasKey(e => e.QuestionnaireId)
                    .HasName("PRIMARY");

                entity.ToTable("questionnaires");

                entity.Property(e => e.QuestionnaireId).HasColumnName("questionnaire_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.DescriptionInner)
                    .IsRequired()
                    .HasColumnName("description_inner")
                    .HasColumnType("text")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Emailbody)
                    .IsRequired()
                    .HasColumnName("emailbody")
                    .HasColumnType("text")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Emailsubject)
                    .IsRequired()
                    .HasColumnName("emailsubject")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.NameAlt)
                    .IsRequired()
                    .HasColumnName("name_alt")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.ReportBackpage)
                    .IsRequired()
                    .HasColumnName("report_backpage")
                    .HasColumnType("enum('n','y')")
                    .HasDefaultValueSql("'n'")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.ReportClientName)
                    .IsRequired()
                    .HasColumnName("report_client_name")
                    .HasColumnType("varchar(127)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.ReportCover)
                    .IsRequired()
                    .HasColumnName("report_cover")
                    .HasColumnType("enum('n','y')")
                    .HasDefaultValueSql("'n'")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.ReportDate)
                    .IsRequired()
                    .HasColumnName("report_date")
                    .HasColumnType("varchar(63)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.ReportMakers)
                    .IsRequired()
                    .HasColumnName("report_makers")
                    .HasColumnType("varchar(127)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.ReportMakersPhones)
                    .IsRequired()
                    .HasColumnName("report_makers_phones")
                    .HasColumnType("varchar(127)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.ReportSubtitle)
                    .IsRequired()
                    .HasColumnName("report_subtitle")
                    .HasColumnType("varchar(127)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.ReportTitle)
                    .IsRequired()
                    .HasColumnName("report_title")
                    .HasColumnType("varchar(127)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("enum('i','a','f','deleted')")
                    .HasDefaultValueSql("'i'")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PRIMARY");

                entity.ToTable("questions");

                entity.HasIndex(e => e.QuestiongroupId)
                    .HasName("questiongroup_id");

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params")
                    .HasColumnType("text")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.ParamsAlt)
                    .IsRequired()
                    .HasColumnName("params_alt")
                    .HasColumnType("text")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Pos).HasColumnName("pos");

                entity.Property(e => e.QuestiongroupId).HasColumnName("questiongroup_id");
            });

            modelBuilder.Entity<Qusers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("qusers");

                entity.HasIndex(e => e.QuestionnaireId)
                    .HasName("questionnaire_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(127)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Groups)
                    .IsRequired()
                    .HasColumnName("groups")
                    .HasColumnType("text")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.LastEmailDate)
                    .HasColumnName("last_email_date")
                    .HasColumnType("date");

                entity.Property(e => e.LastFillDate)
                    .HasColumnName("last_fill_date")
                    .HasColumnType("date");

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("login_id")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(127)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.QuestionnaireId).HasColumnName("questionnaire_id");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("enum('n','p','f','deleted')")
                    .HasDefaultValueSql("'n'")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasColumnName("tel")
                    .HasColumnType("varchar(127)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");
            });

            modelBuilder.Entity<Reports>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PRIMARY");

                entity.ToTable("reports");

                entity.HasIndex(e => e.QuestionnaireId)
                    .HasName("questionnaire_id");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.GroupAveragesGroupingId).HasColumnName("group_averages_grouping_id");

                entity.Property(e => e.PageNumbering)
                    .IsRequired()
                    .HasColumnName("page_numbering")
                    .HasColumnType("enum('n','y')")
                    .HasDefaultValueSql("'n'")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasColumnName("params")
                    .HasColumnType("text")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.ParamsAlt)
                    .IsRequired()
                    .HasColumnName("params_alt")
                    .HasColumnType("text")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Pos).HasColumnName("pos");

                entity.Property(e => e.QuestionnaireId).HasColumnName("questionnaire_id");

                entity.Property(e => e.StartingPagenum).HasColumnName("starting_pagenum");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("enum('a','i')")
                    .HasDefaultValueSql("'a'")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.TitleAlt)
                    .IsRequired()
                    .HasColumnName("title_alt")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("enum('s','m','i','g','t','o','a','p','pt','coaching','coaching_table','distribution','group_averages')")
                    .HasDefaultValueSql("'s'")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.Id)
                    .HasName("id_2");

                entity.HasIndex(e => new { e.Id, e.Name })
                    .HasName("id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("PRIMARY");

                entity.ToTable("sessions");

                entity.HasIndex(e => e.SessionId)
                    .HasName("sessid_un")
                    .IsUnique();

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.LastAccess)
                    .HasColumnName("last_access")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.LastFile)
                    .IsRequired()
                    .HasColumnName("last_file")
                    .HasColumnType("varchar(127)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.LastIp)
                    .IsRequired()
                    .HasColumnName("last_ip")
                    .HasColumnType("varchar(15)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Variables)
                    .HasColumnName("variables")
                    .HasColumnType("text")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");
            });

            modelBuilder.Entity<Usergroupings>(entity =>
            {
                entity.HasKey(e => e.UsergroupingId)
                    .HasName("PRIMARY");

                entity.ToTable("usergroupings");

                entity.HasIndex(e => e.QuestionnaireId)
                    .HasName("questionnaire_id");

                entity.Property(e => e.UsergroupingId).HasColumnName("usergrouping_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.NameAlt)
                    .IsRequired()
                    .HasColumnName("name_alt")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Pos).HasColumnName("pos");

                entity.Property(e => e.QuestionnaireId).HasColumnName("questionnaire_id");
            });

            modelBuilder.Entity<Usergroups>(entity =>
            {
                entity.HasKey(e => e.UsergroupId)
                    .HasName("PRIMARY");

                entity.ToTable("usergroups");

                entity.HasIndex(e => e.UsergroupingId)
                    .HasName("usergrouping_id");

                entity.Property(e => e.UsergroupId).HasColumnName("usergroup_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.NameAlt)
                    .IsRequired()
                    .HasColumnName("name_alt")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Pos).HasColumnName("pos");

                entity.Property(e => e.UsergroupingId).HasColumnName("usergrouping_id");
            });

            modelBuilder.Entity<Userroles>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Roleid })
                    .HasName("PRIMARY");

                entity.ToTable("userroles");

                entity.HasIndex(e => new { e.Userid, e.Roleid })
                    .HasName("userid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Roleid).HasColumnName("roleid");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => new { e.Id, e.Login })
                    .HasName("id_2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lastip)
                    .IsRequired()
                    .HasColumnName("lastip")
                    .HasColumnType("varchar(15)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Lastlogin)
                    .HasColumnName("lastlogin")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasColumnType("varchar(16)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Logincount).HasColumnName("logincount");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");

                entity.Property(e => e.Registerdate)
                    .HasColumnName("registerdate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("enum('n','a','d')")
                    .HasDefaultValueSql("'n'")
                    .HasCharSet("latin2")
                    .HasCollation("latin2_hungarian_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
