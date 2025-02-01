using System;
using TMPro;
using UnityEngine;

public class DialogWindow : MonoBehaviour
{
    public TextMeshProUGUI text;
    public DialogData dialogData;
    private int count;
    private void OnEnable()
    {
        text.text = dialogData.dialogs[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(count == dialogData.dialogs.Count)
            count++;
            text.text = dialogData.dialogs[count];
        }
    }
}
