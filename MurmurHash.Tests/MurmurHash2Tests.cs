using Xunit;

namespace MurmurHash.Tests
{
    public class MurmurHash2Tests
    {
        [Theory]
        [InlineData("Hash1",2816689502)]
        [InlineData("Hash2",367703598)]
        [InlineData("Hash3",91192953)]
        public void Hash_Should_Generate_Valid_Hashes(string hash, uint expected)
        {
            var result = MurmurHash2.Hash(hash);
            Assert.Equal(expected, result);
        }
    }
}