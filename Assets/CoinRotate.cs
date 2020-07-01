using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinRotate : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private float rotationAngle = 30f;


    // Start is called before the first frame update
    void Start()
    {
        TileBase[] tiles = tilemap.GetTilesBlock(tilemap.cellBounds);
        foreach (var tile in tiles)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
