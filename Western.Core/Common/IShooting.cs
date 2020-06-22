using System.Collections.Generic;

namespace Western.Core.Common
{
    public interface IShooting
    {
        bool CanShoot { get; }

        WesternMan KilledBy { get; }

        void Shoot(WesternMan enemy);

        // A Westren Man May Have Quarrel With Alot OF FOLKS !!
        IEnumerable<WesternMan> Shooters { get; }
    }
}
