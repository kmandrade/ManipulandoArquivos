using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ManipulandoArquivos
{
    partial class Program
    {
        static void Main(string[] args)
        {




            
            Console.ReadLine();

        }





        static void UtilizandoStreamReader()
        {
            var enderecoDoArquivo = "contas.txt";

            //using para quando finalizar ja fechar o arquivo (finaly)
            //peguei o arquivo atraves do var fluxo do arquivo e disse que iria apenas abrir, depois
            //variavel leitor vai receber a classe StreamReader para ter as proprieades de leitura
            //depois criado logica para ler o arquivo.
            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var leitor = new StreamReader(fluxoDoArquivo);

                while (!leitor.EndOfStream)
                {

                    //lendo o bloco de notas
                    //var linha = leitor.ReadLine();
                    //Console.WriteLine(linha);

                    //colocando os dados do bloco de notas em conta corrente
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);
                    Console.WriteLine($"Agencia da Conta {contaCorrente.Agencia} ,   Numero da Conta {contaCorrente.Numero}" +
                        $"  Saldo da Conta {contaCorrente.Saldo}" +
                        $"  Titular da Conta {contaCorrente.Titular.Nome}");


                }
            }


        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(' ');//pegando o campo que separa meus atributos, vai quebrar a string atraves desse metodo
            //populando as proprieades da conta corrente
            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2];
            var nomeTitular = campos[3];

            int agenciaComoInt = int.Parse(agencia);
            int numComoInt = int.Parse(numero);
            var saldoComoDouble = double.Parse(saldo.Replace('.', ','));//trocar ponto pela virgula

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agenciaComoInt, numComoInt); //lembrar de guardar os resultados em um var para facilitar e ter acesso a propriedades
            resultado.Depositar(saldoComoDouble);
            resultado.Titular = titular;
            
            return resultado;
        }

        static void EscreveArquivo(byte[] buffer, int bytelidos)
        {
            var utf8 = new UTF8Encoding();

            var texto = utf8.GetString(buffer,0,bytelidos); //pega o array , começa da posicao 0 e termina com a quantidade de byts lidos

            Console.WriteLine(texto);

            //foreach (var MyByte in buffer)
            //{
            //    Console.Write(MyByte);
            //    Console.Write(" ");
            //}


        }
        static void UsandoStreamManualmente()
        {
            var enderecoDoArquivo = "contas.txt";
            var buffer = new byte[1024];
            var controleDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);




            var numByteLidos = -1;
            while (numByteLidos != 0)
            {
                numByteLidos = controleDoArquivo.Read(buffer, 0, 1024);
                EscreveArquivo(buffer, numByteLidos);
            }



        }

    }
}
