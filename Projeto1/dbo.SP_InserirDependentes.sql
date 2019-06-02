--procedure para cadastro dependente
create procedure SP_InserirDependentes
	@Nome	nvarchar(100),
	@DataNascimento	date,
	@IdFuncionario	integer

as
begin
	begin transaction
		insert into Dependente(Nome, DataNascimento, IdFuncionario)
		values(@Nome, @DataNascimento, @IdFuncionario)
	commit
end