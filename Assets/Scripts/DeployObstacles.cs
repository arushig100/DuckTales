using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployObstacles : MonoBehaviour
{
    public GameObject icebergPrefab;
    public GameObject barPrefab;
    public GameObject floatPrefab;
    public float respawnTimeRangeStart = 3.0f;
    public float respawnTimeRangeEnd = 5.0f;
    private float initialPosScale = 2f;
    private Vector2 screenBounds;

    private enum obstacleType {
        ICEBERG = 1,
        BAR = 2,
        FLOAT = 3
    }


    // Start is called before the first frame update
    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,Camera.main.transform.position.z ));
        StartCoroutine(obstacleWave());
    }

    private void spawnObstacle(){
        int obstacleNum = Random.Range(1,4);
        GameObject obst;
        if((obstacleType)obstacleNum == obstacleType.ICEBERG) obst = Instantiate(icebergPrefab) as GameObject;
        else if((obstacleType)obstacleNum == obstacleType.BAR) obst = Instantiate(barPrefab) as GameObject;
        else obst = Instantiate(floatPrefab) as GameObject;
        obst.transform.position = new Vector2(screenBounds.x*initialPosScale, obst.transform.position.y);
    }

    IEnumerator obstacleWave(){
        while(true){
            yield return new WaitForSeconds(Random.Range(respawnTimeRangeStart,respawnTimeRangeEnd));
            spawnObstacle();
            print("SPAWNED");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
