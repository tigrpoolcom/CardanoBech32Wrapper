using CardanoBech32;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanoBech32Test
{
  
  [TestClass]
  public class HelperTest
  {
    [DataTestMethod]
    [DataRow("07c62cb4f0b5a20823361bc6b771b313")]
    [DataRow("8df6c5c2c0ad62279b763e1b5fa88aa2")]
    [DataRow("553d0a5064e3326882013a3a31016d75")]
    public void IsHex_Returns_True(string validValue)
    {
      Assert.IsTrue(Helper.IsHex(validValue));
    }
    [DataTestMethod]
    [DataRow(" 7c62cb4f0b5a20823361bc6b771b313")]
    [DataRow("8*df6_c5c2c0ad62279b763e1b5fa88aa2")]
    [DataRow("Z553d0a5064e3326882013a3a31016d75")]
    [DataRow(null)]
    public void IsHex_Returns_False(string validValue)
    {
      Assert.IsFalse(Helper.IsHex(validValue));
    }

    [DataTestMethod]
    [DataRow("07c62cb4f0b5a20823361bc6b771b313AazZ09")]
    [DataRow("8df6c5c2c0ad62279b763e1b5fa88aa2")]
    [DataRow("553d0a5064e3326882013a3a31016d75")]
    public void IsDigitLetter_Returns_True(string validValue)
    {
      Assert.IsTrue(Helper.IsDigitLetter(validValue));
    }
    [DataTestMethod]
    [DataRow(" 7c62cb4f0b5a20823361bc6b771b313")]
    [DataRow("8*df6_c5c2c0ad62279b763e1b5fa88aa2")]
    [DataRow("_553d0a5064e3326882013a3a31016d75")]
    [DataRow(null)]
    public void IsDigitLetter_Returns_False(string validValue)
    {
      Assert.IsFalse(Helper.IsDigitLetter(validValue));
    }

    [DataTestMethod]
    [DataRow("07c62cb4f0b5a20823361bc6b771b313AazZ09")]
    [DataRow("8df6c5c2c0ad62279b763e1b5fa88aa2")]
    [DataRow("553d0a5064e3326882013a3a31016d75")]
    [DataRow("_5 53d0a5064e3326882013a3a31016d75")]
    public void IsDigitLetterUnderscoreWhitespace_Returns_True(string validValue)
    {
      Assert.IsTrue(Helper.IsDigitLetterUnderscoreWhitespace(validValue));
    }
    [DataTestMethod]
    [DataRow("?7c62cb4f0b5a20823361bc6b771b313")]
    [DataRow("8*df6_c5c2c0ad62279b763e1b5fa88aa2")]
    [DataRow("-_553d0a5064e3326882013a3a31016d75")]
    [DataRow(null)]
    public void IsDigitLetterUnderscoreWhitespace_Returns_False(string validValue)
    {
      Assert.IsFalse(Helper.IsDigitLetterUnderscoreWhitespace(validValue));
    }

  }
}
