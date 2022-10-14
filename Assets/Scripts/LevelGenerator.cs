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
                /*************************Была рандомная генерация блоков и стен*************************/

                //for (int j = 0; j < random.Next(0, 3); j++)
                //{
                //    int blockX = 0;
                //    switch (random.Next(0, 15))
                //    {
                //        case 0:
                //        case 5:
                //        case 10:
                //            blockX = -8;
                //            break;
                //        case 1:
                //        case 6:
                //        case 11:
                //            blockX = -4;
                //            break;
                //        case 2:
                //        case 7:
                //        case 12:
                //            blockX = 0;
                //            break;
                //        case 3:
                //        case 8:
                //        case 13:
                //            blockX = 4;
                //            break;
                //        case 4:
                //        case 9:
                //        case 14:
                //            blockX = 8;
                //            break;
                //    }
                //    int blockZ = random.Next((int)platforms.transform.position.z + 8, (int)platforms.transform.position.z + 40);
                //    Instantiate(Block, new Vector3(blockX, 1, blockZ), Quaternion.identity, transform);
                //}
                //for (int j = 0; j < random.Next(0, 8); j++)
                //{
                //    int wallX = 0;
                //    switch (random.Next(0, 12))
                //    {
                //        case 0:
                //        case 4:
                //        case 8:
                //            wallX = -6;
                //            break;
                //        case 1:
                //        case 5:
                //        case 9:
                //            wallX = -2;
                //            break;
                //        case 2:
                //        case 6:
                //        case 10:
                //            wallX = 2;
                //            break;
                //        case 3:
                //        case 7:
                //        case 11:
                //            wallX = 6;
                //            break;                        
                //    }
                //    int wallZ = random.Next((int)platforms.transform.position.z + 8, (int)platforms.transform.position.z + 40);
                //    Instantiate(Wall, new Vector3(wallX, 1, wallZ), Quaternion.identity, transform);
                //}

                /********************************************************************/
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
