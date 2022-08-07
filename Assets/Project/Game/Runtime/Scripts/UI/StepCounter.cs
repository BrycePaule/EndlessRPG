using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StepCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text countText;
    
    private int stepCounter;

    private void Awake()
    {
        stepCounter = 0;
    }

    public void Increment()
    {
        stepCounter += 1;
        countText.SetText(stepCounter.ToString());
    }

}
