
using FastFoodi;

Cliente cliente1 = new Cliente();

//NÚMERO DO PEDIDO
cliente1.numeroPedido = "123";
cliente1.cliente = new Cliente();

//INFORMAÇÕES DO CLIENTE
cliente1.cliente.nome = "Judy";
cliente1.cliente.cpf = "123.456.789.01";
cliente1.cliente.email = "judy@gmail.com";

//iNFORMAÇÕES DE ITENS
cliente1.item = new ItensPedido();
cliente1.item.quantidade = 4;
cliente1.item.numero_Pedido = 2;

//INFORMAÇÕES - PRODUTO 1
cliente1.item.produto1 = new Produto();
cliente1.item.produto1.codigo_Produto = 321;
cliente1.item.produto1.descricao = "X-Tudo";
cliente1.item.produto1.valor_Unitario = 12.00;
cliente1.item.produto1.quantidade = 2;

//INRFORMAÇÕES - PRODUTO 2
cliente1.item.produto2 = new Produto();
cliente1.item.produto2.codigo_Produto = 021;
cliente1.item.produto2.descricao = "Refrigerente - 500ml";
cliente1.item.produto2.valor_Unitario = 7.00;
cliente1.item.produto2.quantidade = 2;

//INFORMAÇÕES - PRODUTO 3
cliente1.item.produto3 = new Produto();
cliente1.item.produto3.codigo_Produto = 0;
cliente1.item.produto3.descricao = "";
cliente1.item.produto3.valor_Unitario = 0;
cliente1.item.produto3.quantidade = 0;

//INFORMAÇÕES DE ENDERREÇO PARA ENTREGRA
cliente1.cliente.endereço = new Endereço();
cliente1.cliente.endereço.rua = "Santo Antônio";
cliente1.cliente.endereço.numero = 62;
cliente1.cliente.endereço.bairro = "São Cristóvão";
cliente1.cliente.endereço.cidade = "Rio de Janeiro";
cliente1.cliente.endereço.cep = "20.921-180";

//TOTAL DO PEDIDO
//cliente1.totalPedido = new Produto();
//cliente1.totalPedido = cliente1.item.produto1.valor_Unitario + cliente1.item.produto2.valor_Unitario + cliente1.item.produto3.valor_Unitario;


//IMPRIMINDO AS INFORMAÇOES NO CONSOLE

Console.WriteLine("N° do Pedido: " + cliente1.numeroPedido);

Console.WriteLine();

Console.WriteLine("INFORMAÇÕES DO CLIENTE:");
Console.WriteLine("Nome: " + cliente1.cliente.nome);
Console.WriteLine("CPF: " + cliente1.cliente.cpf);
Console.WriteLine("Email : " + cliente1.cliente.email);

Console.WriteLine();

Console.WriteLine("ITENS: ");
Console.WriteLine("Quant. Itens: " + cliente1.item.quantidade);

Console.WriteLine();

Console.WriteLine("PRODUTOS: ");
Console.WriteLine();

Console.WriteLine("Código - " + cliente1.item.produto1.codigo_Produto);
Console.WriteLine("Descrição - " + cliente1.item.produto1.descricao);
Console.WriteLine("Valor Unit. - R$ " + cliente1.item.produto1.valor_Unitario);
Console.WriteLine("Quant. - " + cliente1.item.produto1.quantidade);

Console.WriteLine();

Console.WriteLine(" Código - " + cliente1.item.produto2.codigo_Produto);
Console.WriteLine("Decrição - " + cliente1.item.produto2.descricao);
Console.WriteLine("Valor Unit. R$ - " + cliente1.item.produto2.valor_Unitario);
Console.WriteLine("Quant.- " + cliente1.item.produto1.quantidade);

Console.WriteLine();

Console.WriteLine("Valor Total do Pedido: " + cliente1.totalPedido);

Console.WriteLine();

Console.WriteLine("ENDEREÇO DE ENTREGA: ");
Console.WriteLine("Rua " + cliente1.cliente.endereço.rua);
Console.WriteLine("N° " + cliente1.cliente.endereço.numero);
Console.WriteLine("Bairro: " + cliente1.cliente.endereço.bairro);
Console.WriteLine("Cidade: " + cliente1.cliente.endereço.cidade);
Console.WriteLine("CEP: " + cliente1.cliente.endereço.cep);