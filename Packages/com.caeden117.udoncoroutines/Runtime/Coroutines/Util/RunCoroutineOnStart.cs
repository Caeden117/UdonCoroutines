using UdonSharp;
using UnityEngine;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public sealed class RunCoroutineOnStart : UdonSharpBehaviour
{
    [SerializeField] private BaseUdonCoroutine coroutine;

    private void Start()
    {
        if (coroutine == null) return;

        coroutine.StartUdonCoroutine();
    }
}
