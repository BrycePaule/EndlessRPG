using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile tile;

    
    [Header("Settings")]
    public int Size;

    private void Awake()
    {
        SetTiles();
    }
    
	private void SetTiles()
	{
		for (int i = 0; i < Size; i++)
		{
			for (int j = 0; j < Size; j++)
			{
				Vector3Int _pos = new Vector3Int(i, j, 0);
                tilemap.SetTile(_pos, tile);
			}
		}
	}

}
