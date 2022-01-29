using UnityEngine;

public class Watch
{
    public enum StartingState
    {
        Zero,
        CurTime,
        Full
    }

    double startTime;
    double duration;
    bool useScaledTime;
    bool timeOut;

    public bool TimeOut => timeOut || GetTime() - startTime >= duration;

    public Watch(double duration, bool useScaledTime, StartingState startingState = StartingState.CurTime)
    {
        this.duration = duration;
        this.useScaledTime = useScaledTime;
        switch (startingState)
        {
            case StartingState.Zero:
                startTime = 0;
                timeOut = false;
                break;
            case StartingState.CurTime:
                startTime = GetTime();
                timeOut = false;
                break;
            case StartingState.Full:
                startTime = GetTime() + duration;
                timeOut = true;
                break;
            default:
                break;
        }
    }

    private double GetTime()
    {
        return useScaledTime ? Time.timeAsDouble : Time.unscaledTimeAsDouble;
    }

    public void Reset()
    {
        startTime = GetTime();
        timeOut = false;
    }

    public void SetNewDuration(double duration)
    {
        this.duration = duration;
        timeOut = false;
    }
}
