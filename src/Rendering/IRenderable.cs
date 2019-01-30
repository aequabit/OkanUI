namespace OkanUI.Rendering
{
    public interface IRenderable
    {
        /// <summary>
        /// Gets the rendering matrix.
        /// </summary>
        /// <returns>Rendering matrix.</returns>
        Matrix<Pixel> GetMatrix();
    }
}