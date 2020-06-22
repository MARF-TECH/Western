using Western.Core.Common;

namespace Western.Core.Models
{
    public class Cowboy : WesternMan
    {
        public CharacterType CharacterType => CharacterType.Bad;

        public string Yell => "Die, you sucker!";

        public override bool CanShoot => true;

        public Cowboy(string name): base(name)
        {
        }
    }
}
