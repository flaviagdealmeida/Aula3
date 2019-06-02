--procedure para excluir dependente
create procedure SP_ExcluirDependente
	@IdDependente	integer
as
begin
	begin transaction
		delete from Dependente 
		
	where idDependente =@IdDependente
	commit
end