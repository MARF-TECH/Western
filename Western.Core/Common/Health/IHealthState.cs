namespace Western.Core.Common.Health
{
    public interface IHealthState
    {
        void SetNextState(WesternMan human);

        HealthState State { get; }
    }
}
