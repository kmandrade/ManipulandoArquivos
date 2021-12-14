using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ManipulandoArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            var enderecoDoArquivo = "contas.txt";

            var controleDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);

            var buffer = new byte[1024];

            
            var numByteLidos = -1;
            while (numByteLidos != 0)
            {
                numByteLidos = controleDoArquivo.Read(buffer, 0, 1024);
                EscreveArquivo(buffer);
            }


            Console.ReadLine();

        }

        static void EscreveArquivo(byte[] buffer)
        {
            foreach (var MyByte in buffer)
            {
                Console.Write(MyByte);
                Console.Write(" ");
            }
        }
        
    }
}
