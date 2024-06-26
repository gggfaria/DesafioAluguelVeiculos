# Desafio prático para desenvolvedor back-end .net

## How to run
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

## Swagger 

Utilizar rota auth para realizar login e pegar o token de acesso como Admin

Url para acesso ao Swagger é http://localhost/swagger/

## Logs Seq
Utilize o Seq log para visualizar os logs da aplicação.

Url http://localhost:8080/


## Desafio

Aplicação para gerenciar alugueis de veículos. 
- Cadastro de motoristas;
- Cadastro, pesquisa, atualização e deleção de veículos;
- Realiza aluguel e calcula a taxa de pagamento prevista, seguindo regra do plano ofertado.

### Praticando 

- Testes de unidade
  - DesafioBackEnd.Test
  
- EntityFramework
  - DesafioBackEnd.Infra utiliza EF para persistencia dos dados no postgres;
  - FluentApi para configurar o model first
- Docker e Docker Compose
  - Docker compose configurado para subir a aplicação e o banco de dados
- Design Patterns
  - Abstract Factory
  - Respository
  - UnitOfWork
- Documentação
  - Api documentada no swagger
- Tratamento de erros
  - Validações feitas nas DTOs;
  - Validações de dominio;
  - "Filter" para filtrar erros inesperados
- Arquitetura e modelagem de dados
  - Modelo de camadas com DDD;
  - Dominio rico, regras de negócio ficam na domain;
  - Fluent Validation para validar as regras
- Código limpo e organizado
- Logs
  







  

