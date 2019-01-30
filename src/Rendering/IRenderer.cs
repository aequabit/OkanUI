namespace OkanUI.Rendering
{
    /// <summary>
    /// Abstract for all renderer implementations.
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Renders a matrix.
        /// </summary>
        /// <param name="matrix">Matrix to render.</param>
        void Render(Matrix<Pixel> matrix);

        /// <summary>
        /// Renders a renderable object.
        /// </summary>
        /// <param name="renderable">Object to render.</param>
        void Render(IRenderable renderable);

        /// <summary>
        /// Clears the rendering buffer.
        /// </summary>
        void Clear();
    }
}