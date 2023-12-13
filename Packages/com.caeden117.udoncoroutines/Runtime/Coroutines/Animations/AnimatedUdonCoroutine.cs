using System;
using UdonSharp;
using UnityEngine;

/// <summary>
/// The base class for any Udon Coroutine implementing scripted animation. 
/// </summary>
public abstract class AnimatedUdonCoroutine : BaseUdonCoroutine
{
    [Header("Animated Udon Coroutine")]
    [Tooltip("Length of this animation, in seconds.")]
    [SerializeField]
    private float duration = 1f;
    
    [Tooltip("Define a custom easing for this animation as it progresses in normalized time (0-1)")]
    [SerializeField]
    private AnimationCurve animationCurve;

    private float progress;
    private bool useAnimationCurve;
    
    /// <summary>
    /// Starts this animated Udon Coroutine with an overriden animation length.
    /// </summary>
    /// <param name="duration">Overridden animation length, in seconds</param>
    /// <param name="callback">Component to recieve events during this Coroutine (can be null).</param>
    public void StartUdonCoroutine(float duration, BaseUdonCoroutineCallback callback = null)
    {
        this.duration = duration;

        StartUdonCoroutine(callback);
    }

    protected override void Setup()
    {
        progress = 0;
        useAnimationCurve = animationCurve != null;
        UpdateAnimation(0);
    }

    protected override bool Tick()
    {
        progress += Time.deltaTime / duration;

        // "progress" is raw [0-1] animation progress.
        // We will use a separate variable for post-curve progress
        var easedProgress = useAnimationCurve
            ? animationCurve.Evaluate(progress)
            : progress;
        
        UpdateAnimation(easedProgress);

        return progress >= 1;
    }

    protected override void OnCompletion() => UpdateAnimation(1);

    /// <summary>
    /// Updates the animation state with the current progress.
    /// </summary>
    /// <param name="progress">Normalized (0-1) progress of the animation, after an applicable curve or easing has been applied.</param>
    protected abstract void UpdateAnimation(float progress);
}
