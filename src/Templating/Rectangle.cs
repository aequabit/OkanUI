using System;
using OkanUI.Rendering;

namespace OkanUI.Templating
{
    public class Rectangle : IBlueprint
    {
        /// <summary>
        /// Width of the rectangle.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the rectangle.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Character to fill the rectangle with.
        /// </summary>
        public char Content { get; set; } = ' ';

        /// <summary>
        /// Color of the content.
        /// </summary>
        public ConsoleColor Color { get; set; } = ConsoleColor.White;

        /// <summary>
        /// Background color of the content.
        /// </summary>
        public ConsoleColor Background { get; set; } = ConsoleColor.Black;

        /// <summary>
        /// Creates a rectangle blueprint.
        /// </summary>
        /// <param name="height"><see cref="Height"/></param>
        /// <param name="width"><see cref="Width"/></param>
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        /// <inheritdoc cref="IBlueprint.Compile"/>
        public Matrix<Pixel> Compile()
        {
            // Create the template
            var template = new Pixel[Height, Width];

            // Iterate rows
            for (int row = 0; row < Height; row++)
            {
                // Iterate columns
                for (int column = 0; column < Width; column++)
                {
                    // Add the pixel to the column
                    template[row, column] = new Pixel {Character = Content, Color = Color, Background = Background};
                }
            }

            // Create the matrix
            return new Matrix<Pixel>(Height, Width, template);
        }
    }
}