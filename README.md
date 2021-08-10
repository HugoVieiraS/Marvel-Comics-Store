<h1 align="center">Marvel Comics Store</h1>

<p align="center">Api para consulta dos quadrinhos marvel, e detalhes</p>

<p align="center">
 <a href="#objetivo">Objetivo</a> •
 <a href="#roadmap">Roadmap</a> • 
 <a href="#tecnologias">Tecnologias</a> • 
 <a href="#contribuicao">Contribuição</a> • 
 <a href="#licenc-a">Licença</a> • 
 <a href="#autor">Autor</a>
</p>

#### Objetivo:

- [x] Crie uma aplicação .NET C# de uma loja de quadrinhos utilizando a API da Marvel para buscar informações sobre os quadrinhos..              
- [x] 1ª tela: Listagem dos quadrinhos, com a opção de ver detalhes.
- [x] 2ª tela: Checkout dos quadrinhos selecionados.

#### Diretrizes:

- [x] Utilizar qualquer framework/biblioteca em C#
- [x] Utilizar Mysql ou Oracle como banco de dados.
- [x] Consumir api da marvel https://developer.marvel.com, devolvendo uma lista de quadrinhos e a opção de ver detalhes de um quadrinho específico.
- [x] Salvar as informações do checkout na banco de dados.

#### Extras desenvolvidos :

- [x] O checkout deve contemplar a opcão de código de desconto (pode validar mock).
- [x] Existem dois tipos de cupons: Cupons raros e cupons comuns. Cupons comuns dão desconto somente para quadrinhos comuns enquanto raros podem ser usados em qualquer tipo.

#### Observações

- Executar o comando *update-database*, pelo gerenciador de pacotes, selecionando o projeto *MarvelComicsStore.Infrastructure.Data* para que o banco de dados seja criado.
- Por favor, verificar usuário e senha local e a porta para criar o banco ao realizar os testes.
