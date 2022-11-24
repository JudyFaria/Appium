using ByteBank.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Contas
{
    public class ContaCorrente
    {
        public static int TotalDeContasCriadas { get; set; }

        private int agencia;

        public int Agencia
        {
            get { return agencia; }
            private set { agencia = value; }
        }

        public string Conta { get; set; }

        private double saldo = 100;

        public Cliente Titular { get; set; }

        public void Depositar(double valor)
        {
            saldo += valor;
        }


        public bool Sacar(double valor)
        {

            if (valor <= saldo)
            {
                saldo -= valor;
                return true;
            }
            else { return false; }
        }


        public bool Transferir(double valor, ContaCorrente destino)
        {
            if (valor > saldo)
            {
                return false;
            }
            else
            {
                Sacar(valor);
                destino.Depositar(valor);
                return true;
            }
        }


        public void ExibirInformacao() // Eu fiz com o THIS.
        {
            Console.WriteLine("Titular: " + Titular);
            Console.WriteLine("Agência: " + agencia);
            Console.WriteLine("Conta: " + Conta);
            Console.WriteLine("Saldo: " + saldo);
        }


        public void SetSaldo(double valor)
        {
            if (valor < 0)
            {
                return;
            }
            else
            {
                this.saldo = valor;  
            }
        }

        public double GetSaldo()
        {
            return this.saldo;
        }

        //Método Construtor
        public ContaCorrente(int agencia, string conta )
        { 
            this.Agencia = agencia;
            this.Conta = conta;
            
            TotalDeContasCriadas ++;
        }

    }
   
}