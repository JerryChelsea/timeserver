using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TimeServer
{
    public partial class TimeDataContext : DbContext
    {
        public TimeDataContext()
        {
        }

        public TimeDataContext(DbContextOptions<TimeDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionType> ActionType { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleCategory> ArticleCategory { get; set; }
        public virtual DbSet<ArticleNotes> ArticleNotes { get; set; }
        public virtual DbSet<ArticleSubCategory> ArticleSubCategory { get; set; }
        public virtual DbSet<ArticleType> ArticleType { get; set; }
        public virtual DbSet<ArticleXcategory> ArticleXcategory { get; set; }
        public virtual DbSet<ArticleXsubCategory> ArticleXsubCategory { get; set; }
        public virtual DbSet<AspnetApplications> AspnetApplications { get; set; }
        public virtual DbSet<AspnetMembership> AspnetMembership { get; set; }
        public virtual DbSet<AspnetPaths> AspnetPaths { get; set; }
        public virtual DbSet<AspnetPersonalizationAllUsers> AspnetPersonalizationAllUsers { get; set; }
        public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUser { get; set; }
        public virtual DbSet<AspnetProfile> AspnetProfile { get; set; }
        public virtual DbSet<AspnetRoles> AspnetRoles { get; set; }
        public virtual DbSet<AspnetSchemaVersions> AspnetSchemaVersions { get; set; }
        public virtual DbSet<AspnetUsers> AspnetUsers { get; set; }
        public virtual DbSet<AspnetUsersInRoles> AspnetUsersInRoles { get; set; }
        public virtual DbSet<AspnetWebEventEvents> AspnetWebEventEvents { get; set; }
        public virtual DbSet<BodyText> BodyText { get; set; }
        public virtual DbSet<CityLocations> CityLocations { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<EntityUnitTree> EntityUnitTree { get; set; }
        public virtual DbSet<LinkTypes> LinkTypes { get; set; }
        public virtual DbSet<OnTimeCustomers> OnTimeCustomers { get; set; }
        public virtual DbSet<OnTimeCustomersProjects> OnTimeCustomersProjects { get; set; }
        public virtual DbSet<OnTimeFeatures> OnTimeFeatures { get; set; }
        public virtual DbSet<OnTimeProjects> OnTimeProjects { get; set; }
        public virtual DbSet<OnTimeWorkLog> OnTimeWorkLog { get; set; }
        public virtual DbSet<PageRef> PageRef { get; set; }
        public virtual DbSet<PageRefArticleCategory> PageRefArticleCategory { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Reference> Reference { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<SmCategory> SmCategory { get; set; }
        public virtual DbSet<SmProduct> SmProduct { get; set; }
        public virtual DbSet<SmSubCategory> SmSubCategory { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<SubPageRef> SubPageRef { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<TagReference> TagReference { get; set; }
        public virtual DbSet<UsedWords> UsedWords { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<VWordpair> VWordpair { get; set; }
        public virtual DbSet<VwAspnetApplications> VwAspnetApplications { get; set; }
        public virtual DbSet<VwAspnetMembershipUsers> VwAspnetMembershipUsers { get; set; }
        public virtual DbSet<VwAspnetProfiles> VwAspnetProfiles { get; set; }
        public virtual DbSet<VwAspnetRoles> VwAspnetRoles { get; set; }
        public virtual DbSet<VwAspnetUsers> VwAspnetUsers { get; set; }
        public virtual DbSet<VwAspnetUsersInRoles> VwAspnetUsersInRoles { get; set; }
        public virtual DbSet<VwAspnetWebPartStatePaths> VwAspnetWebPartStatePaths { get; set; }
        public virtual DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShared { get; set; }
        public virtual DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUser { get; set; }
        public virtual DbSet<WebpagesMembership> WebpagesMembership { get; set; }
        public virtual DbSet<WebpagesOauthMembership> WebpagesOauthMembership { get; set; }
        public virtual DbSet<WebpagesRoles> WebpagesRoles { get; set; }
        public virtual DbSet<WebpagesUsersInRoles> WebpagesUsersInRoles { get; set; }
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<WordLink> WordLink { get; set; }
        public virtual DbSet<WordPairs> WordPairs { get; set; }
        public virtual DbSet<Wordlinklist> Wordlinklist { get; set; }
        public virtual DbSet<Wordlist> Wordlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=sql2k802.discountasp.net;Initial Catalog=SQL2008_741027_jerry;Persist Security Info=True;User ID=SQL2008_741027_jerry_user;Password=Gianluca12!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Author).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<ArticleNotes>(entity =>
            {
                entity.Property(e => e.ArticleId).ValueGeneratedNever();

                entity.HasOne(d => d.Article)
                    .WithOne(p => p.ArticleNotes)
                    .HasForeignKey<ArticleNotes>(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleNotes_Article");
            });

            modelBuilder.Entity<ArticleSubCategory>(entity =>
            {
                entity.HasOne(d => d.ArticleCategory)
                    .WithMany(p => p.ArticleSubCategory)
                    .HasForeignKey(d => d.ArticleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleSubCategory_ArticleCategory");
            });

            modelBuilder.Entity<ArticleXcategory>(entity =>
            {
                entity.HasOne(d => d.ArticleCategory)
                    .WithMany(p => p.ArticleXcategory)
                    .HasForeignKey(d => d.ArticleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleXCategory_ArticleCategory");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleXcategory)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleXCategory_Article");
            });

            modelBuilder.Entity<ArticleXsubCategory>(entity =>
            {
                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleXsubCategory)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleXSubCategory_Article");

                entity.HasOne(d => d.ArticleSubCategory)
                    .WithMany(p => p.ArticleXsubCategory)
                    .HasForeignKey(d => d.ArticleSubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticleXSubCategory_ArticleSubCategory");
            });

            modelBuilder.Entity<AspnetApplications>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .HasName("PK__aspnet_A__C93A4C985BE2A6F2")
                    .IsClustered(false);

                entity.HasIndex(e => e.ApplicationName)
                    .HasName("UQ__aspnet_A__30910331619B8048")
                    .IsUnique();

                entity.HasIndex(e => e.LoweredApplicationName)
                    .HasName("aspnet_Applications_Index")
                    .IsClustered();

                entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<AspnetMembership>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_M__1788CC4D7A672E12")
                    .IsClustered(false);

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredEmail })
                    .HasName("aspnet_Membership_index")
                    .IsClustered();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetMembership)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Me__Appli__7C4F7684");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspnetMembership)
                    .HasForeignKey<AspnetMembership>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Me__UserI__7D439ABD");
            });

            modelBuilder.Entity<AspnetPaths>(entity =>
            {
                entity.HasKey(e => e.PathId)
                    .HasName("PK__aspnet_P__CD67DC58339FAB6E")
                    .IsClustered(false);

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredPath })
                    .HasName("aspnet_Paths_index")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetPaths)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pa__Appli__3587F3E0");
            });

            modelBuilder.Entity<AspnetPersonalizationAllUsers>(entity =>
            {
                entity.HasKey(e => e.PathId)
                    .HasName("PK__aspnet_P__CD67DC593B40CD36");

                entity.Property(e => e.PathId).ValueGeneratedNever();

                entity.HasOne(d => d.Path)
                    .WithOne(p => p.AspnetPersonalizationAllUsers)
                    .HasForeignKey<AspnetPersonalizationAllUsers>(d => d.PathId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pe__PathI__3D2915A8");
            });

            modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__aspnet_P__3214EC0640058253")
                    .IsClustered(false);

                entity.HasIndex(e => new { e.PathId, e.UserId })
                    .HasName("aspnet_PersonalizationPerUser_index1")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => new { e.UserId, e.PathId })
                    .HasName("aspnet_PersonalizationPerUser_ncindex2")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Path)
                    .WithMany(p => p.AspnetPersonalizationPerUser)
                    .HasForeignKey(d => d.PathId)
                    .HasConstraintName("FK__aspnet_Pe__PathI__42E1EEFE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspnetPersonalizationPerUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__aspnet_Pe__UserI__43D61337");
            });

            modelBuilder.Entity<AspnetProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_P__1788CC4C114A936A");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AspnetProfile)
                    .HasForeignKey<AspnetProfile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Pr__UserI__1332DBDC");
            });

            modelBuilder.Entity<AspnetRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__aspnet_R__8AFACE1B1CBC4616")
                    .IsClustered(false);

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName })
                    .HasName("aspnet_Roles_index1")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetRoles)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Ro__Appli__1EA48E88");
            });

            modelBuilder.Entity<AspnetSchemaVersions>(entity =>
            {
                entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion })
                    .HasName("PK__aspnet_S__5A1E6BC16E01572D");
            });

            modelBuilder.Entity<AspnetUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__aspnet_U__1788CC4D66603565")
                    .IsClustered(false);

                entity.HasIndex(e => new { e.ApplicationId, e.LastActivityDate })
                    .HasName("aspnet_Users_Index2");

                entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName })
                    .HasName("aspnet_Users_Index")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.AspnetUsers)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__Appli__68487DD7");
            });

            modelBuilder.Entity<AspnetUsersInRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK__aspnet_U__AF2760AD22751F6C");

                entity.HasIndex(e => e.RoleId)
                    .HasName("aspnet_UsersInRoles_index");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspnetUsersInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__RoleI__25518C17");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspnetUsersInRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aspnet_Us__UserI__245D67DE");
            });

            modelBuilder.Entity<AspnetWebEventEvents>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PK__aspnet_W__7944C810540C7B00");

                entity.Property(e => e.EventId)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<BodyText>(entity =>
            {
                entity.HasKey(e => e.BodyId)
                    .HasName("PK__BodyText__8545D8B56CD828CA");

                entity.HasIndex(e => e.BodySubPage)
                    .HasName("IX_BodyText")
                    .IsUnique();
            });

            modelBuilder.Entity<CityLocations>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.CustomerName).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.Zip).IsUnicode(false);
            });

            modelBuilder.Entity<EntityUnitTree>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FullName).IsUnicode(false);

                entity.Property(e => e.LocationName).IsUnicode(false);
            });

            modelBuilder.Entity<LinkTypes>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<OnTimeCustomersProjects>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ProjectId });
            });

            modelBuilder.Entity<OnTimeFeatures>(entity =>
            {
                entity.HasKey(e => e.FeatureId)
                    .HasName("PK_OnTimeTasks");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<OnTimeProjects>(entity =>
            {
                entity.Property(e => e.ProjectId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Path).IsUnicode(false);
            });

            modelBuilder.Entity<OnTimeWorkLog>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<PageRef>(entity =>
            {
                entity.Property(e => e.PageRef1).IsUnicode(false);
            });

            modelBuilder.Entity<PageRefArticleCategory>(entity =>
            {
                entity.HasKey(e => new { e.PageRef, e.CategoryId });

                entity.Property(e => e.PageRef).IsUnicode(false);
            });

            modelBuilder.Entity<Reference>(entity =>
            {
                entity.HasIndex(e => e.RefId)
                    .HasName("IX_Reference");

                entity.Property(e => e.PageRef).IsUnicode(false);

                entity.Property(e => e.Reference1).IsUnicode(false);

                entity.Property(e => e.SubPageRef).IsUnicode(false);

                entity.Property(e => e.Tags).IsUnicode(false);

                entity.Property(e => e.WebSite).IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => new { e.Customerid, e.SchedId });

                entity.Property(e => e.SchedId).ValueGeneratedOnAdd();

                entity.Property(e => e.SchedName).IsUnicode(false);
            });

            modelBuilder.Entity<SmCategory>(entity =>
            {
                entity.Property(e => e.CatName).IsUnicode(false);
            });

            modelBuilder.Entity<SmProduct>(entity =>
            {
                entity.Property(e => e.ProdName).IsUnicode(false);

                entity.Property(e => e.SaleUnit).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SmProduct)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_smProduct_smCategory");

                entity.HasOne(d => d.SmSubCategory)
                    .WithMany(p => p.SmProduct)
                    .HasForeignKey(d => new { d.CategoryId, d.SubCategoryId })
                    .HasConstraintName("FK_smProduct_smSubCategory");
            });

            modelBuilder.Entity<SmSubCategory>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.SubCategoryId });

                entity.Property(e => e.SubCategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.SubCatName).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SmSubCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_smSubCategory_smCategory");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.StateAbbr).IsUnicode(false);

                entity.Property(e => e.StateName).IsUnicode(false);
            });

            modelBuilder.Entity<SubPageRef>(entity =>
            {
                entity.HasKey(e => new { e.PageRef, e.SubPageRef1 });

                entity.Property(e => e.PageRef).IsUnicode(false);

                entity.Property(e => e.SubPageRef1).IsUnicode(false);

                entity.HasOne(d => d.PageRefNavigation)
                    .WithMany(p => p.SubPageRef)
                    .HasForeignKey(d => d.PageRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubPageRef_PageRef");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => new { e.PageRef, e.SubPageRef, e.TagId });

                entity.Property(e => e.PageRef).IsUnicode(false);

                entity.Property(e => e.SubPageRef).IsUnicode(false);
            });

            modelBuilder.Entity<TagReference>(entity =>
            {
                entity.HasIndex(e => e.Tagid)
                    .HasName("IX_TagReference")
                    .IsUnique();

                entity.Property(e => e.Tag).IsUnicode(false);

                entity.Property(e => e.Fontsize).IsUnicode(false);

                entity.Property(e => e.Tagclass).IsUnicode(false);

                entity.Property(e => e.Tagid).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<UsedWords>(entity =>
            {
                entity.Property(e => e.Wordid).ValueGeneratedNever();
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserProf__1788CC4C67DE6983");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__UserProf__C9F284566ABAD62E")
                    .IsUnique();
            });

            modelBuilder.Entity<VWordpair>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_WORDPAIR");

                entity.Property(e => e.Example).IsUnicode(false);

                entity.Property(e => e.Example1).IsUnicode(false);

                entity.Property(e => e.Language).IsUnicode(false);

                entity.Property(e => e.Language1).IsUnicode(false);

                entity.Property(e => e.Note).IsUnicode(false);

                entity.Property(e => e.Note1).IsUnicode(false);

                entity.Property(e => e.Phrase).IsUnicode(false);

                entity.Property(e => e.Phrase1).IsUnicode(false);
            });

            modelBuilder.Entity<VwAspnetApplications>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Applications");
            });

            modelBuilder.Entity<VwAspnetMembershipUsers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_MembershipUsers");
            });

            modelBuilder.Entity<VwAspnetProfiles>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Profiles");
            });

            modelBuilder.Entity<VwAspnetRoles>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Roles");
            });

            modelBuilder.Entity<VwAspnetUsers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_Users");
            });

            modelBuilder.Entity<VwAspnetUsersInRoles>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_UsersInRoles");
            });

            modelBuilder.Entity<VwAspnetWebPartStatePaths>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_WebPartState_Paths");
            });

            modelBuilder.Entity<VwAspnetWebPartStateShared>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_WebPartState_Shared");
            });

            modelBuilder.Entity<VwAspnetWebPartStateUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_aspnet_WebPartState_User");
            });

            modelBuilder.Entity<WebpagesMembership>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__webpages__1788CC4C725BF7F6");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.IsConfirmed).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<WebpagesOauthMembership>(entity =>
            {
                entity.HasKey(e => new { e.Provider, e.ProviderUserId })
                    .HasName("PK__webpages__F53FC0ED6E8B6712");
            });

            modelBuilder.Entity<WebpagesRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__webpages__8AFACE1A7814D14C");

                entity.HasIndex(e => e.RoleName)
                    .HasName("UQ__webpages__8A2B61607AF13DF7")
                    .IsUnique();
            });

            modelBuilder.Entity<WebpagesUsersInRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK__webpages__AF2760AD7EC1CEDB");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.WebpagesUsersInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WebpagesUsersInRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UserId");
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.HasIndex(e => e.Phrase)
                    .HasName("IX_Word")
                    .IsUnique();

                entity.Property(e => e.Example).IsUnicode(false);

                entity.Property(e => e.Language).IsUnicode(false);

                entity.Property(e => e.Note).IsUnicode(false);

                entity.Property(e => e.Phrase).IsUnicode(false);
            });

            modelBuilder.Entity<WordLink>(entity =>
            {
                entity.HasKey(e => new { e.WordId1, e.WordId2 });

                entity.HasIndex(e => e.WordLinkId)
                    .HasName("IX_WordLink_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.WordId2, e.WordId1 })
                    .HasName("IX_WordLink")
                    .IsUnique();

                entity.Property(e => e.WordLinkId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.WordId1Navigation)
                    .WithMany(p => p.WordLinkWordId1Navigation)
                    .HasForeignKey(d => d.WordId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WordLink_Word");

                entity.HasOne(d => d.WordId2Navigation)
                    .WithMany(p => p.WordLinkWordId2Navigation)
                    .HasForeignKey(d => d.WordId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WordLink_Word1");
            });

            modelBuilder.Entity<WordPairs>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Example).IsUnicode(false);

                entity.Property(e => e.Example1).IsUnicode(false);

                entity.Property(e => e.Language).IsUnicode(false);

                entity.Property(e => e.Language1).IsUnicode(false);

                entity.Property(e => e.Note).IsUnicode(false);

                entity.Property(e => e.Note1).IsUnicode(false);

                entity.Property(e => e.Phrase).IsUnicode(false);

                entity.Property(e => e.Phrase1).IsUnicode(false);

                entity.Property(e => e.Wordlinkid).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Wordlinklist>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WORDLINKLIST");

                entity.Property(e => e.Language).IsUnicode(false);
            });

            modelBuilder.Entity<Wordlist>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WORDLIST");

                entity.Property(e => e.Phrase).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
