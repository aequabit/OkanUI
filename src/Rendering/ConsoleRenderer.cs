using System;
using System.Diagnostics;
using OkanUI.Example;

namespace OkanUI.Rendering
{
    public class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Framebuffer.
        /// </summary>
        private Matrix<Pixel> Buffer { get; set; } = new Matrix<Pixel>(0, 0);

        /// <summary>
        /// Height of the last framebuffer.
        /// </summary>
        private int BufferHeight { get; set; } = Console.BufferHeight;

        /// <summary>
        /// Width of the last framebuffer.
        /// </summary>
        private int BufferWidth { get; set; } = Console.BufferWidth;

        /// <inheritdoc cref="IRenderer.Render"/>
        public void Render(Matrix<Pixel> matrix)
        {
            // Hide the cursor if necessary
            if (Console.CursorVisible)
            {
                Console.CursorVisible = false;
            }
            
            // Framebuffer didn't change
            if (matrix.Equals(Buffer))
            {
                // Buffer size didn't change
                if (BufferHeight == Console.BufferHeight || BufferWidth == Console.BufferWidth)
                {
                    return;
                }                

                // Update the buffer size
                BufferHeight = Console.BufferHeight;
                BufferWidth = Console.BufferWidth;
            }

            // Iterate rows
            for (int row = 0; row < matrix.Rows; row++)
            {
                // Iterate columns
                for (int column = 0; column < matrix.Columns; column++)
                {
                    // Do not render the field if it exceeds the console buffer bounds
                    if (row > Console.BufferHeight - 1 || column > Console.BufferWidth - 1)
                    {
                        continue;
                    }

                    // Set the cursor position
                    Console.SetCursorPosition(column, row);

                    // Get the pixel
                    var pixel = matrix.Get(row, column);

                    // Pixel is valid
                    if (matrix.HasField(row, column))
                    {
                        // Set the colors
                        Console.ForegroundColor = pixel.Color;
                        Console.BackgroundColor = pixel.Background;
                        
                        // Write the character
                        Console.Write(pixel.Character);
                    }
                    else
                    {
                        // Reset the background color
                        Console.BackgroundColor = ConsoleColor.Black;

                        // Leave the foreground empty
                        Console.Write(' ');
                    }
                }

                // End the row
                Console.Write('\n');

                // Update the framebuffer.
                Buffer = matrix;
            }
        }

        /// <inheritdoc cref="IRenderer.Render"/>
        public void Render(IRenderable renderable)
        {
            Render(renderable.GetMatrix());
        }

        /// <inheritdoc cref="IRenderer.Clear"/>
        public void Clear()
        {
            // Override the framebuffer with an empty matrix
            Buffer = new Matrix<Pixel>(0, 0);
        }
    }
}