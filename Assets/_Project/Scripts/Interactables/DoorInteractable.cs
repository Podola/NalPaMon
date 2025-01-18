using UnityEngine;

public class DoorInteractable : Interactable
{
    public string doorName;
    public override void OnInteract()
    {
        Debug.Log($"Player opened {doorName}");
    }
}
