using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartAttack : MonoBehaviour
{
    public GameObject[] NumImg;
    public Sprite[] Number;

    private void Update()
    {
        if (DataManager.Instance.HeartNum<10) { 
        NumImg[0].GetComponent<Image>().sprite = Number[DataManager.Instance.HeartNum];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!DataManager.Instance.playerDie)
        {
            if (collision.gameObject.tag.CompareTo("player") == 0)
            {
                //시간추가 
                DataManager.Instance.playerTimeCurrent += 3f;
                Debug.Log("플레이어와 하트 접촉");
                DataManager.Instance.HeartNum++;
                Debug.Log(DataManager.Instance.HeartNum);
        
                if (DataManager.Instance.HeartNum == 7)
                {
                    //심장박동 소리 켜기
                }
                else if (DataManager.Instance.HeartNum == 10)
                { //10개 이상 먹으면 gameOver
                    DataManager.Instance.playerDie = true;
                }

                //닿으면 이미지 끄기 
                gameObject.SetActive(false);
            }

        }

        }

    }
