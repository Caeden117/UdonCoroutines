using UdonSharp;
using UnityEngine;

/// <summary>
/// An Udon Coroutine that animates the world space euler rotation of a target <see cref="Transform"/>.
/// </summary>
/// <remarks>
/// This Coroutine internally converts Euler rotations into <see cref="Quaternion"/>s, then animates those.
/// </remarks>
public class AnimateEulerAnglesCoroutine : AnimatedUdonCoroutine
{
    [Header("Euler Angles Coroutine")]
    [Tooltip("Transform which will be animated.")]
    [SerializeField]
    private Transform target;
    
    [Tooltip("Starting rotation for the animation.")]
    [SerializeField]
    private Vector3 start;
    
    [Tooltip("Ending rotation for the animation.")]
    [SerializeField]
    private Vector3 end;

    private Quaternion startRotation;
    private Quaternion endRotation;
    
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

    protected override void Setup()
    {
        base.Setup();
        startRotation = Quaternion.Euler(start);
        endRotation = Quaternion.Euler(end);
    }
    
    protected override void UpdateAnimation(float progress)
    {
        target.rotation = Quaternion.Lerp(startRotation, endRotation, progress);
    }
}
