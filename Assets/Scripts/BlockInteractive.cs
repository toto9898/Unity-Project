using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInteractive : Poppable
{
    [SerializeField]
    protected Sprite initialSprite;

    [SerializeField]
    protected Sprite poppedSprite;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        PoppingHeight /= 7;
        PoppingSpeed *= 2;

        popDirection = transform.up;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = initialSprite;

        OnGoingDown += SwitchState;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();


    }

    protected void SwitchState()
    {
        if (spriteRenderer.sprite == initialSprite)
            spriteRenderer.sprite = poppedSprite;
        else
            spriteRenderer.sprite = initialSprite;
    }

    private void OnDestroy()
    {
        OnGoingDown -= SwitchState;
    }
}
