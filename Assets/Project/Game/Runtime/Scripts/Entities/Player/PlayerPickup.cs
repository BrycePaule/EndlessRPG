using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerPickup : MonoBehaviour
{
    private PlayerBase playerBase;

    private void Awake()
    {
        playerBase = GetComponentInParent<PlayerBase>();
    }

    private void FixedUpdate()
    {
        float radius = playerBase.StatsAsset.PickupRadius;
        transform.localScale = new Vector3(radius, radius, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == GlobalSettings.PickupsLayerIndex)
        {
            playerBase.GetComponentInChildren<PlayerXP>().CollectXP(10);
            Destroy(other.gameObject);
        }
    }
}
