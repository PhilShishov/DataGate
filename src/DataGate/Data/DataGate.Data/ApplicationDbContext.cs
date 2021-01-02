namespace DataGate.Data
{
    using DataGate.Common;
    using DataGate.Data.Models.Domain;
    using DataGate.Data.Models.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public partial class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
           : base(options)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<TbCalendar> TbCalendar { get; set; }
        public virtual DbSet<TbCompanies> TbCompanies { get; set; }
        public virtual DbSet<TbCountryDistributionShares> TbCountryDistributionShares { get; set; }
        public virtual DbSet<TbDomActivityType> TbDomActivityType { get; set; }
        public virtual DbSet<TbDomAgreementStatus> TbDomAgreementStatus { get; set; }
        public virtual DbSet<TbDomCalculationDate> TbDomCalculationDate { get; set; }
        public virtual DbSet<TbDomCesrClass> TbDomCesrClass { get; set; }
        public virtual DbSet<TbDomCompanyType> TbDomCompanyType { get; set; }
        public virtual DbSet<TbDomCssfGeographicalFocus> TbDomCssfGeographicalFocus { get; set; }
        public virtual DbSet<TbDomCssfPrincipalAssetClass> TbDomCssfPrincipalAssetClass { get; set; }
        public virtual DbSet<TbDomDerivMarket> TbDomDerivMarket { get; set; }
        public virtual DbSet<TbDomDerivPurpose> TbDomDerivPurpose { get; set; }
        public virtual DbSet<TbDomEntity> TbDomEntity { get; set; }
        public virtual DbSet<TbDomFStatus> TbDomFStatus { get; set; }
        public virtual DbSet<TbDomFee> TbDomFee { get; set; }
        public virtual DbSet<TbDomFeeFrequency> TbDomFeeFrequency { get; set; }
        public virtual DbSet<TbDomFeeType> TbDomFeeType { get; set; }
        public virtual DbSet<TbDomFileType> TbDomFileType { get; set; }
        public virtual DbSet<TbDomGlobalExposure> TbDomGlobalExposure { get; set; }
        public virtual DbSet<TbDomInvestorType> TbDomInvestorType { get; set; }
        public virtual DbSet<TbDomIsoCountry> TbDomIsoCountry { get; set; }
        public virtual DbSet<TbDomIsoCurrency> TbDomIsoCurrency { get; set; }
        public virtual DbSet<TbDomLanguages> TbDomLanguages { get; set; }
        public virtual DbSet<TbDomLegalForm> TbDomLegalForm { get; set; }
        public virtual DbSet<TbDomLegalType> TbDomLegalType { get; set; }
        public virtual DbSet<TbDomLegalVehicle> TbDomLegalVehicle { get; set; }
        public virtual DbSet<TbDomNavFrequency> TbDomNavFrequency { get; set; }
        public virtual DbSet<TbDomPrincipalInvestmentStrategy> TbDomPrincipalInvestmentStrategy { get; set; }
        public virtual DbSet<TbDomSfCatBloomberg> TbDomSfCatBloomberg { get; set; }
        public virtual DbSet<TbDomSfCatMorningstar> TbDomSfCatMorningstar { get; set; }
        public virtual DbSet<TbDomSfCatSix> TbDomSfCatSix { get; set; }
        public virtual DbSet<TbDomSfStatus> TbDomSfStatus { get; set; }
        public virtual DbSet<TbDomShareStatus> TbDomShareStatus { get; set; }
        public virtual DbSet<TbDomShareType> TbDomShareType { get; set; }
        public virtual DbSet<TbDomTimeseriesProvider> TbDomTimeseriesProvider { get; set; }
        public virtual DbSet<TbDomTimeseriesType> TbDomTimeseriesType { get; set; }
        public virtual DbSet<TbDomTypeOfMarket> TbDomTypeOfMarket { get; set; }
        public virtual DbSet<TbDomValutationDate> TbDomValutationDate { get; set; }
        public virtual DbSet<TbFile> TbFile { get; set; }
        public virtual DbSet<TbFund> TbFund { get; set; }
        public virtual DbSet<TbFundSubFund> TbFundSubFund { get; set; }
        public virtual DbSet<TbHistoryFund> TbHistoryFund { get; set; }
        public virtual DbSet<TbHistoryShareClass> TbHistoryShareClass { get; set; }
        public virtual DbSet<TbHistoryShareClassCopy> TbHistoryShareClassCopy { get; set; }
        public virtual DbSet<TbHistorySubFund> TbHistorySubFund { get; set; }
        public virtual DbSet<TbMapFilefund> TbMapFilefund { get; set; }
        public virtual DbSet<TbMapFileshareclass> TbMapFileshareclass { get; set; }
        public virtual DbSet<TbMapFilesubfund> TbMapFilesubfund { get; set; }
        public virtual DbSet<TbMapNavFrequencyValuation> TbMapNavFrequencyValuation { get; set; }
        public virtual DbSet<TbPrimeShareClass> TbPrimeShareClass { get; set; }
        public virtual DbSet<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }
        public virtual DbSet<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }
        public virtual DbSet<TbServiceAgreementSubfund> TbServiceAgreementSubfund { get; set; }
        public virtual DbSet<TbShareClass> TbShareClass { get; set; }
        public virtual DbSet<TbShareclassTsTest> TbShareclassTsTest { get; set; }
        public virtual DbSet<TbSubFund> TbSubFund { get; set; }
        public virtual DbSet<TbSubFundShareClass> TbSubFundShareClass { get; set; }
        public virtual DbSet<TbTimeseriesShareclass> TbTimeseriesShareclass { get; set; }
        public virtual DbSet<TbTimeseriesSubfund> TbTimeseriesSubfund { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.configuration.GetConnectionString(GlobalConstants.DataGateAppConnection));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCalendar>(entity =>
            {
                entity.HasKey(e => new { e.IdDomFreq, e.IdDomValDate, e.CalendarDate })
                    .HasName("PK_tb_calendar_1");

                entity.ToTable("tb_calendar");

                entity.Property(e => e.IdDomFreq).HasColumnName("id_dom_freq");

                entity.Property(e => e.IdDomValDate).HasColumnName("id_dom_val_date");

                entity.Property(e => e.CalendarDate)
                    .HasColumnName("calendar_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdDom)
                    .WithMany(p => p.TbCalendar)
                    .HasForeignKey(d => new { d.IdDomFreq, d.IdDomValDate })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_calendar_tb_map_nav_frequency_valuation");
            });

            modelBuilder.Entity<TbCompanies>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK_tb_company");

                entity.ToTable("tb_companies");

                entity.Property(e => e.CId)
                    .HasColumnName("c_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("c_name");
            });

            modelBuilder.Entity<TbCountryDistributionShares>(entity =>
            {
                entity.HasKey(e => new { e.ShareId, e.IsoCountry2, e.Language });

                entity.ToTable("tb_country_distribution_shares");

                entity.Property(e => e.ShareId).HasColumnName("share_id");

                entity.Property(e => e.IsoCountry2)
                    .HasColumnName("iso_country_2")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.LegalSupport).HasColumnName("legal_support");

                entity.Property(e => e.LocalRepresentative).HasColumnName("local_representative");

                entity.Property(e => e.PayingAgent).HasColumnName("paying_agent");

                entity.HasOne(d => d.IsoCountry2Navigation)
                    .WithMany(p => p.TbCountryDistributionShares)
                    .HasForeignKey(d => d.IsoCountry2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_country_distribution_shares_tb_dom_iso_country");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.TbCountryDistributionShares)
                    .HasForeignKey(d => d.Language)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_country_distribution_shares_tb_dom_languages");

                entity.HasOne(d => d.Share)
                    .WithMany(p => p.TbCountryDistributionShares)
                    .HasForeignKey(d => d.ShareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_country_distribution_shares_tb_shareClass");
            });

            modelBuilder.Entity<TbDomActivityType>(entity =>
            {
                entity.HasKey(e => e.AtId);

                entity.ToTable("tb_dom_activityType");

                entity.Property(e => e.AtId)
                    .HasColumnName("at_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AtDesc)
                    .HasColumnName("at_desc")
                    .HasMaxLength(100);

                entity.Property(e => e.AtEntity).HasColumnName("at_entity");

                entity.HasOne(d => d.AtEntityNavigation)
                    .WithMany(p => p.TbDomActivityType)
                    .HasForeignKey(d => d.AtEntity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_dom_activityType_tb_dom_entity");
            });

            modelBuilder.Entity<TbDomAgreementStatus>(entity =>
            {
                entity.HasKey(e => e.ASId);

                entity.ToTable("tb_dom_agreement_status");

                entity.Property(e => e.ASId).HasColumnName("a_s_id");

                entity.Property(e => e.ASDesc)
                    .IsRequired()
                    .HasColumnName("a_s_desc")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbDomCalculationDate>(entity =>
            {
                entity.HasKey(e => e.CdId);

                entity.ToTable("tb_dom_calculationDate");

                entity.Property(e => e.CdId)
                    .HasColumnName("cd_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CdDesc)
                    .HasColumnName("cd_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomCesrClass>(entity =>
            {
                entity.HasKey(e => e.CcId);

                entity.ToTable("tb_dom_cesrClass");

                entity.Property(e => e.CcId)
                    .HasColumnName("cc_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CDesc)
                    .HasColumnName("c_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomCompanyType>(entity =>
            {
                entity.HasKey(e => e.CtId);

                entity.ToTable("tb_dom_company_type");

                entity.Property(e => e.CtId)
                    .HasColumnName("ct_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CtAcronym)
                    .IsRequired()
                    .HasColumnName("ct_acronym")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CtDesc)
                    .IsRequired()
                    .HasColumnName("ct_desc")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbDomCssfGeographicalFocus>(entity =>
            {
                entity.HasKey(e => e.GfId);

                entity.ToTable("tb_dom_cssf_geographical_focus");

                entity.Property(e => e.GfId)
                    .HasColumnName("gf_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GfDesc)
                    .HasColumnName("gf_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomCssfPrincipalAssetClass>(entity =>
            {
                entity.HasKey(e => e.PacId);

                entity.ToTable("tb_dom_cssf_principal_asset_class");

                entity.Property(e => e.PacId)
                    .HasColumnName("pac_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PacDesc)
                    .HasColumnName("pac_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomDerivMarket>(entity =>
            {
                entity.HasKey(e => e.DmId);

                entity.ToTable("tb_dom_derivMarket");

                entity.Property(e => e.DmId)
                    .HasColumnName("dm_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DmDesc)
                    .HasColumnName("dm_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomDerivPurpose>(entity =>
            {
                entity.HasKey(e => e.DpId);

                entity.ToTable("tb_dom_derivPurpose");

                entity.Property(e => e.DpId)
                    .HasColumnName("dp_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DpDesc)
                    .HasColumnName("dp_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomEntity>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("tb_dom_entity");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.EntityDesc)
                    .IsRequired()
                    .HasColumnName("entity_desc");
            });

            modelBuilder.Entity<TbDomFStatus>(entity =>
            {
                entity.HasKey(e => e.StFId);

                entity.ToTable("tb_dom_f_status");

                entity.Property(e => e.StFId)
                    .HasColumnName("st_f_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.StFDesc)
                    .HasColumnName("st_f_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomFee>(entity =>
            {
                entity.HasKey(e => e.FeeId)
                    .HasName("PK__tb_dom_fee");

                entity.ToTable("tb_dom_fee");

                entity.Property(e => e.FeeId)
                    .HasColumnName("fee_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FeeDesc)
                    .HasColumnName("fee_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomFeeFrequency>(entity =>
            {
                entity.HasKey(e => e.FfId)
                    .HasName("PK__tb_dom_fee_frequency");

                entity.ToTable("tb_dom_fee_frequency");

                entity.Property(e => e.FfId)
                    .HasColumnName("ff_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FfDesc)
                    .HasColumnName("ff_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomFeeType>(entity =>
            {
                entity.HasKey(e => e.FtId)
                    .HasName("PK__tb_dom_feeType");

                entity.ToTable("tb_dom_fee_type");

                entity.Property(e => e.FtId)
                    .HasColumnName("ft_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FtDesc)
                    .HasColumnName("ft_desc")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbDomFileType>(entity =>
            {
                entity.HasKey(e => e.FiletypeId);

                entity.ToTable("tb_dom_file_type");

                entity.Property(e => e.FiletypeId).HasColumnName("filetype_id");

                entity.Property(e => e.FiletypeDesc)
                    .IsRequired()
                    .HasColumnName("filetype_desc");

                entity.Property(e => e.FiletypeEntity).HasColumnName("filetype_entity");

                entity.HasOne(d => d.FiletypeEntityNavigation)
                    .WithMany(p => p.TbDomFileType)
                    .HasForeignKey(d => d.FiletypeEntity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_dom_file_type_tb_dom_entity");
            });

            modelBuilder.Entity<TbDomGlobalExposure>(entity =>
            {
                entity.HasKey(e => e.GeId);

                entity.ToTable("tb_dom_globalExposure");

                entity.Property(e => e.GeId)
                    .HasColumnName("ge_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GeDesc)
                    .HasColumnName("ge_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomInvestorType>(entity =>
            {
                entity.HasKey(e => e.ItId);

                entity.ToTable("tb_dom_investor_type");

                entity.Property(e => e.ItId)
                    .HasColumnName("it_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItDesc)
                    .HasColumnName("it_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomIsoCountry>(entity =>
            {
                entity.HasKey(e => e.IsoCountryIso2);

                entity.ToTable("tb_dom_iso_country");

                entity.Property(e => e.IsoCountryIso2)
                    .HasColumnName("iso_country_iso_2")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.IsoCountry3)
                    .HasColumnName("iso_country_3")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.IsoCountryDesc)
                    .HasColumnName("iso_country_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomIsoCurrency>(entity =>
            {
                entity.HasKey(e => e.IsoCcyCode);

                entity.ToTable("tb_dom_iso_currency");

                entity.Property(e => e.IsoCcyCode)
                    .HasColumnName("iso_ccy_code")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.IsoCcyDesc)
                    .HasColumnName("iso_ccy_desc")
                    .HasMaxLength(100);

                entity.Property(e => e.IsoCcyDescEntity)
                    .HasColumnName("iso_ccy_desc_entity")
                    .HasMaxLength(100);

                entity.Property(e => e.IsoCcyNumeric).HasColumnName("iso_ccy_numeric");
            });

            modelBuilder.Entity<TbDomLanguages>(entity =>
            {
                entity.HasKey(e => e.LanguageIso3);

                entity.ToTable("tb_dom_languages");

                entity.Property(e => e.LanguageIso3)
                    .HasColumnName("language_iso_3")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.LanguageDesc)
                    .HasColumnName("language_desc")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbDomLegalForm>(entity =>
            {
                entity.HasKey(e => e.LfId);

                entity.ToTable("tb_dom_legal_form");

                entity.Property(e => e.LfId)
                    .HasColumnName("lf_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LfAcronym)
                    .IsRequired()
                    .HasColumnName("lf_acronym")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbDomLegalType>(entity =>
            {
                entity.HasKey(e => e.LtId);

                entity.ToTable("tb_dom_legal_type");

                entity.Property(e => e.LtId)
                    .HasColumnName("lt_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LtAcronym)
                    .IsRequired()
                    .HasColumnName("lt_acronym")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbDomLegalVehicle>(entity =>
            {
                entity.HasKey(e => e.LvId);

                entity.ToTable("tb_dom_legal_vehicle");

                entity.Property(e => e.LvId)
                    .HasColumnName("lv_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LvAcronym)
                    .IsRequired()
                    .HasColumnName("lv_acronym")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LvFkLegalType).HasColumnName("lv_fk_legal_type");

                entity.HasOne(d => d.LvFkLegalTypeNavigation)
                    .WithMany(p => p.TbDomLegalVehicle)
                    .HasForeignKey(d => d.LvFkLegalType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_dom_legal_vehicle_tb_dom_legal_type");
            });

            modelBuilder.Entity<TbDomNavFrequency>(entity =>
            {
                entity.HasKey(e => e.NfId);

                entity.ToTable("tb_dom_navFrequency");

                entity.Property(e => e.NfId)
                    .HasColumnName("nf_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NfDesc)
                    .HasColumnName("nf_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomPrincipalInvestmentStrategy>(entity =>
            {
                entity.HasKey(e => e.PisId);

                entity.ToTable("tb_dom_principal_investment_strategy");

                entity.Property(e => e.PisId)
                    .HasColumnName("pis_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PisDesc)
                    .HasColumnName("pis_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomSfCatBloomberg>(entity =>
            {
                entity.HasKey(e => e.CatBloombergId);

                entity.ToTable("tb_dom_sf_cat_bloomberg");

                entity.Property(e => e.CatBloombergId)
                    .HasColumnName("cat_bloomberg_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CatBloombergDesc)
                    .HasColumnName("cat_bloomberg_Desc")
                    .HasMaxLength(100);

                entity.Property(e => e.CatBloombergDescExpl).HasColumnName("cat_bloomberg_Desc_expl");
            });

            modelBuilder.Entity<TbDomSfCatMorningstar>(entity =>
            {
                entity.HasKey(e => e.CMorningstarId);

                entity.ToTable("tb_dom_sf_cat_morningstar");

                entity.Property(e => e.CMorningstarId)
                    .HasColumnName("c_morningstar_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CMorningstarDesc)
                    .HasColumnName("c_morningstar_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomSfCatSix>(entity =>
            {
                entity.HasKey(e => e.CatSixId);

                entity.ToTable("tb_dom_sf_cat_six");

                entity.Property(e => e.CatSixId)
                    .HasColumnName("cat_six_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CatSixDesc)
                    .HasColumnName("cat_six_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomSfStatus>(entity =>
            {
                entity.HasKey(e => e.StId);

                entity.ToTable("tb_dom_sf_status");

                entity.Property(e => e.StId)
                    .HasColumnName("st_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.StDesc)
                    .IsRequired()
                    .HasColumnName("st_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomShareStatus>(entity =>
            {
                entity.HasKey(e => e.ScSId);

                entity.ToTable("tb_dom_share_status");

                entity.Property(e => e.ScSId)
                    .HasColumnName("sc_s_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ScSDesc)
                    .HasColumnName("sc_s_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomShareType>(entity =>
            {
                entity.HasKey(e => e.StId);

                entity.ToTable("tb_dom_share_type");

                entity.Property(e => e.StId)
                    .HasColumnName("st_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.StDesc)
                    .HasColumnName("st_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomTimeseriesProvider>(entity =>
            {
                entity.HasKey(e => e.IdProvider)
                    .HasName("PK_tb_dom_ts_provider");

                entity.ToTable("tb_dom_timeseries_provider");

                entity.HasComment("List of providers for timeseries");

                entity.Property(e => e.IdProvider).HasColumnName("id_provider");

                entity.Property(e => e.DescProvider)
                    .IsRequired()
                    .HasColumnName("desc_provider");
            });

            modelBuilder.Entity<TbDomTimeseriesType>(entity =>
            {
                entity.HasKey(e => e.IdTs);

                entity.ToTable("tb_dom_timeseries_type");

                entity.Property(e => e.IdTs).HasColumnName("id_ts");

                entity.Property(e => e.DescTs)
                    .IsRequired()
                    .HasColumnName("desc_ts");

                entity.Property(e => e.EntityType).HasColumnName("entity_type");

                entity.HasOne(d => d.EntityTypeNavigation)
                    .WithMany(p => p.TbDomTimeseriesType)
                    .HasForeignKey(d => d.EntityType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_dom_timeseries_type_tb_dom_entity");
            });

            modelBuilder.Entity<TbDomTypeOfMarket>(entity =>
            {
                entity.HasKey(e => e.TomId);

                entity.ToTable("tb_dom_type_of_market");

                entity.Property(e => e.TomId)
                    .HasColumnName("tom_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TomDesc)
                    .HasColumnName("tom_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomValutationDate>(entity =>
            {
                entity.HasKey(e => e.VdId);

                entity.ToTable("tb_dom_valutationDate");

                entity.Property(e => e.VdId)
                    .HasColumnName("vd_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.VdDesc)
                    .HasColumnName("vd_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbFile>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__tb_file");

                entity.ToTable("tb_file");

                entity.Property(e => e.FileId)
                    .HasColumnName("file_id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TbFund>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK_tb_fund_1");

                entity.ToTable("tb_fund");

                entity.Property(e => e.FId)
                    .HasColumnName("f_id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TbFundSubFund>(entity =>
            {
                entity.HasKey(e => new { e.SfId, e.FsfStartConnection });

                entity.ToTable("tb_fundSubFund");

                entity.Property(e => e.SfId).HasColumnName("sf_id");

                entity.Property(e => e.FsfStartConnection)
                    .HasColumnName("fsf_startConnection")
                    .HasColumnType("datetime");

                entity.Property(e => e.FId).HasColumnName("f_id");

                entity.Property(e => e.FsfEndConnection)
                    .HasColumnName("fsf_endConnection")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.F)
                    .WithMany(p => p.TbFundSubFund)
                    .HasForeignKey(d => d.FId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_fundSubFund_tb_fund");

                entity.HasOne(d => d.Sf)
                    .WithMany(p => p.TbFundSubFund)
                    .HasForeignKey(d => d.SfId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_fundSubFund_tb_subFund");
            });

            modelBuilder.Entity<TbHistoryFund>(entity =>
            {
                entity.HasKey(e => new { e.FId, e.FInitialDate })
                    .HasName("PK_tb_fund");

                entity.ToTable("tb_historyFund");

                entity.Property(e => e.FId).HasColumnName("f_id");

                entity.Property(e => e.FInitialDate)
                    .HasColumnName("f_initial_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FChangeComment).HasColumnName("f_change_comment");

                entity.Property(e => e.FCommentTitle)
                    .HasColumnName("f_comment_title")
                    .HasMaxLength(50);

                entity.Property(e => e.FCompanyType).HasColumnName("f_company_type");

                entity.Property(e => e.FCssfCode)
                    .HasColumnName("f_cssf_code")
                    .HasMaxLength(100);

                entity.Property(e => e.FDepCode)
                    .HasColumnName("f_dep_code")
                    .HasMaxLength(100);

                entity.Property(e => e.FEndDate)
                    .HasColumnName("f_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FFaCode)
                    .HasColumnName("f_fa_code")
                    .HasMaxLength(100);

                entity.Property(e => e.FLegalForm).HasColumnName("f_legal_form");

                entity.Property(e => e.FLegalType).HasColumnName("f_legal_type");

                entity.Property(e => e.FLegalVehicle).HasColumnName("f_legal_vehicle");

                entity.Property(e => e.FLeiCode)
                    .HasColumnName("f_lei_code")
                    .HasMaxLength(100);

                entity.Property(e => e.FOfficialFundName)
                    .HasColumnName("f_official_fund_name")
                    .HasMaxLength(100);

                entity.Property(e => e.FRegistrationNumber)
                    .HasColumnName("f_registration_number")
                    .HasMaxLength(100);

                entity.Property(e => e.FShortFundName)
                    .HasColumnName("f_short_fund_name")
                    .HasMaxLength(100);

                entity.Property(e => e.FStatus).HasColumnName("f_status");

                entity.Property(e => e.FTaCode)
                    .HasColumnName("f_ta_code")
                    .HasMaxLength(100);

                entity.Property(e => e.FTinNumber)
                    .HasColumnName("f_tin_number")
                    .HasMaxLength(100);

                entity.HasOne(d => d.FCompanyTypeNavigation)
                    .WithMany(p => p.TbHistoryFund)
                    .HasForeignKey(d => d.FCompanyType)
                    .HasConstraintName("FK_tb_historyFund_tb_dom_companyType");

                entity.HasOne(d => d.F)
                    .WithMany(p => p.TbHistoryFund)
                    .HasForeignKey(d => d.FId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_historyFund_tb_fund");

                entity.HasOne(d => d.FLegalFormNavigation)
                    .WithMany(p => p.TbHistoryFund)
                    .HasForeignKey(d => d.FLegalForm)
                    .HasConstraintName("FK_tb_historyFund_tb_dom_legal_form");

                entity.HasOne(d => d.FLegalVehicleNavigation)
                    .WithMany(p => p.TbHistoryFund)
                    .HasForeignKey(d => d.FLegalVehicle)
                    .HasConstraintName("FK_tb_historyFund_tb_dom_legal_vehicle");

                entity.HasOne(d => d.FStatusNavigation)
                    .WithMany(p => p.TbHistoryFund)
                    .HasForeignKey(d => d.FStatus)
                    .HasConstraintName("FK_tb_historyFund_tb_dom_f_status");
            });

            modelBuilder.Entity<TbHistoryShareClass>(entity =>
            {
                entity.HasKey(e => new { e.ScId, e.ScInitialDate });

                entity.ToTable("tb_historyShareClass");

                entity.Property(e => e.ScId).HasColumnName("sc_id");

                entity.Property(e => e.ScInitialDate)
                    .HasColumnName("sc_initialDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScAccountingCode)
                    .HasColumnName("sc_accountingCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScBloombedCode)
                    .HasColumnName("sc_bloombedCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScBloombedId)
                    .HasColumnName("sc_bloombedId")
                    .HasMaxLength(100);

                entity.Property(e => e.ScBloomberMarket)
                    .HasColumnName("sc_bloomberMarket")
                    .HasMaxLength(100);

                entity.Property(e => e.ScChangeComment).HasColumnName("sc_change_comment");

                entity.Property(e => e.ScCommentTitle)
                    .HasColumnName("sc_comment_title")
                    .HasMaxLength(50);

                entity.Property(e => e.ScCountryIssue)
                    .HasColumnName("sc_countryIssue")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ScCurrency)
                    .HasColumnName("sc_currency")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.ScDateBusinessYear)
                    .HasColumnName("sc_date_business_year")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScEmissionDate)
                    .HasColumnName("sc_emissionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScEndDate)
                    .HasColumnName("sc_endDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScExpiryDate)
                    .HasColumnName("sc_expiryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScFaCode)
                    .HasColumnName("sc_faCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScHedged).HasColumnName("sc_hedged");

                entity.Property(e => e.ScInceptionDate)
                    .HasColumnName("sc_inceptionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScInitialPrice).HasColumnName("sc_initialPrice");

                entity.Property(e => e.ScInvestorType).HasColumnName("sc_investorType");

                entity.Property(e => e.ScIsinCode)
                    .HasColumnName("sc_isinCode")
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.ScLastNav)
                    .HasColumnName("sc_lastNav")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScListed).HasColumnName("sc_listed");

                entity.Property(e => e.ScOfficialShareClassName)
                    .HasColumnName("sc_officialShareClassName")
                    .HasMaxLength(100);

                entity.Property(e => e.ScProspectusCode)
                    .HasColumnName("sc_prospectus_code")
                    .HasMaxLength(100);

                entity.Property(e => e.ScShareType).HasColumnName("sc_shareType");

                entity.Property(e => e.ScShortShareClassName)
                    .HasColumnName("sc_shortShareClassName")
                    .HasMaxLength(100);

                entity.Property(e => e.ScStatus).HasColumnName("sc_status");

                entity.Property(e => e.ScTaCode)
                    .HasColumnName("sc_taCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScUltimateParentCountryRisk)
                    .HasColumnName("sc_ultimateParentCountryRisk")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ScValorCode)
                    .HasColumnName("sc_valorCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScWkn)
                    .HasColumnName("sc_WKN")
                    .HasMaxLength(100);

                entity.HasOne(d => d.ScCountryIssueNavigation)
                    .WithMany(p => p.TbHistoryShareClass)
                    .HasForeignKey(d => d.ScCountryIssue)
                    .HasConstraintName("FK_tb_historyShareClass_tb_dom_iso_country");

                entity.HasOne(d => d.ScCurrencyNavigation)
                    .WithMany(p => p.TbHistoryShareClass)
                    .HasForeignKey(d => d.ScCurrency)
                    .HasConstraintName("FK_tb_historyShareClass_tb_dom_iso_currency");

                entity.HasOne(d => d.Sc)
                    .WithMany(p => p.TbHistoryShareClass)
                    .HasForeignKey(d => d.ScId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_historyShareClass_tb_shareClass");

                entity.HasOne(d => d.ScInvestorTypeNavigation)
                    .WithMany(p => p.TbHistoryShareClass)
                    .HasForeignKey(d => d.ScInvestorType)
                    .HasConstraintName("FK_tb_historyShareClass_tb_dom_investor_type");

                entity.HasOne(d => d.ScShareTypeNavigation)
                    .WithMany(p => p.TbHistoryShareClass)
                    .HasForeignKey(d => d.ScShareType)
                    .HasConstraintName("FK_tb_historyShareClass_tb_dom_share_type");

                entity.HasOne(d => d.ScStatusNavigation)
                    .WithMany(p => p.TbHistoryShareClass)
                    .HasForeignKey(d => d.ScStatus)
                    .HasConstraintName("FK_tb_historyShareClass_tb_dom_share_status");
            });

            modelBuilder.Entity<TbHistoryShareClassCopy>(entity =>
            {
                entity.HasKey(e => new { e.ScId, e.ScInitialDate });

                entity.ToTable("tb_historyShareClassCopy");

                entity.Property(e => e.ScId).HasColumnName("sc_id");

                entity.Property(e => e.ScInitialDate)
                    .HasColumnName("sc_initialDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScAccountingCode)
                    .HasColumnName("sc_accountingCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScBloombedCode)
                    .HasColumnName("sc_bloombedCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScBloombedId)
                    .HasColumnName("sc_bloombedId")
                    .HasMaxLength(100);

                entity.Property(e => e.ScBloomberMarket)
                    .HasColumnName("sc_bloomberMarket")
                    .HasMaxLength(100);

                entity.Property(e => e.ScChangeComment).HasColumnName("sc_change_comment");

                entity.Property(e => e.ScCommentTitle)
                    .HasColumnName("sc_comment_title")
                    .HasMaxLength(50);

                entity.Property(e => e.ScCountryIssue)
                    .HasColumnName("sc_countryIssue")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ScCurrency)
                    .HasColumnName("sc_currency")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.ScDateBusinessYear)
                    .HasColumnName("sc_date_business_year")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScEmissionDate)
                    .HasColumnName("sc_emissionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScEndDate)
                    .HasColumnName("sc_endDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScExpiryDate)
                    .HasColumnName("sc_expiryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScFaCode)
                    .HasColumnName("sc_faCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScHedged).HasColumnName("sc_hedged");

                entity.Property(e => e.ScInceptionDate)
                    .HasColumnName("sc_inceptionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScInitialPrice).HasColumnName("sc_initialPrice");

                entity.Property(e => e.ScInvestorType).HasColumnName("sc_investorType");

                entity.Property(e => e.ScIsinCode)
                    .HasColumnName("sc_isinCode")
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.ScLastNav)
                    .HasColumnName("sc_lastNav")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScListed).HasColumnName("sc_listed");

                entity.Property(e => e.ScOfficialShareClassName)
                    .HasColumnName("sc_officialShareClassName")
                    .HasMaxLength(100);

                entity.Property(e => e.ScProspectusCode)
                    .HasColumnName("sc_prospectus_code")
                    .HasMaxLength(100);

                entity.Property(e => e.ScShareType).HasColumnName("sc_shareType");

                entity.Property(e => e.ScShortShareClassName)
                    .HasColumnName("sc_shortShareClassName")
                    .HasMaxLength(100);

                entity.Property(e => e.ScStatus).HasColumnName("sc_status");

                entity.Property(e => e.ScTaCode)
                    .HasColumnName("sc_taCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScUltimateParentCountryRisk)
                    .HasColumnName("sc_ultimateParentCountryRisk")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ScValorCode)
                    .HasColumnName("sc_valorCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScWkn)
                    .HasColumnName("sc_WKN")
                    .HasMaxLength(100);

                entity.HasOne(d => d.ScCountryIssueNavigation)
                    .WithMany(p => p.TbHistoryShareClassCopy)
                    .HasForeignKey(d => d.ScCountryIssue)
                    .HasConstraintName("FK_tb_historyShareClassCopy_tb_dom_iso_country");

                entity.HasOne(d => d.ScCurrencyNavigation)
                    .WithMany(p => p.TbHistoryShareClassCopy)
                    .HasForeignKey(d => d.ScCurrency)
                    .HasConstraintName("FK_tb_historyShareClassCopy_tb_dom_iso_currency");

                entity.HasOne(d => d.Sc)
                    .WithMany(p => p.TbHistoryShareClassCopy)
                    .HasForeignKey(d => d.ScId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_historyShareClassCopy_tb_shareClass");

                entity.HasOne(d => d.ScInvestorTypeNavigation)
                    .WithMany(p => p.TbHistoryShareClassCopy)
                    .HasForeignKey(d => d.ScInvestorType)
                    .HasConstraintName("FK_tb_historyShareClassCopy_tb_dom_investor_type");

                entity.HasOne(d => d.ScShareTypeNavigation)
                    .WithMany(p => p.TbHistoryShareClassCopy)
                    .HasForeignKey(d => d.ScShareType)
                    .HasConstraintName("FK_tb_historyShareClassCopy_tb_dom_share_type");

                entity.HasOne(d => d.ScStatusNavigation)
                    .WithMany(p => p.TbHistoryShareClassCopy)
                    .HasForeignKey(d => d.ScStatus)
                    .HasConstraintName("FK_tb_historyShareClassCopy_tb_dom_share_status");
            });

            modelBuilder.Entity<TbHistorySubFund>(entity =>
            {
                entity.HasKey(e => new { e.SfId, e.SfInitialDate });

                entity.ToTable("tb_historySubFund");

                entity.Property(e => e.SfId).HasColumnName("sf_id");

                entity.Property(e => e.SfInitialDate)
                    .HasColumnName("sf_initialDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SfCalculationDate).HasColumnName("sf_calculationDate");

                entity.Property(e => e.SfCatMorningstar).HasColumnName("sf_cat_morningstar");

                entity.Property(e => e.SfCategoryBloomberg).HasColumnName("sf_category_bloomberg");

                entity.Property(e => e.SfCategorySix).HasColumnName("sf_category_six");

                entity.Property(e => e.SfCesrClass).HasColumnName("sf_cesrClass");

                entity.Property(e => e.SfChangeComment).HasColumnName("sf_change_comment");

                entity.Property(e => e.SfClearingCode)
                    .HasColumnName("sf_clearing_code")
                    .HasMaxLength(100);

                entity.Property(e => e.SfCommentTitle)
                    .HasColumnName("sf_comment_title")
                    .HasMaxLength(50);

                entity.Property(e => e.SfCssfAuthDate)
                    .HasColumnName("sf_cssfAuthDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SfCssfCode)
                    .HasColumnName("sf_cssfCode")
                    .HasMaxLength(100);

                entity.Property(e => e.SfCssfGeographicalFocus).HasColumnName("sf_cssf_geographical_focus");

                entity.Property(e => e.SfCurrency)
                    .HasColumnName("sf_currency")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.SfDepCode)
                    .HasColumnName("sf_depCode")
                    .HasMaxLength(100);

                entity.Property(e => e.SfDerivMarket).HasColumnName("sf_derivMarket");

                entity.Property(e => e.SfDerivPurpose).HasColumnName("sf_derivPurpose");

                entity.Property(e => e.SfDerivatives).HasColumnName("sf_derivatives");

                entity.Property(e => e.SfEndDate)
                    .HasColumnName("sf_endDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SfExpDate)
                    .HasColumnName("sf_expDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SfFaCode)
                    .HasColumnName("sf_faCode")
                    .HasMaxLength(100);

                entity.Property(e => e.SfFirstNavDate)
                    .HasColumnName("sf_firstNavDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SfGlobalExposure).HasColumnName("sf_globalExposure");

                entity.Property(e => e.SfLastNavDate)
                    .HasColumnName("sf_lastNavDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SfLastProspectus)
                    .HasColumnName("sf_lastProspectus")
                    .HasColumnType("datetime");

                entity.Property(e => e.SfLastProspectusDate)
                    .HasColumnName("sf_lastProspectusDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SfLeiCode)
                    .HasColumnName("sf_leiCode")
                    .HasMaxLength(100);

                entity.Property(e => e.SfNavFrequency).HasColumnName("sf_navFrequency");

                entity.Property(e => e.SfOfficialSubFundName)
                    .HasColumnName("sf_officialSubFundName")
                    .HasMaxLength(100);

                entity.Property(e => e.SfPrincipalAssetClass).HasColumnName("sf_principal_asset_class");

                entity.Property(e => e.SfPrincipalInvestmentStrategy).HasColumnName("sf_principal_investment_strategy");

                entity.Property(e => e.SfShortSubFundName)
                    .HasColumnName("sf_shortSubFundName")
                    .HasMaxLength(100);

                entity.Property(e => e.SfStatus).HasColumnName("sf_status");

                entity.Property(e => e.SfTaCode)
                    .HasColumnName("sf_taCode")
                    .HasMaxLength(100);

                entity.Property(e => e.SfTypeOfMarket).HasColumnName("sf_type_of_market");

                entity.Property(e => e.SfValutationDate).HasColumnName("sf_valutationDate");

                entity.HasOne(d => d.SfCalculationDateNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfCalculationDate)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_calculationDate");

                entity.HasOne(d => d.SfCatMorningstarNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfCatMorningstar)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_sf_cat_morningstar");

                entity.HasOne(d => d.SfCategoryBloombergNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfCategoryBloomberg)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_sf_cat_bloomberg");

                entity.HasOne(d => d.SfCategorySixNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfCategorySix)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_sf_cat_six");

                entity.HasOne(d => d.SfCesrClassNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfCesrClass)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_cesrClass");

                entity.HasOne(d => d.SfCssfGeographicalFocusNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfCssfGeographicalFocus)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_cssf_geographical_focus");

                entity.HasOne(d => d.SfCurrencyNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfCurrency)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_iso_currency");

                entity.HasOne(d => d.SfDerivMarketNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfDerivMarket)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_derivMarket");

                entity.HasOne(d => d.SfDerivPurposeNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfDerivPurpose)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_derivPurpose");

                entity.HasOne(d => d.SfGlobalExposureNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfGlobalExposure)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_globalExposure");

                entity.HasOne(d => d.Sf)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_historySubFund_tb_subFund1");

                entity.HasOne(d => d.SfNavFrequencyNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfNavFrequency)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_navFrequency");

                entity.HasOne(d => d.SfPrincipalAssetClassNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfPrincipalAssetClass)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_cssf_principal_asset_class");

                entity.HasOne(d => d.SfPrincipalInvestmentStrategyNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfPrincipalInvestmentStrategy)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_principal_investment_strategy");

                entity.HasOne(d => d.SfStatusNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfStatus)
                    .HasConstraintName("FK_tb_historySubFund_tb_subFund");

                entity.HasOne(d => d.SfTypeOfMarketNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfTypeOfMarket)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_type_of_market");

                entity.HasOne(d => d.SfValutationDateNavigation)
                    .WithMany(p => p.TbHistorySubFund)
                    .HasForeignKey(d => d.SfValutationDate)
                    .HasConstraintName("FK_tb_historySubFund_tb_dom_valutationDate");
            });

            modelBuilder.Entity<TbMapFilefund>(entity =>
            {
                entity.HasKey(e => new { e.FileId, e.DocStartConnection })
                    .HasName("PK__tb_map_filefund");

                entity.ToTable("tb_map_filefund");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.DocStartConnection)
                    .HasColumnName("doc_startConnection")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocEndConnection)
                    .HasColumnName("doc_endConnection")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocFiletype).HasColumnName("doc_filetype");

                entity.Property(e => e.DocFundId).HasColumnName("doc_fundId");

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasColumnName("file_extension")
                    .HasMaxLength(5);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name");

                entity.HasOne(d => d.DocFiletypeNavigation)
                    .WithMany(p => p.TbMapFilefund)
                    .HasForeignKey(d => d.DocFiletype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_map_filefund_tb_dom_file_type");

                entity.HasOne(d => d.DocFund)
                    .WithMany(p => p.TbMapFilefund)
                    .HasForeignKey(d => d.DocFundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_map_filefund_tb_fund");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.TbMapFilefund)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_map_filefund_tb_file");
            });

            modelBuilder.Entity<TbMapFileshareclass>(entity =>
            {
                entity.HasKey(e => new { e.FileId, e.DocStartConnection })
                    .HasName("PK__tb_map_fileshareclass");

                entity.ToTable("tb_map_fileshareclass");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.DocStartConnection)
                    .HasColumnName("doc_startConnection")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocEndConnection)
                    .HasColumnName("doc_endConnection")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocFiletype).HasColumnName("doc_filetype");

                entity.Property(e => e.DocShareClassId).HasColumnName("doc_shareClassId");

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasColumnName("file_extension")
                    .HasMaxLength(5);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name");

                entity.HasOne(d => d.DocFiletypeNavigation)
                    .WithMany(p => p.TbMapFileshareclass)
                    .HasForeignKey(d => d.DocFiletype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_map_fileshareclass_tb_dom_file_type");

                entity.HasOne(d => d.DocShareClass)
                    .WithMany(p => p.TbMapFileshareclass)
                    .HasForeignKey(d => d.DocShareClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_map_fileshareclass_tb_shareClass");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.TbMapFileshareclass)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_map_fileshareclass_tb_file");
            });

            modelBuilder.Entity<TbMapFilesubfund>(entity =>
            {
                entity.HasKey(e => new { e.FileId, e.DocStartConnection })
                    .HasName("PK__tb_map_filesubfund");

                entity.ToTable("tb_map_filesubfund");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.DocStartConnection)
                    .HasColumnName("doc_startConnection")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocEndConnection)
                    .HasColumnName("doc_endConnection")
                    .HasColumnType("datetime");

                entity.Property(e => e.DocFiletype).HasColumnName("doc_filetype");

                entity.Property(e => e.DocSubfundId).HasColumnName("doc_subfundId");

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasColumnName("file_extension")
                    .HasMaxLength(5);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name");

                entity.HasOne(d => d.DocFiletypeNavigation)
                    .WithMany(p => p.TbMapFilesubfund)
                    .HasForeignKey(d => d.DocFiletype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_map_filesubfund_tb_dom_file_type");

                entity.HasOne(d => d.DocSubfund)
                    .WithMany(p => p.TbMapFilesubfund)
                    .HasForeignKey(d => d.DocSubfundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_map_filesubfund_tb_subFund");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.TbMapFilesubfund)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_map_filesubfund_tb_file");
            });

            modelBuilder.Entity<TbMapNavFrequencyValuation>(entity =>
            {
                entity.HasKey(e => new { e.IdDomFreq, e.IdDomValDate });

                entity.ToTable("tb_map_nav_frequency_valuation");

                entity.Property(e => e.IdDomFreq).HasColumnName("id_dom_freq");

                entity.Property(e => e.IdDomValDate).HasColumnName("id_dom_val_date");

                entity.HasOne(d => d.IdDomFreqNavigation)
                    .WithMany(p => p.TbMapNavFrequencyValuation)
                    .HasForeignKey(d => d.IdDomFreq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_map_nav_frequency_valuation_tb_dom_navFrequency");

                entity.HasOne(d => d.IdDomValDateNavigation)
                    .WithMany(p => p.TbMapNavFrequencyValuation)
                    .HasForeignKey(d => d.IdDomValDate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_map_nav_frequency_valuation_tb_dom_valutationDate");
            });

            modelBuilder.Entity<TbPrimeShareClass>(entity =>
            {
                entity.HasKey(e => new { e.ScId, e.ScInitialDate });

                entity.ToTable("tb_primeShareClass");

                entity.HasIndex(e => e.ScId)
                    .HasDatabaseName("uidx_sc_id")
                    .IsUnique();

                entity.Property(e => e.ScId).HasColumnName("sc_id");

                entity.Property(e => e.ScInitialDate)
                    .HasColumnName("sc_initialDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScAccountingCode)
                    .HasColumnName("sc_accountingCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScBloombedCode)
                    .HasColumnName("sc_bloombedCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScBloombedId)
                    .HasColumnName("sc_bloombedId")
                    .HasMaxLength(100);

                entity.Property(e => e.ScBloomberMarket)
                    .HasColumnName("sc_bloomberMarket")
                    .HasMaxLength(100);

                entity.Property(e => e.ScChangeComment).HasColumnName("sc_change_comment");

                entity.Property(e => e.ScCommentTitle)
                    .HasColumnName("sc_comment_title")
                    .HasMaxLength(50);

                entity.Property(e => e.ScCountryIssue)
                    .HasColumnName("sc_countryIssue")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ScCurrency)
                    .HasColumnName("sc_currency")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.ScDateBusinessYear)
                    .HasColumnName("sc_date_business_year")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScEmissionDate)
                    .HasColumnName("sc_emissionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScEndDate)
                    .HasColumnName("sc_endDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScExpiryDate)
                    .HasColumnName("sc_expiryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScFaCode)
                    .HasColumnName("sc_faCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScHedged).HasColumnName("sc_hedged");

                entity.Property(e => e.ScInceptionDate)
                    .HasColumnName("sc_inceptionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScInitialPrice).HasColumnName("sc_initialPrice");

                entity.Property(e => e.ScInvestorType).HasColumnName("sc_investorType");

                entity.Property(e => e.ScIsinCode)
                    .HasColumnName("sc_isinCode")
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.ScLastNav)
                    .HasColumnName("sc_lastNav")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScListed).HasColumnName("sc_listed");

                entity.Property(e => e.ScOfficialShareClassName)
                    .HasColumnName("sc_officialShareClassName")
                    .HasMaxLength(100);

                entity.Property(e => e.ScProspectusCode)
                    .HasColumnName("sc_prospectus_code")
                    .HasMaxLength(100);

                entity.Property(e => e.ScShareType).HasColumnName("sc_shareType");

                entity.Property(e => e.ScShortShareClassName)
                    .HasColumnName("sc_shortShareClassName")
                    .HasMaxLength(100);

                entity.Property(e => e.ScStatus).HasColumnName("sc_status");

                entity.Property(e => e.ScTaCode)
                    .HasColumnName("sc_taCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScUltimateParentCountryRisk)
                    .HasColumnName("sc_ultimateParentCountryRisk")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.ScValorCode)
                    .HasColumnName("sc_valorCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScWkn)
                    .HasColumnName("sc_WKN")
                    .HasMaxLength(100);

                entity.HasOne(d => d.ScCountryIssueNavigation)
                    .WithMany(p => p.TbPrimeShareClass)
                    .HasForeignKey(d => d.ScCountryIssue)
                    .HasConstraintName("FK_tb_primeShareClass_tb_dom_iso_country");

                entity.HasOne(d => d.ScCurrencyNavigation)
                    .WithMany(p => p.TbPrimeShareClass)
                    .HasForeignKey(d => d.ScCurrency)
                    .HasConstraintName("FK_tb_primeShareClass_tb_dom_iso_currency");

                entity.HasOne(d => d.Sc)
                    .WithOne(p => p.TbPrimeShareClass)
                    .HasForeignKey<TbPrimeShareClass>(d => d.ScId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_primeShareClass_tb_shareClass");

                entity.HasOne(d => d.ScInvestorTypeNavigation)
                    .WithMany(p => p.TbPrimeShareClass)
                    .HasForeignKey(d => d.ScInvestorType)
                    .HasConstraintName("FK_tb_primeShareClass_tb_dom_investor_type");

                entity.HasOne(d => d.ScShareTypeNavigation)
                    .WithMany(p => p.TbPrimeShareClass)
                    .HasForeignKey(d => d.ScShareType)
                    .HasConstraintName("FK_tb_primeShareClass_tb_dom_share_type");

                entity.HasOne(d => d.ScStatusNavigation)
                    .WithMany(p => p.TbPrimeShareClass)
                    .HasForeignKey(d => d.ScStatus)
                    .HasConstraintName("FK_tb_primeShareClass_tb_dom_share_status");
            });

            modelBuilder.Entity<TbServiceAgreementFund>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__tb_serviceAgreement_fund");

                entity.ToTable("tb_serviceAgreement_fund");

                entity.Property(e => e.FileId)
                    .HasColumnName("file_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasColumnName("file_extension")
                    .HasMaxLength(5);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name");

                entity.Property(e => e.SaActivationDate)
                    .HasColumnName("sa_activationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaActivityType).HasColumnName("sa_activityType");

                entity.Property(e => e.SaCompany).HasColumnName("sa_company");

                entity.Property(e => e.SaContractDate)
                    .HasColumnName("sa_contractDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaExpirationDate)
                    .HasColumnName("sa_expirationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaFundId).HasColumnName("sa_fundId");

                entity.Property(e => e.SaStatus).HasColumnName("sa_status");

                entity.HasOne(d => d.File)
                    .WithOne(p => p.TbServiceAgreementFund)
                    .HasForeignKey<TbServiceAgreementFund>(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_fund_tb_file");

                entity.HasOne(d => d.SaActivityTypeNavigation)
                    .WithMany(p => p.TbServiceAgreementFund)
                    .HasForeignKey(d => d.SaActivityType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_fund_tb_dom_activityType");

                entity.HasOne(d => d.SaCompanyNavigation)
                    .WithMany(p => p.TbServiceAgreementFund)
                    .HasForeignKey(d => d.SaCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_fund_tb_companies");

                entity.HasOne(d => d.SaFund)
                    .WithMany(p => p.TbServiceAgreementFund)
                    .HasForeignKey(d => d.SaFundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_fund_tb_fund");

                entity.HasOne(d => d.SaStatusNavigation)
                    .WithMany(p => p.TbServiceAgreementFund)
                    .HasForeignKey(d => d.SaStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName(" FK_tb_serviceAgreement_fund_tb_dom_agreement_status");
            });

            modelBuilder.Entity<TbServiceAgreementShareclass>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__tb_serviceAgreement_shareclass");

                entity.ToTable("tb_serviceAgreement_shareclass");

                entity.Property(e => e.FileId)
                    .HasColumnName("file_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasColumnName("file_extension")
                    .HasMaxLength(5);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name");

                entity.Property(e => e.SaActivationDate)
                    .HasColumnName("sa_activationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaActivityType).HasColumnName("sa_activityType");

                entity.Property(e => e.SaCompany).HasColumnName("sa_company");

                entity.Property(e => e.SaContractDate)
                    .HasColumnName("sa_contractDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaExpirationDate)
                    .HasColumnName("sa_expirationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaShareclassId).HasColumnName("sa_shareclassId");

                entity.Property(e => e.SaStatus).HasColumnName("sa_status");

                entity.HasOne(d => d.File)
                    .WithOne(p => p.TbServiceAgreementShareclass)
                    .HasForeignKey<TbServiceAgreementShareclass>(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_shareclass_tb_file");

                entity.HasOne(d => d.SaActivityTypeNavigation)
                    .WithMany(p => p.TbServiceAgreementShareclass)
                    .HasForeignKey(d => d.SaActivityType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_shareclass_tb_dom_activityType");

                entity.HasOne(d => d.SaCompanyNavigation)
                    .WithMany(p => p.TbServiceAgreementShareclass)
                    .HasForeignKey(d => d.SaCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_shareclass_tb_companies");

                entity.HasOne(d => d.SaShareclass)
                    .WithMany(p => p.TbServiceAgreementShareclass)
                    .HasForeignKey(d => d.SaShareclassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_shareclass_tb_shareClass");

                entity.HasOne(d => d.SaStatusNavigation)
                    .WithMany(p => p.TbServiceAgreementShareclass)
                    .HasForeignKey(d => d.SaStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_shareclass_tb_dom_agreement_status");
            });

            modelBuilder.Entity<TbServiceAgreementSubfund>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__tb_serviceAgreement_subfund");

                entity.ToTable("tb_serviceAgreement_subfund");

                entity.Property(e => e.FileId)
                    .HasColumnName("file_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasColumnName("file_extension")
                    .HasMaxLength(5);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name");

                entity.Property(e => e.SaActivationDate)
                    .HasColumnName("sa_activationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaActivityType).HasColumnName("sa_activityType");

                entity.Property(e => e.SaCompany).HasColumnName("sa_company");

                entity.Property(e => e.SaContractDate)
                    .HasColumnName("sa_contractDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaExpirationDate)
                    .HasColumnName("sa_expirationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaStatus).HasColumnName("sa_status");

                entity.Property(e => e.SaSubfundId).HasColumnName("sa_subfundId");

                entity.HasOne(d => d.File)
                    .WithOne(p => p.TbServiceAgreementSubfund)
                    .HasForeignKey<TbServiceAgreementSubfund>(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_subfund_tb_file");

                entity.HasOne(d => d.SaActivityTypeNavigation)
                    .WithMany(p => p.TbServiceAgreementSubfund)
                    .HasForeignKey(d => d.SaActivityType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_subfund_tb_dom_activityType");

                entity.HasOne(d => d.SaCompanyNavigation)
                    .WithMany(p => p.TbServiceAgreementSubfund)
                    .HasForeignKey(d => d.SaCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_subfund_tb_companies");

                entity.HasOne(d => d.SaStatusNavigation)
                    .WithMany(p => p.TbServiceAgreementSubfund)
                    .HasForeignKey(d => d.SaStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_subfund_tb_dom_agreement_status");

                entity.HasOne(d => d.SaSubfund)
                    .WithMany(p => p.TbServiceAgreementSubfund)
                    .HasForeignKey(d => d.SaSubfundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_subfund_tb_subFund");
            });

            modelBuilder.Entity<TbShareClass>(entity =>
            {
                entity.HasKey(e => e.IdSc)
                    .HasName("PK_tb_shareClass_1");

                entity.ToTable("tb_shareClass");

                entity.Property(e => e.IdSc)
                    .HasColumnName("id_sc")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TbShareclassTsTest>(entity =>
            {
                entity.HasKey(e => new { e.DateTs, e.IdTs, e.CurrencyTs, e.ProviderTs, e.IdShareclass })
                    .HasName("PK__tb_shareclass_ts_test");

                entity.ToTable("tb_shareclass_ts_test");

                entity.Property(e => e.DateTs)
                    .HasColumnName("date_ts")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdTs).HasColumnName("id_ts");

                entity.Property(e => e.CurrencyTs)
                    .HasColumnName("currency_ts")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.ProviderTs).HasColumnName("provider_ts");

                entity.Property(e => e.IdShareclass).HasColumnName("id_shareclass");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name");

                entity.Property(e => e.ValueTs)
                    .HasColumnName("value_ts")
                    .HasColumnType("decimal(18, 9)");

                entity.HasOne(d => d.CurrencyTsNavigation)
                    .WithMany(p => p.TbShareclassTsTest)
                    .HasForeignKey(d => d.CurrencyTs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_test_tb_dom_iso_currency");

                entity.HasOne(d => d.IdShareclassNavigation)
                    .WithMany(p => p.TbShareclassTsTest)
                    .HasForeignKey(d => d.IdShareclass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_test_tb_shareClass");

                entity.HasOne(d => d.IdTsNavigation)
                    .WithMany(p => p.TbShareclassTsTest)
                    .HasForeignKey(d => d.IdTs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_test_tb_dom_timeseries_type");

                entity.HasOne(d => d.ProviderTsNavigation)
                    .WithMany(p => p.TbShareclassTsTest)
                    .HasForeignKey(d => d.ProviderTs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_test_tb_dom_ts_provider");
            });

            modelBuilder.Entity<TbSubFund>(entity =>
            {
                entity.HasKey(e => e.IdSubFund)
                    .HasName("PK_tb_subFund_1");

                entity.ToTable("tb_subFund");

                entity.Property(e => e.IdSubFund)
                    .HasColumnName("id_subFund")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TbSubFundShareClass>(entity =>
            {
                entity.HasKey(e => new { e.ScId, e.SfscStartConnection })
                    .HasName("PK_tb_shareClass");

                entity.ToTable("tb_subFundShareClass");

                entity.Property(e => e.ScId).HasColumnName("sc_id");

                entity.Property(e => e.SfscStartConnection)
                    .HasColumnName("sfsc_startConnection")
                    .HasColumnType("datetime");

                entity.Property(e => e.SfId).HasColumnName("sf_id");

                entity.Property(e => e.SfscEndConnection)
                    .HasColumnName("sfsc_endConnection")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Sc)
                    .WithMany(p => p.TbSubFundShareClass)
                    .HasForeignKey(d => d.ScId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_subFundShareClass_tb_shareClass");

                entity.HasOne(d => d.Sf)
                    .WithMany(p => p.TbSubFundShareClass)
                    .HasForeignKey(d => d.SfId)
                    .HasConstraintName("FK_tb_subFundShareClass_tb_subFund");
            });

            modelBuilder.Entity<TbTimeseriesShareclass>(entity =>
            {
                entity.HasKey(e => new { e.DateTs, e.IdTs, e.CurrencyTs, e.ProviderTs, e.IdShareclass });

                entity.ToTable("tb_timeseries_shareclass");

                entity.Property(e => e.DateTs)
                    .HasColumnName("date_ts")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdTs).HasColumnName("id_ts");

                entity.Property(e => e.CurrencyTs)
                    .HasColumnName("currency_ts")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.ProviderTs).HasColumnName("provider_ts");

                entity.Property(e => e.IdShareclass).HasColumnName("id_shareclass");

                entity.Property(e => e.ValueTs)
                    .HasColumnName("value_ts")
                    .HasColumnType("decimal(18, 9)");

                entity.HasOne(d => d.CurrencyTsNavigation)
                    .WithMany(p => p.TbTimeseriesShareclass)
                    .HasForeignKey(d => d.CurrencyTs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_shareclass_tb_dom_iso_currency");

                entity.HasOne(d => d.IdShareclassNavigation)
                    .WithMany(p => p.TbTimeseriesShareclass)
                    .HasForeignKey(d => d.IdShareclass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_shareclass_tb_shareClass");

                entity.HasOne(d => d.IdTsNavigation)
                    .WithMany(p => p.TbTimeseriesShareclass)
                    .HasForeignKey(d => d.IdTs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_shareclass_tb_dom_timeseries_type");

                entity.HasOne(d => d.ProviderTsNavigation)
                    .WithMany(p => p.TbTimeseriesShareclass)
                    .HasForeignKey(d => d.ProviderTs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_shareclass_tb_dom_ts_provider");
            });

            modelBuilder.Entity<TbTimeseriesSubfund>(entity =>
            {
                entity.HasKey(e => new { e.DateTs, e.IdTs, e.CurrencyTs, e.ProviderTs, e.IdSubfund });

                entity.ToTable("tb_timeseries_subfund");

                entity.Property(e => e.DateTs)
                    .HasColumnName("date_ts")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdTs).HasColumnName("id_ts");

                entity.Property(e => e.CurrencyTs)
                    .HasColumnName("currency_ts")
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.ProviderTs).HasColumnName("provider_ts");

                entity.Property(e => e.IdSubfund).HasColumnName("id_subfund");

                entity.Property(e => e.ValueTs)
                    .HasColumnName("value_ts")
                    .HasColumnType("decimal(18, 9)");

                entity.HasOne(d => d.CurrencyTsNavigation)
                    .WithMany(p => p.TbTimeseriesSubfund)
                    .HasForeignKey(d => d.CurrencyTs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_subfund_tb_dom_iso_currency");

                entity.HasOne(d => d.IdSubfundNavigation)
                    .WithMany(p => p.TbTimeseriesSubfund)
                    .HasForeignKey(d => d.IdSubfund)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_subfund_tb_subfund");

                entity.HasOne(d => d.IdTsNavigation)
                    .WithMany(p => p.TbTimeseriesSubfund)
                    .HasForeignKey(d => d.IdTs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_subfund_tb_dom_timeseries_type");

                entity.HasOne(d => d.ProviderTsNavigation)
                    .WithMany(p => p.TbTimeseriesSubfund)
                    .HasForeignKey(d => d.ProviderTs)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_timeseries_subfund_tb_dom_ts_provider");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
