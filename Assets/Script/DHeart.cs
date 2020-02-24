using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DHeart : MonoBehaviour
{
    //충돌처리 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("player") == 0)
        {
            //시간감소
            DataManager.Instance.playerTimeCurrent -= 5f;

           /* if (DataManager.Instance.playerTimeCurrent < DataManager.Instance.playlmeMin)
            {
                DataManager.Instance.playerTimeCurrent = DataManager.Instance.playlmeMin;
            }*/

            //먹고 바로 죽이려면 
            DataManager.Instance.playerDie = true;  //player랑 충돌하면 playerDie를 true
            print("player death");

            //자신을 화면에서 없애라
            gameObject.SetActive(false);
        }
    }
}