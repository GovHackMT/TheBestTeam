USE DBAPPSAUDE
GO

IF OBJECT_ID ( 'dbo.DenunciaMovimentoTipo', 'U' ) IS NOT NULL  
BEGIN
	DROP TABLE DenunciaMovimentoTipo
END

CREATE TABLE DenunciaMovimentoTipo
(
	 IdDenunciaMovimentoTipo INT         NOT NULL IDENTITY(1,1)
	,Descricao               VARCHAR(50) NOT NULL 
)

ALTER TABLE DenunciaMovimentoTipo
ADD CONSTRAINT PkDenunciaMovimentoTipo  PRIMARY KEY (IdDenunciaMovimentoTipo)