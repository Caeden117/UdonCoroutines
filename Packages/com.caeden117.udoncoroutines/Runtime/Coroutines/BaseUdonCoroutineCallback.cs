using UdonSharp;
using UnityEngine;

/// <summary>
/// A base Udon script for receiving updates from any Udon Coroutine. 
/// </summary>
public abstract class BaseUdonCoroutineCallback : UdonSharpBehaviour
{
	/// <summary>
	/// Callback when a Udon Coroutine has reset its internal state.
	/// </summary>
	public virtual void Setup() { }

	/// <summary>
	/// Callback every frame an Udon Coroutine executes.
	/// </summary>
    public virtual void Tick() { }

	/// <summary>
	/// Callback when an Udon Coroutine is completed.
	/// </summary>
    public virtual void OnCompletion() { }
}
