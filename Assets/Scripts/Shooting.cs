using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private float shootingSpeed = 0.5f;

    [SerializeField]
    private float bulletsSpeed = 5f;

    Spawner spawner;
    enum BulletType { NORMAL, PARABOLIC, INVALID }
    private BulletType currentBulletType = BulletType.NORMAL;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (IsInvoking() == false)
                StartShoot();
        }
        else
            StopShoot();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ++currentBulletType;
            if (currentBulletType == BulletType.INVALID)
                currentBulletType = BulletType.NORMAL;
        }
    }

    void Shoot()
    {
        GameObject bullet = spawner.Spawn(
            (int)currentBulletType, 
            transform.position, 
            transform.parent.rotation);

        BulletMovement bulletMovement = bullet.GetComponent<BulletMovement>();
        if (bulletMovement)
            bulletMovement.speed = bulletsSpeed;
    }

    void StartShoot()
    {
        InvokeRepeating("Shoot", 0, shootingSpeed);
    }

    void StopShoot()
    {
        CancelInvoke();
    }
}
