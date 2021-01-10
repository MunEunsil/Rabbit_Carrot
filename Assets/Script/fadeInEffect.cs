using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeInEffect : MonoBehaviour
{
    GameObject SplashObj; //panel오브젝트
    Image image; //panel 이미지

    private bool checkBool = false;

    private void Awake()
    {
        SplashObj = this.gameObject;
        image = SplashObj.GetComponent<Image>();
    }

    private void Update()
    {
        StartCoroutine("MainSplash");//코루틴 투명도 조절
        if (checkBool)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator MainSplash()
    {
        Color color = image.color;

        for(int i = 100; i>=0; i--)
        {
            color.a -= Time.deltaTime * 0.01f;
            image.color = color;

            if(image.color.a <= 0)
            {
                checkBool = true;
            }
        }
        yield return null; // 코루틴 종료
    }
}

