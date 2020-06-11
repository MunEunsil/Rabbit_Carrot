using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClearZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("BadCarrot");

        if (collision.gameObject.tag.CompareTo("player") == 0)
        {
            DataManager.Instance.stageClear = true;
            DataManager.Instance.playerDie = true;
            StageManager.Instance.StageNum++;       // 버튼에서 이동할 때 이거랑 이 아래 코드 
        }
        SceneManager.LoadScene(StageManager.Instance.GetCurrentStage()); 
    }
}
