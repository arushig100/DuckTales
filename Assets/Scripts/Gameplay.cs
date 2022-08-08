using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gameplay : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject duck = GameManager.game.characters[GameManager.game.equipDuckInd];
        duck = Instantiate(duck) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
