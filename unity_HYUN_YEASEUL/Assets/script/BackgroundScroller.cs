//2017.11.18 HYUN YEA SEUL 
//move background
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {



    public List<GameObject> background;
    public PlayerController Player;

    public float backgroundLength;
    private int NumOfBackgrounds;

    public static BackgroundScroller instance;
    private Vector3 [] startingPositionOfBackGround = new Vector3[2]; //Todo: dynamic allocation in Awake()


    private void Awake()
    {
        instance = this;
        for(int i=0;i< background.Count;i++)
            startingPositionOfBackGround[i] = background[i].transform.localPosition;
    }
    //Use this for intialization
    public void Start()
    {
        NumOfBackgrounds = background.Count;
        for (int i = 0; i < background.Count; i++)
            background[i].transform.localPosition = startingPositionOfBackGround[i];
        backgroundLength =
            background[1].transform.localPosition.x -
            background[0].transform.localPosition.x;

    }
    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x >
            background[NumOfBackgrounds - 1].transform.position.x)
        {
            // 첫번째 그림을 맨 뒤로 옮기기
            Vector3 NewPosition = background[NumOfBackgrounds - 1].transform.position;
            NewPosition.x += backgroundLength;
            //첫번째를 맨 마지막 인덱스로 변환
            background.Add((GameObject)Instantiate(background[0]));
            background[NumOfBackgrounds].transform.SetParent(this.transform, false);
            background[NumOfBackgrounds].transform.localPosition = NewPosition;
            Destroy(background[0].gameObject);
            background.Remove(background[0]);
        }
    }
}
