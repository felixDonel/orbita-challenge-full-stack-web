### projeto orbita-challenge-full-stack-web - Processo Seletivo

## Decisão da Arquitetura Utilizada
Ao desenvolver o projeto, optei por uma arquitetura modular que segue as melhores práticas e favorece a manutenção e escalabilidade. Organizei o código em Quatro camadas principais: Domain, Application, Data, e API.

**API**
Na camada API, concentrei os controladores, rotas e a lógica específica da interface de programação do aplicativo. Essa camada é responsável por receber requisições HTTP, interagir com a camada de Application e retornar as respostas adequadas.

**Application**
Na camada Application, gerencio as regras de negócios e a coordenação das operações do aplicativo. Aqui, aplico as lógicas de serviço, orquestrando as chamadas necessárias à camada de Data para manipulação de dados. Essa camada serve como uma ponte entre a API e a camada de Domain.

**Domain**
Na camada Domain, concentrei a lógica de negócios e as entidades principais do sistema. Essa camada representa o núcleo do meu aplicativo e contém as regras de negócios, modelos de dados e serviços essenciais.

**Data**
Na camada Data, gerencio o acesso aos dados e as interações com o banco de dados. Utilizando EntityFramework, manipulo as entidades do banco de dados e executo operações de leitura e gravação.

## Bibliotecas
Frontend (Vue.js):
- Vuetify: utilizado para criar uma interface de usuário moderna e responsiva.
- Vue Router: Gerenciamento de rotas para o Vue.js, facilitando a navegação entre as páginas do aplicativo.
- Axios: utilizado para realizar requisições HTTP para o backend.

Backend (.NET):
- Fluent Validation: Biblioteca utilizada para implementar regras de validação, facilitando a validação.
- xUnit: Framework de teste unitário para .NET.
- Moq: Biblioteca de mocking para .NET.
- Pomelo.EntityFrameworkCore.MySql: Provedor do Entity Framework Core para MySQL.

## O que você melhoraria se tivesse mais tempo
- Utilizar o Vuex: penso que é uma ferramenta que iria ajudar pra evolução do projeto.
- maior cobertura de testes, aumentaria a quantidade de teste unitario realizado no projeto.
