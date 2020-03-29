using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DHeart : MonoBehaviour
{


    //충돌처
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("player") == 0)
        {
            //시간감소
            DataManager.Instance.playerTimeCurrent -= 10f;

            
            gameObject.SetActive(false);
            DataManager.Instance.EatBadHeart = true; 
    

        }
    }

    //깜빡깜빡 효과는 이런식으로? 만들것같은데 n초 동안을 만들어 보자 


}
