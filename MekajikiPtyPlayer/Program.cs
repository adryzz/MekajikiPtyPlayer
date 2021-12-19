using System;
using System.Diagnostics;
using MekajikiPtyPlayer.Views;
using Terminal.Gui;

namespace MekajikiPtyPlayer
{
    public static class Program
    {
        public static Configuration Config;
        public static Process? Mpv;
        public static void Main(string[] args)
        {
            Application.UseSystemConsole = true;
            Application.Init();
            Application.Top.KeyPress += TopOnKeyPress;
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

        private static void TopOnKeyPress(View.KeyEventEventArgs obj)
        {
            if (Mpv is {HasExited: false})
            {
                Mpv?.StandardInput.Write(obj.KeyEvent.KeyValue);
                obj.Handled = true;
            }
        }
    }
}