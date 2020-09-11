// Author: Peyman Azami

using System;
namespace RationalNumbers
{
    /// <summary>
    /// IRationalNumber interface supports representation of rational numbers and various operations with them.
    /// </summary>
    public interface IRationalNumber
    {
        /// <summary>
        /// Get the numerator of the rational number.
        /// </summary>
        int Numerator { get; }

        /// <summary>
        /// Get the denominator of the rational number.
        /// </summary>
        int Denominator { get; }

        /// <summary>
        /// Sums up this rational number with <paramref name="number"/>. 
        /// This method does not modify existing rational numbers.
        /// </summary>
        /// <param name="number">A rational number.</param>
        /// <returns>A new rational number that is the sum of this and <paramref name="number"/>.</returns>
        IRationalNumber Add(IRationalNumber number);

        /// <summary>
        /// Subtracts <paramref name="number"/> from this rational number.
        /// This method does not modify existing rational numbers.
        /// </summary>
        /// <param name="number">A rational number.</param>
        /// <returns>A new rational number that is the difference of this and <paramref name="number"/>.</returns>
        IRationalNumber Subtract(IRationalNumber number);

        /// <summary>
        /// Multiplies this rational number with <paramref name="number"/>.
        /// This method does not modify existing rational numbers.
        /// </summary>
        /// <param name="number">A rational number.</param>
        /// <returns>The product of this rational number and <paramref name="number"/>.</returns>
        IRationalNumber Multiply(IRationalNumber number);

        /// <summary>
        /// Divides this rational number by <paramref name="number"/>.
        /// This method does not modify existing rational numbers.
        /// </summary>
        /// <param name="number">A rational number.</param>
        /// <returns>A new rational number that is the quotient of this and <paramref name="number"/>.</returns>
        IRationalNumber Divide(IRationalNumber number);

        /// <summary>
        /// Gets the absolute value of this rational number.
        /// </summary>
        /// <returns>A new rational number that is the absolute value of this rational number.</returns>
        IRationalNumber Abs();

        /// <summary>
        /// Raises this rational number to <paramref name="power"/>.
        /// This method does not modify existing rational numbers.
        /// </summary>
        /// <param name="power">An integer.</param>
        /// <returns>A new rational number that is this rational number raised to <paramref name="power"/>.</returns>
        IRationalNumber ExpRational(int power);

        /// <summary>
        /// Raises <paramref name="baseNumber"/> to this rational number.
        /// </summary>
        /// <param name="baseNumber"></param>
        /// <returns>A real number that is the result of <paramref name="baseNumber"/> raised to this rational number.</returns>
        double ExpReal(int baseNumber);
    }
}
