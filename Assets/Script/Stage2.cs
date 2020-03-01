using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2: MonoBehaviour
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
    public void ChangeScene() {
        SceneManager.LoadScene("Stage_2");
    }
}
