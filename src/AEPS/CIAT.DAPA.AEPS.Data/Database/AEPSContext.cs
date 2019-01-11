using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CIAT.DAPA.AEPS.Data.Database
{
    public partial class AEPSContext : DbContext
    {
        public AEPSContext()
        {
        }

        public AEPSContext(DbContextOptions<AEPSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConCountries> ConCountries { get; set; }
        public virtual DbSet<ConMunicipalities> ConMunicipalities { get; set; }
        public virtual DbSet<ConStates> ConStates { get; set; }
        public virtual DbSet<FarAnswers> FarAnswers { get; set; }
        public virtual DbSet<FarFarms> FarFarms { get; set; }
        public virtual DbSet<FarPlots> FarPlots { get; set; }
        public virtual DbSet<FarProductionEvents> FarProductionEvents { get; set; }
        public virtual DbSet<FarResponsesBool> FarResponsesBool { get; set; }
        public virtual DbSet<FarResponsesDate> FarResponsesDate { get; set; }
        public virtual DbSet<FarResponsesNumeric> FarResponsesNumeric { get; set; }
        public virtual DbSet<FarResponsesOptions> FarResponsesOptions { get; set; }
        public virtual DbSet<FarResponsesText> FarResponsesText { get; set; }
        public virtual DbSet<FrmBlocks> FrmBlocks { get; set; }
        public virtual DbSet<FrmBlocksForms> FrmBlocksForms { get; set; }
        public virtual DbSet<FrmForms> FrmForms { get; set; }
        public virtual DbSet<FrmOptions> FrmOptions { get; set; }
        public virtual DbSet<FrmQuestions> FrmQuestions { get; set; }
        public virtual DbSet<SocAssociations> SocAssociations { get; set; }
        public virtual DbSet<SocPeople> SocPeople { get; set; }
        public virtual DbSet<SocTechnicalAssistants> SocTechnicalAssistants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=aeps_2_0");
            }
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConCountries>(entity =>
            {
                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<ConMunicipalities>(entity =>
            {
                entity.HasIndex(e => e.State)
                    .HasName("fk_con_states_con_municipalities_idx");

                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.ConMunicipalities)
                    .HasForeignKey(d => d.State)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_con_states_con_municipalities");
            });

            modelBuilder.Entity<ConStates>(entity =>
            {
                entity.HasIndex(e => e.Country)
                    .HasName("fk_con_countries_con_state_idx");

                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.ConStates)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_con_countries_con_state");
            });

            modelBuilder.Entity<FarAnswers>(entity =>
            {
                entity.HasIndex(e => e.Event)
                    .HasName("fk_far_production_events_far_answers_idx");

                entity.HasIndex(e => e.Question)
                    .HasName("fk_frm_questions_far_answers_idx");

                entity.Property(e => e.ValueFixed).IsUnicode(false);

                entity.Property(e => e.ValueRaw).IsUnicode(false);

                entity.HasOne(d => d.EventNavigation)
                    .WithMany(p => p.FarAnswers)
                    .HasForeignKey(d => d.Event)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_far_production_events_far_answers");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.FarAnswers)
                    .HasForeignKey(d => d.Question)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_questions_far_answers");
            });

            modelBuilder.Entity<FarFarms>(entity =>
            {
                entity.HasIndex(e => e.Farmer)
                    .HasName("fk_soc_people_far_farms_farmer_idx");

                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.LocationComments).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.FarmerNavigation)
                    .WithMany(p => p.FarFarms)
                    .HasForeignKey(d => d.Farmer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_soc_people_far_farms_farmer");
            });

            modelBuilder.Entity<FarPlots>(entity =>
            {
                entity.HasIndex(e => e.Farm)
                    .HasName("fk_far_farms_far_plots_idx");

                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.FarmNavigation)
                    .WithMany(p => p.FarPlots)
                    .HasForeignKey(d => d.Farm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_far_farms_far_plots");
            });

            modelBuilder.Entity<FarProductionEvents>(entity =>
            {
                entity.HasIndex(e => e.Form)
                    .HasName("fk_frm_forms_far_production_events_idx");

                entity.HasIndex(e => e.Plot)
                    .HasName("fk_far_plots_far_production_events_idx");

                entity.HasIndex(e => e.Technical)
                    .HasName("fk_soc_technical_assitants_far_production_events_idx");

                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.Updated).IsUnicode(false);

                entity.HasOne(d => d.FormNavigation)
                    .WithMany(p => p.FarProductionEvents)
                    .HasForeignKey(d => d.Form)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_forms_far_production_events");

                entity.HasOne(d => d.PlotNavigation)
                    .WithMany(p => p.FarProductionEvents)
                    .HasForeignKey(d => d.Plot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_far_plots_far_production_events");

                entity.HasOne(d => d.TechnicalNavigation)
                    .WithMany(p => p.FarProductionEvents)
                    .HasForeignKey(d => d.Technical)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_soc_technical_assitants_far_production_events");
            });

            modelBuilder.Entity<FarResponsesBool>(entity =>
            {
                entity.HasIndex(e => e.Event)
                    .HasName("fk_far_production_events_far_responses_bool_idx");

                entity.HasIndex(e => e.Question)
                    .HasName("fk_frm_questions_far_responses_bool_idx");

                entity.HasOne(d => d.EventNavigation)
                    .WithMany(p => p.FarResponsesBool)
                    .HasForeignKey(d => d.Event)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_far_production_events_far_responses_bool");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.FarResponsesBool)
                    .HasForeignKey(d => d.Question)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_questions_far_responses_bool");
            });

            modelBuilder.Entity<FarResponsesDate>(entity =>
            {
                entity.HasIndex(e => e.Event)
                    .HasName("fk_far_production_events_frm_responses_date_idx");

                entity.HasIndex(e => e.Question)
                    .HasName("fk_frm_questions_far_responses_date_idx");

                entity.HasOne(d => d.EventNavigation)
                    .WithMany(p => p.FarResponsesDate)
                    .HasForeignKey(d => d.Event)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_far_production_events_frm_responses_date");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.FarResponsesDate)
                    .HasForeignKey(d => d.Question)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_questions_far_responses_date");
            });

            modelBuilder.Entity<FarResponsesNumeric>(entity =>
            {
                entity.HasIndex(e => e.Event)
                    .HasName("fk_far_production_events_far_responses_numeric_idx");

                entity.HasIndex(e => e.Question)
                    .HasName("fk_frm_questions_far_responses_numeric_idx");

                entity.Property(e => e.FixedUnits).IsUnicode(false);

                entity.Property(e => e.RawUnits).IsUnicode(false);

                entity.HasOne(d => d.EventNavigation)
                    .WithMany(p => p.FarResponsesNumeric)
                    .HasForeignKey(d => d.Event)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_far_production_events_far_responses_numeric");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.FarResponsesNumeric)
                    .HasForeignKey(d => d.Question)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_questions_far_responses_numeric");
            });

            modelBuilder.Entity<FarResponsesOptions>(entity =>
            {
                entity.HasIndex(e => e.Event)
                    .HasName("fk_far_production_events_far_responses_options_idx");

                entity.HasIndex(e => e.Option)
                    .HasName("fk_frm_options_far_responses_options_idx");

                entity.HasIndex(e => e.Question)
                    .HasName("fk_frm_question_far_responses_options_idx");

                entity.Property(e => e.Value).IsUnicode(false);

                entity.HasOne(d => d.EventNavigation)
                    .WithMany(p => p.FarResponsesOptions)
                    .HasForeignKey(d => d.Event)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_far_production_events_far_responses_options");

                entity.HasOne(d => d.OptionNavigation)
                    .WithMany(p => p.FarResponsesOptions)
                    .HasForeignKey(d => d.Option)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_options_far_responses_options");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.FarResponsesOptions)
                    .HasForeignKey(d => d.Question)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_questions_far_responses_options");
            });

            modelBuilder.Entity<FarResponsesText>(entity =>
            {
                entity.HasIndex(e => e.Event)
                    .HasName("fk_far_production_events_far_responses_text_idx");

                entity.HasIndex(e => e.Question)
                    .HasName("fk_frm_questions_far_responses_text_idx");

                entity.Property(e => e.FixedValue).IsUnicode(false);

                entity.Property(e => e.RawValue).IsUnicode(false);

                entity.HasOne(d => d.EventNavigation)
                    .WithMany(p => p.FarResponsesText)
                    .HasForeignKey(d => d.Event)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_far_production_events_far_responses_text");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.FarResponsesText)
                    .HasForeignKey(d => d.Question)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_questions_far_responses_text");
            });

            modelBuilder.Entity<FrmBlocks>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<FrmBlocksForms>(entity =>
            {
                entity.HasKey(e => new { e.Form, e.Block });

                entity.HasIndex(e => e.Block)
                    .HasName("fk_frm_blocks_frm_blocks_frm_forms_idx");

                entity.HasIndex(e => e.Form)
                    .HasName("fk_frm_forms_frm_blocks_frm_forms_idx");

                entity.HasOne(d => d.BlockNavigation)
                    .WithMany(p => p.FrmBlocksForms)
                    .HasForeignKey(d => d.Block)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_blocks_frm_blocks_frm_forms");

                entity.HasOne(d => d.FormNavigation)
                    .WithMany(p => p.FrmBlocksForms)
                    .HasForeignKey(d => d.Form)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_forms_frm_blocks_frm_forms");
            });

            modelBuilder.Entity<FrmForms>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<FrmOptions>(entity =>
            {
                entity.HasIndex(e => e.Question)
                    .HasName("fk_frm_questions_frm_options_idx");

                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.Label).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.FrmOptions)
                    .HasForeignKey(d => d.Question)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_questions_frm_options");
            });

            modelBuilder.Entity<FrmQuestions>(entity =>
            {
                entity.HasIndex(e => e.Block)
                    .HasName("fk_frm_blocks_frm_questions_idx");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.Label).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.BlockNavigation)
                    .WithMany(p => p.FrmQuestions)
                    .HasForeignKey(d => d.Block)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_frm_blocks_frm_questions");
            });

            modelBuilder.Entity<SocAssociations>(entity =>
            {
                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<SocPeople>(entity =>
            {
                entity.HasIndex(e => e.Municipality)
                    .HasName("fk_con_municipalities_soc_people_idx");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Cellphone).IsUnicode(false);

                entity.Property(e => e.Document).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.ExtId).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.MunicipalityNavigation)
                    .WithMany(p => p.SocPeople)
                    .HasForeignKey(d => d.Municipality)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_con_municipalities_soc_people");
            });

            modelBuilder.Entity<SocTechnicalAssistants>(entity =>
            {
                entity.HasIndex(e => e.Association)
                    .HasName("fk_soc_associations_soc_technical_assistants_idx");

                entity.HasIndex(e => e.Person)
                    .HasName("fk_soc_people_soc_technical_assistants_idx");

                entity.HasOne(d => d.AssociationNavigation)
                    .WithMany(p => p.SocTechnicalAssistants)
                    .HasForeignKey(d => d.Association)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_soc_associations_soc_technical_assistants");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.SocTechnicalAssistants)
                    .HasForeignKey(d => d.Person)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_soc_people_soc_technical_assistants");
            });
        }
    }
}
