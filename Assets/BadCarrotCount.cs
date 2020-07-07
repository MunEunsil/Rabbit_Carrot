using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadCarrotCount : MonoBehaviour
{
    public GameObject[] NumImg;
    public Sprite[] Number;
    private GameObject playerRabbit;
    public GameObject playerCarrot;
    private void Start()
    {
        playerRabbit = GameObject.FindGameObjectWithTag("player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("player") == 0)
        {
            DataManager.Instance.BadCarrotCount += 1;
            NumImg[1].GetComponent<Image>().sprite = Number[DataManager.Instance.BadCarrotCount%10];
            gameObject.SetActive(false);
           // Debug.Log("BadCarrot OnTrigger");
            if (DataManager.Instance.BadCarrotCount == 10)
            {
                int temp1 = DataManager.Instance.BadCarrotCount / 10;
                NumImg[0].GetComponent<Image>().sprite = Number[temp1];

                //rabbit setActive(f)
                playerRabbit.SetActive(false);
                //당근을 플레이어처럼 만들기
                playerCarrot.SetActive(true);
                playerCarrot.transform.position = playerRabbit.transform.position;
              


            }
        }

    }

}
