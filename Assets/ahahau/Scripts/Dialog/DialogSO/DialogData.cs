using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DialogData", menuName = "Scriptable Objects/DialogData")]
public class DialogData : ScriptableObject
{
    public enum type
    {
        Player,
        Npc,
        Enemy
    }
    public List<string> dialogs = new List<string>();
}
