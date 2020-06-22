using System;
using System.Collections.Generic;

using Western.Core.Exceptions;
using Western.Core.Common.Health;

namespace Western.Core.Common
{

    public abstract class WesternMan : IShooting
    {
        public string Name { get; }

        public IHealthState Health { get; private set; } = new Unharmed();
        public void SetHealthState(IHealthState state) => Health = state;

        public WesternMan(string name)
        {
            Name = name;
        }

        private readonly List<WesternMan> _shooters = new List<WesternMan>();

        public IEnumerable<WesternMan> Shooters => _shooters.AsReadOnly();

        public virtual void Shoot(WesternMan enemy) => TakeTheShot(enemy);

        public bool IsShot => Health.State != HealthState.Unharmed;

        public WesternMan KilledBy { get; protected set; }

        public abstract bool CanShoot { get; } // not everybody can shoot -- it needs skills 

        protected void TakeTheShot(WesternMan enemy, Action haveSomethingToSay = null, bool deathshot = false)
        {
            if (Health.State == HealthState.Killed) throw new CantShootException();

            if ((!enemy._shooters.Contains(this)) && haveSomethingToSay != null)
            {
                haveSomethingToSay.Invoke();
            }
            else
            {
                if (enemy.Health.State != HealthState.Killed) // already dead 
                {
                    if (deathshot) // instant kill (Wasted)
                    {
                        enemy.Health = new Killed();
                    }
                    else // update health bar 
                    {
                        enemy.Health.SetNextState(enemy);
                    }
                }
            }

            // update shooters health .. 
            if (!enemy._shooters.Contains(this)) enemy._shooters.Add(this);
            if (enemy.Health.State == HealthState.Killed) enemy.KilledBy = this; 
        }

    }
}
