using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    private float len, startPos;
    public GameObject cam;
    public float scrollingEffect;
    public bool autoScroll = true;

    void Start()
    {
        startPos = transform.position.x;
        len = GetComponent<SpriteRenderer>().bounds.size.x;
        print(startPos);
        print(len);


    }

    void Update()
    {
        float temp = transform.position.x * (1 - scrollingEffect);
        float distance = (transform.position.x * scrollingEffect);
        float desiredXPos = startPos + distance;
        
        if(autoScroll)
        {
            // Push background to the left
            desiredXPos = transform.position.x - scrollingEffect;
        }
        print(temp);
        transform.position = new Vector2(desiredXPos, transform.position.y);


        if (temp > startPos + len)
        {
            startPos += len;
        }
        else if(temp > startPos - len) 
        {
            startPos -= len;
        }
    }
}

