using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntity : MonoBehaviour {

    void Awake()
    {
        FindObjectOfType<GameController>().entities.Add(this);
    }

    public abstract void Act();
}
