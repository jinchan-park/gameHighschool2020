using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpwaner : MonoBehaviour
{
    public GameObject RedBlock;
    public GameObject BlueBlock;

    public float Timer = 5f;
    public float timer = 5f;

    public float posX = 10f;
    public float posZ = 10f;



    // Update is called once per frame
    void Update()
    {
        //Timer -= Time.deltaTime;

        //if(Timer <= 0)
        //{
        //    Timer = timer;
        //    var Color = Random.Range(1, 3);// 랜덤 범위

        //    var BlockX = Random.Range(-posX, posX);
        //    var BlockY = Random.Range(-posZ, posZ);

        //    if (Color == 1)
        //    {
        //        GameObject BLOCK = GameObject.Instantiate(RedBlock);
        //        BLOCK.transform.position = new Vector3(BlockX, 12, BlockY);
        //    }
        //    else
        //    {
        //        GameObject BLOCK = GameObject.Instantiate(BlueBlock);
        //        BLOCK.transform.position = new Vector3(BlockX, 12, BlockY);
        //    }

        //}
            ,  
    }
}
