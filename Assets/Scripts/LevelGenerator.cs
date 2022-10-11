using UnityEngine;

using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject StartPlatform;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float PlatformsLength;
    public Transform FinishPlatform;
    public GameObject Food;
    public GameObject Block;
    public GameObject Wall;
    public Game Game;


    void Awake()
    {
        int LevelIndex = Game.LevelIndex;        
        Random random = new Random(LevelIndex);
        int platformsCount = RandomRange(random, MinPlatforms, MaxPlatforms + 1);
        

        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, PlatformPrefabs.Length);
            GameObject platformPrefab = i == 0 ? StartPlatform : PlatformPrefabs[prefabIndex];
            GameObject platforms = Instantiate(platformPrefab, transform);
            platforms.transform.localPosition = CalculatePlatformPosition(i);
            if (i != 0)
            {
                for (int j = 0; j < random.Next(0, 8); j++)
                {
                    int foodX = 0;
                    switch (random.Next(0, 15))
                    {
                        case 0:
                        case 5:
                        case 10:
                            foodX = -8;
                            break;
                        case 1:
                        case 6:
                        case 11:
                            foodX = -4;
                            break;
                        case 2:
                        case 7:
                        case 12:
                            foodX = 0;
                            break;
                        case 3:
                        case 8:
                        case 13:
                            foodX = 4;
                            break;
                        case 4:
                        case 9:
                        case 14:
                            foodX = 8;
                            break;
                    }

                    int foodZ = random.Next((int)platforms.transform.position.z + 1, (int)platforms.transform.position.z + 40);
                    Instantiate(Food, new Vector3(foodX, 1, foodZ), Quaternion.identity, transform);

                }
                for (int j = 0; j < random.Next(0, 3); j++)
                {
                    int blockX = 0;
                    switch (random.Next(0, 15))
                    {
                        case 0:
                        case 5:
                        case 10:
                            blockX = -8;
                            break;
                        case 1:
                        case 6:
                        case 11:
                            blockX = -4;
                            break;
                        case 2:
                        case 7:
                        case 12:
                            blockX = 0;
                            break;
                        case 3:
                        case 8:
                        case 13:
                            blockX = 4;
                            break;
                        case 4:
                        case 9:
                        case 14:
                            blockX = 8;
                            break;
                    }
                    int blockZ = random.Next((int)platforms.transform.position.z + 8, (int)platforms.transform.position.z + 40);
                    Instantiate(Block, new Vector3(blockX, 1, blockZ), Quaternion.identity, transform);
                }
                for (int j = 0; j < random.Next(0, 8); j++)
                {
                    int wallX = 0;
                    switch (random.Next(0, 12))
                    {
                        case 0:
                        case 4:
                        case 8:
                            wallX = -6;
                            break;
                        case 1:
                        case 5:
                        case 9:
                            wallX = -2;
                            break;
                        case 2:
                        case 6:
                        case 10:
                            wallX = 2;
                            break;
                        case 3:
                        case 7:
                        case 11:
                            wallX = 6;
                            break;                        
                    }
                    int wallZ = random.Next((int)platforms.transform.position.z + 8, (int)platforms.transform.position.z + 40);
                    Instantiate(Wall, new Vector3(wallX, 1, wallZ), Quaternion.identity, transform);
                }
            }
            FinishPlatform.localPosition = CalculatePlatformPosition(platformsCount);
            //Instantiate(FinishPlatform, CalculatePlatformPosition(platformsCount), Quaternion.identity, transform);
        }
    }
   

    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }
    private float RandomRange(Random random, float min, float maxExclusive)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, maxExclusive, t);
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0,0 , PlatformsLength * platformIndex-20);
    }
}
