# Controle de Fluxo de Caixa

O Controle de Fluxo de Caixa é uma API que permite a um comerciante controlar o seu fluxo de caixa diário com os lançamentos (débitos e créditos) e disponibiliza um relatório com o saldo diário consolidado.

## Requisitos de Negócio

- Serviço de controle de lançamentos
- Serviço de consolidado diário

## Requisitos Técnicos

- Linguagem: ASP.NET Core
- Banco de dados: MySQL
- Padrões de Arquitetura: Domain-Driven Design (DDD), CQRS, Repository Pattern
- Design Patterns: Injeção de Dependência (Dependency Injection)
- Princípios SOLID: Single Responsibility Principle (SRP), Open/Closed Principle (OCP), Liskov Substitution Principle (LSP), Interface Segregation Principle (ISP), Dependency Inversion Principle (DIP)

## Estrutura do Projeto

O projeto está organizado nos seguintes diretórios:

- ControleFluxoCaixa.API: Contém os controladores e rotas da API do sistema. Ele lida com as solicitações HTTP e serve como interface entre a camada de apresentação e a camada de aplicação.

- ControleFluxoCaixa.CQRS: Implementa o padrão Command Query Responsibility Segregation (CQRS). Ele contém os comandos e consultas que são executados dentro do sistema. Os comandos representam ações que modificam o estado do sistema, enquanto as consultas representam operações de leitura.

- ControleFluxoCaixa.DOMAIN: Contém as entidades e modelos de domínio do sistema. Ele representa a lógica e as regras de negócio do sistema. Inclui interfaces, classes e estruturas que definem os objetos de domínio, como `Lancamento` (transação) e `Response`.

- ControleFluxoCaixa.INFRA: Fornece implementações relacionadas à infraestrutura, como acesso ao banco de dados, serviços externos, registro, autenticação, etc. Ele fornece suporte técnico para projetos de nível superior, como `ControleFluxoCaixa.CQRS` e `ControleFluxoCaixa.API`.

- ControleFluxoCaixa.TEST: Contém testes unitários e de integração para validar o comportamento do sistema. Inclui classes de teste para as funcionalidades implementadas nos outros projetos.

## Tecnologias Utilizadas

O sistema ControleFluxoCaixa é desenvolvido utilizando as seguintes tecnologias:

- C#: A linguagem de programação principal para implementar a lógica do sistema.

- ASP.NET Core: O framework usado para construir a API e lidar com solicitações HTTP.

- MediatR: Uma biblioteca usada para implementar o padrão Mediator e lidar com comandos e consultas.

- Moq: Um framework de simulação usado para criar objetos simulados em testes unitários.

- prmToolkit.NotificationPattern: Uma biblioteca usada para gerenciar notificações e validações na camada de domínio.


## Começando

Para começar com o sistema ControleFluxoCaixa, siga estas etapas:

## Configuração

1. Instale o .NET Core SDK versão X: [link para download](https://dotnet.microsoft.com/download)
2. Clone o repositório: `git clone https://github.com/HEITORHOG1/ControleFluxoCaixa`
3. Abra o arquivo de solução `ControleFluxoCaixa.sln` em seu IDE preferido.
4. Compile a solução para restaurar as dependências e compilar o código.
5. Execute o sistema iniciando o projeto `ControleFluxoCaixa.API`.
6. Acesse os endpoints da API por meio das rotas fornecidas e teste a funcionalidade usando uma ferramenta como o Postman ou um navegador da web.

## Configuração do Banco de Dados

1. Abra o arquivo `appsettings.json`
2. Configure a string de conexão do banco de dados no campo `ControleFluxoCaixaConnectionString`

Exemplo da string de conexão:
```json
"ControleFluxoCaixaConnectionString": "Server=localhost;Database=ControleFluxoCaixa;Uid=root;Pwd=q1w2e3r4;"

Executando a Aplicação
Restaure as dependências: dotnet restore
Execute as migrações do banco de dados: dotnet ef migrations add InitialMigration
Aplique as migrações no banco de dados: dotnet ef database update
Execute o projeto: dotnet run
A API estará acessível em: https://localhost:7101/swagger/index.html

Utilização
Endpoint para adicionar um lançamento: POST /api/Lancamento/AdicionarLancamento
Endpoint para listar os lançamentos: GET /api/Lancamento/ListarLancamento
Endpoint para alterar um lançamento: PUT /api/Lancamento/AlterarLancamento
Endpoint para remover um lançamento: DELETE /api/Lancamento/RemoverLancamento/{id}
Endpoint para obter o consolidado diário: GET /api/Consolidado/ListarConsolidadoDiario/{data}
Exemplo de chamada de API para adicionar um lançamento:

POST /api/Lancamento/AdicionarLancamento
Content-Type: application/json

{
  "descricao": "Lançamento de venda",
  "valor": 100.00,
  "tipo": "Crédito"
}
Para executar a API corretamente, é necessário configurar corretamente o ambiente, como o SDK do .NET Core, o banco de dados e as dependências do projeto.



## Contribuição

Contribuições para o projeto ControleFluxoCaixa são bem-vindas. Se você encontrar um bug, tiver uma solicitação de recurso ou quiser contribuir com código, siga estas etapas:

1. Faça um fork do repositório.

2. Crie um novo branch para sua funcionalidade ou correção de bug.

3. Faça as alterações necessárias em seu branch.

4. Teste suas alterações para garantir que elas não introduzam novos problemas.

5. Faça commit das suas alterações e faça o push para o seu repositório forked.

6. Envie uma pull request, explicando as alterações que você fez e por que elas devem ser mescladas.

7. Aguarde feedback ou instruções adicionais dos mantenedores do projeto.

## Licença

O projeto ControleFluxoCaixa está licenciado sob a [Heitor Oliveira Gonçalves](LICENSE).
Por favor, observe que este arquivo README.md é um modelo e você pode precisar modificá-lo de acordo com os detalhes e requisitos específicos do seu projeto.




![Diagrama]([/diagrama.jpg](https://github-production-user-asset-6210df.s3.amazonaws.com/61200900/243025729-448f5805-9ca4-4b24-bedf-949e852067ae.png))




##https://www.linkedin.com/in/heitorhog/




