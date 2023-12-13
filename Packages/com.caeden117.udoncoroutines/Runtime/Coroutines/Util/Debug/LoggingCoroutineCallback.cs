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

    public override void Setup(BaseUdonCoroutine sender)
    {
        if (!logReset) return;
        
        Debug.Log(objectName + " | Setup() from " + sender.name);
    }

    public override void Tick(BaseUdonCoroutine sender)
    {
        if (!logTick) return;
        
        Debug.Log(objectName + " | Tick() from " + sender.name);
    }

    public override void OnCompletion(BaseUdonCoroutine sender)
    {
        if (!logCompletion) return;
        
        Debug.Log(objectName + " | OnCompletion() from " + sender.name);
    }
}
