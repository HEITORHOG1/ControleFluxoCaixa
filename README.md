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



<body><div class="mxgraph" style="max-width:100%;border:1px solid transparent;" data-mxgraph="{&quot;highlight&quot;:&quot;#0000ff&quot;,&quot;nav&quot;:true,&quot;resize&quot;:true,&quot;toolbar&quot;:&quot;zoom layers tags lightbox&quot;,&quot;edit&quot;:&quot;_blank&quot;,&quot;xml&quot;:&quot;&lt;mxfile host=\&quot;app.diagrams.net\&quot; modified=\&quot;2023-06-03T01:09:27.071Z\&quot; agent=\&quot;Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36\&quot; etag=\&quot;M8jIFrcVX_pmqZvsO8RT\&quot; version=\&quot;21.3.7\&quot; type=\&quot;github\&quot;&gt;\n  &lt;diagram id=\&quot;kgpKYQtTHZ0yAKxKKP6v\&quot; name=\&quot;Page-1\&quot;&gt;\n    &lt;mxGraphModel dx=\&quot;1434\&quot; dy=\&quot;764\&quot; grid=\&quot;1\&quot; gridSize=\&quot;10\&quot; guides=\&quot;1\&quot; tooltips=\&quot;1\&quot; connect=\&quot;1\&quot; arrows=\&quot;1\&quot; fold=\&quot;1\&quot; page=\&quot;1\&quot; pageScale=\&quot;1\&quot; pageWidth=\&quot;850\&quot; pageHeight=\&quot;1100\&quot; math=\&quot;0\&quot; shadow=\&quot;0\&quot;&gt;\n      &lt;root&gt;\n        &lt;mxCell id=\&quot;0\&quot; /&gt;\n        &lt;mxCell id=\&quot;1\&quot; parent=\&quot;0\&quot; /&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-8\&quot; value=\&quot;\&quot; style=\&quot;whiteSpace=wrap;html=1;aspect=fixed;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;290\&quot; y=\&quot;160\&quot; width=\&quot;340\&quot; height=\&quot;340\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-3\&quot; value=\&quot;CLIENT\&quot; style=\&quot;rounded=1;whiteSpace=wrap;html=1;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;20\&quot; y=\&quot;140\&quot; width=\&quot;80\&quot; height=\&quot;370\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-4\&quot; value=\&quot;COMMAND\&quot; style=\&quot;shape=singleArrow;whiteSpace=wrap;html=1;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;100\&quot; y=\&quot;160\&quot; width=\&quot;110\&quot; height=\&quot;100\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-5\&quot; value=\&quot;QUERY\&quot; style=\&quot;shape=singleArrow;whiteSpace=wrap;html=1;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;100\&quot; y=\&quot;400\&quot; width=\&quot;120\&quot; height=\&quot;100\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-30\&quot; style=\&quot;edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;\&quot; edge=\&quot;1\&quot; parent=\&quot;1\&quot; source=\&quot;xW6dC_726F_BnDqgVRCd-6\&quot; target=\&quot;xW6dC_726F_BnDqgVRCd-26\&quot;&gt;\n          &lt;mxGeometry relative=\&quot;1\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-6\&quot; value=\&quot;WRITE API\&quot; style=\&quot;rounded=0;whiteSpace=wrap;html=1;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;220\&quot; y=\&quot;170\&quot; width=\&quot;120\&quot; height=\&quot;80\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-31\&quot; style=\&quot;edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;entryX=0.25;entryY=1;entryDx=0;entryDy=0;\&quot; edge=\&quot;1\&quot; parent=\&quot;1\&quot; source=\&quot;xW6dC_726F_BnDqgVRCd-7\&quot; target=\&quot;xW6dC_726F_BnDqgVRCd-26\&quot;&gt;\n          &lt;mxGeometry relative=\&quot;1\&quot; as=\&quot;geometry\&quot;&gt;\n            &lt;Array as=\&quot;points\&quot;&gt;\n              &lt;mxPoint x=\&quot;420\&quot; y=\&quot;430\&quot; /&gt;\n              &lt;mxPoint x=\&quot;420\&quot; y=\&quot;360\&quot; /&gt;\n            &lt;/Array&gt;\n          &lt;/mxGeometry&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-7\&quot; value=\&quot;READ API\&quot; style=\&quot;rounded=0;whiteSpace=wrap;html=1;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;220\&quot; y=\&quot;410\&quot; width=\&quot;120\&quot; height=\&quot;80\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-33\&quot; style=\&quot;edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;entryX=1;entryY=0.5;entryDx=0;entryDy=0;\&quot; edge=\&quot;1\&quot; parent=\&quot;1\&quot; source=\&quot;xW6dC_726F_BnDqgVRCd-9\&quot; target=\&quot;xW6dC_726F_BnDqgVRCd-26\&quot;&gt;\n          &lt;mxGeometry relative=\&quot;1\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-9\&quot; value=\&quot;&amp;lt;br&amp;gt;DOMAIN MODEL\&quot; style=\&quot;rounded=0;whiteSpace=wrap;html=1;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;460\&quot; y=\&quot;180\&quot; width=\&quot;130\&quot; height=\&quot;60\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-32\&quot; style=\&quot;edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;\&quot; edge=\&quot;1\&quot; parent=\&quot;1\&quot; source=\&quot;xW6dC_726F_BnDqgVRCd-10\&quot;&gt;\n          &lt;mxGeometry relative=\&quot;1\&quot; as=\&quot;geometry\&quot;&gt;\n            &lt;mxPoint x=\&quot;490\&quot; y=\&quot;360\&quot; as=\&quot;targetPoint\&quot; /&gt;\n          &lt;/mxGeometry&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-10\&quot; value=\&quot;WRITE API\&quot; style=\&quot;rounded=0;whiteSpace=wrap;html=1;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;420\&quot; y=\&quot;440\&quot; width=\&quot;170\&quot; height=\&quot;40\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-11\&quot; value=\&quot;COMMAND\&quot; style=\&quot;shape=singleArrow;whiteSpace=wrap;html=1;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;630\&quot; y=\&quot;160\&quot; width=\&quot;110\&quot; height=\&quot;100\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-12\&quot; value=\&quot;QUERY\&quot; style=\&quot;shape=singleArrow;whiteSpace=wrap;html=1;rotation=-180;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;640\&quot; y=\&quot;390\&quot; width=\&quot;100\&quot; height=\&quot;100\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-13\&quot; value=\&quot;RELATIONAL\&quot; style=\&quot;shape=cylinder3;whiteSpace=wrap;html=1;boundedLbl=1;backgroundOutline=1;size=15;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;750\&quot; y=\&quot;170\&quot; width=\&quot;60\&quot; height=\&quot;100\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-15\&quot; value=\&quot;NON RELATIONAL\&quot; style=\&quot;shape=cylinder3;whiteSpace=wrap;html=1;boundedLbl=1;backgroundOutline=1;size=15;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;750\&quot; y=\&quot;410\&quot; width=\&quot;60\&quot; height=\&quot;60\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-16\&quot; value=\&quot;SYNC\&quot; style=\&quot;shape=singleArrow;whiteSpace=wrap;html=1;rotation=105;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;750\&quot; y=\&quot;280\&quot; width=\&quot;90\&quot; height=\&quot;100\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-28\&quot; style=\&quot;edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;exitX=1;exitY=0.5;exitDx=0;exitDy=0;entryX=0.523;entryY=1.117;entryDx=0;entryDy=0;entryPerimeter=0;\&quot; edge=\&quot;1\&quot; parent=\&quot;1\&quot; source=\&quot;xW6dC_726F_BnDqgVRCd-26\&quot; target=\&quot;xW6dC_726F_BnDqgVRCd-9\&quot;&gt;\n          &lt;mxGeometry relative=\&quot;1\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-29\&quot; style=\&quot;edgeStyle=orthogonalEdgeStyle;rounded=0;orthogonalLoop=1;jettySize=auto;html=1;\&quot; edge=\&quot;1\&quot; parent=\&quot;1\&quot; source=\&quot;xW6dC_726F_BnDqgVRCd-26\&quot; target=\&quot;xW6dC_726F_BnDqgVRCd-10\&quot;&gt;\n          &lt;mxGeometry relative=\&quot;1\&quot; as=\&quot;geometry\&quot;&gt;\n            &lt;Array as=\&quot;points\&quot;&gt;\n              &lt;mxPoint x=\&quot;520\&quot; y=\&quot;350\&quot; /&gt;\n              &lt;mxPoint x=\&quot;520\&quot; y=\&quot;395\&quot; /&gt;\n              &lt;mxPoint x=\&quot;525\&quot; y=\&quot;395\&quot; /&gt;\n            &lt;/Array&gt;\n          &lt;/mxGeometry&gt;\n        &lt;/mxCell&gt;\n        &lt;mxCell id=\&quot;xW6dC_726F_BnDqgVRCd-26\&quot; value=\&quot;&amp;lt;br&amp;gt;REPOSITORY\&quot; style=\&quot;rounded=0;whiteSpace=wrap;html=1;\&quot; vertex=\&quot;1\&quot; parent=\&quot;1\&quot;&gt;\n          &lt;mxGeometry x=\&quot;360\&quot; y=\&quot;295\&quot; width=\&quot;130\&quot; height=\&quot;65\&quot; as=\&quot;geometry\&quot; /&gt;\n        &lt;/mxCell&gt;\n      &lt;/root&gt;\n    &lt;/mxGraphModel&gt;\n  &lt;/diagram&gt;\n&lt;/mxfile&gt;\n&quot;}"></div>
<script type="text/javascript" src="https://viewer.diagrams.net/js/viewer-static.min.js"></script>
</body>





##https://www.linkedin.com/in/heitorhog/




