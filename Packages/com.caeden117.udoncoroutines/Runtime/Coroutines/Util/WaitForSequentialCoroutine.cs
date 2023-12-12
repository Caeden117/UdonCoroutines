using UdonSharp;
using UnityEngine;

/// <summary>
/// A basic Udon Coroutine, which executes an inner list of Udon Coroutines sequentially (one after another.)
/// </summary>
public sealed class WaitForSequentialCoroutine : BaseUdonCoroutine
{
    [SerializeField] private BaseUdonCoroutine[] coroutines;

    private int coroutineIdx = 0;
    
    /// <summary>
    /// Starts this Coroutine with an overridden list of coroutines to execute sequentially.
    /// </summary>
    /// <param name="callback">Component to recieve events during this Coroutine (can be null).</param>
    /// <param name="coroutines">Overriding list of coroutines to execute.</param>
    public void StartUdonCoroutine(BaseUdonCoroutineCallback callback = null, params BaseUdonCoroutine[] coroutines)
    {
        if (coroutines != null && coroutines.Length > 0)
        {
            this.coroutines = coroutines;
        }

        base.StartUdonCoroutine(callback);
    }
    
    protected override void Setup()
    {
        coroutineIdx = 0;
        coroutines[0].StartUdonCoroutine();
    }

    protected override bool Tick()
    {
        // Stop early if our current coroutine is still executing 
        var currentCoroutine = coroutines[coroutineIdx];
        if (!currentCoroutine.Completed) return false;

        // This coroutine is complete if we've made it all the way through our list
        coroutineIdx++;
        if (coroutineIdx >= coroutines.Length) return true;

        // If not, start the next coroutine
        coroutines[coroutineIdx].StartUdonCoroutine();
        return false;
    }
}
