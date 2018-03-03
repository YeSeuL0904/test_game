using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    // 싱글턴 생성
    public static LevelGenerator instance;
    //미리 생성해 놓는 조각. 게임동안 안바뀜
    public List<LevelPieces> levelPrefabs = new List<LevelPieces>();
    //생성 시작 위치
    public Transform levelStartPoint;
    //생성된 조각들을 게임에 넣고 빼고. 게임동안 바뀜
    public List<LevelPieces> pieces = new List<LevelPieces>();

    private void Awake()
    {
        instance = this;            //싱글턴 생성
    }

    public void Start()
    {
        RemoveAllPieces();
        GenerateInitialPieces();        //초기 조각들 생성
    }
    public void GenerateInitialPieces()
    {
        for (int i = 0; i < 2; i++)
            AddPiece();
    }

    public void AddPiece()
    {
        // random number 생성
        int randomIndex = 0;
        if (pieces.Count == 0)
            randomIndex = 0;
        else
            randomIndex = Random.Range(0, levelPrefabs.Count);

        //levelPrefab을 Instantiate 하여 piece variable에 저장
        LevelPieces piece = (LevelPieces)Instantiate(levelPrefabs[randomIndex]);
        //생성된 조각을 현재 객체에 종속
        piece.transform.SetParent(this.transform, false);

        Vector3 spawnPosition = Vector3.zero;

        //position
       if(pieces.Count == 0)
        {
            //first piece
            spawnPosition = levelStartPoint.position;
        }
       else
        {
            //마지막 조각의 종료지점이 새로운 조각의 생성점
            spawnPosition = pieces[pieces.Count - 1].exitpoint.position + Vector3.up * Random.Range(-2f, 2f);
            if ((spawnPosition.y < (levelStartPoint.position.y - 2)) || spawnPosition.y > (levelStartPoint.position.y + 2))
                spawnPosition.y = levelStartPoint.position.y;
        }

        piece.transform.position = spawnPosition;
        pieces.Add(piece);      //생성

    }

    public void RemoveOldestPiece()
    {
        LevelPieces oldestPiece = pieces[0];

        pieces.Remove(oldestPiece);
        Destroy(oldestPiece.gameObject);
    }

    public void RemoveAllPieces()
    {
        while (pieces.Count > 0)
            RemoveOldestPiece();
    }

}
