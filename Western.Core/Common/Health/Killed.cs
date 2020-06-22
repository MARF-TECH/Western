namespace Western.Core.Common.Health
{
    public class Killed : IHealthState
    {
        public HealthState State => HealthState.Killed;

        public void SetNextState(WesternMan human)
        {
           // already dead
        }
    }
}
