using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCoins : MonoBehaviour
{
    public GameObject coinPrefab;
    public float respawnTimeRangeStart = 5.0f;
    public float respawnTimeRangeEnd = 7.0f;
    private float initialPosScale = 2f;
    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,Camera.main.transform.position.z ));
        StartCoroutine(coinWave());
    }

    private void spawnCoin(){
        GameObject coin = Instantiate(coinPrefab) as GameObject;
        coin.transform.position = new Vector2(screenBounds.x*initialPosScale, Random.Range(-screenBounds.y, coin.transform.position.y));
    }

    IEnumerator coinWave(){
        while(true){
            yield return new WaitForSeconds(Random.Range(respawnTimeRangeStart,respawnTimeRangeEnd));
            spawnCoin();
            print("SPAWN COIN");
        }
    }
}
