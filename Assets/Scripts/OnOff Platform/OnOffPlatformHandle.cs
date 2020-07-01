using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffPlatformHandle : MonoBehaviour
{
    private static float minSwitchTime = 0.1f;
    private static float lastSwitchTime = 0.01f;

    [SerializeField]
    private GameObject RedSwitch;
    [SerializeField]
    private GameObject BlueSwitch;

    [SerializeField]
    private GameObject RedPlatformOff;
    [SerializeField]
    private GameObject RedPlatformOn;
    [SerializeField]
    private GameObject BluePlatformOff;
    [SerializeField]
    private GameObject BluePlatformOn;

    private GameObject[] package;


    private void Start()
    {
        package = new GameObject[6];
        package[0] = RedSwitch;
        package[1] = BlueSwitch;
        package[2] = RedPlatformOff;
        package[3] = RedPlatformOn;
        package[4] = BluePlatformOff;
        package[5] = BluePlatformOn;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.CompareTag("Harmful") && Time.realtimeSinceStartup - lastSwitchTime > minSwitchTime)
        {
            foreach (var item in package)
                SwitchActive(item);
        }
        lastSwitchTime = Time.realtimeSinceStartup;
    }

    void SwitchActive(GameObject o1)
    {
        o1.SetActive(!o1.activeSelf);
    }

}
