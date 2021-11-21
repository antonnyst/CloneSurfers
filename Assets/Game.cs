using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Game : MonoBehaviour
{
    static public int LANE_COUNT = 3;
    static public float LANE_WIDTH = 1.75f;
    static public float SPAWN_DISTANCE = 40f;

    void Awake()
    {
        InitGame();
        floorObject.transform.localScale = new Vector3(LANE_COUNT * LANE_WIDTH / 10f, 1, 15);
        floorObject.transform.position = new Vector3(LANE_COUNT * LANE_WIDTH / 2f - LANE_WIDTH/2f, 0, 60);
    }

    Player player;
    bool running;
    public GameObject playerPrefab;
    public GameObject[] models;
    public GameObject cameraObject;
    public Text textObject;
    public GameObject gameOverScreen;
    public Text highscoreText;
    public GameObject floorObject;
    float score;
    ObstacleGenerator obstacleGenerator;
    public float slow = 1f;
    void Update()
    {
        float dt = Time.deltaTime * slow;

        if (Input.GetKeyDown(KeyCode.U))
        {
            slow += 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            slow -= 0.1f;
        }

        if (running)
        {
            obstacleGenerator.Run(dt * player.speed);

            CheckInput();

            player.Update(dt);

            List<Obstacle> toRemove = new List<Obstacle>();
            foreach (Obstacle obstacle in obstacleGenerator.obstacles)
            {
                obstacle.Update(dt, player.speed);
                if (CheckCollision(obstacle))
                {
                    GameOver(); 
                }
                if (obstacle.distance + obstacle.length < -10f)
                {
                    obstacle.Destroy();
                    toRemove.Add(obstacle);
                }
            }
            foreach (Obstacle obstacle in toRemove)
            {
                obstacleGenerator.obstacles.Remove(obstacle);
            }

            score += player.speed * dt * 2;
            textObject.text = score.ToString("0");
        }
    }
    
    public bool CheckCollisions(int lane)
    {
        foreach (Obstacle obstacle in obstacleGenerator.obstacles)
        {
            if (CheckCollision(obstacle,lane))
            {
                return true;
            }
        }
        return false;
    }
    
    bool CheckCollision(Obstacle obstacle)
    {
        return CheckCollision(obstacle, player.lane);
    }
    bool CheckCollision(Obstacle obstacle,int lane)
    {
        if (lane != obstacle.lane)
            return false;
        if (obstacle.distance > 0f || obstacle.distance + obstacle.length < 0f)
            return false;

        switch (obstacle.type)
        {
            case ObstacleType.Bottom:
                if (player.height > 1f)
                    return false;
                else
                    return true;
            case ObstacleType.Top:
                if (player.height == 0f && player.duck > 0f)
                    return false;
                else
                    return true;
            case ObstacleType.Full:
                return true;
        }
        return false;
    }
    
    void GameOver()
    {
        running = false;
        gameOverScreen.SetActive(true);
        float highScore = Mathf.Max(score, PlayerPrefs.GetFloat("highscore"));
        highscoreText.text = "Highscore : " + highScore.ToString("0");
        PlayerPrefs.SetFloat("highscore", highScore);
        PlayerPrefs.Save();
    }

    public void ResetGame()
    {
        gameOverScreen.SetActive(false);
        foreach (Obstacle obstacle in obstacleGenerator.obstacles)
        {
            obstacle.Destroy();
        }
        player.Destroy();
        InitGame();
    }
    void InitGame()
    {
        player = new Player(Mathf.CeilToInt(LANE_COUNT/2), playerPrefab, this);
        obstacleGenerator = new ObstacleGenerator(models[0]);
        score = 0f;
        running = true;
    }

    Vector2 initialTouchPosition = Vector2.negativeInfinity;
    void CheckInput()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartSwipe(Input.mousePosition);
            }
            else if (initialTouchPosition != Vector2.zero)
            {
                CheckSwipe(Input.mousePosition);
                
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                StartSwipe(touch.position);
            } 
            else if (initialTouchPosition != Vector2.zero)
            {
                CheckSwipe(touch.position);
            }
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            player.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.Jump();
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.Duck();
        }

    }

    void StartSwipe(Vector2 touch)
    {
        initialTouchPosition = new Vector2(touch.x / (float)Screen.width, touch.y / (float)Screen.height);
    }
    void CheckSwipe(Vector2 touch)
    {
        Vector2 diff = initialTouchPosition - new Vector2(touch.x / (float)Screen.width, touch.y / (float)Screen.height); ;
        if (diff.magnitude > 0.15f)
        {
            Vector2 normalized = diff.normalized;
            if (Mathf.Abs(normalized.x) > Mathf.Abs(normalized.y))
            {
                if (normalized.x > 0)
                {
                    player.MoveLeft();
                }
                else
                {
                    player.MoveRight();
                }
            }
            else
            {
                if (normalized.y > 0)
                {
                    player.Duck();
                }
                else
                {
                    player.Jump();
                }
            }
            initialTouchPosition = Vector2.zero;
        }
    }
   
}

