using System.Collections.Generic;

using Western.Core.Common;

namespace Western.Core.Models
{
    public class Marshall : WesternMan
    {
        public CharacterType CharacterType => CharacterType.Good;

        public string Yell => "Throw up your hands!";

        public override bool CanShoot => true;

        public override void Shoot(WesternMan enemy)
        {
            base.TakeTheShot(enemy, () => ReadRightsBeforeShooting());
        }

        public Marshall(string name) : base(name)
        {
        }

        public string ReadRightsBeforeShooting() => $"This is your last warning, {Yell}";
    }
}
