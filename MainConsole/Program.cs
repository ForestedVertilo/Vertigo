using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelsLibrary;
using Otter;
using System.Runtime.InteropServices;

namespace MainConsole
{
    class Program
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
           ShowWindow(handle, SW_HIDE);
            Game game = new Game("Vertigo", 320, 240);
            game.SetWindowScale(2);
            game.Color = Color.White;
             game.Start(new StartScene());

        }
    }
}
