using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject uiIndicator;

    private void Awake()
    {
        if(uiIndicator != null)
        {
            uiIndicator.SetActive(false);
        }
    }

    public virtual void OnInteract()
    {
    }

    public void ShowIndicator()
    {
        if(uiIndicator != null)
        {
            uiIndicator.SetActive(true);
        }
    }

    public void HideIndicator()
    {
        if(uiIndicator != null)
        {
            uiIndicator.SetActive(false);
        }
    }
}
