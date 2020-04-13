using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace efMysql.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ColumnsPriv> ColumnsPriv { get; set; }
        public virtual DbSet<Component> Component { get; set; }
        public virtual DbSet<Db> Db { get; set; }
        public virtual DbSet<DefaultRoles> DefaultRoles { get; set; }
        public virtual DbSet<EngineCost> EngineCost { get; set; }
        public virtual DbSet<Func> Func { get; set; }
        public virtual DbSet<GeneralLog> GeneralLog { get; set; }
        public virtual DbSet<GlobalGrants> GlobalGrants { get; set; }
        public virtual DbSet<GtidExecuted> GtidExecuted { get; set; }
        public virtual DbSet<HelpCategory> HelpCategory { get; set; }
        public virtual DbSet<HelpKeyword> HelpKeyword { get; set; }
        public virtual DbSet<HelpRelation> HelpRelation { get; set; }
        public virtual DbSet<HelpTopic> HelpTopic { get; set; }
        public virtual DbSet<InnodbIndexStats> InnodbIndexStats { get; set; }
        public virtual DbSet<InnodbTableStats> InnodbTableStats { get; set; }
        public virtual DbSet<PasswordHistory> PasswordHistory { get; set; }
        public virtual DbSet<Plugin> Plugin { get; set; }
        public virtual DbSet<ProcsPriv> ProcsPriv { get; set; }
        public virtual DbSet<ProxiesPriv> ProxiesPriv { get; set; }
        public virtual DbSet<RoleEdges> RoleEdges { get; set; }
        public virtual DbSet<ServerCost> ServerCost { get; set; }
        public virtual DbSet<Servers> Servers { get; set; }
        public virtual DbSet<SlaveMasterInfo> SlaveMasterInfo { get; set; }
        public virtual DbSet<SlaveRelayLogInfo> SlaveRelayLogInfo { get; set; }
        public virtual DbSet<SlaveWorkerInfo> SlaveWorkerInfo { get; set; }
        public virtual DbSet<SlowLog> SlowLog { get; set; }
        public virtual DbSet<TablesPriv> TablesPriv { get; set; }
        public virtual DbSet<TimeZone> TimeZone { get; set; }
        public virtual DbSet<TimeZoneLeapSecond> TimeZoneLeapSecond { get; set; }
        public virtual DbSet<TimeZoneName> TimeZoneName { get; set; }
        public virtual DbSet<TimeZoneTransition> TimeZoneTransition { get; set; }
        public virtual DbSet<TimeZoneTransitionType> TimeZoneTransitionType { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=mysql;uid=root;pwd=root", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColumnsPriv>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.Db, e.User, e.TableName, e.ColumnName })
                    .HasName("PRIMARY");

                entity.ToTable("columns_priv");

                entity.HasComment("Column privileges");

                entity.Property(e => e.Host)
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.Db)
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.User)
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.TableName)
                    .HasColumnName("Table_name")
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.ColumnName)
                    .HasColumnName("Column_name")
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("component");

                entity.HasComment("Components");

                entity.Property(e => e.ComponentId).HasColumnName("component_id");

                entity.Property(e => e.ComponentGroupId).HasColumnName("component_group_id");

                entity.Property(e => e.ComponentUrn)
                    .IsRequired()
                    .HasColumnName("component_urn")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Db>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.Db1, e.User })
                    .HasName("PRIMARY");

                entity.ToTable("db");

                entity.HasComment("Database privileges");

                entity.HasIndex(e => e.User)
                    .HasName("User");

                entity.Property(e => e.Host)
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.Db1)
                    .HasColumnName("Db")
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.User)
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.AlterPriv)
                    .IsRequired()
                    .HasColumnName("Alter_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AlterRoutinePriv)
                    .IsRequired()
                    .HasColumnName("Alter_routine_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatePriv)
                    .IsRequired()
                    .HasColumnName("Create_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateRoutinePriv)
                    .IsRequired()
                    .HasColumnName("Create_routine_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTmpTablePriv)
                    .IsRequired()
                    .HasColumnName("Create_tmp_table_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateViewPriv)
                    .IsRequired()
                    .HasColumnName("Create_view_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeletePriv)
                    .IsRequired()
                    .HasColumnName("Delete_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DropPriv)
                    .IsRequired()
                    .HasColumnName("Drop_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EventPriv)
                    .IsRequired()
                    .HasColumnName("Event_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExecutePriv)
                    .IsRequired()
                    .HasColumnName("Execute_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GrantPriv)
                    .IsRequired()
                    .HasColumnName("Grant_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IndexPriv)
                    .IsRequired()
                    .HasColumnName("Index_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsertPriv)
                    .IsRequired()
                    .HasColumnName("Insert_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LockTablesPriv)
                    .IsRequired()
                    .HasColumnName("Lock_tables_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReferencesPriv)
                    .IsRequired()
                    .HasColumnName("References_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SelectPriv)
                    .IsRequired()
                    .HasColumnName("Select_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowViewPriv)
                    .IsRequired()
                    .HasColumnName("Show_view_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TriggerPriv)
                    .IsRequired()
                    .HasColumnName("Trigger_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatePriv)
                    .IsRequired()
                    .HasColumnName("Update_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<DefaultRoles>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User, e.DefaultRoleHost, e.DefaultRoleUser })
                    .HasName("PRIMARY");

                entity.ToTable("default_roles");

                entity.HasComment("Default roles");

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.User)
                    .HasColumnName("USER")
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.DefaultRoleHost)
                    .HasColumnName("DEFAULT_ROLE_HOST")
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("'%'")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.DefaultRoleUser)
                    .HasColumnName("DEFAULT_ROLE_USER")
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");
            });

            modelBuilder.Entity<EngineCost>(entity =>
            {
                entity.HasKey(e => new { e.CostName, e.EngineName, e.DeviceType })
                    .HasName("PRIMARY");

                entity.ToTable("engine_cost");

                entity.Property(e => e.CostName)
                    .HasColumnName("cost_name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EngineName)
                    .HasColumnName("engine_name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeviceType).HasColumnName("device_type");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(1024)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CostValue).HasColumnName("cost_value");

                entity.Property(e => e.DefaultValue).HasColumnName("default_value");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Func>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("func");

                entity.HasComment("User defined functions");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Dl)
                    .IsRequired()
                    .HasColumnName("dl")
                    .HasColumnType("char(128)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Ret).HasColumnName("ret");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("enum('function','aggregate')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<GeneralLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("general_log");

                entity.HasComment("General log");

                entity.Property(e => e.Argument)
                    .IsRequired()
                    .HasColumnName("argument")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.CommandType)
                    .IsRequired()
                    .HasColumnName("command_type")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EventTime)
                    .HasColumnName("event_time")
                    .HasColumnType("timestamp(6)")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP(6)'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ServerId).HasColumnName("server_id");

                entity.Property(e => e.ThreadId).HasColumnName("thread_id");

                entity.Property(e => e.UserHost)
                    .IsRequired()
                    .HasColumnName("user_host")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<GlobalGrants>(entity =>
            {
                entity.HasKey(e => new { e.User, e.Host, e.Priv })
                    .HasName("PRIMARY");

                entity.ToTable("global_grants");

                entity.HasComment("Extended global grants");

                entity.Property(e => e.User)
                    .HasColumnName("USER")
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.Priv)
                    .HasColumnName("PRIV")
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WithGrantOption)
                    .IsRequired()
                    .HasColumnName("WITH_GRANT_OPTION")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<GtidExecuted>(entity =>
            {
                entity.HasKey(e => new { e.SourceUuid, e.IntervalStart })
                    .HasName("PRIMARY");

                entity.ToTable("gtid_executed");

                entity.Property(e => e.SourceUuid)
                    .HasColumnName("source_uuid")
                    .HasComment("uuid of the source where the transaction was originally executed.")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IntervalStart)
                    .HasColumnName("interval_start")
                    .HasComment("First number of interval.");

                entity.Property(e => e.IntervalEnd)
                    .HasColumnName("interval_end")
                    .HasComment("Last number of interval.");
            });

            modelBuilder.Entity<HelpCategory>(entity =>
            {
                entity.ToTable("help_category");

                entity.HasComment("help categories");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.HelpCategoryId).HasColumnName("help_category_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("char(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<HelpKeyword>(entity =>
            {
                entity.ToTable("help_keyword");

                entity.HasComment("help keywords");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.HelpKeywordId).HasColumnName("help_keyword_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("char(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<HelpRelation>(entity =>
            {
                entity.HasKey(e => new { e.HelpKeywordId, e.HelpTopicId })
                    .HasName("PRIMARY");

                entity.ToTable("help_relation");

                entity.HasComment("keyword-topic relation");

                entity.Property(e => e.HelpKeywordId).HasColumnName("help_keyword_id");

                entity.Property(e => e.HelpTopicId).HasColumnName("help_topic_id");
            });

            modelBuilder.Entity<HelpTopic>(entity =>
            {
                entity.ToTable("help_topic");

                entity.HasComment("help topics");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.HelpTopicId).HasColumnName("help_topic_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Example)
                    .IsRequired()
                    .HasColumnName("example")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HelpCategoryId).HasColumnName("help_category_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("char(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<InnodbIndexStats>(entity =>
            {
                entity.HasKey(e => new { e.DatabaseName, e.TableName, e.IndexName, e.StatName })
                    .HasName("PRIMARY");

                entity.ToTable("innodb_index_stats");

                entity.Property(e => e.DatabaseName)
                    .HasColumnName("database_name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasColumnType("varchar(199)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.IndexName)
                    .HasColumnName("index_name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.StatName)
                    .HasColumnName("stat_name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.SampleSize).HasColumnName("sample_size");

                entity.Property(e => e.StatDescription)
                    .IsRequired()
                    .HasColumnName("stat_description")
                    .HasColumnType("varchar(1024)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.StatValue).HasColumnName("stat_value");
            });

            modelBuilder.Entity<InnodbTableStats>(entity =>
            {
                entity.HasKey(e => new { e.DatabaseName, e.TableName })
                    .HasName("PRIMARY");

                entity.ToTable("innodb_table_stats");

                entity.Property(e => e.DatabaseName)
                    .HasColumnName("database_name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.TableName)
                    .HasColumnName("table_name")
                    .HasColumnType("varchar(199)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.ClusteredIndexSize).HasColumnName("clustered_index_size");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.NRows).HasColumnName("n_rows");

                entity.Property(e => e.SumOfOtherIndexSizes).HasColumnName("sum_of_other_index_sizes");
            });

            modelBuilder.Entity<PasswordHistory>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User, e.PasswordTimestamp })
                    .HasName("PRIMARY");

                entity.ToTable("password_history");

                entity.HasComment("Password history for user accounts");

                entity.Property(e => e.Host)
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.User)
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.PasswordTimestamp)
                    .HasColumnName("Password_timestamp")
                    .HasColumnType("timestamp(6)")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP(6)'");

                entity.Property(e => e.Password)
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");
            });

            modelBuilder.Entity<Plugin>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("plugin");

                entity.HasComment("MySQL plugins");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Dl)
                    .IsRequired()
                    .HasColumnName("dl")
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ProcsPriv>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.Db, e.User, e.RoutineName, e.RoutineType })
                    .HasName("PRIMARY");

                entity.ToTable("procs_priv");

                entity.HasComment("Procedure privileges");

                entity.HasIndex(e => e.Grantor)
                    .HasName("Grantor");

                entity.Property(e => e.Host)
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.Db)
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.User)
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.RoutineName)
                    .HasColumnName("Routine_name")
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.RoutineType)
                    .HasColumnName("Routine_type")
                    .HasColumnType("enum('FUNCTION','PROCEDURE')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Grantor)
                    .IsRequired()
                    .HasColumnType("varchar(288)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<ProxiesPriv>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User, e.ProxiedHost, e.ProxiedUser })
                    .HasName("PRIMARY");

                entity.ToTable("proxies_priv");

                entity.HasComment("User proxy privileges");

                entity.HasIndex(e => e.Grantor)
                    .HasName("Grantor");

                entity.Property(e => e.Host)
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.User)
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.ProxiedHost)
                    .HasColumnName("Proxied_host")
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.ProxiedUser)
                    .HasColumnName("Proxied_user")
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Grantor)
                    .IsRequired()
                    .HasColumnType("varchar(288)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.WithGrant).HasColumnName("With_grant");
            });

            modelBuilder.Entity<RoleEdges>(entity =>
            {
                entity.HasKey(e => new { e.FromHost, e.FromUser, e.ToHost, e.ToUser })
                    .HasName("PRIMARY");

                entity.ToTable("role_edges");

                entity.HasComment("Role hierarchy and role grants");

                entity.Property(e => e.FromHost)
                    .HasColumnName("FROM_HOST")
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.FromUser)
                    .HasColumnName("FROM_USER")
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.ToHost)
                    .HasColumnName("TO_HOST")
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.ToUser)
                    .HasColumnName("TO_USER")
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.WithAdminOption)
                    .IsRequired()
                    .HasColumnName("WITH_ADMIN_OPTION")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ServerCost>(entity =>
            {
                entity.HasKey(e => e.CostName)
                    .HasName("PRIMARY");

                entity.ToTable("server_cost");

                entity.Property(e => e.CostName)
                    .HasColumnName("cost_name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(1024)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CostValue).HasColumnName("cost_value");

                entity.Property(e => e.DefaultValue).HasColumnName("default_value");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Servers>(entity =>
            {
                entity.HasKey(e => e.ServerName)
                    .HasName("PRIMARY");

                entity.ToTable("servers");

                entity.HasComment("MySQL Foreign Servers table");

                entity.Property(e => e.ServerName)
                    .HasColumnName("Server_name")
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Db)
                    .IsRequired()
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Socket)
                    .IsRequired()
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Wrapper)
                    .IsRequired()
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<SlaveMasterInfo>(entity =>
            {
                entity.HasKey(e => e.ChannelName)
                    .HasName("PRIMARY");

                entity.ToTable("slave_master_info");

                entity.HasComment("Master Information");

                entity.Property(e => e.ChannelName)
                    .HasColumnName("Channel_name")
                    .HasColumnType("char(64)")
                    .HasComment("The channel on which the slave is connected to a source. Used in Multisource Replication")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Bind)
                    .HasColumnType("text")
                    .HasComment("Displays which interface is employed when connecting to the MySQL server")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.ConnectRetry)
                    .HasColumnName("Connect_retry")
                    .HasComment("The period (in seconds) that the slave will wait before trying to reconnect to the master.");

                entity.Property(e => e.EnabledAutoPosition)
                    .HasColumnName("Enabled_auto_position")
                    .HasComment("Indicates whether GTIDs will be used to retrieve events from the master.");

                entity.Property(e => e.EnabledSsl)
                    .HasColumnName("Enabled_ssl")
                    .HasComment("Indicates whether the server supports SSL connections.");

                entity.Property(e => e.GetPublicKey)
                    .HasColumnName("Get_public_key")
                    .HasComment("Preference to get public key from master.");

                entity.Property(e => e.Host)
                    .HasColumnType("char(255)")
                    .HasComment("The host name of the master.")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.IgnoredServerIds)
                    .HasColumnName("Ignored_server_ids")
                    .HasColumnType("text")
                    .HasComment("The number of server IDs to be ignored, followed by the actual server IDs")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.MasterCompressionAlgorithm)
                    .IsRequired()
                    .HasColumnName("Master_compression_algorithm")
                    .HasColumnType("char(64)")
                    .HasComment("Compression algorithm supported for data transfer between master and slave.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.MasterLogName)
                    .IsRequired()
                    .HasColumnName("Master_log_name")
                    .HasColumnType("text")
                    .HasComment("The name of the master binary log currently being read from the master.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.MasterLogPos)
                    .HasColumnName("Master_log_pos")
                    .HasComment("The master log position of the last read event.");

                entity.Property(e => e.MasterZstdCompressionLevel)
                    .HasColumnName("Master_zstd_compression_level")
                    .HasComment("Compression level associated with zstd compression algorithm.");

                entity.Property(e => e.NetworkNamespace)
                    .HasColumnName("Network_namespace")
                    .HasColumnType("text")
                    .HasComment("Network namespace used for communication with the master server.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.NumberOfLines)
                    .HasColumnName("Number_of_lines")
                    .HasComment("Number of lines in the file.");

                entity.Property(e => e.Port).HasComment("The network port used to connect to the master.");

                entity.Property(e => e.PublicKeyPath)
                    .HasColumnName("Public_key_path")
                    .HasColumnType("text")
                    .HasComment("The file containing public key of master server.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.RetryCount)
                    .HasColumnName("Retry_count")
                    .HasComment("Number of reconnect attempts, to the master, before giving up.");

                entity.Property(e => e.SslCa)
                    .HasColumnName("Ssl_ca")
                    .HasColumnType("text")
                    .HasComment("The file used for the Certificate Authority (CA) certificate.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.SslCapath)
                    .HasColumnName("Ssl_capath")
                    .HasColumnType("text")
                    .HasComment("The path to the Certificate Authority (CA) certificates.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.SslCert)
                    .HasColumnName("Ssl_cert")
                    .HasColumnType("text")
                    .HasComment("The name of the SSL certificate file.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.SslCipher)
                    .HasColumnName("Ssl_cipher")
                    .HasColumnType("text")
                    .HasComment("The name of the cipher in use for the SSL connection.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.SslCrl)
                    .HasColumnName("Ssl_crl")
                    .HasColumnType("text")
                    .HasComment("The file used for the Certificate Revocation List (CRL)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.SslCrlpath)
                    .HasColumnName("Ssl_crlpath")
                    .HasColumnType("text")
                    .HasComment("The path used for Certificate Revocation List (CRL) files")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.SslKey)
                    .HasColumnName("Ssl_key")
                    .HasColumnType("text")
                    .HasComment("The name of the SSL key file.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.SslVerifyServerCert)
                    .HasColumnName("Ssl_verify_server_cert")
                    .HasComment("Whether to verify the server certificate.");

                entity.Property(e => e.TlsCiphersuites)
                    .HasColumnName("Tls_ciphersuites")
                    .HasColumnType("text")
                    .HasComment("Ciphersuites used for TLS 1.3 communication with the master server.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.TlsVersion)
                    .HasColumnName("Tls_version")
                    .HasColumnType("text")
                    .HasComment("Tls version")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.UserName)
                    .HasColumnName("User_name")
                    .HasColumnType("text")
                    .HasComment("The user name used to connect to the master.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.UserPassword)
                    .HasColumnName("User_password")
                    .HasColumnType("text")
                    .HasComment("The password used to connect to the master.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Uuid)
                    .HasColumnType("text")
                    .HasComment("The master server uuid.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");
            });

            modelBuilder.Entity<SlaveRelayLogInfo>(entity =>
            {
                entity.HasKey(e => e.ChannelName)
                    .HasName("PRIMARY");

                entity.ToTable("slave_relay_log_info");

                entity.HasComment("Relay Log Information");

                entity.Property(e => e.ChannelName)
                    .HasColumnName("Channel_name")
                    .HasColumnType("char(64)")
                    .HasComment("The channel on which the slave is connected to a source. Used in Multisource Replication")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Id).HasComment("Internal Id that uniquely identifies this record.");

                entity.Property(e => e.MasterLogName)
                    .HasColumnName("Master_log_name")
                    .HasColumnType("text")
                    .HasComment("The name of the master binary log file from which the events in the relay log file were read.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.MasterLogPos)
                    .HasColumnName("Master_log_pos")
                    .HasComment("The master log position of the last executed event.");

                entity.Property(e => e.NumberOfLines)
                    .HasColumnName("Number_of_lines")
                    .HasComment("Number of lines in the file or rows in the table. Used to version table definitions.");

                entity.Property(e => e.NumberOfWorkers).HasColumnName("Number_of_workers");

                entity.Property(e => e.PrivilegeChecksHostname)
                    .HasColumnName("Privilege_checks_hostname")
                    .HasColumnType("char(255)")
                    .HasComment("Hostname part of PRIVILEGE_CHECKS_USER.")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.PrivilegeChecksUsername)
                    .HasColumnName("Privilege_checks_username")
                    .HasColumnType("char(32)")
                    .HasComment("Username part of PRIVILEGE_CHECKS_USER.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.RelayLogName)
                    .HasColumnName("Relay_log_name")
                    .HasColumnType("text")
                    .HasComment("The name of the current relay log file.")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.RelayLogPos)
                    .HasColumnName("Relay_log_pos")
                    .HasComment("The relay log position of the last executed event.");

                entity.Property(e => e.RequireRowFormat)
                    .HasColumnName("Require_row_format")
                    .HasComment("Indicates whether the channel shall only accept row based events.");

                entity.Property(e => e.SqlDelay)
                    .HasColumnName("Sql_delay")
                    .HasComment("The number of seconds that the slave must lag behind the master.");
            });

            modelBuilder.Entity<SlaveWorkerInfo>(entity =>
            {
                entity.HasKey(e => new { e.ChannelName, e.Id })
                    .HasName("PRIMARY");

                entity.ToTable("slave_worker_info");

                entity.HasComment("Worker Information");

                entity.Property(e => e.ChannelName)
                    .HasColumnName("Channel_name")
                    .HasColumnType("char(64)")
                    .HasComment("The channel on which the slave is connected to a source. Used in Multisource Replication")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CheckpointGroupBitmap)
                    .IsRequired()
                    .HasColumnName("Checkpoint_group_bitmap")
                    .HasColumnType("blob");

                entity.Property(e => e.CheckpointGroupSize).HasColumnName("Checkpoint_group_size");

                entity.Property(e => e.CheckpointMasterLogName)
                    .IsRequired()
                    .HasColumnName("Checkpoint_master_log_name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.CheckpointMasterLogPos).HasColumnName("Checkpoint_master_log_pos");

                entity.Property(e => e.CheckpointRelayLogName)
                    .IsRequired()
                    .HasColumnName("Checkpoint_relay_log_name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.CheckpointRelayLogPos).HasColumnName("Checkpoint_relay_log_pos");

                entity.Property(e => e.CheckpointSeqno).HasColumnName("Checkpoint_seqno");

                entity.Property(e => e.MasterLogName)
                    .IsRequired()
                    .HasColumnName("Master_log_name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.MasterLogPos).HasColumnName("Master_log_pos");

                entity.Property(e => e.RelayLogName)
                    .IsRequired()
                    .HasColumnName("Relay_log_name")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.RelayLogPos).HasColumnName("Relay_log_pos");
            });

            modelBuilder.Entity<SlowLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("slow_log");

                entity.HasComment("Slow log");

                entity.Property(e => e.Db)
                    .IsRequired()
                    .HasColumnName("db")
                    .HasColumnType("varchar(512)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsertId).HasColumnName("insert_id");

                entity.Property(e => e.LastInsertId).HasColumnName("last_insert_id");

                entity.Property(e => e.LockTime).HasColumnName("lock_time");

                entity.Property(e => e.QueryTime).HasColumnName("query_time");

                entity.Property(e => e.RowsExamined).HasColumnName("rows_examined");

                entity.Property(e => e.RowsSent).HasColumnName("rows_sent");

                entity.Property(e => e.ServerId).HasColumnName("server_id");

                entity.Property(e => e.SqlText)
                    .IsRequired()
                    .HasColumnName("sql_text")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("timestamp(6)")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP(6)'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ThreadId).HasColumnName("thread_id");

                entity.Property(e => e.UserHost)
                    .IsRequired()
                    .HasColumnName("user_host")
                    .HasColumnType("mediumtext")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TablesPriv>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.Db, e.User, e.TableName })
                    .HasName("PRIMARY");

                entity.ToTable("tables_priv");

                entity.HasComment("Table privileges");

                entity.HasIndex(e => e.Grantor)
                    .HasName("Grantor");

                entity.Property(e => e.Host)
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.Db)
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.User)
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.TableName)
                    .HasColumnName("Table_name")
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Grantor)
                    .IsRequired()
                    .HasColumnType("varchar(288)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<TimeZone>(entity =>
            {
                entity.ToTable("time_zone");

                entity.HasComment("Time zones");

                entity.Property(e => e.TimeZoneId).HasColumnName("Time_zone_id");

                entity.Property(e => e.UseLeapSeconds)
                    .IsRequired()
                    .HasColumnName("Use_leap_seconds")
                    .HasColumnType("enum('Y','N')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<TimeZoneLeapSecond>(entity =>
            {
                entity.HasKey(e => e.TransitionTime)
                    .HasName("PRIMARY");

                entity.ToTable("time_zone_leap_second");

                entity.HasComment("Leap seconds information for time zones");

                entity.Property(e => e.TransitionTime).HasColumnName("Transition_time");
            });

            modelBuilder.Entity<TimeZoneName>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("time_zone_name");

                entity.HasComment("Time zone names");

                entity.Property(e => e.Name)
                    .HasColumnType("char(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TimeZoneId).HasColumnName("Time_zone_id");
            });

            modelBuilder.Entity<TimeZoneTransition>(entity =>
            {
                entity.HasKey(e => new { e.TimeZoneId, e.TransitionTime })
                    .HasName("PRIMARY");

                entity.ToTable("time_zone_transition");

                entity.HasComment("Time zone transitions");

                entity.Property(e => e.TimeZoneId).HasColumnName("Time_zone_id");

                entity.Property(e => e.TransitionTime).HasColumnName("Transition_time");

                entity.Property(e => e.TransitionTypeId).HasColumnName("Transition_type_id");
            });

            modelBuilder.Entity<TimeZoneTransitionType>(entity =>
            {
                entity.HasKey(e => new { e.TimeZoneId, e.TransitionTypeId })
                    .HasName("PRIMARY");

                entity.ToTable("time_zone_transition_type");

                entity.HasComment("Time zone transition types");

                entity.Property(e => e.TimeZoneId).HasColumnName("Time_zone_id");

                entity.Property(e => e.TransitionTypeId).HasColumnName("Transition_type_id");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasColumnType("char(8)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsDst).HasColumnName("Is_DST");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.Host, e.User1 })
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasComment("Users and global privileges");

                entity.Property(e => e.Host)
                    .HasColumnType("char(255)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("ascii")
                    .HasCollation("ascii_general_ci");

                entity.Property(e => e.User1)
                    .HasColumnName("User")
                    .HasColumnType("char(32)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.AccountLocked)
                    .IsRequired()
                    .HasColumnName("account_locked")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AlterPriv)
                    .IsRequired()
                    .HasColumnName("Alter_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AlterRoutinePriv)
                    .IsRequired()
                    .HasColumnName("Alter_routine_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AuthenticationString)
                    .HasColumnName("authentication_string")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.CreatePriv)
                    .IsRequired()
                    .HasColumnName("Create_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateRolePriv)
                    .IsRequired()
                    .HasColumnName("Create_role_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateRoutinePriv)
                    .IsRequired()
                    .HasColumnName("Create_routine_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTablespacePriv)
                    .IsRequired()
                    .HasColumnName("Create_tablespace_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTmpTablePriv)
                    .IsRequired()
                    .HasColumnName("Create_tmp_table_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateUserPriv)
                    .IsRequired()
                    .HasColumnName("Create_user_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateViewPriv)
                    .IsRequired()
                    .HasColumnName("Create_view_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeletePriv)
                    .IsRequired()
                    .HasColumnName("Delete_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DropPriv)
                    .IsRequired()
                    .HasColumnName("Drop_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DropRolePriv)
                    .IsRequired()
                    .HasColumnName("Drop_role_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.EventPriv)
                    .IsRequired()
                    .HasColumnName("Event_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ExecutePriv)
                    .IsRequired()
                    .HasColumnName("Execute_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FilePriv)
                    .IsRequired()
                    .HasColumnName("File_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.GrantPriv)
                    .IsRequired()
                    .HasColumnName("Grant_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IndexPriv)
                    .IsRequired()
                    .HasColumnName("Index_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InsertPriv)
                    .IsRequired()
                    .HasColumnName("Insert_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LockTablesPriv)
                    .IsRequired()
                    .HasColumnName("Lock_tables_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MaxConnections).HasColumnName("max_connections");

                entity.Property(e => e.MaxQuestions).HasColumnName("max_questions");

                entity.Property(e => e.MaxUpdates).HasColumnName("max_updates");

                entity.Property(e => e.MaxUserConnections).HasColumnName("max_user_connections");

                entity.Property(e => e.PasswordExpired)
                    .IsRequired()
                    .HasColumnName("password_expired")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PasswordLastChanged)
                    .HasColumnName("password_last_changed")
                    .HasColumnType("timestamp");

                entity.Property(e => e.PasswordLifetime).HasColumnName("password_lifetime");

                entity.Property(e => e.PasswordRequireCurrent)
                    .HasColumnName("Password_require_current")
                    .HasColumnType("enum('N','Y')")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PasswordReuseHistory).HasColumnName("Password_reuse_history");

                entity.Property(e => e.PasswordReuseTime).HasColumnName("Password_reuse_time");

                entity.Property(e => e.Plugin)
                    .IsRequired()
                    .HasColumnName("plugin")
                    .HasColumnType("char(64)")
                    .HasDefaultValueSql("'caching_sha2_password'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.ProcessPriv)
                    .IsRequired()
                    .HasColumnName("Process_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReferencesPriv)
                    .IsRequired()
                    .HasColumnName("References_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReloadPriv)
                    .IsRequired()
                    .HasColumnName("Reload_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReplClientPriv)
                    .IsRequired()
                    .HasColumnName("Repl_client_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReplSlavePriv)
                    .IsRequired()
                    .HasColumnName("Repl_slave_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SelectPriv)
                    .IsRequired()
                    .HasColumnName("Select_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowDbPriv)
                    .IsRequired()
                    .HasColumnName("Show_db_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowViewPriv)
                    .IsRequired()
                    .HasColumnName("Show_view_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShutdownPriv)
                    .IsRequired()
                    .HasColumnName("Shutdown_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SslCipher)
                    .IsRequired()
                    .HasColumnName("ssl_cipher")
                    .HasColumnType("blob");

                entity.Property(e => e.SslType)
                    .IsRequired()
                    .HasColumnName("ssl_type")
                    .HasColumnType("enum('','ANY','X509','SPECIFIED')")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SuperPriv)
                    .IsRequired()
                    .HasColumnName("Super_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TriggerPriv)
                    .IsRequired()
                    .HasColumnName("Trigger_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UpdatePriv)
                    .IsRequired()
                    .HasColumnName("Update_priv")
                    .HasColumnType("enum('N','Y')")
                    .HasDefaultValueSql("'N'")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.X509Issuer)
                    .IsRequired()
                    .HasColumnName("x509_issuer")
                    .HasColumnType("blob");

                entity.Property(e => e.X509Subject)
                    .IsRequired()
                    .HasColumnName("x509_subject")
                    .HasColumnType("blob");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
