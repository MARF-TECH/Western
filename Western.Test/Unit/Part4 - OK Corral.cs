using System;

using Xunit;
using FluentAssertions;

using Western.Core.Models;
using Western.Core.Exceptions;
using Western.Core.Common.Health;

namespace Western.Test.Unit
{
    /// <summary>
    ///  Shootings Tests: - ça a dégénéré... --- 
    /// </summary>
    public class Part4
    {
        private readonly Marshall _marshall;
        private readonly Cowboy _cowboy;
        private readonly Gambler _gambler;

        // new players for every new test .. 
        public Part4()
        {
            _marshall = new Marshall("Wyatt Earp");
            _cowboy = new Cowboy("Curly Bill Brocius");
            _gambler = new Gambler("Doc Holliday");
        }

        [Fact]
        public void MarshallInjureEnemyAfterWarning()
        {
            _marshall.Shoot(_cowboy);
            _cowboy.Health.State.Should().Be(HealthState.Unharmed);

            _marshall.Shoot(_cowboy);
            _cowboy.Shooters.Should().Contain(_marshall);
            _cowboy.Health.State.Should().Be(HealthState.Injured);
        }

        [Fact]
        public void MarshallKillEnemyAfterRegulatorySummons()
        {
            _marshall.Shoot(_cowboy); // first time warnings..
            _marshall.Shoot(_cowboy); // take the shot.. 

            _cowboy.Shooters.Should().Contain(_marshall);
            _cowboy.Health.State.Should().Be(HealthState.Injured);

            _marshall.Shoot(_cowboy);
            _cowboy.Health.State.Should().Be(HealthState.Killed);
        }

        [Fact]
        public void GamblerAlwaysShootToKill()
        {
            _gambler.Shoot(_cowboy);
            _cowboy.Health.State.Should().Be(HealthState.Killed);
            _cowboy.KilledBy.Should().Be(_gambler);
        }

        [Fact]
        public void TheDeadCantShoot()
        {
            // arrange 
            _gambler.Shoot(_marshall);
            _marshall.Health.State.Should().Be(HealthState.Killed);

            // act 
            Action action = () => _marshall.Shoot(_gambler);

            // assert 
            action.Should().Throw<CantShootException>();
        }

    }
}
