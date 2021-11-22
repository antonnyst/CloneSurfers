using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ObstacleBlock
{
    public bool[] entrances;
    public bool[] exits;
    public ObstaceDescription[] obstacles;
    public int length;
}
public struct ObstaceDescription
{
    public int lane;
    public int length;
    public int offset;
    public ObstacleType type;
}

public class ObstacleGenerator
{
    public static ObstacleBlock[] OBSTACLE_BLOCKS = new ObstacleBlock[]{
        new ObstacleBlock(){ // Empty block
            entrances=new bool[]{true, true, true},
            exits=new bool[]{true,true,true},
            obstacles= new ObstaceDescription[0],
            length = 10
        },
        new ObstacleBlock(){ // Funnel block middle
            entrances=new bool[]{true, true, true},
            exits=new bool[]{false,true,false},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                }
            },
            length = 14
        },
        new ObstacleBlock(){ // Funnel block left
            entrances=new bool[]{true, true, true},
            exits=new bool[]{true,false,false},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                }
            },
            length = 14
        },
        new ObstacleBlock(){ // Funnel block right
            entrances=new bool[]{true, true, true},
            exits=new bool[]{false,false,true},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                }
            },
            length = 14
        },
        new ObstacleBlock(){ // All bottom block
            entrances=new bool[]{true, true, true},
            exits=new bool[]{true, true, true},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 1,
                    offset = 4,
                    type = ObstacleType.Bottom
                },
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 1,
                    offset = 4,
                    type = ObstacleType.Bottom
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 1,
                    offset = 4,
                    type = ObstacleType.Bottom
                }
            },
            length = 8
        },
        new ObstacleBlock(){ // All top block
            entrances=new bool[]{true, true, true},
            exits=new bool[]{true, true, true},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 1,
                    offset = 4,
                    type = ObstacleType.Top
                },
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 1,
                    offset = 4,
                    type = ObstacleType.Top
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 1,
                    offset = 4,
                    type = ObstacleType.Top
                }
            },
            length = 8
        },
        new ObstacleBlock(){ // Hole in wall left
            entrances=new bool[]{true, true, true},
            exits=new bool[]{true, false, false},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 1,
                    offset = 7,
                    type = ObstacleType.Top
                },
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                }
            },
            length = 14
        },
        new ObstacleBlock(){ // Hole in wall middle
            entrances=new bool[]{true, true, true},
            exits=new bool[]{false, true, false},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 1,
                    offset = 7,
                    type = ObstacleType.Top
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                }
            },
            length = 14
        },
        new ObstacleBlock(){ // Hole in wall right
            entrances=new bool[]{true, true, true},
            exits=new bool[]{ false, false, true},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 1,
                    offset = 7,
                    type = ObstacleType.Top
                }
            },
            length = 14
        },
        new ObstacleBlock(){ // Hole2 in wall left
            entrances=new bool[]{true, true, true},
            exits=new bool[]{true, false, false},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 1,
                    offset = 7,
                    type = ObstacleType.Bottom
                },
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                }
            },
            length = 14
        },
        new ObstacleBlock(){ // Hole2 in wall middle
            entrances=new bool[]{true, true, true},
            exits=new bool[]{false, true, false},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 1,
                    offset = 7,
                    type = ObstacleType.Bottom
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                }
            },
            length = 14
        },
        new ObstacleBlock(){ // Hole2 in wall right
            entrances=new bool[]{true, true, true},
            exits=new bool[]{ false, false, true},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 7,
                    offset = 7,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 1,
                    offset = 7,
                    type = ObstacleType.Bottom
                }
            },
            length = 14
        },
        new ObstacleBlock(){ // Full wall left
            entrances=new bool[]{ true, false, false},
            exits=new bool[]{ true, false, false},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 12,
                    offset = 0,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 12,
                    offset = 0,
                    type = ObstacleType.Full
                }
            },
            length = 12
        },
        new ObstacleBlock(){ // Full wall middle
            entrances=new bool[]{ false, true, false},
            exits=new bool[]{ false, true, false},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 12,
                    offset = 0,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 12,
                    offset = 0,
                    type = ObstacleType.Full
                }
            },
            length = 12
        },
        new ObstacleBlock(){ // Full wall right
            entrances=new bool[]{ false, false, true},
            exits=new bool[]{ false, false, true},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 12,
                    offset = 0,
                    type = ObstacleType.Full
                },
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 12,
                    offset = 0,
                    type = ObstacleType.Full
                }
            },
            length = 12
        },
        new ObstacleBlock(){ // Middle wall
            entrances=new bool[]{ true, false, true},
            exits=new bool[]{ true, true, true},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 1,
                    length = 4,
                    offset = 0,
                    type = ObstacleType.Full
                }
            },
            length = 8
        },
        new ObstacleBlock(){ // Left wall
            entrances=new bool[]{ false, true, false},
            exits=new bool[]{ false, true, false},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 0,
                    length = 6,
                    offset = 0,
                    type = ObstacleType.Full
                }
            },
            length = 6
        },
        new ObstacleBlock(){ // Right wall
            entrances=new bool[]{ true, true, false},
            exits=new bool[]{ true, true, false},
            obstacles= new ObstaceDescription[] {
                new ObstaceDescription()
                {
                    lane = 2,
                    length = 6,
                    offset = 0,
                    type = ObstacleType.Full
                }
            },
            length = 6
        }
    };

    public ObstacleGenerator(GameObject model)
    {
        this.model = model;
        obstacles = new List<Obstacle>();
    }

    public List<Obstacle> obstacles;

    float currentLength;
    int currentBlock = -1;
    bool[] currentBlockExits;
    GameObject model;
    public void Run(float dt)
    {
        if (currentBlock == -1)
        {
            currentBlock = 0;
            CreateObstacleBlock(OBSTACLE_BLOCKS[0], Game.SPAWN_DISTANCE);
            currentLength = OBSTACLE_BLOCKS[0].length + Game.SPAWN_DISTANCE;
            currentBlockExits = OBSTACLE_BLOCKS[0].exits;
        }

        currentLength -= dt;
        if (currentLength <= Game.SPAWN_DISTANCE)
        {
            List<int> candidates = new List<int>();
            for (int i = 0; i < OBSTACLE_BLOCKS.Length; i++)
            {
                bool possible = false;
                bool match = true;
                for (int j = 0; j < 3; j++)
                {
                    if (OBSTACLE_BLOCKS[i].entrances[j] != currentBlockExits[j])
                    {
                        match = false;
                    }
                    if (OBSTACLE_BLOCKS[i].entrances[j] == true && currentBlockExits[j] == true)
                    {
                        possible = true;
                    }
                }
                if (possible)
                {
                    candidates.Add(i);
                    if (match)
                    {
                        candidates.Add(i);
                        candidates.Add(i);
                    }
                }
            }
            if (candidates.Count > 0)
            {
                int nextBlock = candidates[Random.Range(0, candidates.Count)];
                CreateObstacleBlock(OBSTACLE_BLOCKS[nextBlock], currentLength);
                currentLength += OBSTACLE_BLOCKS[nextBlock].length;
                currentBlockExits = OBSTACLE_BLOCKS[nextBlock].exits.Clone() as bool[];
                currentBlock = nextBlock;
            }
            else
            {
                string s = "";
                for (int i = 0; i < currentBlockExits.Length; i++)
                {
                    s += currentBlockExits[i];
                }
                Debug.LogError(s);
            }
        }
    }

    void CreateObstacleBlock(ObstacleBlock block, float distance)
    {
        foreach (ObstaceDescription description in block.obstacles)
        {
            CreateObstacle(description, distance);
        }
    }

    void CreateObstacle(ObstaceDescription description, float distance)
    {
        obstacles.Add(new Obstacle(
            description.lane,
            description.length,
            distance + description.offset,
            description.type,
            model));
    }
}
