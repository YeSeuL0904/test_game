using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //17.11.11 gamemanager call

    bool isCollected = false;
    void show()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;
        isCollected = false;
    }
    void Hide()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }
    void Collect()
    {
        isCollected = true;
        Hide();
        GameManager.instance.CollectedCoin();   //동전과 충돌, 함수실행
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Collect();
        }
    }
    Vector3 initalScale;
    float scaleParam = 1;
    float scaleParamMin = 0.8f;
    float scaleParamMax = 1.2f;
    bool dir = true;
    private void Start()
    {
        initalScale = this.transform.localScale;        
    }
    private void Update()
    {
        this.transform.localScale = initalScale * scaleParam;
        scaleParam = (dir) ? (scaleParam * 1.03f) : (scaleParam/1.03f);
        dir = (scaleParam > scaleParamMax || scaleParam < scaleParamMin) ? !dir : dir;

    }
}
