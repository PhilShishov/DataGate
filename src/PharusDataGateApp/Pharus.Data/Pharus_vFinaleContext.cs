﻿namespace Pharus.Data
{
    using Microsoft.EntityFrameworkCore;

    using Pharus.Domain.Pharus_vFinale;

    public partial class Pharus_vFinaleContext : DbContext
    {
        public Pharus_vFinaleContext()
        {
        }

        public Pharus_vFinaleContext(DbContextOptions<Pharus_vFinaleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbDomActivityType> TbDomActivityType { get; set; }
        public virtual DbSet<TbDomCalculationDate> TbDomCalculationDate { get; set; }
        public virtual DbSet<TbDomCesrClass> TbDomCesrClass { get; set; }
        public virtual DbSet<TbDomCompany> TbDomCompany { get; set; }
        public virtual DbSet<TbDomCompanyType> TbDomCompanyType { get; set; }
        public virtual DbSet<TbDomCssfGeographicalFocus> TbDomCssfGeographicalFocus { get; set; }
        public virtual DbSet<TbDomCssfPrincipalAssetClass> TbDomCssfPrincipalAssetClass { get; set; }
        public virtual DbSet<TbDomDerivMarket> TbDomDerivMarket { get; set; }
        public virtual DbSet<TbDomDerivPurpose> TbDomDerivPurpose { get; set; }
        public virtual DbSet<TbDomFStatus> TbDomFStatus { get; set; }
        public virtual DbSet<TbDomGlobalExposure> TbDomGlobalExposure { get; set; }
        public virtual DbSet<TbDomInvestorType> TbDomInvestorType { get; set; }
        public virtual DbSet<TbDomIsoCountry> TbDomIsoCountry { get; set; }
        public virtual DbSet<TbDomIsoCurrency> TbDomIsoCurrency { get; set; }
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
        public virtual DbSet<TbDomTypeOfMarket> TbDomTypeOfMarket { get; set; }
        public virtual DbSet<TbDomValutationDate> TbDomValutationDate { get; set; }
        public virtual DbSet<TbFund> TbFund { get; set; }
        public virtual DbSet<TbFundSubFund> TbFundSubFund { get; set; }
        public virtual DbSet<TbHistoryFund> TbHistoryFund { get; set; }
        public virtual DbSet<TbHistoryShareClass> TbHistoryShareClass { get; set; }
        public virtual DbSet<TbHistorySubFund> TbHistorySubFund { get; set; }
        public virtual DbSet<TbServiceAgreementFund> TbServiceAgreementFund { get; set; }
        public virtual DbSet<TbServiceAgreementShareclass> TbServiceAgreementShareclass { get; set; }
        public virtual DbSet<TbServiceAgreementSubfund> TbServiceAgreementSubfund { get; set; }
        public virtual DbSet<TbShareClass> TbShareClass { get; set; }
        public virtual DbSet<TbSubFund> TbSubFund { get; set; }
        public virtual DbSet<TbSubFundShareClass> TbSubFundShareClass { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.ConnectionStringPharus_vFinale);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

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
            });

            modelBuilder.Entity<TbDomCalculationDate>(entity =>
            {
                entity.HasKey(e => e.CdId);

                entity.ToTable("tb_dom_calculationDate");

                entity.Property(e => e.CdId)
                    .HasColumnName("cd_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CdDesc)
                    .IsRequired()
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
                    .IsRequired()
                    .HasColumnName("c_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomCompany>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK_tb_company");

                entity.ToTable("tb_dom_company");

                entity.Property(e => e.CId)
                    .HasColumnName("c_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CName)
                    .HasColumnName("c_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomCompanyType>(entity =>
            {
                entity.HasKey(e => e.CtId);

                entity.ToTable("tb_dom_companyType");

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
                    .IsRequired()
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
                    .IsRequired()
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
                    .IsRequired()
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
                    .IsRequired()
                    .HasColumnName("dp_desc")
                    .HasMaxLength(100);
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

            modelBuilder.Entity<TbDomGlobalExposure>(entity =>
            {
                entity.HasKey(e => e.GeId);

                entity.ToTable("tb_dom_globalExposure");

                entity.Property(e => e.GeId)
                    .HasColumnName("ge_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GeDesc)
                    .IsRequired()
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
                    .IsRequired()
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
                    .ValueGeneratedNever();

                entity.Property(e => e.IsoCountry3)
                    .HasColumnName("iso_country_3")
                    .HasMaxLength(3);

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
                    .ValueGeneratedNever();

                entity.Property(e => e.IsoCcyDesc)
                    .HasColumnName("iso_ccy_desc")
                    .HasMaxLength(100);

                entity.Property(e => e.IsoCcyDescEntity)
                    .HasColumnName("iso_ccy_desc_entity")
                    .HasMaxLength(100);

                entity.Property(e => e.IsoCcyNumeric).HasColumnName("iso_ccy_numeric");
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

                entity.ToTable("tb_dom_legalType");

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
                    .HasConstraintName("FK_tb_dom_legal_vehicle_tb_dom_legalType");
            });

            modelBuilder.Entity<TbDomNavFrequency>(entity =>
            {
                entity.HasKey(e => e.NfId);

                entity.ToTable("tb_dom_navFrequency");

                entity.Property(e => e.NfId)
                    .HasColumnName("nf_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NfDesc)
                    .IsRequired()
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
                    .IsRequired()
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
                    .IsRequired()
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
                    .IsRequired()
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
                    .IsRequired()
                    .HasColumnName("st_desc")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDomTypeOfMarket>(entity =>
            {
                entity.HasKey(e => e.TomId);

                entity.ToTable("tb_dom_type_of_market");

                entity.Property(e => e.TomId)
                    .HasColumnName("tom_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TomDesc)
                    .IsRequired()
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
                    .IsRequired()
                    .HasColumnName("vd_desc")
                    .HasMaxLength(100);
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
                    .HasColumnName("f_initialDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FCompanyType).HasColumnName("f_companyType");

                entity.Property(e => e.FCssfCode)
                    .HasColumnName("f_cssfCode")
                    .HasMaxLength(100);

                entity.Property(e => e.FDepCode)
                    .HasColumnName("f_depCode")
                    .HasMaxLength(100);

                entity.Property(e => e.FEndDate)
                    .HasColumnName("f_endDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FFaCode)
                    .HasColumnName("f_faCode")
                    .HasMaxLength(100);

                entity.Property(e => e.FLegalForm).HasColumnName("f_legalForm");

                entity.Property(e => e.FLegalType).HasColumnName("f_legalType");

                entity.Property(e => e.FLegalVehicle).HasColumnName("f_legal_vehicle");

                entity.Property(e => e.FLeiCode)
                    .HasColumnName("f_leiCode")
                    .HasMaxLength(100);

                entity.Property(e => e.FOfficialFundName)
                    .HasColumnName("f_officialFundName")
                    .HasMaxLength(100);

                entity.Property(e => e.FRegistrationNumber)
                    .HasColumnName("f_registrationNumber")
                    .HasMaxLength(100);

                entity.Property(e => e.FShortFundName)
                    .IsRequired()
                    .HasColumnName("f_shortFundName")
                    .HasMaxLength(100);

                entity.Property(e => e.FStatus).HasColumnName("f_status");

                entity.Property(e => e.FTaCode)
                    .HasColumnName("f_taCode")
                    .HasMaxLength(100);

                entity.Property(e => e.FTinNumber)
                    .HasColumnName("f_tinNumber")
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

                entity.Property(e => e.ScCountryIssue)
                    .HasColumnName("sc_countryIssue")
                    .HasMaxLength(2);

                entity.Property(e => e.ScCurrency)
                    .HasColumnName("sc_currency")
                    .HasMaxLength(3);

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
                    .HasMaxLength(12);

                entity.Property(e => e.ScLastNav)
                    .HasColumnName("sc_lastNav")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScListed).HasColumnName("sc_listed");

                entity.Property(e => e.ScOfficialShareClassName)
                    .HasColumnName("sc_officialShareClassName")
                    .HasMaxLength(100);

                entity.Property(e => e.ScProspectusCode)
                    .HasColumnName("sc_prospectus_code")
                    .HasMaxLength(10);

                entity.Property(e => e.ScShareType).HasColumnName("sc_shareType");

                entity.Property(e => e.ScShortShareClassName)
                    .IsRequired()
                    .HasColumnName("sc_shortShareClassName")
                    .HasMaxLength(100);

                entity.Property(e => e.ScStatus).HasColumnName("sc_status");

                entity.Property(e => e.ScTaCode)
                    .HasColumnName("sc_taCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScUltimateParentCountryRisk)
                    .HasColumnName("sc_ultimateParentCountryRisk")
                    .HasMaxLength(2);

                entity.Property(e => e.ScValorCode)
                    .HasColumnName("sc_valorCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ScWkn)
                    .HasColumnName("sc_WKN")
                    .HasMaxLength(100);

                entity.HasOne(d => d.ScCountryIssueNavigation)
                    .WithMany(p => p.TbHistoryShareClassScCountryIssueNavigation)
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

                entity.HasOne(d => d.ScUltimateParentCountryRiskNavigation)
                    .WithMany(p => p.TbHistoryShareClassScUltimateParentCountryRiskNavigation)
                    .HasForeignKey(d => d.ScUltimateParentCountryRisk)
                    .HasConstraintName("FK_tb_historyShareClass_tb_dom_iso_country1");
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

                entity.Property(e => e.SfClearingCode)
                    .HasColumnName("sf_clearing_code")
                    .HasMaxLength(100);

                entity.Property(e => e.SfCssfAuthDate)
                    .HasColumnName("sf_cssfAuthDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SfCssfCode)
                    .HasColumnName("sf_cssfCode")
                    .HasMaxLength(100);

                entity.Property(e => e.SfCssfGeographicalFocus).HasColumnName("sf_cssf_geographical_focus");

                entity.Property(e => e.SfCurrency)
                    .HasColumnName("sf_currency")
                    .HasMaxLength(3);

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
                    .IsRequired()
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

            modelBuilder.Entity<TbServiceAgreementFund>(entity =>
            {
                entity.HasKey(e => e.SaId);

                entity.ToTable("tb_serviceAgreement_fund");

                entity.Property(e => e.SaId).HasColumnName("sa_id");

                entity.Property(e => e.SaActivationDate)
                    .HasColumnName("sa_activationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaActivityType).HasColumnName("sa_activityType");

                entity.Property(e => e.SaCompanyId).HasColumnName("sa_companyId");

                entity.Property(e => e.SaConctractDate)
                    .HasColumnName("sa_conctractDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaExpirationDate)
                    .HasColumnName("sa_expirationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaF).HasColumnName("sa_f");

                entity.Property(e => e.SaRifCode)
                    .HasColumnName("sa_rifCode")
                    .HasMaxLength(100);

                entity.Property(e => e.SaStatus)
                    .HasColumnName("sa_status")
                    .HasMaxLength(100);

                entity.HasOne(d => d.SaActivityTypeNavigation)
                    .WithMany(p => p.TbServiceAgreementFund)
                    .HasForeignKey(d => d.SaActivityType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_fund_tb_dom_activityType");

                entity.HasOne(d => d.SaCompany)
                    .WithMany(p => p.TbServiceAgreementFund)
                    .HasForeignKey(d => d.SaCompanyId)
                    .HasConstraintName("FK_tb_serviceAgreement_fund_tb_dom_company");

                entity.HasOne(d => d.SaFNavigation)
                    .WithMany(p => p.TbServiceAgreementFund)
                    .HasForeignKey(d => d.SaF)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_fund_tb_fund");
            });

            modelBuilder.Entity<TbServiceAgreementShareclass>(entity =>
            {
                entity.HasKey(e => e.SaId);

                entity.ToTable("tb_serviceAgreement_shareclass");

                entity.Property(e => e.SaId).HasColumnName("sa_id");

                entity.Property(e => e.SaActivationDate)
                    .HasColumnName("sa_activationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaActivityType).HasColumnName("sa_activityType");

                entity.Property(e => e.SaCompanyId).HasColumnName("sa_companyId");

                entity.Property(e => e.SaConctractDate)
                    .HasColumnName("sa_conctractDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaExpirationDate)
                    .HasColumnName("sa_expirationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaRifCode)
                    .HasColumnName("sa_rifCode")
                    .HasMaxLength(100);

                entity.Property(e => e.SaSc).HasColumnName("sa_sc");

                entity.Property(e => e.SaStatus)
                    .HasColumnName("sa_status")
                    .HasMaxLength(100);

                entity.HasOne(d => d.SaActivityTypeNavigation)
                    .WithMany(p => p.TbServiceAgreementShareclass)
                    .HasForeignKey(d => d.SaActivityType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_shareclass_tb_dom_activityType");

                entity.HasOne(d => d.SaCompany)
                    .WithMany(p => p.TbServiceAgreementShareclass)
                    .HasForeignKey(d => d.SaCompanyId)
                    .HasConstraintName("FK_tb_serviceAgreement_shareclass_tb_dom_company");

                entity.HasOne(d => d.SaScNavigation)
                    .WithMany(p => p.TbServiceAgreementShareclass)
                    .HasForeignKey(d => d.SaSc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_shareclass_tb_shareClass");
            });

            modelBuilder.Entity<TbServiceAgreementSubfund>(entity =>
            {
                entity.HasKey(e => e.SaId);

                entity.ToTable("tb_serviceAgreement_subfund");

                entity.Property(e => e.SaId).HasColumnName("sa_id");

                entity.Property(e => e.SaActivationDate)
                    .HasColumnName("sa_activationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaActivityType).HasColumnName("sa_activityType");

                entity.Property(e => e.SaCompanyId).HasColumnName("sa_companyId");

                entity.Property(e => e.SaConctractDate)
                    .HasColumnName("sa_conctractDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaExpirationDate)
                    .HasColumnName("sa_expirationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaRifCode)
                    .HasColumnName("sa_rifCode")
                    .HasMaxLength(100);

                entity.Property(e => e.SaSf).HasColumnName("sa_sf");

                entity.Property(e => e.SaStatus)
                    .HasColumnName("sa_status")
                    .HasMaxLength(100);

                entity.HasOne(d => d.SaActivityTypeNavigation)
                    .WithMany(p => p.TbServiceAgreementSubfund)
                    .HasForeignKey(d => d.SaActivityType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_serviceAgreement_subfund_tb_dom_activityType");

                entity.HasOne(d => d.SaCompany)
                    .WithMany(p => p.TbServiceAgreementSubfund)
                    .HasForeignKey(d => d.SaCompanyId)
                    .HasConstraintName("FK_tb_serviceAgreement_subfund_tb_dom_company");

                entity.HasOne(d => d.SaSfNavigation)
                    .WithMany(p => p.TbServiceAgreementSubfund)
                    .HasForeignKey(d => d.SaSf)
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
        }
    }
}
