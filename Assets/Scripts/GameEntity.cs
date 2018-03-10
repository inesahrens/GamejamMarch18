using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntity : MonoBehaviour {

    public GameController gameController;
    public Vector2Int position;

    void Awake()
    {
        position = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        gameController = FindObjectOfType<GameController>();
        gameController.register(this);
    }

    public abstract void Act();
}
