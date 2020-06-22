using Western.Core.Common;
using Western.Core.Exceptions;

namespace Western.Core.Models
{
    public class Gambler : WesternMan
    {
        public CharacterType CharacterType => CharacterType.Ugly;

        public string Yell => throw new CoolGuyException();

        public override bool CanShoot => true;

        public override void Shoot(WesternMan enemy)
        {
            base.TakeTheShot(enemy, haveSomethingToSay: null, deathshot: true);
        }

        public Gambler(string name) : base(name)
        {
        }
    }
}
