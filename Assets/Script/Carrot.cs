using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
   // public GameObject coinAudio;
    //충돌처리 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag.CompareTo("player") == 0 || collision.gameObject.tag.CompareTo("BadCarrotPlayer") == 0)
        {
            DataManager.Instance.score += 1;
            //coinAudio.GetComponent<AudioSource>().Play();
            SoundManager.Instance.PlaySound("EatCarrot");
            //자신을 화면에서 없애라
            gameObject.SetActive(false);
        }
    }

}
