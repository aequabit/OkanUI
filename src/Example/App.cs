using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using OkanUI.Rendering;
using OkanUI.Templating;
using OkanUI.UI;

namespace OkanUI.Example
{
    public class App
    {
        struct Vehicle
        {
            public string Name;
        }

        struct Parkingspace
        {
            public int Id;
            public string LicensePlate;
        }

        struct Parkhouse
        {
            public List<Parkingspace> Parkingspaces;
        }

        public static void Main(string[] args)
        {
            var renderer = new ConsoleRenderer();

            var w = new Window
            {
                Title = "Test window",
                Fullscreen = true
            };

            var button = new Button
            {
                Content = "Do stuff",
                Width = 8,
                X = 0,
                Y = 0,
            };
            
            button.Clicked += (sender, eventArgs) => w.Title = "did stuff";

            w.Controls.Add(button); 
            
            var button2 = new Button
            {
                Content = "Do things",
                Width = 8,
                X = 5,
                Y = 75,
            };

            button2.Clicked += (sender, eventArgs) => w.Title = "did things";

            w.Controls.Add(button2);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                 w.Handle(Console.ReadKey().Key);   
                }
                
                renderer.Render(w);

                Thread.Sleep(1);
            }
        }
    }
}