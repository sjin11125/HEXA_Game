using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
   public static int[,] BlockBoard;
    public static bool isCheck;      //모든 배열 검사하는 변수
    // Start is called before the first frame update
    void Start()
    {
        BlockBoard = new int[8,10];
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                BlockBoard[i, j] =0;                //배경 블럭들 초기화
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))              //디버깅용
        {
            for (int i = 0; i < 7; i++)
            {
                Debug.Log(BlockBoard[i,0]+" "+ BlockBoard[i, 1] + " " + BlockBoard[i, 2] +" " + BlockBoard[i, 3]
                    + " " + BlockBoard[i, 4] + " " + BlockBoard[i, 5] + " " + BlockBoard[i, 6] );
            }
        }
        if (isCheck == true)            //배열 다 돌려서 검사하는 함수 호출
        {

        }
    }
}
