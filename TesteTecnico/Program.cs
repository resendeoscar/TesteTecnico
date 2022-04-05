using System;

namespace TesteTecnico
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao;

            Console.WriteLine("[SIMULAÇÃO DE CRÉDITO]");
            do
            {
                Credito credito = new Credito();

                Console.WriteLine("Informe o tipo de crédito. \n [D = CRÉDITO DIRETO | C = CRÉDITO CONSIGNADO | PJ = CRÉD. PESSOA JURÍDICA | PF = CRÉD. PESSOA FÍSICA | I = CRÉD. IMOBILIÁRIO]");
                credito.TipoCredito = Console.ReadLine();

                Console.WriteLine("Informe o valor do crédito.");
                credito.ValorCredito = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Informe a quantidade de parcelas.");
                credito.QuantidadeParcelas = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Informe a data do primeiro vencimento.");
                credito.PrimeiroVencimento = Convert.ToDateTime(Console.ReadLine());
                
                credito.Processar();

                Console.WriteLine("Deseja simular novamente? [s/n]");
                opcao = Console.ReadLine();

                switch(opcao.ToUpper())
                {
                    case "S":
                        Console.WriteLine("Faça uma nova simulação!");
                        break;
                    default:
                        Console.WriteLine("Obrigado por usar a nossa simulação de crédito.");
                        break;                    
                }

            } while(opcao.ToUpper() == "S");
        }
    }
}
