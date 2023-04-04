using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class virus3 : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform[] spawnPoints;//总数
    public int SpawnCount;

    void Start()
    {
        
        int maxAttempts = 5; // 每次便利次数

        for (int i = 0; i < SpawnCount; i++)
        {
            int attemptCount = 0;
            bool foundSpawnPoint = false;

            while (!foundSpawnPoint && attemptCount < maxAttempts)
            {
                int randomIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[randomIndex];

                if (spawnPoint.childCount == 0) // 判断
                {
                    GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation, spawnPoint);
                    foundSpawnPoint = true;
                }

                attemptCount++;
            }

            if (!foundSpawnPoint) // 没找到子物体
            {
                Debug.Log("无法为第 " + i + " 个物体找到合适的生成点。");
            }
        }
    }





void Update()
    {
        
        //Generate();
        
    }//可以不用

    /*private void Generate()//复制函数
    {
        if (Timeamount.GetComponent<Image>().fillAmount == 20)
        {
            foreach (GameObject pointPosition in PointPositions)
            {
                perfebGerenation = Instantiate(perfeb, pointPosition.transform.position, perfeb.transform.rotation);
            }

        }
    }*/

    
}
