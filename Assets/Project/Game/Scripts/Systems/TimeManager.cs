using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float turnTime;

    [Header("References")]
    [SerializeField] private GameEvent_Int eTurnEnd;

    private float timer;

    private void Awake()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= turnTime)
        {
            eTurnEnd?.Raise(-1);
            timer = 0f;
        }
    }
}
