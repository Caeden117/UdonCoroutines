using UdonSharp;
using UnityEngine;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public sealed class LoggingCoroutineCallback : BaseUdonCoroutineCallback
{
    [SerializeField] private bool logReset = true;
    [SerializeField] private bool logTick = true;
    [SerializeField] private bool logCompletion = true;

    private string objectName;

    private void OnEnable() => objectName = $"Coroutine Callback ({gameObject.name})";

    public override void Reset()
    {
        if (!logReset) return;
        
        Debug.Log(objectName + " | Reset()");
    }

    public override void Tick()
    {
        if (!logTick) return;
        
        Debug.Log(objectName + " | Tick()");
    }

    public override void OnCompletion()
    {
        if (!logCompletion) return;
        
        Debug.Log(objectName + " | OnCompletion()");
    }
}
