using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBlockController : MonoBehaviour
{
    public int posX, posY;
    // Start is called before the first frame update
    void Start()
    {
        posX = (int)transform.localPosition.x;          //�ʱ� ��ġ ����
        posY = (int)transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
