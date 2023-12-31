﻿using System;
using UdonSharp;
using UnityEngine;

/// <summary>
/// The base coroutine class, of which all Udon Coroutines are built from.
/// </summary>
public abstract class BaseUdonCoroutine : UdonSharpBehaviour
{
    // Udon Coroutine callback component, can be null
    [Header("Base Udon Coroutine")]
    [Tooltip("Optional field, specifying a Callback component which will recieve events from this Coroutine.")]
    [SerializeField]
    protected BaseUdonCoroutineCallback callback = null;
    
    /// <summary>
    /// The completion status of this Udon Coroutine.
    /// </summary>
    public bool Completed { get; private set; } = false;

    /// <summary>
    /// The running state of this Udon Coroutine.
    /// </summary>
    public bool Running { get; private set; } = false;
    
    /// <summary>
    /// Starts this Udon Coroutine.
    /// </summary>
    /// <param name="callback">Component to recieve events during this Coroutine (can be null).</param>
    public void StartUdonCoroutine(BaseUdonCoroutineCallback callback = null)
    {
        if (Running)
        {
            Debug.LogError("Cannot start an Udon Coroutine while the coroutine is already running!");
            return;

            // Guh.
            //throw new InvalidOperationException("Cannot start a Udon Coroutine while the coroutine is already running!");
        }
        
        if (callback != null)
        {
            this.callback = callback;
        }
        
        Setup();
        Completed = false;
        Running = true;
        enabled = true;

        if (callback == null) return;
        
        callback.Setup(this);
    }
    
    /// <summary>
    /// Resets the internal state of this Udon Coroutine.
    /// Called once when this Udon Coroutine is started.
    /// </summary>
    protected virtual void Setup() { }
    
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
    private void Start() => enabled = false;
    
    private void Update()
    {
        if (!Running) return;

        var completion = Tick();

        if (callback != null)
        {
            callback.Tick(this);
        }

        if (!completion) return;
        
        Completed = true;
        Running = false;
        enabled = false;

        OnCompletion();

        if (callback == null) return;

        callback.OnCompletion(this);
    }
}
