using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoredisplay : MonoBehaviour
{
    public TMP_Text scoretext;
    void Start()
    {
        scoretext.SetText(GM.score.ToString());
    }
    void Update()
    {
        
    scoretext.SetText(GM.score.ToString());
    }
}
