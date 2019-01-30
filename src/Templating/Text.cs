using System;
using OkanUI.Rendering;

namespace OkanUI.Templating
{
    public class Text : IBlueprint
    {
        /// <summary>
        /// Text content.
        /// </summary>
        public string Content { get; set; } = "";

        /// <summary>
        /// Color of the text.
        /// </summary>
        public ConsoleColor Color { get; set; } = ConsoleColor.White;

        /// <summary>
        /// Background color of the text.
        /// </summary>
        public ConsoleColor Background { get; set; } = ConsoleColor.DarkGray;

        /// <inheritdoc cref="IBlueprint.Compile"/>
        public Matrix<Pixel> Compile()
        {
            // Create the template
            var template = new Pixel[1, Content.Length];

            // Iterate all characters of the content
            for (int i = 0; i < Content.Length; i++)
            {
                // Add the pixel
                template[0, i] = new Pixel {Character = Content[i], Color = Color, Background = Background};
            }

            // Create the matrix
            return new Matrix<Pixel>(1, Content.Length, template);
        }
    }
}