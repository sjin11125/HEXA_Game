using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    bool isMoving = false;
    public bool isArrive;

    int X, Y;           //현재 위치
    string Color;          // 블럭의 색깔
    GameObject Targetpos;       //목표 위치



    public BlockManager blockManager;
    
    // Start is called before the first frame update
    void Start()
    {
        isArrive = false;
        Targetpos = new GameObject();
        X =(int)transform.localPosition.x;
        Debug.Log(X);
        CheckBlock();       //해당 줄 아래를 검사해서 도착 지점 설정
        //Targetpos = GameObject.Find("Block");
        //BlockMove(Targetpos.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
            
        
        
       
        if (isArrive == false)       // 도착하지 못 하면 움직일 수 있다
        {
            CheckBlock();               //아래 열에 비어있는 곳 찾기
            
            if (Input.GetKeyUp(KeyCode.RightArrow))//키보드로 움직이기
            {
                transform.position += new Vector3(0.5f, 0);
                X += 1;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-0.5f, 0);
                X -= 1;
            }
        }

        if (transform.localPosition == Targetpos.transform.position)
        {
            isArrive = true;                //도착했다.
            CancelInvoke("BlockMove");
            BlockManager.BlockBoard[(int)transform.localPosition.y, X] = 1;
            BlockManager.isCheck = true;        //도착하면 블럭매니저에서 검사
        }

        if (isMoving == false)
        {
            isMoving = true;
            InvokeRepeating("BlockMove", 1f, 1f);
        }


    }
    public void CheckBlock()
    {
        for (int i = 0; i <7; i++)                  //아래에서부터 탐색
        {
            if (BlockManager.BlockBoard[i, X]==0)       //비어있니?
            {
                Debug.Log(X+"   "+i);
                Targetpos.transform.position = new Vector3(X,i);                    //목표지점 설정
                
                return;
            }
            
        }
    }

    void BlockMove()
    {
        transform.position += new Vector3(0,-0.5f);
        Debug.Log("transform:  " + transform.position);
        Debug.Log("Targetpos.transform:   " + Targetpos.transform.position);
    } 
       
}
