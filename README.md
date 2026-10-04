# Desafio Técnico — Target Sistemas

Solução desenvolvida para o desafio técnico da vaga de **Desenvolvedor de Sistemas Jr. — Target Sistemas**.

## Tecnologias

* C#
* .NET 10
* JSON
* Git
* GitHub

## Estrutura do projeto

```text
DesafioTarget/
├── Desafio1/
│   ├── ListaVendas.cs
│   └── Venda.cs
├── Desafio2/
│   ├── ListaEstoque.cs
│   ├── Movimentacao.cs
│   └── Produto.cs
├── DesafioTarget.csproj
├── DesafioTarget.slnx
├── Program.cs
└── .gitignore
```

## Desafios

### Desafio 1 — Cálculo de comissão

Realiza a leitura dos dados de vendas em JSON, calcula a comissão de cada venda de acordo com as regras fornecidas e consolida o valor total de comissão por vendedor.

As classes relacionadas ao desafio estão organizadas na pasta `Desafio1`.

### Desafio 2 — Movimentação de estoque

Processa movimentações de entrada e saída de produtos, realizando validações de quantidade, tipo de movimentação, existência do produto e disponibilidade do estoque.

As classes relacionadas ao desafio estão organizadas na pasta `Desafio2`.

### Desafio 3 — Cálculo de juros

Calcula os juros de uma cobrança a partir do valor, da data de vencimento e da quantidade de dias em atraso, considerando multa de **2,5% ao dia**.

A implementação do Desafio 3 está diretamente no `Program.cs`.

## Observações

A solução foi desenvolvida priorizando **clareza, organização, validações e separação das responsabilidades**, utilizando os recursos da linguagem C# adequados para cada desafio.
