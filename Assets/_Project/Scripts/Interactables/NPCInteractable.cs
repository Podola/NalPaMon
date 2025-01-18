using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : Interactable
{
    public string NPCName;
    public List<string> dialogueLines;

    public override void OnInteract()
    {
        Debug.Log($"Player starts a conversation with {NPCName}");

        DialogueManager.instance.StartDialogue(dialogueLines);  
    }
}
