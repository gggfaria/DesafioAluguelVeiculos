# Teste prático para back-end .net

Para rodar o projeto basta utilizar o docker com o comando:

```
docker-compose up --build

```

Irá subir a API com Swagger e uma base de dados Postgres

Usuário Admin pré-criado:

```
{
  "userName": "mithrandir",
  "password": "mellon_42"
}
```

Utilizar rota auth para realizar login e pegar o token de acesso como Admin

Url para acesso ao Swagger é http://localhost/swagger/


## Requisitos
- Testes unitários
  - DesafioBackEnd.Test
  
- EntityFramework e/ou Dapper
  - DesafioBackEnd.Infra utiliza EF para persistencia dos dados no postgres;
  - FluentApi para configurar o model first
- Docker e Docker Compose
  - Docker compose configurado para subir a aplicação e o banco de dados
- Design Patterns
  - Factory
  - Respository
  - UnitOfWork
- Documentação
  - Api documentada no swagger
- Tratamento de erros
  - Validações feitas nas DTOs;
  - Validações de dominio;
  - Filter para filtrar erros inesperados
- Arquitetura e modelagem de dados
  - Modelo de camadas com DDD;
  - Dominio rico, regras de negócio ficam na domain;
  - Fluent Validation para validar as regras
- Código escrito em língua inglesa
  - Código em inglês
- Código limpo e organizado
- Logs bem estruturados
- Seguir convenções utilizadas pela comunidade
  







  

