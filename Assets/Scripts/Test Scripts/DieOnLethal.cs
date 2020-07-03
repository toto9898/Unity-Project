using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnLethal : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManagerObj;

    private GameManager gameManager;

    private void Start()
    {
        if (gameManagerObj != null)
            gameManager = gameManagerObj.GetComponent<GameManager>();

        if (gameManager == null)
            Debug.LogWarning("Game manager not loaded on this object.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lethal"))
            if (gameObject.layer != collision.gameObject.layer)
            {
                if (gameObject.layer == LayerMask.NameToLayer("Player") && gameManager != null)
                    gameManager.LoadMainMenu();
                else
                    Destroy(gameObject);
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Lethal"))
            if (gameObject.layer != collision.collider.gameObject.layer)
            {
                if (gameObject.layer == LayerMask.NameToLayer("Player") && gameManager != null)
                    gameManager.LoadMainMenu();
                else
                    Destroy(gameObject);
            }
    }
}
