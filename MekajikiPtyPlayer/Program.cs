using System;
using MekajikiPtyPlayer.Views;
using Terminal.Gui;

namespace MekajikiPtyPlayer
{
    public static class Program
    {
        public static Configuration Config;
        public static void Main(string[] args)
        {
            Application.UseSystemConsole = true;
            Application.Init();
            if (Configuration.Exists("config.json"))
            {
                Config = Configuration.FromFile("config.json");
                Application.Top.Add(new AnimeSelector());
            }
            else
            {
                Application.Top.Add(new ServerSelector());
            }
            Application.Run();
        }
    }
}