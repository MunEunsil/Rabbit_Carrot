using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripple_Carrot : MonoBehaviour
{
    //충돌처리 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("player") == 0)
        {
            DataManager.Instance.score += 5; 
            //훔...carrot / tripplecarrot하지말고 하나로 만드는게 좋나? 
            //자신을 화면에서 없애라
            gameObject.SetActive(false);
        }
    }
}
