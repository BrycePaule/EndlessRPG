using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerOverlay : MonoBehaviour
{

	[SerializeField] private Spawner spawner;

	[SerializeField] private GameObject minOverlay;
	[SerializeField] private SpriteRenderer minOverlaySR;

	[SerializeField] private GameObject maxOverlay;
	[SerializeField] private SpriteRenderer maxOverlaySR;

	[SerializeField] private Color minColour;
	[SerializeField] private Color maxColour;

	private void FixedUpdate()
	{
		minOverlay.transform.localScale = new Vector3(spawner.MinSpawnDistanceFromPlayer, spawner.MinSpawnDistanceFromPlayer, 0) * 2;
		minOverlaySR.color = minColour;

		maxOverlay.transform.localScale = new Vector3(spawner.MaxSpawnDistanceFromPlayer, spawner.MaxSpawnDistanceFromPlayer, 0) * 2;
		maxOverlaySR.color = maxColour;
	}
}
