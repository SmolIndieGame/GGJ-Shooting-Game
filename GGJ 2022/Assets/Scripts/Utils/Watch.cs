using UnityEngine;

public class Watch
{
    double startTime;
    double duration;
    bool useScaledTime;
    bool timeOut;

    public bool TimeOut => timeOut || GetTime() - startTime >= duration;

    public Watch(double duration, bool useScaledTime, bool startAtZero = false)
    {
        this.duration = duration;
        this.useScaledTime = useScaledTime;
        if (startAtZero)
            startTime = 0;
        else
            startTime = GetTime();
        timeOut = false;
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
