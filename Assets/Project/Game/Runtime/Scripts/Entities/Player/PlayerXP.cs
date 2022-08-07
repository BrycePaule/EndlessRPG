using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    [SerializeField] private Slider xpBar;
    [SerializeField] private GameEvent_Int eLevelUp;

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
            LevelUp();
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

    public void LevelUp()
    {
        Level += 1; 
        currentXP = currentXP % NextLevelXP;
        NextLevelXP = Mathf.RoundToInt(NextLevelXP * DifficultySettings.PlayerXPScalar);
        UpdateXPBar();

        eLevelUp?.Raise(Level);
    }

}
