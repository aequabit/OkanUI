using System;
using System.Diagnostics;
using OkanUI.Rendering;
using OkanUI.Templating;

namespace OkanUI.UI
{
    public class Button : Control
    {
        /// <summary>
        /// Text content of the button.
        /// </summary>
        public string Content
        {
            set => Text.Content = value;
        }

        /// <summary>
        /// Width of the button.
        /// </summary>
        public int Width { get; set; } = 8;

        /// <summary>
        /// Height of the button.
        /// </summary>
        public int Height { get; set; } = 1;
        
        /// <summary>
        /// Triggered when the button is clicked.
        /// </summary>
        public event EventHandler<EventArgs> Clicked;

        /// <summary>
        /// Text blueprint.
        /// </summary>
        private Text Text { get; set; } = new Text();

        /// <summary>
        /// Clicks the button.
        /// </summary>
        public void Click()
        {
            // Triger the button click callback
            OnButtonClick(new EventArgs());
        }
        
        /// <inheritdoc cref="IControl.GetMatrix"/>
        public override Matrix<Pixel> GetMatrix()
        {
            // Abbreviate the text content if it is too long
            Text.Content = Text.Content.Abbreviate(Width);

            // Indicate focus
            // TODO: Improve
            if (Focused)
            {
                Text.Color = ConsoleColor.Black;
                Text.Background = ConsoleColor.DarkRed;
            }
            else
            {
                Text.Color = ConsoleColor.White;
                Text.Background = ConsoleColor.DarkGray;
            }
            
            // Compile the blueprint
            return Text.Compile();
        }

        protected virtual void OnButtonClick(EventArgs e)
        {
            // Call the event handler
            Clicked?.Invoke(this, e);
        }
    }
}