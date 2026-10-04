using System.Text.Json;

string jsonVendas = """
{
    "vendas": [
                    
            {"vendedor": "João Silva",  "valor": 1200.50 },
            {"vendedor": "João Silva", "valor": 950.75 },
            {"vendedor": "João Silva", "valor": 1800.00 },
            {"vendedor": "João Silva", "valor": 1400.30 },
            {"vendedor": "João Silva", "valor": 1100.90 },
            {"vendedor": "João Silva", "valor": 1550.00 },
            {"vendedor": "João Silva", "valor": 1700.80 },
            {"vendedor": "João Silva", "valor": 250.30 },
            {"vendedor": "João Silva", "valor": 480.75 },
            {"vendedor": "João Silva", "valor": 320.40 },

            {"vendedor": "Maria Souza", "valor": 2100.40 },
            {"vendedor": "Maria Souza", "valor": 1350.60 },
            {"vendedor": "Maria Souza", "valor": 950.20 },
            {"vendedor": "Maria Souza", "valor": 1600.75 },
            {"vendedor": "Maria Souza", "valor": 1750.00 },
            {"vendedor": "Maria Souza", "valor": 1450.90 },
            {"vendedor": "Maria Souza", "valor": 400.50 },
            {"vendedor": "Maria Souza", "valor": 180.20 },
            {"vendedor": "Maria Souza", "valor": 90.75 },

            {"vendedor": "Carlos Oliveira", "valor": 800.50 },
            {"vendedor": "Carlos Oliveira", "valor": 1200.00 },

            {"vendedor": "Carlos Oliveira", "valor": 1950.30 },
            {"vendedor": "Carlos Oliveira", "valor": 1750.80 },
            {"vendedor": "Carlos Oliveira", "valor": 1300.60 },
            {"vendedor": "Carlos Oliveira", "valor": 300.40 },
            {"vendedor": "Carlos Oliveira", "valor": 500.00 },
            {"vendedor": "Carlos Oliveira", "valor": 125.75 },

            {"vendedor": "Ana Lima", "valor": 1000.00 },
            {"vendedor": "Ana Lima", "valor": 1100.50 },
            {"vendedor": "Ana Lima", "valor": 1250.75 },
            {"vendedor": "Ana Lima", "valor": 1400.20 },
            {"vendedor": "Ana Lima", "valor": 1550.90 },
            {"vendedor": "Ana Lima", "valor": 1650.00 },
            {"vendedor": "Ana Lima", "valor": 75.30 },
            { "vendedor": "Ana Lima", "valor": 420.90 },
            { "vendedor": "Ana Lima", "valor": 315.40 }

            
        ]
}
""";



string jsonEstoque = """
{
    "estoque": [
        {"codigoProduto": 101, "descricaoProduto": "Caneta Azul", "estoque": 150},
        {"codigoProduto": 102, "descricaoProduto": "Caderno Universitário", "estoque": 75},
        {"codigoProduto": 103, "descricaoProduto": "Borracha Branca", "estoque": 200},
        {"codigoProduto": 104, "descricaoProduto": "Lápis Preto HB", "estoque": 320},
        {"codigoProduto": 105, "descricaoProduto": "Marcador de Texto Amarelo", "estoque": 90}
    ]
}
""";
Console.WriteLine("========== DESAFIO 1 ==========");




ListaVendas lista = JsonSerializer.Deserialize<ListaVendas>(jsonVendas);
Dictionary<string, decimal> comissoes = new();

foreach (Venda venda in lista.vendas)
{
    decimal comissao = 0;

    if (venda.valor < 100)
    {
        comissao = 0;
    }
    else if (venda.valor < 500)
    {
        comissao = venda.valor * 0.01m;
    }
    else
    {
        comissao = venda.valor * 0.05m;
    }

    if (comissoes.ContainsKey(venda.vendedor))
    {
        comissoes[venda.vendedor] += comissao;
    }
    else
    {
        comissoes.Add(venda.vendedor, comissao);
    }
}


foreach (var item in comissoes)
{
    Console.WriteLine($"Vendedor: {item.Key}, Comissão total: R$ {item.Value:F2}");
    
}
Console.WriteLine("=====================================");
Console.WriteLine("========== DESAFIO 2 ==========");






ListaEstoque listaEstoque = JsonSerializer.Deserialize<ListaEstoque>(jsonEstoque);
List<Movimentacao> movimentacoes = new()
{
    new()
    {
        id = 1,
        tipo = "saida",
        descricao= "Saída de Produto",
        codigoProduto = 101,
        quantidade = 50
    },
    new()
    {
        id = 2,
        tipo = "entrada",
        descricao= "Entrada de Produto",
        codigoProduto = 102,
        quantidade = 75
    },
    new()
    {
        id = 3,
        tipo = "entrada",
        descricao= "Entrada de Produto",
        codigoProduto = 103,
        quantidade = 200
    },
    new()
    {
        id = 4,
        tipo = "saida",
        descricao= "Saída de Produto",
        codigoProduto = 104,
        quantidade = 200
    },
    new()
    {
        id = 5,
        tipo = "saida",
        descricao= "Saída de Produto",
        codigoProduto = 105,
        quantidade = 10
    },
};




static void ProcessarMovimentacao(Movimentacao mov, Produto produto)
{

    if (mov.quantidade <= 0)
    {
        throw new ArgumentException(
            $"Erro: Quantidade inválida na movimentação ID {mov.id}. A quantidade deve ser maior que zero.");
    }


    if (mov.tipo == "entrada")
    {
        produto.estoque += mov.quantidade;

    }
    else if (mov.tipo == "saida")
    {
        if (produto.estoque < mov.quantidade)
        {
            throw new InvalidOperationException($"Erro: Estoque insuficiente para o produto {produto.descricaoProduto}.");

        }

        produto.estoque -= mov.quantidade;

    }
    else
    {
        throw new ArgumentException($"Erro: Tipo de movimentação inválido: {mov.tipo}");
    }
    
}


foreach (Movimentacao mov in movimentacoes) 
{
    try
    {
        Produto produto = listaEstoque.estoque
            .FirstOrDefault(p => p.codigoProduto == mov.codigoProduto);

        if (produto != null)
        {
            ProcessarMovimentacao(mov, produto);

            Console.WriteLine($"ID: {mov.id}, Tipo: {mov.tipo}, Descrição: {mov.descricao}");
            Console.WriteLine($"Produto: {produto.descricaoProduto}, Estoque Atual: {produto.estoque}");
            Console.WriteLine("=====================================");

        }
        else
        {
            throw new KeyNotFoundException(
                $"Erro: Produto com código {mov.codigoProduto} não encontrado no estoque.");
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (KeyNotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine("========== DESAFIO 3 ==========");

decimal valor = 1000m;
DateTime dataVencimento = new DateTime(2026, 10, 02);
decimal percentualDiario = 0.025m;

DateTime diaAtual = DateTime.Today;

TimeSpan atraso = diaAtual.Subtract(dataVencimento);

int diasAtraso = atraso.Days;
decimal juros = 0;
if (diasAtraso < 0)
{
    diasAtraso = 0;
}
juros = valor * percentualDiario * diasAtraso;

Console.WriteLine($"Dias de atraso: {diasAtraso}");
Console.WriteLine($"Juros: {juros:F2}");

