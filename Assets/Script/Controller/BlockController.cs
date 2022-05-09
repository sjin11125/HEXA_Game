using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    bool isMoving = false;
    public bool isArrive;

    int X, Y;           //���� ��ġ
    string Color;          // ���� ����
    GameObject Targetpos;       //��ǥ ��ġ



    public BlockManager blockManager;
    
    // Start is called before the first frame update
    void Start()
    {
        isArrive = false;
        Targetpos = new GameObject();
        X =(int)transform.localPosition.x;
        Debug.Log(X);
        CheckBlock();       //�ش� �� �Ʒ��� �˻��ؼ� ���� ���� ����
        //Targetpos = GameObject.Find("Block");
        //BlockMove(Targetpos.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
            
        
        
       
        if (isArrive == false)       // �������� �� �ϸ� ������ �� �ִ�
        {
            CheckBlock();               //�Ʒ� ���� ����ִ� �� ã��
            
            if (Input.GetKeyUp(KeyCode.RightArrow))//Ű����� �����̱�
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
            isArrive = true;                //�����ߴ�.
            CancelInvoke("BlockMove");
            BlockManager.BlockBoard[(int)transform.localPosition.y, X] = 1;
            BlockManager.isCheck = true;        //�����ϸ� ���Ŵ������� �˻�
        }

        if (isMoving == false)
        {
            isMoving = true;
            InvokeRepeating("BlockMove", 1f, 1f);
        }


    }
    public void CheckBlock()
    {
        for (int i = 0; i <7; i++)                  //�Ʒ��������� Ž��
        {
            if (BlockManager.BlockBoard[i, X]==0)       //����ִ�?
            {
                Debug.Log(X+"   "+i);
                Targetpos.transform.position = new Vector3(X,i);                    //��ǥ���� ����
                
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
