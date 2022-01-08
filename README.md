# cotacao.api

#Criação da tabela de Cotação no Banco de dados
CREATE TABLE [dbo].[TB_COTACAO](
	IdCotacao [bigint] IDENTITY(1,1) NOT NULL,
	CNPJComprador [varchar](20) NOT NULL,
	CNPJFornecedor [varchar](20) NOT NULL,
	NumeroCotacao [bigint] NOT NULL,
	DataCotacao [datetime] NOT NULL,
	DataEntregaCotacao [datetime] NOT NULL,
	Cep [varchar](10) NOT NULL,
	Logradouro [varchar](100),
	Complemento [varchar](30),
	Bairro [varchar](50),
	UF [varchar](2),
	Observacao [varchar](100),
 CONSTRAINT [PK_TB_COTACAO] PRIMARY KEY CLUSTERED 
(
	IdCotacao ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


##Criação da tabela de Itens Da Cotação no Banco de dados
CREATE TABLE [dbo].[TB_COTACAO_ITEM](
	IdCotacaoItem [bigint] IDENTITY(1,1) NOT NULL,
	IdCotacao [bigint] NOT NULL,	
	Descricao [varchar](100) NOT NULL,
	NumeroItem [bigint] NOT NULL,
	Preco [numeric](18, 2) NULL,
	Quantidade [numeric](18, 2) NOT NULL,
	Marca [varchar](50),
	Unidade [varchar](2),
 CONSTRAINT [PK_TB_COTACAO_ITEM] PRIMARY KEY CLUSTERED 
(
	IdCotacaoItem ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TB_COTACAO_ITEM]  WITH CHECK ADD  
CONSTRAINT [FK_TB_COTACAO_ITEM_TB_COTACAO] FOREIGN KEY([IdCotacao])
REFERENCES [dbo].[TB_COTACAO] ([IdCotacao])
GO

ALTER TABLE [dbo].[TB_COTACAO_ITEM] CHECK CONSTRAINT [FK_TB_COTACAO_ITEM_TB_COTACAO]
GO



