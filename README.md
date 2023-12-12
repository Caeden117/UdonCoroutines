# Udon Coroutines

A collection of Udon scripts bringing basic coroutine-like functionality to Udon.

## Why?

VRChat Udon is a very restrictive sandbox, and there currently exists no tool to mimic the functionality of Unity's Coroutines.

Udon Coroutines, as the name implies, implements a basic Coroutine system with many basic Coroutines and utility scripts.

## Coroutine List

### `WaitForAllCoroutine`

Executes a list of inner Udon Coroutines at the same time, completing when all inner coroutines are complete.

### `WaitForAnyCoroutine`

Executes a list of inner Udon Coroutines at the same time, completing as soon as the first inner coroutine is complete.

### `WaitForSecondsCoroutine`

A simple Udon Coroutine which automatically completes after a set amount of time.

### `WaitForSequentialCoroutine`

Executes a list of inner Udon Coroutines sequentially (one after another), completing when all inner coroutines are complete.

## Custom Coroutines

Udon Coroutines allows you to script custom Coroutines and execute them with other Udon Coroutine scripts.

Custom Udon Coroutines should be written with UdonSharp. The Udon graphical scripting interface is untested.

To create a custom Udon Coroutine, inherit `BaseUdonCoroutine`, then override some methods.

```csharp
// BaseUdonCoroutine inherits UdonSharpBehaviour
public class ExampleUdonCoroutine : BaseUdonCoroutine
{
    // Executes when a script calls StartUdonCoroutine().
    // Should be used to initialize your coroutine.
    protected override void Setup() { }
    
    // Executes every frame, returning 'true' when this Udon Coroutine is considered complete.
    // Due to the slow speed of Udon, Tick() should be as fast as possible.
    protected override bool Tick();
    
    // Internal callback when this Udon Coroutine is complete.
    // Should be used to clean up resources used during the execution of this coroutine.
    protected override void OnCompletion() { }
}
```

## TODO
- Udon Coroutines for Unity Animations
- Udon Coroutines for scripted Animations / Tweens
- Publish to VCC