using UnityEngine;

using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject StartPlatform;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float PlatformLength;
    public Transform FinishPlatform;
    public GameObject[] Food;
    public int MaxFood=5;
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
                int maxFood = random.Next(0, MaxFood);                
                int[] previousPositionX=new int[maxFood];
                int[] previousPositionZ=new int[maxFood];
                for (int j = 0; j <maxFood ; j++)
                {
                    int foodX = 0;
                    int pos =random.Next(0, 100)%5;
                    switch (pos)
                    {
                        case 0:                        
                            foodX = -8;
                            break;
                        case 1:                        
                            foodX = -4;
                            break;
                        case 2:
                            foodX = 0;
                            break;
                        case 3:
                            foodX = 4;
                            break;
                        case 4:
                            foodX = 8;
                            break;
                    }                   

                    int foodZ = random.Next((int)platforms.transform.position.z, (int)platforms.transform.position.z +(int)PlatformLength-15);
                    for (int k = 0; k < j; k++)
                    {
                        if (foodX == previousPositionX[k] && Mathf.Abs(foodZ - previousPositionZ[k]) <=5)
                        {
                            foodZ  += 11 * (int)Mathf.Sign(foodZ - previousPositionZ[k]);
                        }
                    }
                    int foodPrefab = random.Next(0, Food.Length);

                    if(foodPrefab == 0) Instantiate(Food[foodPrefab], new Vector3(foodX, 0, foodZ), Quaternion.Euler(0,90,0), transform);
                    else     Instantiate(Food[foodPrefab], new Vector3(foodX, 0, foodZ), Quaternion.identity, transform);
                    previousPositionZ[j]=foodZ;
                    previousPositionX[j] = foodX;
                }               
            }
        }
        FinishPlatform.localPosition = CalculatePlatformPosition(platformsCount);
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
        return new Vector3(0,0 , PlatformLength * platformIndex-20);
    }
}
