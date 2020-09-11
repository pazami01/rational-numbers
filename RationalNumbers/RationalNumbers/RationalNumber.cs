// Author: Peyman Azami

using System;

namespace RationalNumbers
{
    /// <summary>
    /// RationalNumber struct encapsulates the numerator and denominator fields.
    /// Objects of this type are to be used as rational numbers.
    /// </summary>
    public struct RationalNumber : IRationalNumber
    {
        /// <summary>
        /// Access and set the numerator property for the rational number.
        /// </summary>
        public int Numerator { get; private set; }

        /// <summary>
        /// Access and set the denominator property for the rational number.
        /// Must not be less than or equal to zero.
        /// </summary>
        public int Denominator { get; private set; }

        /// <summary>
        /// Constructs a new rational number.
        /// On construction, the rational number is reduced to its lowest form.
        /// Zero is stored as 0/1.
        /// A negative rational is stored with a negative numerator and a positive denominator.
        /// </summary>
        /// <param name="numerator">An integer as the numerator.</param>
        /// <param name="denominator">An integer as the denominator. May not be zero.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="denominator"/> is zero.</exception>
        public RationalNumber(int numerator = 0, int denominator = 1)
        {
            if (denominator == 0)
            {
                throw new ArgumentOutOfRangeException("Denominator must not be zero.");
            }

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            Numerator = numerator;
            Denominator = denominator;

            Reduce();
        }

        /// <summary>
        /// Returns a new rational number that is the sum of <paramref name="r1"/> and <paramref name="r2"/>.
        /// </summary>
        /// <param name="r1">A rational number.</param>
        /// <param name="r2">A rational number.</param>
        /// <returns>The sum of <paramref name="r1"/> and <paramref name="r2"/>.</returns>
        public static IRationalNumber operator +(RationalNumber r1, RationalNumber r2) => r1.Add(r2);

        /// <summary>
        /// Returns a new rational number that is the difference between <paramref name="r1"/> and <paramref name="r2"/>.
        /// </summary>
        /// <param name="r1">A rational number.</param>
        /// <param name="r2">A rational number.</param>
        /// <returns>The difference between <paramref name="r1"/> and <paramref name="r2"/>.</returns>
        public static IRationalNumber operator -(RationalNumber r1, RationalNumber r2) => r1.Subtract(r2);

        /// <summary>
        /// Returns a new rational number that is the product of <paramref name="r1"/> and <paramref name="r2"/>.
        /// </summary>
        /// <param name="r1">A rational number.</param>
        /// <param name="r2">A rational number.</param>
        /// <returns>The product of <paramref name="r1"/> and <paramref name="r2"/>.</returns>
        public static IRationalNumber operator *(RationalNumber r1, RationalNumber r2) => r1.Multiply(r2);


        /// <summary>
        /// Returns a new rational number that is the quotient of <paramref name="r1"/> and <paramref name="r2"/>.
        /// </summary>
        /// <param name="r1">A rational number.</param>
        /// <param name="r2">A rational number.</param>
        /// <returns>The quotient of <paramref name="r1"/> and <paramref name="r2"/>.</returns>
        public static IRationalNumber operator /(RationalNumber r1, RationalNumber r2) => r1.Divide(r2);

        /// <summary>
        /// Gets the absolute value of this rational number.
        /// </summary>
        /// <returns>A new rational number that is the absolute value of this rational number.</returns>
        public IRationalNumber Abs()
        {
            return new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator));
        }

        /// <summary>
        /// Reduces this rational number to its simplest form.
        /// This method modifies the properties of this rational number.
        /// </summary>
        private void Reduce()
        {
            int gcd = GetGCD();

            Numerator /= gcd;
            Denominator /= gcd;
        }

        /// <summary>
        /// Gets the greatest common divisor of the numerator and denominator of this rational number.
        /// </summary>
        /// <returns>The greatest common divisor of the numerator and denominator.</returns>
        private int GetGCD()
        {
            int numOne = Numerator < 0 ? -Numerator : Numerator;
            int numTwo = Denominator;

            while (numTwo != 0)
            {
                int remainder = numOne % numTwo;
                numOne = numTwo;
                numTwo = remainder;
            }

            return numOne;
        }

        /// <summary>
        /// Raises this rational number to <paramref name="power"/>.
        /// This method does not modify existing rational numbers.
        /// </summary>
        /// <param name="power">An integer.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when raising the rational number zero to a negative <paramref name="power"/>.</exception>
        /// <returns>A new rational number that is this rational number raised to <paramref name="power"/>.</returns>
        public IRationalNumber ExpRational(int power)
        {
            if (power < 0)
            {
                int newPower = Math.Abs(power);

                try
                {
                    return new RationalNumber((int)Math.Pow(Denominator, newPower), (int)Math.Pow(Numerator, newPower));
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException("Cannot raise zero to a negative power.");
                }
            }

            return new RationalNumber((int)Math.Pow(Numerator, power), (int)Math.Pow(Denominator, power));
        }
        
        /// <summary>
        /// Raises <paramref name="baseNumber"/> to this rational number.
        /// </summary>
        /// <param name="baseNumber"></param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when this rational number is negative and <paramref name="baseNumber"/> is zero.</exception>
        /// <returns>A real number that is the result of <paramref name="baseNumber"/> raised to this rational number.</returns>
        public double ExpReal(int baseNumber)
        {
            if (baseNumber == 0 && Numerator < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot raise 0 to a negative rational number.");
            }

            return Math.Pow(baseNumber, (double)Numerator / Denominator);
        }

        /// <summary>
        /// Sums up this rational number with <paramref name="number"/>. 
        /// This method does not modify existing rational numbers.
        /// </summary>
        /// <param name="number">A rational number.</param>
        /// <returns>A new rational number that is the sum of this and <paramref name="number"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="number"/> is null.</exception>
        public IRationalNumber Add(IRationalNumber number)
        {
            if (number == null)
            {
                throw new ArgumentNullException("Number cannot be null.");
            }

            int newNumerator = Numerator * number.Denominator + Denominator * number.Numerator;
            int newDenominator = Denominator * number.Denominator;
            
            return new RationalNumber(newNumerator, newDenominator);
        }

        /// <summary>
        /// Subtracts <paramref name="number"/> from this rational number.
        /// This method does not modify existing rational numbers.
        /// </summary>
        /// <param name="number">A rational number.</param>
        /// <returns>A new rational number that is the difference of this and <paramref name="number"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="number"/> is null.</exception>
        public IRationalNumber Subtract(IRationalNumber number)
        {
            if (number == null)
            {
                throw new ArgumentNullException("Number cannot be null.");
            }

            int newNumerator = Numerator * number.Denominator - Denominator * number.Numerator;
            int newDenominator = Denominator * number.Denominator;

            return new RationalNumber(newNumerator, newDenominator);
        }

        /// <summary>
        /// Multiplies this rational number with <paramref name="number"/>.
        /// This method does not modify existing rational numbers.
        /// </summary>
        /// <param name="number">A rational number.</param>
        /// <returns>The product of this rational number and <paramref name="number"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="number"/> is null.</exception>
        public IRationalNumber Multiply(IRationalNumber number)
        {
            if (number == null)
            {
                throw new ArgumentNullException("Number cannot be null.");
            }

            int newNumerator = Numerator * number.Numerator;
            int newDenominator = Denominator * number.Denominator;

            return new RationalNumber(newNumerator, newDenominator);
        }
        
        /// <summary>
        /// Divides this rational number by <paramref name="number"/>.
        /// This method does not modify existing rational numbers.
        /// </summary>
        /// <param name="number">A rational number.</param>
        /// <returns>A new rational number that is the quotient of this and <paramref name="number"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="number"/>is null.</exception>
        /// <exception cref="DivideByZeroException">Thrown if <paramref name="number"/>is zero.</exception>
        public IRationalNumber Divide(IRationalNumber number)
        {
            if (number == null) { throw new ArgumentNullException("Number cannot be null."); }

            if (number.Numerator == 0) { throw new DivideByZeroException("Number cannot be zero."); }

            int newNumerator = Numerator * number.Denominator;
            int newDenominator = Denominator * number.Numerator;

            return new RationalNumber(newNumerator, newDenominator);
        }

        /// <summary>
        /// The string representation of a rational number in the form numerator/denominator
        /// </summary>
        /// <returns>The string representation of this rational number.</returns>
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        /// <summary>
        /// Compares this rational number with another object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True if this rational number is equal to <paramref name="obj"/>.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is RationalNumber))
            {
                return false;
            }

            IRationalNumber other = (RationalNumber)obj;

            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        /// <summary>
        /// Returns a hash code based on the numerator and denominator of this rational number.
        /// Two RationalNumber objects with the same numerator and denominator will produce the same hash code.
        /// It's not neccessarily the case that two RationalNumber objects with the same code are equal.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Numerator * Numerator - Denominator;
        }
    }

    /// <summary>
    /// This class defines an extension method for integers which allows raising them to rational numbers.
    /// </summary>
    public static class IntNumberExtension
    {
        /// <summary>
        /// Raises this real number to a rational number <paramref name="r"/>.
        /// </summary>
        /// <param name="intNumber">A real number.</param>
        /// <param name="r">A rational number.</param>
        /// <returns>Return the result of <paramref name="intNumber"/> raised to <paramref name="r"/>.</returns>
        public static double ExpReal(this int intNumber, RationalNumber r)
        {
            return r.ExpReal(intNumber);
        }
    }
}
