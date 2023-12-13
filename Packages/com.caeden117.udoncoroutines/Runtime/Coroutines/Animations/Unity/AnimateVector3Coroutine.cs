using UdonSharp;
using UnityEngine;

/// <summary>
/// Udon Coroutine specializing in general <see cref="Vector3"/> usecases.
/// </summary>
/// <remarks>
/// Consider AnimateEulerCoroutine if you would like to animate Vector3s as Euler Angles.
/// </remarks>
public class AnimateVector3Coroutine : AnimatedUdonCoroutine
{
    [Header("Vector3 Coroutine")]
    [Tooltip("Starting value.")]
    [SerializeField]
    private Vector3 start;
    
    [Tooltip("Ending value.")]
    [SerializeField]
    private Vector3 end;

    /// <summary>
    /// The current <see cref="Vector3"/> during animation.
    /// </summary>
    public Vector3 Vector => result;
    
    private Vector3 result;
    
    /// <summary>
    /// Starts this Udon Coroutine with overridden start and ending points, duration, and callback.
    /// </summary>
    /// <param name="start">Override starting vector.</param>
    /// <param name="end">Override ending vector.</param>
    /// <param name="duration">Overridden animation length, in seconds</param>
    /// <param name="callback">Component to recieve events during this Coroutine (can be null).</param>
    public void StartUdonCoroutine(Vector3 start, Vector3 end, float duration = 1f,
        BaseUdonCoroutineCallback callback = null)
    {
        this.start = start;
        this.end = end;
        
        StartUdonCoroutine(duration, callback);
    }
    
    protected override void UpdateAnimation(float progress)
    {
        result = Vector3.Lerp(start, end, progress);
    }
}
