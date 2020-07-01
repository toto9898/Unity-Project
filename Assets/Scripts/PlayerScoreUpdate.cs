using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScoreUpdate : MonoBehaviour
{
    [SerializeField]
    private Tilemap coinsTilemap;

    [SerializeField]
    BoxCollider2D boxCollider;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins") == false)
            return;

        Vector3 hit = boxCollider.bounds.center;
        Vector3Int cellPos = coinsTilemap.WorldToCell(hit);

        if (coinsTilemap.HasTile(cellPos))
        {
            coinsTilemap.SetTile(cellPos, null);
            ++Score.score;
        }
    }
}
