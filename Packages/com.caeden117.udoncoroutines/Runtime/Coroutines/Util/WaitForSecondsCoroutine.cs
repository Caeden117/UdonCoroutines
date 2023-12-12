using UdonSharp;
using UnityEngine;

/// <summary>
/// A basic Udon Coroutine, which waits a specified amount of time before completing.
/// </summary>
public sealed class WaitForSecondsCoroutine : BaseUdonCoroutine
{
    [SerializeField] private float seconds = 1f;

    private float destinationTime;
    
    /// <summary>
    /// Starts this Udon Coroutine with an overriden amount of seconds.
    /// </summary>
    /// <param name="seconds">Amount of time to wait, in seconds.</param>
    public void StartCoroutine(float seconds)
    {
        this.seconds = seconds;
        StartCoroutine();
    }

    protected override void Reset()
    {
        destinationTime = Time.time + seconds;
    }

    protected override bool Tick() => Time.time >= destinationTime;
}
