using CardanoBech32;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardanoBech32Test
{
    [TestClass]
    public class Bech32Test
    {
        [TestMethod]
        public void TestValid()
        {
            string[] valid_checksum =
            {
                "A12UEL5L",
                "an83characterlonghumanreadablepartthatcontainsthenumber1andtheexcludedcharactersbio1tt5tgs",
                "abcdef1qpzry9x8gf2tvdw0s3jn54khce6mua7lmqqqxw",
                "11qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqc8247j",
                "split1checkupstagehandshakeupstreamerranterredcaperred2y9e3w",
                "stake1uyuqtqq84v9jrqm0asptaehtw7srrr7cnwuxyqz38a6e8scm6lcf3",
                "addr1qxkmuf2gqzsm5ejxm2amrwuq3pcc02cw6tttgsgqgafj46klskg5jjufdyf4znw8sjn37enwn5ge5l66qsx8srrpg3tq8du7us",
                "stake_test1ur84236ycjkxvt0r5l7tdqaatlhhec0hrpncqlv5gp58e0q2ajrqx",
                "addr_test1qznd7jmvw2a53ykmgg5c6dcqd9f35mtts77zf57wn6ern5x024r5f39vvck78fluk6pm6hl00nslwxr8sp7egsrg0j7q8y2a9d",
            };

            foreach (var encoded in valid_checksum)
            {
                string hrp;
                byte[] data;
                Bech32Engine.Decode(encoded, out hrp, out data);
                Assert.IsNotNull(data, "bech32_decode fails: {0}", encoded);

                var rebuild = Bech32Engine.Encode(hrp, data);
                Assert.IsNotNull(rebuild, "bech32_encode fails: {0}", encoded);
                Assert.AreEqual(encoded.ToLower(), rebuild, "bech32_encode produces incorrect result : {0}", encoded);
            }
        }
        [TestMethod]
        public void TestInvalid()
        {
            string[] invalid_checksum =
            {
                "tc1qw508d6qejxtdg4y5r3zarvary0c5xw7kg3g4ty",
                "bc1qw508d6qejxtdg4y5r3zarvary0c5xw7kv8f3t5",
                "BC13W508D6QEJXTDG4Y5R3ZARVARY0C5XW7KN40WF2",
                "bc1rw5uspcuh",
                "bc10w508d6qejxtdg4y5r3zarvary0c5xw7kw508d6qejxtdg4y5r3zarvary0c5xw7kw5rljs90",
                "BC1QR508D6QEJXTDG4Y5R3ZARVARYV98GJ9P",
                "tb1qrp33g0q5c5txsp9arysrx4k6zdkfs4nce4xj0gdcccefvpysxf3q0sL5k7",
                "stake_test1uyuqtqq84v9jrqm0asptaehtw7srrr7cnwuxyqz38a6e8scm6lcf3",
                "addr_test1qxkmuf2gqzsm5ejxm2amrwuq3pcc02cw6tttgsgqgafj46klskg5jjufdyf4znw8sjn37enwn5ge5l66qsx8srrpg3tq8du7us",
                "stake1ur84236ycjkxvt0r5l7tdqaatlhhec0hrpncqlv5gp58e0q2ajrqx",
                "addr1qznd7jmvw2a53ykmgg5c6dcqd9f35mtts77zf57wn6ern5x024r5f39vvck78fluk6pm6hl00nslwxr8sp7egsrg0j7q8y2a9d",
            };

            foreach (var encoded in invalid_checksum)
            {
                string hrp;
                byte[] data;
                Bech32Engine.Decode(encoded, out hrp, out data);
                Assert.IsNull(data, "bech32_decode should fail: {0}", encoded);
            }
        }
    }
}
