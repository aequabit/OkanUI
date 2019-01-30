using OkanUI.Rendering;

namespace OkanUI.Templating
{
    public interface IBlueprint
    {
        /// <summary>
        /// Compiles a blueprint to a rendering matrix.
        /// </summary>
        /// <returns>Compiled rendering matrix.</returns>
        Matrix<Pixel> Compile();
    }
}