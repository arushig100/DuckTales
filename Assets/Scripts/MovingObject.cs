using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{

    public float speed = 5f;
    private float screenBufferScale = -2f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start() {
        speed = GameManager.game.obstacleSpeed;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0f);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,Camera.main.transform.position.z ));
    
    }

    // Update is called once per frame
    void Update() {
        if(transform.position.x < screenBounds.x*screenBufferScale){
            Destroy(gameObject);
        }
    }
}
