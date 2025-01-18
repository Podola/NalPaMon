using UnityEngine;

public class EventTriggerInteractable : Interactable
{
    public string eventTriggerName;
    public override void OnInteract()
    {
        Debug.Log($"Player triggered {eventTriggerName} event");
    }
}
