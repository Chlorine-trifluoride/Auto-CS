using System;
using System.Diagnostics;
using System.Linq;
using AutoConsole;
using SDL2;

namespace AutoSDL
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: check for libraries

            Game1 game = new Game1(960, 540); // qHD
            game.Run();
        }
    }
}
