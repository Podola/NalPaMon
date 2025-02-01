using System;
using UnityEngine;
using UnityEngine.Events;

public class NpcDialog : MonoBehaviour
{
    public UnityEvent dialog; 
    public void DialogExecution()
    {
        dialog?.Invoke();
    }
}
