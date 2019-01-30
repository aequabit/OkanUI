using System;
using System.Collections.Generic;
using OkanUI.Rendering;
using OkanUI.Templating;

namespace OkanUI.UI
{
    public class Window : IRenderable
    {
        /// <summary>
        /// Width of the window.
        /// </summary>
        public int Width { get; set; } = 64;

        /// <summary>
        /// Height of the window.
        /// </summary>
        public int Height { get; set; } = 16;

        /// <summary>
        /// Padding of the content.
        /// </summary>
        public int Padding { get; set; } = 1;

        /// <summary>
        /// Sizes the window to fit the console.
        /// </summary>
        public bool Fullscreen { get; set; } = false;

        /// <summary>
        /// Index of the focused control.
        /// </summary>
        public int FocusedControl { get; set; } = -1;

        /// <summary>
        /// Title of the window.
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// Background color of the window.
        /// </summary>
        public ConsoleColor Background { get; set; } = ConsoleColor.Black;

        /// <summary>
        /// Controls in the window.
        /// </summary>
        public List<Control> Controls { get; } = new List<Control>();

        public void Handle(ConsoleKey key)
        {
            var btn = (Controls[0] as Button);

            if (key == ConsoleKey.DownArrow || key == ConsoleKey.RightArrow)
            {
                if (Controls.Count > FocusedControl + 1)
                {
                    FocusedControl++;
                }
            }
            else if (key == ConsoleKey.UpArrow || key == ConsoleKey.LeftArrow)
            {
                if (FocusedControl > 0)
                {
                    FocusedControl--;
                }
            } else if (key == ConsoleKey.Enter)
            {
                var control = Controls[FocusedControl];
                if (control is Button)
                {
                    ((Button) control).Click();
                }
            }
        }

        /// <inheritdoc cref="IRenderable.GetMatrix"/>
        public Matrix<Pixel> GetMatrix()
        {
            // Apply fullscreen
            if (Fullscreen)
            {
                Height = Console.BufferHeight - 1;
                Width = Console.BufferWidth;
            }


            // Build the window background
            var final = new Rectangle(Height, Width)
            {
                Background = Background,
                Height = Height,
                Width = Width
            }.Compile();

            // Overlay the status bar
            final.Overlay(0, 0, new Rectangle(1, Width)
            {
                Background = ConsoleColor.DarkRed
            }.Compile());

            // Overlay the control
            final.Overlay(0, 0, new Text
            {
                Content = Title,
                Color = ConsoleColor.Black,
                Background = ConsoleColor.DarkRed
            }.Compile());

            // Iterate controls
            for (int i = 0; i < Controls.Count; i++)
            {
                // Get the control
                var control = Controls[i];

                // Update the control focus
                control.Focused = i == FocusedControl;
                
                // Overlay the control
                final.Overlay(control.X + Padding + 1, control.Y + Padding, control.GetMatrix());
            }

            return final;
        }
    }
}