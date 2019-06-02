Create table Funcionario(
	idFuncionario integer identity(1,1),
	Nome	nvarchar(100) not null,
	Salario	decimal(18,2)	not null,
	DataAdmissao date	not null,
	primary key (idFuncionario)
)
go

create table Dependente(
	idDependente integer identity(1,1),
	Nome	nvarchar(100) not null,
	DataNascimento	date	not null,
	IdFuncionario integer,
	primary key(idDependente),
	foreign key(idFuncionario)
		references Funcionario(idFuncionario)

)
go