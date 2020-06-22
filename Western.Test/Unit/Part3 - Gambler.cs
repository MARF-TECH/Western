using System;

using Xunit;
using FluentAssertions;

using Western.Core.Models;
using Western.Core.Exceptions;

namespace Western.Test.Unit
{
    /// <summary>
    ///  Gambler Tests: - une paire d'As et une paire de Huit ? Jettez ça, pauvre fou ! --- 
    /// </summary>
    public class Part3
    {
        private Gambler _gambler = new Gambler("Doc Holliday");

        [Fact]
        public void GamblerCanSayHisName()
        {
            _gambler.Name.Should().Be("Doc Holliday");
        }

        [Fact]
        public void GamblerIsSortOfUgly()
        {
            _gambler.CharacterType.Should().Be(_gambler.CharacterType);
        }

        [Fact]
        public void GamblerKeepsHisCoolAndNeverYells()
        {
            Action action = () =>
            {
                var notPossible = _gambler.Yell;
            };
            action.Should()
                  .Throw<CoolGuyException>()
                  .WithMessage("cool guys never yell");
        }
    }
}
