using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<GameEntity> entities;

	public void act()
    {
        foreach (GameEntity entity in entities)
        {
            entity.Act();
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            act();
        }
    }
}
