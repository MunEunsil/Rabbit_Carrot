using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour      //일시정지 코드 
{
    private bool IsPause;
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    //일시정지 활성화
    public void pauseButtonDown()   
    {
        //일시정지 버튼을 누르면 계속하기, 나가기 버튼이 생겨야 한다.
        Time.timeScale = 0;
        IsPause = true;
        pausePanel.SetActive(true);

        return;
    }
    //일시정지 비활성화
    public void ContinueButtonDown()
    {
        Time.timeScale = 1;
        IsPause = false;
        pausePanel.SetActive(false);
        return;
    }
}
