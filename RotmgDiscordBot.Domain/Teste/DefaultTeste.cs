using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotmgDiscordBot.Domain.Teste
{
    public class DefaultTeste : ITeste
    {
        public void Run()
        {
            Console.WriteLine("Teste ok.");
        }
    }
}
