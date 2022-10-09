using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject StartPlatform;
    public int MinPlatforms;
    public int MaxPlatforms;
    public float PlatformsLength;
    public GameObject FinishPlatform;    
    //public Game Game;

    //private float _extraCylinderScale = 1f;

    void Awake()
    {
        // int LevelIndex = Game.LevelIndex;
        Random random = new Random();
        //Random random = new Random(LevelIndex);
        // int platformsCount = RandomRange(random, MinPlatforms, MaxPlatforms + 1);
        int platformsCount=random.Next(MinPlatforms,MaxPlatforms);

        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, PlatformPrefabs.Length);
            GameObject platformPrefab = i == 0 ? StartPlatform : PlatformPrefabs[prefabIndex];
            GameObject platforms = Instantiate(platformPrefab, transform);
            platforms.transform.localPosition = CalculatePlatformPosition(i);
            //if (i > 0)
            //    platforms.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);
        }
        Instantiate(FinishPlatform, CalculatePlatformPosition(platformsCount), Quaternion.identity ,transform);
        
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
