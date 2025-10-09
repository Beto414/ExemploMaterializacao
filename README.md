# Sistema de Cadastros (ExemploMaterializacao)

## Visão Geral

Este projeto é uma aplicação web desenvolvida com a stack .NET Framework, demonstrando uma arquitetura de N-Camadas para a criação de um sistema de gerenciamento de dados (CRUD). A aplicação inclui módulos para o cadastro de Pacientes e Carros, servindo como um exemplo prático de implementação de padrões de desenvolvimento de software em um ambiente corporativo.

A arquitetura foi projetada para garantir a separação de responsabilidades, manutenibilidade e escalabilidade.

---

## Arquitetura

A solução está dividida nas seguintes camadas (projetos):

-   **Dados:** Responsável pela comunicação com o banco de dados. Utiliza o **Entity Framework** com a abordagem **Database First**, contendo o modelo de dados (`.edmx`) e as entidades geradas.
-   **Repositorio:** Implementa o padrão *Repository Pattern*, abstraindo a lógica de acesso aos dados e as consultas diretas ao `DbContext`.
-   **TO (Transfer Objects):** Contém os Data Transfer Objects (DTOs), classes simples utilizadas para transferir dados entre as camadas, garantindo o desacoplamento.
-   **Negocio:** Camada de regras de negócio. Orquestra as chamadas ao repositório e aplica as validações e lógicas de domínio.
-   **Servico:** Expõe a camada de negócio através de um **Serviço Web ASMX (SOAP)**, servindo como o endpoint de back-end para a aplicação cliente.
-   **Web:** A camada de apresentação (front-end), desenvolvida com **ASP.NET MVC 5**. É responsável por renderizar a interface do usuário, consumir os dados do serviço ASMX e interagir com o usuário.
-   **Testes:** Projeto de testes unitários para validar a lógica da camada de negócio.

---

## Tecnologias Utilizadas

-   **Back-end:** .NET Framework 4.8, C#
-   **Front-end:** ASP.NET MVC 5, Razor, HTML5, CSS3, JavaScript, jQuery, Bootstrap 5
-   **Acesso a Dados:** Entity Framework 6 (Database First)
-   **Banco de Dados:** Microsoft SQL Server Express
-   **Serviço:** ASP.NET Web Service (ASMX/SOAP)
-   **Controle de Versão:** Git & GitHub

---

## Funcionalidades Implementadas

-   **CRUD Completo:** Operações de Criar, Ler, Atualizar e Excluir para as entidades `Paciente` e `Carro`.
-   **Navegação em Camadas:** Fluxo de dados completo, desde a `View` (MVC) até o `Serviço` (ASMX), passando pelas camadas de `Negocio` e `Repositorio` até o banco de dados.
-   **Interface de Usuário Responsiva:** Layout adaptável utilizando Bootstrap.
-   **UX Melhorada:**
    -   Modal de confirmação para operações de exclusão, evitando recarregamento da página (AJAX).
    -   Homepage estruturada como um dashboard de navegação.
    -   Seletor de tema (Light/Dark) com persistência no `localStorage`.

---

## Como Executar o Projeto

1.  **Pré-requisitos:**
    -   Visual Studio 2022 com a carga de trabalho "Desenvolvimento ASP.NET e para a Web".
    -   Microsoft SQL Server Express (instância `SQLEXPRESS01` ou ajuste a string de conexão).
2.  **Configuração do Banco de Dados:**
    -   O banco de dados `ExemploMaterializacao` e suas tabelas podem ser criados executando o script SQL correspondente (se fornecido) ou através da engenharia reversa do modelo.
3.  **Execução:**
    -   Abra a solução (`.sln`) no Visual Studio.
    -   Configure os projetos de inicialização para iniciar múltiplos projetos: `Servico` e `Web`.
    -   Pressione F5 para iniciar a depuração. O Visual Studio iniciará os dois servidores de desenvolvimento e abrirá as páginas nos navegadores.
