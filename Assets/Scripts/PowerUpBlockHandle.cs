using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBlockHandle : BlockInteractive
{
    PowerUpMovement powMovement;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        powMovement = GetComponentInChildren<PowerUpMovement>();
        OnPop += powMovement.Activate;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }


    private void OnDestroy()
    {
        //popCheck.OnPop -= StartPop;
        OnPop -= powMovement.Activate;
    }
}
