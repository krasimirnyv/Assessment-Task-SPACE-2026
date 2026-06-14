namespace SpaceProgram.Services.Models;

public class MissionReport
{
    public MissionReport(IEnumerable<MissionResult> failedMissions,
                         IEnumerable<MissionResult> successfulMissions)
    {
        FailedMissions = failedMissions.ToList().AsReadOnly();
        SuccessfulMissions = successfulMissions.ToList().AsReadOnly();
    }

    public IReadOnlyCollection<MissionResult> FailedMissions { get; }

    public IReadOnlyCollection<MissionResult> SuccessfulMissions { get; }
}
