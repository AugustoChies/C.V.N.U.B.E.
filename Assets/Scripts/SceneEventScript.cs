using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class SceneEventScript : ScriptableObject
{
    public Sprite background;
    public List<Sprite> portraitList;
    public AudioClip music;
    public List<string> text;
    public bool hasChoice;
    [Space()]
    [Header("Natural Progression")] 
    public SceneEventScript destination;

    [Space()]
    [Header("Multiple Choice")]
    public List<string> optionsText;
    public List<SceneEventScript> destinationList;
}
