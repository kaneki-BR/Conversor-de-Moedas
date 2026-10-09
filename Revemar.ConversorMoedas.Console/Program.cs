using System;
using System.Globalization;

namespace ConversorMoedas
{
    public enum Moeda
    {
        Real = 1,
        Dolar = 2,
        Euro = 3
    }

    public class Program
    {
        // Taxas fixas em relação ao Real (BRL)
        private const decimal TAXA_DOLAR_EM_BRL = 4.99m;
        private const decimal TAXA_EURO_EM_BRL = 5.59m;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== MONITOR E CONVERSOR DE CÂMBIO ===");
            Console.WriteLine("1 - Real (BRL)");
            Console.WriteLine("2 - Dólar (USD)");
            Console.WriteLine("3 - Euro (EUR)");
            Console.Write("\nEscolha a moeda de origem (1, 2 ou 3): ");

            if (!Enum.TryParse(Console.ReadLine(), out Moeda moedaOrigem) || !Enum.IsDefined(typeof(Moeda), moedaOrigem))
            {
                Console.WriteLine("\n[Erro] Opção de moeda inválida.");
                return;
            }

            Console.Write("Digite o valor a ser convertido: ");
            string? inputValor = Console.ReadLine();

            if (!decimal.TryParse(inputValor, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal valor) &&
                !decimal.TryParse(inputValor, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
            {
                Console.WriteLine("\n[Erro] Valor numérico inválido.");
                return;
            }

            if (valor < 0)
            {
                Console.WriteLine("\n[Erro] O valor deve ser maior ou igual a zero.");
                return;
            }

            ExibirConversoes(moedaOrigem, valor);
        }

        private static void ExibirConversoes(Moeda origem, decimal valor)
        {
            // Culturas para formatação de moeda
            var culturaBrl = new CultureInfo("pt-BR");
            var culturaUsd = new CultureInfo("en-US");
            var culturaEur = new CultureInfo("de-DE"); 

            Console.WriteLine("\n----------------------------------");
            Console.WriteLine($"Valor informado: {FormatarMoeda(valor, origem, culturaBrl, culturaUsd, culturaEur)}");
            Console.WriteLine("----------------------------------");

            switch (origem)
            {
                case Moeda.Real:
                    decimal emDolar = valor / TAXA_DOLAR_EM_BRL;
                    decimal emEuro = valor / TAXA_EURO_EM_BRL;

                    Console.WriteLine($"Em Dólar (USD): {emDolar.ToString("C", culturaUsd)}");
                    Console.WriteLine($"Em Euro (EUR):  {emEuro.ToString("C", culturaEur)}");
                    break;

                case Moeda.Dolar:
                    decimal dolarParaReal = valor * TAXA_DOLAR_EM_BRL;
                    decimal dolarParaEuro = dolarParaReal / TAXA_EURO_EM_BRL;

                    Console.WriteLine($"Em Real (BRL): {dolarParaReal.ToString("C", culturaBrl)}");
                    Console.WriteLine($"Em Euro (EUR): {dolarParaEuro.ToString("C", culturaEur)}");
                    break;

                case Moeda.Euro:
                    decimal euroParaReal = valor * TAXA_EURO_EM_BRL;
                    decimal euroParaDolar = euroParaReal / TAXA_DOLAR_EM_BRL;

                    Console.WriteLine($"Em Real (BRL):  {euroParaReal.ToString("C", culturaBrl)}");
                    Console.WriteLine($"Em Dólar (USD): {euroParaDolar.ToString("C", culturaUsd)}");
                    break;
            }

            Console.WriteLine("----------------------------------");
        }

        private static string FormatarMoeda(decimal valor, Moeda moeda, CultureInfo brl, CultureInfo usd, CultureInfo eur)
        {
            switch (moeda)
            {
                case Moeda.Real:
                    return valor.ToString("C", brl);

                case Moeda.Dolar:
                    return valor.ToString("C", usd);

                case Moeda.Euro:
                    return valor.ToString("C", eur);

                default:
                    return valor.ToString("F2");
            }
        }
    }
}