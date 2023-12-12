using UdonSharp;
using UnityEngine;

/// <summary>
/// A basic Udon Coroutine, which executes an inner list of Udon Coroutines in parallel, finishing when any inner coroutine is complete.
/// </summary>
public sealed class WaitForAnyCoroutine : BaseUdonCoroutine
{
    [SerializeField] private BaseUdonCoroutine[] coroutines;
    
    /// <summary>
    /// Starts this Coroutine with an overridden list of coroutines to execute in parallel.
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
        for (int i = 0; i < coroutines.Length; i++)
        {
            coroutines[i].StartUdonCoroutine();
        }
    }

    protected override bool Tick()
    {
        for (int i = 0; i < coroutines.Length; i++)
        {
            if (coroutines[i].Completed) return true;
        }

        return false;
    }
}
