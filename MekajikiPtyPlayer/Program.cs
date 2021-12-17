using System;
using MekajikiPtyPlayer.Views;
using Terminal.Gui;

namespace MekajikiPtyPlayer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Application.UseSystemConsole = true;
            Application.Init();
            Application.Top.Add(new ServerSelector());
            Application.Run();
        }
    }
}