insert into PessoaPrograma
select Codigo, Programa_Codigo from Pessoa;

-- Correção Programa-Ata
update a set Programa_Codigo=p.Programa_Codigo from ata a
	inner join pessoa p on p.Codigo=a.Responsavel_Codigo;

-- Correção Programa-Aprovação
update a set Programa_Codigo=p.Programa_Codigo from Aprovacao a
	inner join pessoa p on p.Codigo=a.ResponsavelPelaAprovacao_Codigo;

-- Correção Programa-AberturaDeSolicitacao
update a set Programa_Codigo=p.Programa_Codigo from AberturaDeSolicitacao a
	inner join pessoa p on p.Codigo=a.Responsavel_Codigo

-- Correção Programa-AnaliseDeSolicitacao
update a set Programa_Codigo=p.Programa_Codigo from AnaliseDeSolicitacao a
	inner join pessoa p on p.Codigo=a.Responsavel_Codigo

-- Correção Programa-AprovacaoDeSolicitacao
update a set Programa_Codigo=p.Programa_Codigo from AprovacaoDeSolicitacao a
	inner join pessoa p on p.Codigo=a.Responsavel_Codigo

-- Correção Programa-ProcessoDaSolicitacao
update a set Programa_Codigo=p.Programa_Codigo from ProcessoDaSolicitacao a
	inner join pessoa p on p.Codigo=a.Responsavel_Codigo

-- Correção Programa-EntregaDaSolicitacao
update a set Programa_Codigo=p.Programa_Codigo from EntregaDaSolicitacao a
	inner join pessoa p on p.Codigo=a.Responsavel_Codigo

-- Correção Programa-Infusao
update a set Programa_Codigo=p.Programa_Codigo from Infusao a
	inner join pessoa p on p.Codigo=a.Responsavel_Codigo

-- Correção Programa-NotaFiscal
update a set Programa_Codigo=p.Programa_Codigo from NotaFiscal a
	inner join pessoa p on p.Codigo=a.Responsavel_Codigo

-- Correção Programa-Fatura
