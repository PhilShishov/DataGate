USE [master]
GO
CREATE DATABASE [DataGate_Test]
GO
USE [DataGate_Test]
GO
/****** Object:  Table [dbo].[tb_historySubFund]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_historySubFund](
	[sf_id] [int] NOT NULL,
	[sf_initialDate] [datetime] NOT NULL,
	[sf_endDate] [datetime] NULL,
	[sf_officialSubFundName] [nvarchar](100) NULL,
	[sf_shortSubFundName] [nvarchar](100) NULL,
	[sf_cssfCode] [nvarchar](100) NULL,
	[sf_faCode] [nvarchar](100) NULL,
	[sf_depCode] [nvarchar](100) NULL,
	[sf_taCode] [nvarchar](100) NULL,
	[sf_firstNavDate] [datetime] NULL,
	[sf_lastNavDate] [datetime] NULL,
	[sf_cssfAuthDate] [datetime] NULL,
	[sf_expDate] [datetime] NULL,
	[sf_status] [int] NULL,
	[sf_leiCode] [nvarchar](100) NULL,
	[sf_cesrClass] [int] NULL,
	[sf_cssf_geographical_focus] [int] NULL,
	[sf_globalExposure] [int] NULL,
	[sf_currency] [nchar](3) NULL,
	[sf_navFrequency] [int] NULL,
	[sf_valutationDate] [int] NULL,
	[sf_calculationDate] [int] NULL,
	[sf_derivatives] [bit] NULL,
	[sf_derivMarket] [int] NULL,
	[sf_derivPurpose] [int] NULL,
	[sf_lastProspectus] [datetime] NULL,
	[sf_lastProspectusDate] [datetime] NULL,
	[sf_principal_asset_class] [int] NULL,
	[sf_type_of_market] [int] NULL,
	[sf_principal_investment_strategy] [int] NULL,
	[sf_clearing_code] [nvarchar](100) NULL,
	[sf_cat_morningstar] [int] NULL,
	[sf_category_six] [int] NULL,
	[sf_category_bloomberg] [int] NULL,
	[sf_change_comment] [nvarchar](max) NULL,
	[sf_comment_title] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_historySubFund] PRIMARY KEY CLUSTERED 
(
	[sf_id] ASC,
	[sf_initialDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_sf_status]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_sf_status](
	[st_id] [int] NOT NULL,
	[st_desc] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tb_dom_sf_status] PRIMARY KEY CLUSTERED 
(
	[st_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_calculationDate]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_calculationDate](
	[cd_id] [int] NOT NULL,
	[cd_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_calculationDate] PRIMARY KEY CLUSTERED 
(
	[cd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_cesrClass]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_cesrClass](
	[cc_id] [int] NOT NULL,
	[c_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_cesrClass] PRIMARY KEY CLUSTERED 
(
	[cc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_cssf_geographical_focus]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_cssf_geographical_focus](
	[gf_id] [int] NOT NULL,
	[gf_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_cssf_geographical_focus] PRIMARY KEY CLUSTERED 
(
	[gf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_cssf_principal_asset_class]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_cssf_principal_asset_class](
	[pac_id] [int] NOT NULL,
	[pac_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_cssf_principal_asset_class] PRIMARY KEY CLUSTERED 
(
	[pac_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_derivMarket]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_derivMarket](
	[dm_id] [int] NOT NULL,
	[dm_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_derivMarket] PRIMARY KEY CLUSTERED 
(
	[dm_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_derivPurpose]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_derivPurpose](
	[dp_id] [int] NOT NULL,
	[dp_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_derivPurpose] PRIMARY KEY CLUSTERED 
(
	[dp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_globalExposure]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_globalExposure](
	[ge_id] [int] NOT NULL,
	[ge_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_globalExposure] PRIMARY KEY CLUSTERED 
(
	[ge_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_navFrequency]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_navFrequency](
	[nf_id] [int] NOT NULL,
	[nf_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_navFrequency] PRIMARY KEY CLUSTERED 
(
	[nf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_principal_investment_strategy]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_principal_investment_strategy](
	[pis_id] [int] NOT NULL,
	[pis_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_principal_investment_strategy] PRIMARY KEY CLUSTERED 
(
	[pis_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_sf_cat_bloomberg]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_sf_cat_bloomberg](
	[cat_bloomberg_id] [int] NOT NULL,
	[cat_bloomberg_Desc] [nvarchar](100) NULL,
	[cat_bloomberg_Desc_expl] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_dom_sf_cat_bloomberg] PRIMARY KEY CLUSTERED 
(
	[cat_bloomberg_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_sf_cat_morningstar]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_sf_cat_morningstar](
	[c_morningstar_id] [int] NOT NULL,
	[c_morningstar_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_sf_cat_morningstar] PRIMARY KEY CLUSTERED 
(
	[c_morningstar_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_sf_cat_six]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_sf_cat_six](
	[cat_six_id] [int] NOT NULL,
	[cat_six_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_sf_cat_six] PRIMARY KEY CLUSTERED 
(
	[cat_six_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_type_of_market]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_type_of_market](
	[tom_id] [int] NOT NULL,
	[tom_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_type_of_market] PRIMARY KEY CLUSTERED 
(
	[tom_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_valutationDate]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_valutationDate](
	[vd_id] [int] NOT NULL,
	[vd_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_valutationDate] PRIMARY KEY CLUSTERED 
(
	[vd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE FUNCTION [dbo].[fn_filetypeAllowed]
(
	@valueTocheck as int,
	@entitytype as int
)
RETURNS bit
AS
BEGIN

	IF
		(SELECT filetype_id from [tb_dom_file_type]
		where filetype_entity=@entitytype and filetype_id=@valueTocheck)>0 
	BEGIN
		return 1;
    END

	  return 0;


	
END
GO

/****** Object:  UserDefinedFunction [dbo].[fn_all_subfund]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_all_subfund]
(	
		@report_date date 
)
RETURNS TABLE 
AS
RETURN 
(

SELECT top(1000)

 [ID]
,[VALID FROM]
, case
	when [VALID UNTIL] is null then 'STILL VALID'
	else [VALID UNTIL] end as [VALID UNTIL]
, [NAME]
, [STATUS]
, [CSSF CODE]
, [ADMIN CODE]
, [DEPOSITARY BANK CODE]
, [TRANSFER AGENT CODE]
, [FIRST NAV DATE]
, [LAST NAV DATE]
, [CSSF AUTH. DATE]
, [EXPIRY DATE]
,[LEI CODE]
,[CESR CLASS]
,[GEO FOCUS]
,[GLOBAL EXPOSURE]
,[CURRENCY]
,[FREQUENCY]
,[VALUATION DATE]
,[CALCULATION DATE]
,[DERIVATIVES]
,[DERIV. MARKET]
,[DERIV. PURPOSE]
,[PRINCIPAL ASSET CLASS]
,[MARKET TYPE]
,[PRINCIPAL INVESTMENT STRATEGY]
,[CLEARING CODE]
,[MORNINGSTAR CATEGORY]
,[SIX CATEGORY]
,[BLOOMBERG CATEGORY]	
FROM
(
select 

 sf_id [ID]
,convert(varchar,sf_initialDate, 103) [VALID FROM]
,convert(varchar,sf_endDate, 103) [VALID UNTIL]
,sf_officialSubFundName [NAME]
,sfstat.st_desc [STATUS]
,sf_cssfCode [CSSF CODE]
,sf_faCode [ADMIN CODE]
,sf_depCode [DEPOSITARY BANK CODE]
,sf_taCode [TRANSFER AGENT CODE]
,convert(varchar,sf_firstNavDate, 103) [FIRST NAV DATE]
,convert(varchar,sf_lastNavDate, 103) [LAST NAV DATE]
,convert(varchar,sf_cssfAuthDate, 103) [CSSF AUTH. DATE]
,convert(varchar,sf_expDate, 103) [EXPIRY DATE]
,sf_leiCode [LEI CODE]
,sfcesr.c_desc [CESR CLASS]
,sfgeo.gf_desc [GEO FOCUS]
,sfge.ge_desc [GLOBAL EXPOSURE]
,sf_currency [CURRENCY]
,nfreq.nf_desc [FREQUENCY]
,vdate.vd_desc [VALUATION DATE]
,cdate.cd_desc [CALCULATION DATE]
,case 
	when sf_derivatives=1 then 'Yes'
	when sf_derivatives=0 then 'No'
	else NULL
	END as [DERIVATIVES]
,dmar.dm_desc [DERIV. MARKET]
,dpur.dp_desc [DERIV. PURPOSE]
,pac.pac_desc [PRINCIPAL ASSET CLASS]
,tom.tom_desc [MARKET TYPE]
,pis.pis_desc [PRINCIPAL INVESTMENT STRATEGY]
,sf_clearing_code [CLEARING CODE]
,cms.c_morningstar_desc [MORNINGSTAR CATEGORY]
,cs.cat_six_desc [SIX CATEGORY]
,cb.cat_bloomberg_Desc [BLOOMBERG CATEGORY]	
	
	
	FROM tb_historySubFund sf
				left join tb_dom_sf_status sfstat on sfstat.st_id=sf.sf_status
				left join tb_dom_cesrClass sfcesr on sfcesr.cc_id=sf.sf_cesrClass
				left join tb_dom_cssf_geographical_focus sfgeo on sfgeo.gf_id=sf.sf_cssf_geographical_focus
				left join tb_dom_globalExposure sfge on sfge.ge_id=sf.sf_globalExposure
				left join tb_dom_navFrequency nfreq on nfreq.nf_id=sf.sf_navFrequency
				left join tb_dom_valutationDate vdate on vdate.vd_id=sf.sf_valutationDate
				left join tb_dom_calculationDate cdate on cdate.cd_id=sf.sf_calculationDate
				left join tb_dom_derivMarket dmar on dmar.dm_id=sf.sf_derivMarket
				left join tb_dom_derivPurpose dpur on dpur.dp_id=sf.sf_derivPurpose
				left join tb_dom_cssf_principal_asset_class pac on pac.pac_id=sf.sf_principal_asset_class
				left join tb_dom_type_of_market tom on tom.tom_id=sf.sf_type_of_market
				left join tb_dom_principal_investment_strategy pis on pis.pis_id=sf.sf_principal_investment_strategy
				left join tb_dom_sf_cat_morningstar cms on cms.c_morningstar_id=sf.sf_cat_morningstar
				left join tb_dom_sf_cat_six cs on cs.cat_six_id=sf.sf_category_six
				left join tb_dom_sf_cat_bloomberg cb on cb.cat_bloomberg_id=sf.sf_category_bloomberg


	Where (	@report_date between sf.sf_initialDate and sf.sf_endDate  OR (@report_date > sf.sf_initialDate and sf.sf_endDate is null))
) t2 
ORDER BY t2.[NAME]
) 
GO
/****** Object:  Table [dbo].[tb_historyFund]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_historyFund](
	[f_id] [int] NOT NULL,
	[f_initial_date] [datetime] NOT NULL,
	[f_end_date] [datetime] NULL,
	[f_status] [int] NULL,
	[f_registration_number] [nvarchar](100) NULL,
	[f_official_fund_name] [nvarchar](100) NULL,
	[f_short_fund_name] [nvarchar](100) NULL,
	[f_lei_code] [nvarchar](100) NULL,
	[f_cssf_code] [nvarchar](100) NULL,
	[f_fa_code] [nvarchar](100) NULL,
	[f_dep_code] [nvarchar](100) NULL,
	[f_ta_code] [nvarchar](100) NULL,
	[f_legal_form] [int] NULL,
	[f_legal_type] [int] NULL,
	[f_legal_vehicle] [int] NULL,
	[f_company_type] [int] NULL,
	[f_tin_number] [nvarchar](100) NULL,
	[f_change_comment] [nvarchar](max) NULL,
	[f_comment_title] [nvarchar](50) NULL,
	[f_vat_registration_number] [nvarchar](100) NULL,
	[f_vat_identification_number] [nvarchar](100) NULL,
	[f_ibic_number] [nvarchar](100) NULL,
	[f_fund_admin] [int] NULL,
 CONSTRAINT [PK_tb_fund] PRIMARY KEY CLUSTERED 
(
	[f_id] ASC,
	[f_initial_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_companies]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_companies](
	[c_id] [int] NOT NULL,
	[c_name] [nvarchar](max) NOT NULL,
	[c_iso3_acronym] [varchar](3) NULL,
 CONSTRAINT [PK_tb_company] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_company_type]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_company_type](
	[ct_id] [int] NOT NULL,
	[ct_desc] [varchar](100) NOT NULL,
	[ct_acronym] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tb_dom_companyType] PRIMARY KEY CLUSTERED 
(
	[ct_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_f_status]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_f_status](
	[st_f_id] [int] NOT NULL,
	[st_f_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_f_status] PRIMARY KEY CLUSTERED 
(
	[st_f_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_serviceAgreement_fund]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_serviceAgreement_fund](
	[file_id] [int] NOT NULL,
	[file_name] [nvarchar](max) NOT NULL,
	[file_extension] [nvarchar](5) NOT NULL,
	[sa_fundId] [int] NOT NULL,
	[sa_activityType] [int] NOT NULL,
	[sa_contractDate] [datetime] NOT NULL,
	[sa_activationDate] [datetime] NOT NULL,
	[sa_expirationDate] [datetime] NULL,
	[sa_status] [int] NOT NULL,
	[sa_company] [int] NOT NULL,
 CONSTRAINT [PK__tb_serviceAgreement_fund] PRIMARY KEY CLUSTERED 
(
	[file_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_legal_form]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_legal_form](
	[lf_id] [int] NOT NULL,
	[lf_acronym] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tb_dom_legal_form] PRIMARY KEY CLUSTERED 
(
	[lf_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_legal_vehicle]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_legal_vehicle](
	[lv_id] [int] NOT NULL,
	[lv_acronym] [varchar](100) NOT NULL,
	[lv_fk_legal_type] [int] NOT NULL,
 CONSTRAINT [PK_tb_dom_legal_vehicle] PRIMARY KEY CLUSTERED 
(
	[lv_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_legal_type]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_legal_type](
	[lt_id] [int] NOT NULL,
	[lt_acronym] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tb_dom_legalType] PRIMARY KEY CLUSTERED 
(
	[lt_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_all_fund]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_all_fund]
(	
		@report_date date 
)
RETURNS TABLE 
AS
RETURN 
(

select top(1000)
[ID],
[VALID FROM],
	case
	when [VALID UNTIL] is null then 'STILL VALID'
	else [VALID UNTIL] end as [VALID UNTIL],
[NAME],
[STATUS],
[CSSF CODE],
[LEGAL FORM],
[LEGAL VEHICLE],
[LEGAL TYPE],
[FUND ADMIN CODE],
[DEPOSITARY BANK CODE],
[TRANSFER AGENT CODE],
[COMPANY DESCRIPTION],
[COMPANY TYPE],
[TIN NUMBER],
[LEI CODE],
[REG. NUMBER],
[VAT REG. NUMBER],
[VAT IDENT. NUMBER],
[I.B.I.C. NUMBER]
from (

SELECT 
                        convert(varchar, f.f_initial_date, 103)[VALID FROM],
			convert(varchar, f.f_end_date, 103) [VALID UNTIL],
			f.f_id [ID],
			f.f_official_fund_name [NAME],  
			f.f_cssf_code [CSSF CODE],  
			ft.st_f_desc [STATUS], 
			lf.lf_acronym [LEGAL FORM],  
			lv.lv_acronym [LEGAL VEHICLE], 
			lt.lt_acronym [LEGAL TYPE], 
			CONCAT(tb_comp_fund.c_iso3_acronym, '- ',  f_fa_code ) [FUND ADMIN CODE],
			f_dep_code [DEPOSITARY BANK CODE],
			f_ta_code [TRANSFER AGENT CODE],
			ct.ct_desc [COMPANY DESCRIPTION],  
			CT.ct_acronym [COMPANY TYPE], 
			f.f_tin_number [TIN NUMBER], 
			f.f_lei_code [LEI CODE],
			f.f_registration_number [REG. NUMBER],
                        f.f_vat_registration_number [VAT REG. NUMBER],
                        f.f_vat_Identification_number [VAT IDENT. NUMBER],
                        f.f_ibic_number [I.B.I.C. NUMBER]
	
	FROM tb_historyFund f
				left join tb_dom_f_status ft  on ft.st_f_id=f.f_status
				left join tb_dom_legal_form lf on lf.lf_id=f.f_legal_form
				left join tb_dom_legal_vehicle lv on lv.lv_id=f.f_legal_vehicle
				left join tb_dom_legal_type lt on lt.lt_id=f.f_legal_type
				left join tb_dom_company_type ct on ct.ct_id=f.f_company_type
					left join (select tc.c_id, tc.c_name, tc.c_iso3_acronym, sa_fundId from tb_serviceAgreement_fund saf 
								join tb_companies tc on tc.c_id=saf.sa_company
								where sa_activityType=8 
								and (@report_date >= saf.sa_activationDate and (saf.sa_expirationDate>@report_date or saf.sa_expirationDate is null) and sa_status=1)
								)tb_comp_fund  on sa_fundId=f.f_id


	Where (@report_date between f.f_initial_date and f.f_end_date  OR (@report_date >= f.f_initial_date and f.f_end_date is null))
	)tb2
)
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_AgreementtypeAllowed]
(
	@valueTocheck as int,
	@entitytype as int
)
RETURNS bit
AS
BEGIN

	IF
		(SELECT at_id from [tb_dom_activityType]
		where at_entity=@entitytype and at_id=@valueTocheck)>0 
	BEGIN
		return 1;
    END

	  return 0;


	
END
GO

/****** Object:  Table [dbo].[tb_historyShareClass]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_historyShareClass](
	[sc_id] [int] NOT NULL,
	[sc_initialDate] [datetime] NOT NULL,
	[sc_endDate] [datetime] NULL,
	[sc_officialShareClassName] [nvarchar](100) NULL,
	[sc_shortShareClassName] [nvarchar](100) NULL,
	[sc_investorType] [int] NULL,
	[sc_shareType] [int] NULL,
	[sc_currency] [nchar](3) NULL,
	[sc_countryIssue] [nchar](2) NULL,
	[sc_ultimateParentCountryRisk] [nchar](2) NULL,
	[sc_emissionDate] [datetime] NULL,
	[sc_inceptionDate] [datetime] NULL,
	[sc_lastNav] [datetime] NULL,
	[sc_expiryDate] [datetime] NULL,
	[sc_status] [int] NULL,
	[sc_initialPrice] [float] NULL,
	[sc_accountingCode] [nvarchar](100) NULL,
	[sc_hedged] [bit] NULL,
	[sc_listed] [bit] NULL,
	[sc_bloomberMarket] [nvarchar](100) NULL,
	[sc_bloombedCode] [nvarchar](100) NULL,
	[sc_bloombedId] [nvarchar](100) NULL,
	[sc_isinCode] [nchar](12) NULL,
	[sc_valorCode] [nvarchar](100) NULL,
	[sc_faCode] [nvarchar](100) NULL,
	[sc_taCode] [nvarchar](100) NULL,
	[sc_WKN] [nvarchar](100) NULL,
	[sc_date_business_year] [datetime] NULL,
	[sc_prospectus_code] [nvarchar](100) NULL,
	[sc_change_comment] [nvarchar](max) NULL,
	[sc_comment_title] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_historyShareClass] PRIMARY KEY CLUSTERED 
(
	[sc_id] ASC,
	[sc_initialDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_investor_type]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_investor_type](
	[it_id] [int] NOT NULL,
	[it_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_investor_type] PRIMARY KEY CLUSTERED 
(
	[it_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_share_status]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_share_status](
	[sc_s_id] [int] NOT NULL,
	[sc_s_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_share_status] PRIMARY KEY CLUSTERED 
(
	[sc_s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_share_type]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_share_type](
	[st_id] [int] NOT NULL,
	[st_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK_tb_dom_share_type] PRIMARY KEY CLUSTERED 
(
	[st_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_all_shareclass]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_all_shareclass]
(	
		@report_date date 
)
RETURNS TABLE 
AS
RETURN 
(

SELECT TOP(1000) 

 [ID]	
,[VALID FROM]
,case
	when [VALID UNTIL] is null then 'STILL VALID'
	else [VALID UNTIL] end as [VALID UNTIL]
,[NAME]
,[STATUS]
,[ISIN]
,[INVESTOR TYPE]
,[SHARE TYPE]
,[CCY]
,[COUNTRY ISSUE]
,[ULT PARENT COUNTRY OF RISK]
,[EMISSION DATE]
,[INCEPTION DATE]
,[LAST NAV]
,[EXPIRY DATE]
,[INITIAL PRICE]
,[ACCOUNTING CODE]
,[HEDGED]
,[LISTED]
,[BLOOMBERG MARKET]
,[BLOOMBERG CODE]
,[BLOOMBERG ID]
,[VALOR CODE]
,[FUND ADMIN. CODE]
,[TRASFER AGENT CODE]
,[WKN CODE]
,[BUSINESS YEAR]
,[PROSPECTUS CODE]	
FROM 
( 

SELECT

 sc_id [ID]	
,convert(varchar, sc_initialDate, 103) [VALID FROM]
,convert(varchar, sc_endDate, 103) [VALID UNTIL]
,sc_officialShareClassName [NAME]
,stat.sc_s_desc [STATUS]
,intype.it_desc [INVESTOR TYPE]
,sharetype.st_desc [SHARE TYPE]
,sc_currency [CCY]
,sc_countryIssue [COUNTRY ISSUE]
,sc_ultimateParentCountryRisk [ULT PARENT COUNTRY OF RISK]
,convert(varchar, sc_emissionDate, 103) [EMISSION DATE]
,convert(varchar, sc_inceptionDate, 103) [INCEPTION DATE]
,convert(varchar, sc_lastNav, 103) [LAST NAV]
,convert(varchar, sc_expiryDate, 103) [EXPIRY DATE]
,sc_initialPrice [INITIAL PRICE]
,sc_accountingCode [ACCOUNTING CODE]
,case 
	when sc_hedged=1 then 'Yes'
	when sc_hedged=0 then 'No'
	else NULL
	END as [HEDGED]
,case 
	when sc_listed=1 then 'Yes'
	when sc_listed=0 then 'No'
	else NULL
	END as  [LISTED]
,sc_bloomberMarket [BLOOMBERG MARKET]
,sc_bloombedCode [BLOOMBERG CODE]
,sc_bloombedId [BLOOMBERG ID]
,sc_isinCode [ISIN]
,sc_valorCode [VALOR CODE]
,sc_faCode [FUND ADMIN. CODE]
,sc_taCode [TRASFER AGENT CODE]
,sc_WKN [WKN CODE]
,convert(varchar, sc_date_business_year, 103)  [BUSINESS YEAR]
,sc_prospectus_code [PROSPECTUS CODE]	
	
	FROM tb_historyShareClass sc
	left join tb_dom_investor_type intype on intype.it_id=sc.sc_investorType
	left join tb_dom_share_type sharetype on sharetype.st_id= sc.sc_shareType
	left join tb_dom_share_status stat on stat.sc_s_id=sc.sc_status
		
	Where (
		@report_date between sc.sc_initialDate and sc.sc_endDate  OR (@report_date > sc.sc_initialDate and sc.sc_endDate is null)
					 
	)
) t2
 ORDER BY t2.[NAME]
)
GO
/****** Object:  UserDefinedFunction [dbo].[fn_shareclass_id]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_shareclass_id]
(	
		@report_date date,
                @shareclass_id as int
)
RETURNS TABLE 
AS
RETURN 
(

SELECT TOP(1) 

[ISIN CODE]
,[VALID FROM]
,case
	when [VALID UNTIL] is null then 'STILL VALID'
	else [VALID UNTIL] end as [VALID UNTIL]
,[SHARE CLASS NAME]
,[STATUS]
,[INVESTOR TYPE]
,[SHARE TYPE]
,[CCY]
,[COUNTRY ISSUE]
,[ULT PARENT COUNTRY OF RISK]
,[EMISSION DATE]
,[INCEPTION DATE]
,[LAST NAV]
,[EXPIRY DATE]
,[INITIAL PRICE]
,[ACCOUNTING CODE]
,[HEDGED]
,[LISTED]
,[BLOOMBERG MARKET]
,[BLOOMBERG CODE]
,[BLOOMBERG ID]
,[VALOR CODE]
,[FUND ADMIN. CODE]
,[TRASFER AGENT CODE]
,[WKN CODE]
,[BUSINESS YEAR]
,[PROSPECTUS CODE]	
,[SHARE CLASS ID]
FROM 
( 

SELECT

 sc_id [SHARE CLASS ID]	
,convert(varchar, sc_initialDate, 103) [VALID FROM]
,convert(varchar, sc_endDate, 103) [VALID UNTIL]
,sc_officialShareClassName [SHARE CLASS NAME]
,stat.sc_s_desc [STATUS]
,intype.it_desc [INVESTOR TYPE]
,sharetype.st_desc [SHARE TYPE]
,sc_currency [CCY]
,sc_countryIssue [COUNTRY ISSUE]
,sc_ultimateParentCountryRisk [ULT PARENT COUNTRY OF RISK]
,convert(varchar, sc_emissionDate, 103) [EMISSION DATE]
,convert(varchar, sc_inceptionDate, 103) [INCEPTION DATE]
,convert(varchar, sc_lastNav, 103) [LAST NAV]
,convert(varchar, sc_expiryDate, 103) [EXPIRY DATE]
,sc_initialPrice [INITIAL PRICE]
,sc_accountingCode [ACCOUNTING CODE]
,case 
	when sc_hedged=1 then 'Yes'
	when sc_hedged=0 then 'No'
	else NULL
	END as [HEDGED]
,case 
	when sc_listed=1 then 'Yes'
	when sc_listed=0 then 'No'
	else NULL
	END as  [LISTED]
,sc_bloomberMarket [BLOOMBERG MARKET]
,sc_bloombedCode [BLOOMBERG CODE]
,sc_bloombedId [BLOOMBERG ID]
,sc_isinCode [ISIN CODE]
,sc_valorCode [VALOR CODE]
,sc_faCode [FUND ADMIN. CODE]
,sc_taCode [TRASFER AGENT CODE]
,sc_WKN [WKN CODE]
,convert(varchar, sc_date_business_year, 103)  [BUSINESS YEAR]
,sc_prospectus_code [PROSPECTUS CODE]	
	
	FROM tb_historyShareClass sc
	left join tb_dom_investor_type intype on intype.it_id=sc.sc_investorType
	left join tb_dom_share_type sharetype on sharetype.st_id= sc.sc_shareType
	left join tb_dom_share_status stat on stat.sc_s_id=sc.sc_status
		
	Where  (@shareclass_id = sc.sc_id) AND (
		@report_date between sc.sc_initialDate and sc.sc_endDate  OR (@report_date > sc.sc_initialDate and sc.sc_endDate is null)
					 
	)
) t2
 ORDER BY t2.[SHARE CLASS NAME]
)
GO
/****** Object:  Table [dbo].[tb_calendar]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_calendar](
	[id_dom_freq] [int] NOT NULL,
	[id_dom_val_date] [int] NOT NULL,
	[calendar_date] [date] NOT NULL,
 CONSTRAINT [PK_tb_calendar_1] PRIMARY KEY CLUSTERED 
(
	[id_dom_freq] ASC,
	[id_dom_val_date] ASC,
	[calendar_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_contract]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_contract](
	[id_contract] [int] NOT NULL,
 CONSTRAINT [PK_tb_contract] PRIMARY KEY CLUSTERED 
(
	[id_contract] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_country_distribution_shares]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_country_distribution_shares](
	[share_id] [int] NOT NULL,
	[iso_country_2] [nchar](2) NOT NULL,
	[local_representative] [int] NULL,
	[paying_agent] [int] NULL,
	[legal_support] [int] NULL,
	[language] [nchar](3) NOT NULL,
 CONSTRAINT [PK_tb_country_distribution_shares] PRIMARY KEY CLUSTERED 
(
	[share_id] ASC,
	[iso_country_2] ASC,
	[language] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_activityType]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_activityType](
	[at_id] [int] NOT NULL,
	[at_desc] [nvarchar](100) NULL,
	[at_entity] [int] NOT NULL,
 CONSTRAINT [PK_tb_dom_activityType] PRIMARY KEY CLUSTERED 
(
	[at_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_agreement_status]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_agreement_status](
	[a_s_id] [int] IDENTITY(1,1) NOT NULL,
	[a_s_desc] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tb_dom_agreement_status] PRIMARY KEY CLUSTERED 
(
	[a_s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_entity]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_entity](
	[entity_id] [int] IDENTITY(1,1) NOT NULL,
	[entity_desc] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tb_dom_entity] PRIMARY KEY CLUSTERED 
(
	[entity_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_fee]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_fee](
	[fee_id] [int] NOT NULL,
	[fee_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK__tb_dom_fee] PRIMARY KEY CLUSTERED 
(
	[fee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_fee_frequency]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_fee_frequency](
	[ff_id] [int] NOT NULL,
	[ff_desc] [nvarchar](100) NULL,
 CONSTRAINT [PK__tb_dom_fee_frequency] PRIMARY KEY CLUSTERED 
(
	[ff_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_fee_type]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_fee_type](
	[ft_id] [int] NOT NULL,
	[ft_desc] [nvarchar](50) NULL,
 CONSTRAINT [PK__tb_dom_feeType] PRIMARY KEY CLUSTERED 
(
	[ft_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_file_type]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_file_type](
	[filetype_id] [int] IDENTITY(1,1) NOT NULL,
	[filetype_desc] [nvarchar](max) NOT NULL,
	[filetype_entity] [int] NOT NULL,
 CONSTRAINT [PK_tb_dom_file_type] PRIMARY KEY CLUSTERED 
(
	[filetype_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_fund_admin_type]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_fund_admin_type](
	[fat_id] [int] IDENTITY(1,1) NOT NULL,
	[fat_desc] [varchar](100) NOT NULL,
	[fat_acronym] [nchar](5) NOT NULL,
 CONSTRAINT [PK__tb_dom_fund_admin_type] PRIMARY KEY CLUSTERED 
(
	[fat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_iso_country]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_iso_country](
	[iso_country_iso_2] [nchar](2) NOT NULL,
	[iso_country_desc] [nvarchar](100) NULL,
	[iso_country_3] [nchar](3) NULL,
 CONSTRAINT [PK_tb_dom_iso_country] PRIMARY KEY CLUSTERED 
(
	[iso_country_iso_2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_iso_currency]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_iso_currency](
	[iso_ccy_code] [nchar](3) NOT NULL,
	[iso_ccy_desc] [nvarchar](100) NULL,
	[iso_ccy_desc_entity] [nvarchar](100) NULL,
	[iso_ccy_numeric] [int] NULL,
 CONSTRAINT [PK_tb_dom_iso_currency] PRIMARY KEY CLUSTERED 
(
	[iso_ccy_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_languages]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_languages](
	[language_iso_3] [nchar](3) NOT NULL,
	[language_desc] [nvarchar](30) NULL,
 CONSTRAINT [PK_tb_dom_languages] PRIMARY KEY CLUSTERED 
(
	[language_iso_3] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_timeseries_provider]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_timeseries_provider](
	[id_provider] [int] IDENTITY(1,1) NOT NULL,
	[desc_provider] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tb_dom_ts_provider] PRIMARY KEY CLUSTERED 
(
	[id_provider] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dom_timeseries_type]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dom_timeseries_type](
	[id_ts] [int] IDENTITY(1,1) NOT NULL,
	[desc_ts] [nvarchar](max) NOT NULL,
	[entity_type] [int] NOT NULL,
 CONSTRAINT [PK_tb_dom_timeseries_type] PRIMARY KEY CLUSTERED 
(
	[id_ts] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_file]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_file](
	[file_id] [int] NOT NULL,
 CONSTRAINT [PK__tb_file] PRIMARY KEY CLUSTERED 
(
	[file_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fund]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fund](
	[f_id] [int] NOT NULL,
 CONSTRAINT [PK_tb_fund_1] PRIMARY KEY CLUSTERED 
(
	[f_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_fundSubFund]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_fundSubFund](
	[sf_id] [int] NOT NULL,
	[f_id] [int] NOT NULL,
	[fsf_startConnection] [datetime] NOT NULL,
	[fsf_endConnection] [datetime] NULL,
 CONSTRAINT [PK_tb_fundSubFund] PRIMARY KEY CLUSTERED 
(
	[sf_id] ASC,
	[fsf_startConnection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_historyContract]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_historyContract](
	[id_contract] [int] NOT NULL,
	[d_initialDateContr] [datetime] NOT NULL,
	[d_endDateInvContr] [datetime] NULL,
	[s_typeContr] [nvarchar](255) NULL,
	[s_subtypeContr] [nvarchar](255) NULL,
	[id_compContractor1] [int] NOT NULL,
	[id_compContractor2] [int] NOT NULL,
	[id_compMediator] [int] NULL,
 CONSTRAINT [PK_tb_historyContract] PRIMARY KEY CLUSTERED 
(
	[id_contract] ASC,
	[d_initialDateContr] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_historyInvAccount]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_historyInvAccount](
	[id_invAccount] [int] NOT NULL,
	[d_initialDateInvAcc] [datetime] NOT NULL,
	[d_endDateInvAcc] [datetime] NULL,
	[id_idInvAcc] [nvarchar](100) NOT NULL,
	[s_officialNameInvAcc] [nvarchar](255) NULL,
 CONSTRAINT [PK_tb_historyInvAccount] PRIMARY KEY CLUSTERED 
(
	[id_invAccount] ASC,
	[d_initialDateInvAcc] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_historyInvestor]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_historyInvestor](
	[id_inv] [int] NOT NULL,
	[d_initialDateInv] [datetime] NOT NULL,
	[d_endDateInv] [datetime] NULL,
	[id_idInv] [nvarchar](100) NOT NULL,
	[s_officialNameInv] [nvarchar](255) NULL,
 CONSTRAINT [PK_tb_historyInvestor] PRIMARY KEY CLUSTERED 
(
	[id_inv] ASC,
	[d_initialDateInv] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_investor]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_investor](
	[id_inv] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_inv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_investorAccount]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_investorAccount](
	[id_invAccount] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_invAccount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_invInvAccount]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_invInvAccount](
	[id_inv] [int] NOT NULL,
	[id_invAccount] [int] NOT NULL,
	[d_startConnectionInvInvAcc] [datetime] NOT NULL,
	[d_endConnectionInvInvAcc] [datetime] NULL,
 CONSTRAINT [PK_tb_invInvAccount] PRIMARY KEY CLUSTERED 
(
	[id_invAccount] ASC,
	[id_inv] ASC,
	[d_startConnectionInvInvAcc] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_invInvAccShareClass]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_invInvAccShareClass](
	[id_inv] [int] NOT NULL,
	[id_invAccount] [int] NOT NULL,
	[id_shareClass] [int] NOT NULL,
	[d_startConnectionInvInvAcc] [datetime] NOT NULL,
	[d_endConnectionInvInvAcc] [datetime] NULL,
 CONSTRAINT [PK_tb_invInvAccShareClass] PRIMARY KEY CLUSTERED 
(
	[id_invAccount] ASC,
	[id_inv] ASC,
	[id_shareClass] ASC,
	[d_startConnectionInvInvAcc] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_map_filefund]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_map_filefund](
	[file_id] [int] NOT NULL,
	[file_name] [nvarchar](max) NOT NULL,
	[file_extension] [nvarchar](5) NOT NULL,
	[doc_fundId] [int] NOT NULL,
	[doc_startConnection] [datetime] NOT NULL,
	[doc_endConnection] [datetime] NULL,
	[doc_filetype] [int] NOT NULL,
 CONSTRAINT [PK__tb_map_filefund] PRIMARY KEY CLUSTERED 
(
	[file_id] ASC,
	[doc_startConnection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_map_fileshareclass]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_map_fileshareclass](
	[file_id] [int] NOT NULL,
	[file_name] [nvarchar](max) NOT NULL,
	[file_extension] [nvarchar](5) NOT NULL,
	[doc_shareClassId] [int] NOT NULL,
	[doc_startConnection] [datetime] NOT NULL,
	[doc_endConnection] [datetime] NULL,
	[doc_filetype] [int] NOT NULL,
 CONSTRAINT [PK__tb_map_fileshareclass] PRIMARY KEY CLUSTERED 
(
	[file_id] ASC,
	[doc_startConnection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_map_filesubfund]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_map_filesubfund](
	[file_id] [int] NOT NULL,
	[file_name] [nvarchar](max) NOT NULL,
	[file_extension] [nvarchar](5) NOT NULL,
	[doc_subfundId] [int] NOT NULL,
	[doc_startConnection] [datetime] NOT NULL,
	[doc_endConnection] [datetime] NULL,
	[doc_filetype] [int] NOT NULL,
 CONSTRAINT [PK__tb_map_filesubfund] PRIMARY KEY CLUSTERED 
(
	[file_id] ASC,
	[doc_startConnection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_map_nav_frequency_valuation]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_map_nav_frequency_valuation](
	[id_dom_freq] [int] NOT NULL,
	[id_dom_val_date] [int] NOT NULL,
 CONSTRAINT [PK_tb_map_nav_frequency_valuation] PRIMARY KEY CLUSTERED 
(
	[id_dom_freq] ASC,
	[id_dom_val_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_serviceAgreement_shareclass]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_serviceAgreement_shareclass](
	[file_id] [int] NOT NULL,
	[file_name] [nvarchar](max) NOT NULL,
	[file_extension] [nvarchar](5) NOT NULL,
	[sa_shareclassId] [int] NOT NULL,
	[sa_activityType] [int] NOT NULL,
	[sa_contractDate] [datetime] NOT NULL,
	[sa_activationDate] [datetime] NOT NULL,
	[sa_expirationDate] [datetime] NULL,
	[sa_status] [int] NOT NULL,
	[sa_company] [int] NOT NULL,
 CONSTRAINT [PK__tb_serviceAgreement_shareclass] PRIMARY KEY CLUSTERED 
(
	[file_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_serviceAgreement_subfund]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_serviceAgreement_subfund](
	[file_id] [int] NOT NULL,
	[file_name] [nvarchar](max) NOT NULL,
	[file_extension] [nvarchar](5) NOT NULL,
	[sa_subfundId] [int] NOT NULL,
	[sa_activityType] [int] NOT NULL,
	[sa_contractDate] [datetime] NOT NULL,
	[sa_activationDate] [datetime] NOT NULL,
	[sa_expirationDate] [datetime] NULL,
	[sa_status] [int] NOT NULL,
	[sa_company] [int] NOT NULL,
 CONSTRAINT [PK__tb_serviceAgreement_subfund] PRIMARY KEY CLUSTERED 
(
	[file_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_shareClass]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_shareClass](
	[id_sc] [int] NOT NULL,
 CONSTRAINT [PK_tb_shareClass_1] PRIMARY KEY CLUSTERED 
(
	[id_sc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_shareclass_ts_test]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_shareclass_ts_test](
	[date_ts] [datetime] NOT NULL,
	[id_ts] [int] NOT NULL,
	[value_ts] [decimal](18, 9) NULL,
	[currency_ts] [nchar](3) NOT NULL,
	[provider_ts] [int] NOT NULL,
	[id_shareclass] [int] NOT NULL,
	[file_name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__tb_shareclass_ts_test] PRIMARY KEY CLUSTERED 
(
	[date_ts] ASC,
	[id_ts] ASC,
	[currency_ts] ASC,
	[provider_ts] ASC,
	[id_shareclass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_subFund]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_subFund](
	[id_subFund] [int] NOT NULL,
 CONSTRAINT [PK_tb_subFund_1] PRIMARY KEY CLUSTERED 
(
	[id_subFund] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_subFundShareClass]    Script Date: 10-Jan-21 11:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_subFundShareClass](
	[sc_id] [int] NOT NULL,
	[sf_id] [int] NULL,
	[sfsc_startConnection] [datetime] NOT NULL,
	[sfsc_endConnection] [datetime] NULL,
 CONSTRAINT [PK_tb_shareClass] PRIMARY KEY CLUSTERED 
(
	[sc_id] ASC,
	[sfsc_startConnection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-01-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-02-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-03-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-01' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-04-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-26' AS Date))
GO
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-05-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-06-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-01' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-07-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-08-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-01' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-09-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-01' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-15' AS Date))
GO
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-10-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-11-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-01' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (1, 9, CAST(N'2020-12-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-01-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-01-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-01-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-01-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-02-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-02-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-02-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-02-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-03-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-03-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-03-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-03-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-03-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-04-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-04-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-04-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-05-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-05-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-05-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-05-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-06-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-06-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-06-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-06-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-07-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-07-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-07-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-07-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-08-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-08-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-08-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-08-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-08-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-09-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-09-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-09-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-09-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-10-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-10-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-10-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-10-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-11-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-11-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-11-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-11-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-11-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-12-07' AS Date))
GO
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-12-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-12-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 1, CAST(N'2020-12-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-01-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-01-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-01-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-01-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-01-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-02-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-02-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-02-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-02-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-03-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-03-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-03-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-03-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-04-01' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-04-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-04-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-04-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-04-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-05-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-05-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-05-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-05-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-06-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-06-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-06-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-06-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-07-01' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-07-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-07-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-07-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-07-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-08-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-08-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-08-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-08-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-09-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-09-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-09-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-09-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-09-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-10-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-10-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-10-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-10-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-11-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-11-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-11-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-11-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-12-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-12-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-12-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-12-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 3, CAST(N'2020-12-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-01-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-01-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-01-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-01-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-01-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-02-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-02-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-02-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-02-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-03-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-03-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-03-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-03-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-04-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-04-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-04-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-04-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-04-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-05-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-05-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-05-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-06-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-06-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-06-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-06-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-07-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-07-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-07-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-07-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-07-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-08-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-08-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-08-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-08-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-09-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-09-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-09-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-09-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-10-01' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-10-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-10-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-10-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-10-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-11-05' AS Date))
GO
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-11-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-11-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-11-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-12-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-12-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-12-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 4, CAST(N'2020-12-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-01-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-01-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-01-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-01-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-01-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-02-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-02-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-02-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-02-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-03-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-03-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-03-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-03-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-04-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-04-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-04-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-05-08' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-05-15' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-05-22' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-05-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-06-05' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-06-12' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-06-19' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-06-26' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-07-03' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-07-10' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-07-17' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-07-24' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-07-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-08-07' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-08-14' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-08-21' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-08-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-09-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-09-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-09-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-09-25' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-10-02' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-10-09' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-10-16' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-10-23' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-10-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-11-06' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-11-13' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-11-20' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-11-27' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-12-04' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-12-11' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (2, 5, CAST(N'2020-12-18' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-01-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-02-28' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-03-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-04-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-05-29' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-06-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-07-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-08-31' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-09-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-10-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-11-30' AS Date))
INSERT [dbo].[tb_calendar] ([id_dom_freq], [id_dom_val_date], [calendar_date]) VALUES (4, 8, CAST(N'2020-12-31' AS Date))
GO
INSERT [dbo].[tb_companies] ([c_id], [c_name], [c_iso3_acronym]) VALUES (1, N'Pharus Management Lux SA', N'PML')
INSERT [dbo].[tb_companies] ([c_id], [c_name], [c_iso3_acronym]) VALUES (2, N'Edmond de Rothschild Asset Management (Luxembourg)', N'EDR')
INSERT [dbo].[tb_companies] ([c_id], [c_name], [c_iso3_acronym]) VALUES (3, N'UBS Fund Services (Luxembourg) S.A.', N'UBS')
INSERT [dbo].[tb_companies] ([c_id], [c_name], [c_iso3_acronym]) VALUES (4, N'CACEIS Bank Luxembourg', N'CAC')
INSERT [dbo].[tb_companies] ([c_id], [c_name], [c_iso3_acronym]) VALUES (5, N'Northern Trust Global Services SE', N'NTS')
GO
INSERT [dbo].[tb_country_distribution_shares] ([share_id], [iso_country_2], [local_representative], [paying_agent], [legal_support], [language]) VALUES (94, N'IT', NULL, NULL, NULL, N'ITA')
INSERT [dbo].[tb_country_distribution_shares] ([share_id], [iso_country_2], [local_representative], [paying_agent], [legal_support], [language]) VALUES (94, N'LU', NULL, NULL, NULL, N'ENG')
INSERT [dbo].[tb_country_distribution_shares] ([share_id], [iso_country_2], [local_representative], [paying_agent], [legal_support], [language]) VALUES (95, N'IT', NULL, NULL, NULL, N'ITA')
INSERT [dbo].[tb_country_distribution_shares] ([share_id], [iso_country_2], [local_representative], [paying_agent], [legal_support], [language]) VALUES (95, N'LU', NULL, NULL, NULL, N'ENG')
INSERT [dbo].[tb_country_distribution_shares] ([share_id], [iso_country_2], [local_representative], [paying_agent], [legal_support], [language]) VALUES (160, N'IT', NULL, NULL, NULL, N'ITA')
INSERT [dbo].[tb_country_distribution_shares] ([share_id], [iso_country_2], [local_representative], [paying_agent], [legal_support], [language]) VALUES (160, N'LU', NULL, NULL, NULL, N'ENG')
INSERT [dbo].[tb_country_distribution_shares] ([share_id], [iso_country_2], [local_representative], [paying_agent], [legal_support], [language]) VALUES (164, N'IT', NULL, NULL, NULL, N'ITA')
INSERT [dbo].[tb_country_distribution_shares] ([share_id], [iso_country_2], [local_representative], [paying_agent], [legal_support], [language]) VALUES (164, N'LU', NULL, NULL, NULL, N'ENG')
GO
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (1, N'Management Company Agreement', 1)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (2, N'Investment Management Agreement', 2)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (3, N'Distribution Agreeement', 3)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (4, N'ISDA', 2)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (5, N'Giveup Agreement', 2)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (6, N'Hedging Contract', 3)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (7, N'Credit Facility And Collateral Agreement', 1)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (8, N'Central Administration Agreement', 1)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (9, N'Depositary Bank Agreement', 1)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (10, N'Investment Advisory Agreement', 2)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (11, N'Introducer', 3)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (12, N'EMIR', 2)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (13, N'Fiduciary Deposit Framework Agreement', 1)
INSERT [dbo].[tb_dom_activityType] ([at_id], [at_desc], [at_entity]) VALUES (14, N'Private Placement Agreement', 3)
GO
SET IDENTITY_INSERT [dbo].[tb_dom_agreement_status] ON 

INSERT [dbo].[tb_dom_agreement_status] ([a_s_id], [a_s_desc]) VALUES (1, N'Active')
INSERT [dbo].[tb_dom_agreement_status] ([a_s_id], [a_s_desc]) VALUES (2, N'Inactive')
SET IDENTITY_INSERT [dbo].[tb_dom_agreement_status] OFF
GO
INSERT [dbo].[tb_dom_calculationDate] ([cd_id], [cd_desc]) VALUES (1, N'Prior')
INSERT [dbo].[tb_dom_calculationDate] ([cd_id], [cd_desc]) VALUES (2, N'Current')
GO
INSERT [dbo].[tb_dom_cesrClass] ([cc_id], [c_desc]) VALUES (1, N'Market Fund')
INSERT [dbo].[tb_dom_cesrClass] ([cc_id], [c_desc]) VALUES (2, N'Absolute Return')
INSERT [dbo].[tb_dom_cesrClass] ([cc_id], [c_desc]) VALUES (3, N'Total Return')
INSERT [dbo].[tb_dom_cesrClass] ([cc_id], [c_desc]) VALUES (4, N'Lyfe Cycle Fund')
INSERT [dbo].[tb_dom_cesrClass] ([cc_id], [c_desc]) VALUES (5, N'Structured Fund')
GO
INSERT [dbo].[tb_dom_company_type] ([ct_id], [ct_desc], [ct_acronym]) VALUES (1, N'Public limited company', N'S.A.')
INSERT [dbo].[tb_dom_company_type] ([ct_id], [ct_desc], [ct_acronym]) VALUES (2, N'European company', N'S.E.')
INSERT [dbo].[tb_dom_company_type] ([ct_id], [ct_desc], [ct_acronym]) VALUES (3, N'Private limited liability company', N'S.à r.l.')
INSERT [dbo].[tb_dom_company_type] ([ct_id], [ct_desc], [ct_acronym]) VALUES (4, N'Partnership limited by shares', N'S.C.A.')
INSERT [dbo].[tb_dom_company_type] ([ct_id], [ct_desc], [ct_acronym]) VALUES (5, N'Special limited partnership', N'S.C.Sp.')
INSERT [dbo].[tb_dom_company_type] ([ct_id], [ct_desc], [ct_acronym]) VALUES (6, N'Limited partnership', N'S.C.S.')
INSERT [dbo].[tb_dom_company_type] ([ct_id], [ct_desc], [ct_acronym]) VALUES (7, N'Cooperative company organized as a public limited company', N'S.Co S.A.')
GO
INSERT [dbo].[tb_dom_cssf_geographical_focus] ([gf_id], [gf_desc]) VALUES (1, N'Africa')
INSERT [dbo].[tb_dom_cssf_geographical_focus] ([gf_id], [gf_desc]) VALUES (2, N'Asia & Pacific')
INSERT [dbo].[tb_dom_cssf_geographical_focus] ([gf_id], [gf_desc]) VALUES (3, N'Europe')
INSERT [dbo].[tb_dom_cssf_geographical_focus] ([gf_id], [gf_desc]) VALUES (4, N'North America')
INSERT [dbo].[tb_dom_cssf_geographical_focus] ([gf_id], [gf_desc]) VALUES (5, N'Central and South America')
INSERT [dbo].[tb_dom_cssf_geographical_focus] ([gf_id], [gf_desc]) VALUES (6, N'Multiple Regions')
GO
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (1, N'Equity')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (2, N'IG Bond')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (3, N'HY Bond')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (4, N'General Bond')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (5, N'Convertible Bond')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (6, N'MM instruments')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (7, N'ABS/MBS')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (8, N'Foreign Exchange')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (9, N'Commodities')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (10, N'Volatility')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (11, N'Mixed Bond/Equity')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (12, N'Mixed others')
INSERT [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id], [pac_desc]) VALUES (13, N'Others')
GO
INSERT [dbo].[tb_dom_derivMarket] ([dm_id], [dm_desc]) VALUES (1, N'OTC')
INSERT [dbo].[tb_dom_derivMarket] ([dm_id], [dm_desc]) VALUES (2, N'Listed')
INSERT [dbo].[tb_dom_derivMarket] ([dm_id], [dm_desc]) VALUES (3, N'Both')
GO
INSERT [dbo].[tb_dom_derivPurpose] ([dp_id], [dp_desc]) VALUES (1, N'Hedging')
INSERT [dbo].[tb_dom_derivPurpose] ([dp_id], [dp_desc]) VALUES (2, N'Speculation')
INSERT [dbo].[tb_dom_derivPurpose] ([dp_id], [dp_desc]) VALUES (3, N'Both')
GO
SET IDENTITY_INSERT [dbo].[tb_dom_entity] ON 

INSERT [dbo].[tb_dom_entity] ([entity_id], [entity_desc]) VALUES (1, N'Fund')
INSERT [dbo].[tb_dom_entity] ([entity_id], [entity_desc]) VALUES (2, N'Subfund')
INSERT [dbo].[tb_dom_entity] ([entity_id], [entity_desc]) VALUES (3, N'Shareclass')
SET IDENTITY_INSERT [dbo].[tb_dom_entity] OFF
GO
INSERT [dbo].[tb_dom_f_status] ([st_f_id], [st_f_desc]) VALUES (1, N'Active')
INSERT [dbo].[tb_dom_f_status] ([st_f_id], [st_f_desc]) VALUES (2, N'Inactive - Liquidated')
INSERT [dbo].[tb_dom_f_status] ([st_f_id], [st_f_desc]) VALUES (3, N'Inactive - Closed')
INSERT [dbo].[tb_dom_f_status] ([st_f_id], [st_f_desc]) VALUES (4, N'Inactive - To be launched')
INSERT [dbo].[tb_dom_f_status] ([st_f_id], [st_f_desc]) VALUES (5, N'Inactive - Merged')
GO
INSERT [dbo].[tb_dom_fee] ([fee_id], [fee_desc]) VALUES (1, N'Risk')
INSERT [dbo].[tb_dom_fee] ([fee_id], [fee_desc]) VALUES (2, N'Management Company')
GO
INSERT [dbo].[tb_dom_fee_frequency] ([ff_id], [ff_desc]) VALUES (1, N'Daily')
INSERT [dbo].[tb_dom_fee_frequency] ([ff_id], [ff_desc]) VALUES (2, N'Weekly')
INSERT [dbo].[tb_dom_fee_frequency] ([ff_id], [ff_desc]) VALUES (3, N'Weekly and last Monthly nav')
INSERT [dbo].[tb_dom_fee_frequency] ([ff_id], [ff_desc]) VALUES (4, N'Monthly ')
INSERT [dbo].[tb_dom_fee_frequency] ([ff_id], [ff_desc]) VALUES (5, N'Fortnightly')
INSERT [dbo].[tb_dom_fee_frequency] ([ff_id], [ff_desc]) VALUES (6, N'Fortnightly and last Monthly nav')
INSERT [dbo].[tb_dom_fee_frequency] ([ff_id], [ff_desc]) VALUES (7, N'Quarterly')
INSERT [dbo].[tb_dom_fee_frequency] ([ff_id], [ff_desc]) VALUES (8, N'Semi-annually')
INSERT [dbo].[tb_dom_fee_frequency] ([ff_id], [ff_desc]) VALUES (9, N'Annually')
GO
INSERT [dbo].[tb_dom_fee_type] ([ft_id], [ft_desc]) VALUES (1, N'Fixed Amount')
INSERT [dbo].[tb_dom_fee_type] ([ft_id], [ft_desc]) VALUES (2, N'% AuM')
GO
SET IDENTITY_INSERT [dbo].[tb_dom_file_type] ON 

INSERT [dbo].[tb_dom_file_type] ([filetype_id], [filetype_desc], [filetype_entity]) VALUES (2, N'Prospectus', 1)
INSERT [dbo].[tb_dom_file_type] ([filetype_id], [filetype_desc], [filetype_entity]) VALUES (3, N'KIID - ENG', 3)
INSERT [dbo].[tb_dom_file_type] ([filetype_id], [filetype_desc], [filetype_entity]) VALUES (4, N'Pricing Policy', 1)
INSERT [dbo].[tb_dom_file_type] ([filetype_id], [filetype_desc], [filetype_entity]) VALUES (5, N'Official NAV Report', 2)
INSERT [dbo].[tb_dom_file_type] ([filetype_id], [filetype_desc], [filetype_entity]) VALUES (6, N'KIID - IT', 3)
INSERT [dbo].[tb_dom_file_type] ([filetype_id], [filetype_desc], [filetype_entity]) VALUES (7, N'KIID - DE', 3)
INSERT [dbo].[tb_dom_file_type] ([filetype_id], [filetype_desc], [filetype_entity]) VALUES (8, N'KIID - FR', 3)
INSERT [dbo].[tb_dom_file_type] ([filetype_id], [filetype_desc], [filetype_entity]) VALUES (9, N'KIID - IT/CH', 3)
INSERT [dbo].[tb_dom_file_type] ([filetype_id], [filetype_desc], [filetype_entity]) VALUES (10, N'Circular Resolution - Prospectus changes', 1)
SET IDENTITY_INSERT [dbo].[tb_dom_file_type] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_dom_fund_admin_type] ON 

INSERT [dbo].[tb_dom_fund_admin_type] ([fat_id], [fat_desc], [fat_acronym]) VALUES (1, N'CACEIS', N'CAC  ')
INSERT [dbo].[tb_dom_fund_admin_type] ([fat_id], [fat_desc], [fat_acronym]) VALUES (2, N'Northern Trust', N'UBS  ')
INSERT [dbo].[tb_dom_fund_admin_type] ([fat_id], [fat_desc], [fat_acronym]) VALUES (3, N'Edmond de Rothschild', N'ROT  ')
SET IDENTITY_INSERT [dbo].[tb_dom_fund_admin_type] OFF
GO
INSERT [dbo].[tb_dom_globalExposure] ([ge_id], [ge_desc]) VALUES (1, N'VaR Absolute')
INSERT [dbo].[tb_dom_globalExposure] ([ge_id], [ge_desc]) VALUES (2, N'Var Relative')
INSERT [dbo].[tb_dom_globalExposure] ([ge_id], [ge_desc]) VALUES (3, N'Commitment')
INSERT [dbo].[tb_dom_globalExposure] ([ge_id], [ge_desc]) VALUES (4, N'AIF Gross Net')
GO
INSERT [dbo].[tb_dom_investor_type] ([it_id], [it_desc]) VALUES (1, N'Retail')
INSERT [dbo].[tb_dom_investor_type] ([it_id], [it_desc]) VALUES (2, N'Qualified')
INSERT [dbo].[tb_dom_investor_type] ([it_id], [it_desc]) VALUES (3, N'Professional')
INSERT [dbo].[tb_dom_investor_type] ([it_id], [it_desc]) VALUES (4, N'Institutional')
INSERT [dbo].[tb_dom_investor_type] ([it_id], [it_desc]) VALUES (5, N'Well Informed')
INSERT [dbo].[tb_dom_investor_type] ([it_id], [it_desc]) VALUES (6, N'Reserved')
GO
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'0 ', N'AFRICAN REGION (Fund)                                                                               ', N'X00')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'1 ', N'ASIAN PACIFIC REGION (Fund)                                                                         ', N'X01')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'10', N'MIDDLE EAST REGION (Fund)                                                                           ', N'X10')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'11', N'NORTH AMERICAN REGION (Fund)                                                                        ', N'X11')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'12', N'SUPRA NATIONAL                                                                                      ', N'X12')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'13', N'MIDDLE EAST NORTH AFRICA REGION (Fund)                                                              ', N'X13')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'14', N'WEST EUROPE (Fund)                                                                                  ', N'X14')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'15', N'NORTH EUROPE (Fund)                                                                                 ', N'X15')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'16', N'GREATER CHINA (Fund)                                                                                ', N'X16')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'17', N'Gulf Cooperation Council                                                                            ', N'GCC')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'18', N'BRIC                                                                                                ', N'X18')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'2 ', N'ASIAN PACIFIC REGION EX JAPAN (Fund)                                                                ', N'X02')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'3 ', N'EASTERN EUROPEAN REGION (Fund)                                                                      ', N'X03')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'4 ', N'EUROPEAN REG. EX UK (Fund)                                                                          ', N'X04')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'5 ', N'EUROPEAN REGION (Fund)                                                                              ', N'X05')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'6 ', N'EUROZONE (Fund)                                                                                     ', N'X06')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'7 ', N'INTERNATIONAL (Fund)                                                                                ', N'X07')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'8 ', N'OCEANIA REGION (Fund)                                                                               ', N'X08')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'9 ', N'LATIN AMERICAN REGION (Fund)                                                                        ', N'X09')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AD', N'ANDORRA                                                                                             ', N'AND')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AE', N'UNITED ARAB EMIRATES                                                                                ', N'ARE')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AF', N'AFGHANISTAN                                                                                         ', N'AFG')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AG', N'ANTIGUA AND BARBUDA                                                                                 ', N'ATG')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AI', N'ANGUILLA                                                                                            ', N'AIA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AL', N'ALBANIA                                                                                             ', N'ALB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AM', N'ARMENIA                                                                                             ', N'ARM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AN', N'NETHERLANDS ANTILLES                                                                                ', N'ANT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AO', N'ANGOLA                                                                                              ', N'AGO')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AQ', N'ANTARCTICA                                                                                          ', N'ATA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AR', N'ARGENTINA                                                                                           ', N'ARG')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AS', N'AMERICAN SAMOA                                                                                      ', N'ASM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AT', N'AUSTRIA                                                                                             ', N'AUT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AU', N'AUSTRALIA                                                                                           ', N'AUS')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AW', N'ARUBA                                                                                               ', N'ABW')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AX', N'ALAND ISLANDS                                                                                       ', N'ALA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'AZ', N'AZERBAIJAN                                                                                          ', N'AZE')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BA', N'BOSNIA AND HERZEGOVINA                                                                              ', N'BIH')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BB', N'BARBADOS                                                                                            ', N'BRB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BD', N'BANGLADESH                                                                                          ', N'BGD')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BE', N'BELGIUM                                                                                             ', N'BEL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BF', N'BURKINA FASO                                                                                        ', N'BFA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BG', N'BULGARIA                                                                                            ', N'BGR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BH', N'BAHRAIN                                                                                             ', N'BHR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BI', N'BURUNDI                                                                                             ', N'BDI')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BJ', N'BENIN                                                                                               ', N'BEN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BL', N'SAINT BARTHÉLEMY                                                                                    ', N'BLM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BM', N'BERMUDA                                                                                             ', N'BMU')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BN', N'BRUNEI DARUSSALAM                                                                                   ', N'BRN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BO', N'BOLIVIA PLURINATIONAL STATE OF                                                                      ', N'BOL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BQ', N'BONAIRE SAINT EUSTATIUS AND SABA                                                                    ', N'BES')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BR', N'BRAZIL                                                                                              ', N'BRA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BS', N'BAHAMAS                                                                                             ', N'BHS')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BT', N'BHUTAN                                                                                              ', N'BTN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BV', N'BOUVET ISLAND                                                                                       ', N'BVT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BW', N'BOTSWANA                                                                                            ', N'BWA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BY', N'BELARUS                                                                                             ', N'BLR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'BZ', N'BELIZE                                                                                              ', N'BLZ')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CA', N'CANADA                                                                                              ', N'CAN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CC', N'COCOS (KEELING) ISLANDS                                                                             ', N'CCK')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CD', N'CONGO THE DEMOCRATIC REPUBLIC OF THE                                                                ', N'COD')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CF', N'CENTRAL AFRICAN REPUBLIC                                                                            ', N'CAF')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CG', N'CONGO                                                                                               ', N'COG')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CH', N'SWITZERLAND                                                                                         ', N'CHE')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CI', N'Côte d Ivoire                                                                                       ', N'CIV')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CK', N'COOK ISLANDS                                                                                        ', N'COK')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CL', N'CHILE                                                                                               ', N'CHL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CM', N'CAMEROON                                                                                            ', N'CMR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CN', N'CHINA                                                                                               ', N'CHN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CO', N'COLOMBIA                                                                                            ', N'COL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CP', N'Clipperton Island                                                                                   ', N'CPT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CR', N'COSTA RICA                                                                                          ', N'CRI')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CU', N'CUBA                                                                                                ', N'CUB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CV', N'CAPE VERDE                                                                                          ', N'CPV')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CW', N'CURAÇAO                                                                                             ', N'CUW')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CX', N'CHRISTMAS ISLAND                                                                                    ', N'CXR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CY', N'CYPRUS                                                                                              ', N'CYP')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'CZ', N'CZECH REPUBLIC                                                                                      ', N'CZE')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'DE', N'GERMANY                                                                                             ', N'DEU')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'DJ', N'DJIBOUTI                                                                                            ', N'DJI')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'DK', N'DENMARK                                                                                             ', N'DNK')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'DM', N'DOMINICA                                                                                            ', N'DMA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'DO', N'DOMINICAN REPUBLIC                                                                                  ', N'DOM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'DZ', N'ALGERIA                                                                                             ', N'DZA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'EC', N'ECUADOR                                                                                             ', N'ECU')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'EE', N'ESTONIA                                                                                             ', N'EST')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'EG', N'EGYPT                                                                                               ', N'EGY')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'EH', N'WESTERN SAHARA                                                                                      ', N'ESH')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'ER', N'ERITREA                                                                                             ', N'ERI')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'ES', N'SPAIN                                                                                               ', N'ESP')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'ET', N'ETHIOPIA                                                                                            ', N'ETH')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'FI', N'FINLAND                                                                                             ', N'FIN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'FJ', N'FIJI                                                                                                ', N'FJI')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'FK', N'FALKLAND ISLANDS (MALVINAS)                                                                         ', N'FLK')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'FM', N'MICRONESIA FEDERATED STATES OF                                                                      ', N'FSM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'FO', N'FAROE ISLANDS                                                                                       ', N'FRO')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'FR', N'FRANCE                                                                                              ', N'FRA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GA', N'GABON                                                                                               ', N'GAB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GB', N'UNITED KINGDOM                                                                                      ', N'GBR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GD', N'GRENADA                                                                                             ', N'GRD')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GE', N'GEORGIA                                                                                             ', N'GEO')
GO
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GF', N'FRENCH GUIANA                                                                                       ', N'GUF')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GG', N'GUERNSEY                                                                                            ', N'GGY')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GH', N'GHANA                                                                                               ', N'GHA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GI', N'GIBRALTAR                                                                                           ', N'GIB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GL', N'GREENLAND                                                                                           ', N'GRL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GM', N'GAMBIA                                                                                              ', N'GMB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GN', N'GUINEA                                                                                              ', N'GIN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GP', N'GUADELOUPE                                                                                          ', N'GLP')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GQ', N'EQUATORIAL GUINEA                                                                                   ', N'GNQ')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GR', N'GREECE                                                                                              ', N'GRC')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GS', N'SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS                                                        ', N'SGS')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GT', N'GUATEMALA                                                                                           ', N'GTM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GU', N'GUAM                                                                                                ', N'GUM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GW', N'GUINEA-BISSAU                                                                                       ', N'GNB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'GY', N'GUYANA                                                                                              ', N'GUY')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'HK', N'HONG KONG                                                                                           ', N'HKG')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'HM', N'HEARD ISLAND AND MCDONALD ISLANDS                                                                   ', N'HMD')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'HN', N'HONDURAS                                                                                            ', N'HND')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'HR', N'CROATIA                                                                                             ', N'HRV')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'HT', N'HAITI                                                                                               ', N'HTI')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'HU', N'HUNGARY                                                                                             ', N'HUN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'ID', N'INDONESIA                                                                                           ', N'IDN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'IE', N'IRELAND                                                                                             ', N'IRL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'IL', N'ISRAEL                                                                                              ', N'ISR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'IM', N'ISLE OF MAN                                                                                         ', N'IMN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'IN', N'INDIA                                                                                               ', N'IND')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'IO', N'BRITISH INDIAN OCEAN TERRITORY                                                                      ', N'IOT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'IQ', N'IRAQ                                                                                                ', N'IRQ')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'IR', N'IRAN ISLAMIC REPUBLIC OF                                                                            ', N'IRN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'IS', N'ICELAND                                                                                             ', N'ISL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'IT', N'ITALY                                                                                               ', N'ITA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'JE', N'JERSEY                                                                                              ', N'JEY')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'JM', N'JAMAICA                                                                                             ', N'JAM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'JO', N'JORDAN                                                                                              ', N'JOR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'JP', N'JAPAN                                                                                               ', N'JPN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'KE', N'KENYA                                                                                               ', N'KEN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'KG', N'KYRGYZSTAN                                                                                          ', N'KGZ')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'KH', N'CAMBODIA                                                                                            ', N'KHM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'KI', N'KIRIBATI                                                                                            ', N'KIR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'KM', N'COMOROS                                                                                             ', N'COM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'KN', N'SAINT KITTS AND NEVIS                                                                               ', N'KNA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'KP', N'KOREA DEMOCRATIC PEOPLE REPUBLIC OF                                                                 ', N'PRK')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'KR', N'KOREA REPUBLIC OF                                                                                   ', N'KOR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'KW', N'KUWAIT                                                                                              ', N'KWT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'KY', N'CAYMAN ISLANDS                                                                                      ', N'CYM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'KZ', N'KAZAKHSTAN                                                                                          ', N'KAZ')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'LA', N'LAO PEOPLE Democratic Republic THE                                                                  ', N'LAO')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'LB', N'LEBANON                                                                                             ', N'LBN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'LC', N'SAINT LUCIA                                                                                         ', N'LCA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'LI', N'LIECHTENSTEIN                                                                                       ', N'LIE')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'LK', N'SRI LANKA                                                                                           ', N'LKA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'LR', N'LIBERIA                                                                                             ', N'LBR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'LS', N'LESOTHO                                                                                             ', N'LSO')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'LT', N'LITHUANIA                                                                                           ', N'LTU')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'LU', N'LUXEMBOURG                                                                                          ', N'LUX')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'LV', N'LATVIA                                                                                              ', N'LVA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'LY', N'LIBYAN ARAB JAMAHIRIYA                                                                              ', N'LBY')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MA', N'MOROCCO                                                                                             ', N'MAR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MC', N'MONACO                                                                                              ', N'MCO')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MD', N'MOLDOVA REPUBLIC OF                                                                                 ', N'MDA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'ME', N'MONTENEGRO                                                                                          ', N'MNE')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MF', N'SAINT MARTIN (FRENCH PART)                                                                          ', N'MAF')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MG', N'MADAGASCAR                                                                                          ', N'MDG')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MH', N'MARSHALL ISLANDS                                                                                    ', N'MHL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MK', N'MACEDONIA THE FORMER YUGOSLAV REPUBLIC OF                                                           ', N'MKD')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'ML', N'MALI                                                                                                ', N'MLI')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MM', N'MYANMAR                                                                                             ', N'MMR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MN', N'MONGOLIA                                                                                            ', N'MNG')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MO', N'MACAO                                                                                               ', N'MAC')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MP', N'NORTHERN MARIANA ISLANDS                                                                            ', N'MNP')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MQ', N'MARTINIQUE                                                                                          ', N'MTQ')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MR', N'MAURITANIA                                                                                          ', N'MRT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MS', N'MONTSERRAT                                                                                          ', N'MSR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MT', N'MALTA                                                                                               ', N'MLT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MU', N'MAURITIUS                                                                                           ', N'MUS')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MV', N'MALDIVES                                                                                            ', N'MDV')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MW', N'MALAWI                                                                                              ', N'MWI')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MX', N'MEXICO                                                                                              ', N'MEX')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MY', N'MALAYSIA                                                                                            ', N'MYS')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'MZ', N'MOZAMBIQUE                                                                                          ', N'MOZ')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NA', N'NAMIBIA                                                                                             ', N'NAM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NC', N'NEW CALEDONIA                                                                                       ', N'NCL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NE', N'NIGER                                                                                               ', N'NER')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NF', N'NORFOLK ISLAND                                                                                      ', N'NFK')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NG', N'NIGERIA                                                                                             ', N'NGA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NI', N'NICARAGUA                                                                                           ', N'NIC')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NL', N'NETHERLANDS                                                                                         ', N'NLD')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NO', N'NORWAY                                                                                              ', N'NOR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NP', N'NEPAL                                                                                               ', N'NPL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NR', N'NAURU                                                                                               ', N'NRU')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NU', N'NIUE                                                                                                ', N'NIU')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'NZ', N'NEW ZEALAND                                                                                         ', N'NZL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'OM', N'OMAN                                                                                                ', N'OMN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PA', N'PANAMA                                                                                              ', N'PAN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PE', N'PERU                                                                                                ', N'PER')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PF', N'FRENCH POLYNESIA                                                                                    ', N'PYF')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PG', N'PAPUA NEW GUINEA                                                                                    ', N'PNG')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PH', N'PHILIPPINES                                                                                         ', N'PHL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PK', N'PAKISTAN                                                                                            ', N'PAK')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PL', N'POLAND                                                                                              ', N'POL')
GO
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PM', N'SAINT PIERRE AND MIQUELON                                                                           ', N'SPM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PN', N'PITCAIRN                                                                                            ', N'PCN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PR', N'PUERTO RICO                                                                                         ', N'PRI')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PS', N'PALESTINIAN TERRITORY OCCUPIED                                                                      ', N'PSE')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PT', N'PORTUGAL                                                                                            ', N'PRT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PW', N'PALAU                                                                                               ', N'PLW')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'PY', N'PARAGUAY                                                                                            ', N'PRY')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'QA', N'QATAR                                                                                               ', N'QAT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'RE', N'RÉUNION                                                                                             ', N'REU')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'RO', N'ROMANIA                                                                                             ', N'ROU')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'RS', N'SERBIA                                                                                              ', N'SRB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'RU', N'RUSSIAN FEDERATION                                                                                  ', N'RUS')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'RW', N'RWANDA                                                                                              ', N'RWA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SA', N'SAUDI ARABIA                                                                                        ', N'SAU')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SB', N'SOLOMON ISLANDS                                                                                     ', N'SLB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SC', N'SEYCHELLES                                                                                          ', N'SYC')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SD', N'SUDAN                                                                                               ', N'SDN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SE', N'SWEDEN                                                                                              ', N'SWE')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SG', N'SINGAPORE                                                                                           ', N'SGP')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SH', N'SAINT HELENA ASCENSION AND TRISTAN DA CUNHA                                                         ', N'SHN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SI', N'SLOVENIA                                                                                            ', N'SVN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SJ', N'SVALBARD AND JAN MAYEN                                                                              ', N'SJM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SK', N'SLOVAKIA                                                                                            ', N'SVK')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SL', N'SIERRA LEONE                                                                                        ', N'SLE')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SM', N'SAN MARINO                                                                                          ', N'SMR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SN', N'SENEGAL                                                                                             ', N'SEN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SO', N'SOMALIA                                                                                             ', N'SOM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SR', N'SURINAME                                                                                            ', N'SUR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SS', N'South Sudan                                                                                         ', N'SSD')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'ST', N'SAO TOME AND PRINCIPE                                                                               ', N'STP')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SV', N'EL SALVADOR                                                                                         ', N'SLV')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SX', N'SINT MAARTEN (DUTCH PART)                                                                           ', N'SXM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SY', N'SYRIAN ARAB REPUBLIC                                                                                ', N'SYR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'SZ', N'SWAZILAND                                                                                           ', N'SWZ')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TC', N'TURKS AND CAICOS ISLANDS                                                                            ', N'TCA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TD', N'CHAD                                                                                                ', N'TCD')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TF', N'FRENCH SOUTHERN TERRITORIES                                                                         ', N'ATF')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TG', N'TOGO                                                                                                ', N'TGO')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TH', N'THAILAND                                                                                            ', N'THA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TJ', N'TAJIKISTAN                                                                                          ', N'TJK')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TK', N'TOKELAU                                                                                             ', N'TKL')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TL', N'TIMOR-LESTE                                                                                         ', N'TLS')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TM', N'TURKMENISTAN                                                                                        ', N'TKM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TN', N'TUNISIA                                                                                             ', N'TUN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TO', N'TONGA                                                                                               ', N'TON')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TR', N'TURKEY                                                                                              ', N'TUR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TT', N'TRINIDAD AND TOBAGO                                                                                 ', N'TTO')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TV', N'TUVALU                                                                                              ', N'TUV')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TW', N'TAIWAN PROVINCE OF CHINA                                                                            ', N'TWN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'TZ', N'TANZANIA UNITED REPUBLIC OF                                                                         ', N'TZA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'UA', N'UKRAINE                                                                                             ', N'UKR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'UG', N'UGANDA                                                                                              ', N'UGA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'UM', N'UNITED STATES MINOR OUTLYING ISLANDS                                                                ', N'UMI')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'US', N'UNITED STATES                                                                                       ', N'USA')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'UY', N'URUGUAY                                                                                             ', N'URY')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'UZ', N'UZBEKISTAN                                                                                          ', N'UZB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'VA', N'HOLY SEE (VATICAN CITY STATE)                                                                       ', N'VAT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'VC', N'SAINT VINCENT AND THE GRENADINES                                                                    ', N'VCT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'VE', N'VENEZUELA BOLIVARIAN REPUBLIC OF                                                                    ', N'VEN')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'VG', N'VIRGIN ISLANDS BRITISH                                                                              ', N'VGB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'VI', N'VIRGIN ISLANDS U.S.                                                                                 ', N'VIR')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'VN', N'VIET NAM                                                                                            ', N'VNM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'VU', N'VANUATU                                                                                             ', N'VUT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'WF', N'WALLIS AND FUTUNA                                                                                   ', N'WLF')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'WS', N'SAMOA                                                                                               ', N'WSM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'YE', N'YEMEN                                                                                               ', N'YEM')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'YT', N'MAYOTTE                                                                                             ', N'MYT')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'ZA', N'SOUTH AFRICA                                                                                        ', N'ZAF')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'ZM', N'ZAMBIA                                                                                              ', N'ZMB')
INSERT [dbo].[tb_dom_iso_country] ([iso_country_iso_2], [iso_country_desc], [iso_country_3]) VALUES (N'ZW', N'ZIMBABWE                                                                                            ', N'ZWE')
GO
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'AED', N'UAE Dirham                                                                                          ', N'UNITED ARAB EMIRATES                                                                                ', 784)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'AFN', N'Afghani                                                                                             ', N'AFGHANISTAN                                                                                         ', 971)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'ALL', N'Lek                                                                                                 ', N'ALBANIA                                                                                             ', 8)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'AMD', N'Armenian Dram                                                                                       ', N'ARMENIA                                                                                             ', 51)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'ANG', N'Netherlands Antillean Guilder                                                                       ', N'CURACAO                                                                                             ', 532)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'AOA', N'Kwanza                                                                                              ', N'ANGOLA                                                                                              ', 973)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'ARS', N'Argentine Peso                                                                                      ', N'ARGENTINA                                                                                           ', 32)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'AUD', N'Australian Dollar                                                                                   ', N'AUSTRALIA                                                                                           ', 36)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'AWG', N'Aruban Guilder                                                                                      ', N'ARUBA                                                                                               ', 533)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'AZN', N'Azerbaijanian Manat                                                                                 ', N'AZERBAIJAN                                                                                          ', 944)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BAM', N'Convertible Mark                                                                                    ', N'BOSNIA & HERZEGOVINA                                                                                ', 977)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BBD', N'Barbados Dollar                                                                                     ', N'BARBADOS                                                                                            ', 52)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BDT', N'Taka                                                                                                ', N'BANGLADESH                                                                                          ', 50)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BGN', N'Bulgarian Lev                                                                                       ', N'BULGARIA                                                                                            ', 975)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BHD', N'Bahraini Dinar                                                                                      ', N'BAHRAIN                                                                                             ', 48)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BIF', N'Burundi Franc                                                                                       ', N'BURUNDI                                                                                             ', 108)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BMD', N'Bermudian Dollar                                                                                    ', N'BERMUDA                                                                                             ', 60)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BND', N'Brunei Dollar                                                                                       ', N'BRUNEI DARUSSALAM                                                                                   ', 96)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BOB', N'Boliviano                                                                                           ', N'BOLIVIA PLURINATIONAL STATE OF                                                                      ', 68)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BOV', N'Mvdol                                                                                               ', N'BOLIVIA PLURINATIONAL STATE OF                                                                      ', 984)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BRL', N'Brazilian Real                                                                                      ', N'BRAZIL                                                                                              ', 986)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BSD', N'Bahamian Dollar                                                                                     ', N'BAHAMAS                                                                                             ', 44)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BTN', N'Ngultrum                                                                                            ', N'BHUTAN                                                                                              ', 64)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BWP', N'Pula                                                                                                ', N'BOTSWANA                                                                                            ', 72)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BYN', N'Belarusian Ruble                                                                                    ', N'BELARUS                                                                                             ', 933)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BYR', N'Belarussian Ruble                                                                                   ', N'BELARUS                                                                                             ', 974)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'BZD', N'Belize Dollar                                                                                       ', N'BELIZE                                                                                              ', 84)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CAD', N'Canadian Dollar                                                                                     ', N'CANADA                                                                                              ', 124)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CDF', N'Congolese Franc                                                                                     ', N'CONGO THE DEMOCRATIC REPUBLIC OF                                                                    ', 976)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CHE', N'WIR Euro                                                                                            ', N'SWITZERLAND                                                                                         ', 947)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CHF', N'Swiss Franc                                                                                         ', N'SWITZERLAND                                                                                         ', 756)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CHW', N'WIR Franc                                                                                           ', N'SWITZERLAND                                                                                         ', 948)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CLF', N'Unidades de fomento                                                                                 ', N'CHILE                                                                                               ', 990)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CLP', N'Chilean Peso                                                                                        ', N'CHILE                                                                                               ', 152)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CNH', N'Yuan Renminbi (Offshore)                                                                            ', N'CHINA                                                                                               ', 1003)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CNY', N'Yuan Renminbi                                                                                       ', N'CHINA                                                                                               ', 156)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'COP', N'Colombian Peso                                                                                      ', N'COLOMBIA                                                                                            ', 170)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'COU', N'Unidad de Valor Real                                                                                ', N'COLOMBIA                                                                                            ', 970)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CRC', N'Costa Rican Colon                                                                                   ', N'COSTA RICA                                                                                          ', 188)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CUC', N'Peso Convertible                                                                                    ', N'CUBA                                                                                                ', 931)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CUP', N'Cuban Peso                                                                                          ', N'CUBA                                                                                                ', 192)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CVE', N'Cape Verde Escudo                                                                                   ', N'CAPE VERDE                                                                                          ', 132)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CYP', N'Cypriot Pound                                                                                       ', N'CYPRUS                                                                                              ', 1002)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'CZK', N'Czech Koruna                                                                                        ', N'CZECH REPUBLIC                                                                                      ', 203)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'DEM', N'Deutsche Mark                                                                                       ', N'Federal Republic of Germany                                                                         ', 271)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'DJF', N'Djibouti Franc                                                                                      ', N'DJIBOUTI                                                                                            ', 262)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'DKK', N'Danish Krone                                                                                        ', N'DENMARK                                                                                             ', 208)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'DOP', N'Dominican Peso                                                                                      ', N'DOMINICAN REPUBLIC                                                                                  ', 214)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'DZD', N'Algerian Dinar                                                                                      ', N'ALGERIA                                                                                             ', 12)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'EEK', N'Estonian kroon                                                                                      ', N'Estonian kroon                                                                                      ', 1001)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'EGP', N'Egyptian Pound                                                                                      ', N'EGYPT                                                                                               ', 818)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'ERN', N'Nakfa                                                                                               ', N'ERITREA                                                                                             ', 232)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'ETB', N'Ethiopian Birr                                                                                      ', N'ETHIOPIA                                                                                            ', 230)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'EUR', N'Euro                                                                                                ', N'EUROPEAN MONETARY UNION                                                                             ', 978)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'FJD', N'Fiji Dollar                                                                                         ', N'FIJI                                                                                                ', 242)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'FKP', N'Falkland Islands Pound                                                                              ', N'FALKLAND ISLANDS (MALVINAS)                                                                         ', 238)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'GBP', N'Pound Sterling                                                                                      ', N'UNITED KINGDOM                                                                                      ', 826)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'GEL', N'Lari                                                                                                ', N'GEORGIA                                                                                             ', 981)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'GHS', N'Cedi                                                                                                ', N'GHANA                                                                                               ', 936)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'GIP', N'Gibraltar Pound                                                                                     ', N'GIBRALTAR                                                                                           ', 292)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'GMD', N'Dalasi                                                                                              ', N'GAMBIA                                                                                              ', 270)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'GNF', N'Guinea Franc                                                                                        ', N'GUINEA                                                                                              ', 324)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'GTQ', N'Quetzal                                                                                             ', N'GUATEMALA                                                                                           ', 320)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'GYD', N'Guyana Dollar                                                                                       ', N'GUYANA                                                                                              ', 328)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'HKD', N'Hong Kong Dollar                                                                                    ', N'HONG KONG                                                                                           ', 344)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'HNL', N'Lempira                                                                                             ', N'HONDURAS                                                                                            ', 340)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'HRK', N'Croatian Kuna                                                                                       ', N'CROATIA                                                                                             ', 191)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'HTG', N'Gourde                                                                                              ', N'HAITI                                                                                               ', 332)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'HUF', N'Forint                                                                                              ', N'HUNGARY                                                                                             ', 348)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'IDR', N'Rupiah                                                                                              ', N'INDONESIA                                                                                           ', 360)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'ILS', N'New Israeli Sheqel                                                                                  ', N'ISRAEL                                                                                              ', 376)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'INR', N'Indian Rupee                                                                                        ', N'INDIA                                                                                               ', 356)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'IQD', N'Iraqi Dinar                                                                                         ', N'IRAQ                                                                                                ', 368)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'IRR', N'Iranian Rial                                                                                        ', N'IRAN ISLAMIC REPUBLIC OF                                                                            ', 364)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'ISK', N'Iceland Krona                                                                                       ', N'ICELAND                                                                                             ', 352)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'JMD', N'Jamaican Dollar                                                                                     ', N'JAMAICA                                                                                             ', 388)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'JOD', N'Jordanian Dinar                                                                                     ', N'JORDAN                                                                                              ', 400)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'JPY', N'Yen                                                                                                 ', N'JAPAN                                                                                               ', 392)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'KES', N'Kenyan Shilling                                                                                     ', N'KENYA                                                                                               ', 404)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'KGS', N'Som                                                                                                 ', N'KYRGYZSTAN                                                                                          ', 417)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'KHR', N'Riel                                                                                                ', N'CAMBODIA                                                                                            ', 116)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'KMF', N'Comoro Franc                                                                                        ', N'COMOROS                                                                                             ', 174)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'KPW', N'North Korean Won                                                                                    ', N'KOREA DEMOCRATIC PEOPLE’S REPUBLIC OF                                                               ', 408)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'KRW', N'Won                                                                                                 ', N'KOREA REPUBLIC OF                                                                                   ', 410)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'KWD', N'Kuwaiti Dinar                                                                                       ', N'KUWAIT                                                                                              ', 414)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'KYD', N'Cayman Islands Dollar                                                                               ', N'CAYMAN ISLANDS                                                                                      ', 136)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'KZT', N'Tenge                                                                                               ', N'KAZAKHSTAN                                                                                          ', 398)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'LAK', N'Kip                                                                                                 ', N'LAO PEOPLE’S DEMOCRATIC REPUBLIC                                                                    ', 418)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'LBP', N'Lebanese Pound                                                                                      ', N'LEBANON                                                                                             ', 422)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'LKR', N'Sri Lanka Rupee                                                                                     ', N'SRI LANKA                                                                                           ', 144)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'LRD', N'Liberian Dollar                                                                                     ', N'LIBERIA                                                                                             ', 430)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'LSL', N'Loti                                                                                                ', N'LESOTHO                                                                                             ', 426)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'LTL', N'Lithuanian Litas                                                                                    ', N'LITHUANIA                                                                                           ', 435)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'LVL', N'Latvian Lats                                                                                        ', N'LATVIA                                                                                              ', 427)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'LYD', N'Libyan Dinar                                                                                        ', N'LIBYAN ARAB JAMAHIRIYA                                                                              ', 434)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MAD', N'Moroccan Dirham                                                                                     ', N'MOROCCO                                                                                             ', 504)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MDL', N'Moldovan Leu                                                                                        ', N'MOLDOVA REPUBLIC OF                                                                                 ', 498)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MGA', N'Malagasy Ariary                                                                                     ', N'MADAGASCAR                                                                                          ', 969)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MKD', N'Denar                                                                                               ', N'MACEDONIA THE FORMER YUGOSLAV REPUBLIC OF                                                           ', 807)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MMK', N'Kyat                                                                                                ', N'MYANMAR                                                                                             ', 104)
GO
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MNT', N'Tugrik                                                                                              ', N'MONGOLIA                                                                                            ', 496)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MOP', N'Pataca                                                                                              ', N'MACAO                                                                                               ', 446)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MRO', N'Ouguiya                                                                                             ', N'MAURITANIA                                                                                          ', 463)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MRU', N'Ouguiya                                                                                             ', N'MAURITANIA                                                                                          ', 929)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MUR', N'Mauritius Rupee                                                                                     ', N'MAURITIUS                                                                                           ', 480)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MVR', N'Rufiyaa                                                                                             ', N'MALDIVES                                                                                            ', 462)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MWK', N'Kwacha                                                                                              ', N'MALAWI                                                                                              ', 454)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MXN', N'Mexican Peso                                                                                        ', N'MEXICO                                                                                              ', 484)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MXV', N'Mexican Unidad de Inversion (UDI)                                                                   ', N'MEXICO                                                                                              ', 979)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MYR', N'Malaysian Ringgit                                                                                   ', N'MALAYSIA                                                                                            ', 458)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'MZN', N'Metical                                                                                             ', N'MOZAMBIQUE                                                                                          ', 943)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'NAD', N'Namibia Dollar                                                                                      ', N'NAMIBIA                                                                                             ', 516)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'NGN', N'Naira                                                                                               ', N'NIGERIA                                                                                             ', 566)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'NIO', N'Cordoba Oro                                                                                         ', N'NICARAGUA                                                                                           ', 558)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'NOK', N'Norwegian Krone                                                                                     ', N'NORWAY                                                                                              ', 578)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'NPR', N'Nepalese Rupee                                                                                      ', N'NEPAL                                                                                               ', 524)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'NZD', N'New Zealand Dollar                                                                                  ', N'NEW ZEALAND                                                                                         ', 554)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'OMR', N'Rial Omani                                                                                          ', N'OMAN                                                                                                ', 512)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'PAB', N'Balboa                                                                                              ', N'PANAMA                                                                                              ', 590)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'PEN', N'Nuevo Sol                                                                                           ', N'PERU                                                                                                ', 604)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'PGK', N'Kina                                                                                                ', N'PAPUA NEW GUINEA                                                                                    ', 598)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'PHP', N'Philippine Peso                                                                                     ', N'PHILIPPINES                                                                                         ', 608)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'PKR', N'Pakistan Rupee                                                                                      ', N'PAKISTAN                                                                                            ', 586)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'PLN', N'Zloty                                                                                               ', N'POLAND                                                                                              ', 985)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'PYG', N'Guarani                                                                                             ', N'PARAGUAY                                                                                            ', 600)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'QAR', N'Qatari Rial                                                                                         ', N'QATAR                                                                                               ', 634)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'RON', N'Leu                                                                                                 ', N'ROMANIA                                                                                             ', 946)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'RSD', N'Serbian Dinar                                                                                       ', N'SERBIA                                                                                              ', 941)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'RUB', N'Russian Ruble                                                                                       ', N'RUSSIAN FEDERATION                                                                                  ', 643)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'RUR', N'Russian Federation                                                                                  ', NULL, 1004)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'RWF', N'Rwanda Franc                                                                                        ', N'RWANDA                                                                                              ', 646)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SAR', N'Saudi Riyal                                                                                         ', N'SAUDI ARABIA                                                                                        ', 682)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SBD', N'Solomon Islands Dollar                                                                              ', N'SOLOMON ISLANDS                                                                                     ', 90)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SCR', N'Seychelles Rupee                                                                                    ', N'SEYCHELLES                                                                                          ', 690)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SDG', N'Sudanese Pound                                                                                      ', N'SUDAN                                                                                               ', 938)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SEK', N'Swedish Krona                                                                                       ', N'SWEDEN                                                                                              ', 752)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SGD', N'Singapore Dollar                                                                                    ', N'SINGAPORE                                                                                           ', 702)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SHP', N'Saint Helena Pound                                                                                  ', N'SAINT HELENA ASCENSION AND TRISTAN DA CUNHA                                                         ', 654)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SKK', N'Slovak koruna                                                                                       ', NULL, 1005)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SLL', N'Leone                                                                                               ', N'SIERRA LEONE                                                                                        ', 694)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SOS', N'Somali Shilling                                                                                     ', N'SOMALIA                                                                                             ', 706)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SRD', N'Surinam Dollar                                                                                      ', N'SURINAME                                                                                            ', 968)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SSP', N'South Sudanese Pound                                                                                ', N'SOUTH SUDAN                                                                                         ', 728)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'STD', N'Dobra                                                                                               ', N'SAO TOME AND PRINCIPE                                                                               ', 655)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'STN', N'Dobra                                                                                               ', N'SAO TOME AND PRINCIPE                                                                               ', 930)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SVC', N'El Salvador Colon                                                                                   ', N'EL SALVADOR                                                                                         ', 222)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SYP', N'Syrian Pound                                                                                        ', N'SYRIAN ARAB REPUBLIC                                                                                ', 760)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'SZL', N'Lilangeni                                                                                           ', N'SWAZILAND                                                                                           ', 748)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'THB', N'Baht                                                                                                ', N'THAILAND                                                                                            ', 764)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'TJS', N'Somoni                                                                                              ', N'TAJIKISTAN                                                                                          ', 972)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'TMT', N'New Manat                                                                                           ', N'TURKMENISTAN                                                                                        ', 934)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'TND', N'Tunisian Dinar                                                                                      ', N'TUNISIA                                                                                             ', 788)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'TOP', N'Pa’anga                                                                                             ', N'TONGA                                                                                               ', 776)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'TRY', N'Turkish Lira                                                                                        ', N'TURKEY                                                                                              ', 949)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'TTD', N'Trinidad and Tobago Dollar                                                                          ', N'TRINIDAD AND TOBAGO                                                                                 ', 780)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'TWD', N'New Taiwan Dollar                                                                                   ', N'TAIWAN PROVINCE OF CHINA                                                                            ', 901)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'TZS', N'Tanzanian Shilling                                                                                  ', N'TANZANIA UNITED REPUBLIC OF                                                                         ', 834)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'UAH', N'Hryvnia                                                                                             ', N'UKRAINE                                                                                             ', 980)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'UGX', N'Uganda Shilling                                                                                     ', N'UGANDA                                                                                              ', 800)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'USD', N'US Dollar                                                                                           ', N'UNITED STATES                                                                                       ', 840)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'USN', N'US Dollar (Next day)                                                                                ', N'UNITED STATES                                                                                       ', 997)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'USS', N'US Dollar (Same day)                                                                                ', N'UNITED STATES                                                                                       ', 998)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'UYI', N'Uruguay Peso en Unidades Indexadas (URUIURUI)                                                       ', N'URUGUAY                                                                                             ', 940)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'UYU', N'Peso Uruguayo                                                                                       ', N'URUGUAY                                                                                             ', 858)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'UYW', N'Unidad Previsional                                                                                  ', N'URUGUAY                                                                                             ', 927)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'UZS', N'Uzbekistan Sum                                                                                      ', N'UZBEKISTAN                                                                                          ', 860)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'VEB', N'Venezuelan Bolívar                                                                                  ', NULL, 1006)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'VEF', N'Bolivar Fuerte                                                                                      ', N'VENEZUELA BOLIVARIAN REPUBLIC OF                                                                    ', 937)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'VES', N'Bolívar Soberano                                                                                    ', N'VENEZUELA (BOLIVARIAN REPUBLIC OF)                                                                  ', 928)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'VND', N'Dong                                                                                                ', N'VIET NAM                                                                                            ', 704)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'VUV', N'Vatu                                                                                                ', N'VANUATU                                                                                             ', 548)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'WST', N'Tala                                                                                                ', N'SAMOA                                                                                               ', 882)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XAF', N'CFA Franc BEAC                                                                                      ', N'CENTRAL AFRICAN REPUBLIC                                                                            ', 950)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XAG', N'Silver                                                                                              ', NULL, 961)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XAU', N'Gold                                                                                                ', NULL, 959)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XBA', N'Bond Markets Unit European Composite Unit (EURCO)                                                   ', NULL, 955)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XBB', N'Bond Markets Unit European Monetary Unit                                                            ', NULL, 956)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XBC', N'Bond Markets Unit European Unit of Account 9                                                        ', NULL, 957)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XBD', N'Bond Markets Unit European Unit of Account 17                                                       ', NULL, 958)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XCD', N'East Caribbean Dollar                                                                               ', NULL, 951)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XDR', N'SDR (Special Drawing Right)                                                                         ', N'INTERNATIONAL MONETARY FUND (IMF)                                                                   ', 960)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XOF', N'CFA Franc BCEAO                                                                                     ', NULL, 952)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XPD', N'Palladium                                                                                           ', NULL, 964)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XPF', N'CFP Franc                                                                                           ', N'FRENCH POLYNESIA                                                                                    ', 953)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XPT', N'Platinum                                                                                            ', NULL, 962)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XSU', N'Sucre                                                                                               ', N'SISTEMA UNITARIO DE COMPENSACION REGIONAL DE PAGOS                                                  ', 994)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XTS', N'Codes specifically reserved for testing purposes                                                    ', N'ZZ06_Testing_Code                                                                                   ', 963)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XUA', N'ADB Unit of Account                                                                                 ', N'MEMBER COUNTRIES OF THE AFRICAN DEVELOPMENT BANK GROUP                                              ', 965)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'XXX', N'No Currency                                                                                         ', N'No Currency State                                                                                   ', 999)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'YER', N'Yemeni Rial                                                                                         ', N'YEMEN                                                                                               ', 886)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'ZAR', N'Rand                                                                                                ', N'SOUTH AFRICA                                                                                        ', 710)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'ZMK', N'Zambian Kwacha                                                                                      ', N'ZAMBIA                                                                                              ', 887)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'ZMW', N'Zambian Kwacha                                                                                      ', N'ZAMBIA                                                                                              ', 967)
INSERT [dbo].[tb_dom_iso_currency] ([iso_ccy_code], [iso_ccy_desc], [iso_ccy_desc_entity], [iso_ccy_numeric]) VALUES (N'ZWL', N'Zimbabwe Dollar                                                                                     ', N'ZIMBABWE                                                                                            ', 932)
GO
INSERT [dbo].[tb_dom_languages] ([language_iso_3], [language_desc]) VALUES (N'DEU', N'German')
INSERT [dbo].[tb_dom_languages] ([language_iso_3], [language_desc]) VALUES (N'ENG', N'English')
INSERT [dbo].[tb_dom_languages] ([language_iso_3], [language_desc]) VALUES (N'FRA', N'French')
INSERT [dbo].[tb_dom_languages] ([language_iso_3], [language_desc]) VALUES (N'ITA', N'Italian')
INSERT [dbo].[tb_dom_languages] ([language_iso_3], [language_desc]) VALUES (N'SPA', N'Spanish')
GO
INSERT [dbo].[tb_dom_legal_form] ([lf_id], [lf_acronym]) VALUES (1, N'FCP')
INSERT [dbo].[tb_dom_legal_form] ([lf_id], [lf_acronym]) VALUES (2, N'SICAV')
INSERT [dbo].[tb_dom_legal_form] ([lf_id], [lf_acronym]) VALUES (3, N'SICAF')
GO
INSERT [dbo].[tb_dom_legal_type] ([lt_id], [lt_acronym]) VALUES (1, N'UCITS')
INSERT [dbo].[tb_dom_legal_type] ([lt_id], [lt_acronym]) VALUES (2, N'AIF')
INSERT [dbo].[tb_dom_legal_type] ([lt_id], [lt_acronym]) VALUES (3, N'OTHERS')
GO
INSERT [dbo].[tb_dom_legal_vehicle] ([lv_id], [lv_acronym], [lv_fk_legal_type]) VALUES (1, N'UCITS', 1)
INSERT [dbo].[tb_dom_legal_vehicle] ([lv_id], [lv_acronym], [lv_fk_legal_type]) VALUES (2, N'SIF', 2)
INSERT [dbo].[tb_dom_legal_vehicle] ([lv_id], [lv_acronym], [lv_fk_legal_type]) VALUES (3, N'UCI - Part II', 2)
INSERT [dbo].[tb_dom_legal_vehicle] ([lv_id], [lv_acronym], [lv_fk_legal_type]) VALUES (4, N'RAIF', 2)
INSERT [dbo].[tb_dom_legal_vehicle] ([lv_id], [lv_acronym], [lv_fk_legal_type]) VALUES (5, N'SICAR', 2)
INSERT [dbo].[tb_dom_legal_vehicle] ([lv_id], [lv_acronym], [lv_fk_legal_type]) VALUES (6, N'SOPARFI', 3)
INSERT [dbo].[tb_dom_legal_vehicle] ([lv_id], [lv_acronym], [lv_fk_legal_type]) VALUES (7, N'SPF', 3)
INSERT [dbo].[tb_dom_legal_vehicle] ([lv_id], [lv_acronym], [lv_fk_legal_type]) VALUES (8, N'SV', 3)
INSERT [dbo].[tb_dom_legal_vehicle] ([lv_id], [lv_acronym], [lv_fk_legal_type]) VALUES (9, N'ELTIF', 2)
INSERT [dbo].[tb_dom_legal_vehicle] ([lv_id], [lv_acronym], [lv_fk_legal_type]) VALUES (10, N'EUVECA', 2)
INSERT [dbo].[tb_dom_legal_vehicle] ([lv_id], [lv_acronym], [lv_fk_legal_type]) VALUES (11, N'EUSEF', 2)
GO
INSERT [dbo].[tb_dom_navFrequency] ([nf_id], [nf_desc]) VALUES (1, N'Daily')
INSERT [dbo].[tb_dom_navFrequency] ([nf_id], [nf_desc]) VALUES (2, N'Weekly')
INSERT [dbo].[tb_dom_navFrequency] ([nf_id], [nf_desc]) VALUES (3, N'Weekly and last Monthly nav')
INSERT [dbo].[tb_dom_navFrequency] ([nf_id], [nf_desc]) VALUES (4, N'Monthly')
INSERT [dbo].[tb_dom_navFrequency] ([nf_id], [nf_desc]) VALUES (5, N'Fortnightly')
INSERT [dbo].[tb_dom_navFrequency] ([nf_id], [nf_desc]) VALUES (6, N'Fortnightly and last Monthly nav')
INSERT [dbo].[tb_dom_navFrequency] ([nf_id], [nf_desc]) VALUES (7, N'Quarterly')
INSERT [dbo].[tb_dom_navFrequency] ([nf_id], [nf_desc]) VALUES (8, N'Semi-annually')
INSERT [dbo].[tb_dom_navFrequency] ([nf_id], [nf_desc]) VALUES (9, N'Annually')
GO
INSERT [dbo].[tb_dom_principal_investment_strategy] ([pis_id], [pis_desc]) VALUES (1, N'Long                                                                                                ')
INSERT [dbo].[tb_dom_principal_investment_strategy] ([pis_id], [pis_desc]) VALUES (2, N'Short                                                                                               ')
INSERT [dbo].[tb_dom_principal_investment_strategy] ([pis_id], [pis_desc]) VALUES (3, N'Long Short                                                                                          ')
INSERT [dbo].[tb_dom_principal_investment_strategy] ([pis_id], [pis_desc]) VALUES (4, N'Market Neutral                                                                                      ')
INSERT [dbo].[tb_dom_principal_investment_strategy] ([pis_id], [pis_desc]) VALUES (5, N'Arbitrage                                                                                           ')
INSERT [dbo].[tb_dom_principal_investment_strategy] ([pis_id], [pis_desc]) VALUES (6, N'Unconstrained/ Multistrategy                                                                        ')
GO
INSERT [dbo].[tb_dom_sf_cat_bloomberg] ([cat_bloomberg_id], [cat_bloomberg_Desc], [cat_bloomberg_Desc_expl]) VALUES (1, N'Fixed Income                                                                                        ', N'Exposure to fixed income securities with maturity >1 year.')
INSERT [dbo].[tb_dom_sf_cat_bloomberg] ([cat_bloomberg_id], [cat_bloomberg_Desc], [cat_bloomberg_Desc_expl]) VALUES (2, N'Mixed Allocation                                                                                    ', N'Investing in a combination of variable and fixed income securities.')
INSERT [dbo].[tb_dom_sf_cat_bloomberg] ([cat_bloomberg_id], [cat_bloomberg_Desc], [cat_bloomberg_Desc_expl]) VALUES (3, N'Specialty                                                                                           ', N'Invests in non-traditional investments specifically life policy, currencies and derivatives.')
INSERT [dbo].[tb_dom_sf_cat_bloomberg] ([cat_bloomberg_id], [cat_bloomberg_Desc], [cat_bloomberg_Desc_expl]) VALUES (4, N'Real Estate                                                                                         ', N'Focused on tangible real estate assets. REITS are not included.')
INSERT [dbo].[tb_dom_sf_cat_bloomberg] ([cat_bloomberg_id], [cat_bloomberg_Desc], [cat_bloomberg_Desc_expl]) VALUES (5, N'Commodity                                                                                           ', N'Either tangible or through the use of derivative strategies to invest in commodities.')
INSERT [dbo].[tb_dom_sf_cat_bloomberg] ([cat_bloomberg_id], [cat_bloomberg_Desc], [cat_bloomberg_Desc_expl]) VALUES (6, N'Money Market                                                                                        ', N'Invests in fixed income instruments with a mean residual life to maturity of <1 year.')
INSERT [dbo].[tb_dom_sf_cat_bloomberg] ([cat_bloomberg_id], [cat_bloomberg_Desc], [cat_bloomberg_Desc_expl]) VALUES (7, N'Alternative                                                                                         ', N'Funds using hedge/derivative strategies')
INSERT [dbo].[tb_dom_sf_cat_bloomberg] ([cat_bloomberg_id], [cat_bloomberg_Desc], [cat_bloomberg_Desc_expl]) VALUES (8, N'Equity', N'Invests in stocks.')
GO
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (1, N'Africa and Middle East Equity                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (2, N'Africa Equity                                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (3, N'Alt - Currency                                                                                      ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (4, N'Alt - Event Driven                                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (5, N'Alt - Global Macro                                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (6, N'Alt - Long/Short Credit                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (7, N'Alt - Long/Short Equity - Europe                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (8, N'Alt - Long/Short Equity - Global                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (9, N'Alt - Long/Short Equity - UK                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (10, N'Alt - Long/Short Equity - US                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (11, N'Alt - Market Neutral - Equity                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (12, N'Alt - Multistrategy                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (13, N'Alt - Other                                                                                         ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (14, N'Alt - Relative Value Arbitrage                                                                      ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (15, N'Alt - Systematic Futures                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (16, N'Alt - Volatility                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (17, N'ASEAN Equity                                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (18, N'Asia Allocation                                                                                     ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (19, N'Asia Bond                                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (20, N'Asia Bond - Local Currency                                                                          ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (21, N'Asia ex-Japan Equity                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (22, N'Asia ex-Japan Small/Mid-Cap Equity                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (23, N'Asia High Yield Bond                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (24, N'Asia-Pacific ex-Japan Equity                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (25, N'Asia-Pacific ex-Japan Equity Income                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (26, N'Asia-Pacific inc. Japan Equity                                                                      ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (27, N'Australia and New Zealand Equity                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (28, N'Brazil Equity                                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (29, N'BRIC Equity                                                                                         ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (30, N'Canada Equity                                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (31, N'Capital Protected                                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (32, N'CHF Aggressive Allocation                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (33, N'CHF Bond                                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (34, N'CHF Bond - Short Term                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (35, N'CHF Cautious Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (36, N'CHF Moderate Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (37, N'CHF Money Market                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (38, N'China Equity                                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (39, N'China Equity - A Shares                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (40, N'Commodities - Broad Agriculture                                                                     ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (41, N'Commodities - Broad Basket                                                                          ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (42, N'Commodities - Energy                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (43, N'Convertible Bond - Europe                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (44, N'Convertible Bond - Global                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (45, N'Convertible Bond - Global, CHF Hedged                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (46, N'Convertible Bond - Global, EUR Hedged                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (47, N'Convertible Bond - Global, GBP Hedged                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (48, N'Convertible Bond - Global, USD Hedged                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (49, N'Convertible Bond - Other                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (50, N'Denmark Equity                                                                                      ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (51, N'DKK Bond                                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (52, N'DKK Domestic Bond                                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (53, N'Emerging Europe Bond                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (54, N'Emerging Europe Equity                                                                              ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (55, N'Emerging Europe ex-Russia Equity                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (56, N'EUR Aggressive Allocation                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (57, N'EUR Aggressive Allocation - Global                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (58, N'EUR Bond - Long Term                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (59, N'EUR Cautious Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (60, N'EUR Cautious Allocation - Global                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (61, N'EUR Corporate Bond                                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (62, N'EUR Corporate Bond - Short Term                                                                     ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (63, N'EUR Diversified Bond                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (64, N'EUR Diversified Bond - Short Term                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (65, N'EUR Flexible Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (66, N'EUR Flexible Allocation - Global                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (67, N'EUR Flexible Bond                                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (68, N'EUR Government Bond                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (69, N'EUR Government Bond - Short Term                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (70, N'EUR High Yield Bond                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (71, N'EUR Inflation-Linked Bond                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (72, N'EUR Moderate Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (73, N'EUR Moderate Allocation - Global                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (74, N'EUR Money Market                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (75, N'EUR Money Market - Short Term                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (76, N'EUR Subordinated Bond                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (77, N'EUR Ultra Short-Term Bond                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (78, N'Europe Bond                                                                                         ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (79, N'Europe Equity Income                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (80, N'Europe ex-UK Large-Cap Equity                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (81, N'Europe ex-UK Small/Mid-Cap Equity                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (82, N'Europe Flex-Cap Equity                                                                              ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (83, N'Europe Large-Cap Blend Equity                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (84, N'Europe Large-Cap Growth Equity                                                                      ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (85, N'Europe Large-Cap Value Equity                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (86, N'Europe Mid-Cap Equity                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (87, N'Europe Small-Cap Equity                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (88, N'Eurozone Flex-Cap Equity                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (89, N'Eurozone Large-Cap Equity                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (90, N'Eurozone Mid-Cap Equity                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (91, N'Eurozone Small-Cap Equity                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (92, N'Fixed Term Bond                                                                                     ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (93, N'Foreign Large Blend                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (94, N'France Large-Cap Equity                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (95, N'France Small/Mid-Cap Equity                                                                         ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (96, N'GBP Adventurous Allocation                                                                          ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (97, N'GBP Cautious Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (98, N'GBP Corporate Bond                                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (99, N'GBP Diversified Bond                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (100, N'GBP Diversified Bond - Short Term                                                                   ')
GO
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (101, N'GBP Flexible Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (102, N'GBP Flexible Bond                                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (103, N'GBP Government Bond                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (104, N'GBP High Yield Bond                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (105, N'GBP Inflation-Linked Bond                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (106, N'GBP Moderate Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (107, N'GBP Moderately Adventurous Allocation                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (108, N'GBP Moderately Cautious Allocation                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (109, N'GBP Money Market                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (110, N'GBP Money Market - Short Term                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (111, N'Germany Large-Cap Equity                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (112, N'Germany Small/Mid-Cap Equity                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (113, N'Global Bond                                                                                         ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (114, N'Global Bond - CHF Biased                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (115, N'Global Bond - CHF Hedged                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (116, N'Global Bond - EUR Biased                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (117, N'Global Bond - EUR Hedged                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (118, N'Global Bond - GBP Biased                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (119, N'Global Bond - GBP Hedged                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (120, N'Global Bond - ILS                                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (121, N'Global Bond - NOK Hedged                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (122, N'Global Bond - USD Hedged                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (123, N'Global Corporate Bond                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (124, N'Global Corporate Bond - CHF Hedged                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (125, N'Global Corporate Bond - EUR Hedged                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (126, N'Global Corporate Bond - GBP Hedged                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (127, N'Global Corporate Bond - USD Hedged                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (128, N'Global Emerging Markets Allocation                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (129, N'Global Emerging Markets Bond                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (130, N'Global Emerging Markets Bond - EUR Biased                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (131, N'Global Emerging Markets Bond - Local Currency                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (132, N'Global Emerging Markets Corporate Bond                                                              ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (133, N'Global Emerging Markets Corporate Bond - EUR Biased                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (134, N'Global Emerging Markets Equity                                                                      ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (135, N'Global Emerging Markets Small/Mid-Cap Equity                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (136, N'Global Equity Income                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (137, N'Global Flex-Cap Equity                                                                              ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (138, N'Global Flexible Bond                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (139, N'Global Flexible Bond - CHF Hedged                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (140, N'Global Flexible Bond - EUR Hedged                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (141, N'Global Flexible Bond - GBP Hedged                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (142, N'Global Flexible Bond - USD Hedged                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (143, N'Global Frontier Markets Equity                                                                      ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (144, N'Global High Yield Bond                                                                              ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (145, N'Global High Yield Bond - CHF Hedged                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (146, N'Global High Yield Bond - EUR Hedged                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (147, N'Global High Yield Bond - GBP Hedged                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (148, N'Global Inflation-Linked Bond                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (149, N'Global Inflation-Linked Bond - EUR Hedged                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (150, N'Global Inflation-Linked Bond - GBP Hedged                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (151, N'Global Inflation-Linked Bond - USD Hedged                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (152, N'Global Large-Cap Blend Equity                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (153, N'Global Large-Cap Growth Equity                                                                      ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (154, N'Global Large-Cap Value Equity                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (155, N'Global Small-Cap Equity                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (156, N'Greater China Allocation                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (157, N'Greater China Equity                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (158, N'Guaranteed Funds                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (159, N'HKD Bond                                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (160, N'Hong Kong Equity                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (161, N'India Equity                                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (162, N'Indonesia Equity                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (163, N'Islamic Allocation - Other                                                                          ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (164, N'Islamic Equity - Other                                                                              ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (165, N'Islamic Global Bond                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (166, N'Islamic Global Equity                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (167, N'Italy Equity                                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (168, N'Japan Flex-Cap Equity                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (169, N'Japan Large-Cap Equity                                                                              ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (170, N'Japan Small/Mid-Cap Equity                                                                          ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (171, N'JPY Bond                                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (172, N'Korea Equity                                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (173, N'Latin America Equity                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (174, N'Money Market - Other                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (175, N'Multialternative                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (176, N'NOK Bond                                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (177, N'NOK Bond - Short Term                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (178, N'NOK Cautious Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (179, N'NOK High Yield Bond                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (180, N'NOK Moderate Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (181, N'Nontraditional Bond                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (182, N'Nordic Equity                                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (183, N'Nordic Small/Mid-Cap Equity                                                                         ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (184, N'Norway Equity                                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (185, N'Other                                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (186, N'Other Allocation                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (187, N'Other Bond                                                                                          ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (188, N'Other Equity                                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (189, N'Pacific ex-Japan Equity                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (190, N'Property - Direct Europe                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (191, N'Property - Direct Global                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (192, N'Property - Direct Other                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (193, N'Property - Direct UK                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (194, N'Property - Indirect Asia                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (195, N'Property - Indirect Europe                                                                          ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (196, N'Property - Indirect Eurozone                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (197, N'Property - Indirect Global                                                                          ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (198, N'Property - Indirect North America                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (199, N'Property - Indirect Other                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (200, N'RMB Bond                                                                                            ')
GO
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (201, N'RMB Bond - Onshore                                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (202, N'RMB High Yield Bond                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (203, N'Russia Equity                                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (204, N'Sector Equity Agriculture                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (205, N'Sector Equity Alternative Energy                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (206, N'Sector Equity Biotechnology                                                                         ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (207, N'Sector Equity Communications                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (208, N'Sector Equity Consumer Goods and Services                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (209, N'Sector Equity Ecology                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (210, N'Sector Equity Energy                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (211, N'Sector Equity Financial Services                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (212, N'Sector Equity Healthcare                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (213, N'Sector Equity Industrial Materials                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (214, N'Sector Equity Infrastructure                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (215, N'Sector Equity Natural Resources                                                                     ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (216, N'Sector Equity Precious Metals                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (217, N'Sector Equity Private Equity                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (218, N'Sector Equity Technology                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (219, N'Sector Equity Water                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (220, N'SEK Bond                                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (221, N'SEK Cautious Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (222, N'SEK Corporate Bond                                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (223, N'SEK Flexible Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (224, N'SEK Moderate Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (225, N'Singapore Equity                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (226, N'Spain Equity                                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (227, N'Sweden Equity                                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (228, N'Switzerland Large-Cap Equity                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (229, N'Switzerland Small/Mid-Cap Equity                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (230, N'Taiwan Large-Cap Equity                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (231, N'Target Date 2011 - 2015                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (232, N'Target Date 2016 - 2020                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (233, N'Target Date 2021 - 2025                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (234, N'Target Date 2026 - 2030                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (235, N'Target Date 2031 - 2035                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (236, N'Target Date 2036 - 2040                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (237, N'Target Date 2041 - 2045                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (238, N'Target Date 2046+                                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (239, N'Thailand Equity                                                                                     ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (240, N'Trading - Leveraged/Inverse Commodities                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (241, N'Turkey Equity                                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (242, N'UK Equity Income                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (243, N'UK Flex-Cap Equity                                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (244, N'UK Large-Cap Equity                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (245, N'UK Mid-Cap Equity                                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (246, N'UK Small-Cap Equity                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (247, N'US Flex-Cap Equity                                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (248, N'US Large-Cap Blend Equity                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (249, N'US Large-Cap Growth Equity                                                                          ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (250, N'US Large-Cap Value Equity                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (251, N'US Mid-Cap Equity                                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (252, N'US Small-Cap Equity                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (253, N'USD Aggressive Allocation                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (254, N'USD Cautious Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (255, N'USD Corporate Bond                                                                                  ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (256, N'USD Diversified Bond                                                                                ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (257, N'USD Diversified Bond - Short Term                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (258, N'USD Flexible Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (259, N'USD Flexible Bond                                                                                   ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (260, N'USD Government Bond                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (261, N'USD High Yield Bond                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (262, N'USD Inflation-Linked Bond                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (263, N'USD Moderate Allocation                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (264, N'USD Money Market                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (265, N'USD Money Market - Short Term                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (266, N'Vietnam Equity                                                                                      ')
INSERT [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id], [c_morningstar_desc]) VALUES (267, N'World Large Stock                                                                                   ')
GO
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (1, N'Equities Fund/Equity unit trust                                                                     ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (2, N'Fixed interest sec. Fund/ bond Fund                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (3, N'Money market / Currency Fund                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (4, N'Convertible bond Fund                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (5, N'Invest. objective Fund/Balanced Fund                                                                ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (6, N'Hedge Fund                                                                                          ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (7, N'Real estate investment Fund                                                                         ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (8, N'Industry Fund                                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (9, N'Index Fund                                                                                          ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (10, N'Fund of Funds                                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (11, N'Country / Regional Fund                                                                             ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (12, N'Allroundfunds/Mixed Funds                                                                           ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (13, N'Equities & industry Fund                                                                            ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (14, N'Equities & country/regional Fund                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (15, N'Bond & industry Funds                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (16, N'Bond & country/regional Funds                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (17, N'Guarantee fund/insurance Fund                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (18, N'Pension Fund                                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (19, N'Equity/Bond Fund                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (20, N'Sector-/Country-& Regional Fund                                                                     ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (21, N'Equity/Sector-/Country-& Regional Fund                                                              ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (22, N'Bond/Sector-/Country-& Regional Fund                                                                ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (23, N'Investment foundation claim                                                                         ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (24, N'Insurance Funds                                                                                     ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (25, N'Bond & Equity/Country-& Regional Fund                                                               ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (26, N'Mortgage Fund                                                                                       ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (27, N'Futures/Options Funds                                                                               ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (28, N'Derivative Fund                                                                                     ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (29, N'ETF                                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (30, N'Private Equity Fund                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (31, N'Commodity Fund                                                                                      ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (32, N'Fund of Hedge Funds                                                                                 ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (33, N'Fund of Private Equity Funds                                                                        ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (34, N'Alternative Fund                                                                                    ')
INSERT [dbo].[tb_dom_sf_cat_six] ([cat_six_id], [cat_six_desc]) VALUES (99, N'Other                                                                                               ')
GO
INSERT [dbo].[tb_dom_sf_status] ([st_id], [st_desc]) VALUES (1, N'Active')
INSERT [dbo].[tb_dom_sf_status] ([st_id], [st_desc]) VALUES (2, N'Inactive - Liquidated')
INSERT [dbo].[tb_dom_sf_status] ([st_id], [st_desc]) VALUES (3, N'Inactive - Closed')
INSERT [dbo].[tb_dom_sf_status] ([st_id], [st_desc]) VALUES (4, N'Inactive - To be launched')
INSERT [dbo].[tb_dom_sf_status] ([st_id], [st_desc]) VALUES (5, N'Inactive - Merged')
GO
INSERT [dbo].[tb_dom_share_status] ([sc_s_id], [sc_s_desc]) VALUES (1, N'Active')
INSERT [dbo].[tb_dom_share_status] ([sc_s_id], [sc_s_desc]) VALUES (2, N'Inactive - Liquidated')
INSERT [dbo].[tb_dom_share_status] ([sc_s_id], [sc_s_desc]) VALUES (3, N'Inactive - Closed')
INSERT [dbo].[tb_dom_share_status] ([sc_s_id], [sc_s_desc]) VALUES (4, N'Inactive - To be launched')
INSERT [dbo].[tb_dom_share_status] ([sc_s_id], [sc_s_desc]) VALUES (5, N'Inactive - Merged')
GO
INSERT [dbo].[tb_dom_share_type] ([st_id], [st_desc]) VALUES (1, N'Accumulation                                                                                        ')
INSERT [dbo].[tb_dom_share_type] ([st_id], [st_desc]) VALUES (2, N'Distribution                                                                                        ')
GO
SET IDENTITY_INSERT [dbo].[tb_dom_timeseries_provider] ON 

INSERT [dbo].[tb_dom_timeseries_provider] ([id_provider], [desc_provider]) VALUES (1, N'EDR')
INSERT [dbo].[tb_dom_timeseries_provider] ([id_provider], [desc_provider]) VALUES (2, N'Caceis')
INSERT [dbo].[tb_dom_timeseries_provider] ([id_provider], [desc_provider]) VALUES (3, N'SiX')
INSERT [dbo].[tb_dom_timeseries_provider] ([id_provider], [desc_provider]) VALUES (4, N'Bloomberg')
INSERT [dbo].[tb_dom_timeseries_provider] ([id_provider], [desc_provider]) VALUES (5, N'Northern Trust')
INSERT [dbo].[tb_dom_timeseries_provider] ([id_provider], [desc_provider]) VALUES (6, N'Allocare')
INSERT [dbo].[tb_dom_timeseries_provider] ([id_provider], [desc_provider]) VALUES (7, N'Swiss-Rev')
SET IDENTITY_INSERT [dbo].[tb_dom_timeseries_provider] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_dom_timeseries_type] ON 

INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (1, N'Subscription Amount', 3)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (2, N'Redemption Amount', 3)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (3, N'AuM SC in Share CCY', 3)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (4, N'Value %', 3)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (5, N'Price', 3)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (6, N'AuM in subfund currency', 3)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (7, N'Number of Shares', 3)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (8, N'Redemption Amount in Shares', 3)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (9, N'Subscription Amount in Shares', 3)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (10, N'AuM in EUR', 2)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (11, N'AuM aggregate SC at SF level', 3)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (12, N'VaR HS Emp (99%)', 2)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (13, N'VaR HS Nod (99%)', 2)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (14, N'AIF Commitment %', 2)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (15, N'AIF Gross %', 2)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (16, N'Commitment', 2)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (17, N'Sum of Notional (Delta 1) %', 2)
INSERT [dbo].[tb_dom_timeseries_type] ([id_ts], [desc_ts], [entity_type]) VALUES (18, N'AuM in SF CCY', 2)
SET IDENTITY_INSERT [dbo].[tb_dom_timeseries_type] OFF
GO
INSERT [dbo].[tb_dom_type_of_market] ([tom_id], [tom_desc]) VALUES (1, N'Developed                                                                                           ')
INSERT [dbo].[tb_dom_type_of_market] ([tom_id], [tom_desc]) VALUES (2, N'Emerging                                                                                            ')
INSERT [dbo].[tb_dom_type_of_market] ([tom_id], [tom_desc]) VALUES (3, N'Mixed                                                                                               ')
GO
INSERT [dbo].[tb_dom_valutationDate] ([vd_id], [vd_desc]) VALUES (1, N'Monday')
INSERT [dbo].[tb_dom_valutationDate] ([vd_id], [vd_desc]) VALUES (2, N'Tuesday')
INSERT [dbo].[tb_dom_valutationDate] ([vd_id], [vd_desc]) VALUES (3, N'Wednesday')
INSERT [dbo].[tb_dom_valutationDate] ([vd_id], [vd_desc]) VALUES (4, N'Thursday')
INSERT [dbo].[tb_dom_valutationDate] ([vd_id], [vd_desc]) VALUES (5, N'Friday')
INSERT [dbo].[tb_dom_valutationDate] ([vd_id], [vd_desc]) VALUES (6, N'Saturday')
INSERT [dbo].[tb_dom_valutationDate] ([vd_id], [vd_desc]) VALUES (7, N'Sunday')
INSERT [dbo].[tb_dom_valutationDate] ([vd_id], [vd_desc]) VALUES (8, N'Last business day of the month')
INSERT [dbo].[tb_dom_valutationDate] ([vd_id], [vd_desc]) VALUES (9, N'Today')
GO
INSERT [dbo].[tb_fund] ([f_id]) VALUES (1)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (2)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (3)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (4)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (5)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (6)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (7)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (8)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (9)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (10)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (11)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (12)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (13)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (14)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (15)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (16)
INSERT [dbo].[tb_fund] ([f_id]) VALUES (17)
GO
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (1, 7, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (2, 7, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (3, 7, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (4, 6, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (5, 5, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (6, 5, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (7, 4, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (8, 4, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (9, 3, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (10, 3, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (11, 2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (12, 2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (13, 2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (14, 2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (15, 2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (16, 2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (17, 2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (18, 2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (19, 2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (20, 2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (21, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (22, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (23, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (24, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (25, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (26, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (27, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (28, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (29, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (30, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (31, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (32, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (33, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (34, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (35, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (36, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (37, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (38, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (39, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (40, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (41, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (42, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (43, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (44, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (45, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (46, 2, CAST(N'2019-11-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (47, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (48, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (49, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (50, 8, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (51, 16, CAST(N'2003-06-20T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (52, 10, CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (53, 10, CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (54, 10, CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (55, 10, CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (56, 11, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (57, 11, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (58, 11, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (59, 11, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (60, 11, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (61, 11, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (62, 11, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (63, 12, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (64, 7, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (65, 1, CAST(N'2019-02-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (66, 1, CAST(N'2019-12-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (67, 5, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (68, 5, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (69, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (70, 5, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (71, 1, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (72, 7, CAST(N'2017-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (73, 7, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (74, 8, CAST(N'2019-12-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (75, 8, CAST(N'2019-12-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (76, 11, CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (77, 11, CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (78, 11, CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (79, 6, CAST(N'2017-06-30T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (81, 1, CAST(N'2020-06-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (83, 1, CAST(N'2020-09-30T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (84, 15, CAST(N'2020-08-31T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (85, 15, CAST(N'2020-08-31T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_fundSubFund] ([sf_id], [f_id], [fsf_startConnection], [fsf_endConnection]) VALUES (86, 4, CAST(N'2020-09-04T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (1, CAST(N'2002-12-05T00:00:00.000' AS DateTime), CAST(N'2019-02-14T00:00:00.000' AS DateTime), 1, N'B90212', N'PHARUS SICAV', N'PHARUS SICAV', N'222100JG4N94G0JFHL87', N'O00003465', N'3465', N'3465', N'3465', 2, 1, 1, 1, N'2002 4500 919', N'Launch of new Sub Funds', N'LAUNCH OF NEW SUB FUNDS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (1, CAST(N'2019-02-15T00:00:00.000' AS DateTime), CAST(N'2019-06-17T00:00:00.000' AS DateTime), 1, N'B90212', N'PHARUS SICAV', N'PHARUS SICAV', N'222100JG4N94G0JFHL87', N'O00003465', N'3465', N'3465', N'3465', 2, 1, 1, 1, N'2002 4500 919', NULL, N'LAUNCH OF NEW SUB FUNDS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (1, CAST(N'2019-06-18T00:00:00.000' AS DateTime), CAST(N'2019-12-15T00:00:00.000' AS DateTime), 1, N'B90212', N'PHARUS SICAV', N'PHARUS SICAV', N'222100JG4N94G0JFHL87', N'O00003465', N'3465', N'3465', N'3465', 2, 1, 1, 1, N'2002 4500 919', NULL, N'LAUNCH OF NEW SUB FUNDS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (1, CAST(N'2019-12-16T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), 1, N'B90212', N'PHARUS SICAV', N'PHARUS SICAV', N'222100JG4N94G0JFHL87', N'O00003465', N'3465', N'3465', N'3465', 2, 1, 1, 1, N'2002 4500 919', N'Main changes New subfunds (Flexible Alocation, Basic Fund, Galileo Dynamic) Chnage of name (Biotech in MEdicall Innovation, Absolute Return in Conservative)Bond Value and Global Dynamic opportunities placed into dormant list). Target changed invest policy.', N'NEW PROSPECTUS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (1, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, 1, N'B90212', N'PHARUS SICAV', N'PHARUS SICAV', N'222100JG4N94G0JFHL87', N'O00003465', N'3465', N'3465', N'3465', 2, 1, 1, 1, N'2002 4500 919', N'Main changes New subfunds (Flexible Alocation, Basic Fund, Galileo Dynamic) Chnage of name (Biotech in MEdicall Innovation, Absolute Return in Conservative)Bond Value and Global Dynamic opportunities placed into dormant list). Target changed invest policy.', N'NEW PROSPECTUS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (2, CAST(N'2012-08-20T00:00:00.000' AS DateTime), CAST(N'2019-07-10T00:00:00.000' AS DateTime), 1, N'B177997', N'MULTI STARS SICAV', N'MULTI STARS SICAV', N'529900W4LEFLCLOP5984', N'O00007588', N'7588', N'7588', N'7588', 2, 1, 1, 1, N'2012 4501 262', NULL, N'LAUNCH OF NEW SUB FUNDS', NULL, NULL, NULL, 2)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (2, CAST(N'2019-07-11T00:00:00.000' AS DateTime), CAST(N'2019-11-14T00:00:00.000' AS DateTime), 1, N'B177997', N'MULTI STARS SICAV', N'MULTI STARS SICAV', N'529900W4LEFLCLOP5984', N'O00007588', N'7588', N'7588', N'7588', 2, 1, 1, 1, N'2012 4501 262', NULL, N'LAUNCH OF NEW SUB FUNDS', NULL, NULL, NULL, 2)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (2, CAST(N'2019-11-15T00:00:00.000' AS DateTime), CAST(N'2019-12-10T00:00:00.000' AS DateTime), 1, N'B177997', N'MULTI STARS SICAV', N'MULTI STARS SICAV', N'529900W4LEFLCLOP5984', N'O00007588', N'7588', N'7588', N'7588', 2, 1, 1, 1, N'2012 4501 262', NULL, N'LAUNCH OF NEW SUB FUNDS', NULL, NULL, NULL, 2)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (2, CAST(N'2019-12-11T00:00:00.000' AS DateTime), CAST(N'2019-12-31T00:00:00.000' AS DateTime), 1, N'B177997', N'MULTI STARS SICAV', N'MULTI STARS SICAV', N'529900W4LEFLCLOP5984', N'O00007588', N'7588', N'7588', N'7588', 2, 1, 1, 1, N'2012 4501 262', NULL, N'NEW PROSPECTUS', NULL, NULL, NULL, 2)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (2, CAST(N'2020-01-01T00:00:00.000' AS DateTime), CAST(N'2020-09-17T00:00:00.000' AS DateTime), 1, N'B177997', N'MULTI STARS SICAV', N'MULTI STARS SICAV', N'529900W4LEFLCLOP5984', N'O00007588', N'7588', N'7588', N'7588', 2, 1, 1, 1, N'2012 4501 262', N'Emerging Market Local Currency	49% residual should include bond not emerging markets, Cube	clarify the payments of perfomance fees to the sharholders of class Z, Hearth Ethical	Class D should become hedged class, Hearth Ethical	Class F should become hedged class, Hearth Ethical	Update of invesment manager name from Valeur to Valori, Hearth Ethical	% of invetsments in UCITS/UCIs should be lowered from 50% - 10%, Alexander	delete typo on valuation date , Regent	incl valuation date, Regent	incl pos', N'CHANGE OF PROSPECTUS', NULL, NULL, NULL, 2)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (2, CAST(N'2020-09-18T00:00:00.000' AS DateTime), NULL, 1, N'B177997', N'MULTI STARS SICAV', N'MULTI STARS SICAV', N'529900W4LEFLCLOP5984', N'O00007588', N'7588', N'7588', N'7588', 2, 1, 1, 1, N'2012 4501 262', N'Emerging Market Local Currency	49% residual should include bond not emerging markets, Cube	clarify the payments of perfomance fees to the sharholders of class Z, Hearth Ethical	Class D should become hedged class, Hearth Ethical	Class F should become hedged class, Hearth Ethical	Update of invesment manager name from Valeur to Valori, Hearth Ethical	% of invetsments in UCITS/UCIs should be lowered from 50% - 10%, Alexander	delete typo on valuation date , Regent	incl valuation date, Regent	incl pos', N'CHANGE OF PROSPECTUS', NULL, NULL, NULL, 2)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (3, CAST(N'2018-11-29T00:00:00.000' AS DateTime), CAST(N'2020-10-01T00:00:00.000' AS DateTime), 1, N'O00007630', N'KITE FUND SICAV', N'KITE FUND SICAV', N'529900B4ZMG7YZ2DLQ49', N'O00007630', N'7630', N'7630', N'7630', 2, 1, 1, 1, N'2012 45 01 599', N'New shares, amendment of fees, change auditor, update list of directors', N'NEW PROSPECTUS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (3, CAST(N'2020-10-02T00:00:00.000' AS DateTime), NULL, 1, N'O00007630', N'KITE FUND SICAV', N'KITE FUND SICAV', N'529900B4ZMG7YZ2DLQ49', N'O00007630', N'7630', N'7630', N'7630', 2, 1, 1, 1, N'2012 45 01 599', N'New shares, amendment of fees, change auditor, update list of directors', N'NEW PROSPECTUS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (4, CAST(N'2015-12-17T00:00:00.000' AS DateTime), CAST(N'2020-09-03T00:00:00.000' AS DateTime), 1, N'B203047', N'EMERALD SICAV', N'EMERALD SICAV', N'Never requested', N'O00008724', N'8724', N'8724', N'8724', 2, 1, 1, 1, N'2015 4502 093', N'Launch of Emerald Euro Governement Bond', N'LAUNCH OF 1 NEW SUBFUND', NULL, NULL, NULL, 1)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (4, CAST(N'2020-09-04T00:00:00.000' AS DateTime), NULL, 1, N'B203047', N'EMERALD SICAV', N'EMERALD SICAV', N'Never requested', N'O00008724', N'8724', N'8724', N'8724', 2, 1, 1, 1, N'2015 4502 093', N'Launch of Emerald Euro Governement Bond', N'LAUNCH OF 1 NEW SUBFUND', NULL, NULL, NULL, 1)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (5, CAST(N'1997-01-01T00:00:00.000' AS DateTime), CAST(N'2019-08-12T00:00:00.000' AS DateTime), 1, N'O00002118', N'EFFICIENCY GROWTH FUND', N'EFFICIENCY GROWTH FUND', N'5299001XQ85TQ8T4AV09', N'O00002118', N'2118', N'2118', N'2118', 2, 1, 1, 1, N'1997 4500 674', NULL, N'CHANGED NAME OF FUND', NULL, NULL, NULL, 1)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (5, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL, 1, N'O00002118', N'GFG FUNDS', N'GFG FUNDS', N'5299001XQ85TQ8T4AV09', N'O00002118', N'2118', N'2118', N'2118', 2, 1, 1, 1, N'1997 4500 674', NULL, N'CHANGED NAME OF FUND', NULL, NULL, NULL, 1)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (6, CAST(N'2017-06-30T00:00:00.000' AS DateTime), CAST(N'2019-06-27T00:00:00.000' AS DateTime), 1, N'B212389', N'BRIGHT STARS SICAV-SIF', N'BRIGHT STARS SICAV-SIF', N'Never requested', N'O00011020', N'11020', N'11020', N'11020', 2, 2, 2, 1, N'2017 4500 151', NULL, N'NEW PROSPECTUS', NULL, NULL, NULL, 2)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (6, CAST(N'2019-06-28T00:00:00.000' AS DateTime), NULL, 1, N'B212389', N'BRIGHT STARS SICAV-SIF', N'BRIGHT STARS SICAV-SIF', N'Never requested', N'O00011020', N'11020', N'11020', N'11020', 2, 2, 2, 1, N'2017 4500 151', NULL, N'NEW PROSPECTUS', NULL, NULL, NULL, 2)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (7, CAST(N'2017-05-05T00:00:00.000' AS DateTime), CAST(N'2019-09-15T00:00:00.000' AS DateTime), 1, N'B213151', N'1ST SICAV', N'1ST SICAV', N'549300WTGS4L8JZYP719', N'O00011081', N'11081', N'11081', N'11081', 2, 1, 1, 1, N'2017 4500 283', NULL, N'NEW PROSPECTUS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (7, CAST(N'2019-09-16T00:00:00.000' AS DateTime), NULL, 1, N'B213151', N'1ST SICAV', N'1ST SICAV', N'549300WTGS4L8JZYP719', N'O00011081', N'11081', N'11081', N'11081', 2, 1, 1, 1, N'2017 4500 283', NULL, N'NEW PROSPECTUS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (8, CAST(N'2017-07-19T00:00:00.000' AS DateTime), CAST(N'2019-12-01T00:00:00.000' AS DateTime), 1, N'B216631', N'RITOM SICAV-RAIF', N'RITOM SICAV-RAIF', N'529900QN7IEME9MI2J78', N'V00001829', N'1829', N'1829', N'1829', 2, 2, 4, 1, N'2017 2207 554', NULL, N'LAUNCH OF NEW SUB FUNDS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (8, CAST(N'2019-12-02T00:00:00.000' AS DateTime), CAST(N'2020-03-31T00:00:00.000' AS DateTime), 1, N'B216631', N'RITOM SICAV-RAIF', N'RITOM SICAV-RAIF', N'529900QN7IEME9MI2J78', N'V00001829', N'1829', N'1829', N'1829', 2, 2, 4, 1, N'2017 2207 554', NULL, N'NEW PROSPECTUS ', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (8, CAST(N'2020-04-01T00:00:00.000' AS DateTime), NULL, 1, N'B216631', N'RITOM SICAV-RAIF', N'RITOM SICAV-RAIF', N'529900QN7IEME9MI2J78', N'V00001829', N'1829', N'1829', N'1829', 2, 2, 4, 1, N'2017 2207 554', NULL, N'NEW PROSPECTUS ', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (9, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, 4, N'B166082', N'SWISSNESS', N'SWISSNESS', N'Never requested', N'O00003553', N'3553', N'3553', N'3553', 2, 1, 1, 1, N'2011 4503 186', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (10, CAST(N'2018-08-28T00:00:00.000' AS DateTime), NULL, 1, N'B175600', N'SWAN SICAV-SIF', N'SWAN SICAV-SIF', N'529900H6INIJHLCW4R96', N'O00007843', N'7843', N'7843', N'7843', 2, 2, 2, 1, N'2013 4500 329', NULL, NULL, NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (11, CAST(N'2003-07-31T00:00:00.000' AS DateTime), CAST(N'2019-05-31T00:00:00.000' AS DateTime), 1, N'O00003599', N'TIMEO NEUTRAL SICAV', N'TIMEO NEUTRAL SICAV', N'529900II6NUSUF43EY69', N'O00003599', N'3599', N'3599', N'3599', 2, 1, 1, 1, N'2003 4500 445', NULL, N'NEW PROSPECTUS', NULL, NULL, NULL, 1)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (11, CAST(N'2019-06-01T00:00:00.000' AS DateTime), NULL, 1, N'O00003599', N'TIMEO NEUTRAL SICAV', N'TIMEO NEUTRAL SICAV', N'529900II6NUSUF43EY69', N'O00003599', N'3599', N'3599', N'3599', 2, 1, 1, 1, N'2003 4500 445', NULL, N'NEW PROSPECTUS', NULL, NULL, NULL, 1)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (12, CAST(N'2018-03-12T00:00:00.000' AS DateTime), CAST(N'2019-08-20T00:00:00.000' AS DateTime), 1, N'B222856', N'UNITED SICAV-RAIF', N'UNITED SICAV-RAIF', N'54930084108B8S6V7E17', N'V00001957', N'1957', N'1957', N'1957', 2, 2, 4, 1, N'2018 4500 583', NULL, N'NEW PROSPECTUS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (12, CAST(N'2019-08-21T00:00:00.000' AS DateTime), NULL, 1, N'B222856', N'UNITED SICAV-RAIF', N'UNITED SICAV-RAIF', N'54930084108B8S6V7E17', N'V00001957', N'1957', N'1957', N'1957', 2, 2, 4, 1, N'2018 4500 583', NULL, N'NEW PROSPECTUS', NULL, NULL, NULL, 3)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (15, CAST(N'2020-08-28T00:00:00.000' AS DateTime), NULL, 1, NULL, N'MH FUND SA SICAV-SIF', N'MH FUND SA SICAV-SIF', NULL, N'O00008878', N'LU8251', N'LU8251', N'LU8251', 2, 2, 2, 1, N'2016 4501 370', NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (16, CAST(N'2003-06-20T00:00:00.000' AS DateTime), CAST(N'2019-08-30T00:00:00.000' AS DateTime), 1, NULL, N'SIFTER FUND', N'SIFTER FUND', N'EVK05KS7XY1DEII3R011', N'O00003553', N'38001F', N'38001F', N'38001F', 2, 1, 1, 1, NULL, N'Sifter fund migrated to ADEPA ManCo', N'CHANGE MANCO', NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_historyFund] ([f_id], [f_initial_date], [f_end_date], [f_status], [f_registration_number], [f_official_fund_name], [f_short_fund_name], [f_lei_code], [f_cssf_code], [f_fa_code], [f_dep_code], [f_ta_code], [f_legal_form], [f_legal_type], [f_legal_vehicle], [f_company_type], [f_tin_number], [f_change_comment], [f_comment_title], [f_vat_registration_number], [f_vat_identification_number], [f_ibic_number], [f_fund_admin]) VALUES (16, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, 3, NULL, N'SIFTER FUND', N'SIFTER FUND', N'EVK05KS7XY1DEII3R011', N'O00003553', N'38001F', N'38001F', N'38001F', 2, 1, 1, 1, NULL, N'Sifter fund migrated to ADEPA ManCo', N'CHANGE MANCO', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (1, CAST(N'2011-07-14T00:00:00.000' AS DateTime), CAST(N'2019-08-12T00:00:00.000' AS DateTime), N'Efficiency Growth Fund - Euro Global Bond I EUR', N'Efficiency Growth Fund - Euro Global Bond I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2012-12-31T00:00:00.000' AS DateTime), CAST(N'2012-12-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, N'EFFEGIE LX', NULL, N'LU0828733419', NULL, N'51115', NULL, N'A12FXJ', NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (1, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL, N'GFG Funds Euro Global Bond I EUR', N'GFG Funds Euro Global Bond I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2012-12-31T00:00:00.000' AS DateTime), CAST(N'2012-12-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, N'EFFEGIE LX', NULL, N'LU0828733419', NULL, N'51115', NULL, N'A12FXJ', NULL, N'I', NULL, N'SHARE CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (2, CAST(N'2011-07-14T00:00:00.000' AS DateTime), CAST(N'2019-08-12T00:00:00.000' AS DateTime), N'Efficiency Growth Fund - Euro Global Bond P EUR', N'Efficiency Growth Fund - Euro Global Bond P EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2011-07-14T00:00:00.000' AS DateTime), CAST(N'2011-07-14T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, N'EFFEGBB LX', NULL, N'LU0622616760', N'12909862', N'51115', NULL, N'A1JG8V', NULL, N'P', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (2, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL, N'GFG Funds Euro Global Bond P EUR', N'GFG Funds Euro Global Bond P EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2011-07-14T00:00:00.000' AS DateTime), CAST(N'2011-07-14T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, N'EFFEGBB LX', NULL, N'LU0622616760', N'12909862', N'51115', NULL, N'A1JG8V', NULL, N'P', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (3, CAST(N'2014-09-26T00:00:00.000' AS DateTime), CAST(N'2019-08-12T00:00:00.000' AS DateTime), N'Efficiency Growth Fund - Euro Global Bond PP EUR', N'Efficiency Growth Fund - Euro Global Bond PP EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2014-09-26T00:00:00.000' AS DateTime), CAST(N'2014-09-26T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 0, 0, NULL, NULL, NULL, N'LU1095075120', N'25029901', N'51115', NULL, N'A12FXK', NULL, N'PP', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (3, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL, N'GFG Funds Euro Global Bond PP EUR', N'GFG Funds Euro Global Bond PP EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2014-09-26T00:00:00.000' AS DateTime), CAST(N'2014-09-26T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 0, 0, NULL, NULL, NULL, N'LU1095075120', N'25029901', N'51115', NULL, N'A12FXK', NULL, N'PP', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (4, CAST(N'2015-03-26T00:00:00.000' AS DateTime), NULL, N'GFG Funds Euro Global Bond P CHF', N'GFG Funds Euro Global Bond P CHF', 1, 1, N'CHF', NULL, NULL, CAST(N'2015-03-26T00:00:00.000' AS DateTime), CAST(N'2015-03-26T00:00:00.000' AS DateTime), NULL, NULL, 4, 100, N'C7', 1, 0, NULL, NULL, NULL, N'LU1196450263', NULL, N'51115', NULL, NULL, NULL, N'P', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (5, CAST(N'2014-11-21T00:00:00.000' AS DateTime), NULL, N'GFG Funds Euro Global Bond P USD', N'GFG Funds Euro Global Bond P USD', 1, 1, N'USD', NULL, NULL, CAST(N'2014-11-21T00:00:00.000' AS DateTime), CAST(N'2014-11-21T00:00:00.000' AS DateTime), NULL, NULL, 4, 100, N'C4', 1, 0, NULL, NULL, NULL, N'LU1138304412', NULL, N'51115', NULL, NULL, NULL, N'P', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (6, CAST(N'2014-11-27T00:00:00.000' AS DateTime), NULL, N'GFG Funds Euro Global Bond PP USD', N'GFG Funds Euro Global Bond PP USD', 1, 1, N'USD', NULL, NULL, CAST(N'2014-11-27T00:00:00.000' AS DateTime), CAST(N'2014-11-27T00:00:00.000' AS DateTime), NULL, NULL, 4, 100, N'C5', 1, 0, NULL, NULL, NULL, N'LU1138304768', NULL, N'51115', NULL, NULL, NULL, N'PP', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (7, CAST(N'2015-10-13T00:00:00.000' AS DateTime), NULL, N'GFG Funds Euro Global Bond Q EUR', N'GFG Funds Euro Global Bond Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-10-13T00:00:00.000' AS DateTime), CAST(N'2015-10-13T00:00:00.000' AS DateTime), NULL, NULL, 4, 100, N'CA', 0, 0, NULL, NULL, NULL, N'LU1249211803', NULL, N'51115', NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (8, CAST(N'2017-06-30T00:00:00.000' AS DateTime), CAST(N'2019-08-12T00:00:00.000' AS DateTime), N'Efficiency Growth Fund - Income Opportunity I EUR', N'Efficiency Growth Fund - Income Opportunity I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2017-06-30T00:00:00.000' AS DateTime), CAST(N'2017-06-30T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1620753571', N'36692596', N'33646', NULL, N'A2DYLU', NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (8, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL, N'GFG Funds Income Opportunity I EUR', N'GFG Funds Income Opportunity I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2017-06-30T00:00:00.000' AS DateTime), CAST(N'2017-06-30T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1620753571', N'36692596', N'33646', NULL, N'A2DYLU', NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (9, CAST(N'2017-06-30T00:00:00.000' AS DateTime), CAST(N'2019-08-12T00:00:00.000' AS DateTime), N'Efficiency Growth Fund - Income Opportunity P EUR', N'Efficiency Growth Fund - Income Opportunity P EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-06-30T00:00:00.000' AS DateTime), CAST(N'2017-06-30T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1620753811', N'36695603', N'33646', NULL, N'A2DYLV', NULL, N'P', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (9, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL, N'GFG Funds Income Opportunity P EUR', N'GFG Funds Income Opportunity P EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-06-30T00:00:00.000' AS DateTime), CAST(N'2017-06-30T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1620753811', N'36695603', N'33646', NULL, N'A2DYLV', NULL, N'P', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (10, CAST(N'2015-12-21T00:00:00.000' AS DateTime), NULL, N'Emerald Sicav Euro Investment Grade Bond I EUR', N'Emerald Sicav Euro Investment Grade Bond I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2015-12-21T00:00:00.000' AS DateTime), CAST(N'2015-12-21T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, NULL, NULL, N'EMEIGBI LX', NULL, N'LU1336188484', N'30734142', N'8062', NULL, N'A2AH7S', NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (11, CAST(N'2016-09-14T00:00:00.000' AS DateTime), CAST(N'2020-03-15T00:00:00.000' AS DateTime), N'Emerald Sicav Euro Investment Grade Bond II EUR', N'Emerald Sicav Euro Investment Grade Bond II EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2016-09-14T00:00:00.000' AS DateTime), CAST(N'2016-09-14T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, NULL, NULL, N'EMEIGII LX', NULL, N'LU1462003622', N'33337919', N'8062', NULL, N'A2DW3U', NULL, N'II', N'dormant', N'DORMANT')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (11, CAST(N'2020-03-16T00:00:00.000' AS DateTime), NULL, N'Emerald Sicav Euro Investment Grade Bond II EUR', N'Emerald Sicav Euro Investment Grade Bond II EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2016-09-14T00:00:00.000' AS DateTime), CAST(N'2016-09-14T00:00:00.000' AS DateTime), NULL, NULL, 3, 0, N'C4', 0, 0, NULL, N'EMEIGII LX', NULL, N'LU1462003622', N'33337919', N'8062', NULL, N'A2DW3U', NULL, N'II', N'dormant', N'DORMANT')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (12, CAST(N'2015-12-17T00:00:00.000' AS DateTime), NULL, N'Emerald Sicav Euro Investment Grade Bond R EUR', N'Emerald Sicav Euro Investment Grade Bond R EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-12-17T00:00:00.000' AS DateTime), CAST(N'2015-12-17T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU1336188211', N'30733839', N'8062', NULL, N'A2DK8A', NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (13, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Emerald Sicav Euro Investment Grade Bond RR EUR', N'Emerald Sicav Euro Investment Grade Bond RR EUR', 1, 1, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 1, 100, N'C3', 0, NULL, NULL, N'EMEIGRR LX', NULL, N'LU1462002228', N'33337912', N'8062', NULL, N'A2DGRM', NULL, N'RR', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (14, CAST(N'2017-12-19T00:00:00.000' AS DateTime), NULL, N'Emerald Sicav Euro Inflation-Linked Bond R EUR', N'Emerald Sicav Euro Inflation-Linked Bond R EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-19T00:00:00.000' AS DateTime), CAST(N'2017-12-19T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU1737062783', N'39544945', N'88057', NULL, N'A2JE3C', NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (15, CAST(N'2017-12-29T00:00:00.000' AS DateTime), NULL, N'Emerald Sicav Euro Inflation-Linked Bond I EUR', N'Emerald Sicav Euro Inflation-Linked Bond I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2017-12-29T00:00:00.000' AS DateTime), CAST(N'2017-12-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, NULL, NULL, NULL, NULL, N'LU1737062866', N'39544947', N'88057', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (16, CAST(N'2017-02-06T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Active Income Fund I EUR', N'Timeo Neutral Sicav BZ Active Income Fund I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2017-02-06T00:00:00.000' AS DateTime), CAST(N'2017-02-06T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, NULL, NULL, NULL, NULL, N'LU0857402530', N'20005497', N'32679', N'32679', N'A2DX5E', NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (17, CAST(N'2014-07-03T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Active Income Fund I USD', N'Timeo Neutral Sicav BZ Active Income Fund I USD', 4, 1, N'USD', NULL, NULL, CAST(N'2014-07-03T00:00:00.000' AS DateTime), CAST(N'2014-07-03T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C6', 1, NULL, NULL, N'NEUGAIU LX', NULL, N'LU1080257949', N'24698897', N'32681', N'32681', N'A2DX5D', NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (18, CAST(N'2012-11-29T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Active Income Fund R EUR', N'Timeo Neutral Sicav BZ Active Income Fund R EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2012-11-29T00:00:00.000' AS DateTime), CAST(N'2012-11-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, N'NEUGAAR LX', NULL, N'LU0857402373', N'20005494', N'32676', N'32676', N'A2DLHA', NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (19, CAST(N'2012-06-29T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Conservative Wolf Fund I EUR', N'Timeo Neutral Sicav BZ Conservative Wolf Fund I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2012-06-29T00:00:00.000' AS DateTime), CAST(N'2012-06-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, NULL, NULL, N'NWOLFIE LX', NULL, N'LU0792923541', N'18761192', N'32537', NULL, N'A2PBZ0', NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (20, CAST(N'2013-01-31T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Conservative Wolf Fund I USD', N'Timeo Neutral Sicav BZ Conservative Wolf Fund I USD', 4, 1, N'USD', NULL, NULL, CAST(N'2013-01-31T00:00:00.000' AS DateTime), CAST(N'2013-01-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C6', 1, NULL, NULL, N'NWOLFIU LX', NULL, N'LU0875482522', N'20395756', N'32537', NULL, N'A2PBZ1', NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (21, CAST(N'2012-07-19T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Conservative Wolf Fund R CHF', N'Timeo Neutral Sicav BZ Conservative Wolf Fund R CHF', 1, 1, N'CHF', NULL, NULL, CAST(N'2012-07-19T00:00:00.000' AS DateTime), CAST(N'2012-07-19T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 1, NULL, NULL, N'NWOLFRC LX', NULL, N'LU0805149647', N'18986994', N'32537', NULL, NULL, NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (22, CAST(N'2012-06-29T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Conservative Wolf Fund R EUR', N'Timeo Neutral Sicav BZ Conservative Wolf Fund R EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2012-06-29T00:00:00.000' AS DateTime), CAST(N'2012-06-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, N'NWOLFRE LX', NULL, N'LU0792923384', N'18761188', N'32537', NULL, N'A1J720', NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (23, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Conservative Wolf Fund I CHF', N'Timeo Neutral Sicav BZ Conservative Wolf Fund I CHF', 1, 1, N'CHF', NULL, NULL, NULL, NULL, NULL, NULL, 4, 100, N'C3', 1, 0, NULL, NULL, NULL, N'LU0875428822', NULL, N'32537', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (24, CAST(N'2018-06-18T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Amares Strategy Fund - Balanced A', N'Multi Stars SICAV Amares Strategy Fund - Balanced A', 1, 1, N'EUR', NULL, NULL, CAST(N'2019-05-02T00:00:00.000' AS DateTime), CAST(N'2019-05-02T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1842715168', NULL, N'LU6714', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (25, CAST(N'2015-03-27T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Cefisa Relative Strength Global Asset Allocation B EUR', N'Multi Stars SICAV Cefisa Relative Strength Global Asset Allocation B EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU0950572841', NULL, N'LU6275', NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (26, CAST(N'2018-06-04T00:00:00.000' AS DateTime), CAST(N'2019-12-13T00:00:00.000' AS DateTime), N'Multi Stars SICAV Hearth Ethical Fund F USD', N'Multi Stars SICAV Hearth Ethical Fund F USD', 4, 1, N'USD', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1936207015', NULL, N'LU6658', NULL, NULL, NULL, N'F', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (27, CAST(N'2019-05-28T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Hearth Ethical Fund A1 EUR', N'Multi Stars SICAV Hearth Ethical Fund A1 EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2019-10-16T00:00:00.000' AS DateTime), CAST(N'2019-10-16T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1936207106', NULL, N'LU6658', NULL, NULL, NULL, N'A1', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (28, CAST(N'2019-05-22T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Hearth Ethical Fund Z EUR', N'Multi Stars SICAV Hearth Ethical Fund Z EUR', 6, 1, N'EUR', NULL, NULL, CAST(N'2019-11-07T00:00:00.000' AS DateTime), CAST(N'2019-11-07T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU2028896897', NULL, N'LU6658', NULL, NULL, NULL, N'Z', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (29, CAST(N'2019-05-28T00:00:00.000' AS DateTime), NULL, N'Multi Stars Sicav - Hearth Ethical Fund D CHF', N'Multi Stars Sicav - Hearth Ethical Fund D CHF', 4, 1, N'CHF', NULL, NULL, CAST(N'2019-12-10T00:00:00.000' AS DateTime), CAST(N'2019-12-10T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1936204939', NULL, N'LU6658', NULL, NULL, NULL, N'D', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (30, CAST(N'2010-06-16T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Inflation Linked Bds Fd I EUR', N'Timeo Neutral Sicav BZ Inflation Linked Bds Fd I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2010-06-16T00:00:00.000' AS DateTime), CAST(N'2010-06-16T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, NULL, NULL, N'VEGNILI LX', NULL, N'LU0469024839', N'11528166', N'32536', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (31, CAST(N'2013-01-24T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Inflation Linked Bds Fd I USD', N'Timeo Neutral Sicav BZ Inflation Linked Bds Fd I USD', 4, 1, N'USD', NULL, NULL, CAST(N'2013-01-24T00:00:00.000' AS DateTime), CAST(N'2013-01-24T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C6', 1, NULL, NULL, N'NEUILBI LX', NULL, N'LU0875487752', N'20428863', N'32536', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (32, CAST(N'2012-02-01T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Inflation Linked Bds Fd R CHF', N'Timeo Neutral Sicav BZ Inflation Linked Bds Fd R CHF', 1, 1, N'CHF', NULL, NULL, CAST(N'2012-02-01T00:00:00.000' AS DateTime), CAST(N'2012-02-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 1, NULL, NULL, N'NEUILBR LX', NULL, N'LU0738461291', N'14822597', N'32536', NULL, NULL, NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (33, CAST(N'2003-08-01T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Inflation Linked Bds Fd R EUR', N'Timeo Neutral Sicav BZ Inflation Linked Bds Fd R EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2003-08-01T00:00:00.000' AS DateTime), CAST(N'2003-08-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, N'VEGNILB LX', NULL, N'LU0172366956', N'1637913', N'32536', NULL, N'A0Q0UT', NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (34, CAST(N'2013-01-24T00:00:00.000' AS DateTime), CAST(N'2018-11-19T00:00:00.000' AS DateTime), N'Timeo Neutral Sicav BZ Inflation Linked Bds Fd R USD', N'Timeo Neutral Sicav BZ Inflation Linked Bds Fd R USD', 1, 1, N'USD', NULL, NULL, CAST(N'2013-01-24T00:00:00.000' AS DateTime), CAST(N'2013-01-24T00:00:00.000' AS DateTime), NULL, NULL, 3, 100, N'C3', 1, NULL, NULL, NULL, NULL, N'LU0875486515', NULL, N'32536', NULL, NULL, NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (35, CAST(N'2020-01-02T00:00:00.000' AS DateTime), NULL, N'Ritom Sicav - RAIF Archimede A EUR', N'Ritom Sicav - RAIF Archimede A EUR', 5, NULL, N'EUR', NULL, NULL, CAST(N'2020-01-31T00:00:00.000' AS DateTime), CAST(N'2020-01-31T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU2098359594', NULL, N'23764', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (36, CAST(N'2020-01-02T00:00:00.000' AS DateTime), NULL, N'Ritom Sicav - RAIF Archimede B EUR', N'Ritom Sicav - RAIF Archimede B EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU2098359677', NULL, N'23764', NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (37, CAST(N'2020-01-02T00:00:00.000' AS DateTime), NULL, N'Ritom Sicav - RAIF Astipalea A EUR', N'Ritom Sicav - RAIF Astipalea A EUR', 5, NULL, N'EUR', NULL, NULL, CAST(N'2020-01-20T00:00:00.000' AS DateTime), CAST(N'2020-01-20T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU2098359750', NULL, N'23765', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (38, CAST(N'2020-01-02T00:00:00.000' AS DateTime), NULL, N'Ritom Sicav - RAIF Astipalea B EUR', N'Ritom Sicav - RAIF Astipalea B EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU2098359834', NULL, N'23765', NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (39, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL, N'GFG Funds Global Enhanced Cash I EUR', N'GFG Funds Global Enhanced Cash I EUR', 4, NULL, N'EUR', NULL, NULL, CAST(N'2020-03-05T00:00:00.000' AS DateTime), CAST(N'2020-03-05T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, N'C1', 0, 0, NULL, NULL, NULL, N'LU1981743435', NULL, N'38110', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (40, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL, N'GFG Funds Global Enhanced Cash P EUR', N'GFG Funds Global Enhanced Cash P EUR', 1, NULL, N'EUR', NULL, NULL, CAST(N'2020-03-16T00:00:00.000' AS DateTime), CAST(N'2020-03-16T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, N'C2', 0, 0, NULL, NULL, NULL, N'LU1981743518', NULL, N'38110', NULL, NULL, NULL, N'P', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (41, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL, N'GFG Funds Global Enhanced Cash PP EUR', N'GFG Funds Global Enhanced Cash PP EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1981743609', NULL, N'38110', NULL, NULL, NULL, N'PP', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (42, CAST(N'2015-07-03T00:00:00.000' AS DateTime), CAST(N'2020-09-14T00:00:00.000' AS DateTime), N'Timeo Neutral Sicav CFO America 38 I EUR', N'Timeo Neutral Sicav CFO America 38 I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2015-07-07T00:00:00.000' AS DateTime), CAST(N'2015-07-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1244114911', NULL, N'32724', N'32724', NULL, NULL, N'I', N'SUBFUND in liquidation - Share dormant', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (42, CAST(N'2020-09-15T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav CFO America 38 I EUR', N'Timeo Neutral Sicav CFO America 38 I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2015-07-07T00:00:00.000' AS DateTime), CAST(N'2015-07-07T00:00:00.000' AS DateTime), NULL, NULL, 3, 0, N'C2', 0, 0, NULL, NULL, NULL, N'LU1244114911', NULL, N'32724', N'32724', NULL, NULL, N'I', N'SUBFUND in liquidation - Share dormant', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (43, CAST(N'2015-09-22T00:00:00.000' AS DateTime), CAST(N'2020-09-14T00:00:00.000' AS DateTime), N'Timeo Neutral Sicav CFO America 38 R EUR', N'Timeo Neutral Sicav CFO America 38 R EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-09-22T00:00:00.000' AS DateTime), CAST(N'2015-09-22T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1256231405', NULL, N'32723', N'32723', NULL, NULL, N'R', N'SUBFUND in liquidation - Share dormant', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (43, CAST(N'2020-09-15T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav CFO America 38 R EUR', N'Timeo Neutral Sicav CFO America 38 R EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-09-22T00:00:00.000' AS DateTime), CAST(N'2015-09-22T00:00:00.000' AS DateTime), NULL, NULL, 3, 0, N'C1', 0, 0, NULL, NULL, NULL, N'LU1256231405', NULL, N'32723', N'32723', NULL, NULL, N'R', N'SUBFUND in liquidation - Share dormant', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (44, CAST(N'2015-07-03T00:00:00.000' AS DateTime), CAST(N'2020-09-14T00:00:00.000' AS DateTime), N'Timeo Neutral Sicav CFO Europa 38 I EUR', N'Timeo Neutral Sicav CFO Europa 38 I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2015-09-21T00:00:00.000' AS DateTime), CAST(N'2015-09-21T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, NULL, NULL, NULL, NULL, N'LU1244114671', NULL, N'32722', N'32722', NULL, NULL, N'I', N'SUBFUND in liquidation - Share dormant', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (44, CAST(N'2020-09-15T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav CFO Europa 38 I EUR', N'Timeo Neutral Sicav CFO Europa 38 I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2015-09-21T00:00:00.000' AS DateTime), CAST(N'2015-09-21T00:00:00.000' AS DateTime), NULL, NULL, 3, 0, N'C2', 0, 0, NULL, NULL, NULL, N'LU1244114671', NULL, N'32722', N'32722', NULL, NULL, N'I', N'SUBFUND in liquidation - Share dormant', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (45, CAST(N'2015-09-22T00:00:00.000' AS DateTime), CAST(N'2020-09-14T00:00:00.000' AS DateTime), N'Timeo Neutral Sicav CFO Europa 38 R EUR', N'Timeo Neutral Sicav CFO Europa 38 R EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-09-21T00:00:00.000' AS DateTime), CAST(N'2015-09-21T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU1256231587', NULL, N'32699', N'32699', NULL, NULL, N'R', N'SUBFUND in liquidation - Share dormant', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (45, CAST(N'2020-09-15T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav CFO Europa 38 R EUR', N'Timeo Neutral Sicav CFO Europa 38 R EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-09-21T00:00:00.000' AS DateTime), CAST(N'2015-09-21T00:00:00.000' AS DateTime), NULL, NULL, 3, 0, N'C1', 0, 0, NULL, NULL, NULL, N'LU1256231587', NULL, N'32699', N'32699', NULL, NULL, N'R', N'SUBFUND in liquidation - Share dormant', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (46, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2019-08-06T00:00:00.000' AS DateTime), N'Timeo Neutral Sicav Europ Abs Ret Fd A Institutional EUR', N'Timeo Neutral Sicav Europ Abs Ret Fd A Institutional EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1506684098', N'34252803', NULL, NULL, NULL, NULL, N'A', N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (46, CAST(N'2019-08-07T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav Europ Abs Ret Fd A Institutional EUR', N'Timeo Neutral Sicav Europ Abs Ret Fd A Institutional EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 2, 0, N'C2', 0, 0, NULL, NULL, NULL, N'LU1506684098', N'34252803', N'16400A', NULL, NULL, NULL, N'A', N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (47, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2019-08-06T00:00:00.000' AS DateTime), N'Timeo Neutral Sicav Europ Abs Ret Fd A Listed EUR', N'Timeo Neutral Sicav Europ Abs Ret Fd A Listed EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C5', 0, 0, NULL, NULL, NULL, N'LU1506684254', N'34252812', NULL, NULL, N'A2H5X4', NULL, N'A', N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (47, CAST(N'2019-08-07T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav Europ Abs Ret Fd A Listed EUR', N'Timeo Neutral Sicav Europ Abs Ret Fd A Listed EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 2, 0, N'C5', 0, 0, NULL, NULL, NULL, N'LU1506684254', N'34252812', N'16400C5', NULL, N'A2H5X4', NULL, N'A', N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (48, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2019-08-06T00:00:00.000' AS DateTime), N'Timeo Neutral Sicav Europ Abs Ret Fd A No Load EUR', N'Timeo Neutral Sicav Europ Abs Ret Fd A No Load EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, 0, NULL, NULL, NULL, N'LU1506683959', N'34252802', NULL, NULL, N'A2JCUY', NULL, N'A', N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (48, CAST(N'2019-08-07T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav Europ Abs Ret Fd A No Load EUR', N'Timeo Neutral Sicav Europ Abs Ret Fd A No Load EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 3, 0, N'C4', 0, 0, NULL, NULL, NULL, N'LU1506683959', N'34252802', N'16400C', NULL, N'A2JCUY', NULL, N'A', N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (49, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2019-08-06T00:00:00.000' AS DateTime), N'Timeo Neutral Sicav Europ Abs Ret Fd A Retail UH EUR', N'Timeo Neutral Sicav Europ Abs Ret Fd A Retail UH EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU1506683793', N'34252791', NULL, NULL, NULL, NULL, NULL, N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (49, CAST(N'2019-08-07T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav Europ Abs Ret Fd A Retail UH EUR', N'Timeo Neutral Sicav Europ Abs Ret Fd A Retail UH EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 2, 0, N'C1', 0, 0, NULL, NULL, NULL, N'LU1506683793', N'34252791', N'16400C1', NULL, NULL, NULL, NULL, N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (50, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2019-08-06T00:00:00.000' AS DateTime), N'Timeo Neutral Sicav Europ Abs Ret Fd A Retail UH S2 EUR', N'Timeo Neutral Sicav Europ Abs Ret Fd A Retail UH S2 EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 0, NULL, NULL, NULL, NULL, N'LU1506683876', N'34252798', NULL, NULL, NULL, NULL, NULL, N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (50, CAST(N'2019-08-07T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav Europ Abs Ret Fd A Retail UH S2 EUR', N'Timeo Neutral Sicav Europ Abs Ret Fd A Retail UH S2 EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 3, 0, N'C3', 0, 0, NULL, NULL, NULL, N'LU1506683876', N'34252798', N'16400C3', NULL, NULL, NULL, N'UH', N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (51, CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Long Short Credit Fund A CHF', N'Swan SICAV SIF SWAN Long Short Credit Fund A CHF', 5, 1, N'CHF', NULL, NULL, CAST(N'2014-01-15T00:00:00.000' AS DateTime), CAST(N'2014-01-15T00:00:00.000' AS DateTime), CAST(N'2020-07-27T00:00:00.000' AS DateTime), NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1019167318', NULL, N'19878', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (52, CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Long Short Credit Fund A USD', N'Swan SICAV SIF SWAN Long Short Credit Fund A USD', 5, 1, N'USD', NULL, NULL, CAST(N'2014-01-15T00:00:00.000' AS DateTime), CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1019167151', NULL, N'19878', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (53, CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Long Short Credit Fund B CHF', N'Swan SICAV SIF SWAN Long Short Credit Fund B CHF', 6, 1, N'CHF', NULL, NULL, CAST(N'2014-01-15T00:00:00.000' AS DateTime), CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1019167581', NULL, N'19878', NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (54, CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Long Short Credit Fund B USD', N'Swan SICAV SIF SWAN Long Short Credit Fund B USD', NULL, 1, N'USD', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1019167409', NULL, N'19878', NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (55, CAST(N'2018-08-07T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav Syntagma Absolute Return I EUR', N'Timeo Neutral Sicav Syntagma Absolute Return I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2018-08-07T00:00:00.000' AS DateTime), CAST(N'2018-08-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 1, 0, NULL, NULL, NULL, N'LU1847646525', N'793973', NULL, NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (56, CAST(N'2018-08-07T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav Syntagma Absolute Return R PRIME USD', N'Timeo Neutral Sicav Syntagma Absolute Return R PRIME USD', 1, 1, N'USD', NULL, NULL, CAST(N'2018-08-07T00:00:00.000' AS DateTime), CAST(N'2018-08-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1847645980', N'793973', NULL, NULL, N'A2PBMW', NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (57, CAST(N'2018-08-07T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav Syntagma Absolute Return R PRIME EUR HGD', N'Timeo Neutral Sicav Syntagma Absolute Return R PRIME EUR HGD', 1, 1, N'EUR', NULL, NULL, CAST(N'2018-08-07T00:00:00.000' AS DateTime), CAST(N'2018-08-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 1, 0, NULL, NULL, NULL, N'LU1847646798', N'793973', NULL, NULL, NULL, NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (58, CAST(N'2018-08-07T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav Syntagma Absolute Return I USD', N'Timeo Neutral Sicav Syntagma Absolute Return I USD', 4, 1, N'USD', NULL, NULL, CAST(N'2018-08-07T00:00:00.000' AS DateTime), CAST(N'2018-08-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1847646368', N'793973', NULL, NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (59, CAST(N'2018-06-13T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Best Global Managers Flexible Equity A EUR', N'Timeo Neutral Sicav BZ Best Global Managers Flexible Equity A EUR', 1, NULL, N'EUR', NULL, NULL, CAST(N'2019-07-31T00:00:00.000' AS DateTime), CAST(N'2019-07-31T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 1, NULL, NULL, NULL, N'LU1850436491', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (60, CAST(N'2018-06-13T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Best Global Managers Flexible Equity I EUR', N'Timeo Neutral Sicav BZ Best Global Managers Flexible Equity I EUR', 4, NULL, N'EUR', NULL, NULL, CAST(N'2019-07-31T00:00:00.000' AS DateTime), CAST(N'2019-07-31T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1850436228', NULL, NULL, NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (61, CAST(N'2018-06-13T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral Sicav BZ Best Global Managers Flexible Equity R EUR', N'Timeo Neutral Sicav BZ Best Global Managers Flexible Equity R EUR', 1, NULL, N'EUR', NULL, NULL, CAST(N'2019-07-31T00:00:00.000' AS DateTime), CAST(N'2019-07-31T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1850436145', NULL, NULL, NULL, NULL, NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (62, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, N'1st SICAV Athena Balanced R', N'1st SICAV Athena Balanced R', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-06-29T00:00:00.000' AS DateTime), CAST(N'2017-06-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1435778300', NULL, N'30658', NULL, NULL, NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (63, CAST(N'2017-05-10T00:00:00.000' AS DateTime), CAST(N'2019-04-15T00:00:00.000' AS DateTime), N'1st SICAV Europe Small I', N'1st SICAV Europe Small I', 4, 1, N'EUR', NULL, NULL, CAST(N'2017-05-10T00:00:00.000' AS DateTime), CAST(N'2017-05-10T00:00:00.000' AS DateTime), NULL, NULL, 3, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1435777914', NULL, NULL, NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (64, CAST(N'2017-05-05T00:00:00.000' AS DateTime), CAST(N'2019-04-15T00:00:00.000' AS DateTime), N'1st SICAV Europe Small R', N'1st SICAV Europe Small R', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-05-05T00:00:00.000' AS DateTime), CAST(N'2017-05-05T00:00:00.000' AS DateTime), NULL, NULL, 3, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1435777831', NULL, NULL, NULL, NULL, NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (65, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, N'1st SICAV Hestia Conservative R', N'1st SICAV Hestia Conservative R', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-06-29T00:00:00.000' AS DateTime), CAST(N'2017-06-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1435778565', NULL, N'30659', NULL, NULL, NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (66, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, N'1st SICAV Italy I', N'1st SICAV Italy I', 4, 1, N'EUR', NULL, NULL, CAST(N'2017-05-10T00:00:00.000' AS DateTime), CAST(N'2017-05-10T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1435777674', NULL, N'30656', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (67, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, N'1st SICAV Italy R', N'1st SICAV Italy R', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-05-05T00:00:00.000' AS DateTime), CAST(N'2017-05-05T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1435777591', NULL, N'30656', NULL, NULL, NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (68, CAST(N'2017-03-23T00:00:00.000' AS DateTime), NULL, N'Kite Fund SICAV FLexible Credit A EUR', N'Kite Fund SICAV FLexible Credit A EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2017-04-11T00:00:00.000' AS DateTime), CAST(N'2017-04-11T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D1', 0, 0, NULL, NULL, NULL, N'LU1550130873', NULL, N'26886', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (69, CAST(N'2012-09-11T00:00:00.000' AS DateTime), NULL, N'Kite Fund SICAV Total Return A EUR', N'Kite Fund SICAV Total Return A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2012-10-08T00:00:00.000' AS DateTime), CAST(N'2012-10-08T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0830807797', NULL, N'22132', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (70, CAST(N'2010-03-31T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Absolute Return B EUR', N'Pharus Sicav Absolute Return B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2010-03-31T00:00:00.000' AS DateTime), CAST(N'2010-03-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU0515577780', NULL, NULL, NULL, NULL, NULL, N'B', N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (70, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Conservative B EUR', N'Pharus Sicav Conservative B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2010-03-31T00:00:00.000' AS DateTime), CAST(N'2010-03-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU0515577780', NULL, N'40495BEUR', NULL, NULL, NULL, N'B', N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (71, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Absolute Return C USD', N'Pharus Sicav Absolute Return C USD', 4, 1, N'USD', NULL, NULL, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2015-03-09T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 1, 0, NULL, NULL, NULL, N'LU1136401624', NULL, NULL, NULL, NULL, NULL, N'C', N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (71, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Conservative C USD', N'Pharus Sicav Conservative C USD', 4, 1, N'USD', NULL, NULL, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2015-03-09T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 1, 0, NULL, NULL, NULL, N'LU1136401624', NULL, N'40495CUSD', NULL, NULL, NULL, N'C', N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (72, CAST(N'2007-04-15T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Absolute Return A EUR', N'Pharus Sicav Absolute Return A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2007-04-15T00:00:00.000' AS DateTime), CAST(N'2007-04-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0291569647', NULL, NULL, NULL, NULL, NULL, N'A', N'changed name', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (72, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Conservative A EUR', N'Pharus Sicav Conservative A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2007-04-15T00:00:00.000' AS DateTime), CAST(N'2007-04-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0291569647', NULL, N'40495AEUR', NULL, NULL, NULL, N'A', N'changed name', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (73, CAST(N'2017-03-27T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Absolute Return E CHF', N'Pharus Sicav Absolute Return E CHF', 1, 1, N'CHF', NULL, NULL, CAST(N'2017-03-27T00:00:00.000' AS DateTime), CAST(N'2017-03-27T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 1, 0, NULL, NULL, NULL, N'LU1582234149', NULL, NULL, NULL, NULL, NULL, N'E', N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (73, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Conservative E CHF', N'Pharus Sicav Conservative E CHF', 1, 1, N'CHF', NULL, NULL, CAST(N'2017-03-27T00:00:00.000' AS DateTime), CAST(N'2017-03-27T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 1, 0, NULL, NULL, NULL, N'LU1582234149', NULL, N'40495ECHF', NULL, NULL, NULL, N'E', N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (74, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Absolute Return F CHF', N'Pharus Sicav Absolute Return F CHF', 4, 1, N'CHF', NULL, NULL, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2015-03-09T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C5', 1, 0, NULL, NULL, NULL, N'LU1136401541', NULL, NULL, NULL, NULL, NULL, N'F', N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (74, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Conservative F CHF', N'Pharus Sicav Conservative F CHF', 4, 1, N'CHF', NULL, NULL, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2015-03-09T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C5', 1, 0, NULL, NULL, NULL, N'LU1136401541', NULL, N'40495FCHF', NULL, NULL, NULL, N'F', N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (75, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Absolute Return Q EUR', N'Pharus Sicav Absolute Return Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1136401467', NULL, NULL, NULL, NULL, NULL, N'Q', N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (75, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Conservative Q EUR', N'Pharus Sicav Conservative Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1136401467', NULL, N'40495QEUR', NULL, NULL, NULL, N'Q', N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (76, CAST(N'2012-12-02T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Algo Flex A EUR', N'Pharus Sicav Algo Flex A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2012-12-02T00:00:00.000' AS DateTime), CAST(N'2012-12-02T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0833009060', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (77, CAST(N'2012-02-21T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Algo Flex B EUR', N'Pharus Sicav Algo Flex B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2012-02-21T00:00:00.000' AS DateTime), CAST(N'2012-02-21T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU0746320174', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (78, CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Algo Flex Q EUR', N'Pharus Sicav Algo Flex Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1136402788', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (79, CAST(N'2016-05-20T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Athesis Total Return A EUR', N'Pharus Sicav Athesis Total Return A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-05-20T00:00:00.000' AS DateTime), CAST(N'2016-05-20T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1410343914', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
GO
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (80, CAST(N'2016-05-20T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Athesis Total Return B EUR', N'Pharus Sicav Athesis Total Return B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2016-05-20T00:00:00.000' AS DateTime), CAST(N'2016-05-20T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1410345455', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (81, CAST(N'2018-05-04T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Avantgarde A EUR', N'Pharus Sicav Avantgarde A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2018-05-04T00:00:00.000' AS DateTime), CAST(N'2018-05-04T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D3', 0, 0, NULL, NULL, NULL, N'LU1620769494', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (82, CAST(N'2016-12-15T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Avantgarde B EUR', N'Pharus Sicav Avantgarde B EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-12-15T00:00:00.000' AS DateTime), CAST(N'2016-12-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1424613740', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (83, CAST(N'2016-12-15T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Avantgarde C EUR', N'Pharus Sicav Avantgarde C EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2016-12-15T00:00:00.000' AS DateTime), CAST(N'2016-12-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1424614391', NULL, NULL, NULL, NULL, NULL, N'C', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (84, CAST(N'2017-06-26T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Avantgarde I EUR', N'Pharus Sicav Avantgarde I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2017-06-26T00:00:00.000' AS DateTime), CAST(N'2017-06-26T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, 0, NULL, NULL, NULL, N'LU1620769817', NULL, NULL, NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (85, CAST(N'2015-02-20T00:00:00.000' AS DateTime), CAST(N'2020-11-30T00:00:00.000' AS DateTime), N'Pharus Sicav Target G EUR', N'Pharus Sicav Target G EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1732804247', NULL, NULL, NULL, NULL, NULL, N'G', N'class G becomes class A', N'CLASS G BECOMES CLASS A')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (85, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Target A EUR', N'Pharus Sicav Target A EUR', 1, 1, N'EUR', N'LU', NULL, NULL, NULL, NULL, NULL, 4, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1732804247', NULL, N'AEUR', NULL, NULL, NULL, N'A', N'class G becomes class A', N'CLASS G BECOMES CLASS A')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (86, CAST(N'2019-01-18T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Next Revolution I2 EUR', N'Pharus Sicav Next Revolution I2 EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1882538066', NULL, NULL, NULL, NULL, NULL, N'I2', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (87, CAST(N'2016-07-11T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Avantgarde F USD', N'Pharus Sicav Avantgarde F USD', 4, 1, N'USD', NULL, NULL, CAST(N'2019-03-08T00:00:00.000' AS DateTime), CAST(N'2019-03-08T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 1, 0, NULL, NULL, NULL, N'LU1882537928', NULL, NULL, NULL, NULL, NULL, N'F', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (88, CAST(N'2019-07-31T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Global Managers Flexible Equity A EUR', N'Pharus Sicav Best Global Managers Flexible Equity A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2011-07-08T00:00:00.000' AS DateTime), CAST(N'2011-07-08T00:00:00.000' AS DateTime), NULL, NULL, 3, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU0645706689', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (89, CAST(N'2019-07-31T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Global Managers Flexible Equity B EUR', N'Pharus Sicav Best Global Managers Flexible Equity B EUR', 4, NULL, NULL, NULL, NULL, CAST(N'2018-08-01T00:00:00.000' AS DateTime), CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL, NULL, 3, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1842648898', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (90, CAST(N'2019-07-31T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Global Managers Flexible Equity Q EUR', N'Pharus Sicav Best Global Managers Flexible Equity Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, NULL, 3, 100, N'C7', 0, NULL, NULL, NULL, NULL, N'LU1136402358', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (91, CAST(N'2016-10-31T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Biotech A EUR', N'Pharus Sicav Biotech A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-10-31T00:00:00.000' AS DateTime), CAST(N'2016-10-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1491986011', NULL, NULL, NULL, NULL, NULL, N'A', N'rename the sub-fund into Pharus SICAV – Medical Innovation', N'RENAME THE SUB-FUND INTO PHARUS SICAV – MEDICAL IN')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (91, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Medical Innovation A EUR', N'Pharus Sicav Medical Innovation A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-10-31T00:00:00.000' AS DateTime), CAST(N'2016-10-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1491986011', NULL, N'AEUR', NULL, NULL, NULL, N'A', N'rename the sub-fund into Pharus SICAV – Medical Innovation', N'RENAME THE SUB-FUND INTO PHARUS SICAV – MEDICAL IN')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (92, CAST(N'2016-10-31T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Biotech E USD', N'Pharus Sicav Biotech E USD', 1, 1, N'USD', NULL, NULL, CAST(N'2016-10-31T00:00:00.000' AS DateTime), CAST(N'2016-10-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C5', 1, 0, NULL, NULL, NULL, N'LU1491986441', NULL, NULL, NULL, NULL, NULL, N'E', N'RENAME THE SUB-FUND INTO PHARUS SICAV – MEDICAL INNOVATION AND E BECOMES AH', N'RENAME THE SUB-FUND INTO PHARUS SICAV – MEDICAL IN')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (92, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Medical Innovation AH USD', N'Pharus Sicav Medical Innovation AH USD', 1, 1, N'USD', N'LU', NULL, CAST(N'2016-10-31T00:00:00.000' AS DateTime), CAST(N'2016-10-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 0, N'C5', 1, 0, NULL, NULL, NULL, N'LU1491986441', NULL, N'AHUSD', NULL, NULL, NULL, N'AHUSD', N'RENAME THE SUB-FUND INTO PHARUS SICAV – MEDICAL INNOVATION AND E BECOMES AH', N'RENAME THE SUB-FUND INTO PHARUS SICAV – MEDICAL IN')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (93, CAST(N'2016-10-31T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Biotech I EUR', N'Pharus Sicav Biotech I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2016-10-31T00:00:00.000' AS DateTime), CAST(N'2016-10-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1491986102', NULL, NULL, NULL, NULL, NULL, N'I', N'RENAME THE SUB-FUND INTO PHARUS SICAV – MEDICAL INNOVATION AND CLASS I BECOMES B', N'RENAME THE SUB-FUND INTO PHARUS SICAV – MEDICAL IN')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (93, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Medical Innovation B EUR', N'Pharus Sicav Medical Innovation B EUR', 4, 1, N'EUR', N'LU', NULL, CAST(N'2016-10-31T00:00:00.000' AS DateTime), CAST(N'2016-10-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1491986102', NULL, N'BEUR', NULL, NULL, NULL, N'B', N'RENAME THE SUB-FUND INTO PHARUS SICAV – MEDICAL INNOVATION AND CLASS I BECOMES B', N'RENAME THE SUB-FUND INTO PHARUS SICAV – MEDICAL IN')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (94, CAST(N'2003-01-31T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Bond Opportunities A EUR', N'Pharus Sicav Bond Opportunities A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2003-01-31T00:00:00.000' AS DateTime), CAST(N'2003-01-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0159790970', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (95, CAST(N'2008-05-21T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Bond Opportunities B EUR', N'Pharus Sicav Bond Opportunities B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2008-05-21T00:00:00.000' AS DateTime), CAST(N'2008-05-21T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU0365512168', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (96, CAST(N'2013-10-17T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Bond Opportunities C USD', N'Pharus Sicav Bond Opportunities C USD', 4, 2, N'USD', NULL, NULL, CAST(N'2013-10-17T00:00:00.000' AS DateTime), CAST(N'2013-10-17T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'DD', 1, 0, NULL, NULL, NULL, N'LU0985039519', NULL, NULL, NULL, NULL, NULL, N'C', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (97, CAST(N'2018-07-23T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Bond Opportunities D EUR', N'Pharus Sicav Bond Opportunities D EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2018-07-23T00:00:00.000' AS DateTime), CAST(N'2018-07-23T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, 0, NULL, NULL, NULL, N'LU1834915123', NULL, NULL, NULL, NULL, NULL, N'D', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (98, CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Bond Opportunities Q EUR', N'Pharus Sicav Bond Opportunities Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 0, NULL, NULL, NULL, N'LU1136401111', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (99, CAST(N'2017-03-17T00:00:00.000' AS DateTime), CAST(N'2020-03-04T00:00:00.000' AS DateTime), N'Pharus Sicav Bond Value A EUR', N'Pharus Sicav Bond Value A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-03-17T00:00:00.000' AS DateTime), CAST(N'2017-03-17T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'CA', 0, 0, NULL, NULL, NULL, N'LU1480634275', NULL, NULL, NULL, NULL, NULL, N'A', N'LIQUIDATED', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (99, CAST(N'2020-03-05T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Bond Value A EUR', N'Pharus Sicav Bond Value A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-03-17T00:00:00.000' AS DateTime), CAST(N'2017-03-17T00:00:00.000' AS DateTime), CAST(N'2020-03-05T00:00:00.000' AS DateTime), NULL, 2, 100, N'CA', 0, 0, NULL, NULL, NULL, N'LU1480634275', NULL, N'17390A', NULL, NULL, NULL, N'A', N'LIQUIDATED', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (100, CAST(N'2017-05-12T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Deepview Trading A EUR', N'Pharus Sicav Deepview Trading A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-05-12T00:00:00.000' AS DateTime), CAST(N'2017-05-12T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1502105775', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (101, CAST(N'2017-05-12T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Deepview Trading B EUR', N'Pharus Sicav Deepview Trading B EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-05-12T00:00:00.000' AS DateTime), CAST(N'2017-05-12T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1502105858', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (102, CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Deepview Trading C EUR', N'Pharus Sicav Deepview Trading C EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2018-08-01T00:00:00.000' AS DateTime), CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 0, 0, NULL, NULL, NULL, N'LU1834915479', NULL, NULL, NULL, NULL, NULL, N'C', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (103, CAST(N'2011-07-25T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav EOS A1 EUR', N'Pharus Sicav EOS A1 EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2011-07-25T00:00:00.000' AS DateTime), CAST(N'2011-07-25T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0649901526', NULL, NULL, NULL, NULL, NULL, N'A1', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (104, CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Europe Total Return A EUR', N'Pharus Sicav Europe Total Return A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-11-07T00:00:00.000' AS DateTime), CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1437803098', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (105, CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Europe Total Return B CHF', N'Pharus Sicav Europe Total Return B CHF', 1, 1, N'CHF', NULL, NULL, CAST(N'2016-11-07T00:00:00.000' AS DateTime), CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 1, 0, NULL, NULL, NULL, N'LU1437803171', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (106, CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Europe Total Return C USD', N'Pharus Sicav Europe Total Return C USD', 1, 1, N'USD', NULL, NULL, CAST(N'2016-11-07T00:00:00.000' AS DateTime), CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 1, 0, NULL, NULL, NULL, N'LU1437803254', NULL, NULL, NULL, NULL, NULL, N'C', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (107, CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Europe Total Return D EUR', N'Pharus Sicav Europe Total Return D EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-11-07T00:00:00.000' AS DateTime), CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C5', 0, 0, NULL, NULL, NULL, N'LU1437803411', NULL, NULL, NULL, NULL, NULL, N'D', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (108, CAST(N'2017-09-26T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Europe Total Return E CHF', N'Pharus Sicav Europe Total Return E CHF', 1, 1, N'CHF', NULL, NULL, CAST(N'2017-09-26T00:00:00.000' AS DateTime), CAST(N'2017-09-26T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C6', 1, 0, NULL, NULL, NULL, N'LU1437803502', NULL, NULL, NULL, NULL, NULL, N'E', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (109, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Europe Total Return F USD', N'Pharus Sicav Europe Total Return F USD', 1, 1, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, 100, N'C7', 0, 0, NULL, NULL, NULL, N'LU1437803684', NULL, NULL, NULL, NULL, NULL, N'F', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (110, CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Europe Total Return G EUR', N'Pharus Sicav Europe Total Return G EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-11-07T00:00:00.000' AS DateTime), CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, 0, NULL, NULL, NULL, N'LU1437803338', NULL, NULL, NULL, NULL, NULL, N'G', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (111, CAST(N'2018-05-22T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Europe Total Return H EUR', N'Pharus Sicav Europe Total Return H EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2018-05-22T00:00:00.000' AS DateTime), CAST(N'2018-05-22T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C9', 0, 0, NULL, NULL, NULL, N'LU1819985471', NULL, NULL, NULL, NULL, NULL, N'H', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (112, CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Europe Total Return Q EUR', N'Pharus Sicav Europe Total Return Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-11-07T00:00:00.000' AS DateTime), CAST(N'2016-11-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C8', 0, 1, NULL, NULL, NULL, N'LU1437803767', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (113, CAST(N'2014-01-31T00:00:00.000' AS DateTime), CAST(N'2020-05-25T00:00:00.000' AS DateTime), N'Pharus Sicav Global Dynamic Opportunities A EUR', N'Pharus Sicav Global Dynamic Opportunities A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2014-01-31T00:00:00.000' AS DateTime), CAST(N'2014-01-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0881534563', NULL, NULL, NULL, NULL, NULL, N'A', N'LIQUIDATED', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (113, CAST(N'2020-05-26T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Dynamic Opportunities A EUR', N'Pharus Sicav Global Dynamic Opportunities A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2014-01-31T00:00:00.000' AS DateTime), CAST(N'2014-01-31T00:00:00.000' AS DateTime), CAST(N'2020-05-26T00:00:00.000' AS DateTime), NULL, 2, 0, N'C1', 0, 0, NULL, NULL, NULL, N'LU0881534563', NULL, N'19684A', NULL, NULL, NULL, N'A', N'LIQUIDATED', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (114, CAST(N'2014-01-31T00:00:00.000' AS DateTime), CAST(N'2020-05-25T00:00:00.000' AS DateTime), N'Pharus Sicav Global Dynamic Opportunities B EUR', N'Pharus Sicav Global Dynamic Opportunities B EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2014-01-31T00:00:00.000' AS DateTime), CAST(N'2014-01-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU0881534720', NULL, NULL, NULL, NULL, NULL, N'B', N'LIQUIDATED', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (114, CAST(N'2020-05-26T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Dynamic Opportunities B EUR', N'Pharus Sicav Global Dynamic Opportunities B EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2014-01-31T00:00:00.000' AS DateTime), CAST(N'2014-01-31T00:00:00.000' AS DateTime), CAST(N'2020-05-26T00:00:00.000' AS DateTime), NULL, 2, 0, N'C2', 0, 0, NULL, NULL, NULL, N'LU0881534720', NULL, N'19684C2', NULL, NULL, NULL, N'B', N'LIQUIDATED', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (115, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2020-05-25T00:00:00.000' AS DateTime), N'Pharus Sicav Global Dynamic Opportunities C EUR', N'Pharus Sicav Global Dynamic Opportunities C EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2015-03-09T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 0, 0, NULL, NULL, NULL, N'LU1198470442', NULL, NULL, NULL, NULL, NULL, N'C', N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (115, CAST(N'2020-05-26T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Dynamic Opportunities C EUR', N'Pharus Sicav Global Dynamic Opportunities C EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2020-05-26T00:00:00.000' AS DateTime), NULL, 2, 100, N'C3', 0, 0, NULL, NULL, NULL, N'LU1198470442', NULL, N'19684C', NULL, NULL, NULL, N'C', N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (116, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2020-03-11T00:00:00.000' AS DateTime), N'Pharus Sicav Global Dynamic Opportunities Q EUR', N'Pharus Sicav Global Dynamic Opportunities Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1136402945', NULL, NULL, NULL, NULL, NULL, N'Q', N'LIQUIDATED', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (116, CAST(N'2020-03-12T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Dynamic Opportunities Q EUR', N'Pharus Sicav Global Dynamic Opportunities Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2020-03-12T00:00:00.000' AS DateTime), NULL, 2, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1136402945', NULL, N'19684Q', NULL, NULL, NULL, N'Q', N'LIQUIDATED', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (117, CAST(N'2016-04-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Value Equity A EUR', N'Pharus Sicav Global Value Equity A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-04-01T00:00:00.000' AS DateTime), CAST(N'2016-04-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1371477776', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (118, CAST(N'2016-04-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Value Equity AH EUR', N'Pharus Sicav Global Value Equity AH EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-04-01T00:00:00.000' AS DateTime), CAST(N'2016-04-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'CA', 0, 0, NULL, NULL, NULL, N'LU1371477859', NULL, NULL, NULL, NULL, NULL, N'AH', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (119, CAST(N'2016-02-29T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Value Equity C EUR', N'Pharus Sicav Global Value Equity C EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2016-02-29T00:00:00.000' AS DateTime), CAST(N'2016-02-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D3', 0, 0, NULL, NULL, NULL, N'LU1371478154', NULL, NULL, NULL, NULL, NULL, N'C', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (120, CAST(N'2016-02-29T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Value Equity D EUR', N'Pharus Sicav Global Value Equity D EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-02-29T00:00:00.000' AS DateTime), CAST(N'2016-02-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, 0, NULL, NULL, NULL, N'LU1371478238', NULL, NULL, NULL, NULL, NULL, N'D', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (121, CAST(N'2016-06-17T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Value Equity I EUR', N'Pharus Sicav Global Value Equity I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2016-06-17T00:00:00.000' AS DateTime), CAST(N'2016-06-17T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C8', 0, 0, NULL, NULL, NULL, N'LU1427873770', NULL, NULL, NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (122, CAST(N'2016-06-17T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Value Equity IH EUR', N'Pharus Sicav Global Value Equity IH EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2016-06-17T00:00:00.000' AS DateTime), CAST(N'2016-06-17T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C9', 0, 0, NULL, NULL, NULL, N'LU1427874158', NULL, NULL, NULL, NULL, NULL, N'IH', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (123, CAST(N'2016-05-27T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Value Equity Q EUR', N'Pharus Sicav Global Value Equity Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-05-27T00:00:00.000' AS DateTime), CAST(N'2016-05-27T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1371515534', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (124, CAST(N'2016-05-27T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Value Equity QH EUR', N'Pharus Sicav Global Value Equity QH EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-05-27T00:00:00.000' AS DateTime), CAST(N'2016-05-27T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'CI', 0, 1, NULL, NULL, NULL, N'LU1371515880', NULL, NULL, NULL, NULL, NULL, N'QH', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (125, CAST(N'2017-06-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Value Equity QHD EUR', N'Pharus Sicav Global Value Equity QHD EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2017-06-01T00:00:00.000' AS DateTime), CAST(N'2017-06-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D5', 0, 1, NULL, NULL, NULL, N'LU1574104151', NULL, NULL, NULL, NULL, NULL, N'QHD', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (126, CAST(N'2016-05-20T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav I-Bond Plus Solution A USD', N'Pharus Sicav I-Bond Plus Solution A USD', 1, 2, N'USD', NULL, NULL, CAST(N'2016-05-20T00:00:00.000' AS DateTime), CAST(N'2016-05-20T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'CA', 0, 0, NULL, NULL, NULL, N'LU1410342601', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (127, CAST(N'2017-09-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav I-Bond Plus Solution G USD', N'Pharus Sicav I-Bond Plus Solution G USD', 1, 1, N'USD', NULL, NULL, CAST(N'2017-09-01T00:00:00.000' AS DateTime), CAST(N'2017-09-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, 0, NULL, NULL, NULL, N'LU1662734398', NULL, NULL, NULL, NULL, NULL, N'G', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (128, CAST(N'2010-01-29T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav International Eq Quant A EUR', N'Pharus Sicav International Eq Quant A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2010-01-29T00:00:00.000' AS DateTime), CAST(N'2010-01-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0471904796', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (129, CAST(N'2010-01-29T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav International Eq Quant B EUR', N'Pharus Sicav International Eq Quant B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2010-01-29T00:00:00.000' AS DateTime), CAST(N'2010-01-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU0471904879', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (130, CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav International Equity Quant Q EUR', N'Pharus Sicav International Equity Quant Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1136402192', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (131, CAST(N'2002-12-20T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Liquidity A EUR', N'Pharus Sicav Liquidity A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2002-12-20T00:00:00.000' AS DateTime), CAST(N'2002-12-20T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0159791275', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (132, CAST(N'2013-10-17T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Liquidity B USD', N'Pharus Sicav Liquidity B USD', 4, 1, N'USD', NULL, NULL, CAST(N'2013-10-17T00:00:00.000' AS DateTime), CAST(N'2013-10-17T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 1, 0, NULL, NULL, NULL, N'LU0985039436', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (133, CAST(N'2015-03-09T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Liquidity E CHF', N'Pharus Sicav Liquidity E CHF', 1, 1, N'CHF', NULL, NULL, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2015-03-09T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 1, 0, NULL, NULL, NULL, N'LU1136401202', NULL, NULL, NULL, NULL, NULL, N'E', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (134, CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Liquidity Q EUR', N'Pharus Sicav Liquidity Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1136401384', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (135, CAST(N'2016-04-22T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Marzotto Active Bond A EUR', N'Pharus Sicav Marzotto Active Bond A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-04-22T00:00:00.000' AS DateTime), CAST(N'2016-04-22T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1371477263', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (136, CAST(N'2016-04-15T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Marzotto Active Bond B EUR', N'Pharus Sicav Marzotto Active Bond B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2016-04-15T00:00:00.000' AS DateTime), CAST(N'2016-04-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1371477347', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (137, CAST(N'2016-06-13T00:00:00.000' AS DateTime), CAST(N'2020-04-13T00:00:00.000' AS DateTime), N'Pharus Sicav Marzotto Active Bond Q EUR', N'Pharus Sicav Marzotto Active Bond Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-06-13T00:00:00.000' AS DateTime), CAST(N'2016-06-13T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1371515021', NULL, NULL, NULL, NULL, NULL, N'Q', N'Closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (137, CAST(N'2020-04-14T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Marzotto Active Bond Q EUR', N'Pharus Sicav Marzotto Active Bond Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-06-13T00:00:00.000' AS DateTime), CAST(N'2016-06-13T00:00:00.000' AS DateTime), CAST(N'2020-02-13T00:00:00.000' AS DateTime), NULL, 3, 0, N'C7', 0, 1, NULL, NULL, NULL, N'LU1371515021', NULL, N'9887A', NULL, NULL, NULL, N'Q', N'Closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (138, CAST(N'2016-04-22T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Marzotto Active Diversified A EUR', N'Pharus Sicav Marzotto Active Diversified A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-04-22T00:00:00.000' AS DateTime), CAST(N'2016-04-22T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1371477420', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (139, CAST(N'2016-04-15T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Marzotto Active Diversified B EUR', N'Pharus Sicav Marzotto Active Diversified B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2016-04-15T00:00:00.000' AS DateTime), CAST(N'2016-04-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1371477693', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (140, CAST(N'2016-06-13T00:00:00.000' AS DateTime), CAST(N'2020-02-13T00:00:00.000' AS DateTime), N'Pharus Sicav Marzotto Active Diversified Q EUR', N'Pharus Sicav Marzotto Active Diversified Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-06-13T00:00:00.000' AS DateTime), CAST(N'2016-06-13T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1371515294', NULL, NULL, NULL, NULL, NULL, N'Q', N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (140, CAST(N'2020-02-14T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Marzotto Active Diversified Q EUR', N'Pharus Sicav Marzotto Active Diversified Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-06-13T00:00:00.000' AS DateTime), CAST(N'2016-06-13T00:00:00.000' AS DateTime), CAST(N'2020-02-13T00:00:00.000' AS DateTime), NULL, 3, 0, N'C7', 0, 1, NULL, NULL, NULL, N'LU1371515294', NULL, N'9887Q', NULL, NULL, NULL, N'Q', N'closed', N'CLOSED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (141, CAST(N'2012-02-29T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Dynamic Allocation MV7 B EUR', N'Pharus Sicav Dynamic Allocation MV7 B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2012-02-29T00:00:00.000' AS DateTime), CAST(N'2012-02-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU0746320331', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (142, CAST(N'2012-02-29T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Dynamic Allocation MV7 A EUR', N'Pharus Sicav Dynamic Allocation MV7 A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2012-02-29T00:00:00.000' AS DateTime), CAST(N'2012-02-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0746320257', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (143, CAST(N'2015-12-09T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Southern Europe A EUR', N'Pharus Sicav Southern Europe A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-12-22T00:00:00.000' AS DateTime), CAST(N'2015-12-22T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1278160939', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (144, CAST(N'2015-12-09T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Southern Europe B EUR', N'Pharus Sicav Southern Europe B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2015-12-09T00:00:00.000' AS DateTime), CAST(N'2015-12-09T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1278161150', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (145, CAST(N'2018-01-31T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Southern Europe C EUR', N'Pharus Sicav Southern Europe C EUR', 1, 1, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 3, 100, N'C3', 0, NULL, NULL, NULL, NULL, N'LU1330685899', NULL, NULL, NULL, NULL, NULL, N'C', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (146, CAST(N'2018-06-28T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Southern Europe Q EUR', N'Pharus Sicav Southern Europe Q EUR', 1, 1, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 3, 100, N'C7', 0, NULL, NULL, NULL, NULL, N'LU1578646025', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (147, CAST(N'2019-03-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Swan Dynamic A EUR', N'Pharus Sicav Swan Dynamic A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-10-12T00:00:00.000' AS DateTime), CAST(N'2015-10-12T00:00:00.000' AS DateTime), NULL, NULL, 3, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1253867417', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (148, CAST(N'2019-03-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Swan Dynamic B EUR', N'Pharus Sicav Swan Dynamic B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2016-04-01T00:00:00.000' AS DateTime), CAST(N'2016-04-01T00:00:00.000' AS DateTime), NULL, NULL, 3, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1384920283', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (149, CAST(N'2019-03-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Swan Dynamic C EUR', N'Pharus Sicav Swan Dynamic C EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2018-07-30T00:00:00.000' AS DateTime), CAST(N'2018-07-30T00:00:00.000' AS DateTime), NULL, NULL, 3, 100, N'C3', 0, 0, NULL, NULL, NULL, N'LU1834915396', NULL, NULL, NULL, NULL, NULL, N'C', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (150, CAST(N'2012-02-21T00:00:00.000' AS DateTime), CAST(N'2020-11-30T00:00:00.000' AS DateTime), N'Pharus Sicav Target A EUR', N'Pharus Sicav Target A EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2012-02-21T00:00:00.000' AS DateTime), CAST(N'2012-02-21T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D1', 0, 0, NULL, NULL, NULL, N'LU0746320414', NULL, NULL, NULL, NULL, NULL, N'A', N'class A becomes class AD', N'CLASS A BECOMES CLASS AD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (150, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Target AD EUR', N'Pharus Sicav Target AD EUR', 1, 2, N'EUR', N'LU', NULL, CAST(N'2012-02-21T00:00:00.000' AS DateTime), CAST(N'2012-02-21T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D1', 0, 0, NULL, NULL, NULL, N'LU0746320414', NULL, N'ADEUR', NULL, NULL, NULL, N'AD', N'class A becomes class AD', N'CLASS A BECOMES CLASS AD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (151, CAST(N'2012-02-21T00:00:00.000' AS DateTime), CAST(N'2020-11-30T00:00:00.000' AS DateTime), N'Pharus Sicav Target B EUR', N'Pharus Sicav Target B EUR', 4, 2, N'EUR', NULL, NULL, CAST(N'2012-02-21T00:00:00.000' AS DateTime), CAST(N'2012-02-21T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D2', 0, 0, NULL, NULL, NULL, N'LU0746320505', NULL, NULL, NULL, NULL, NULL, N'B', N'class B becomes class BD', N'CLASS B BECOMES CLASS BD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (151, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Target BD EUR', N'Pharus Sicav Target BD EUR', 4, 2, N'EUR', N'LU', NULL, CAST(N'2012-02-21T00:00:00.000' AS DateTime), CAST(N'2012-02-21T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D2', 0, 0, NULL, NULL, NULL, N'LU0746320505', NULL, N'BDEUR', NULL, NULL, NULL, N'BD', N'class B becomes class BD', N'CLASS B BECOMES CLASS BD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (152, CAST(N'2013-10-17T00:00:00.000' AS DateTime), CAST(N'2020-11-30T00:00:00.000' AS DateTime), N'Pharus Sicav Target C USD', N'Pharus Sicav Target C USD', 4, 2, N'USD', NULL, NULL, CAST(N'2013-10-17T00:00:00.000' AS DateTime), CAST(N'2013-10-17T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'DD', 1, 0, NULL, NULL, NULL, N'LU0985039352', NULL, NULL, NULL, NULL, NULL, N'C', N'class C becomes class BH - USD', N'CLASS C BECOMES CLASS BH - USD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (152, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Target BH USD', N'Pharus Sicav Target BH USD', 4, 2, N'USD', NULL, NULL, CAST(N'2013-10-17T00:00:00.000' AS DateTime), CAST(N'2013-10-17T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'BHUSD', 1, 0, NULL, NULL, NULL, N'LU0985039352', NULL, N'BHUSD', NULL, NULL, NULL, N'BH', N'class C becomes class BH - USD', N'CLASS C BECOMES CLASS BH - USD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (153, CAST(N'2017-03-27T00:00:00.000' AS DateTime), CAST(N'2020-11-30T00:00:00.000' AS DateTime), N'Pharus Sicav Target E CHF', N'Pharus Sicav Target E CHF', 1, 1, N'CHF', NULL, NULL, CAST(N'2017-03-27T00:00:00.000' AS DateTime), CAST(N'2017-03-27T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 1, 0, NULL, NULL, NULL, N'LU1582233844', NULL, NULL, NULL, NULL, NULL, N'E', N'class E becomes class AH - CHF', N'CLASS E BECOMES CLASS AH - CHF')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (153, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Target AH CHF', N'Pharus Sicav Target AH CHF', 1, 1, N'CHF', N'LU', NULL, CAST(N'2017-03-27T00:00:00.000' AS DateTime), CAST(N'2017-03-27T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 1, 0, NULL, NULL, NULL, N'LU1582233844', NULL, N'AHCHF', NULL, NULL, NULL, N'AH', N'class E becomes class AH - CHF', N'CLASS E BECOMES CLASS AH - CHF')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (154, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2020-11-30T00:00:00.000' AS DateTime), N'Pharus Sicav Target F CHF', N'Pharus Sicav Target F CHF', 4, 1, N'CHF', NULL, NULL, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2015-03-09T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D5', 1, 0, NULL, NULL, NULL, N'LU1136402606', NULL, NULL, NULL, NULL, NULL, N'F', N'class F becomes class BH - CHF', N'CLASS F BECOMES CLASS BH - CHF')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (154, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Target BH CHF', N'Pharus Sicav Target BH CHF', 4, 1, N'CHF', NULL, NULL, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2015-03-09T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D5', 1, 0, NULL, NULL, NULL, N'LU1136402606', NULL, N'BHCHF', NULL, NULL, NULL, N'BH CHF', N'class F becomes class BH - CHF', N'CLASS F BECOMES CLASS BH - CHF')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (155, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2020-11-30T00:00:00.000' AS DateTime), N'Pharus Sicav Target H EUR', N'Pharus Sicav Target H EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2015-03-09T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C6', 0, 0, NULL, NULL, NULL, N'LU1136402515', NULL, NULL, NULL, NULL, NULL, N'H', N'class H becomes class B', N'CLASS H BECOMES CLASS B')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (155, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Target B EUR', N'Pharus Sicav Target B EUR', 4, 1, N'EUR', N'LU', NULL, CAST(N'2015-03-09T00:00:00.000' AS DateTime), CAST(N'2015-03-09T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C6', 0, 0, NULL, NULL, NULL, N'LU1136402515', NULL, N'BEUR', NULL, NULL, NULL, N'B', N'class H becomes class B', N'CLASS H BECOMES CLASS B')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (156, CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Target Q EUR', N'Pharus Sicav Target Q EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2015-05-29T00:00:00.000' AS DateTime), CAST(N'2015-05-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D7', 0, 1, NULL, NULL, NULL, N'LU1136402432', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (157, CAST(N'2015-10-12T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Tikehon Global Growth & Income Fund A EUR', N'Pharus Sicav Tikehon Global Growth & Income Fund A EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2015-10-12T00:00:00.000' AS DateTime), CAST(N'2015-10-12T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1253867250', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (158, CAST(N'2015-10-12T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Tikehon Global Growth & Income Fund B EUR', N'Pharus Sicav Tikehon Global Growth & Income Fund B EUR', 4, 2, N'EUR', NULL, NULL, CAST(N'2015-10-12T00:00:00.000' AS DateTime), CAST(N'2015-10-12T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1253867334', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (159, CAST(N'2017-11-03T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Tikehon Global Growth & Income Fund C EUR', N'Pharus Sicav Tikehon Global Growth & Income Fund C EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-11-03T00:00:00.000' AS DateTime), CAST(N'2017-11-03T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 0, 0, NULL, NULL, NULL, N'LU1310644387', NULL, NULL, NULL, NULL, NULL, N'C', N'change of name of Share Class C into Share Class S', N'CHANGE OF NAME OF SHARE CLASS C INTO SHARE CLASS S')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (159, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Tikehon Global Growth & Income Fund S EUR', N'Pharus Sicav Tikehon Global Growth & Income Fund S EUR', 1, 1, N'EUR', N'LU', NULL, CAST(N'2017-11-03T00:00:00.000' AS DateTime), CAST(N'2017-11-03T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 0, 0, NULL, NULL, NULL, N'LU1310644387', NULL, N'SEUR', NULL, NULL, NULL, N'S', N'change of name of Share Class C into Share Class S', N'CHANGE OF NAME OF SHARE CLASS C INTO SHARE CLASS S')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (160, CAST(N'2009-12-22T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Titan Aggressive A EUR', N'Pharus Sicav Titan Aggressive A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2009-12-22T00:00:00.000' AS DateTime), CAST(N'2009-12-22T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0471904440', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (161, CAST(N'2016-07-15T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Trend Player A EUR', N'Pharus Sicav Trend Player A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-07-15T00:00:00.000' AS DateTime), CAST(N'2016-07-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1253867508', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
GO
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (162, CAST(N'2015-11-16T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Trend Player B EUR', N'Pharus Sicav Trend Player B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2015-11-16T00:00:00.000' AS DateTime), CAST(N'2015-11-16T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1253867763', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (163, CAST(N'2016-01-08T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Trend Player Q EUR', N'Pharus Sicav Trend Player Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-01-08T00:00:00.000' AS DateTime), CAST(N'2016-01-08T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1253867847', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (164, CAST(N'2009-11-30T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Flexible Bond A EUR', N'Pharus Sicav Global Flexible Bond A EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2009-11-30T00:00:00.000' AS DateTime), CAST(N'2009-11-30T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0460960882', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (165, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-03-06T00:00:00.000' AS DateTime), N'Pharus Sicav Value A EUR', N'Pharus Sicav Value A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2008-06-10T00:00:00.000' AS DateTime), CAST(N'2008-06-10T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0368595129', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (165, CAST(N'2019-03-07T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Next Revolution A EUR', N'Pharus Sicav Next Revolution A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2008-06-10T00:00:00.000' AS DateTime), CAST(N'2008-06-10T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0368595129', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (166, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-03-06T00:00:00.000' AS DateTime), N'Pharus Sicav Value B EUR', N'Pharus Sicav Value B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2010-03-31T00:00:00.000' AS DateTime), CAST(N'2010-03-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU0515578911', NULL, NULL, NULL, NULL, NULL, N'B', N'Changed name', N'Changed Name')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (166, CAST(N'2019-03-07T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Next Revolution B EUR', N'Pharus Sicav Next Revolution B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2010-03-31T00:00:00.000' AS DateTime), CAST(N'2010-03-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU0515578911', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (167, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-03-06T00:00:00.000' AS DateTime), N'Pharus Sicav Value C USD', N'Pharus Sicav Value C USD', 4, 1, N'USD', NULL, NULL, CAST(N'2013-10-17T00:00:00.000' AS DateTime), CAST(N'2013-10-17T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'CD', 1, 0, NULL, NULL, NULL, N'LU0985039600', NULL, NULL, NULL, NULL, NULL, N'C', N'Changed name', N'Changed Name')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (167, CAST(N'2019-03-07T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Next Revolution C USD', N'Pharus Sicav Next Revolution C USD', 4, 1, N'USD', NULL, NULL, CAST(N'2013-10-17T00:00:00.000' AS DateTime), CAST(N'2013-10-17T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'CD', 1, 0, NULL, NULL, NULL, N'LU0985039600', NULL, NULL, NULL, NULL, NULL, N'C', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (168, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-03-06T00:00:00.000' AS DateTime), N'Pharus Sicav Value Q EUR', N'Pharus Sicav Value Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-05-25T00:00:00.000' AS DateTime), CAST(N'2015-05-25T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1136401970', NULL, NULL, NULL, NULL, NULL, N'Q', N'Changed name', N'Changed Name')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (168, CAST(N'2019-03-07T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Next Revolution Q EUR', N'Pharus Sicav Next Revolution Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2015-05-25T00:00:00.000' AS DateTime), CAST(N'2015-05-25T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C7', 0, 1, NULL, NULL, NULL, N'LU1136401970', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (169, CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Bond Enhanced Fund A CHF', N'Swan SICAV SIF SWAN Bond Enhanced Fund A CHF', 5, 1, N'CHF', NULL, NULL, CAST(N'2014-01-15T00:00:00.000' AS DateTime), CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'CV', 1, NULL, NULL, NULL, NULL, N'LU1019165965', NULL, N'19876', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (170, CAST(N'2013-06-24T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Bond Enhanced Fund A EUR', N'Swan SICAV SIF SWAN Bond Enhanced Fund A EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2013-06-24T00:00:00.000' AS DateTime), CAST(N'2013-06-24T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU0849750368', NULL, N'19876', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (171, CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Bond Enhanced Fund A USD', N'Swan SICAV SIF SWAN Bond Enhanced Fund A USD', 5, 1, N'USD', NULL, NULL, CAST(N'2014-01-15T00:00:00.000' AS DateTime), CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'CB', 1, NULL, NULL, NULL, NULL, N'LU1019165882', NULL, N'19876', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (172, CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Bond Enhanced Fund B CHF', N'Swan SICAV SIF SWAN Bond Enhanced Fund B CHF', 5, 1, N'CHF', NULL, NULL, CAST(N'2014-01-15T00:00:00.000' AS DateTime), CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'CW', 1, NULL, NULL, NULL, NULL, N'LU1019166187', NULL, N'19876', NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (173, CAST(N'2013-06-24T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Bond Enhanced Fund B EUR', N'Swan SICAV SIF SWAN Bond Enhanced Fund B EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2013-06-24T00:00:00.000' AS DateTime), CAST(N'2013-06-24T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, NULL, NULL, NULL, NULL, N'LU0849750525', NULL, N'19876', NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (174, CAST(N'2014-04-30T00:00:00.000' AS DateTime), CAST(N'2018-07-12T00:00:00.000' AS DateTime), N'Swan SICAV SIF SWAN Dynamic Fund A EUR', N'Swan SICAV SIF SWAN Dynamic Fund A EUR', 5, 1, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU1064663518', NULL, NULL, NULL, NULL, NULL, N'A', N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (174, CAST(N'2018-07-13T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Dynamic Fund A EUR', N'Swan SICAV SIF SWAN Dynamic Fund A EUR', 5, 1, N'EUR', NULL, NULL, NULL, NULL, CAST(N'2018-07-13T00:00:00.000' AS DateTime), NULL, 2, 0, N'C1', 0, 0, NULL, NULL, NULL, N'LU1064663518', NULL, N'22187A', NULL, NULL, NULL, N'A', N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (175, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Dynamic Fund A1 EUR', N'Swan SICAV SIF SWAN Dynamic Fund A1 EUR', 5, 1, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, 100, N'C5', 0, NULL, NULL, NULL, NULL, N'LU1405993525', NULL, NULL, NULL, NULL, NULL, N'A1', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (176, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Dynamic Fund A2 EUR', N'Swan SICAV SIF SWAN Dynamic Fund A2 EUR', 5, 1, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, 100, N'C6', 0, NULL, NULL, NULL, NULL, N'LU1405993798', NULL, NULL, NULL, NULL, NULL, N'A2', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (177, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Dynamic Fund A3 EUR', N'Swan SICAV SIF SWAN Dynamic Fund A3 EUR', 5, 1, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, 100, N'C7', 0, NULL, NULL, NULL, NULL, N'LU1405993871', NULL, NULL, NULL, NULL, NULL, N'A3', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (178, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Dynamic Fund A4 EUR', N'Swan SICAV SIF SWAN Dynamic Fund A4 EUR', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1405993954', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (179, CAST(N'2015-10-16T00:00:00.000' AS DateTime), CAST(N'2018-10-11T00:00:00.000' AS DateTime), N'Swan SICAV SIF SWAN Dynamic Fund B CHF', N'Swan SICAV SIF SWAN Dynamic Fund B CHF', 5, 1, N'CHF', NULL, NULL, CAST(N'2015-10-16T00:00:00.000' AS DateTime), CAST(N'2015-10-16T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'CW', 1, NULL, NULL, NULL, NULL, N'LU1084810560', NULL, NULL, NULL, NULL, NULL, N'B', N'Liquidated', N'LUQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (179, CAST(N'2018-10-12T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Dynamic Fund B CHF', N'Swan SICAV SIF SWAN Dynamic Fund B CHF', 5, 1, N'CHF', NULL, NULL, CAST(N'2015-10-16T00:00:00.000' AS DateTime), CAST(N'2015-10-16T00:00:00.000' AS DateTime), CAST(N'2018-10-12T00:00:00.000' AS DateTime), NULL, 2, 0, N'CW', 1, 0, NULL, NULL, NULL, N'LU1084810560', NULL, N'22187B', NULL, NULL, NULL, N'B', N'Liquidated', N'LUQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (180, CAST(N'2014-04-30T00:00:00.000' AS DateTime), CAST(N'2018-10-11T00:00:00.000' AS DateTime), N'Swan SICAV SIF SWAN Dynamic Fund B EUR', N'Swan SICAV SIF SWAN Dynamic Fund B EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2014-04-30T00:00:00.000' AS DateTime), CAST(N'2014-04-30T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, NULL, NULL, NULL, NULL, N'LU1064663609', NULL, NULL, NULL, NULL, NULL, N'B', N'LIQUIDATED', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (180, CAST(N'2018-10-12T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Dynamic Fund B EUR', N'Swan SICAV SIF SWAN Dynamic Fund B EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2014-04-30T00:00:00.000' AS DateTime), CAST(N'2014-04-30T00:00:00.000' AS DateTime), CAST(N'2018-10-12T00:00:00.000' AS DateTime), NULL, 2, 0, N'C2', 0, 0, NULL, NULL, NULL, N'LU1064663609', NULL, N'22187BEUR', NULL, NULL, NULL, N'B', N'LIQUIDATED', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (181, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Dynamic Fund C EUR', N'Swan SICAV SIF SWAN Dynamic Fund C EUR', 5, 1, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, 100, N'C3', 0, NULL, NULL, NULL, NULL, N'LU1064663781', NULL, NULL, NULL, NULL, NULL, N'C', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (182, CAST(N'2015-04-07T00:00:00.000' AS DateTime), CAST(N'2019-12-12T00:00:00.000' AS DateTime), N'Swan SICAV SIF SWAN Dynamic Fund D EUR', N'Swan SICAV SIF SWAN Dynamic Fund D EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2015-04-07T00:00:00.000' AS DateTime), CAST(N'2015-04-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, NULL, NULL, NULL, NULL, N'LU1209099164', NULL, NULL, NULL, NULL, NULL, N'D', N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (182, CAST(N'2019-12-13T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Dynamic Fund D EUR', N'Swan SICAV SIF SWAN Dynamic Fund D EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2015-04-07T00:00:00.000' AS DateTime), CAST(N'2015-04-07T00:00:00.000' AS DateTime), CAST(N'2019-12-13T00:00:00.000' AS DateTime), NULL, 2, 0, N'C4', 0, 0, NULL, NULL, NULL, N'LU1209099164', NULL, N'22187BEUR', NULL, NULL, NULL, N'D', N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (183, CAST(N'2018-01-26T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Dynamic Fund D CHF', N'Swan SICAV SIF SWAN Dynamic Fund D CHF', NULL, NULL, N'CHF', NULL, NULL, NULL, NULL, CAST(N'2018-01-26T00:00:00.000' AS DateTime), NULL, 2, 0, NULL, 0, 0, NULL, NULL, NULL, N'LU1209099321', NULL, N'LU1209099321', NULL, NULL, NULL, N'D', N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (183, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2018-01-25T00:00:00.000' AS DateTime), N'Swan SICAV SIF SWAN Dynamic Fund D CHF', N'Swan SICAV SIF SWAN Dynamic Fund D CHF', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1209099321', NULL, NULL, NULL, NULL, NULL, N'D', N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (184, CAST(N'2013-02-04T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Long Short Credit Fund A EUR', N'Swan SICAV SIF SWAN Long Short Credit Fund A EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2013-02-04T00:00:00.000' AS DateTime), CAST(N'2013-02-04T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0849750954', NULL, N'19878', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (185, CAST(N'2013-02-04T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Long Short Credit Fund B EUR', N'Swan SICAV SIF SWAN Long Short Credit Fund B EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2013-02-04T00:00:00.000' AS DateTime), CAST(N'2013-02-04T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, NULL, NULL, NULL, NULL, N'LU0849751093', NULL, N'19878', NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (186, CAST(N'2013-02-04T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Multistrategy Fund A EUR', N'Swan SICAV SIF SWAN Multistrategy Fund A EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2013-02-04T00:00:00.000' AS DateTime), CAST(N'2013-02-04T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU0849751176', NULL, N'19879', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (187, CAST(N'2013-02-04T00:00:00.000' AS DateTime), CAST(N'2020-11-26T00:00:00.000' AS DateTime), N'Swan SICAV SIF SWAN Multistrategy Fund B EUR', N'Swan SICAV SIF SWAN Multistrategy Fund B EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2013-02-04T00:00:00.000' AS DateTime), CAST(N'2013-02-04T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, NULL, NULL, NULL, NULL, N'LU0849751259', NULL, N'19879', NULL, NULL, NULL, N'B', N'Dormant - total redemption', N'DORMANT')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (187, CAST(N'2020-11-27T00:00:00.000' AS DateTime), NULL, N'Swan SICAV SIF SWAN Multistrategy Fund B EUR', N'Swan SICAV SIF SWAN Multistrategy Fund B EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2013-02-04T00:00:00.000' AS DateTime), CAST(N'2013-02-04T00:00:00.000' AS DateTime), CAST(N'2020-11-26T00:00:00.000' AS DateTime), NULL, 2, 0, N'C2', 0, 0, NULL, NULL, NULL, N'LU0849751259', NULL, N'19879', NULL, NULL, NULL, N'B', N'Dormant - total redemption', N'DORMANT')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (188, CAST(N'2003-06-20T00:00:00.000' AS DateTime), CAST(N'2019-08-30T00:00:00.000' AS DateTime), N'Sifter Fund Global I EUR', N'Sifter Fund Global I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2003-06-20T00:00:00.000' AS DateTime), CAST(N'2003-06-20T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU0168577939', NULL, NULL, NULL, NULL, NULL, N'I', N'Changed ManCo to ADEPA', N'CHANGE MANCO')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (188, CAST(N'2019-08-31T00:00:00.000' AS DateTime), NULL, N'Sifter Fund Global I EUR', N'Sifter Fund Global I EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2003-06-20T00:00:00.000' AS DateTime), CAST(N'2003-06-20T00:00:00.000' AS DateTime), NULL, NULL, 2, 0, N'C2', 0, 0, NULL, NULL, NULL, N'LU0168577939', NULL, N'38001I', NULL, NULL, NULL, N'I', N'Changed ManCo to ADEPA', N'CHANGE MANCO')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (189, CAST(N'2003-06-20T00:00:00.000' AS DateTime), CAST(N'2019-08-30T00:00:00.000' AS DateTime), N'Sifter Fund Global R EUR', N'Sifter Fund Global R EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2003-06-20T00:00:00.000' AS DateTime), CAST(N'2003-06-20T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU0168736675', NULL, NULL, NULL, NULL, NULL, N'R', N'Changed ManCo to ADEPA', N'CHANGE MANCO')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (189, CAST(N'2019-08-31T00:00:00.000' AS DateTime), NULL, N'Sifter Fund Global R EUR', N'Sifter Fund Global R EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2003-06-20T00:00:00.000' AS DateTime), CAST(N'2003-06-20T00:00:00.000' AS DateTime), NULL, NULL, 2, 0, N'C1', 0, 0, NULL, NULL, NULL, N'LU0168736675', NULL, N'38001R', NULL, NULL, NULL, N'R', N'Changed ManCo to ADEPA', N'CHANGE MANCO')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (190, CAST(N'2015-03-27T00:00:00.000' AS DateTime), CAST(N'2019-08-30T00:00:00.000' AS DateTime), N'Sifter Fund Global PI EUR', N'Sifter Fund Global PI EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2015-03-31T00:00:00.000' AS DateTime), CAST(N'2015-03-31T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 0, 0, NULL, NULL, NULL, N'LU1194076995', NULL, NULL, NULL, NULL, NULL, N'PI', N'Changed ManCo to ADEPA', N'CHANGE MANCO')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (190, CAST(N'2019-08-31T00:00:00.000' AS DateTime), NULL, N'Sifter Fund Global PI EUR', N'Sifter Fund Global PI EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2015-03-31T00:00:00.000' AS DateTime), CAST(N'2015-03-31T00:00:00.000' AS DateTime), NULL, NULL, 2, 0, N'C4', 0, 0, NULL, NULL, NULL, N'LU1194076995', NULL, N'38001PI', NULL, NULL, NULL, N'PI', N'Changed ManCo to ADEPA', N'CHANGE MANCO')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (191, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-13T00:00:00.000' AS DateTime), N'Multi Stars SICAV Hearth Ethical Fund AD EUR', N'Multi Stars SICAV Hearth Ethical Fund AD EUR', 1, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1720014320', NULL, N'LU6658', NULL, NULL, NULL, N'AD', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (192, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-11-14T00:00:00.000' AS DateTime), N'Multi Stars SICAV - AL-FA Dynamic Q EUR', N'Multi Stars SICAV - AL-FA Dynamic Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2018-10-02T00:00:00.000' AS DateTime), CAST(N'2018-10-02T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 1, NULL, NULL, NULL, N'LU1838949516', NULL, N'LU6266', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (192, CAST(N'2019-11-15T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV AL-FA Sustainable Megatrends Q EUR', N'Multi Stars SICAV AL-FA Sustainable Megatrends Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2018-10-02T00:00:00.000' AS DateTime), CAST(N'2018-10-02T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 1, NULL, NULL, NULL, N'LU1838949516', NULL, N'LU6266', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (193, CAST(N'2018-06-04T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Hearth Ethical Fund Q EUR', N'Multi Stars SICAV Hearth Ethical Fund Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2018-10-02T00:00:00.000' AS DateTime), CAST(N'2018-10-02T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 0, 1, NULL, NULL, NULL, N'LU1838949607', NULL, N'LU6658', NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (194, CAST(N'2018-07-31T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Sureco US Core Equity CH CHF', N'Multi Stars SICAV Sureco US Core Equity CH CHF', 1, 1, N'CHF', NULL, NULL, CAST(N'2018-08-20T00:00:00.000' AS DateTime), CAST(N'2018-08-20T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 1, 0, NULL, NULL, NULL, N'LU1854151476', NULL, N'LU6304', NULL, NULL, NULL, N'CH', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (195, CAST(N'2018-06-04T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Sureco US Core Equity C EUR', N'Multi Stars SICAV Sureco US Core Equity C EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2018-07-16T00:00:00.000' AS DateTime), CAST(N'2018-07-16T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 0, 0, NULL, NULL, NULL, N'LU1838949433', NULL, N'LU6304', NULL, NULL, NULL, N'C', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (196, CAST(N'2015-01-30T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Regent Serenity Fund B1 GBP', N'Multi Stars SICAV Regent Serenity Fund B1 GBP', 1, 1, N'GBP', NULL, NULL, CAST(N'2018-03-15T00:00:00.000' AS DateTime), CAST(N'2018-03-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C5', 0, 0, NULL, NULL, NULL, N'LU1760804770', NULL, N'LU6406', NULL, NULL, NULL, N'B1', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (197, CAST(N'2018-03-01T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Hearth Ethical Fund A EUR', N'Multi Stars SICAV Hearth Ethical Fund A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2018-03-02T00:00:00.000' AS DateTime), CAST(N'2018-03-02T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1720014247', NULL, N'LU6658', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (198, CAST(N'2017-09-29T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Cube A EUR', N'Multi Stars SICAV Cube A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1671605654', NULL, N'LU6624', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (199, CAST(N'2017-09-29T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Cube Z EUR', N'Multi Stars SICAV Cube Z EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 1, NULL, NULL, NULL, N'LU1671606116', NULL, N'LU6624', NULL, NULL, NULL, N'Z', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (200, CAST(N'2017-09-29T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Cube S EUR', N'Multi Stars SICAV Cube S EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2017-12-01T00:00:00.000' AS DateTime), CAST(N'2017-12-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 0, 0, NULL, NULL, NULL, N'LU1671606389', NULL, N'LU6624', NULL, NULL, NULL, N'S', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (201, CAST(N'2015-12-31T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Regent Serenity Fund DH EUR', N'Multi Stars SICAV Regent Serenity Fund DH EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2016-01-28T00:00:00.000' AS DateTime), CAST(N'2016-01-28T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 1, 0, NULL, NULL, NULL, N'LU1333049911', NULL, N'LU6406', NULL, NULL, NULL, N'DH', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (202, CAST(N'2015-12-31T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Regent Serenity Fund CH EUR', N'Multi Stars SICAV Regent Serenity Fund CH EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2016-01-28T00:00:00.000' AS DateTime), CAST(N'2016-01-28T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C4', 1, 0, NULL, NULL, NULL, N'LU1333050091', NULL, N'LU6406', NULL, NULL, NULL, N'CH', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (203, CAST(N'2015-01-30T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Regent Serenity Fund A GBP', N'Multi Stars SICAV Regent Serenity Fund A GBP', 1, 1, N'GBP', NULL, NULL, CAST(N'2015-02-05T00:00:00.000' AS DateTime), CAST(N'2015-02-05T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C2', 0, 0, NULL, NULL, NULL, N'LU1172430958', NULL, N'LU6406', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (204, CAST(N'2014-10-30T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Regent Serenity Fund B GBP', N'Multi Stars SICAV Regent Serenity Fund B GBP', 4, 1, N'GBP', NULL, NULL, CAST(N'2014-10-30T00:00:00.000' AS DateTime), CAST(N'2014-10-30T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1118191490', NULL, N'LU6406', NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (205, CAST(N'2014-10-21T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Alexander A EUR', N'Multi Stars SICAV Alexander A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2014-10-21T00:00:00.000' AS DateTime), CAST(N'2014-10-21T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU1110447759', NULL, N'LU6389', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (206, CAST(N'2014-08-25T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Emerging Market Local Currency FHD USD', N'Multi Stars SICAV Emerging Market Local Currency FHD USD', 4, 2, N'USD', NULL, NULL, CAST(N'2014-08-25T00:00:00.000' AS DateTime), CAST(N'2014-08-25T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D3', 1, 0, NULL, NULL, NULL, N'LU1095738685', NULL, N'LU6276', NULL, NULL, NULL, N'FHD', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (207, CAST(N'2013-09-02T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Sureco US Core Equity A USD', N'Multi Stars SICAV Sureco US Core Equity A USD', 1, 1, N'USD', NULL, NULL, CAST(N'2013-09-02T00:00:00.000' AS DateTime), CAST(N'2013-09-02T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU0961060687', NULL, N'LU6304', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (208, CAST(N'2013-08-06T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Emerging Market Local Currency AD EUR', N'Multi Stars SICAV Emerging Market Local Currency AD EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2013-08-06T00:00:00.000' AS DateTime), CAST(N'2013-08-06T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D1', 0, 0, NULL, NULL, NULL, N'LU0950572924', NULL, N'LU6276', NULL, NULL, NULL, N'AD', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (209, CAST(N'2013-08-06T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Emerging Market Local Currency BD EUR', N'Multi Stars SICAV Emerging Market Local Currency BD EUR', 4, 2, N'EUR', NULL, NULL, CAST(N'2013-08-06T00:00:00.000' AS DateTime), CAST(N'2013-08-06T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'D2', 0, 0, NULL, NULL, NULL, N'LU0950573062', NULL, N'LU6276', NULL, NULL, NULL, N'BD', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (210, CAST(N'2013-08-05T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Cefisa Relative Strength EU Equity A EUR', N'Multi Stars SICAV Cefisa Relative Strength EU Equity A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2013-08-05T00:00:00.000' AS DateTime), CAST(N'2013-08-05T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU0950572684', NULL, N'LU6274', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (211, CAST(N'2013-08-01T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV Cefisa Relative Strength Global Asset Allocation A EUR', N'Multi Stars SICAV Cefisa Relative Strength Global Asset Allocation A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2013-08-01T00:00:00.000' AS DateTime), CAST(N'2013-08-01T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, NULL, NULL, NULL, NULL, N'LU0950572767', NULL, N'LU6275', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (212, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-11-14T00:00:00.000' AS DateTime), N'Multi Stars SICAV - AL-FA Dynamic A EUR', N'Multi Stars SICAV - AL-FA Dynamic A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2012-08-20T00:00:00.000' AS DateTime), CAST(N'2012-08-20T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0809734113', NULL, N'LU6266', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (212, CAST(N'2019-11-15T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV AL-FA Sustainable Megatrends A EUR', N'Multi Stars SICAV AL-FA Sustainable Megatrends A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2012-08-20T00:00:00.000' AS DateTime), CAST(N'2012-08-20T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU0809734113', NULL, N'LU6266', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (213, CAST(N'2018-03-12T00:00:00.000' AS DateTime), NULL, N'United SICAV-RAIF Market Neutral Actions Euro P EUR', N'United SICAV-RAIF Market Neutral Actions Euro P EUR', 5, 1, N'EUR', NULL, NULL, CAST(N'2018-04-27T00:00:00.000' AS DateTime), CAST(N'2018-04-27T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C3', 0, 0, NULL, NULL, NULL, N'LU1805040109', NULL, N'1826', NULL, NULL, NULL, N'P', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (214, CAST(N'2017-07-19T00:00:00.000' AS DateTime), CAST(N'2019-12-17T00:00:00.000' AS DateTime), N'Ritom Sicav Raif - Peak Fund A', N'Ritom Sicav Raif - Peak Fund A', 5, 1, N'EUR', NULL, NULL, CAST(N'2017-08-07T00:00:00.000' AS DateTime), CAST(N'2017-08-07T00:00:00.000' AS DateTime), NULL, NULL, 2, 100, N'CA', 0, 0, NULL, NULL, NULL, N'LU1654544995', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (215, CAST(N'2017-07-19T00:00:00.000' AS DateTime), CAST(N'2018-07-03T00:00:00.000' AS DateTime), N'Ritom Sicav Raif - Peak Fund B', N'Ritom Sicav Raif - Peak Fund B', 5, 1, N'EUR', NULL, NULL, CAST(N'2017-12-11T00:00:00.000' AS DateTime), CAST(N'2017-12-11T00:00:00.000' AS DateTime), NULL, NULL, 3, 100, N'CB', 0, 0, NULL, NULL, NULL, N'LU1654545026', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (216, CAST(N'2017-02-28T00:00:00.000' AS DateTime), NULL, N'Bright Stars Sicav Vitalix A', N'Bright Stars Sicav Vitalix A', 5, 1, N'USD', NULL, NULL, CAST(N'2017-06-30T00:00:00.000' AS DateTime), CAST(N'2017-06-30T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, N'C1', 0, 0, NULL, NULL, NULL, N'LU1485530684', NULL, N'LU6542', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (217, CAST(N'2018-03-12T00:00:00.000' AS DateTime), NULL, N'United SICAV-RAIF Market Neutral Actions Euro A EUR', N'United SICAV-RAIF Market Neutral Actions Euro A EUR', 5, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1805039945', NULL, N'1826', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (218, CAST(N'2018-03-12T00:00:00.000' AS DateTime), NULL, N'United SICAV-RAIF Market Neutral Actions Euro B EUR', N'United SICAV-RAIF Market Neutral Actions Euro B EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1805040018', NULL, N'1826', NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (219, CAST(N'2018-03-12T00:00:00.000' AS DateTime), NULL, N'United SICAV-RAIF Market Neutral Actions Euro S EUR', N'United SICAV-RAIF Market Neutral Actions Euro S EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1805040281', NULL, N'1826', NULL, NULL, NULL, N'S', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (220, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, N'1st SICAV Athena Balanced I', N'1st SICAV Athena Balanced I', 4, 1, N'EUR', NULL, NULL, CAST(N'2017-01-03T00:00:00.000' AS DateTime), CAST(N'2018-04-10T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1435778482', NULL, N'30658', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (221, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, N'1st SICAV Hestia Conservative I', N'1st SICAV Hestia Conservative I', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1435778649', NULL, N'30659', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (222, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, N'1st SICAV Italy S', N'1st SICAV Italy S', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1435777757', NULL, N'30656', NULL, NULL, NULL, N'S', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (223, CAST(N'2015-03-25T00:00:00.000' AS DateTime), NULL, N'GFG Funds Euro Global Bond I CHF', N'GFG Funds Euro Global Bond I CHF', NULL, NULL, N'CHF', NULL, NULL, CAST(N'2015-03-25T00:00:00.000' AS DateTime), CAST(N'2015-03-25T00:00:00.000' AS DateTime), NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1196450693', NULL, N'51115', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (224, CAST(N'2015-03-23T00:00:00.000' AS DateTime), NULL, N'GFG Funds Euro Global Bond PP CHF', N'GFG Funds Euro Global Bond PP CHF', NULL, NULL, N'CHF', NULL, NULL, CAST(N'2015-03-23T00:00:00.000' AS DateTime), CAST(N'2015-03-23T00:00:00.000' AS DateTime), NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1196450420', NULL, N'51115', NULL, NULL, NULL, N'PP', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (225, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL, N'GFG Funds Global Corporate Bond I EUR', N'GFG Funds Global Corporate Bond I EUR', 4, NULL, N'EUR', NULL, NULL, CAST(N'2019-04-17T00:00:00.000' AS DateTime), CAST(N'2019-11-29T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1981743195', NULL, N'38123', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (226, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL, N'GFG Funds Global Corporate Bond P EUR', N'GFG Funds Global Corporate Bond P EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1981743278', NULL, N'38123', NULL, NULL, NULL, N'P', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (227, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL, N'GFG Funds Global Corporate Bond PP EUR', N'GFG Funds Global Corporate Bond PP EUR', 1, NULL, N'EUR', NULL, NULL, CAST(N'2019-04-17T00:00:00.000' AS DateTime), CAST(N'2019-11-29T00:00:00.000' AS DateTime), NULL, NULL, 1, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1981743351', NULL, N'38123', NULL, NULL, NULL, N'PP', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (228, CAST(N'2017-03-23T00:00:00.000' AS DateTime), NULL, N'Kite Fund SICAV FLexible Credit A CHF', N'Kite Fund SICAV FLexible Credit A CHF', NULL, NULL, N'CHF', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1550130956', NULL, N'26886', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (229, CAST(N'2017-03-23T00:00:00.000' AS DateTime), NULL, N'Kite Fund SICAV FLexible Credit A USD', N'Kite Fund SICAV FLexible Credit A USD', NULL, NULL, N'USD', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1550131509', NULL, N'26886', NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (230, CAST(N'2017-03-23T00:00:00.000' AS DateTime), NULL, N'Kite Fund SICAV FLexible Credit I', N'Kite Fund SICAV FLexible Credit I', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1550131251', NULL, N'26886', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (231, CAST(N'2016-07-11T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Avantgarde E USD', N'Pharus Sicav Avantgarde E USD', NULL, NULL, N'USD', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1882537845', NULL, NULL, NULL, NULL, NULL, N'E', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (232, CAST(N'2009-11-30T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Global Flexible Bond D CHF', N'Pharus Sicav Global Flexible Bond D CHF', 4, 1, N'CHF', NULL, NULL, CAST(N'2019-12-20T00:00:00.000' AS DateTime), CAST(N'2019-12-20T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU2081626249', NULL, NULL, NULL, NULL, NULL, N'D', N'change the name of Class D into BH-CHF', N'CHANGE THE NAME OF CLASS D INTO BH-CHF')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (232, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Flexible Bond BH CHF', N'Pharus Sicav Global Flexible Bond BH CHF', 4, 1, N'CHF', NULL, NULL, CAST(N'2019-12-20T00:00:00.000' AS DateTime), CAST(N'2019-12-20T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 1, 0, NULL, NULL, NULL, N'LU2081626249', NULL, N'BHCHF', NULL, NULL, NULL, N'BH', N'change the name of Class D into BH-CHF', N'CHANGE THE NAME OF CLASS D INTO BH-CHF')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (233, CAST(N'2009-11-30T00:00:00.000' AS DateTime), CAST(N'2020-10-21T00:00:00.000' AS DateTime), N'Pharus Sicav Global Flexible Bond Z EUR', N'Pharus Sicav Global Flexible Bond Z EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 1, NULL, NULL, NULL, N'LU2012056466', NULL, NULL, NULL, NULL, NULL, N'Z', N'ACTIVATED ON 22/10/2020', N'ACTIVATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (233, CAST(N'2020-10-22T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Flexible Bond Z EUR', N'Pharus Sicav Global Flexible Bond Z EUR', 6, 1, N'EUR', N'LU', NULL, CAST(N'2009-11-30T00:00:00.000' AS DateTime), CAST(N'2020-10-22T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 1, NULL, NULL, NULL, N'LU2012056466', NULL, N'Z', NULL, NULL, NULL, N'Z', N'ACTIVATED ON 22/10/2020', N'ACTIVATED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (234, CAST(N'2009-11-30T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Global Flexible Bond B EUR', N'Pharus Sicav Global Flexible Bond B EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU2081626165', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (235, CAST(N'2018-08-22T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Electric Mobility Niches A EUR', N'Pharus Sicav Electric Mobility Niches A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2019-10-23T00:00:00.000' AS DateTime), CAST(N'2019-10-23T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1867072149', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (236, CAST(N'2018-08-22T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Electric Mobility Niches B EUR', N'Pharus Sicav Electric Mobility Niches B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2019-06-07T00:00:00.000' AS DateTime), CAST(N'2019-06-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1867072222', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (237, CAST(N'2018-08-22T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Electric Mobility Niches Q EUR', N'Pharus Sicav Electric Mobility Niches Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2019-06-07T00:00:00.000' AS DateTime), CAST(N'2019-06-07T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 1, NULL, NULL, NULL, N'LU1867072495', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (238, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Asian Niches B EUR', N'Pharus Sicav Asian Niches B EUR', 4, 1, N'EUR', NULL, NULL, CAST(N'2019-02-15T00:00:00.000' AS DateTime), CAST(N'2019-02-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1867072651', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (239, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Asian Niches A EUR', N'Pharus Sicav Asian Niches A EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2019-02-15T00:00:00.000' AS DateTime), CAST(N'2019-02-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1867072578', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (240, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Asian Niches Q EUR', N'Pharus Sicav Asian Niches Q EUR', 1, 1, N'EUR', NULL, NULL, CAST(N'2019-02-15T00:00:00.000' AS DateTime), CAST(N'2019-02-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 1, NULL, NULL, NULL, N'LU1867072735', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (241, CAST(N'2019-06-18T00:00:00.000' AS DateTime), CAST(N'2019-12-15T00:00:00.000' AS DateTime), N'Pharus SICAV - Target Equity Dividend A EUR', N'Pharus SICAV - Target Equity Dividend A EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872042', NULL, NULL, NULL, NULL, NULL, N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (241, CAST(N'2019-12-16T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Best Regulated Companies A EUR', N'Pharus Sicav Best Regulated Companies A EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872042', NULL, NULL, NULL, NULL, NULL, N'A', N'CHANGED FROM A TO AD', N'CHANGED FROM A TO AD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (241, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Regulated Companies AD EUR', N'Pharus Sicav Best Regulated Companies AD EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872042', NULL, N'AD', NULL, NULL, NULL, N'AD', N'CHANGED FROM A TO AD', N'CHANGED FROM A TO AD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (242, CAST(N'2019-06-18T00:00:00.000' AS DateTime), CAST(N'2019-12-15T00:00:00.000' AS DateTime), N'Pharus SICAV - Target Equity Dividend B EUR', N'Pharus SICAV - Target Equity Dividend B EUR', 4, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872125', NULL, NULL, NULL, NULL, NULL, N'B', NULL, NULL)
GO
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (242, CAST(N'2019-12-16T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Best Regulated Companies B EUR', N'Pharus Sicav Best Regulated Companies B EUR', 4, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872125', NULL, NULL, NULL, NULL, NULL, N'B', N'CHANGED FROM B TO BD', N'CHANGED FROM B TO BD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (242, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Regulated Companies BD EUR', N'Pharus Sicav Best Regulated Companies BD EUR', 4, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872125', NULL, N'BD', NULL, NULL, NULL, N'BD', N'CHANGED FROM B TO BD', N'CHANGED FROM B TO BD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (243, CAST(N'2019-01-02T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Best Regulated Companies C EUR', N'Pharus Sicav Best Regulated Companies C EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872398', NULL, NULL, NULL, NULL, NULL, N'C', N'CHANGED FROM C EUR TO BHD USD', N'CHANGED FROM C EUR TO BHD USD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (243, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Regulated Companies BHD USD', N'Pharus Sicav Best Regulated Companies BHD USD', NULL, NULL, N'USD', NULL, NULL, NULL, NULL, NULL, NULL, 4, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872398', NULL, N'BHDUSD', NULL, NULL, NULL, N'BHD', N'CHANGED FROM C EUR TO BHD USD', N'CHANGED FROM C EUR TO BHD USD')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (244, CAST(N'2019-06-18T00:00:00.000' AS DateTime), CAST(N'2019-12-15T00:00:00.000' AS DateTime), N'Pharus SICAV - Target Equity Dividend E CHF', N'Pharus SICAV - Target Equity Dividend E CHF', 1, 2, N'CHF', NULL, NULL, CAST(N'2019-10-16T00:00:00.000' AS DateTime), CAST(N'2019-10-16T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 1, 0, NULL, NULL, NULL, N'LU1868872471', NULL, NULL, NULL, NULL, NULL, N'E', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (244, CAST(N'2019-12-16T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Best Regulated Companies E CHF', N'Pharus Sicav Best Regulated Companies E CHF', 1, 2, N'CHF', NULL, NULL, CAST(N'2019-10-16T00:00:00.000' AS DateTime), CAST(N'2019-10-16T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 1, 0, NULL, NULL, NULL, N'LU1868872471', NULL, NULL, NULL, NULL, NULL, N'E', N'class E becomes class AHD - CHF', N'CLASS E BECOMES CLASS AHD - CHF')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (244, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Regulated Companies AHD CHF', N'Pharus Sicav Best Regulated Companies AHD CHF', 1, 2, N'CHF', NULL, NULL, CAST(N'2019-10-16T00:00:00.000' AS DateTime), CAST(N'2019-10-16T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 1, 0, NULL, NULL, NULL, N'LU1868872471', NULL, N'AHDCHF', NULL, NULL, NULL, N'AHD', N'class E becomes class AHD - CHF', N'CLASS E BECOMES CLASS AHD - CHF')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (245, CAST(N'2019-01-02T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Best Regulated Companies F EUR', N'Pharus Sicav Best Regulated Companies F EUR', NULL, NULL, N'EUR', NULL, NULL, NULL, NULL, NULL, NULL, 4, NULL, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872554', NULL, NULL, NULL, NULL, NULL, N'F', N'Class F becomes class BHD - CHF', N'CLASS F BECOMES CLASS BHD - CHF')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (245, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Regulated Companies BHD CHF', N'Pharus Sicav Best Regulated Companies BHD CHF', NULL, NULL, N'CHF', NULL, NULL, NULL, NULL, NULL, NULL, 4, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872554', NULL, N'BHDCHF', NULL, NULL, NULL, N'BHD', N'Class F becomes class BHD - CHF', N'CLASS F BECOMES CLASS BHD - CHF')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (246, CAST(N'2019-06-18T00:00:00.000' AS DateTime), CAST(N'2019-12-15T00:00:00.000' AS DateTime), N'Pharus SICAV - Target Equity Dividend G EUR', N'Pharus SICAV - Target Equity Dividend G EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872638', NULL, NULL, NULL, NULL, NULL, N'G', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (246, CAST(N'2019-12-16T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Best Regulated Companies G EUR', N'Pharus Sicav Best Regulated Companies G EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872638', NULL, NULL, NULL, NULL, NULL, N'G', N'CLASS G BECOMES CLASS A', N'CLASS G BECOMES CLASS A')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (246, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Regulated Companies A EUR', N'Pharus Sicav Best Regulated Companies A EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872638', NULL, N'AEUR', NULL, NULL, NULL, N'A', N'CLASS G BECOMES CLASS A', N'CLASS G BECOMES CLASS A')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (247, CAST(N'2019-06-18T00:00:00.000' AS DateTime), CAST(N'2019-12-15T00:00:00.000' AS DateTime), N'Pharus SICAV - Target Equity Dividend H EUR', N'Pharus SICAV - Target Equity Dividend H EUR', 4, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872711', NULL, NULL, NULL, NULL, NULL, N'H', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (247, CAST(N'2019-12-16T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus Sicav Best Regulated Companies H EUR', N'Pharus Sicav Best Regulated Companies H EUR', 4, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872711', NULL, NULL, NULL, NULL, NULL, N'H', N'CLASS H BECOMES CLASS B', N'CLASS H BECOMES CLASS B')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (247, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Regulated Companies B EUR', N'Pharus Sicav Best Regulated Companies B EUR', 4, 2, N'EUR', NULL, NULL, CAST(N'2019-03-29T00:00:00.000' AS DateTime), CAST(N'2019-03-29T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU1868872711', NULL, N'BEUR', NULL, NULL, NULL, N'B', N'CLASS H BECOMES CLASS B', N'CLASS H BECOMES CLASS B')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (248, CAST(N'2019-06-18T00:00:00.000' AS DateTime), CAST(N'2019-12-15T00:00:00.000' AS DateTime), N'Pharus SICAV - Target Equity Dividend Q EUR', N'Pharus SICAV - Target Equity Dividend Q EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2019-07-08T00:00:00.000' AS DateTime), CAST(N'2019-07-08T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 1, NULL, NULL, NULL, N'LU1868872802', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (248, CAST(N'2019-12-16T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Regulated Companies Q EUR', N'Pharus Sicav Best Regulated Companies Q EUR', 1, 2, N'EUR', NULL, NULL, CAST(N'2019-07-08T00:00:00.000' AS DateTime), CAST(N'2019-07-08T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 0, 1, NULL, NULL, NULL, N'LU1868872802', NULL, NULL, NULL, NULL, NULL, N'Q', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (249, CAST(N'2019-12-18T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Fasanara Quant BH', N'Pharus Sicav Fasanara Quant BH', 4, NULL, N'USD', N'LU', NULL, CAST(N'2020-06-12T00:00:00.000' AS DateTime), CAST(N'2020-06-12T00:00:00.000' AS DateTime), NULL, NULL, 1, 100, NULL, 1, 0, NULL, NULL, NULL, N'LU2040055670', NULL, N'402', NULL, NULL, NULL, N'BH', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (250, CAST(N'2019-12-18T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Fasanara Quant B', N'Pharus Sicav Fasanara Quant B', 4, NULL, N'EUR', N'LU', NULL, NULL, CAST(N'2020-06-12T00:00:00.000' AS DateTime), NULL, NULL, 1, 0, NULL, 0, 0, NULL, NULL, NULL, N'LU2040055241', NULL, N'402B', NULL, NULL, NULL, N'B', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (251, CAST(N'2019-12-18T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Fasanara Quant B1', N'Pharus Sicav Fasanara Quant B1', 4, NULL, N'EUR', N'LU', NULL, CAST(N'2020-06-12T00:00:00.000' AS DateTime), CAST(N'2020-06-12T00:00:00.000' AS DateTime), NULL, NULL, 1, 0, NULL, 0, 0, NULL, NULL, NULL, N'LU2040055324', NULL, N'402B1', NULL, NULL, NULL, N'B1', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (252, CAST(N'2019-12-18T00:00:00.000' AS DateTime), CAST(N'2020-07-14T00:00:00.000' AS DateTime), N'Pharus Sicav Fasanara Quant A', N'Pharus Sicav Fasanara Quant A', 1, NULL, N'EUR', N'LU', N'LU', NULL, NULL, NULL, NULL, 4, 100, NULL, 0, 0, NULL, NULL, NULL, N'LU2040055167', NULL, N'402A', NULL, NULL, NULL, N'A', N'launched', N'LAUNCHED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (252, CAST(N'2020-07-15T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Fasanara Quant A', N'Pharus Sicav Fasanara Quant A', 1, NULL, N'EUR', NULL, NULL, CAST(N'2020-07-15T00:00:00.000' AS DateTime), CAST(N'2020-07-15T00:00:00.000' AS DateTime), NULL, NULL, 1, 0, NULL, 0, 0, NULL, NULL, NULL, N'LU2040055167', NULL, N'402A', NULL, NULL, NULL, N'A', N'launched', N'LAUNCHED')
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (253, CAST(N'2020-08-31T00:00:00.000' AS DateTime), NULL, N'MH Fund SICAV SIF Vitalis Equity-Lux Fd A USD', N'MH Fund SICAV SIF Vitalis Equity-Lux Fd A USD', 5, NULL, N'USD', N'LU', N'LU', NULL, NULL, NULL, NULL, 1, 100, N'D1', 0, 0, N'LX', N'VITEQYA LX', NULL, N'LU1554402526', NULL, N'LU6793A', N'LU6793A', NULL, CAST(N'2020-12-31T00:00:00.000' AS DateTime), N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (254, CAST(N'2020-08-31T00:00:00.000' AS DateTime), NULL, N'MH Fund SICAV SIF Vitalis Fixed Income-Lux Fd A USD', N'MH Fund SICAV SIF Vitalis Fixed Income-Lux Fd A USD', 5, NULL, N'USD', N'LU', N'LU', NULL, NULL, NULL, NULL, 1, 0, N'D1', 0, 0, N'LX', N'VITFXIA LX', NULL, N'LU1554410974', NULL, N'LU6794A', N'LU6794A', NULL, CAST(N'2020-08-31T00:00:00.000' AS DateTime), N'A', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (255, CAST(N'2020-09-04T00:00:00.000' AS DateTime), NULL, N'Emerald Euro Government Bond R EUR ACC', N'Emerald Euro Government Bond R EUR ACC', 2, NULL, N'EUR', N'LU', N'LU', NULL, NULL, NULL, NULL, 4, 100, N'R', 0, 0, NULL, NULL, NULL, N'LU2186178591', NULL, N'26056R', NULL, NULL, NULL, N'R', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (256, CAST(N'2020-09-04T00:00:00.000' AS DateTime), NULL, N'Emerald Euro Government Bond RR EUR ACC', N'Emerald Euro Government Bond RR EUR ACC', 1, NULL, N'EUR', N'LU', N'LU', NULL, NULL, NULL, NULL, 4, 100, N'RR', 0, 0, NULL, NULL, NULL, N'LU2186178674', NULL, N'26056RR', NULL, NULL, NULL, N'RR', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (257, CAST(N'2020-09-04T00:00:00.000' AS DateTime), NULL, N'Emerald Euro Government Bond I EUR ACC', N'Emerald Euro Government Bond I EUR ACC', 4, NULL, N'EUR', N'LU', N'LU', NULL, NULL, NULL, NULL, 4, 100, N'I', 0, 0, NULL, NULL, NULL, N'LU2186178757', NULL, N'26056I', NULL, NULL, NULL, N'I', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (258, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Best Regulated Companies AH AUD', N'Pharus Sicav Best Regulated Companies AH AUD', 1, NULL, N'AUD', N'LU', NULL, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, NULL, NULL, 4, 100, NULL, 1, 0, NULL, NULL, NULL, N'TBDAHAUD    ', NULL, N'AHAUD', NULL, NULL, NULL, N'AH', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (259, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Fasanara Quant B2', N'Pharus Sicav Fasanara Quant B2', 4, NULL, N'EUR', N'LU', NULL, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, NULL, NULL, 4, 100, N'B2', 0, 0, NULL, NULL, NULL, N'LU2040055597', NULL, N'B2', NULL, NULL, NULL, N'B2', NULL, NULL)
INSERT [dbo].[tb_historyShareClass] ([sc_id], [sc_initialDate], [sc_endDate], [sc_officialShareClassName], [sc_shortShareClassName], [sc_investorType], [sc_shareType], [sc_currency], [sc_countryIssue], [sc_ultimateParentCountryRisk], [sc_emissionDate], [sc_inceptionDate], [sc_lastNav], [sc_expiryDate], [sc_status], [sc_initialPrice], [sc_accountingCode], [sc_hedged], [sc_listed], [sc_bloomberMarket], [sc_bloombedCode], [sc_bloombedId], [sc_isinCode], [sc_valorCode], [sc_faCode], [sc_taCode], [sc_WKN], [sc_date_business_year], [sc_prospectus_code], [sc_change_comment], [sc_comment_title]) VALUES (260, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, N'Pharus Sicav Target AH AUD', N'Pharus Sicav Target AH AUD', 1, NULL, N'AUD', N'LU', NULL, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL, NULL, NULL, 4, 100, N'AH', 1, 0, NULL, NULL, NULL, N'TBDAHAUD    ', NULL, N'AHAUD', NULL, NULL, NULL, N'AH', NULL, NULL)
GO
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (1, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'1st SICAV - Athena Balanced', N'1st SICAV - Athena Balanced', N'O00011081_00000005', N'30658', N'47156', N'30658', NULL, NULL, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, 1, N'	 222100P3F8MWHFBFOX70', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 1, 1, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'1st SICAV - Hestia Conservative', N'1st SICAV - Hestia Conservative', N'O00011081_00000006', N'30659', N'47157', N'30659', NULL, NULL, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, 1, N'222100GXXV9PYXJ5EJ61', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 3, 1, 1, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (3, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'1st SICAV - Italy', N'1st SICAV - Italy', N'O00011081_00000003', N'30656', N'47153', N'30656', NULL, NULL, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, 1, N'	 2221006GBQ7E4OLHMI55', NULL, 3, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'8 200 OWM01', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (4, CAST(N'2017-06-30T00:00:00.000' AS DateTime), NULL, N'Bright Stars SICAV-SIF - VITALIX', N'Bright Stars SICAV-SIF - VITALIX', N'O00011020_00000001', N'LU6542', N'5445270', N'LU6542', NULL, NULL, CAST(N'2018-12-18T00:00:00.000' AS DateTime), NULL, 1, N'	 5299001531N4FD5B2392', NULL, NULL, 4, N'USD', 4, 8, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (5, CAST(N'2011-07-14T00:00:00.000' AS DateTime), CAST(N'2019-08-12T00:00:00.000' AS DateTime), N'Efficiency Growth Fund - Euro Global Bond', N'Efficiency Growth Fund - Euro Global Bond', N'O00002118_00000010', N'51115', N'51115', N'51115', NULL, NULL, CAST(N'2011-05-03T00:00:00.000' AS DateTime), NULL, 1, N'529900DAOBBDCY8NV798', NULL, NULL, NULL, N'EUR', 1, NULL, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'FUND NAME CHANGE')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (5, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL, N'GFG Funds - Euro Global Bond', N'GFG Funds - Euro Global Bond', N'O00002118_00000010', N'51115', N'51115', N'51115                                                                                               ', NULL, NULL, CAST(N'2011-05-03T00:00:00.000' AS DateTime), NULL, 1, N'529900DAOBBDCY8NV798', NULL, 3, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 2, 1, 1, NULL, NULL, NULL, 1, NULL, N'FUND NAME CHANGE')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (6, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-08-12T00:00:00.000' AS DateTime), N'Efficiency Growth Fund - Income Opportunity', N'Efficiency Growth Fund - Income Opportunity', N'O00002118_00000013', N'33646', N'33646', N'33646', NULL, NULL, CAST(N'2017-04-25T00:00:00.000' AS DateTime), NULL, 1, N'529900MI16EB9MJ6SX85', NULL, NULL, 1, N'EUR', 1, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, N'FUND NAME CHANGED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (6, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL, N'GFG Funds - Income Opportunity', N'GFG Funds - Income Opportunity', N'O00002118_00000013', N'33646', N'33646', N'33646                                                                                               ', NULL, NULL, CAST(N'2017-04-25T00:00:00.000' AS DateTime), NULL, 1, N'	 529900MI16EB9MJ6SX85', NULL, 6, 1, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 3, 3, NULL, NULL, NULL, 2, NULL, N'FUND NAME CHANGED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (7, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Emerald Euro Inflation Linked Bond', N'Emerald Euro Inflation Linked Bond', N'O00008724_00000002', N'88057', N'88057', N'88057', NULL, NULL, CAST(N'2017-12-12T00:00:00.000' AS DateTime), NULL, 1, N'	 529900AE72FS7KYGHW03', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 2, 1, 1, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (8, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Emerald Euro Investment Grade Bond', N'Emerald Euro Investment Grade Bond', N'O00008724_00000001', N'8062', N'8062', N'8062', NULL, NULL, CAST(N'2017-11-17T00:00:00.000' AS DateTime), NULL, 1, N'	 529900DCGVVZHKM6F683', NULL, 3, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 2, 1, 1, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (9, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Kite Fund SICAV - Kite Flexible Credit', N'Kite Fund SICAV - Kite Flexible Credit', N'O00007630_00000002', N'26886', N'45122', N'26886', NULL, NULL, CAST(N'2017-03-23T00:00:00.000' AS DateTime), NULL, 1, N'	 222100QIEEYRDO22BT02', NULL, 6, 3, N'EUR', 1, 9, 2, NULL, NULL, NULL, NULL, NULL, 4, 1, 1, N'79683', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (10, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Kite Fund SICAV - Total Return', N'Kite Fund SICAV - Total Return', N'O00007630_00000001', N'22132', N'45121', N'22132', NULL, NULL, CAST(N'2012-09-25T00:00:00.000' AS DateTime), NULL, 1, N'	 529900WLOFHVZK7J4G22', NULL, 6, 3, N'EUR', 1, 9, 2, NULL, NULL, NULL, NULL, NULL, 11, 1, 1, N'99812', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (11, CAST(N'2014-10-21T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV - Alexander', N'Multi Stars SICAV - Alexander', N'O00007588_00000009', N'LU6389', N'5443740', N'LU6389', NULL, NULL, CAST(N'2014-08-28T00:00:00.000' AS DateTime), NULL, 1, N'	 529900A0YNWHVW0S6496', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 11, 1, 1, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (12, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-11-14T00:00:00.000' AS DateTime), N'Multi Stars SICAV - AL-FA Dynamic', N'Multi Stars SICAV - AL-FA Dynamic', N'O00007588_00000003', N'LU6266', N'5001200', N'LU6266', NULL, NULL, CAST(N'2012-07-23T00:00:00.000' AS DateTime), NULL, 1, N'5299003CF4QLJUYYPU03', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 11, 3, 1, NULL, NULL, NULL, 2, N'ex. AL-FA Dynamic', N'CHANGED NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (12, CAST(N'2019-11-15T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV - AL-FA Sustainable Megatrends', N'Multi Stars SICAV - AL-FA Sustainable Megatrends', N'O00007588_00000003', N'LU6266', N'5001200', N'LU6266                                                                                              ', NULL, NULL, CAST(N'2012-07-23T00:00:00.000' AS DateTime), NULL, 1, N'5299003CF4QLJUYYPU03', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 3, 1, NULL, NULL, NULL, 2, N'ex. AL-FA Dynamic', N'CHANGED NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (13, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV - Amares Strategy Fund - Balanced', N'Multi Stars SICAV - Amares Strategy Fund - Balanced', N'O00007588_00000014', N'LU6714', N'5446850', N'LU6714', NULL, NULL, CAST(N'2018-12-14T00:00:00.000' AS DateTime), NULL, 1, N'	 529900GN12WQWWPSOR02', NULL, 6, 3, N'EUR', 2, 3, 1, 0, NULL, NULL, NULL, NULL, 11, 1, 1, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (14, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV - Cefisa Relative Strenght European Equity', N'Multi Stars SICAV - Cefisa Relative Strenght European Equity', N'O00007588_00000005', N'LU6274', N'5442590', N'LU6274', NULL, NULL, CAST(N'2013-06-26T00:00:00.000' AS DateTime), NULL, 1, N'	 529900E3WLKUC0Y3AI53', NULL, 3, 3, N'EUR', 2, 1, 1, 0, NULL, NULL, NULL, NULL, 12, 1, 1, NULL, NULL, NULL, 8, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (15, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV - Cefisa Relative Strenght Global Asset Allocation', N'Multi Stars SICAV - Cefisa Relative Strenght Global Asset Allocation', N'O00007588_00000006', N'LU6275', N'5442600', N'LU6275', NULL, NULL, CAST(N'2013-06-26T00:00:00.000' AS DateTime), NULL, 1, N'	 529900COCSGVBUL0UZ80', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 12, 1, 1, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (16, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV - CUBE', N'Multi Stars Sicav - CUBE', N'O00007588_00000012', N'LU6624', N'5446090', N'LU6624', NULL, NULL, CAST(N'2017-08-25T00:00:00.000' AS DateTime), NULL, 1, N'529900LOIBDHYJLQ0T30', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 11, 1, 1, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (17, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV - HEarth ETHICAL FUND', N'Multi Stars Sicav - HEarth ETHICAL FUND', N'O00007588_00000013', N'LU6658', N'5446340', N'LU6658', NULL, NULL, CAST(N'2017-10-18T00:00:00.000' AS DateTime), NULL, 1, N'	 529900BD1ZUS0MTPY974', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 11, 3, 1, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (18, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV - Regent Serenity Fund', N'Multi Stars SICAV - Regent Serenity Fund', N'O00007588_00000010', N'LU6406', N'5443910', N'LU6406', NULL, NULL, CAST(N'2014-09-19T00:00:00.000' AS DateTime), NULL, 1, N'	 529900HLR6PAJW6NNT41', NULL, 6, 3, N'GBP', 2, 4, 1, NULL, NULL, NULL, NULL, NULL, 11, 1, 1, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (19, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV - Sureco US Core Equity', N'Multi Stars SICAV - Sureco US Core Equity', N'O00007588_00000008', N'LU6304', N'5442890', N'LU6304', NULL, NULL, CAST(N'2013-07-26T00:00:00.000' AS DateTime), NULL, 1, N'	 529900KRKQKFR52A6V34', NULL, 4, 3, N'USD', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, 8, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (20, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV - Emerging Market Local Currency', N'Multi Stars SICAV - Emerging Market Local Currency', N'O00007588_00000007', N'LU6276', N'5442610', N'LU6276', NULL, NULL, CAST(N'2013-06-26T00:00:00.000' AS DateTime), NULL, 1, N'	 5299007JJDINAVGKJN23', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 2, 1, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (21, CAST(N'2007-04-15T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus SICAV - Absolute Return', N'Pharus SICAV - Absolute Return', N'O00003465_00000008', N'19693', N'40495', N'19693', NULL, NULL, CAST(N'2004-08-04T00:00:00.000' AS DateTime), NULL, 1, N'549300OGZCRIA3VCSR93', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 4, 3, 1, N'8 200 PDG35', NULL, NULL, 2, N'PHARUS SICAV – ABSOLUTE RETURN changed the name of the sub-fund to Pharus SICAV – Conservative.

increase the minimum holding amount for share Class B from EUR 1,000 to EUR 100,000.', N'NAME CHANGE')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (21, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV – Conservative', N'Pharus SICAV – Conservative', N'O00003465_00000008', N'19693', N'40495', N'19693                                                                                               ', NULL, NULL, CAST(N'2004-08-04T00:00:00.000' AS DateTime), NULL, 1, N'549300OGZCRIA3VCSR93', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 4, NULL, NULL, N'8200PDG35                                                                                           ', NULL, NULL, 2, N'PHARUS SICAV – ABSOLUTE RETURN changed the name of the sub-fund to Pharus SICAV – Conservative.

increase the minimum holding amount for share Class B from EUR 1,000 to EUR 100,000.', N'NAME CHANGE')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (22, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Algo Flex', N'Pharus SICAV - Algo Flex', N'O00003465_00000027', N'19663', N'40463', N'19663', NULL, NULL, CAST(N'2012-02-02T00:00:00.000' AS DateTime), NULL, 1, N'	 5493002NLFW4QBPHI238', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 3, 1, N'8 200 PDG34', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (23, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-02-14T00:00:00.000' AS DateTime), N'Pharus SICAV - Asian Niches', N'Pharus SICAV - Asian Niches', N'O00003465_00000054', N'4545', N'44754', N'4545', NULL, NULL, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL, 4, N'	 549300RXJLJ47ZY3ZL19', NULL, 2, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 1, 3, 1, NULL, NULL, NULL, 2, NULL, N'SUB FUND LAUNCH')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (23, CAST(N'2019-02-15T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Asian Niches', N'Pharus SICAV - Asian Niches', N'O00003465_00000054', N'4545', N'44754', N'4545', NULL, NULL, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL, 1, N'	 549300RXJLJ47ZY3ZL19', NULL, 2, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 3, 1, NULL, NULL, NULL, 2, NULL, N'SUB FUND LAUNCH')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (24, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Athesis Total Return', N'Pharus SICAV - Athesis Total Return', N'O00003465_00000045', N'9901', N'41783', N'9901', NULL, NULL, CAST(N'2016-05-02T00:00:00.000' AS DateTime), NULL, 1, N'	 222100SYTJNZIWAPUA25', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 1, 1, N'8 200 PDG20', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (25, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Avantgarde', N'Pharus SICAV - Avantgarde', N'O00003465_00000048', N'15324', N'47394', N'15324', NULL, NULL, CAST(N'2016-07-11T00:00:00.000' AS DateTime), NULL, 1, N'22210002OFQ9S3U35E97', NULL, 6, 1, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 12, 1, 3, N'8 200 PDG10', NULL, NULL, 3, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (26, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-07-30T00:00:00.000' AS DateTime), N'Pharus SICAV - Best Global Managers Flexible Equity', N'Pharus SICAV - Best Global Managers Flexible Equity', N'O00003465_00000024', N'19658', N'40458', N'19658', NULL, NULL, NULL, NULL, 1, N'	 549300FII8TS79ZZ6V77', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, 3, 1, N'8 200 PDG47', NULL, NULL, 2, NULL, N'SUB FUND CLOSED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (26, CAST(N'2019-07-31T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Best Global Managers Flexible Equity', N'Pharus SICAV - Best Global Managers Flexible Equity', N'O00003465_00000024', N'19658', N'40458', N'19658                                                                                               ', NULL, NULL, NULL, NULL, 3, N'549300FII8TS79ZZ6V77', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, 3, 1, N'8 200 PDG47', NULL, NULL, 2, NULL, N'SUB FUND CLOSED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (27, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2020-11-18T00:00:00.000' AS DateTime), N'Pharus SICAV - Biotech', N'Pharus SICAV  - Biotech', N'O00003465_00000049', N'17389', N'47395', N'17389', NULL, NULL, CAST(N'2016-08-23T00:00:00.000' AS DateTime), NULL, 1, N'	 2221001XBCEZX0P1WC88', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 1, 1, N'8 200 PDG09', NULL, NULL, 8, N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (27, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Medical Innovation', N'Pharus SICAV - Medical Innovation', N'O00003465_00000049', N'17389', N'47395', N'17389                                                                                               ', NULL, NULL, CAST(N'2016-08-23T00:00:00.000' AS DateTime), NULL, 1, N'	 2221001XBCEZX0P1WC88', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'8200PDG09                                                                                           ', NULL, NULL, 8, N'CHANGED NAME', N'CHANGED NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (28, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Bond Opportunities', N'Pharus SICAV - Bond Opportunities', N'O00003465_00000005', N'19670', N'40475', N'19670', NULL, NULL, CAST(N'2002-12-05T00:00:00.000' AS DateTime), NULL, 1, N'	 549300R6URP1GY5YYF05', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 4, 3, 1, N'8 200 PDG43', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (29, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2020-03-04T00:00:00.000' AS DateTime), N'Pharus SICAV - Bond Value', N'Pharus SICAV - Bond Value', N'O00003465_00000050', N'17390', N'47396', N'17390', NULL, NULL, CAST(N'2017-02-09T00:00:00.000' AS DateTime), NULL, 1, N'	 222100ZVEE1SLAL6RB69', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 4, 3, 1, NULL, NULL, NULL, 1, N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (29, CAST(N'2020-03-05T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Bond Value', N'Pharus SICAV - Bond Value', N'O00003465_00000050', N'17390', N'47396', N'17390                                                                                               ', NULL, CAST(N'2020-03-05T00:00:00.000' AS DateTime), CAST(N'2017-02-09T00:00:00.000' AS DateTime), NULL, 2, N'	 222100ZVEE1SLAL6RB69', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 4, NULL, NULL, NULL, NULL, NULL, 1, N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (30, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Deepview Trading', N'Pharus SICAV - Deepview Trading', N'O00003465_00000051', N'9895', N'40494', N'9895', NULL, NULL, CAST(N'2017-02-09T00:00:00.000' AS DateTime), NULL, 1, N'	 2221005ALDKRRR359415', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 12, 1, 1, N'8 200 PDG33', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (31, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-02-14T00:00:00.000' AS DateTime), N'Pharus SICAV - Quintessenza', N'Pharus SICAV  - Quintessenza', N'O00003465_00000028', N'19666', N'40464', N'19666', NULL, NULL, CAST(N'2012-02-02T00:00:00.000' AS DateTime), NULL, 1, N'549300MCDO7CZETH1Y09', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 3, 1, N'Multiple', NULL, NULL, 2, N'ex Quintessenza ', N'CHANGE OF NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (31, CAST(N'2019-02-15T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Dynamic Allocation MV7', N'Pharus SICAV - Dynamic Allocation MV7', N'O00003465_00000028', N'19666', N'40464', N'19666', NULL, NULL, CAST(N'2012-02-02T00:00:00.000' AS DateTime), NULL, 1, N'549300MCDO7CZETH1Y09', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 3, 1, N'Multiple', NULL, NULL, 2, N'ex Quintessenza ', N'CHANGE OF NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (32, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-02-14T00:00:00.000' AS DateTime), N'Pharus SICAV - Electric Mobility Niches', N'Pharus SICAV - Electric Mobility Niches', N'	 O00003465_00000055', N'4542', N'44755', N'4542', NULL, NULL, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL, 4, N'	 549300YAC68YVVVXQ079', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 1, 3, 1, NULL, NULL, NULL, 2, NULL, N'SUB FUND LAUNCH')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (32, CAST(N'2019-02-15T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Electric Mobility Niches', N'Pharus SICAV - Electric Mobility Niches', N'O00003465_00000055', N'4542', N'44755', N'4542', NULL, NULL, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL, 1, N'549300YAC68YVVVXQ079', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 3, 1, NULL, NULL, NULL, 2, NULL, N'SUB FUND LAUNCH')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (33, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Eos', N'Pharus SICAV - Eos', N'O00003465_00000025', N'19661', N'40461', N'19661', NULL, NULL, CAST(N'2011-07-04T00:00:00.000' AS DateTime), NULL, 1, N'549300JBNB0W2FMCVZ95', NULL, 3, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 1, 1, N'8 200 PDG29', NULL, NULL, 8, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (34, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-02-14T00:00:00.000' AS DateTime), N'Pharus SICAV - Europe Absolute Return', N'Pharus SICAV - Europe Absolute Return', N'O00003465_00000046', N'9886', N'41784', N'9886', NULL, NULL, CAST(N'2016-05-12T00:00:00.000' AS DateTime), NULL, 1, N'	 222100I3217ZEPUQK436', NULL, 3, 1, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 11, 1, 1, N'Multiple', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (34, CAST(N'2019-02-15T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Europe Total Return', N'Pharus SICAV - Europe Total Return', N'	 O00003465_00000046', N'9886', N'41784', N'9886', NULL, NULL, CAST(N'2016-05-12T00:00:00.000' AS DateTime), NULL, 1, N'	 222100I3217ZEPUQK436', NULL, 6, 1, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, 3, 1, N'Multiple', NULL, NULL, 2, N'ex Europe Absolute Return', N'CHANGE OF NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (35, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2020-05-25T00:00:00.000' AS DateTime), N'Pharus SICAV - Global Dynamic Opportunities', N'Pharus SICAV - Global Dynamic Opportunities', N'O00003465_00000034', N'19684', N'40483', N'19684', NULL, NULL, CAST(N'2013-01-15T00:00:00.000' AS DateTime), NULL, 1, N'	 549300UK8G6H8OBAFX46', NULL, 6, 1, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 12, 1, 3, N'Multiple', NULL, NULL, 7, N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (35, CAST(N'2020-05-26T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Global Dynamic Opportunities', N'Pharus SICAV - Global Dynamic Opportunities', N'O00003465_00000034', N'19684', N'40483', N'19684                                                                                               ', NULL, CAST(N'2020-05-26T00:00:00.000' AS DateTime), CAST(N'2013-01-15T00:00:00.000' AS DateTime), NULL, 2, N'549300UK8G6H8OBAFX46', NULL, 6, 1, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 12, NULL, NULL, NULL, NULL, NULL, 7, N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (36, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-02-06T00:00:00.000' AS DateTime), N'Pharus SICAV - Valeur Income', N'Pharus SICAV - Valeur Income', N'O00003465_00000013', N'19640', N'40451', N'19640', NULL, NULL, CAST(N'2009-11-12T00:00:00.000' AS DateTime), NULL, 1, N'549300XAJHZ5S6DKT677', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 3, 3, 1, N'8 200 PDG39', NULL, NULL, 1, N'ex Valeur Income', N'CHANGE OF NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (36, CAST(N'2019-02-07T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Global Flexible Bond', N'Pharus SICAV - Global Flexible Bond', N'O00003465_00000013', N'19640', N'40451', N'19640', NULL, NULL, CAST(N'2009-11-12T00:00:00.000' AS DateTime), NULL, 1, N'549300XAJHZ5S6DKT677', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 3, 3, 1, N'8 200 PDG39', NULL, NULL, 1, N'ex Valeur Income', N'CHANGE OF NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (37, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Global Value Equity', N'Pharus SICAV - Global Value Equity', N'O00003465_00000041', N'9894', N'40493', N'9894', NULL, NULL, CAST(N'2016-02-10T00:00:00.000' AS DateTime), NULL, 1, N'2221003B2JN3V3ESGR30', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, 8, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (38, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - I-Bond Plus Solution', N'Pharus SICAV - I-Bond Plus Solution', N'O00003465_00000044', N'9899', N'41782', N'9899', NULL, NULL, CAST(N'2016-05-02T00:00:00.000' AS DateTime), NULL, 1, N'	 222100T975WVXB8ZLF90', NULL, 6, 3, N'USD', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 4, 1, 1, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (39, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - International Equity Quant', N'Pharus SICAV - International Equity Quant', N'O00003465_00000017', N'19655', N'40456', N'19655', NULL, NULL, CAST(N'2009-12-11T00:00:00.000' AS DateTime), NULL, 1, N'	 549300ES0XMCO0CYPL15', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 2, 1, NULL, NULL, NULL, 8, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (40, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Liquidity', N'Pharus SICAV - Liquidity', N'O00003465_00000006', N'19673', N'40480', N'19673', NULL, NULL, CAST(N'2002-12-05T00:00:00.000' AS DateTime), NULL, 1, N'	 5493005E4I7C5IQM9V11', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 2, 3, 1, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (41, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Marzotto Active Bond', N'Pharus SICAV - Marzotto Active Bond', N'O00003465_00000042', N'9887', N'41788', N'9887', NULL, NULL, CAST(N'2016-02-10T00:00:00.000' AS DateTime), NULL, 1, N'	 222100TFM3FH5AUIFG89', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 4, 3, 1, N'8 200 PDG23', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (42, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Marzotto Active Diversified', N'Pharus SICAV - Marzotto Active Diversified', N'O00003465_00000043', N'9897', N'41789', N'9897', NULL, NULL, CAST(N'2016-02-10T00:00:00.000' AS DateTime), NULL, 1, N'222100QX5K8CO406MP08', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 3, 1, N'8 200 PDG24', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (43, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-02-06T00:00:00.000' AS DateTime), N'Pharus SICAV - Value', N'Pharus SICAV - Value', N'O00003465_00000011', N'19867', N'41785', N'19867', NULL, NULL, CAST(N'2008-05-20T00:00:00.000' AS DateTime), NULL, 1, N'	 54930004G7UQ6EUX8D07', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 1, 3, 1, N'8 200 PDG36', NULL, NULL, 2, N'ex Value', N'CHANGE OF NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (43, CAST(N'2019-02-07T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Next Revolution', N'Pharus SICAV - Next Revolution', N'O00003465_00000011', N'19867', N'41785', N'19867', NULL, NULL, CAST(N'2008-05-20T00:00:00.000' AS DateTime), NULL, 1, N'	 54930004G7UQ6EUX8D07', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 1, 1, N'8 200 PDG36', NULL, NULL, 2, N'ex Value', N'CHANGE OF NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (44, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Southern Europe', N'Pharus SICAV  - Southern Europe', N'O00003465_00000040', N'52294', N'41781', N'52294', NULL, NULL, CAST(N'2015-11-20T00:00:00.000' AS DateTime), NULL, 1, N'	 2221007ABU3XM8HL4G82', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 1, 1, N'8 200 PDG27', NULL, NULL, 8, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (45, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Target', N'Pharus SICAV - Target', N'O00003465_00000026', N'19662', N'40462', N'19662', NULL, NULL, CAST(N'2012-02-02T00:00:00.000' AS DateTime), NULL, 1, N'	 5493005S307UO5UDVQ16', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 4, 3, 1, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (46, CAST(N'2019-11-12T00:00:00.000' AS DateTime), NULL, N'Multi Stars SICAV - Prosperise', N'Multi Stars SICAV - Prosperise', N'O00007588_00000015', N'LU6743', N'5447140', N'LU6743', NULL, NULL, NULL, NULL, 4, N'529900V4I3S8JJ4BJP71', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (47, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Tikehon Global Growth & Income Fund', N'Pharus SICAV - Tikehon Global Growth & Income Fund', N'O00003465_00000037', N'51649', N'40496', N'51649', NULL, NULL, CAST(N'2015-09-01T00:00:00.000' AS DateTime), NULL, 1, N'	 2221008Q176Q8V6EXV22', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 12, 3, 1, N'8 200 PDG31', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (48, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Titan Aggressive', N'Pharus SICAV - Titan Aggressive', N'O00003465_00000016', N'19641', N'40453', N'19641', NULL, NULL, CAST(N'2009-12-11T00:00:00.000' AS DateTime), NULL, 1, N'	 5493009GSR0HWW9CHR28', NULL, 6, 3, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, 12, 3, 1, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (49, CAST(N'2019-01-17T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Trend Player', N'Pharus SICAV - Trend Player', N'O00003465_00000039', N'51653', N'40498', N'51653', NULL, NULL, CAST(N'2015-09-01T00:00:00.000' AS DateTime), NULL, 1, N'	 222100Y1L0BH7IHTMD28', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 3, 1, N'8 200 PDG30', NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (50, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-12-15T00:00:00.000' AS DateTime), N'Ritom SICAV-RAIF - Peak Fund', N'Ritom SICAV-RAIF - Peak Fund', N'V00001829_00000001', N'48471', N'49011', N'48471', NULL, NULL, CAST(N'2017-08-07T00:00:00.000' AS DateTime), NULL, 1, N'	 549300B5RGUEKZ7L9I50', NULL, NULL, 4, N'EUR', 2, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (50, CAST(N'2019-12-16T00:00:00.000' AS DateTime), NULL, N'Ritom SICAV-RAIF - Peak Fund', N'Ritom SICAV-RAIF - Peak Fund', N'V00001829_00000001', N'48471', N'49011', N'48471                                                                                               ', NULL, CAST(N'2019-12-16T00:00:00.000' AS DateTime), CAST(N'2017-08-07T00:00:00.000' AS DateTime), NULL, 2, N'	 549300B5RGUEKZ7L9I50', NULL, NULL, 4, N'EUR', 2, 1, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, N'Liquidated', N'LIQUIDATED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (51, CAST(N'2003-06-20T00:00:00.000' AS DateTime), NULL, N'Sifter Fund - Global', N'Sifter Fund - Global', N'O00003553_00000001', N'038001', N'5126125351', N'038001                                                                                              ', NULL, NULL, CAST(N'2003-06-16T00:00:00.000' AS DateTime), NULL, 2, N'	 549300J13DF5BV0ZMR28', NULL, NULL, NULL, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, N'Changed ManCo to ADEPA', N'CHANGE MANCO')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (51, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-08-30T00:00:00.000' AS DateTime), N'Sifter Fund - Global', N'Sifter Fund - Global', N'O00003553_00000001', N'038001', N'5126125351', N'038001', NULL, NULL, CAST(N'2003-06-16T00:00:00.000' AS DateTime), NULL, 1, N'	 549300J13DF5BV0ZMR28', NULL, NULL, NULL, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, N'Changed ManCo to ADEPA', N'CHANGE MANCO')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (52, CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL, N'Swan SICAV-SIF - Swan Bond Enhanced Fund', N'Swan SICAV-SIF - Swan Bond Enhanced Fund', N'O00007843_00000001', N'19876', N'42081', N'19876', NULL, NULL, CAST(N'2013-05-15T00:00:00.000' AS DateTime), NULL, 1, N'	 549300SVWMINFVPKMY60', NULL, NULL, 1, N'EUR', 1, 9, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (53, CAST(N'2018-08-01T00:00:00.000' AS DateTime), CAST(N'2019-12-12T00:00:00.000' AS DateTime), N'Swan SICAV-SIF - Swan Dynamic Fund', N'Swan SICAV-SIF - Swan Dynamic Fund', N'O00003465_00000038', N'22187', N'22187', N'22187', NULL, NULL, CAST(N'2014-05-15T00:00:00.000' AS DateTime), NULL, 1, N'	 549300FPV9BDVPIREI41', NULL, NULL, 1, N'EUR', 2, 5, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, N'SUB FUND CLOSED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (53, CAST(N'2019-12-13T00:00:00.000' AS DateTime), NULL, N'Swan SICAV-SIF - Swan Dynamic Fund', N'Swan SICAV-SIF - Swan Dynamic Fund', N'O00003465_00000038', N'22187', N'22187', N'22187                                                                                               ', NULL, NULL, CAST(N'2014-05-15T00:00:00.000' AS DateTime), NULL, 3, N'549300FPV9BDVPIREI41', NULL, NULL, 1, N'EUR', 2, 5, 2, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, N'Closed', N'SUB FUND CLOSED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (54, CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL, N'Swan SICAV-SIF - Swan Long Short Credit Fund', N'Swan SICAV-SIF - Swan Long Short Credit Fund', N'O00007843_00000003', N'19878', N'42083', N'19878', NULL, NULL, CAST(N'2013-05-15T00:00:00.000' AS DateTime), NULL, 1, N'	 549300XV1ZIXRU3L8895', NULL, NULL, 1, N'EUR', 1, 9, 2, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (55, CAST(N'2018-08-01T00:00:00.000' AS DateTime), NULL, N'Swan SICAV-SIF - Swan Multistrategy Fund', N'Swan SICAV-SIF - Swan Multistrategy Fund', N'O00007843_00000004', N'19879', N'42084', N'19879', NULL, NULL, CAST(N'2013-05-15T00:00:00.000' AS DateTime), NULL, 1, N'	 549300QR2VGU7UJBGF29', NULL, NULL, 1, N'EUR', 1, 9, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (56, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral SICAV - BZ  Active Income Fund', N'Timeo Neutral SICAV - BZ  Active Income Fund', N'O00003599_00000015', N'32601', N'32601', N'32601', NULL, NULL, CAST(N'2012-05-23T00:00:00.000' AS DateTime), NULL, 1, N'	 549300YI603JVZXEQD58', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 4, 3, 1, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (57, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral SICAV - BZ  Conservative Wolf Fund', N'Timeo Neutral SICAV - BZ  Conservative Wolf Fund', N'O00003599_00000011', N'32537', N'32537', N'32537', NULL, NULL, CAST(N'2012-05-23T00:00:00.000' AS DateTime), NULL, 1, N'	 549300NOX71KNJL64E60', NULL, 6, 1, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 4, 1, 1, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (58, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral SICAV - BZ  Inflation Linked Bonds Fund', N'Timeo Neutral SICAV - BZ  Inflation Linked Bonds Fund', N'O00003599_00000004', N'32536', N'32536', N'32536', NULL, NULL, CAST(N'2003-09-05T00:00:00.000' AS DateTime), NULL, 1, N'	 549300U86312VBXUYU82', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 2, 3, 1, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (59, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral SICAV - BZ Syntagma Absolute Return', N'Timeo Neutral SICAV - BZ Syntagma Absolute Return', N'O00003599_00000025', N'49145', N'49145', N'49145', NULL, NULL, CAST(N'2018-06-13T00:00:00.000' AS DateTime), NULL, 1, N'	 529900PNTO7KC889K531', NULL, 6, 1, N'USD', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 3, 3, NULL, NULL, NULL, 7, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (60, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2020-09-14T00:00:00.000' AS DateTime), N'Timeo Neutral SICAV - CFO AMERICA 38', N'Timeo Neutral SICAV - CFO AMERICA 38', N'O00003599_00000021', N'32605', N'32605', N'32605', NULL, NULL, CAST(N'2015-05-18T00:00:00.000' AS DateTime), NULL, 1, N'	 529900WNO21ZCONVZ903', NULL, 4, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, 7, N'SUBFUND in liquidation', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (60, CAST(N'2020-09-15T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral SICAV - CFO AMERICA 38', N'Timeo Neutral SICAV - CFO AMERICA 38', N'O00003599_00000021', N'32605', N'32605', N'32605                                                                                               ', NULL, CAST(N'2020-09-15T00:00:00.000' AS DateTime), CAST(N'2015-05-18T00:00:00.000' AS DateTime), NULL, 3, N'	 529900WNO21ZCONVZ903', NULL, 4, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, 7, N'SUBFUND in liquidation', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (61, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2020-09-14T00:00:00.000' AS DateTime), N'Timeo Neutral SICAV - CFO EUROPA 38', N'Timeo Neutral SICAV - CFO EUROPA 38', N'O00003599_00000020', N'32604', N'32604', N'32604', NULL, NULL, CAST(N'2015-05-18T00:00:00.000' AS DateTime), NULL, 1, N'	 529900Z85NVXARCBET49', NULL, 3, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, NULL, 7, N'subfund liquidated', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (61, CAST(N'2020-09-15T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral SICAV - CFO EUROPA 38', N'Timeo Neutral SICAV - CFO EUROPA 38', N'O00003599_00000020', N'32604', N'32604', N'32604                                                                                               ', NULL, CAST(N'2020-09-15T00:00:00.000' AS DateTime), CAST(N'2015-05-18T00:00:00.000' AS DateTime), NULL, 3, N'529900Z85NVXARCBET49', NULL, 3, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, 7, N'subfund liquidated', N'SUBFUND IN LIQUIDATION')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (62, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-08-06T00:00:00.000' AS DateTime), N'Timeo Neutral SICAV - European Absolute Return Fund', N'Timeo Neutral SICAV - European Absolute Return Fund', N'O00003599_00000023', N'16400', N'16400', N'16400', NULL, NULL, NULL, NULL, 1, N'	 529900JXF8S6N1I9A690', NULL, 6, NULL, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, 3, 1, NULL, NULL, NULL, 8, NULL, N'SUB FUND LIQUIDATED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (62, CAST(N'2019-08-07T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral SICAV - European Absolute Return Fund', N'Timeo Neutral SICAV - European Absolute Return Fund', N'O00003599_00000023', N'16400', N'16400', N'16400                                                                                               ', NULL, NULL, NULL, NULL, 2, N'529900JXF8S6N1I9A690', NULL, 6, NULL, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, 3, 1, NULL, NULL, NULL, 8, NULL, N'SUB FUND LIQUIDATED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (63, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL, N'United SICAV-RAIF - Market Neutral Actions Euro', N'United SICAV-RAIF - Market Neutral Actions Euro', N'V00001957_00000001', N'1826', N'46581', N'1826', NULL, NULL, CAST(N'2018-04-27T00:00:00.000' AS DateTime), NULL, 1, N'	 54930084108B8S6V7E17', NULL, NULL, 4, N'EUR', 2, 5, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Multiple', NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (64, CAST(N'2019-01-01T00:00:00.000' AS DateTime), CAST(N'2019-04-15T00:00:00.000' AS DateTime), N'1st SICAV - Europe Small Cap', N'1st SICAV - Europe Small Cap', N'	 O00011081_00000004', NULL, NULL, NULL, NULL, NULL, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, 1, N'222100SQMFTXUFTDP148', NULL, NULL, NULL, N'EUR', 1, 9, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (64, CAST(N'2019-04-16T00:00:00.000' AS DateTime), NULL, N'1st SICAV - Europe Small Cap', N'1st SICAV - Europe Small Cap', N'O00011081_00000004', N'12345', NULL, NULL, NULL, NULL, NULL, NULL, 3, N'222100SQMFTXUFTDP148', NULL, NULL, NULL, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 8, NULL, N'SUB FUND CLOSED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (65, CAST(N'2019-02-15T00:00:00.000' AS DateTime), CAST(N'2019-06-17T00:00:00.000' AS DateTime), N'Pharus SICAV - Target Equity Dividend', N'Pharus SICAV - Target Equity Dividend', N'	 O00003465_00000057', N'4543', N'44756', N'4543', NULL, NULL, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL, 4, N'	 549300G81CVUJTUGB498', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 1, 1, N'8 200 PDG47', NULL, NULL, 8, NULL, N'SUB FUND LAUNCH')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (65, CAST(N'2019-06-18T00:00:00.000' AS DateTime), CAST(N'2019-12-15T00:00:00.000' AS DateTime), N'Pharus SICAV - Target Equity Dividend', N'Pharus SICAV - Target Equity Dividend', N'	 O00003465_00000057', N'4543', N'44756', N'4543', NULL, NULL, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL, 1, N'	 549300G81CVUJTUGB498', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 1, 1, N'8 200 PDG47', NULL, NULL, 8, N'ex Target Equity Dividend', N'CHANGE OF NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (65, CAST(N'2019-12-16T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Best Regulated Companies', N'Pharus SICAV - Best Regulated Companies', N'	 O00003465_00000057', N'4543', N'44756', N'4543', NULL, NULL, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL, 1, N'	 549300G81CVUJTUGB498', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 1, 1, 1, N'8 200 PDG47', NULL, NULL, 8, N'ex Target Equity Dividend', N'CHANGE OF NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (66, CAST(N'2019-12-18T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Fasanara Quant', N'Pharus SICAV - Fasanara Quant', N'O00003465_00000058', N'402', N'40506', N'402', NULL, NULL, CAST(N'2019-11-08T00:00:00.000' AS DateTime), NULL, 1, N'549300SPDK7HIAE50683', NULL, 6, 1, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, 3, 1, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (67, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL, N'GFG Funds - Alternative Alpha Strategy
', N'GFG Funds - Alternative Alpha Strategy', N'O00002118_00000019', N'38068', N'38068', N'38068', NULL, NULL, CAST(N'2019-07-22T00:00:00.000' AS DateTime), NULL, 4, N'529900FMU7B2ODIK1F06', NULL, NULL, NULL, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (68, CAST(N'2019-08-13T00:00:00.000' AS DateTime), NULL, N'GFG Funds - Global Corporate Bond', N'GFG Funds - Global Corporate Bond', N'O00002118_00000017', N'38123', N'38123', N'38123', NULL, NULL, CAST(N'2019-07-22T00:00:00.000' AS DateTime), NULL, 1, N'	 5299000ODH2E94NAJ487', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 4, 3, 1, NULL, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (69, CAST(N'2019-01-17T00:00:00.000' AS DateTime), CAST(N'2019-02-14T00:00:00.000' AS DateTime), N'Pharus SICAV - Swan Relative Strategy', N'Pharus SICAV - Swan Relative Strategy', NULL, N'51650', N'40497 ', N'51650', NULL, NULL, CAST(N'2014-05-15T00:00:00.000' AS DateTime), NULL, 1, N'	 222100HFMLLX4RV0GU07', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, 3, 1, NULL, NULL, NULL, 2, N'ex Swan Relative Strategy', N'CHANGE OF NAME')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (69, CAST(N'2019-02-15T00:00:00.000' AS DateTime), CAST(N'2019-03-18T00:00:00.000' AS DateTime), N'Pharus SICAV - Swan Dynamic', N'Pharus SICAV - Swan Dynamic', NULL, N'51650', N'40497 ', N'51650', NULL, NULL, CAST(N'2014-05-15T00:00:00.000' AS DateTime), NULL, 1, N'	 222100HFMLLX4RV0GU07', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, 3, 1, NULL, NULL, NULL, 2, NULL, N'SUB FUND CLOSED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (69, CAST(N'2019-03-19T00:00:00.000' AS DateTime), NULL, N'Pharus SICAV - Swan Dynamic', N'Pharus SICAV - Swan Dynamic', NULL, N'51650', N'40497', N'51650', NULL, NULL, CAST(N'2014-05-15T00:00:00.000' AS DateTime), NULL, 3, N'	 222100HFMLLX4RV0GU07', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, 3, 1, NULL, NULL, NULL, 2, NULL, N'SUB FUND CLOSED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (70, CAST(N'2019-08-13T00:00:00.000' AS DateTime), CAST(N'2020-03-04T00:00:00.000' AS DateTime), N'GFG Funds - Global Enhanced Cash', N'GFG Funds - Global Enhanced Cash', N'O00002118_00000018', N'38110', N'38110', N'38110', NULL, NULL, CAST(N'2019-07-22T00:00:00.000' AS DateTime), NULL, 4, N'	 529900BQ5Y6853N43J70', NULL, NULL, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'SUB FUND LAUNCHED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (70, CAST(N'2020-03-05T00:00:00.000' AS DateTime), NULL, N'GFG Funds - Global Enhanced Cash', N'GFG Funds - Global Enhanced Cash', N'O00002118_00000018', N'38110', N'38110', N'38110                                                                                               ', NULL, NULL, CAST(N'2019-07-22T00:00:00.000' AS DateTime), NULL, 1, N'529900BQ5Y6853N43J70', NULL, NULL, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'SUB FUND LAUNCHED')
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (72, CAST(N'2017-03-01T16:41:00.000' AS DateTime), CAST(N'2019-09-16T00:00:00.000' AS DateTime), N'1st SICAV - Emerging Africa', N'1st SICAV - Emerging Africa', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (73, CAST(N'2017-03-01T00:00:00.000' AS DateTime), CAST(N'2019-09-16T00:00:00.000' AS DateTime), N'1st SICAV - Emerging Asia', N'1st SICAV - Emerging Asia', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, NULL, NULL, NULL, NULL, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (74, CAST(N'2019-12-01T00:00:00.000' AS DateTime), NULL, N'Ritom SICAV-RAIF - Astipalea', N'Ritom SICAV-RAIF - Astipalea', N'V00001829_00000002', N'23765', N'49014', N'23765', NULL, NULL, CAST(N'2020-01-13T00:00:00.000' AS DateTime), NULL, 1, N'	 5493000JVVGLMY1ZMW60', NULL, NULL, 4, N'EUR', 2, 1, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (75, CAST(N'2019-12-01T00:00:00.000' AS DateTime), NULL, N'Ritom SICAV-RAIF - Archimede', N'Ritom SICAV-RAIF- Archimede', N'V00001829_00000003', N'23764', N'49013', N'23764', NULL, NULL, CAST(N'2020-01-13T00:00:00.000' AS DateTime), NULL, 1, N'	 54930088HSOXBT8ON347', NULL, NULL, 4, N'EUR', 4, 8, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8-200-PDG57', NULL, NULL, 2, NULL, NULL)
GO
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (76, CAST(N'2018-08-01T00:00:00.000' AS DateTime), CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Timeo Neutral SICAV - BZ Equity Value Fund', N'Timeo Neutral SICAV - BZ Equity Value Fund', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, N'	 549300S9JS8VOQX0Y182', NULL, 6, NULL, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (77, CAST(N'2018-08-01T00:00:00.000' AS DateTime), CAST(N'2019-02-25T00:00:00.000' AS DateTime), N'Timeo Neutral SICAV - BZ Diversified Fund', N'Timeo Neutral SICAV - BZ Diversified Fund', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, N'	 5493004EWD82GHG4C578', NULL, 6, NULL, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, NULL, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (78, CAST(N'2019-08-01T00:00:00.000' AS DateTime), NULL, N'Timeo Neutral SICAV - BZ Best Global Managers Flexible Equity', N'Timeo Neutral SICAV - BZ Best Global Managers Flexible Equity', N'	 O00003599_00000024', N'49134', N'49134', N'49134', NULL, NULL, CAST(N'2018-06-13T00:00:00.000' AS DateTime), NULL, 1, N'	 529900POMJB5BDBU5Q05', NULL, 6, 3, N'EUR', 1, 9, 1, 0, NULL, NULL, NULL, NULL, 11, 3, 1, NULL, NULL, NULL, 8, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (79, CAST(N'2017-06-30T00:00:00.000' AS DateTime), NULL, N'Bright Stars SICAV-SIF - Stability Fund', N'Bright Stars SICAV-SIF - Stability Fund', N'O00011020_00000002', NULL, NULL, NULL, NULL, NULL, CAST(N'2018-12-18T00:00:00.000' AS DateTime), NULL, 4, NULL, NULL, NULL, NULL, N'EUR', 4, 8, 1, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (84, CAST(N'2020-08-31T00:00:00.000' AS DateTime), NULL, N'MH Fund SICAV-SIF - Vitalis Equity-Lux Fund', N'MH Fund SICAV-SIF - Vitalis Equity-Lux Fund', N'O00008878_00000003', N'LU6793', N'LU6793', N'LU6793', CAST(N'2020-08-31T00:00:00.000' AS DateTime), NULL, CAST(N'2020-08-28T00:00:00.000' AS DateTime), NULL, 1, N'222100JA8EZLYLRYEN85', 3, 6, 4, N'USD', 1, 9, 1, 1, 3, 3, NULL, NULL, 1, 1, 1, N'LU6793', NULL, 1, 8, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (85, CAST(N'2020-08-31T00:00:00.000' AS DateTime), NULL, N'MH Fund SICAV-SIF - Vitalis Fixed Income-Lux Fund', N'MH Fund SICAV-SIF - Vitalis Fixed Income-Lux Fund', N'O00008878_00000004', N'LU6794', N'LU6794', N'LU6794', CAST(N'2020-08-31T00:00:00.000' AS DateTime), NULL, CAST(N'2020-08-28T00:00:00.000' AS DateTime), NULL, 1, N'222100345565UTF1H147', 3, 6, 4, N'USD', 1, 9, 1, 1, 3, 3, NULL, NULL, 4, 3, 1, N'LU6794', 256, 2, 1, NULL, NULL)
INSERT [dbo].[tb_historySubFund] ([sf_id], [sf_initialDate], [sf_endDate], [sf_officialSubFundName], [sf_shortSubFundName], [sf_cssfCode], [sf_faCode], [sf_depCode], [sf_taCode], [sf_firstNavDate], [sf_lastNavDate], [sf_cssfAuthDate], [sf_expDate], [sf_status], [sf_leiCode], [sf_cesrClass], [sf_cssf_geographical_focus], [sf_globalExposure], [sf_currency], [sf_navFrequency], [sf_valutationDate], [sf_calculationDate], [sf_derivatives], [sf_derivMarket], [sf_derivPurpose], [sf_lastProspectus], [sf_lastProspectusDate], [sf_principal_asset_class], [sf_type_of_market], [sf_principal_investment_strategy], [sf_clearing_code], [sf_cat_morningstar], [sf_category_six], [sf_category_bloomberg], [sf_change_comment], [sf_comment_title]) VALUES (86, CAST(N'2020-09-04T00:00:00.000' AS DateTime), NULL, N'Emerald Euro Government Bond', N'Emerald Euro Government Bond', N'O00008724_00000003', N'26056', N'26056', N'26056', NULL, NULL, NULL, NULL, 4, NULL, 3, 3, 3, N'EUR', 1, 9, 1, 1, 3, 3, NULL, NULL, 4, 1, 1, NULL, 68, 2, 1, NULL, NULL)
GO
INSERT [dbo].[tb_file] ([file_id]) VALUES (1)
INSERT [dbo].[tb_file] ([file_id]) VALUES (2)
GO
INSERT [dbo].[tb_map_filefund] ([file_id], [file_name], [file_extension], [doc_fundId], [doc_startConnection], [doc_endConnection], [doc_filetype]) VALUES (1, N'TIMEO NEUTRAL SICAV - Prospectus June 2019 - VISA.pdf', N'.pdf', 11, CAST(N'2019-06-01T00:00:00.000' AS DateTime), CAST(N'2020-06-01T00:00:00.000' AS DateTime), 2)
GO
INSERT [dbo].[tb_serviceAgreement_fund] ([file_id], [file_name], [file_extension], [sa_fundId], [sa_activityType], [sa_contractDate], [sa_activationDate], [sa_expirationDate], [sa_status], [sa_company]) VALUES (2, N'2016 07 13 - PHARUS SICAV - Central Administration Agreement - EDRA & PM Lux & PS - signed.pdf', N'.pdf', 1, 8, CAST(N'2016-07-13T00:00:00.000' AS DateTime), CAST(N'2016-07-13T00:00:00.000' AS DateTime), CAST(N'2017-07-13T00:00:00.000' AS DateTime), 1, 2)
GO
INSERT [dbo].[tb_map_nav_frequency_valuation] ([id_dom_freq], [id_dom_val_date]) VALUES (1, 9)
INSERT [dbo].[tb_map_nav_frequency_valuation] ([id_dom_freq], [id_dom_val_date]) VALUES (2, 1)
INSERT [dbo].[tb_map_nav_frequency_valuation] ([id_dom_freq], [id_dom_val_date]) VALUES (2, 3)
INSERT [dbo].[tb_map_nav_frequency_valuation] ([id_dom_freq], [id_dom_val_date]) VALUES (2, 4)
INSERT [dbo].[tb_map_nav_frequency_valuation] ([id_dom_freq], [id_dom_val_date]) VALUES (2, 5)
INSERT [dbo].[tb_map_nav_frequency_valuation] ([id_dom_freq], [id_dom_val_date]) VALUES (4, 1)
INSERT [dbo].[tb_map_nav_frequency_valuation] ([id_dom_freq], [id_dom_val_date]) VALUES (4, 8)
GO
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (1)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (2)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (3)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (4)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (5)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (6)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (7)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (8)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (9)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (10)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (11)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (12)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (13)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (14)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (15)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (16)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (17)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (18)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (19)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (20)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (21)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (22)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (23)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (24)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (25)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (26)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (27)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (28)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (29)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (30)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (31)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (32)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (33)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (34)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (35)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (36)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (37)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (38)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (39)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (40)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (41)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (42)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (43)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (44)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (45)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (46)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (47)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (48)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (49)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (50)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (51)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (52)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (53)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (54)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (55)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (56)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (57)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (58)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (59)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (60)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (61)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (62)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (63)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (64)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (65)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (66)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (67)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (68)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (69)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (70)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (71)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (72)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (73)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (74)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (75)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (76)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (77)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (78)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (79)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (80)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (81)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (82)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (83)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (84)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (85)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (86)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (87)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (88)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (89)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (90)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (91)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (92)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (93)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (94)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (95)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (96)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (97)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (98)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (99)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (100)
GO
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (101)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (102)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (103)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (104)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (105)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (106)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (107)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (108)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (109)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (110)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (111)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (112)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (113)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (114)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (115)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (116)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (117)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (118)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (119)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (120)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (121)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (122)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (123)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (124)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (125)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (126)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (127)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (128)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (129)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (130)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (131)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (132)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (133)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (134)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (135)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (136)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (137)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (138)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (139)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (140)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (141)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (142)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (143)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (144)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (145)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (146)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (147)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (148)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (149)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (150)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (151)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (152)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (153)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (154)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (155)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (156)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (157)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (158)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (159)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (160)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (161)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (162)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (163)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (164)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (165)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (166)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (167)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (168)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (169)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (170)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (171)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (172)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (173)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (174)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (175)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (176)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (177)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (178)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (179)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (180)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (181)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (182)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (183)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (184)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (185)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (186)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (187)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (188)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (189)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (190)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (191)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (192)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (193)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (194)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (195)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (196)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (197)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (198)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (199)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (200)
GO
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (201)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (202)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (203)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (204)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (205)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (206)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (207)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (208)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (209)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (210)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (211)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (212)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (213)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (214)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (215)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (216)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (217)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (218)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (219)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (220)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (221)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (222)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (223)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (224)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (225)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (226)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (227)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (228)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (229)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (230)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (231)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (232)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (233)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (234)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (235)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (236)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (237)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (238)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (239)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (240)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (241)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (242)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (243)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (244)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (245)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (246)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (247)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (248)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (249)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (250)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (251)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (252)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (253)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (254)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (255)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (256)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (257)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (258)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (259)
INSERT [dbo].[tb_shareClass] ([id_sc]) VALUES (260)
GO
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (1)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (2)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (3)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (4)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (5)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (6)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (7)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (8)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (9)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (10)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (11)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (12)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (13)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (14)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (15)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (16)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (17)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (18)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (19)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (20)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (21)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (22)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (23)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (24)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (25)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (26)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (27)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (28)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (29)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (30)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (31)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (32)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (33)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (34)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (35)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (36)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (37)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (38)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (39)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (40)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (41)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (42)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (43)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (44)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (45)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (46)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (47)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (48)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (49)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (50)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (51)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (52)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (53)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (54)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (55)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (56)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (57)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (58)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (59)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (60)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (61)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (62)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (63)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (64)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (65)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (66)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (67)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (68)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (69)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (70)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (71)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (72)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (73)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (74)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (75)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (76)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (77)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (78)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (79)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (80)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (81)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (82)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (83)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (84)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (85)
INSERT [dbo].[tb_subFund] ([id_subFund]) VALUES (86)
GO
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (1, 5, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (2, 5, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (3, 5, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (4, 5, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (5, 5, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (6, 5, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (7, 5, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (8, 6, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (9, 6, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (10, 8, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (11, 8, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (12, 8, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (13, 8, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (14, 7, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (15, 7, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (16, 56, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (17, 56, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (18, 56, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (19, 57, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (20, 57, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (21, 57, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (22, 57, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (23, 57, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (24, 13, CAST(N'2018-06-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (25, 15, CAST(N'2015-03-27T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (26, 17, CAST(N'2018-06-04T00:00:00.000' AS DateTime), CAST(N'2019-12-13T00:00:00.000' AS DateTime))
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (27, 17, CAST(N'2019-05-28T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (28, 17, CAST(N'2019-05-22T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (29, 17, CAST(N'2019-05-28T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (30, 58, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (31, 58, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (32, 58, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (33, 58, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (34, 58, CAST(N'2013-01-24T00:00:00.000' AS DateTime), CAST(N'2018-11-19T00:00:00.000' AS DateTime))
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (35, 75, CAST(N'2020-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (36, 75, CAST(N'2020-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (37, 74, CAST(N'2020-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (38, 74, CAST(N'2020-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (39, 70, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (40, 70, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (41, 70, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (42, 60, CAST(N'2015-07-03T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (43, 60, CAST(N'2015-09-22T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (44, 61, CAST(N'2015-07-03T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (45, 61, CAST(N'2015-09-22T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (46, 62, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (47, 62, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (48, 62, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (49, 62, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (50, 62, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (51, 54, CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (52, 54, CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (53, 54, CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (54, 54, CAST(N'2014-01-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (55, 59, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (56, 59, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (57, 59, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (58, 59, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (59, 78, CAST(N'2018-06-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (60, 78, CAST(N'2018-06-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (61, 78, CAST(N'2018-06-13T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (62, 1, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (63, 64, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (64, 64, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (65, 2, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (66, 3, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (67, 3, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (68, 9, CAST(N'2017-03-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (69, 10, CAST(N'2012-09-11T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (70, 21, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (71, 21, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (72, 21, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (73, 21, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (74, 21, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (75, 21, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (76, 22, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (77, 22, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (78, 22, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (79, 24, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (80, 24, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (81, 25, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (82, 25, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (83, 25, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (84, 25, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (85, 45, CAST(N'2015-02-20T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (86, 43, CAST(N'2019-01-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (87, 25, CAST(N'2016-07-11T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (88, 26, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (89, 26, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (90, 26, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (91, 27, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (92, 27, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (93, 27, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (94, 28, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (95, 28, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (96, 28, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (97, 28, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (98, 28, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (99, 29, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (100, 30, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (101, 30, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (102, 30, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (103, 33, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (104, 34, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (105, 34, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (106, 34, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (107, 34, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (108, 34, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (109, 34, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (110, 34, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (111, 34, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (112, 34, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (113, 35, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (114, 35, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (115, 35, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (116, 35, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (117, 37, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (118, 37, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (119, 37, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (120, 37, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (121, 37, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (122, 37, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (123, 37, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (124, 37, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (125, 37, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (126, 38, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (127, 38, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (128, 39, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (129, 39, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (130, 39, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (131, 40, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (132, 40, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (133, 40, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (134, 40, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (135, 41, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (136, 41, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (137, 41, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (138, 42, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (139, 42, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (140, 42, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (141, 31, CAST(N'2012-02-29T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (142, 31, CAST(N'2012-02-29T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (143, 44, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (144, 44, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (145, 44, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (146, 44, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (147, 69, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (148, 69, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (149, 69, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (150, 45, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (151, 45, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (152, 45, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (153, 45, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (154, 45, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (155, 45, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (156, 45, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (157, 47, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (158, 47, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (159, 47, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (160, 48, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (161, 49, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (162, 49, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (163, 49, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (164, 36, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (165, 43, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (166, 43, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (167, 43, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (168, 43, CAST(N'2015-03-30T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (169, 52, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (170, 52, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (171, 52, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (172, 52, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (173, 52, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (174, 53, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (175, 53, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (176, 53, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (177, 53, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (178, 53, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (179, 53, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (180, 53, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (181, 53, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (182, 53, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (183, 53, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (184, 54, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (185, 54, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (186, 55, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (187, 55, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (188, 51, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (189, 51, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (190, 51, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (191, 17, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (192, 12, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (193, 17, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (194, 19, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (195, 19, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (196, 18, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (197, 17, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (198, 16, CAST(N'2017-09-29T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (199, 16, CAST(N'2017-09-29T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (200, 16, CAST(N'2017-09-29T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (201, 18, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (202, 18, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (203, 18, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (204, 18, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (205, 11, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (206, 20, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (207, 19, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (208, 20, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (209, 20, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (210, 14, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (211, 15, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (212, 12, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (213, 63, CAST(N'2018-03-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (214, 50, CAST(N'2017-07-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (215, 50, CAST(N'2017-07-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (216, 4, CAST(N'2019-01-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (217, 63, CAST(N'2019-02-28T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (218, 63, CAST(N'2018-03-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (219, 63, CAST(N'2018-03-12T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (220, 1, CAST(N'2018-10-04T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (221, 2, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (222, 3, CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (223, 5, CAST(N'2015-03-25T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (224, 5, CAST(N'2015-03-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (225, 68, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (226, 68, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (227, 68, CAST(N'2019-04-17T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (228, 9, CAST(N'2017-03-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (229, 9, CAST(N'2017-03-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (230, 9, CAST(N'2017-03-23T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (231, 25, CAST(N'2016-07-11T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (232, 36, CAST(N'2009-11-30T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (233, 36, CAST(N'2009-11-30T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (234, 36, CAST(N'2009-11-30T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (235, 32, CAST(N'2018-08-22T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (236, 32, CAST(N'2018-08-22T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (237, 32, CAST(N'2018-08-22T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (238, 23, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (239, 23, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (240, 23, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (241, 65, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (242, 65, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (243, 65, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (244, 65, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (245, 65, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (246, 65, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (247, 65, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (248, 65, CAST(N'2019-01-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (249, 66, CAST(N'2019-12-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (250, 66, CAST(N'2019-12-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (251, 66, CAST(N'2019-12-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (252, 66, CAST(N'2019-12-18T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (253, 84, CAST(N'2020-08-31T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (254, 85, CAST(N'2020-08-31T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (255, 86, CAST(N'2020-09-04T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (256, 86, CAST(N'2020-09-04T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (257, 86, CAST(N'2020-09-04T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (258, 65, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (259, 66, CAST(N'2020-11-19T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[tb_subFundShareClass] ([sc_id], [sf_id], [sfsc_startConnection], [sfsc_endConnection]) VALUES (260, 45, CAST(N'2020-12-01T00:00:00.000' AS DateTime), NULL)
GO
ALTER TABLE [dbo].[tb_calendar]  WITH CHECK ADD  CONSTRAINT [FK_tb_calendar_tb_map_nav_frequency_valuation] FOREIGN KEY([id_dom_freq], [id_dom_val_date])
REFERENCES [dbo].[tb_map_nav_frequency_valuation] ([id_dom_freq], [id_dom_val_date])
GO
ALTER TABLE [dbo].[tb_calendar] CHECK CONSTRAINT [FK_tb_calendar_tb_map_nav_frequency_valuation]
GO
ALTER TABLE [dbo].[tb_country_distribution_shares]  WITH CHECK ADD  CONSTRAINT [FK_tb_country_distribution_shares_tb_dom_iso_country] FOREIGN KEY([iso_country_2])
REFERENCES [dbo].[tb_dom_iso_country] ([iso_country_iso_2])
GO
ALTER TABLE [dbo].[tb_country_distribution_shares] CHECK CONSTRAINT [FK_tb_country_distribution_shares_tb_dom_iso_country]
GO
ALTER TABLE [dbo].[tb_country_distribution_shares]  WITH CHECK ADD  CONSTRAINT [FK_tb_country_distribution_shares_tb_dom_languages] FOREIGN KEY([language])
REFERENCES [dbo].[tb_dom_languages] ([language_iso_3])
GO
ALTER TABLE [dbo].[tb_country_distribution_shares] CHECK CONSTRAINT [FK_tb_country_distribution_shares_tb_dom_languages]
GO
ALTER TABLE [dbo].[tb_country_distribution_shares]  WITH CHECK ADD  CONSTRAINT [FK_tb_country_distribution_shares_tb_shareClass] FOREIGN KEY([share_id])
REFERENCES [dbo].[tb_shareClass] ([id_sc])
GO
ALTER TABLE [dbo].[tb_country_distribution_shares] CHECK CONSTRAINT [FK_tb_country_distribution_shares_tb_shareClass]
GO
ALTER TABLE [dbo].[tb_dom_activityType]  WITH CHECK ADD  CONSTRAINT [FK_tb_dom_activityType_tb_dom_entity] FOREIGN KEY([at_entity])
REFERENCES [dbo].[tb_dom_entity] ([entity_id])
GO
ALTER TABLE [dbo].[tb_dom_activityType] CHECK CONSTRAINT [FK_tb_dom_activityType_tb_dom_entity]
GO
ALTER TABLE [dbo].[tb_dom_file_type]  WITH CHECK ADD  CONSTRAINT [FK_tb_dom_file_type_tb_dom_entity] FOREIGN KEY([filetype_entity])
REFERENCES [dbo].[tb_dom_entity] ([entity_id])
GO
ALTER TABLE [dbo].[tb_dom_file_type] CHECK CONSTRAINT [FK_tb_dom_file_type_tb_dom_entity]
GO
ALTER TABLE [dbo].[tb_dom_legal_vehicle]  WITH CHECK ADD  CONSTRAINT [FK_tb_dom_legal_vehicle_tb_dom_legalType] FOREIGN KEY([lv_fk_legal_type])
REFERENCES [dbo].[tb_dom_legal_type] ([lt_id])
GO
ALTER TABLE [dbo].[tb_dom_legal_vehicle] CHECK CONSTRAINT [FK_tb_dom_legal_vehicle_tb_dom_legalType]
GO
ALTER TABLE [dbo].[tb_dom_timeseries_type]  WITH CHECK ADD  CONSTRAINT [FK_tb_dom_timeseries_type_tb_dom_entity] FOREIGN KEY([entity_type])
REFERENCES [dbo].[tb_dom_entity] ([entity_id])
GO
ALTER TABLE [dbo].[tb_dom_timeseries_type] CHECK CONSTRAINT [FK_tb_dom_timeseries_type_tb_dom_entity]
GO
ALTER TABLE [dbo].[tb_fundSubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_fundSubFund_tb_fund] FOREIGN KEY([f_id])
REFERENCES [dbo].[tb_fund] ([f_id])
GO
ALTER TABLE [dbo].[tb_fundSubFund] CHECK CONSTRAINT [FK_tb_fundSubFund_tb_fund]
GO
ALTER TABLE [dbo].[tb_fundSubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_fundSubFund_tb_subFund] FOREIGN KEY([sf_id])
REFERENCES [dbo].[tb_subFund] ([id_subFund])
GO
ALTER TABLE [dbo].[tb_fundSubFund] CHECK CONSTRAINT [FK_tb_fundSubFund_tb_subFund]
GO
ALTER TABLE [dbo].[tb_historyContract]  WITH CHECK ADD  CONSTRAINT [FK1_tb_historyContract] FOREIGN KEY([id_contract])
REFERENCES [dbo].[tb_contract] ([id_contract])
GO
ALTER TABLE [dbo].[tb_historyContract] CHECK CONSTRAINT [FK1_tb_historyContract]
GO
ALTER TABLE [dbo].[tb_historyFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyFund_tb_dom_companyType] FOREIGN KEY([f_company_type])
REFERENCES [dbo].[tb_dom_company_type] ([ct_id])
GO
ALTER TABLE [dbo].[tb_historyFund] CHECK CONSTRAINT [FK_tb_historyFund_tb_dom_companyType]
GO
ALTER TABLE [dbo].[tb_historyFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyFund_tb_dom_f_status] FOREIGN KEY([f_status])
REFERENCES [dbo].[tb_dom_f_status] ([st_f_id])
GO
ALTER TABLE [dbo].[tb_historyFund] CHECK CONSTRAINT [FK_tb_historyFund_tb_dom_f_status]
GO
ALTER TABLE [dbo].[tb_historyFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyFund_tb_dom_fund_admin_type] FOREIGN KEY([f_fund_admin])
REFERENCES [dbo].[tb_dom_fund_admin_type] ([fat_id])
GO
ALTER TABLE [dbo].[tb_historyFund] CHECK CONSTRAINT [FK_tb_historyFund_tb_dom_fund_admin_type]
GO
ALTER TABLE [dbo].[tb_historyFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyFund_tb_dom_legal_form] FOREIGN KEY([f_legal_form])
REFERENCES [dbo].[tb_dom_legal_form] ([lf_id])
GO
ALTER TABLE [dbo].[tb_historyFund] CHECK CONSTRAINT [FK_tb_historyFund_tb_dom_legal_form]
GO
ALTER TABLE [dbo].[tb_historyFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyFund_tb_dom_legal_vehicle] FOREIGN KEY([f_legal_vehicle])
REFERENCES [dbo].[tb_dom_legal_vehicle] ([lv_id])
GO
ALTER TABLE [dbo].[tb_historyFund] CHECK CONSTRAINT [FK_tb_historyFund_tb_dom_legal_vehicle]
GO
ALTER TABLE [dbo].[tb_historyFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyFund_tb_fund] FOREIGN KEY([f_id])
REFERENCES [dbo].[tb_fund] ([f_id])
GO
ALTER TABLE [dbo].[tb_historyFund] CHECK CONSTRAINT [FK_tb_historyFund_tb_fund]
GO
ALTER TABLE [dbo].[tb_historyInvAccount]  WITH CHECK ADD  CONSTRAINT [FK1_tb_historyInvAccount] FOREIGN KEY([id_invAccount])
REFERENCES [dbo].[tb_investorAccount] ([id_invAccount])
GO
ALTER TABLE [dbo].[tb_historyInvAccount] CHECK CONSTRAINT [FK1_tb_historyInvAccount]
GO
ALTER TABLE [dbo].[tb_historyInvestor]  WITH CHECK ADD  CONSTRAINT [FK1_tb_historyInvestor] FOREIGN KEY([id_inv])
REFERENCES [dbo].[tb_investor] ([id_inv])
GO
ALTER TABLE [dbo].[tb_historyInvestor] CHECK CONSTRAINT [FK1_tb_historyInvestor]
GO
ALTER TABLE [dbo].[tb_historyShareClass]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyShareClass_tb_dom_investor_type] FOREIGN KEY([sc_investorType])
REFERENCES [dbo].[tb_dom_investor_type] ([it_id])
GO
ALTER TABLE [dbo].[tb_historyShareClass] CHECK CONSTRAINT [FK_tb_historyShareClass_tb_dom_investor_type]
GO
ALTER TABLE [dbo].[tb_historyShareClass]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyShareClass_tb_dom_iso_country] FOREIGN KEY([sc_countryIssue])
REFERENCES [dbo].[tb_dom_iso_country] ([iso_country_iso_2])
GO
ALTER TABLE [dbo].[tb_historyShareClass] CHECK CONSTRAINT [FK_tb_historyShareClass_tb_dom_iso_country]
GO
ALTER TABLE [dbo].[tb_historyShareClass]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyShareClass_tb_dom_iso_currency] FOREIGN KEY([sc_currency])
REFERENCES [dbo].[tb_dom_iso_currency] ([iso_ccy_code])
GO
ALTER TABLE [dbo].[tb_historyShareClass] CHECK CONSTRAINT [FK_tb_historyShareClass_tb_dom_iso_currency]
GO
ALTER TABLE [dbo].[tb_historyShareClass]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyShareClass_tb_dom_share_status] FOREIGN KEY([sc_status])
REFERENCES [dbo].[tb_dom_share_status] ([sc_s_id])
GO
ALTER TABLE [dbo].[tb_historyShareClass] CHECK CONSTRAINT [FK_tb_historyShareClass_tb_dom_share_status]
GO
ALTER TABLE [dbo].[tb_historyShareClass]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyShareClass_tb_dom_share_type] FOREIGN KEY([sc_shareType])
REFERENCES [dbo].[tb_dom_share_type] ([st_id])
GO
ALTER TABLE [dbo].[tb_historyShareClass] CHECK CONSTRAINT [FK_tb_historyShareClass_tb_dom_share_type]
GO
ALTER TABLE [dbo].[tb_historyShareClass]  WITH CHECK ADD  CONSTRAINT [FK_tb_historyShareClass_tb_shareClass] FOREIGN KEY([sc_id])
REFERENCES [dbo].[tb_shareClass] ([id_sc])
GO
ALTER TABLE [dbo].[tb_historyShareClass] CHECK CONSTRAINT [FK_tb_historyShareClass_tb_shareClass]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_calculationDate] FOREIGN KEY([sf_calculationDate])
REFERENCES [dbo].[tb_dom_calculationDate] ([cd_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_calculationDate]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_cesrClass] FOREIGN KEY([sf_cesrClass])
REFERENCES [dbo].[tb_dom_cesrClass] ([cc_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_cesrClass]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_cssf_geographical_focus] FOREIGN KEY([sf_cssf_geographical_focus])
REFERENCES [dbo].[tb_dom_cssf_geographical_focus] ([gf_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_cssf_geographical_focus]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_cssf_principal_asset_class] FOREIGN KEY([sf_principal_asset_class])
REFERENCES [dbo].[tb_dom_cssf_principal_asset_class] ([pac_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_cssf_principal_asset_class]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_derivMarket] FOREIGN KEY([sf_derivMarket])
REFERENCES [dbo].[tb_dom_derivMarket] ([dm_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_derivMarket]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_derivPurpose] FOREIGN KEY([sf_derivPurpose])
REFERENCES [dbo].[tb_dom_derivPurpose] ([dp_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_derivPurpose]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_globalExposure] FOREIGN KEY([sf_globalExposure])
REFERENCES [dbo].[tb_dom_globalExposure] ([ge_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_globalExposure]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_iso_currency] FOREIGN KEY([sf_currency])
REFERENCES [dbo].[tb_dom_iso_currency] ([iso_ccy_code])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_iso_currency]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_navFrequency] FOREIGN KEY([sf_navFrequency])
REFERENCES [dbo].[tb_dom_navFrequency] ([nf_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_navFrequency]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_principal_investment_strategy] FOREIGN KEY([sf_principal_investment_strategy])
REFERENCES [dbo].[tb_dom_principal_investment_strategy] ([pis_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_principal_investment_strategy]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_sf_cat_bloomberg] FOREIGN KEY([sf_category_bloomberg])
REFERENCES [dbo].[tb_dom_sf_cat_bloomberg] ([cat_bloomberg_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_sf_cat_bloomberg]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_sf_cat_morningstar] FOREIGN KEY([sf_cat_morningstar])
REFERENCES [dbo].[tb_dom_sf_cat_morningstar] ([c_morningstar_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_sf_cat_morningstar]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_sf_cat_six] FOREIGN KEY([sf_category_six])
REFERENCES [dbo].[tb_dom_sf_cat_six] ([cat_six_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_sf_cat_six]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_type_of_market] FOREIGN KEY([sf_type_of_market])
REFERENCES [dbo].[tb_dom_type_of_market] ([tom_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_type_of_market]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_dom_valutationDate] FOREIGN KEY([sf_valutationDate])
REFERENCES [dbo].[tb_dom_valutationDate] ([vd_id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_dom_valutationDate]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_subFund] FOREIGN KEY([sf_status])
REFERENCES [dbo].[tb_dom_sf_status] ([st_id])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_subFund]
GO
ALTER TABLE [dbo].[tb_historySubFund]  WITH CHECK ADD  CONSTRAINT [FK_tb_historySubFund_tb_subFund1] FOREIGN KEY([sf_id])
REFERENCES [dbo].[tb_subFund] ([id_subFund])
GO
ALTER TABLE [dbo].[tb_historySubFund] CHECK CONSTRAINT [FK_tb_historySubFund_tb_subFund1]
GO
ALTER TABLE [dbo].[tb_invInvAccount]  WITH CHECK ADD  CONSTRAINT [FK1_tb_invInvAccount] FOREIGN KEY([id_inv])
REFERENCES [dbo].[tb_investor] ([id_inv])
GO
ALTER TABLE [dbo].[tb_invInvAccount] CHECK CONSTRAINT [FK1_tb_invInvAccount]
GO
ALTER TABLE [dbo].[tb_invInvAccount]  WITH CHECK ADD  CONSTRAINT [FK2_tb_invInvAccount] FOREIGN KEY([id_invAccount])
REFERENCES [dbo].[tb_investorAccount] ([id_invAccount])
GO
ALTER TABLE [dbo].[tb_invInvAccount] CHECK CONSTRAINT [FK2_tb_invInvAccount]
GO
ALTER TABLE [dbo].[tb_invInvAccShareClass]  WITH CHECK ADD  CONSTRAINT [FK1_tb_invInvAccShareClass] FOREIGN KEY([id_inv])
REFERENCES [dbo].[tb_investor] ([id_inv])
GO
ALTER TABLE [dbo].[tb_invInvAccShareClass] CHECK CONSTRAINT [FK1_tb_invInvAccShareClass]
GO
ALTER TABLE [dbo].[tb_invInvAccShareClass]  WITH CHECK ADD  CONSTRAINT [FK2_invInvAccShareClass] FOREIGN KEY([id_invAccount])
REFERENCES [dbo].[tb_investorAccount] ([id_invAccount])
GO
ALTER TABLE [dbo].[tb_invInvAccShareClass] CHECK CONSTRAINT [FK2_invInvAccShareClass]
GO
ALTER TABLE [dbo].[tb_invInvAccShareClass]  WITH CHECK ADD  CONSTRAINT [FK3_invInvAccShareClass] FOREIGN KEY([id_shareClass])
REFERENCES [dbo].[tb_shareClass] ([id_sc])
GO
ALTER TABLE [dbo].[tb_invInvAccShareClass] CHECK CONSTRAINT [FK3_invInvAccShareClass]
GO
ALTER TABLE [dbo].[tb_map_filefund]  WITH CHECK ADD  CONSTRAINT [FK_tb_map_filefund_tb_dom_file_type] FOREIGN KEY([doc_filetype])
REFERENCES [dbo].[tb_dom_file_type] ([filetype_id])
GO
ALTER TABLE [dbo].[tb_map_filefund] CHECK CONSTRAINT [FK_tb_map_filefund_tb_dom_file_type]
GO
ALTER TABLE [dbo].[tb_map_filefund]  WITH CHECK ADD  CONSTRAINT [FK_tb_map_filefund_tb_file] FOREIGN KEY([file_id])
REFERENCES [dbo].[tb_file] ([file_id])
GO
ALTER TABLE [dbo].[tb_map_filefund] CHECK CONSTRAINT [FK_tb_map_filefund_tb_file]
GO
ALTER TABLE [dbo].[tb_map_filefund]  WITH CHECK ADD  CONSTRAINT [FK_tb_map_filefund_tb_fund] FOREIGN KEY([doc_fundId])
REFERENCES [dbo].[tb_fund] ([f_id])
GO
ALTER TABLE [dbo].[tb_map_filefund] CHECK CONSTRAINT [FK_tb_map_filefund_tb_fund]
GO
ALTER TABLE [dbo].[tb_map_fileshareclass]  WITH CHECK ADD  CONSTRAINT [FK_tb_map_fileshareclass_tb_dom_file_type] FOREIGN KEY([doc_filetype])
REFERENCES [dbo].[tb_dom_file_type] ([filetype_id])
GO
ALTER TABLE [dbo].[tb_map_fileshareclass] CHECK CONSTRAINT [FK_tb_map_fileshareclass_tb_dom_file_type]
GO
ALTER TABLE [dbo].[tb_map_fileshareclass]  WITH CHECK ADD  CONSTRAINT [FK_tb_map_fileshareclass_tb_file] FOREIGN KEY([file_id])
REFERENCES [dbo].[tb_file] ([file_id])
GO
ALTER TABLE [dbo].[tb_map_fileshareclass] CHECK CONSTRAINT [FK_tb_map_fileshareclass_tb_file]
GO
ALTER TABLE [dbo].[tb_map_fileshareclass]  WITH CHECK ADD  CONSTRAINT [FK_tb_map_fileshareclass_tb_shareClass] FOREIGN KEY([doc_shareClassId])
REFERENCES [dbo].[tb_shareClass] ([id_sc])
GO
ALTER TABLE [dbo].[tb_map_fileshareclass] CHECK CONSTRAINT [FK_tb_map_fileshareclass_tb_shareClass]
GO
ALTER TABLE [dbo].[tb_map_filesubfund]  WITH CHECK ADD  CONSTRAINT [FK_tb_map_filesubfund_tb_dom_file_type] FOREIGN KEY([doc_filetype])
REFERENCES [dbo].[tb_dom_file_type] ([filetype_id])
GO
ALTER TABLE [dbo].[tb_map_filesubfund] CHECK CONSTRAINT [FK_tb_map_filesubfund_tb_dom_file_type]
GO
ALTER TABLE [dbo].[tb_map_filesubfund]  WITH CHECK ADD  CONSTRAINT [FK_tb_map_filesubfund_tb_file] FOREIGN KEY([file_id])
REFERENCES [dbo].[tb_file] ([file_id])
GO
ALTER TABLE [dbo].[tb_map_filesubfund] CHECK CONSTRAINT [FK_tb_map_filesubfund_tb_file]
GO
ALTER TABLE [dbo].[tb_map_filesubfund]  WITH CHECK ADD  CONSTRAINT [FK_tb_map_filesubfund_tb_subFund] FOREIGN KEY([doc_subfundId])
REFERENCES [dbo].[tb_subFund] ([id_subFund])
GO
ALTER TABLE [dbo].[tb_map_filesubfund] CHECK CONSTRAINT [FK_tb_map_filesubfund_tb_subFund]
GO
ALTER TABLE [dbo].[tb_map_nav_frequency_valuation]  WITH CHECK ADD  CONSTRAINT [FK_tb_map_nav_frequency_valuation_tb_dom_navFrequency] FOREIGN KEY([id_dom_freq])
REFERENCES [dbo].[tb_dom_navFrequency] ([nf_id])
GO
ALTER TABLE [dbo].[tb_map_nav_frequency_valuation] CHECK CONSTRAINT [FK_tb_map_nav_frequency_valuation_tb_dom_navFrequency]
GO
ALTER TABLE [dbo].[tb_map_nav_frequency_valuation]  WITH CHECK ADD  CONSTRAINT [FK_tb_map_nav_frequency_valuation_tb_dom_valutationDate] FOREIGN KEY([id_dom_val_date])
REFERENCES [dbo].[tb_dom_valutationDate] ([vd_id])
GO
ALTER TABLE [dbo].[tb_map_nav_frequency_valuation] CHECK CONSTRAINT [FK_tb_map_nav_frequency_valuation_tb_dom_valutationDate]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund]  WITH CHECK ADD  CONSTRAINT [ FK_tb_serviceAgreement_fund_tb_dom_agreement_status] FOREIGN KEY([sa_status])
REFERENCES [dbo].[tb_dom_agreement_status] ([a_s_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund] CHECK CONSTRAINT [ FK_tb_serviceAgreement_fund_tb_dom_agreement_status]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_fund_tb_companies] FOREIGN KEY([sa_company])
REFERENCES [dbo].[tb_companies] ([c_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund] CHECK CONSTRAINT [FK_tb_serviceAgreement_fund_tb_companies]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_fund_tb_dom_activityType] FOREIGN KEY([sa_activityType])
REFERENCES [dbo].[tb_dom_activityType] ([at_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund] CHECK CONSTRAINT [FK_tb_serviceAgreement_fund_tb_dom_activityType]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_fund_tb_file] FOREIGN KEY([file_id])
REFERENCES [dbo].[tb_file] ([file_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund] CHECK CONSTRAINT [FK_tb_serviceAgreement_fund_tb_file]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_fund_tb_fund] FOREIGN KEY([sa_fundId])
REFERENCES [dbo].[tb_fund] ([f_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund] CHECK CONSTRAINT [FK_tb_serviceAgreement_fund_tb_fund]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_shareclass_tb_companies] FOREIGN KEY([sa_company])
REFERENCES [dbo].[tb_companies] ([c_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass] CHECK CONSTRAINT [FK_tb_serviceAgreement_shareclass_tb_companies]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_shareclass_tb_dom_activityType] FOREIGN KEY([sa_activityType])
REFERENCES [dbo].[tb_dom_activityType] ([at_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass] CHECK CONSTRAINT [FK_tb_serviceAgreement_shareclass_tb_dom_activityType]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_shareclass_tb_dom_agreement_status] FOREIGN KEY([sa_status])
REFERENCES [dbo].[tb_dom_agreement_status] ([a_s_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass] CHECK CONSTRAINT [FK_tb_serviceAgreement_shareclass_tb_dom_agreement_status]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_shareclass_tb_file] FOREIGN KEY([file_id])
REFERENCES [dbo].[tb_file] ([file_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass] CHECK CONSTRAINT [FK_tb_serviceAgreement_shareclass_tb_file]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_shareclass_tb_shareClass] FOREIGN KEY([sa_shareclassId])
REFERENCES [dbo].[tb_shareClass] ([id_sc])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass] CHECK CONSTRAINT [FK_tb_serviceAgreement_shareclass_tb_shareClass]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_subfund_tb_companies] FOREIGN KEY([sa_company])
REFERENCES [dbo].[tb_companies] ([c_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund] CHECK CONSTRAINT [FK_tb_serviceAgreement_subfund_tb_companies]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_subfund_tb_dom_activityType] FOREIGN KEY([sa_activityType])
REFERENCES [dbo].[tb_dom_activityType] ([at_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund] CHECK CONSTRAINT [FK_tb_serviceAgreement_subfund_tb_dom_activityType]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_subfund_tb_dom_agreement_status] FOREIGN KEY([sa_status])
REFERENCES [dbo].[tb_dom_agreement_status] ([a_s_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund] CHECK CONSTRAINT [FK_tb_serviceAgreement_subfund_tb_dom_agreement_status]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_subfund_tb_file] FOREIGN KEY([file_id])
REFERENCES [dbo].[tb_file] ([file_id])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund] CHECK CONSTRAINT [FK_tb_serviceAgreement_subfund_tb_file]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund]  WITH CHECK ADD  CONSTRAINT [FK_tb_serviceAgreement_subfund_tb_subFund] FOREIGN KEY([sa_subfundId])
REFERENCES [dbo].[tb_subFund] ([id_subFund])
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund] CHECK CONSTRAINT [FK_tb_serviceAgreement_subfund_tb_subFund]
GO
ALTER TABLE [dbo].[tb_shareclass_ts_test]  WITH NOCHECK ADD  CONSTRAINT [FK_tb_timeseries_test_tb_dom_iso_currency] FOREIGN KEY([currency_ts])
REFERENCES [dbo].[tb_dom_iso_currency] ([iso_ccy_code])
GO
ALTER TABLE [dbo].[tb_shareclass_ts_test] CHECK CONSTRAINT [FK_tb_timeseries_test_tb_dom_iso_currency]
GO
ALTER TABLE [dbo].[tb_shareclass_ts_test]  WITH NOCHECK ADD  CONSTRAINT [FK_tb_timeseries_test_tb_dom_timeseries_type] FOREIGN KEY([id_ts])
REFERENCES [dbo].[tb_dom_timeseries_type] ([id_ts])
GO
ALTER TABLE [dbo].[tb_shareclass_ts_test] CHECK CONSTRAINT [FK_tb_timeseries_test_tb_dom_timeseries_type]
GO
ALTER TABLE [dbo].[tb_shareclass_ts_test]  WITH NOCHECK ADD  CONSTRAINT [FK_tb_timeseries_test_tb_dom_ts_provider] FOREIGN KEY([provider_ts])
REFERENCES [dbo].[tb_dom_timeseries_provider] ([id_provider])
GO
ALTER TABLE [dbo].[tb_shareclass_ts_test] CHECK CONSTRAINT [FK_tb_timeseries_test_tb_dom_ts_provider]
GO
ALTER TABLE [dbo].[tb_shareclass_ts_test]  WITH NOCHECK ADD  CONSTRAINT [FK_tb_timeseries_test_tb_shareClass] FOREIGN KEY([id_shareclass])
REFERENCES [dbo].[tb_shareClass] ([id_sc])
GO
ALTER TABLE [dbo].[tb_shareclass_ts_test] CHECK CONSTRAINT [FK_tb_timeseries_test_tb_shareClass]
GO
ALTER TABLE [dbo].[tb_subFundShareClass]  WITH CHECK ADD  CONSTRAINT [FK_tb_subFundShareClass_tb_shareClass] FOREIGN KEY([sc_id])
REFERENCES [dbo].[tb_shareClass] ([id_sc])
GO
ALTER TABLE [dbo].[tb_subFundShareClass] CHECK CONSTRAINT [FK_tb_subFundShareClass_tb_shareClass]
GO
ALTER TABLE [dbo].[tb_subFundShareClass]  WITH CHECK ADD  CONSTRAINT [FK_tb_subFundShareClass_tb_subFund] FOREIGN KEY([sf_id])
REFERENCES [dbo].[tb_subFund] ([id_subFund])
GO
ALTER TABLE [dbo].[tb_subFundShareClass] CHECK CONSTRAINT [FK_tb_subFundShareClass_tb_subFund]
GO
ALTER TABLE [dbo].[tb_map_filefund]  WITH CHECK ADD  CONSTRAINT [CK_tb_map_filefund] CHECK  (([dbo].[fn_filetypeAllowed]([doc_filetype],(1))=(1)))
GO
ALTER TABLE [dbo].[tb_map_filefund] CHECK CONSTRAINT [CK_tb_map_filefund]
GO
ALTER TABLE [dbo].[tb_map_fileshareclass]  WITH CHECK ADD  CONSTRAINT [CK_tb_map_fileshareclass] CHECK  (([dbo].[fn_filetypeAllowed]([doc_filetype],(3))=(1)))
GO
ALTER TABLE [dbo].[tb_map_fileshareclass] CHECK CONSTRAINT [CK_tb_map_fileshareclass]
GO
ALTER TABLE [dbo].[tb_map_filesubfund]  WITH CHECK ADD  CONSTRAINT [CK_tb_map_filesubfund] CHECK  (([dbo].[fn_filetypeAllowed]([doc_filetype],(2))=(1)))
GO
ALTER TABLE [dbo].[tb_map_filesubfund] CHECK CONSTRAINT [CK_tb_map_filesubfund]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund]  WITH CHECK ADD  CONSTRAINT [CK_tb_serviceAgreement_fund] CHECK  (([dbo].[fn_AgreementtypeAllowed]([sa_activityType],(1))=(1)))
GO
ALTER TABLE [dbo].[tb_serviceAgreement_fund] CHECK CONSTRAINT [CK_tb_serviceAgreement_fund]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass]  WITH CHECK ADD  CONSTRAINT [CK_tb_serviceAgreement_shareclass] CHECK  (([dbo].[fn_AgreementtypeAllowed]([sa_activityType],(3))=(1)))
GO
ALTER TABLE [dbo].[tb_serviceAgreement_shareclass] CHECK CONSTRAINT [CK_tb_serviceAgreement_shareclass]
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund]  WITH CHECK ADD  CONSTRAINT [CK_tb_serviceAgreement_subfund] CHECK  (([dbo].[fn_AgreementtypeAllowed]([sa_activityType],(2))=(1)))
GO
ALTER TABLE [dbo].[tb_serviceAgreement_subfund] CHECK CONSTRAINT [CK_tb_serviceAgreement_subfund]
GO
/****** Object:  StoredProcedure [dbo].[delete_agreement_fundfile_byid]    Script Date: 10-Jan-21 11:24:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delete_agreement_fundfile_byid]

@file_id as int

AS
BEGIN

delete from [dbo].[tb_serviceAgreement_fund] where [file_id]=@file_id
delete from [dbo].[tb_file] where [file_id]=@file_id

END
GO
/****** Object:  StoredProcedure [dbo].[delete_fund_file_byid]    Script Date: 10-Jan-21 11:24:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[delete_fund_file_byid]

@file_id as int

AS
BEGIN

delete from [dbo].[tb_map_filefund] where [file_id]=@file_id
delete from [dbo].[tb_file] where [file_id]=@file_id

END
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_agreement_fund]    Script Date: 10-Jan-21 11:24:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_insert_agreement_fund]

	@file_name as nvarchar(MAX),
	@entity_id as int,
	@file_ext as nvarchar(10),
	@activity_type_id as int,
	@contract_date as date,
	@activation_date as date,
	@expiration_date as date null,
	@company_id as int,
	@status as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @id_newfile int
	set @id_newfile =(select max(file_id)+1 from tb_file)

	--checking if a file with same filtype, same time period and same fund id is already present (cannot be inserted a prospectus for the same fund at the same time period unless we delete the previous)


    IF (@expiration_date IS NULL)
    SET @expiration_date = '29991231'

	declare @check1 int
	set @check1 = (
	   select  ISNULL(count([file_id]),0)
       from tb_serviceAgreement_fund where
       sa_fundId=@entity_id and 
       sa_activityType=@activity_type_id
       and ((sa_expirationDate>=@expiration_date or sa_expirationDate is null)
                     or (sa_activationDate<=@expiration_date))	
	)
	
	BEGIN TRANSACTION;

		BEGIN TRY
      		If(@check1=0)
			  BEGIN

                                 INSERT INTO [dbo].[tb_file] (file_id) values (@id_newfile)

				 INSERT INTO [dbo].[tb_serviceAgreement_fund] 
				 VALUES (@id_newfile, @file_name, @file_ext, @entity_id, @activity_type_id, @contract_date, @activation_date, @expiration_date, @status, @company_id)
	         END
                 ELSE 
                        BEGIN
                             Throw 60000,'Count is higher than 0. Check ids and dates.',5   
                        END
		COMMIT TRANSACTION;

		END TRY

	BEGIN CATCH
		DECLARE @SQLErrorMessage nvarchar(2048);
                SET @SQLErrorMessage = ERROR_MESSAGE();
                RAISERROR (@SQLErrorMessage, 16, 1);
                ROLLBACK TRANSACTION;
	END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insert_document_fund]    Script Date: 10-Jan-21 11:24:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_insert_document_fund]

	@file_name as nvarchar(MAX),
	@entity_id as int,
	@start_connection as date,
	@end_connection as date null,
	@file_ext as nvarchar(10),
	@filetype_id as int
AS
BEGIN
	declare @check1 int
	set @check1 = (
	select ISNULL(count([file_id]),0) 
	from [dbo].[tb_map_filefund] 
	where doc_fundId=@entity_id  and 
	(@start_connection>=doc_startConnection and (@start_connection<=doc_endConnection or doc_endConnection is null))
	and doc_filetype=@filetype_id)

        -- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @id_newfile int
	set @id_newfile =(select max(file_id)+1 from tb_file)


	BEGIN TRANSACTION

		BEGIN TRY
			IF(@check1=0)
				BEGIN
                                        INSERT INTO [dbo].[tb_file] (file_id) values (@id_newfile)

					INSERT INTO [dbo].[tb_map_filefund] 
					VALUES (@id_newfile, @file_name, @file_ext, @entity_id, @start_connection, @end_connection, @filetype_id)
				END

                       ELSE 
                              BEGIN
                              Throw 60000,'Count is higher than 0. Check ids and dates.',5  
                              END
		       COMMIT TRANSACTION;			
		END TRY

	BEGIN CATCH
		DECLARE @SQLErrorMessage nvarchar(2048)
                SET @SQLErrorMessage = ERROR_MESSAGE()
                RAISERROR (@SQLErrorMessage, 16, 1)
                ROLLBACK TRANSACTION;
	END CATCH;
END
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_modify_shareclass] 
  @sc_initialDate datetime
,@sc_officialShareClassName nvarchar(100)
,@sc_investorType int null
,@sc_shareType int null
,@sc_currency nchar(3)
,@sc_countryIssue nchar(2) null
,@sc_ultimateParentCountryRisk nchar(2) null
,@sc_emissionDate datetime null
,@sc_inceptionDate datetime null
,@sc_lastNav datetime null
,@sc_expiryDate datetime null
,@sc_status int
,@sc_initialPrice float null
,@sc_accountingCode nvarchar(100) null
,@sc_hedged bit null
,@sc_listed bit null
,@sc_bloomberMarket nvarchar(100) null
,@sc_bloombedCode nvarchar(100) null
,@sc_bloombedId nvarchar(100) null
,@sc_isinCode nchar(12) null
,@sc_valorCode nvarchar(100) null
,@sc_faCode nvarchar(100)
,@sc_taCode nvarchar(100) null
,@sc_WKN nvarchar(100) null
,@sc_date_business_year datetime null
,@sc_prospectus_code nvarchar(100) null
,@sc_id int
,@comment nvarchar(MAX) null
,@comment_title nvarchar(50)
  
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Checking if the shareclass is present ( just one row with end date = null)
	declare @checkshareclass1 int
	set @checkshareclass1 = (select count(@sc_id) from [dbo].[tb_historyShareClass] h where h.sc_id=@sc_id and h.sc_endDate is null )

BEGIN TRANSACTION;

BEGIN TRY
      
	  IF
	    --Check null values
		(@checkshareclass1=1) and
	    (@sc_initialDate is not null) and 
		(@sc_status  is not null) and (@sc_officialShareClassName  is not null) and
		(@sc_faCode  is not null) 		
		

	  BEGIN
		-- Updating previous value with end date one day before new value
		update [tb_historyShareClass] set [sc_endDate]= DATEADD(day,-1,@sc_initialDate), [sc_change_comment]=@comment, [sc_comment_title]=@comment_title where [tb_historyShareClass].sc_id=@sc_id and [tb_historyShareClass].sc_endDate is null

insert into [tb_historyShareClass] (
		 [sc_id]
		,[sc_initialDate]
		,[sc_endDate]
		,[sc_officialShareClassName]
		,[sc_shortShareClassName]
		,[sc_investorType]
		,[sc_shareType]
		,[sc_currency]
		,[sc_countryIssue]
		,[sc_ultimateParentCountryRisk]
		,[sc_emissionDate]
		,[sc_inceptionDate]
		,[sc_lastNav]
		,[sc_expiryDate]
		,[sc_status]
		,[sc_initialPrice]
		,[sc_accountingCode]
		,[sc_hedged]
		,[sc_listed]
		,[sc_bloomberMarket]
		,[sc_bloombedCode]
		,[sc_bloombedId]
		,[sc_isinCode]
		,[sc_valorCode]
		,[sc_faCode]
		,[sc_taCode]
		,[sc_WKN]
		,[sc_date_business_year]
		,[sc_prospectus_code]
		,[sc_change_comment]
		,[sc_comment_title])

		values(
		 @sc_id
	    ,@sc_initialDate 
		,null
		,@sc_officialShareClassName 
		,@sc_officialShareClassName 
		,@sc_investorType 
		,@sc_shareType 
		,@sc_currency 
		,@sc_countryIssue 
		,@sc_ultimateParentCountryRisk 
		,@sc_emissionDate 
		,@sc_inceptionDate 
		,@sc_lastNav 
		,@sc_expiryDate 
		,@sc_status 
		,@sc_initialPrice 
		,@sc_accountingCode 
		,@sc_hedged 
		,@sc_listed 
		,@sc_bloomberMarket 
		,@sc_bloombedCode 
		,@sc_bloombedId 
		,@sc_isinCode 
		,@sc_valorCode 
		,@sc_faCode 
		,@sc_taCode 
		,@sc_WKN 
		,@sc_date_business_year 
		,@sc_prospectus_code 
		,@comment 
		,@comment_title
		)

-- modifyng all the files in the table in order to end the validity of documents
		 update [dbo].[tb_map_fileshareclass] set doc_endConnection=DATEADD(day,-1,@sc_initialDate) where doc_shareclassId=@sc_id and doc_endConnection is null

	   END

ELSE 
                              BEGIN
                              Throw 60000,'Check not passing',5  
                              END

    COMMIT TRANSACTION;
END TRY

BEGIN CATCH
	DECLARE @SQLErrorMessage nvarchar(2048);
        SET @SQLErrorMessage = ERROR_MESSAGE();
        RAISERROR (@SQLErrorMessage, 16, 1);
        ROLLBACK TRANSACTION;
END CATCH;

END



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_new_shareclass]

@sc_initialDate datetime
,@sc_officialShareClassName nvarchar(100)
,@sc_investorType int null
,@sc_shareType int null
,@sc_currency nchar(3)
,@sc_countryIssue nchar(2) null
,@sc_ultimateParentCountryRisk nchar(2) null
,@sc_emissionDate datetime null
,@sc_inceptionDate datetime null
,@sc_lastNav datetime null
,@sc_expiryDate datetime null
,@sc_status int
,@sc_initialPrice float null
,@sc_accountingCode nvarchar(100) null
,@sc_hedged bit null
,@sc_listed bit null
,@sc_bloomberMarket nvarchar(100) null
,@sc_bloombedCode nvarchar(100) null
,@sc_bloombedId nvarchar(100) null
,@sc_isinCode nchar(12) null
,@sc_valorCode nvarchar(100) null
,@sc_faCode nvarchar(100) 
,@sc_taCode nvarchar(100) null
,@sc_WKN nvarchar(100) null
,@sc_date_business_year datetime null
,@sc_prospectus_code nvarchar(100) null

-- for connection subfund-shareclass
,@subfundcontainer as int
,@sc_endDate datetime null

 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @id_newshareclass int
	set @id_newshareclass =(select max([id_sc])+1 from [dbo].[tb_shareclass])

	
BEGIN TRANSACTION;

BEGIN TRY
      
	  IF
	    --Check null values
	    (@sc_initialDate is not null) and  (@id_newshareclass is not null) and 
		(@sc_status  is not null) and (@sc_officialShareClassName  is not null) and
        (@sc_faCode  is not null) and (@subfundcontainer  is not null)	
		

	  BEGIN

			insert into [tb_shareclass] ([id_sc]) values (@id_newshareclass)

			INSERT INTO [dbo].[tb_historyShareClass]
           ([sc_id]
           ,[sc_initialDate]
           ,[sc_endDate]
           ,[sc_officialShareClassName]
           ,[sc_shortShareClassName]
           ,[sc_investorType]
           ,[sc_shareType]
           ,[sc_currency]
           ,[sc_countryIssue]
           ,[sc_ultimateParentCountryRisk]
           ,[sc_emissionDate]
           ,[sc_inceptionDate]
           ,[sc_lastNav]
           ,[sc_expiryDate]
           ,[sc_status]
           ,[sc_initialPrice]
           ,[sc_accountingCode]
           ,[sc_hedged]
           ,[sc_listed]
           ,[sc_bloomberMarket]
           ,[sc_bloombedCode]
           ,[sc_bloombedId]
           ,[sc_isinCode]
           ,[sc_valorCode]
           ,[sc_faCode]
           ,[sc_taCode]
           ,[sc_WKN]
           ,[sc_date_business_year]
           ,[sc_prospectus_code]
           ,[sc_change_comment]
           ,[sc_comment_title])
     VALUES (
			 @id_newshareclass
			,@sc_initialDate
			,@sc_endDate
			,@sc_officialShareClassName
			,@sc_officialShareClassName
			,@sc_investorType
			,@sc_shareType
			,@sc_currency
			,@sc_countryIssue
			,@sc_ultimateParentCountryRisk
			,@sc_emissionDate
			,@sc_inceptionDate
			,@sc_lastNav
			,@sc_expiryDate
			,@sc_status
			,@sc_initialPrice
			,@sc_accountingCode
			,@sc_hedged
			,@sc_listed
			,@sc_bloomberMarket
			,@sc_bloombedCode
			,@sc_bloombedId
			,@sc_isinCode
			,@sc_valorCode
			,@sc_faCode
			,@sc_taCode
			,@sc_WKN
			,@sc_date_business_year
			,@sc_prospectus_code			
			,null
			,null
			)
	   -- for connection fund-subfund
			insert into [dbo].[tb_subFundShareClass] values(@id_newshareclass,@subfundcontainer,@sc_initialDate,@sc_endDate)
	   END

ELSE 
                              BEGIN
                              Throw 60000,'Check not passing',5  
                              END

    COMMIT TRANSACTION;
END TRY

BEGIN CATCH
        DECLARE @SQLErrorMessage nvarchar(2048);
        SET @SQLErrorMessage = ERROR_MESSAGE();
        RAISERROR (@SQLErrorMessage, 16, 1);
        ROLLBACK TRANSACTION;
END CATCH;



END

GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_active_fund_subfunds]
(	
 @report_date as date,
 @fund_id as int
)
RETURNS TABLE 
AS
RETURN 
(
SELECT top(100)
 [ID]
,[VALID FROM]
, case
	when [VALID UNTIL] is null then 'STILL VALID'
	else [VALID UNTIL] end as [VALID UNTIL]
, [SUB FUND NAME]
, [STATUS]
, [CSSF CODE]
, [ADMIN CODE]
, [DEPOSITARY BANK CODE]
, [TRANSFER AGENT CODE]
, [FIRST NAV DATE]
, [LAST NAV DATE]
, [CSSF AUTH. DATE]
, [EXPIRY DATE]
,[LEI CODE]
,[CESR CLASS]
,[GEO FOCUS]
,[GLOBAL EXPOSURE]
,[CURRENCY]
,[FREQUENCY]
,[VALUATION DATE]
,[CALCULATION DATE]
,[DERIVATIVES]
,[DERIV. MARKET]
,[DERIV. PURPOSE]
,[PRINCIPAL ASSET CLASS]
,[MARKET TYPE]
,[PRINCIPAL INVESTMENT STRATEGY]
,[CLEARING CODE]
,[MORNINGSTAR CATEGORY]
,[SIX CATEGORY]
,[BLOOMBERG CATEGORY]	
FROM ( 
	SELECT f.f_id, f.f_official_fund_name
	FROM [dbo].tb_historyFund f 
	Where (@report_date between f.f_initial_date and f.f_end_date OR (@report_date >= f.f_initial_date and f.f_end_date is null)) ) t1 
	JOIN ( 
			SELECT fsf.sf_id, fsf.fsf_startConnection, fsf.fsf_endConnection, fsf.f_id 
			FROM [dbo].tb_fundSubFund fsf 
			Where 
				(@report_date between fsf.fsf_startConnection and fsf.fsf_endConnection OR (@report_date >= fsf.fsf_startConnection and fsf.fsf_endConnection is null)) 
		 ) t2  ON t1.f_id = t2.f_id and t1.f_id=@fund_id
	
	JOIN ( 
			SELECT  
 sf_id [ID]
 ,convert(varchar,sf_initialDate,103) [VALID FROM]
,convert(varchar,sf_endDate,103) [VALID UNTIL]
,sf_officialSubFundName [SUB FUND NAME]
,sfstat.st_desc [STATUS]
,sf_cssfCode [CSSF CODE]
,sf_faCode [ADMIN CODE]
,sf_depCode [DEPOSITARY BANK CODE]
,sf_taCode [TRANSFER AGENT CODE]
,sf_firstNavDate [FIRST NAV DATE]
,sf_lastNavDate [LAST NAV DATE]
,sf_cssfAuthDate [CSSF AUTH. DATE]
,sf_expDate  [EXPIRY DATE]
,sf_leiCode [LEI CODE]
,sfcesr.c_desc [CESR CLASS]
,sfgeo.gf_desc [GEO FOCUS]
,sfge.ge_desc [GLOBAL EXPOSURE]
,sf_currency [CURRENCY]
,nfreq.nf_desc [FREQUENCY]
,vdate.vd_desc [VALUATION DATE]
,cdate.cd_desc [CALCULATION DATE]
,case 
	when sf_derivatives=1 then 'YES'
	when sf_derivatives=0 then 'NO'
	else NULL
	END as [DERIVATIVES]
,dmar.dm_desc [DERIV. MARKET]
,dpur.dp_desc [DERIV. PURPOSE]
,sf_lastProspectus [LAST PROSPECTUS]
,sf_lastProspectusDate [LAST PROSPECTUS DATE]
,pac.pac_desc [PRINCIPAL ASSET CLASS]
,tom.tom_desc [MARKET TYPE]
,pis.pis_desc [PRINCIPAL INVESTMENT STRATEGY]
,sf_clearing_code [CLEARING CODE]
,cms.c_morningstar_desc [MORNINGSTAR CATEGORY]
,cs.cat_six_desc [SIX CATEGORY]
,cb.cat_bloomberg_Desc [BLOOMBERG CATEGORY]	

			FROM [dbo].tb_historySubFund sf
				left join tb_dom_sf_status sfstat on sfstat.st_id=sf.sf_status
				left join tb_dom_cesrClass sfcesr on sfcesr.cc_id=sf.sf_cesrClass
				left join tb_dom_cssf_geographical_focus sfgeo on sfgeo.gf_id=sf.sf_cssf_geographical_focus
				left join tb_dom_globalExposure sfge on sfge.ge_id=sf.sf_globalExposure
				left join tb_dom_navFrequency nfreq on nfreq.nf_id=sf.sf_navFrequency
				left join tb_dom_valutationDate vdate on vdate.vd_id=sf.sf_valutationDate
				left join tb_dom_calculationDate cdate on cdate.cd_id=sf.sf_calculationDate
				left join tb_dom_derivMarket dmar on dmar.dm_id=sf.sf_derivMarket
				left join tb_dom_derivPurpose dpur on dpur.dp_id=sf.sf_derivPurpose
				left join tb_dom_cssf_principal_asset_class pac on pac.pac_id=sf.sf_principal_asset_class
				left join tb_dom_type_of_market tom on tom.tom_id=sf.sf_type_of_market
				left join tb_dom_principal_investment_strategy pis on pis.pis_id=sf.sf_principal_investment_strategy
				left join tb_dom_sf_cat_morningstar cms on cms.c_morningstar_id=sf.sf_cat_morningstar
				left join tb_dom_sf_cat_six cs on cs.cat_six_id=sf.sf_category_six
				left join tb_dom_sf_cat_bloomberg cb on cb.cat_bloomberg_id=sf.sf_category_bloomberg
			Where (@report_date between sf.sf_initialDate and sf.sf_endDate OR (@report_date >= sf.sf_initialDate and sf.sf_endDate is null)) 
		 ) t3 ON t2.sf_id = t3.[ID] 
                 ORDER BY t3.[SUB FUND NAME]
)


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_fund_id]
(	
		@report_date date,
		@fundid as int
)
RETURNS TABLE 
AS
RETURN 
(

select 
[FUND ID],
[VALID FROM],
	case
	when [VALID UNTIL] is null then 'STILL VALID'
	else [VALID UNTIL] end as [VALID UNTIL] ,
[FUND NAME],
[STATUS],
[CSSF CODE],
[LEGAL FORM],
[LEGAL VEHICLE],
[LEGAL TYPE],
[FUND ADMIN CODE],
[DEPOSITARY BANK CODE],
[TRANSFER AGENT CODE],
[COMPANY DESCRIPTION],
[COMPANY TYPE],
[TIN NUMBER],
[LEI CODE],
[REG. NUMBER],
[VAT REG. NUMBER],
[VAT IDENT. NUMBER],
[I.B.I.C. NUMBER]
from (

SELECT 
 convert(varchar, f.f_initial_date, 103)[VALID FROM],
			convert(varchar, f.f_end_date, 103) [VALID UNTIL],
			f.f_id [FUND ID],
			f.f_official_fund_name [FUND NAME],  
			f.f_cssf_code [CSSF CODE],  
			ft.st_f_desc [STATUS], 
			lf.lf_acronym [LEGAL FORM],  
			lv.lv_acronym [LEGAL VEHICLE], 
			lt.lt_acronym [LEGAL TYPE], 
			CONCAT(tb_comp_fund.c_iso3_acronym, ' - ',  f_fa_code ) [FUND ADMIN CODE],
			f_dep_code [DEPOSITARY BANK CODE],
			f_ta_code [TRANSFER AGENT CODE],
			ct.ct_desc [COMPANY DESCRIPTION],  
			CT.ct_acronym [COMPANY TYPE], 
			f.f_tin_number [TIN NUMBER], 
			f.f_lei_code [LEI CODE],
			f.f_registration_number [REG. NUMBER],
                        f.f_vat_registration_number [VAT REG. NUMBER],
                        f.f_vat_Identification_number [VAT IDENT. NUMBER],
                        f.f_ibic_number [I.B.I.C. NUMBER]
	
	FROM tb_historyFund f
				left join tb_dom_f_status ft  on ft.st_f_id=f.f_status
				left join tb_dom_legal_form lf on lf.lf_id=f.f_legal_form
				left join tb_dom_legal_vehicle lv on lv.lv_id=f.f_legal_vehicle
				left join tb_dom_legal_type lt on lt.lt_id=f.f_legal_type
				left join tb_dom_company_type ct on ct.ct_id=f.f_company_type
                                left join (select tc.c_id, tc.c_name, tc.c_iso3_acronym, sa_fundId from tb_serviceAgreement_fund saf 
								join tb_companies tc on tc.c_id=saf.sa_company
								where sa_activityType=8 
								and (@report_date >= saf.sa_activationDate and (saf.sa_expirationDate>@report_date or saf.sa_expirationDate is null) and sa_status=1)
								)tb_comp_fund  on sa_fundId=f.f_id


	Where (@fundid = f.f_id) AND (@report_date between f.f_initial_date and f.f_end_date  OR (@report_date >= f.f_initial_date and f.f_end_date is null))
	)tb2
)


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_active_shareclass]
(	
		@report_date date 
)
RETURNS TABLE 
AS
RETURN 
(

SELECT TOP(1000) 

 [ID]	
,[VALID FROM]
,case
	when [VALID UNTIL] is null then 'STILL VALID'
	else [VALID UNTIL] end as [VALID UNTIL]
,[NAME]
,[STATUS]
,[ISIN]
,[INVESTOR TYPE]
,[SHARE TYPE]
,[CCY]
,[COUNTRY ISSUE]
,[ULT PARENT COUNTRY OF RISK]
,[EMISSION DATE]
,[INCEPTION DATE]
,[LAST NAV]
,[EXPIRY DATE]
,[INITIAL PRICE]
,[ACCOUNTING CODE]
,[HEDGED]
,[LISTED]
,[BLOOMBERG MARKET]
,[BLOOMBERG CODE]
,[BLOOMBERG ID]
,[VALOR CODE]
,[FUND ADMIN. CODE]
,[TRASFER AGENT CODE]
,[WKN CODE]
,[BUSINESS YEAR]
,[PROSPECTUS CODE]	
FROM 
( 

SELECT

 sc_id [ID]	
,convert(varchar, sc_initialDate, 103) [VALID FROM]
,convert(varchar, sc_endDate, 103) [VALID UNTIL]
,sc_officialShareClassName [NAME]
,stat.sc_s_desc [STATUS]
,intype.it_desc [INVESTOR TYPE]
,sharetype.st_desc [SHARE TYPE]
,sc_currency [CCY]
,sc_countryIssue [COUNTRY ISSUE]
,sc_ultimateParentCountryRisk [ULT PARENT COUNTRY OF RISK]
,convert(varchar, sc_emissionDate, 103) [EMISSION DATE]
,convert(varchar, sc_inceptionDate, 103) [INCEPTION DATE]
,convert(varchar, sc_lastNav, 103) [LAST NAV]
,convert(varchar, sc_expiryDate, 103) [EXPIRY DATE]
,sc_initialPrice [INITIAL PRICE]
,sc_accountingCode [ACCOUNTING CODE]
,case 
	when sc_hedged=1 then 'Yes'
	when sc_hedged=0 then 'No'
	else NULL
	END as [HEDGED]
,case 
	when sc_listed=1 then 'Yes'
	when sc_listed=0 then 'No'
	else NULL
	END as  [LISTED]
,sc_bloomberMarket [BLOOMBERG MARKET]
,sc_bloombedCode [BLOOMBERG CODE]
,sc_bloombedId [BLOOMBERG ID]
,sc_isinCode [ISIN]
,sc_valorCode [VALOR CODE]
,sc_faCode [FUND ADMIN. CODE]
,sc_taCode [TRASFER AGENT CODE]
,sc_WKN [WKN CODE]
,convert(varchar, sc_date_business_year, 103)  [BUSINESS YEAR]
,sc_prospectus_code [PROSPECTUS CODE]	
	
	FROM tb_historyShareClass sc
	left join tb_dom_investor_type intype on intype.it_id=sc.sc_investorType
	left join tb_dom_share_type sharetype on sharetype.st_id= sc.sc_shareType
	left join tb_dom_share_status stat on stat.sc_s_id=sc.sc_status
		
	Where (
		@report_date between sc.sc_initialDate and sc.sc_endDate  OR (@report_date > sc.sc_initialDate and sc.sc_endDate is null)
			 and stat.sc_s_desc = 'Active'		 
	)
) t2
 ORDER BY t2.[NAME]
)

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_active_fund_active_subfunds]
(	
 @report_date as date,
 @fund_id as int
)
RETURNS TABLE 
AS
RETURN 
(
SELECT top(100)
 [ID]
,[VALID FROM]
, case
	when [VALID UNTIL] is null then 'STILL VALID'
	else [VALID UNTIL] end as [VALID UNTIL]
, [SUB FUND NAME]
, [STATUS]
, [CSSF CODE]
, [ADMIN CODE]
, [DEPOSITARY BANK CODE]
, [TRANSFER AGENT CODE]
, [FIRST NAV DATE]
, [LAST NAV DATE]
, [CSSF AUTH. DATE]
, [EXPIRY DATE]
,[LEI CODE]
,[CESR CLASS]
,[GEO FOCUS]
,[GLOBAL EXPOSURE]
,[CURRENCY]
,[FREQUENCY]
,[VALUATION DATE]
,[CALCULATION DATE]
,[DERIVATIVES]
,[DERIV. MARKET]
,[DERIV. PURPOSE]
,[PRINCIPAL ASSET CLASS]
,[MARKET TYPE]
,[PRINCIPAL INVESTMENT STRATEGY]
,[CLEARING CODE]
,[MORNINGSTAR CATEGORY]
,[SIX CATEGORY]
,[BLOOMBERG CATEGORY]	
FROM ( 
	SELECT f.f_id, f.f_official_fund_name
	FROM [dbo].tb_historyFund f 
	Where (@report_date between f.f_initial_date and f.f_end_date OR (@report_date >= f.f_initial_date and f.f_end_date is null)) ) t1 
	JOIN ( 
			SELECT fsf.sf_id, fsf.fsf_startConnection, fsf.fsf_endConnection, fsf.f_id 
			FROM [dbo].tb_fundSubFund fsf 
			Where 
				(@report_date between fsf.fsf_startConnection and fsf.fsf_endConnection OR (@report_date >= fsf.fsf_startConnection and fsf.fsf_endConnection is null)) 
		 ) t2  ON t1.f_id = t2.f_id and t1.f_id=@fund_id
	
	JOIN ( 
			SELECT  
 sf_id [ID]
 ,convert(varchar,sf_initialDate,103) [VALID FROM]
,convert(varchar,sf_endDate,103) [VALID UNTIL]
,sf_officialSubFundName [SUB FUND NAME]
,sfstat.st_desc [STATUS]
,sf_cssfCode [CSSF CODE]
,sf_faCode [ADMIN CODE]
,sf_depCode [DEPOSITARY BANK CODE]
,sf_taCode [TRANSFER AGENT CODE]
,sf_firstNavDate [FIRST NAV DATE]
,sf_lastNavDate [LAST NAV DATE]
,sf_cssfAuthDate [CSSF AUTH. DATE]
,sf_expDate  [EXPIRY DATE]
,sf_leiCode [LEI CODE]
,sfcesr.c_desc [CESR CLASS]
,sfgeo.gf_desc [GEO FOCUS]
,sfge.ge_desc [GLOBAL EXPOSURE]
,sf_currency [CURRENCY]
,nfreq.nf_desc [FREQUENCY]
,vdate.vd_desc [VALUATION DATE]
,cdate.cd_desc [CALCULATION DATE]
,case 
	when sf_derivatives=1 then 'YES'
	when sf_derivatives=0 then 'NO'
	else NULL
	END as [DERIVATIVES]
,dmar.dm_desc [DERIV. MARKET]
,dpur.dp_desc [DERIV. PURPOSE]
,sf_lastProspectus [LAST PROSPECTUS]
,sf_lastProspectusDate [LAST PROSPECTUS DATE]
,pac.pac_desc [PRINCIPAL ASSET CLASS]
,tom.tom_desc [MARKET TYPE]
,pis.pis_desc [PRINCIPAL INVESTMENT STRATEGY]
,sf_clearing_code [CLEARING CODE]
,cms.c_morningstar_desc [MORNINGSTAR CATEGORY]
,cs.cat_six_desc [SIX CATEGORY]
,cb.cat_bloomberg_Desc [BLOOMBERG CATEGORY]	

			FROM [dbo].tb_historySubFund sf
				left join tb_dom_sf_status sfstat on sfstat.st_id=sf.sf_status
				left join tb_dom_cesrClass sfcesr on sfcesr.cc_id=sf.sf_cesrClass
				left join tb_dom_cssf_geographical_focus sfgeo on sfgeo.gf_id=sf.sf_cssf_geographical_focus
				left join tb_dom_globalExposure sfge on sfge.ge_id=sf.sf_globalExposure
				left join tb_dom_navFrequency nfreq on nfreq.nf_id=sf.sf_navFrequency
				left join tb_dom_valutationDate vdate on vdate.vd_id=sf.sf_valutationDate
				left join tb_dom_calculationDate cdate on cdate.cd_id=sf.sf_calculationDate
				left join tb_dom_derivMarket dmar on dmar.dm_id=sf.sf_derivMarket
				left join tb_dom_derivPurpose dpur on dpur.dp_id=sf.sf_derivPurpose
				left join tb_dom_cssf_principal_asset_class pac on pac.pac_id=sf.sf_principal_asset_class
				left join tb_dom_type_of_market tom on tom.tom_id=sf.sf_type_of_market
				left join tb_dom_principal_investment_strategy pis on pis.pis_id=sf.sf_principal_investment_strategy
				left join tb_dom_sf_cat_morningstar cms on cms.c_morningstar_id=sf.sf_cat_morningstar
				left join tb_dom_sf_cat_six cs on cs.cat_six_id=sf.sf_category_six
				left join tb_dom_sf_cat_bloomberg cb on cb.cat_bloomberg_id=sf.sf_category_bloomberg
			Where (@report_date between sf.sf_initialDate and sf.sf_endDate OR (@report_date >= sf.sf_initialDate and sf.sf_endDate is null) and sfstat.st_desc = 'Active') 
		 ) t3 ON t2.sf_id = t3.[ID] 
                 ORDER BY t3.[SUB FUND NAME]
)