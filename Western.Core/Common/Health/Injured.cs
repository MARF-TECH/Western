namespace Western.Core.Common.Health
{
    public class Injured : IHealthState
    {
        public HealthState State => HealthState.Injured;

        public void SetNextState(WesternMan human)
        {
            human.SetHealthState(new Killed());
        }
    }
}
