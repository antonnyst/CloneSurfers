using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    Full,
    Bottom,
    Top
}

public class Obstacle
{
    public Obstacle(int lane, float length, float distance, ObstacleType type, GameObject model)
    {
        this.lane = lane;
        this.length = length;
        this.distance = distance;
        this.type = type;
        obstacleObject = Object.Instantiate(model);
        obstacleObject.transform.position = new Vector3(lane, 0, 0);
        float wallHeight = 0f;
        switch (type)
        {
            case ObstacleType.Full:
                wallHeight = 3f;
                break;
            case ObstacleType.Bottom:
                wallHeight = 1f;
                break;
            case ObstacleType.Top:
                wallHeight = 1.5f;
                break;
        }
        obstacleObject.transform.GetChild(0).transform.localScale = new Vector3(Game.LANE_WIDTH, wallHeight, length);
        if (type == ObstacleType.Top)
        {
            obstacleObject.transform.GetChild(0).transform.localPosition = new Vector3(0, 3f-(wallHeight/2), length / 2f);
        } else
        {
            obstacleObject.transform.GetChild(0).transform.localPosition = new Vector3(0, wallHeight/2, length / 2f);
        }
    }
    public int lane;
    public float length;
    public float distance;
    public ObstacleType type;

    GameObject obstacleObject;

    public void Update(float dt, float speed)
    {
        distance -= dt * speed;
        obstacleObject.transform.position = new Vector3(lane*Game.LANE_WIDTH, 0, distance);
    }
    public void Destroy()
    {
        Object.Destroy(obstacleObject);
    }
}
