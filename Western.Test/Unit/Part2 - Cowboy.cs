
using Xunit;
using FluentAssertions;

using Western.Core.Models;

namespace Western.Test.Unit
{
    /// <summary>
    ///  Cowboy Tests: - Vous p(r)endrez bien quelques Desperados --- 
    /// </summary>
    public class Part2
    {
        private Cowboy _cowboy = new Cowboy("Curly Bill Brocius");

        [Fact]
        public void CowboyCanSayHisName()
        {
            _cowboy.Name.Should().Be("Curly Bill Brocius");
        }

        [Fact]
        public void CowboyIsBadGuy()
        {
            _cowboy.CharacterType.Should().Be(CharacterType.Bad);
        }

        [Fact]
        public void CowboyLacksSubtelty()
        {
            _cowboy.Yell.Should().Be("Die, you sucker!");
        }
    }
}
