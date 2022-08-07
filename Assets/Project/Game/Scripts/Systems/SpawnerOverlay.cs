using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpawnerOverlay : MonoBehaviour
{
    [SerializeField] private Spawner spawner;

    [SerializeField] private GameObject minOverlay;
    [SerializeField] private SpriteRenderer minOverlaySR;

    [SerializeField] private GameObject maxOverlay;
    [SerializeField] private SpriteRenderer maxOverlaySR;

    [SerializeField] private Color minColour;
    [SerializeField] private Color maxColour;

    private void LateUpdate()
    {
        minOverlay.transform.localScale = new Vector3(spawner.MinSpawnTilesFromPlayer, spawner.MinSpawnTilesFromPlayer, 0) * GlobalSettings.TilemapScale * 2;
        minOverlaySR.color = minColour;

        maxOverlay.transform.localScale = new Vector3(spawner.MaxSpawnTilesFromPlayer, spawner.MaxSpawnTilesFromPlayer, 0) * GlobalSettings.TilemapScale * 2;
        maxOverlaySR.color = maxColour;
    }
}
