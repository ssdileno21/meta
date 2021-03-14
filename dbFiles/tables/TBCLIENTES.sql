﻿/****** Object:  Table [dbo].[TBCLIENTES]    Script Date: 2/14/2021 6:48:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBCLIENTES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [varchar](100) NULL,
	[TELEFONE] [varchar](20) NULL,
 CONSTRAINT [PK_TBCLIENTES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

