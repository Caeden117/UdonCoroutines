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
	/// <param name="sender">Udon Coroutine triggering this callback.</param>
	public virtual void Setup(BaseUdonCoroutine sender) { }

	/// <summary>
	/// Callback every frame an Udon Coroutine executes.
	/// </summary>
	/// <param name="sender">Udon Coroutine triggering this callback.</param>
	public virtual void Tick(BaseUdonCoroutine sender) { }

	/// <summary>
	/// Callback when an Udon Coroutine is completed.
	/// </summary>
	/// <param name="sender">Udon Coroutine triggering this callback.</param>
	public virtual void OnCompletion(BaseUdonCoroutine sender) { }
}
