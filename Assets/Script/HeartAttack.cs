using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAttack : MonoBehaviour
{
    private int HeartNum;
    
    public GameObject[] NumImg;
    public Sprite[] Number;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Heart");

        if (collision.gameObject.tag.CompareTo("player") == 0)
        {
            HeartNum += 1;
            if(HeartNum == 7)
            {
                //심장박동 소리 켜기
            }
            else if(HeartNum ==10){ //10개 이상 먹으면 gameOver
                DataManager.Instance.playerDie = true;
            }


        }

    }

}
