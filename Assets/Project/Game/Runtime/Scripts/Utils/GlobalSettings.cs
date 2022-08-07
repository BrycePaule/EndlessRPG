using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalSettings
{
    public static float TravelSpeedScalar = 0.0005f;

    public static float EntityMoveTime = .3f; // in seconds
    public static float PlayerHitTimer = 1f; // in seconds

    public static float ExperienceMultiplier = 5f;

    // MAP
    public static float TilemapScale = 2f;

    // LAYERS
    public static int PlayerLayerIndex = 8;
    public static int MonsterLayerIndex = 9;
    public static int PickupsLayerIndex = 10;

}
