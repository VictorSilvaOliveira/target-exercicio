Teste - Desenvolvedor Full Stack
Pergunta 1 de 1

Criar uma tela de extrato de conta corrente, onde eu possa listar os lançamentos da conta corrente feitos de forma avulsa ou não. Além disso, que eu também possa nessa tela, inserir, alterar, e cancelar lançamento avulsos válidos.

 
Critérios de Aceite de Negócio:

- As propriedades de cada lançamento são: Id, descrição, data, valor, avulso, status.
- O status pode ser “Válido” ou “Cancelado”
- O Id deve ser o identificador único do lançamento
- A descrição deve ser alfanumérica para ajudar o usuário a identificar o lançamento
- A data deve ser a data que foi feito o lançamento na conta corrente
- O valor do lançamento pode ser positivo ou negativo
- O lançamento pode ser avulso (lançamento pelo usuário manualmente), ou não (lançamento por algum processo).
- A tela do extrato deve ter um filtro de range de data, e a range inicial deve ser 2 dias. Dessa forma, deve vir mostrando os dados do extrato referente a esses últimos 2 dias.
- Ao mudar as datas deve carregar os lançamentos de acordo com as novas datas
- Deve ser possível incluir um lançamento válido no extrato de forma avulsa (deve ser identificado no extrato como avulso)
- Deve ser possível alterar um lançamento avulso e válido do extrato, onde poderá ser alterado somente o valor e a data.
- Deve ser possível cancelar um lançamento válido e avulso do extrato
- Deve existir um totalizador mostrando o valor total dos lançamentos que foram listados no extrato.
- Deve existir uma rota na API para inserir um lançamento NÃO AVULSO na conta corrente, deve receber a descrição, valor e data. Lançamento deve ser gerado como “Não Avulso” e “Válido”.

Critérios de Aceite Técnicos:

- Obrigatório utilizar frontend em Angular
- Obrigatório utilizar backend em .NET (preferencialmente .NET 6)
- Recomendado utilizar SPA, dessa forma, teremos um serviço apenas para a API e o APP (o template do próprio - Visual Studio já cria a API dessa forma).
- Obrigatório utilizar Entity Framework de ORM para persistência.
- Recomendado utilizar Material Angular para os objetos da tela, como inputs, tabelas, grids, ou o que for do agrado para criação da página.
- É obrigatório que a comunicação entre APP e API seja REST utilizando JSON para as comunicações que necessitam de um objeto.
- Não tem restrição paras a arquitetura a ser utilizada, porém é recomendado que seja utilizado alguma arquitetura para organização do código do front e do back.
