/**
 *@author: Weston R. Campbell
 *@organization: Outer Games Entertainment Inc.
 *@license: Free Use
 */

using UnityEngine;
using UnityEngine.Events;

public class TriggerUnityEvent : MonoBehaviour
{
    public UnityEvent executeOnEnter;
    public UnityEvent executeOnExit;
    public string triggerTag = "Player";
    public bool triggerEnterOnlyOnce;
    public bool triggerExitOnlyOnce;

    private bool _enterTriggered;
    private bool _exitTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (triggerEnterOnlyOnce && _enterTriggered) return;

        if (!other.CompareTag(triggerTag)) return;
        
        executeOnEnter?.Invoke();
        _enterTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (triggerExitOnlyOnce && _exitTriggered) return;

        if (!other.CompareTag(triggerTag)) return;

        executeOnExit?.Invoke();
        _exitTriggered = true;
    }
}
