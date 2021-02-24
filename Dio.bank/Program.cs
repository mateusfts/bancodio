using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dio.bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = MenuInicial(); 
            
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                        
                }
                opcaoUsuario = MenuInicial();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser Transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

       
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);

        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada!");
                return;
            }
            for(int i=0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta");

            Console.WriteLine("Digite 1 para conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo Incial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Credito Inicial: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                    saldo: entradaSaldo,
                                                    credito: entradaCredito,
                                                    nome: entradaNome);
            listContas.Add(novaConta);

        }

        private static string MenuInicial()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao Banco da DIO!");
            Console.WriteLine("Informe a Opção desejada");

            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir nova Conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Corrigir");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
