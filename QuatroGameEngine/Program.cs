using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace QuatroGameEngine
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(600,400);
            window.Title = "Quatro Engine";
            new GameEngineWindow(window);
        }
    }
}
