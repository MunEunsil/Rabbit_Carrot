using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageStoryManager : MonoBehaviour
{
    public GameObject[] NextStory;
    public GameObject[] NextTextBox;
    int num = 0;
    public int imgNum;
    public int StageNum;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (num == imgNum)
            {
                //입력한 스테이지 넘버로 이동
                SceneManager.LoadScene(StageManager.sceneNameArray[StageNum]);
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
