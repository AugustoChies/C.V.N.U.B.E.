using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public SceneList allScenes;

    //for debug purposes
    public SceneEventScript startingScene;
    //for debug purposes

    public CanvasController storyCanvas;
    public AudioSource source;

    private int currentText;
    private List<Sprite> currentPortraitList;    
    [Space()]
    [SerializeField]
    private SceneEventScript currentScene;

    private List<SceneEventScript> possibleScenes;

    public bool selectionMode = false;

    void Start()
    {
        NewScene(startingScene);
        possibleScenes = new List<SceneEventScript>();
    }

    private void Update()
    {
        if (selectionMode) return;

        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            AdvanceDialogue();
        }
    }

    public void NewScene(SceneEventScript newScene)
    {
        Debug.Log("Started scene " + newScene.name);
        currentScene = newScene;
        currentText = 0;
        try
        {
            storyCanvas.ChangeBackground(newScene.background);
        }
        catch (System.Exception)
        {
            Debug.LogError("There is no background assigned to scene " + newScene.name);
        }
        try
        {
            if (source.clip != newScene.music)
            {
                source.clip = newScene.music;
                source.Play();
            }
        }
        catch (System.Exception)
        {
            Debug.LogWarning("There is no music assigned to scene " + newScene.name);
        }

        AdvanceDialogue();
    }

    public void AdvanceDialogue()
    {        
        if(currentText >= currentScene.text.Count)
        {
            if(currentScene.hasChoice)
            {
                ActivateButtons();                
            }
            else
            {
                NewScene(currentScene.destination);
            }
            
            return;
        }
        string newText = ChangePortrait(currentScene.text[currentText]); ;
        
        storyCanvas.StartNewDialogue(newText);
        currentText++;
    }


    public string ChangePortrait(string inputText)
    {
        string idtext = inputText.Substring(0,1);
        int id = 0;
        if(int.TryParse(idtext,out id))
        {
            try
            {
                storyCanvas.ChangePortrait(currentScene.portraitList[id]);
            }
            catch (System.Exception)
            {
                Debug.LogError("There is no portait assigned to scene " + currentScene.name);
            }
            return inputText.Remove(0, 1);
        }
        else
        {
            storyCanvas.DisablePortrait();
            return inputText;
        }
    }


    public void ActivateButtons()
    {
        selectionMode = true;
        List<string> buttontexts = new List<string>(); 
        possibleScenes.Clear();
        for (int i = 0; i < currentScene.destinationList.Count; i++)
        {
            if(currentScene.destinationList[i] != null)
            {
                possibleScenes.Add(currentScene.destinationList[i]);
                buttontexts.Add(currentScene.optionsText[i]);
            }            
        }
        storyCanvas.ShowButtons(buttontexts);
    }

    public void ButtonOption1()
    {        
        storyCanvas.DisableButtons();
        NewScene(possibleScenes[0]);
        selectionMode = false;
    }

    public void ButtonOption2()
    {
        storyCanvas.DisableButtons();
        NewScene(possibleScenes[1]);
        selectionMode = false;
    }

    public void ButtonOption3()
    {
        storyCanvas.DisableButtons();
        NewScene(possibleScenes[2]);
        selectionMode = false;
    }
}
