# DIO - Trilha.NET - API e Entity Framework

_Versão por:_ **Thiago de Oliveira Miranda**

_Mockup funcional Html/Javascript:_ https://thiagoomiranda.github.io/trilha-net-mvc-mockup/

<br>

## Descrição do desafio:

&emsp;&emsp;Para esse desafio, foram utilizados os conhecimentos adquiridos no módulo **API e Entity Framework**, da trilha **.NET** da **DIO (_Digital Innovation One_)**.

---

<br>

## Contexto:

&emsp;&emsp;Construir um sistema _gerenciador de tarefas_, onde poderá ser agendado com atributos uma lista de tarefas para melhor organizar a rotina. Essa lista de tarefas precisa ter um **_CRUD (Create, Read, Update and Delete)_**, ou seja, deverá permitir criar, editar e deletar registros. A aplicação implementada foi uma **_MVC (Model, View and Controller)_**.

<br>

---

<br>

## Classe principal da Tarefa:

<br>

<p align="center"><img src="wwwroot/images/diagrama.png" alt="Diagrama da classe tarefa" style="width:75%;"></p>

<i style="text-align: center;">

Figura01: Diagrama da classe Tarefa

</i>

<br>

&emsp;&emsp;Foi adicionado, com fins didáticos a propriedade Enum: **Prioridade**. A qual categoriza o nível de prioridade da tarefa nas seguintes classificações: **_mínima, média, máxima e urgente_**.

<br>

---

<br>

## Métodos implementados:

<br>

<img src="wwwroot/images/metodos.png" alt="Métodos da controller" style="width:100%; display: block; margin: 0 auto">

<i style="text-align: center;">

Figura 02: Listagem dos métodos da Controller

</i>

<br>

&emsp;&emsp;**_Criar, Editar, Deletar e Detalhes_**: Contemplam as funções básicas de um CRUD, trocando dados com requisições ao sqlserver através da migration.

<br>

> **_Index_**: Inseridas no método principal, as ações:
>
> - **_sortOrder_**: Consiste nos critérios de ordenação através do **ViewBag** classificados em: **ordenar por Id, Título e Data**.
>
> - **_searchString, SearchDate, searchPriority, searchStatus_**: Lógica implementada para filtrar as tarefas por: **palavras-chave (searchString), data (searchDate), prioridade (searchPriority) e status (searchStatus)**.

<br>

---

<br>

## Interface do usuário:

<br>

<img src="wwwroot/images/telaIndex.png" alt="Tela principal" style="width:100%; display: block; margin: 0 auto">

<i style="text-align: center;">

Figura 03: Tela principal do agendador de Tarefas

</i>

<br>

<img src="wwwroot/images/telaCriar.png" alt="Tela de criação de tarefas" style="width:100%; display: block; margin: 0 auto">

<i style="text-align: center;">

Figura 04: Tela de criação de Tarefas

</i>

<br>

<img src="wwwroot/images/telaEditar.png" alt="Tela de edição de tarefas" style="width:100%; display: block; margin: 0 auto">

<i style="text-align: center;">

Figura 05: Tela de edição de Tarefas

</i>

<br>

<img src="wwwroot/images/telaDetalhes.png" alt="Tela de detalhes da tarefa" style="width:100%; display: block; margin: 0 auto">

<i style="text-align: center;">

Figura 06: Tela de detalhes da Tarefa

</i>

<br>

<img src="wwwroot/images/telaDeletar.png" alt="Tela de deleção da tarefa" style="width:100%; display: block; margin: 0 auto">

<i style="text-align: center;">

Figura 07: Tela de deleção de Tarefas

</i>
