using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TF_BadCarrot : MonoBehaviour
{
    public GameObject BadCarrot;
    public GameObject TFBadCarrot;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (DataManager.Instance.playerDie == false)
        {

            if (collision.gameObject.tag.CompareTo("player") == 0 || collision.gameObject.tag.CompareTo("BadCarrotPlayer") == 0)
            {

                TFBadCarrot.gameObject.SetActive(false);     //TF BadCarrot 끄고 
                //본인스스로인데 나 왜 이렇게 스크립트 만들었..?
                BadCarrot.gameObject.SetActive(true);        //BadCarrot켜기

            }
        }
    }
}
