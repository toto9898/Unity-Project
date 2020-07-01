using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffBlockHandle : BlockInteractive
{
    public enum State { ACTIVE_BLUE, ACTIVE_RED }

    public static State GlobalState { get; private set; } = State.ACTIVE_BLUE;
    private State localState = State.ACTIVE_BLUE;

    protected override void Start()
    {
        base.Start();

        popDirection = Vector3.zero;

        if ((int)localState != (int)GlobalState)
        {
            StartPop();
            SwitchState();
        }
            

        OnPop += SwitchState;
    }

    protected override void Update()
    {
        base.Update();
        if (localState != GlobalState)
        {
            StartPop();
            SwitchState();
        }
    }

    private void OnDestroy()
    {
        OnPop -= SwitchState;
    }

    private new void SwitchState()
    {
        if (GlobalState == State.ACTIVE_BLUE)
            GlobalState = State.ACTIVE_RED;
        else
            GlobalState = State.ACTIVE_BLUE;

        localState = GlobalState;
    }

}
