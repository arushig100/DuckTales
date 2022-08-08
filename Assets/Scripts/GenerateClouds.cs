using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateClouds : MonoBehaviour
{
    public GameObject cloud1Prefab;
    public GameObject cloud2Prefab;
    public GameObject cloud3Prefab;
    public float respawnTimeRangeStart = 5.0f;
    public float respawnTimeRangeEnd = 7.0f;
    private float initialPosScale = 2f;
    private Vector2 screenBounds;

    private enum obstacleType {
        CLOUD_1 = 1,
        CLOUD_2 = 2,
        CLOUD_3 = 3
    }


    // Start is called before the first frame update
    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,Camera.main.transform.position.z ));
        StartCoroutine(cloudWave());
    }

    private void spawnCloud(){
        int obstacleNum = Random.Range(1,4);
        GameObject obst;
        if((obstacleType)obstacleNum == obstacleType.CLOUD_1) obst = Instantiate(cloud1Prefab) as GameObject;
        else if((obstacleType)obstacleNum == obstacleType.CLOUD_2) obst = Instantiate(cloud2Prefab) as GameObject;
        else obst = Instantiate(cloud3Prefab) as GameObject;
        obst.transform.position = new Vector2(screenBounds.x*initialPosScale, Random.Range(obst.transform.position.y,screenBounds.y));
    }

    IEnumerator cloudWave(){
        while(true){
            yield return new WaitForSeconds(Random.Range(respawnTimeRangeStart,respawnTimeRangeEnd));
            spawnCloud();
            print("SPAWN CLOUD");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
