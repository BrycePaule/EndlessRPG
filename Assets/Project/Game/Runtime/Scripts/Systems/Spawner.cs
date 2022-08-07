using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerBase player;
    [SerializeField] private Transform MonsterContainer;

    [SerializeField] private GameObject monster1;
    // [SerializeField] private GameObject monster2;
    // [SerializeField] private GameObject monster3;

    [Header("Settings")]
    public int MinSpawnTilesFromPlayer;
    public int MaxSpawnTilesFromPlayer;

    public int minEnemies;
    public int maxEnemies;

    private int stepCounter;
    private int enemyCount;

    private Vector3 SelectSpawnPos()
    {
        int distX = Mathf.RoundToInt(Random.Range(MinSpawnTilesFromPlayer, MaxSpawnTilesFromPlayer) * GlobalSettings.TilemapScale);
        int distY = Mathf.RoundToInt(Random.Range(MinSpawnTilesFromPlayer, MaxSpawnTilesFromPlayer) * GlobalSettings.TilemapScale);

        return new Vector3(
            Roll(50) ? player.transform.position.x + distX : player.transform.position.x - distX,
            Roll(50) ? player.transform.position.y + distY : player.transform.position.y - distY,
            0
        );
    }

    private bool Roll(float chance)
    {
        chance = Mathf.Clamp(chance, 0, 100);
        float roll = Random.Range(0, 100);

        return roll <= chance;
    }

    public void Spawn()
    {
        Instantiate(monster1, SelectSpawnPos(), Quaternion.identity, MonsterContainer);
    }

    public void SpawnRound()
    {
        UpdateEnemyCount();

        if (enemyCount < minEnemies)
        {
            Spawn();
        }
    }

    private void UpdateEnemyCount()
    {
        int count = 0;

        foreach (Transform t in MonsterContainer)
        {
            count += 1;
        }

        enemyCount = count;
    }

}
