using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Duck : MonoBehaviour
{
    private Rigidbody2D duckBody;
    private SpriteRenderer sr;
    public TextMeshProUGUI scoreText;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    // Movement constants
    public float moveForce;
    public float jumpForce = 10.5f;
    public float diveForce = -10.5f;
    public float normalGravityScale = 0f;
    public float jumpGravityScale = 1f;
    public float diveGravityScale = -1f;
    private  Vector2 acceleration = new Vector2(0f, -9.81f);
    private float movementX = 0;
    private float movementY = 0;
    private float initY;

    // Water & Air constants
    private bool belowWater = false;
    private bool aboveWater = false;
    private string WATER_TAG = "Water";
    private string AIR_TAG = "Air";
    private string WALL_TAG = "Wall";
    private string COIN_TAG = "Coin";

    // Score constants
    public int numCoins = 0;

    // Called before anything occurs
    private void Awake() {
        duckBody = GetComponent<Rigidbody2D>();
        initY = duckBody.position.y;
        duckBody.gravityScale = normalGravityScale; 
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scoreText = GameObject.Find("Score_Text").GetComponentInChildren<TextMeshProUGUI>();

    }


    // Start is called before the first frame update
    void Start()
    {
        moveForce = GameManager.game.duckSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveHorizontal();
        AnimatePlayer();
        
    }

    // Function called every fixed frame rate (not called every frame); generally use it to perform physics operations (including rigidbody)
    private void FixedUpdate() {
        PlayerUpdateForces();
        PlayerMoveVertical(); // Jumps/dives
    }

    void PlayerMoveHorizontal(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f)*Time.deltaTime * moveForce;
    }

    void PlayerMoveVertical(){
        movementY = Input.GetAxisRaw("Vertical");
        bool atWater = !aboveWater && !belowWater;
        if(movementY!=0 && atWater){ 
            SoundManager.inst.PlayJump();
            if(movementY == 1){
                duckBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                duckBody.gravityScale = jumpGravityScale;
                aboveWater = true;
                print("UP");
            }
            else{
                duckBody.AddForce(new Vector2(0f, diveForce), ForceMode2D.Impulse);
                duckBody.gravityScale = diveGravityScale;
                belowWater = true;
                print("DOWN");
            }
        }
    }


    void PlayerUpdateForces(){
         if(duckBody.position.y < initY-0.01){
             belowWater = true;
             aboveWater = false;
             duckBody.gravityScale = diveGravityScale;
         }
         else if(duckBody.position.y > initY + 0.01){
             aboveWater = true;
             belowWater = false;
             duckBody.gravityScale = jumpGravityScale;
         }
         else {
             belowWater = false;
             aboveWater = false;
             ResetYVel();
         }


    }

    void AnimatePlayer(){
        // Duck moving right
        if(movementX > 0){
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        // Duck moving left
        else if (movementX < 0){
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else{
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
    }

    private void ResetYVel(){
        duckBody.gravityScale = 0;
        duckBody.velocity = new Vector2(0f, 0f);
    }

    private void AddScore(){
        numCoins++;
        GameManager.game.totalMoney++;
        scoreText.SetText("Coins: " + numCoins.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collider){
        // If duck colliding with water for the first time since jumping
        if(collider.gameObject.CompareTag(WATER_TAG) && aboveWater){
            ResetYVel();
            aboveWater = false;
        }
        // If duck colliding with air for the first time since diving
        if(collider.gameObject.CompareTag(AIR_TAG) &&  belowWater){
            ResetYVel();
            belowWater = false;
        }
        // If duck colliding with a coin
        if(collider.gameObject.CompareTag(COIN_TAG)){
            SoundManager.inst.PlayCoin();
            Destroy(collider.gameObject);
            AddScore();
        }
        
        // If duck colliding with left wall, go to main menu
        if(collider.gameObject.CompareTag(WALL_TAG)){
            SoundManager.inst.StartAsianMusic();
            SceneManager.LoadScene("StartScreen");
        }
    }






} 
