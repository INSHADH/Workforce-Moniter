USE [WorkforceMonitorDB]
GO

/****** Object:  Table [dbo].[TNEmpMasterTable]    Script Date: 04-12-2023 16:32:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TNEmpMasterTable](
	[emp_id] [int] IDENTITY(1,1) NOT NULL,
	[emp_code] [varchar](50) NOT NULL,
	[emp_name] [varchar](200) NOT NULL,
	[designation] [varchar](50) NOT NULL,
	[salary] [int] NOT NULL,
 CONSTRAINT [PK_TNEmpMasterTable] PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

