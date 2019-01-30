using OkanUI.Rendering;

namespace OkanUI.UI
{
    public abstract class Control : IRenderable
    {
        /// <summary>
        /// X position of the control.
        /// </summary>
        public int X { get; set; }
        
        /// <summary>
        /// Y position of the control.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Focus state of the control.
        /// </summary>
        public bool Focused { get; set; } = false;
        
        /// <inheritdoc cref="IControl.GetMatrix"/>
        public virtual Matrix<Pixel> GetMatrix()
        {
            return new Matrix<Pixel>(0, 0);
        }
    }
}