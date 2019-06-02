--procedure para atualizar dependente
create procedure SP_AtualizarDependente
	@IdDependente	integer,
	@Nome	nvarchar(100),
	@DataNascimento	date,
	@IdFuncionario	integer

as
begin
	begin transaction
		update Dependente 
		set
		Nome = @Nome,
		DataNascimento = @DataNascimento, 
		IdFuncionario =@IdFuncionario
	where
		idDependente =@IdDependente
	commit
end