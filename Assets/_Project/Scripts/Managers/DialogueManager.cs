using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance {  get; private set; }
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;

    private Queue<string> dialogueLines = new Queue<string>();
    private Coroutine typingCoroutine;
    private float typingSpeed = 0.05f;
    private string currentTypingLine;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        dialogueBox.SetActive(false);
    }

    public void StartDialogue(List<string> lines)
    {
        dialogueLines.Clear();

        foreach(string line in lines)
        {
            dialogueLines.Enqueue(line);
        }

        dialogueBox.SetActive(true);
        DisplayNextLine();
    }

    private void DisplayNextLine()
    {
        if(dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        currentTypingLine = dialogueLines.Dequeue();
        typingCoroutine = StartCoroutine(TypeLine(currentTypingLine));
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        dialogueText.text = "";
    }

    private IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        // 코루틴 종료 시 참조 해제 처리
        typingCoroutine = null;

    }
    private void SkipTyping()
    {
        if (typingCoroutine != null)
        {
            dialogueText.text = currentTypingLine;
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        else
        {
            DisplayNextLine();
        }
    }

    private void Update()
    {
        if(!dialogueBox.activeInHierarchy)
        {
            return; 
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SkipTyping();
        }
    }
}
