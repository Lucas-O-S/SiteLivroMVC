Desenvolva uma aplicação ASP.NET CORE MVC para cadastro de livros.

Crie as operações de Inclusao, alteração, exclusão e listagem dos livros. O campo "autor2" nao é obrigatório sendo que neste caso o usuário não precisará preenchê-lo. Os demais são de preenchimento obrigatório.

Tabela: 

create table tbLivros

(

  Id int not null primary key,

  Titulo varchar(100) not null,

  Autor1 varchar(100) not null,

  Autor2 varchar(100) null,   

  Editora  varchar(100) not null,

  AnoLancamento int not null,

  Edicao int not null,

  PrecoSugerido money not null  

)
