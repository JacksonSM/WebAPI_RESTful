# AluraFlix - WebAPI_RESTful 
[![Generic badge](https://img.shields.io/badge/Status-Finalizado-<COLOR>.svg)](https://shields.io/)
[![PyPi license](https://badgen.net/pypi/license/pip/)](https://pypi.com/project/pip/)
## Deploy

Para acessar os endpoints, utilize o seguinte usuario, email: `user@gmail.com`, Senha: `user321`</br>
Link para API: [AluraFlix](https://aluraflixapi.azurewebsites.net/swagger/index.html)</br>

Para você que usa o Postman para fazer requisições, aqui está a collection da API: </br>
[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/2164b6c56662b416e384?action=collection%2Fimport)</br>

![Capturar](https://user-images.githubusercontent.com/90290547/205185875-be690612-bdfd-46b0-b5fe-94dcd187a440.PNG)


## Sobre

Esta WebApi foi desenvolvida na Alura Challange Backend 5° Edição. Este desafio foi agnóstico com relação à linguagens, frameworks, 
bases de dados e decisões de arquitetura. O desenvolvedor tinha livre-arbítrio para escolher a stack.

Nesse desafio era dado uma prazo de um mês para a entregar da WebApi. A cada semana 
os participantes recebiam novos requisitos para implementarem na sua API. Utilizamos a metodologia kanban para gerenciar os requistos do projeto.

#### O que é um Challenge da Alura?
É uma forma de implementar o Challenge Based Learning que a Apple ajudou a criar. Um mecanismo onde você vai engajar em cima de um problema,
para só depois investigar soluções com cursos, conteúdo e conversas; ou até mesmo com o conhecimento que você já possui! Finalmente vai agir e colocar
seu projeto no ar. Tudo isso com você comentando e ajudando nos projetos de outros alunos e alunas.

### Requisitos: 

  #### Semana 1
      * Criar um banco de dados para armazenar os seguintes campos: id, titulo, descricao, url.
      * Rotas CRUD para /videos.
      * Todos os campos de vídeos devem ser obrigatórios e validados.
 
   #### Semana 2
      * adicionar uma nova tabela no banco de dados para armazenar os seguintes campos: id, titulo, cor.
      * Rotas CRUD para /categorias.
      * Todos os campos de categoria devem ser obrigatório.
      * Agrupar vídeos e categorias, criar uma relação entre vídeos e categorias, atribuindo para cada vídeo uma categoria.
      * Requisição para exibir vídeos por categoria.
      * Criar uma rota que busque vídeos por nome via query parameters.
      * Videos sem categoria definida, recebem categoria LIVRE com o id 1.
      * Criar Testes de unidade e testes de Integração

   #### Semana 3
      * Alterar a estrutura do banco de dados para suporta autenticação.
      * A partir de agora somente usuários autenticados podem interagir com a API. Implementar um mecanismo de autenticação na API,
        para que os usuários possam se autenticar e disparar requisições para ela.
      * Criar uma rota que retorne um numero limitado de videos, sem a necessidade de autenticação.
      * Implementar paginação no retorno de videos.
      * Realizar o deploy da aplicação em qualquer plataforma cloud.

## Technologies / Bibliotecas utilizadas

### Banco de dados
* SQLite

### .NET 6
* ASP.NET WebApi
* Entity Framework Core 6

### Bibliotecas
* AutoMapper
* FluentValidator
* Swagger UI com suporte a JWT 
* FluentAssertions
* Bogus
* Moq
* xUnit
    
## Arquitetura:

* Clean Code
* Clean Architecture
* Injeção de dependência
* Unit of Work
* Repository
* Command 
