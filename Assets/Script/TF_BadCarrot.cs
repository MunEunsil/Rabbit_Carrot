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

            if (collision.gameObject.tag.CompareTo("player") == 0)
            {

                TFBadCarrot.gameObject.SetActive(false);     //TF BadCarrot 끄고
                BadCarrot.gameObject.SetActive(true);        //BadCarrot켜기

            }
        }
    }
}
