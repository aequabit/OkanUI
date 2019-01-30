using System;

namespace OkanUI.Rendering
{
    /// <summary>
    /// Represents a pixel in the drawing process.
    /// </summary>
    public struct Pixel
    {
        /// <summary>
        /// Character to draw.
        /// </summary>
        public char Character;
        
        /// <summary>
        /// Foreground color of the pixel.
        /// </summary>
        public ConsoleColor Color;

        /// <summary>
        /// Background color of the pixel.
        /// </summary>
        public ConsoleColor Background;
    }
}