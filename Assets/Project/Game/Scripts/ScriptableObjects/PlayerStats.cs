using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerStats", fileName = "New PlayerStats")]
public class PlayerStats : ScriptableObject
{

    public int MaxHealth;
    public float MovementSpeed;

}
