

USE DBAPPSAUDE
GO

IF OBJECT_ID ( 'dbo.Denuncia', 'U' ) IS NOT NULL  
BEGIN
	DROP TABLE Denuncia
END

CREATE TABLE Denuncia
(
	 IdDenuncia     INT             NOT NULL IDENTITY(1,1)
	,IdDenunciaTipo INT             NOT NULL 
    ,IdUsuario INT             NOT NULL 
	,CodigoUnidade  INT                 NULL 
	,Latitude       VARCHAR(100)    
	,Longetude      VARCHAR(100)
	--,GeogCol1       GEOGRAPHY
    --,GeogCol2       AS GeogCol1.STAsText()
	,Observacao     VARCHAR(MAX)    
)

ALTER TABLE Denuncia
ADD CONSTRAINT PkDenuncia  PRIMARY KEY (IdDenuncia)

ALTER TABLE Denuncia
ADD CONSTRAINT FkDenunciaXDenunciaTipo FOREIGN KEY (IdDenunciaTipo)
REFERENCES DenunciaTipo (IdDenunciaTipo)

ALTER TABLE Denuncia
ADD CONSTRAINT FkDenunciaXUsuario FOREIGN KEY (IdUsuario)
REFERENCES Usuario (IdUsuario)



--DECLARE @geog1 geography;  
--DECLARE @geog2 geography;  
--DECLARE @result geography;  
  
--SELECT @geog1 = GeogCol1 FROM Denuncia 
--SELECT @geog2 = GeogCol1 FROM Denuncia 
--SELECT @result = @geog1.STIntersection(@geog2);  
--SELECT @result.STAsText();  