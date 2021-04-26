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

    public bool CheckFlag(string flag,List <string> flagList)
    {
        if (flag != "")
        {
            bool alternate = false;
            for (int i = 0; i < flagList.Count; i++)
            {
                if (flagList[i] == flag)
                {
                    alternate = true;
                    break;
                }
            }
            return alternate;
        }

        return true;
    }

    public void ShowButtons(List<string> optionsText, List<string> flags, List<string> activeFlags)
    {
        for (int i = 0; i < optionsText.Count; i++)
        {
            buttons[i].SetActive(CheckFlag(flags[i],activeFlags));
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
