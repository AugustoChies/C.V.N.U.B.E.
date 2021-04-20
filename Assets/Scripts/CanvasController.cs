using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private Image background;
    [SerializeField]
    private Image portrait;
    [SerializeField]
    private GameObject textWindow;
    [SerializeField]
    private TextMeshProUGUI dialogue;
    [SerializeField]
    private List<GameObject> buttons;
   

    public void ChangeBackground(Sprite newB)
    {
        background.sprite = newB;        
    }

    public void ChangePortrait(Sprite newP)
    {
        portrait.enabled = true;
        portrait.sprite = newP;        
    }

    public void DisablePortrait()
    {
        portrait.enabled = false;
    }

    public void StartNewDialogue(string newText)
    {
        dialogue.text = newText;
    }

    public void ShowButtons(List<string> optionsText)
    {
        for (int i = 0; i < optionsText.Count; i++)
        {
            buttons[i].SetActive(true);
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = optionsText[i];            
        }
    }

    public void DisableButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetActive(false);
        }
    }
}
