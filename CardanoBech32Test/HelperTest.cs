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

    [DataTestMethod]
    [DataRow(" ")]
    [DataRow("")]
    [DataRow("*'*$§")]
    [DataRow(null)]
    public void ConvertByteToHexString_Returns_EmptyString(string validValue)
    {
        var validTest = Helper.ConvertHexStringToByte(validValue);
        Assert.AreEqual(Helper.ConvertByteToHexString(validTest), string.Empty);
    }

    [DataTestMethod]
    [DataRow("addr1q94z79m3gpzcd365p7fkhus2akk0q0vdpndkf9x5w5v4jjlyaksh35p2qzfuv3dsz6352v6v3pn3wm2q4vz3m8key9fqlpaslx")]
    [DataRow("addr1qxq47au29wss4g8acjk0zsmwwq0h34hhzump6stye9wuldm7nm0t6ad3jz9hy5v3smye0nvcumtzu43k7r36ag0w29qqdafvvk")]
    public void IsBech32ToHexConvertible_Returns_True(string validValue)
    {
      Assert.AreEqual(Helper.IsBech32ToHexConvertible(validValue), true);
    }

    [DataTestMethod]
    [DataRow(" ")]
    [DataRow("DdzFFzCqrhsmMp7k6EpXzRLrBV2bH69Dr3Lq46ftRj3LovzPghDQbn4m5XnyR1yXeSbxnipkQ4UVfp7yuxFGsFTNAPxedktYou2H24qV")]
    [DataRow(null)]
    public void IsBech32ToHexConvertible_Returns_False(string validValue)
    {
      Assert.AreEqual(Helper.IsBech32ToHexConvertible(validValue), false);
    }



    [DataTestMethod]
    [DataRow("82d818584283581cf61ebfbc2585045b2cc58762bc9197126d98ccb4359106f9fa326022a101581e581c3083349abf53ea9337bbdf50d390207234af2ea48028f2baa18b3128001aa0eb1924")]
    [DataRow("61a061ae00b0f8e07b359fead1a1f9072ec2aee1e78486d7830adcf273")]
    [DataRow(" 61a061ae00b0f8e07b359fead1a1f9072ec2aee1e78486d7830adcf273")]
    public void TryConvertHexStringToByte_Returns_True(string validValue)
    {
      Assert.AreEqual(Helper.TryConvertHexStringToByte(validValue, out var valueInHex ), true);
      Assert.AreNotEqual(valueInHex, null);
    }

    [DataTestMethod]
    [DataRow(" ")]
    [DataRow("DdzFFzCqrhsmMp7k6EpXzRLrBV2bH69Dr3Lq46ftRj3LovzPghDQbn4m5XnyR1yXeSbxnipkQ4UVfp7yuxFGsFTNAPxedktYou2H24qV")]
    [DataRow("61a061ae00b0f8e07b359fead1a1 f9072ec2aee1e78486d7830adcf273")]
    [DataRow(null)]
    public void TryConvertHexStringToByte_Returns_False(string validValue)
    {
      Assert.AreEqual(Helper.TryConvertHexStringToByte(validValue, out var valueInHex), false);
      Assert.IsNull(valueInHex);
    }

    [DataTestMethod]
    [DataRow("82d818584283581cf61ebfbc2585045b2cc58762bc9197126d98ccb4359106f9fa326022a101581e581c3083349abf53ea9337bbdf50d390207234af2ea48028f2baa18b3128001aa0eb1924")]
    [DataRow("61a061ae00b0f8e07b359fead1a1f9072ec2aee1e78486d7830adcf273")]
    [DataRow(" 61a061ae00b0f8e07b359fead1a1f9072ec2aee1e78486d7830adcf273")]
    public void TryConvertByteToHexString_Returns_True(string validValue)
    {
      Helper.TryConvertHexStringToByte(validValue, out var valueInHex);

     
      Assert.AreEqual(Helper.TryConvertByteToHexString(valueInHex, out var valueInHexString), true);
      Assert.AreEqual(valueInHexString, validValue.Trim());
    }

    [DataTestMethod]
    [DataRow(" ")]
    [DataRow("DdzFFzCqrhsmMp7k6EpXzRLrBV2bH69Dr3Lq46ftRj3LovzPghDQbn4m5XnyR1yXeSbxnipkQ4UVfp7yuxFGsFTNAPxedktYou2H24qV")]
    [DataRow("61a061ae00b0f8e07b359fead1a1 f9072ec2aee1e78486d7830adcf273")]
    [DataRow(null)]
    public void TryConvertByteToHexString_Returns_False(string validValue)
    {
      Helper.TryConvertHexStringToByte(validValue, out var valueInHex);


      Assert.AreEqual(Helper.TryConvertByteToHexString(valueInHex, out var valueInHexString), false);
      Assert.IsNull(valueInHexString);
    }


  }
}
