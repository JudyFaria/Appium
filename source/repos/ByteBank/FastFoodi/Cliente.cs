using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodi
{
    public class Pedido
    {
        public string numeroPedido;
        public Cliente cliente;
        public ItensPedido item;
        public Produto totalPedido;
    }

    public class ItensPedido
    {
        public int quantidade;
        public int numero_Pedido;
        public Produto produto1;
        public Produto produto2;
        public Produto produto3;
    }

    public class Produto
    {
        public int codigo_Produto;
        public string descricao;
        public double valor_Unitario;
        public double quantidade;



    }

    public class Cliente
    {
        public string nome;
        public string cpf;
        public string email;
        public Endereço endereço;
    }

    public class Endereço
    {
        public string rua;
        public int numero;
        public string bairro;
        public string cidade;
        public string cep;
    }
}
