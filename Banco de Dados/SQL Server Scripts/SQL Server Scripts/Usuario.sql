USE DBAPPSAUDE
GO

IF OBJECT_ID ('dbo.Usuario', 'U' ) IS NOT NULL  
BEGIN
	DROP TABLE Usuario
END

CREATE TABLE Usuario
(
	 IdUsuario        INT             NOT NULL IDENTITY(1,1)
	,Nome             VARCHAR(100)    NOT NULL 
	,SobreNome        VARCHAR(100)    NOT NULL 
	,Email            VARCHAR(100)    NOT NULL  
	,Senha            VARCHAR(100)    NOT NULL 
	,DataNascimento   DATETIME        NULL 
	,CPF              VARCHAR(15)     NULL  
	,Celular          VARCHAR(30)         NULL  
	,Autenticacao     INT                 NULL  
)

ALTER TABLE Usuario
ADD CONSTRAINT PkUsuario  PRIMARY KEY (IdUsuario)