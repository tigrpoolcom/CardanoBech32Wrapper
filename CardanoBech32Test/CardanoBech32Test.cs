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
  public class CardanoBech32Test
  {
    private CardanoBech32Wrapper _cBech32;
    public CardanoBech32Test()
    {
      _cBech32 = new CardanoBech32Wrapper();
    }


    [DataTestMethod]
    [DataRow("addr1qxkmuf2gqzsm5ejxm2amrwuq3pcc02cw6tttgsgqgafj46klskg5jjufdyf4znw8sjn37enwn5ge5l66qsx8srrpg3tq8du7us", "01adbe254800a1ba6646dabbb1bb80887187ab0ed2d6b4410047532aeadf8591494b896913514dc784a71f666e9d119a7f5a040c780c614456")]
    [DataRow("addr1qx2ezq7geqclknv0n3nhf09c48acm3lpq93frnxhrt84fvkmtgh4vcg6t6ujpr9yrf3gnndc6uufn7xvu2sjqkwqlgkqzq5xdt", "01959103c8c831fb4d8f9c6774bcb8a9fb8dc7e1016291ccd71acf54b2db5a2f56611a5eb9208ca41a6289cdb8d73899f8cce2a12059c0fa2c")]

    public void ConvertToHexAddressFromBech32_IsHex_True(string address, string addressInHexCheck)
    {
      Assert.AreEqual(_cBech32.ConvertToHexAddressFromBech32(address), addressInHexCheck);
    }

    [DataTestMethod]
    [DataRow(
      "01adbe254800a1ba6646dabbb1bb80887187ab0ed2d6b4410047532aeadf8591494b896913514dc784a71f666e9d119a7f5a040c780c614456", 
      AddressType.addr,
      "addr1qxkmuf2gqzsm5ejxm2amrwuq3pcc02cw6tttgsgqgafj46klskg5jjufdyf4znw8sjn37enwn5ge5l66qsx8srrpg3tq8du7us")]
    [DataRow(
       "01959103c8c831fb4d8f9c6774bcb8a9fb8dc7e1016291ccd71acf54b2db5a2f56611a5eb9208ca41a6289cdb8d73899f8cce2a12059c0fa2c", 
      AddressType.addr,
      "addr1qx2ezq7geqclknv0n3nhf09c48acm3lpq93frnxhrt84fvkmtgh4vcg6t6ujpr9yrf3gnndc6uufn7xvu2sjqkwqlgkqzq5xdt")]
    //[DataRow(
    //   "b84d709a29b5f2f0f79d48941df55d3e5823a1ecc290a6091d1f6841437574794d616c3031373830",
    //  AddressType.asset,
    //  "asset12a60j3a4jx9kq2h4g2lepg4cgm7hkdgd2am9x0")]
    // Asset Fingerprint uses blake2b and then bech32 Todo: implement -> https://github.com/BLAKE2/BLAKE2/tree/b52178a376ca85a8ffe50492263c2a5bc0fa4f46
    // https://cardano.stackexchange.com/questions/809/how-do-i-calculate-the-fingerprint-of-an-asset
    public void ConvertToBech32AddressFromHex_IsHex_True(string addressInHex, AddressType addressType ,string addressCheck)
    {
      Assert.AreEqual(_cBech32.ConvertToBech32AddressFromHex(addressInHex,addressType), addressCheck);
    }

    [DataTestMethod]
    [DataRow("addr1qx2ezq7geqclknv0n3nhf09c48acm3lpq93frnxhrt84fvkmtgh4vcg6t6ujpr9yrf3gnndc6uufn7xvu2sjqkwqlgkqzq5xdt", "stake1u8d45t6kvyd9awfq3jjp5c5fekudwwyelrxw9gfqt8q05tq3j8dxa")]
    [DataRow("addr1qxdvcswn0exwc2vjfr6u6f6qndfhmk94xjrt5tztpelyk4yg83zn9d4vrrtzs98lcl5u5q6mv7ngmg829xxvy3g5ydls7c76wu", "stake1uxyrc3fjk6kp343gznlu06w2qddk0f5d5r4znrxzg52zxlclk0hlq")]
    public void GetStakeAddressFromAddress_IsValid_True(string address, string stakeAddressCheck)
    {

      var stakeAddress = _cBech32.GetStakeAddressFromAddress(address);

      Assert.AreEqual(stakeAddress, stakeAddressCheck);

    }

  }
}
