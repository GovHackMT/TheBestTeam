USE DBAPPSAUDE
GO

IF OBJECT_ID ( 'dbo.DenunciaMovimento', 'U' ) IS NOT NULL  
BEGIN
	DROP TABLE DenunciaMovimento
END

CREATE TABLE DenunciaMovimento
(
	 IdDenunciaMovimento     INT          NOT NULL IDENTITY(1,1)
	,IdDenuncia              INT          NOT NULL 
	,IdUsuario               INT          NOT NULL 
	,IdDenunciaMovimentoTipo INT          NOT NULL 	
	,DataCadastro            DATETIME     NOT NULL 
	,Caminho                 VARCHAR(200) NOT NULL 
)

ALTER TABLE DenunciaMovimento
ADD CONSTRAINT PkDenunciaMovimento  PRIMARY KEY (IdDenunciaMovimento)

ALTER TABLE DenunciaMovimento
ADD CONSTRAINT FkDenunciaMovimentoXDenunciaMovimentoTipo FOREIGN KEY (IdDenunciaMovimentoTipo)
REFERENCES DenunciaMovimentoTipo (IdDenunciaMovimentoTipo)

ALTER TABLE DenunciaMovimento
ADD CONSTRAINT FkDenunciaMovimentoXDenuncia FOREIGN KEY (IdDenuncia)
REFERENCES Denuncia (IdDenuncia)

ALTER TABLE DenunciaMovimento
ADD CONSTRAINT FkDenunciaMovimentoXUsuario FOREIGN KEY (IdUsuario)
REFERENCES Usuario (IdUsuario)