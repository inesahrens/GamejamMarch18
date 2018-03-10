using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<GameEntity> entities;
    public static int mapSizeX = 20;
    public static int mapSizeY = 20;
    public GameEntity[,] map = new GameEntity [mapSizeX, mapSizeY];

    public void register(GameEntity entity)
    {
        entities.Add(entity);
        add(entity, entity.position);
    }

    private void remove(GameEntity entity)
    {
        int x = entity.position.x;
        int y = entity.position.y;
        map[x, y] = null;
    }

    private void add(GameEntity entity, Vector2Int vector)
    {
        int x = vector.x;
        int y = vector.y;
        if (map[x,y] == null)
        {
            map[x, y] = entity;
        } else
        {
            Debug.LogError("Tried to move " + entity + " to " + x + "," + y + " but already used by " + map[x, y]);
        }
    }

	public void act()
    {
        entities.RemoveAll(x => x == null);
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

    public void Move(GameEntity entity, Vector2Int vector)
    {
        Vector2Int goal = entity.position + vector;
        int x = goal.x;
        int y = goal.y;
        if (map[x, y] != null)
        {
            collide(entity, map[x, y]);
            return;
        }
        remove(entity);
        add(entity, goal);
        entity.gameObject.transform.Translate(new Vector2 (vector.x, vector.y));
        entity.position += vector;
    }

    private void collide(GameEntity moving, GameEntity other)
    {
        if (moving is HorizontalFlyer)
        {
            if (other is Terrain)
            {
                ((HorizontalFlyer) moving).turn();
            }
        }
    }
}
