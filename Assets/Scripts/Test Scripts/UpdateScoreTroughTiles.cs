using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UpdateScoreTroughTiles : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap = null;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Vector3 hit = collision.collider.gameObject.GetComponent<BoxCollider2D>().bounds.center;
            Vector3Int cellPos = tilemap.WorldToCell(hit);

            if (tilemap.HasTile(cellPos))
            {
                tilemap.SetTile(cellPos, null);
                ++Score.score;
            }
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 hit = collision.gameObject.GetComponent<BoxCollider2D>().bounds.center;
            Vector3Int cellPos = tilemap.WorldToCell(hit);

            if (tilemap.HasTile(cellPos))
            {
                tilemap.SetTile(cellPos, null);
                ++Score.score;
            }
        }
    }
}
