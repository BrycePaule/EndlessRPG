using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[ExecuteInEditMode]
public class PlayerPickup : MonoBehaviour
{
    private PlayerBase playerBase;
    private Light2D pickupRing;
    private CircleCollider2D pickupCollider;

    private void Awake()
    {
        playerBase = GetComponentInParent<PlayerBase>();
        pickupCollider = GetComponent<CircleCollider2D>();
        pickupRing = GetComponent<Light2D>();
    }

    private void FixedUpdate()
    {
        float radius = playerBase.StatsAsset.PickupRadius;

        pickupCollider.radius = radius / 2;

        pickupRing.pointLightInnerRadius = (radius * .75f) / 2;
        pickupRing.pointLightOuterRadius = radius / 2;
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
