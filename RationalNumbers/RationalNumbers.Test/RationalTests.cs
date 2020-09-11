// Author: Peyman Azami

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RationalNumbers.Test
{
    [TestClass]
    public class RationalTests
    {
        #region Test Categories

        const string constructor = "Constructor";
        const string getGCD = "GetGCD";
        const string equals = "Equals";
        const string getHashCode = "GetHashCode";
        const string add = "Add";
        const string subtract = "Subtract";
        const string multiply = "Multiply";
        const string divide = "Divide";
        const string abs = "Abs";
        const string expRational = "ExpRational";
        const string expReal = "ExpReal";
        const string reduce = "Reduce";

        #endregion

        #region Constructor Tests

        [TestMethod]
        [TestCategory(constructor)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_zero_as_denominator_should_throw_ArgumentOutOfRangeException()
        {
            IRationalNumber rationalNumber = new RationalNumber(1, 0);
        }

        [TestMethod]
        [TestCategory(constructor)]
        public void Constructor_zero_as_numerator()
        {
            Assert.AreEqual(new RationalNumber(0, 1), new RationalNumber(0));
        }

        [TestMethod]
        [TestCategory(constructor)]
        public void Constructor_one_as_numerator()
        {
            Assert.AreEqual(new RationalNumber(1, 1), new RationalNumber(1));
        }

        [TestMethod]
        [TestCategory(constructor)]
        public void Constructor_positive_numerator_negative_denominator()
        {
            Assert.AreEqual(new RationalNumber(-2, 3), new RationalNumber(2, -3));
        }

        [TestMethod]
        [TestCategory(constructor)]
        public void Constructor_zero_as_numerator_and_negative_denominator()
        {
            Assert.AreEqual(new RationalNumber(0, 4), new RationalNumber(0, -4));
        }

        [TestMethod]
        [TestCategory(constructor)]
        public void Constructor_reducable_numerator_and_denominator()
        {
            Assert.AreEqual(new RationalNumber(2, 3), new RationalNumber(4, 6));
        }

        #endregion

        /* #region GetGCD Tests - Call to GetGCD must be removed from the constructor in order for these tests to be relevant

        [TestMethod]
        [TestCategory(getGCD)]
        public void GetGCD_of_a_positive_numerator_and_denominator()
        {
            Assert.AreEqual(4, new RationalNumber(48, 20).GetGCD());
        }

        [TestMethod]
        [TestCategory(getGCD)]
        public void GetGCD_of_a_positive_numerator_and_a_negative_denominator()
        {
            Assert.AreEqual(5, new RationalNumber(105, -25).GetGCD());
        }

        [TestMethod]
        [TestCategory(getGCD)]
        public void GetGCD_of_a_negative_numerator_and_a_positive_denominator()
        {
            Assert.AreEqual(1, new RationalNumber(-49, 15).GetGCD());
        }

        [TestMethod]
        [TestCategory(getGCD)]
        public void GetGCD_of_a_negative_numerator_and_a_negative_denominator()
        {
            Assert.AreEqual(5, new RationalNumber(-25, -105).GetGCD());
        }

        [TestMethod]
        [TestCategory(getGCD)]
        public void GetGCD_of_a_zero_numerator_and_a_nonZero_denominator()
        {
            Assert.AreEqual(29, new RationalNumber(0, 29).GetGCD());
        }

        #endregion */

        #region Equals Tests

        [TestMethod]
        [TestCategory(equals)]
        public void Equals_two_equal_rational_numbers()
        {
            Assert.AreEqual(true, new RationalNumber(2, 3).Equals(new RationalNumber(2, 3)));
        }

        [TestMethod]
        [TestCategory(equals)]
        public void Equals_two_unequal_rational_numbers()
        {
            Assert.AreEqual(false, new RationalNumber(1, 2).Equals(new RationalNumber(2, 1)));
        }

        [TestMethod]
        [TestCategory(equals)]
        public void Equals_rational_number_and_a_different_type()
        {
            Assert.AreEqual(false, new RationalNumber(1, 1).Equals("This is not a rational number."));
        }

        [TestMethod]
        [TestCategory(equals)]
        public void Equals_rational_number_and_an_int()
        {
            Assert.AreEqual(false, new RationalNumber(1, 1).Equals(15));
        }

        [TestMethod]
        [TestCategory(equals)]
        public void Equals_rational_number_and_null()
        {
            Assert.AreEqual(false, new RationalNumber(3, 5).Equals(null));
        }

        #endregion

        #region GetHashCode Tests

        [TestMethod]
        [TestCategory(getHashCode)]
        public void GetHashCode_two_equal_rational_numbers()
        {
            Assert.AreEqual(new RationalNumber(1, 2).GetHashCode(), new RationalNumber(1, 2).GetHashCode());
        }

        #endregion

        #region Add Tests

        [TestMethod]
        [TestCategory(add)]
        public void Add_two_positive_rational_numbers()
        {
            Assert.AreEqual(new RationalNumber(7, 6), new RationalNumber(1, 2) + new RationalNumber(2, 3));
        }

        [TestMethod]
        [TestCategory(add)]
        public void Add_a_positive_rational_number_and_a_negative_rational_number()
        {
            Assert.AreEqual(new RationalNumber(-1, 6), new RationalNumber(1, 2) + new RationalNumber(-2, 3));
        }

        [TestMethod]
        [TestCategory(add)]
        public void Add_two_negative_rational_numbers()
        {
            Assert.AreEqual(new RationalNumber(-7, 6), new RationalNumber(-1, 2) + new RationalNumber(-2, 3));
        }

        [TestMethod]
        [TestCategory(add)]
        public void Add_a_rational_number_to_its_additive_inverse()
        {
            Assert.AreEqual(new RationalNumber(0, 1), new RationalNumber(1, 2) + new RationalNumber(-1, 2));
        }

        [TestMethod]
        [TestCategory(add)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_null_value_to_rational_number_should_throw_ArgumentNullException()
        {
            IRationalNumber result = new RationalNumber(1, 2).Add(null);
        }

        #endregion

        #region Subtract Tests

        [TestMethod]
        [TestCategory(subtract)]
        public void Subtract_two_positive_rational_numbers()
        {
            Assert.AreEqual(new RationalNumber(-1, 6), new RationalNumber(1, 2) - new RationalNumber(2, 3));
        }

        [TestMethod]
        [TestCategory(subtract)]
        public void Subtract_a_positive_rational_number_and_a_negative_rational_number()
        {
            Assert.AreEqual(new RationalNumber(7, 6), new RationalNumber(1, 2) - new RationalNumber(-2, 3));
        }

        [TestMethod]
        [TestCategory(subtract)]
        public void Subtract_two_negative_rational_numbers()
        {
            Assert.AreEqual(new RationalNumber(1, 6), new RationalNumber(-1, 2) - new RationalNumber(-2, 3));
        }

        [TestMethod]
        [TestCategory(subtract)]
        public void Subtract_a_rational_number_from_itself()
        {
            Assert.AreEqual(new RationalNumber(0, 1), new RationalNumber(1, 2) - new RationalNumber(1, 2));
        }

        [TestMethod]
        [TestCategory(subtract)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Subtract_null_value_from_rational_number_should_throw_ArgumentNullException()
        {
            IRationalNumber result = new RationalNumber(1, 2).Subtract(null);
        }

        #endregion

        #region Multiply Tests

        [TestMethod]
        [TestCategory(multiply)]
        public void Multiply_two_positive_rational_numbers()
        {
            Assert.AreEqual(new RationalNumber(1, 3), new RationalNumber(1, 2) * new RationalNumber(2, 3));
        }

        [TestMethod]
        [TestCategory(multiply)]
        public void Multiply_a_negative_rational_number_by_a_positive_rational_number()
        {
            Assert.AreEqual(new RationalNumber(-1, 3), new RationalNumber(-1, 2) * new RationalNumber(2, 3));
        }

        [TestMethod]
        [TestCategory(multiply)]
        public void Multiply_two_negative_rational_numbers()
        {
            Assert.AreEqual(new RationalNumber(1, 3), new RationalNumber(-1, 2) * new RationalNumber(-2, 3));
        }

        [TestMethod]
        [TestCategory(multiply)]
        public void Multiply_a_rational_number_by_its_reciprocal()
        {
            Assert.AreEqual(new RationalNumber(1, 1), new RationalNumber(1, 2) * new RationalNumber(2, 1));
        }

        [TestMethod]
        [TestCategory(multiply)]
        public void Multiply_a_rational_number_by_1()
        {
            Assert.AreEqual(new RationalNumber(1, 2), new RationalNumber(1, 2) * new RationalNumber(1, 1));
        }

        [TestMethod]
        [TestCategory(multiply)]
        public void Multiply_a_rational_number_by_0()
        {
            Assert.AreEqual(new RationalNumber(0, 1), new RationalNumber(1, 2) * new RationalNumber(0, 1));
        }

        [TestMethod]
        [TestCategory(multiply)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Multiply_null_value_with_rational_number_should_throw_ArgumentNullException()
        {
            IRationalNumber result = new RationalNumber(1, 2).Multiply(null);
        }

        #endregion

        #region Divide Tests

        [TestMethod]
        [TestCategory(divide)]
        public void Divide_two_positive_rational_numbers()
        {
            Assert.AreEqual(new RationalNumber(3, 4), new RationalNumber(1, 2) / new RationalNumber(2, 3));
        }

        [TestMethod]
        [TestCategory(divide)]
        public void Divide_a_positive_rational_number_by_a_negative_rational_number()
        {
            Assert.AreEqual(new RationalNumber(-3, 4), new RationalNumber(1, 2) / new RationalNumber(-2, 3));
        }

        [TestMethod]
        [TestCategory(divide)]
        public void Divide_two_negative_rational_numbers()
        {
            Assert.AreEqual(new RationalNumber(3, 4), new RationalNumber(-1, 2) / new RationalNumber(-2, 3));
        }

        [TestMethod]
        [TestCategory(divide)]
        public void Divide_a_rational_number_by_1()
        {
            Assert.AreEqual(new RationalNumber(1, 2), new RationalNumber(1, 2) / new RationalNumber(1, 1));
        }

        [TestMethod]
        [TestCategory(divide)]
        public void Divide_zero_by_a_nonZero_rational_number()
        {
            Assert.AreEqual(new RationalNumber(0, 1), new RationalNumber(0, 1) / new RationalNumber(2, 3));
        }

        [TestMethod]
        [TestCategory(divide)]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_rational_number_by_zero_should_throw_DivideByZeroException()
        {
            IRationalNumber result = new RationalNumber(2, 3) / new RationalNumber(0, 1);
        }

        [TestMethod]
        [TestCategory(divide)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Divide_rational_number_by_null_value_should_throw_ArgumentNullException()
        {
            IRationalNumber result = new RationalNumber(1, 2).Divide(null);
        }

        #endregion

        #region Abs Tests

        [TestMethod]
        [TestCategory(abs)]
        public void Absolute_value_of_a_positive_rational_number()
        {
            Assert.AreEqual(new RationalNumber(1, 2), new RationalNumber(1, 2).Abs());
        }

        [TestMethod]
        [TestCategory(abs)]
        public void Absolute_value_of_a_positive_rational_number_with_negative_numerator_and_denominator()
        {
            Assert.AreEqual(new RationalNumber(1, 2), new RationalNumber(-1, -2).Abs());
        }

        [TestMethod]
        [TestCategory(abs)]
        public void Absolute_value_of_a_negative_rational_number()
        {
            Assert.AreEqual(new RationalNumber(1, 2), new RationalNumber(-1, 2).Abs());
        }

        [TestMethod]
        [TestCategory(abs)]
        public void Absolute_value_of_a_negative_rational_number_with_negative_denominator()
        {
            Assert.AreEqual(new RationalNumber(1, 2), new RationalNumber(1, -2).Abs());
        }

        [TestMethod]
        [TestCategory(abs)]
        public void Absolute_value_of_zero()
        {
            Assert.AreEqual(new RationalNumber(0, 1), new RationalNumber(0, 1).Abs());
        }

        #endregion

        #region ExpRational Tests

        [TestMethod]
        [TestCategory(expRational)]
        public void Raise_a_positive_rational_number_to_a_positive_integer_power()
        {
            Assert.AreEqual(new RationalNumber(1, 8), new RationalNumber(1, 2).ExpRational(3));
        }

        [TestMethod]
        [TestCategory(expRational)]
        public void Raise_a_negative_rational_number_to_a_positive_integer_power()
        {
            Assert.AreEqual(new RationalNumber(-1, 8), new RationalNumber(-1, 2).ExpRational(3));
        }

        [TestMethod]
        [TestCategory(expRational)]
        public void Raise_zero_to_an_integer_power()
        {
            Assert.AreEqual(new RationalNumber(0, 1), new RationalNumber(0, 1).ExpRational(5));
        }

        [TestMethod]
        [TestCategory(expRational)]
        public void Raise_one_to_an_integer_power()
        {
            Assert.AreEqual(new RationalNumber(1, 1), new RationalNumber(1, 1).ExpRational(4));
        }

        [TestMethod]
        [TestCategory(expRational)]
        public void Raise_one_to_a_negative_integer_power()
        {
            Assert.AreEqual(new RationalNumber(1, 1), new RationalNumber(1, 1).ExpRational(-5));
        }

        [TestMethod]
        [TestCategory(expRational)]
        public void Raise_a_positive_rational_number_to_the_power_of_zero()
        {
            Assert.AreEqual(new RationalNumber(1, 1), new RationalNumber(1, 2).ExpRational(0));
        }

        [TestMethod]
        [TestCategory(expRational)]
        public void Raise_a_negative_rational_number_to_the_power_of_zero()
        {
            Assert.AreEqual(new RationalNumber(1, 1), new RationalNumber(-1, 2).ExpRational(0));
        }

        [TestMethod]
        [TestCategory(expRational)]
        public void Raise_a_postive_rational_number_to_a_negative_integer_power()
        {
            Assert.AreEqual(new RationalNumber(9, 4), new RationalNumber(2, 3).ExpRational(-2));
        }

        [TestMethod]
        [TestCategory(expRational)]
        public void Raise_zero_to_zero()
        {
            Assert.AreEqual(new RationalNumber(1, 1), new RationalNumber(0, 1).ExpRational(0));
        }

        [TestMethod]
        [TestCategory(expRational)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Raise_zero_to_a_negative_integer_power_should_throw_ArgumentOutOfRangeException()
        {
            var rationalNumber = new RationalNumber(0, 1).ExpRational(-9);
        }

        [TestMethod]
        [TestCategory(expRational)]
        public void Raise_a_negative_rational_number_to_a_negative_integer_power()
        {
            Assert.AreEqual(new RationalNumber(-8, 1), new RationalNumber(-1, 2).ExpRational(-3));
        }


        #endregion

        #region ExpReal Tests

        [TestMethod]
        [TestCategory(expReal)]
        public void Raise_a_real_number_to_a_positive_rational_number()
        {
            Assert.AreEqual(16, 8.ExpReal(new RationalNumber(4, 3)), 0.0000001);
        }

        [TestMethod]
        [TestCategory(expReal)]
        public void Raise_a_real_number_to_a_negative_rational_number()
        {
            Assert.AreEqual(0.33333334, 9.ExpReal(new RationalNumber(-1, 2)), 0.0000001);
        }

        [TestMethod]
        [TestCategory(expReal)]
        public void Raise_a_real_number_to_a_zero_rational_number()
        {
            Assert.AreEqual(1, 2.ExpReal(new RationalNumber(0, 1)), 0.0000001);
        }

        [TestMethod]
        [TestCategory(expReal)]
        public void Raise_a_zero_real_number_to_a_positive_rational_number()
        {
            Assert.AreEqual(0, 0.ExpReal(new RationalNumber(2, 3)), 0.0000001);
        }

        [TestMethod]
        [TestCategory(expReal)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Raise_a_zero_real_number_to_a_negative_rational_number_should_throw_ArgumentOutOfRangeException()
        {
            var result = 0.ExpReal(new RationalNumber(-1, 3));
        }

        [TestMethod]
        [TestCategory(expReal)]
        public void Raise_a_zero_real_number_to_a_zero_rational_number()
        {
            Assert.AreEqual(1, 0.ExpReal(new RationalNumber(0, 1)), 0.0000001);
        }

        [TestMethod]
        [TestCategory(expReal)]
        public void Raise_a_negative_real_number_to_a_positive_rational_number()
        {
            Assert.AreEqual(-1.31950791, -2.ExpReal(new RationalNumber(2, 5)), 0.0000001);
        }

        [TestMethod]
        [TestCategory(expReal)]
        public void Raise_a_negative_real_number_to_a_negative_rational_number()
        {
            Assert.AreEqual(-0.75983568, -3.ExpReal(new RationalNumber(-1, 4)), 0.0000001);
        }

        [TestMethod]
        [TestCategory(expReal)]
        public void Raise_a_negative_real_number_to_a_zero_rational_number()
        {
            Assert.AreEqual(-1, -3.ExpReal(new RationalNumber(0, 1)), 0.0000001);
        }

        #endregion

        #region Reduce Tests

        [TestMethod]
        [TestCategory(reduce)]
        public void Reduce_a_positive_rational_number_to_lowest_terms()
        {
            var rationalNumber = new RationalNumber(2, 4);

            rationalNumber.Reduce();

            Assert.AreEqual(new RationalNumber(1, 2), rationalNumber);
        }

        [TestMethod]
        [TestCategory(reduce)]
        public void Reduce_a_negative_rational_number_to_lowest_terms()
        {
            var rationalNumber = new RationalNumber(-4, 6);

            rationalNumber.Reduce();

            Assert.AreEqual(new RationalNumber(-2, 3), rationalNumber);
        }

        [TestMethod]
        [TestCategory(reduce)]
        public void Reduce_a_rational_number_with_a_negative_denominator_to_lowest_terms()
        {
            var rationalNumber = new RationalNumber(3, -9);

            rationalNumber.Reduce();

            Assert.AreEqual(new RationalNumber(-1, 3), rationalNumber);
        }

        [TestMethod]
        [TestCategory(reduce)]
        public void Reduce_zero_to_lowest_terms()
        {
            var rationalNumber = new RationalNumber(0, 6);

            rationalNumber.Reduce();

            Assert.AreEqual(new RationalNumber(0, 1), rationalNumber);
        }

        [TestMethod]
        [TestCategory(reduce)]
        public void Reduce_an_integer_to_lowest_terms()
        {
            var rationalNumber = new RationalNumber(-14, 7);

            rationalNumber.Reduce();

            Assert.AreEqual(new RationalNumber(-2, 1), rationalNumber);
        }

        [TestMethod]
        [TestCategory(reduce)]
        public void Reduce_one_to_lowest_terms()
        {
            var rationalNumber = new RationalNumber(13, 13);

            rationalNumber.Reduce();

            Assert.AreEqual(new RationalNumber(1, 1), rationalNumber);
        }

        #endregion
    }
}