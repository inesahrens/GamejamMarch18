using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalFlyer : GameEntity {

    public bool right = true;


    public override void Act()
    {
        if (right)
        {
            gameController.Move(this, new Vector2Int(1, 0));
        }
        else
        {
            gameController.Move(this, new Vector2Int(-1, 0));
        }

    }

    public void turn()
    {
        right = !right;
        GetComponent<SpriteRenderer>().flipX = !right;
    }

 
}
