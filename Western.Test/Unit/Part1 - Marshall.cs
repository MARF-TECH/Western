
using Xunit;
using FluentAssertions;

using Western.Core.Models;

namespace Western.Test.Unit
{
    /// <summary>
    ///  Marshall Tests: - A Marshall In Tombstone Town --- 
    /// </summary>
    public class Part1
    {
        private Marshall _marshall = new Marshall("Wyatt Earp");

        [Fact]
        public void MarshallCanSayHisName()
        {
            _marshall.Name.Should().Be("Wyatt Earp");
        }

        [Fact]
        public void MarshallIsGoodGuy()
        {
            _marshall.CharacterType.Should().Be(CharacterType.Good);
        }

        [Fact]
        public void MarshallWarnsBeforeShooting()
        {
            _marshall.Yell.Should().Be("Throw up your hands!");
        }
    }
}
