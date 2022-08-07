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
    public float MinSpawnDistanceFromPlayer;
    public float MaxSpawnDistanceFromPlayer;

    [Header("Timer")]
    [SerializeField] private float spawnIncrement;
    private float timer;


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnIncrement)
        {
            Instantiate(monster1, SelectSpawnPos(), Quaternion.identity, MonsterContainer);
            timer = 0f;
        }
    }

    private Vector3 SelectSpawnPos()
    {
        int distX = (int) Random.Range(MinSpawnDistanceFromPlayer, MaxSpawnDistanceFromPlayer);
        int distY = (int) Random.Range(MinSpawnDistanceFromPlayer, MaxSpawnDistanceFromPlayer);

        return new Vector3(
            2 * (Roll(50) ? player.transform.position.x + distX : player.transform.position.x - distX),
            2 * (Roll(50) ? player.transform.position.y + distY : player.transform.position.y - distY),
            0
        );
    }

    private bool Roll(float chance)
    {
        chance = Mathf.Clamp(chance, 0, 100);
        float roll = Random.Range(0, 100);

        return roll <= chance;
    }

}
