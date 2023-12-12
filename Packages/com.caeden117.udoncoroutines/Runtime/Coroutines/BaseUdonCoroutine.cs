using UdonSharp;
using UnityEngine;

/// <summary>
/// The base coroutine class, of which all Udon Coroutines are built from.
/// </summary>
public abstract class BaseUdonCoroutine : UdonSharpBehaviour
{
    /// <summary>
    /// The completion status of this Udon Coroutine.
    /// </summary>
    public bool Completed { get; private set; } = false;

    /// <summary>
    /// The running state of this Udon Coroutine.
    /// </summary>
    public bool Running { get; private set; } = false;

    // Udon Coroutine callback component, can be null
    [SerializeField] BaseUdonCoroutineCallback callback = null;
    
    /// <summary>
    /// Starts this Udon Coroutine.
    /// </summary>
    public void StartCoroutine(BaseUdonCoroutineCallback callback = null)
    {
        if (callback != null)
        {
            this.callback = callback;
        }
        
        Reset();
        Completed = false;
        Running = true;
        enabled = true;

        if (callback == null) return;
        
        callback.Reset();
    }
    
    /// <summary>
    /// Resets the internal state of this Udon Coroutine.
    /// Called once when this Udon Coroutine is started.
    /// </summary>
    protected virtual void Reset() { }
    
    /// <summary>
    /// The internal ticking update for Udon Coroutines.
    /// </summary>
    /// <remarks>
    /// This method is called on the Unity Update loop for each frame this Coroutine is running.
    /// As such, performance of this Tick method is critical and should be as fast as possible.
    /// </remarks>
    /// <returns>
    /// Whether or not this coroutine has been completed.
    /// </returns>
    protected abstract bool Tick();
    
    /// <summary>
    /// Internal callback, called when this Udon Coroutine finishes.
    /// </summary>
    protected virtual void OnCompletion() { }

    // Because Udon Coroutines rely heavily on Update, automatically disable Update events on start.
    private void Awake() => enabled = false;
    
    private void Update()
    {
        if (!Running) return;

        var completion = Tick();

        if (callback != null)
        {
            callback.Tick();
        }

        if (!completion) return;
        
        Completed = true;
        Running = false;
        enabled = false;

        OnCompletion();

        if (callback == null) return;

        callback.OnCompletion();
    }
}
