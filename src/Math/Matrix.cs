using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace OkanUI.Rendering
{
    public class Matrix<T>
    {
        /// <summary>
        /// Vertical length of the matrix.
        /// </summary>
        public int Rows { get; }

        /// <summary>
        /// Horizontal length of the matrix.
        /// </summary>
        public int Columns { get; }

        /// <summary>
        /// Internal matrix.
        /// </summary>
        public T[,] Internal { get; private set; }

        /// <summary>
        /// Creates an empty matrix.
        /// </summary>
        /// <param name="rows"><see cref="Rows"/></param>
        /// <param name="columns"><see cref="Columns"/></param>
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Internal = new T[rows, columns];
        }

        /// <summary>
        /// Creates a matrix from a template.
        /// </summary>
        /// <param name="rows"><see cref="Rows"/></param>
        /// <param name="columns"><see cref="Columns"/></param>
        /// <param name="template">Template to create the matrix from.</param>
        public Matrix(int rows, int columns, T[,] template)
        {
            Rows = rows;
            Columns = columns;

            // Template exceeds the bounds of the matrix
            if (!ValidateTemplateBounds(template))
            {
                throw new Exception("Template bounds exceed matrix bounds");
            }

            Internal = template;
        }

        /// <summary>
        /// Array operator.
        /// </summary>
        /// <param name="row">Row to get.</param>
        /// <param name="column">Column to get.</param>
        public T this[int row, int column]
        {
            get => Internal[row, column];
        }

        /// <summary>
        /// Checks if a field exists in the matrix.
        /// </summary>
        /// <param name="row">Row of the field.</param>
        /// <param name="column">Column of the field.</param>
        /// <returns></returns>
        public bool HasField(int row, int column)
        {
            return
                // Verify amount of rows
                row < Rows &&

                // Verify amount of columns
                column < Columns &&

                // Check for the default type value
                !Get(row, column).Equals(default(T));
        }

        /// <summary>
        /// Gets a field from the matrix.
        /// </summary>
        /// <param name="row">Row of the field.</param>
        /// <param name="column">Column of the field.</param>
        /// <returns></returns>
        public T Get(int row, int column) => Internal[row, column];

        /// <summary>
        /// Inserts a field into the matrix.
        /// </summary>
        /// <param name="row">Row of the field.</param>
        /// <param name="column">Column of the field.</param>
        /// <param name="value">Value to insert into the field.</param>
        public void Insert(int row, int column, T value) => Internal[row, column] = value;

        /// <summary>
        /// Compares two matrices.
        /// </summary>
        /// <param name="matrix">Matrix to compare against.</param>
        /// <returns>True if the matrices are equal.</returns>
        public bool Equals(Matrix<T> matrix)
        {
            // Matrix has a different size
            if (Rows != matrix.Rows || Columns != matrix.Columns)
            {
                return false;
            }

            // TODO: Improve matrix comparison

            // Iterate rows
            for (int x = 0; x < Rows; x++)
            {
                // Iterate columns
                for (int y = 0; y < Columns; y++)
                {
                    // Fields are not equal
                    if (!Internal[x, y].Equals(matrix.Get(x, y)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Overlays two matrices.
        /// </summary>
        /// <param name="row">Row of the anchor.</param>
        /// <param name="column">Column of the anchor.</param>
        /// <param name="matrix">Matrix to overlay.</param>
        /// <returns>The combined matrices.</returns>
        public Matrix<T> Overlay(int row, int column, Matrix<T> matrix)
        {
            // Copy the current matrix
            var copy = (Matrix<T>) MemberwiseClone();

            // Iterate rows
            for (int i = row; i < row + matrix.Rows; i++)
            {
                // Iterate columns
                for (int j = column; j < column + matrix.Columns; j++)
                {
                    // Check if the overlay matrix has a field to overlay
                    if (HasField(i, j) && matrix.HasField(i - row, j - column))
                    {
                        // Insert the field
                        copy.Insert(i, j, matrix[i - row, j - column]);
                    }
                }
            }

            return copy;
        }

        /// <summary>
        /// Validates the bounds of a template.
        /// </summary>
        /// <param name="template">Template to validate.</param>
        /// <returns>Validity of the template.</returns>
        public bool ValidateTemplateBounds(T[,] template)
        {
            return
                // Verify amount of rows
                template.GetLength(0) <= Rows &&

                // Verify amount of columns
                template.GetLength(1) <= Columns;
        }
    }
}