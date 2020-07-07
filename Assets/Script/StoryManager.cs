using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public GameObject[] NextStory;
    public GameObject[] NextTextBox;
    int num = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (num == 9) 
            {
                SceneManager.LoadScene("InGame");
            }
            else
            {
                NextStory[num].SetActive(false);
                num += 1;
            }

        }


    }

}
