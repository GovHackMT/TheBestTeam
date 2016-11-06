USE DBAPPSAUDE
GO

IF OBJECT_ID ( 'dbo.DenunciaTipo', 'U' ) IS NOT NULL  
BEGIN
	DROP TABLE DenunciaTipo
END

CREATE TABLE DenunciaTipo
(
	 IdDenunciaTipo INT             NOT NULL IDENTITY(1,1)
	,Descricao      VARCHAR(200)    NOT NULL 
)

ALTER TABLE DenunciaTipo
ADD CONSTRAINT PkDenunciaTipo  PRIMARY KEY (IdDenunciaTipo)