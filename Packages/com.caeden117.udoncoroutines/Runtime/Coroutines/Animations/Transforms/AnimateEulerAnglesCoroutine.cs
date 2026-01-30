using UdonSharp;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// An Udon Coroutine that animates the world space euler rotation of a target <see cref="Transform"/>.
///
/// Additional edits by DubbyDragon
/// </summary>
/// <remarks>
/// This Coroutine internally converts Euler rotations into <see cref="Quaternion"/>s, then animates those.
/// </remarks>
public class AnimateEulerAnglesCoroutine : AnimatedUdonCoroutine
{
    
#region VARIABLES
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
    private Quaternion _startRotation;
    private Quaternion _endRotation;
#endregion
    
#region GETTERS_SETTERS
        
    public Vector3 GetEnd()
    {
        return end;
    }
    
    public void SetEnd(Vector3 endEulerAngles)
    {
        end = endEulerAngles;
    }
    
    public Vector3 GetStart()
    {
        return end;
    }
    
    public void SetStart(Vector3 startEulerAngles)
    {
        end = startEulerAngles;
    }
#endregion
    
#region COROUTINE_METHODS
    /// <summary>
    /// Starts this Udon Coroutine with overridden start and ending points, duration, and callback.
    /// </summary>
    /// <param name="startEulerAngles">Override starting vector.</param>
    /// <param name="endEulerAngles">Override ending vector.</param>
    /// <param name="duration">Overridden animation length, in seconds</param>
    /// <param name="endCallback">Component to recieve events during this Coroutine (can be null).</param>
    public void StartUdonCoroutine(Vector3 startEulerAngles, Vector3 endEulerAngles, float duration = 1f,
        BaseUdonCoroutineCallback endCallback = null)
    {
        this.start = startEulerAngles;
        this.end = endEulerAngles;
        
        _startRotation = Quaternion.Euler(start);
        _endRotation = Quaternion.Euler(end);
        
        StartUdonCoroutine(duration, endCallback);
    }
    

    /// <summary>
    /// A mirror to the base callback allowing you to not have to add a start and end parameter. that calls the base function
    /// This allows for more flexible usage
    /// </summary>
    /// <author>DubstepDragon</author>
    /// <param name="duration"></param>
    /// <param name="endCallback"></param>
    public void StartUdonCoroutineRaw(float duration = 1f,
        BaseUdonCoroutineCallback endCallback = null)
    {
        StartUdonCoroutine(start, end, duration, endCallback);
    }
#endregion

#region OVERRIDES
    protected override void UpdateAnimation(float progress)
    {
        target.rotation = Quaternion.Lerp(_startRotation, _endRotation, progress);
    }
#endregion
}
