using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{

    public static StartMusic musicInst;

    private void Awake() {
        if(musicInst != null && musicInst != this) {
            Destroy(this.gameObject);
            return;
        }

        musicInst = this;
        DontDestroyOnLoad(this);
    }
}
