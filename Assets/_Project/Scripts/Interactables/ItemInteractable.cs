using UnityEngine;

public class ItemInteractable : Interactable
{
    public string itemName;
    public override void OnInteract()
    {
        Debug.Log($"Player gets {itemName}");
    }
}
