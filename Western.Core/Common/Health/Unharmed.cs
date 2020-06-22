namespace Western.Core.Common.Health
{
    public class Unharmed : IHealthState
    {
        public HealthState State => HealthState.Unharmed;

        public void SetNextState(WesternMan human)
        {
            human.SetHealthState(new Injured());
        }
    }
}
