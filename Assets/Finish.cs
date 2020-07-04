using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private GameObject FinishScreen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.NameToLayer("Player") == collision.gameObject.layer)
        {
            FinishScreen.SetActive(true);
            Invoke("LoadMenu", 3);
        }
    }

    void LoadMenu() => gameManager.LoadMainMenu();

}
