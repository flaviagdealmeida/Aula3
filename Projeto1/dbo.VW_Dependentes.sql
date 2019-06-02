--criando uma view para consulta de dependentes..

create view VW_Dependentes
as
	select
		d.IdDependente,
		d.Nome as NomeDependente,
		d.DataNascimento,
		f.IdFuncionario,
		f.Nome as NomeFuncionario,
		f.Salario as Salario,
		f.DataAdmissao as DataAdmissao
	from Dependente d
	inner join 
		Funcionario f
	on
		f.idFuncionario = d.IdFuncionario