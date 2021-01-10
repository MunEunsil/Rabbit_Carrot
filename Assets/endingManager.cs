using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingManager : MonoBehaviour
{
    public GameObject[] NextStory;
    public GameObject[] NextTextBox;
    int num = 0;
    public int imgNum;
    public int StageNum;
    public GameObject[] bgi;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (num == imgNum)
            {
                //입력한 스테이지 넘버로 이동
                SceneManager.LoadScene("EndingCradit");
            }
            else if (num==5)
            {
                bgi[1].SetActive(false);
                bgi[0].SetActive(true);
                NextStory[num].SetActive(false);
                num += 1;
                NextStory[num].SetActive(true);
            }
            else if (num == 9)
            {
                bgi[0].SetActive(false);
                NextStory[num].SetActive(false);
                num += 1;
                NextStory[num].SetActive(true);
            }
            else
            {
                NextStory[num].SetActive(false);
                num += 1;
                NextStory[num].SetActive(true);
            }

        }


    }
}
