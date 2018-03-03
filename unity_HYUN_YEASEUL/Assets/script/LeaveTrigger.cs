using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : MonoBehaviour {
    
    //조각 연속 자동생성
	void OnTriggerEnter2D(Collider2D other)
    {   
        //Leave Trigger 객체와 연결할 if구문
        if (other.gameObject.tag == "Player")
        {
            LevelGenerator.instance.AddPiece();
            LevelGenerator.instance.RemoveOldestPiece();
        }
    }
}
