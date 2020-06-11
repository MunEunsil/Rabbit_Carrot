using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ChangeScene();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeScene()
    {
        StageManager.Instance.StageNum = 3;
        SceneManager.LoadScene("Stage_3.1");
    }
}
