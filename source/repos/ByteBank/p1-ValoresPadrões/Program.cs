ContaCorrente conta = new ContaCorrente();
Console.WriteLine($"Titular da conta: {conta.titular}");
Console.WriteLine($"Número da conta: {conta.conta}");
Console.WriteLine($"Agência: {conta.agencia}");
Console.WriteLine($"Saldo R$ {String.Format("{0:0.00}", conta.saldo)}");

Console.ReadKey();