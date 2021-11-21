using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player
{
    static float START_COOLDOWN = 0.1f;
    static float JUMP_COOLDOWN = 0f;
    static float DUCK_COOLDOWN = 0f;
    static float MOVE_COOLDOWN = 0f;
    public static float RUN_SPEED = 10f;
    static float MOVE_SPEED = 25f;
    static float JUMP_POWER = 6f;
    static float GRAVITY_STRENGTH = 10f;
    static float DUCK_LENGTH = 1f;
    public Player(int lane, GameObject prefab, Game game)
    {
        this.lane = lane;
        height = 0f;
        verticalVelocity = 0f;
        duck = 0f;
        jumpCooldown = duckCooldown = moveCooldown = START_COOLDOWN;
        speed = RUN_SPEED;
        
        playerObject = Object.Instantiate(prefab);
        playerObject.transform.position = new Vector3(lane*Game.LANE_WIDTH, 0, 0);

        this.game = game;
    }
    public int lane;
    public float height;
    public float verticalVelocity;
    public float duck;
    public float speed;

    Game game;

    public float jumpCooldown;
    public float duckCooldown;
    public float moveCooldown;

    public GameObject playerObject;
    public void Update(float dt)
    {
        float prevPos = playerObject.transform.position.x;

        moveCooldown -= dt;
        if (height == 0f)
            jumpCooldown -= dt;
        if (duck <= 0f)
            duckCooldown -= dt;

        height += verticalVelocity * dt;
        if (height > 0)
            verticalVelocity -= GRAVITY_STRENGTH * dt;

        if (height < 0)
        { 
            height = 0f;
            verticalVelocity = 0f;
        }

        duck -= dt;
        
        speed += speed * 0.01f * dt;

        playerObject.transform.position = new Vector3(Mathf.Lerp(prevPos, lane*Game.LANE_WIDTH, MOVE_SPEED * dt), height, 0);

        Quaternion targetRotation = Quaternion.identity;
        Vector3 targetPosition = new Vector3(0f, 1f, 0f);

        if (duck > 0f && height <= 0f)
        {
            targetRotation = Quaternion.Euler(-90, 0, 0);
            targetPosition = new Vector3(0f, 0.5f, 0f);
        }
        
        playerObject.transform.GetChild(0).transform.rotation = Quaternion.Lerp(playerObject.transform.GetChild(0).transform.rotation,targetRotation,dt*10);
        playerObject.transform.GetChild(0).transform.localPosition = Vector3.Lerp(playerObject.transform.GetChild(0).transform.localPosition, targetPosition, dt * 10);
    }

    public void MoveLeft()
    {
        if (lane > 0 && moveCooldown <= 0f && !game.CheckCollisions(lane - 1))
        {
            lane--;
            moveCooldown = MOVE_COOLDOWN;
        }
    }
    public void MoveRight()
    {
        if (lane < Game.LANE_COUNT-1 && moveCooldown <= 0f && !game.CheckCollisions(lane + 1))
        {
            lane++;
            moveCooldown = MOVE_COOLDOWN;
        }
    }
    public void Jump()
    {
        if (height == 0f && jumpCooldown <= 0f)
        {
            verticalVelocity += JUMP_POWER;
            jumpCooldown = JUMP_COOLDOWN;
            duck = 0f;
        }
    }
    public void Duck()
    {
        if (duckCooldown <= 0f)
        {
            verticalVelocity = -10f;
            duckCooldown = DUCK_COOLDOWN;
            duck = DUCK_LENGTH;
        }
    }
    public void Destroy()
    {
        Object.Destroy(playerObject);
    }
}
