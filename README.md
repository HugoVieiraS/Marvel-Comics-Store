<h1 align="center">Marvel Comics Store</h1>

<p align="center">Api para listagem e detalhes dos quadrinhos Marvel</p>

<p align="center">
 <a href="#objetivo">Objetivo</a> •
 <a href="#tecnologias">Diretrizes</a> • 
 <a href="#contribuicao">Extras</a> • 
 <a href="#observacoes"> Observações</a> • 
 <a href="#observacoes"> Rodando a aplicação</a> • 
</p>

#### Objetivo:

- [x] Crie uma aplicação .NET C# de uma loja de quadrinhos utilizando a API da Marvel para buscar informações sobre os quadrinhos..              
- [x] Listagem dos quadrinhos, com a opção de ver detalhes.
- [x] Checkout dos quadrinhos selecionados.

#### Diretrizes:

- [x] Utilizar Mysql ou Oracle como banco de dados.
- [x] Consumir api da marvel https://developer.marvel.com.
- [x] Salvar as informações do Checkout na banco de dados.

#### Features realizadas

- [x] Endpoint Get para listagem dos quadrinhos marvel.
- [x] Endpoint Get para os detalhes do quadrinho.
- [x] Fluxo do checkout (CRUD).
- [x] Cálculo envolvendo os quadrinhos e seus cupons de desconto.

#### Extras desenvolvidos :

- [x] Código de desconto no checkout.
- [x] Tipos de cupons: Cupons raros e cupons comuns.

#### Observação
- [x] Todos os endpoint disponibilizados podem ser testados via swagger da aplicação.

#### Rodando a aplicação

```bash
# Clone este repositório
$ git clone <https://github.com/HugoVieiraS/Marvel-Comics-Store.git>

# Acesse o gerenciador de pacotes e selecione o projeto *MarvelComicsStore.Infrastructure.Data*, e execute o seguinte comando para a criação do banco de dados
$ update-database

# Verifique se o usuário e senha da maquina local é a mesma que se encontra no arquivo appsettings.json

# Execute a aplicação em modo de desenvolvimento
# O servidor inciará na porta:44350 - acesse <https://localhost:44350/swagger>
```
