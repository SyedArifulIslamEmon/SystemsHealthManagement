BEGIN TRAN;
INSERT INTO dbo.Grupos (Nome, Descricao) values ('Íntegra', 'Íntegra');
INSERT INTO dbo.Grupos (Nome, Descricao) values ('Cliente', 'Cliente');

INSERT INTO dbo.TipoDeCrm (Descricao) values ('Representante');
INSERT INTO dbo.TipoDeCrm (Descricao) values ('Gerente de Marketing');
INSERT INTO dbo.TipoDeCrm (Descricao) values ('Gerente de Produto');

INSERT INTO dbo.Cargo (Nome, Descricao) values ('Administrador','Administrador');
INSERT INTO dbo.Departamento (Nome, Descricao) values ('Executivo', 'Executivo');

INSERT INTO dbo.Modulo (Nome, Descricao) values ('Dashboard','Dashboard');
INSERT INTO dbo.Modulo (Nome, Descricao) values ('Relatorios', 'Relatorios');
INSERT INTO dbo.Modulo (Nome, Descricao) values ('GestaoDeClinicas', 'Gestao de Clinicas');
INSERT INTO dbo.Modulo (Nome, Descricao) values ('GestaoDeTratamentos', 'Gestao de Tratamentos');
INSERT INTO dbo.Modulo (Nome, Descricao) values ('PainelDeControle', 'Painel de Controle');

INSERT INTO dbo.Programa (Nome, Descricao) VALUES ('Essencial', 'Essencial - Programa de Apoio ao Paciente');

INSERT INTO dbo.Equipe (Programa_Codigo) VALUES ((SELECT codigo FROM dbo.Programa WHERE Nome = 'Essencial'));

INSERT INTO dbo.Perfil (Nome, Grupo_Codigo) values 
	('Master Íntegra', (SELECT Codigo FROM dbo.Grupos WHERE Descricao = 'Íntegra'));
INSERT INTO dbo.Perfil (Nome, Grupo_Codigo) values 
	('Master Cliente', (SELECT Codigo FROM dbo.Grupos WHERE Descricao = 'Cliente'));

INSERT INTO dbo.PerfilModulo (Modulo_Codigo, Perfil_Codigo)
(SELECT codigo , (SELECT TOP 1 codigo FROM dbo.Perfil WHERE Nome = 'Master Íntegra') FROM dbo.Modulo);

INSERT INTO dbo.PerfilModulo (Modulo_Codigo, Perfil_Codigo)
(SELECT codigo, (SELECT TOP 1 codigo FROM dbo.Perfil WHERE Nome = 'Master Cliente') FROM dbo.Modulo);

INSERT INTO dbo.Usuario (DataDeCriacao, NomeDeUsuario, Senha, UltimoAcesso, PenultimoAcesso, Perfil_Codigo)
VALUES (GETDATE(), 'integra@integra.com.br', 'AMkqoaR271urXl7aFxIg4b7Wep33uvAZpdBAOm9nMETiHznVP1zITYpcHwyzaXB+SQ==', GETDATE(), GETDATE(), (SELECT Codigo FROM dbo.Perfil WHERE Nome = 'Master Íntegra'));

INSERT INTO dbo.Usuario (DataDeCriacao, NomeDeUsuario, Senha, UltimoAcesso, PenultimoAcesso, Perfil_Codigo)
VALUES (GETDATE(), 'cliente@integra.com.br', 'ACRYK/FnKeNZw90QDuB7hbHz2tD+lCW+6yBr5YD/NUbia47SiCNce6txOMnK0AybTQ==', GETDATE(), GETDATE(), (SELECT codigo FROM dbo.Perfil WHERE Nome = 'Master Cliente'));

INSERT INTO dbo.Pessoa (Nome, TipoDaPessoa, Inativo, Cargo_Codigo, Departamento_Codigo, Programa_Codigo, Usuario_Codigo)
(SELECT 'Usúario Integra Master', 0, 0, codigo, 
(SELECT codigo FROM dbo.Departamento WHERE Nome = 'Executivo'),
(SELECT codigo FROM dbo.Programa WHERE Nome = 'Essencial'),
(SELECT codigo FROM dbo.Usuario WHERE NomeDeUsuario = 'integra@integra.com.br')
 FROM dbo.Cargo WHERE Descricao = 'Administrador');

 INSERT INTO dbo.Pessoa (Nome, TipoDaPessoa, Inativo, Programa_Codigo, Usuario_Codigo)
(SELECT 'Usúario Cliente Master', 1, 0,
(SELECT codigo FROM dbo.Programa WHERE Nome = 'Essencial'), codigo
FROM dbo.Usuario WHERE NomeDeUsuario = 'cliente@integra.com.br');

COMMIT;
