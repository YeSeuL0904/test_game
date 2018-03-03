using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//17.11.18 움직이는 platform
public class MovingVertical : MonoBehaviour {

    public float movingRange = 2;
    public float initialPostiony;
    public float direction = 1;

    // Use this for initialization 

    void Start()
    {
        initialPostiony = this.transform.localPosition.y;
    }

    // Update is called once per frame 

    void Update()
    {
        if (initialPostiony - movingRange > this.transform.localPosition.y)
            direction = -1;
        else if (initialPostiony + movingRange < this.transform.localPosition.y)
            direction = 1;

        transform.Translate(Vector2.down * Time.deltaTime * direction);
    }
}


