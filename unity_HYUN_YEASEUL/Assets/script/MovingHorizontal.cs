using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//17.11.18 움직이는 platform
public class MovingHorizontal : MonoBehaviour {

    public float movingRange = 2;
    public float initialPostionx;
    public float direction = 1;

    // Use this for initialization

    void Start ()
    {
        initialPostionx = this.transform.localPosition.x;
    }

    // Update is called once per frame 

    void Update()
    {
        if (initialPostionx - movingRange > this.transform.localPosition.x)
            direction = 1;
        else if (initialPostionx + movingRange < this.transform.localPosition.x)
            direction = -1;

        transform.Translate(Vector2.right * Time.deltaTime * direction);
    }
}
