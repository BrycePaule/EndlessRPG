using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    [SerializeField] private Slider xpBar;

    public int Level;
    public int currentXP;
    public int NextLevelXP;

    private void Awake()
    {
        currentXP = 0;
        Level = 1;
    }

    private void Start()
    {
        InitXPBar();
        UpdateXPBar();
    }

    public void CollectXP(int amount)
    {
        currentXP += amount;

        if (currentXP >= NextLevelXP) 
        { 
            Level += 1; 
            currentXP = currentXP % NextLevelXP;
            NextLevelXP = (int) (NextLevelXP * DifficultySettings.PlayerXPScalar);
        }

        UpdateXPBar();
    }

    public void InitXPBar()
    {
        xpBar.minValue = 0;
        xpBar.value = currentXP;
        xpBar.maxValue = NextLevelXP;
    }

    public void UpdateXPBar()
    {
        xpBar.value = currentXP;
        xpBar.maxValue = NextLevelXP;
    }

}
