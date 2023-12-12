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
    /// <param name="callback">Component to recieve events during this Coroutine (can be null).</param>
    public void StartUdonCoroutine(float seconds, BaseUdonCoroutineCallback callback = null)
    {
        if (callback != null)
        {
            this.callback = callback;
        }
        
        this.seconds = seconds;
        StartUdonCoroutine(callback);
    }

    protected override void Setup()
    {
        destinationTime = Time.time + seconds;
    }

    protected override bool Tick() => Time.time >= destinationTime;
}
