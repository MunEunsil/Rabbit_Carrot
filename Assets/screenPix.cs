using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenPix : MonoBehaviour
{
   private void setupCamera()
    {
        //가로화면 비율 
        float targetWidthAspect = 16.0f;
        //세로화면 비율 
        float targetHeightAspect = 9.0f;

        Camera mainCamera = Camera.main;

        mainCamera.aspect = targetWidthAspect / targetHeightAspect;

        float widthRatio = (float)Screen.width / targetWidthAspect;
        float heightRatio = (float)Screen.height / targetHeightAspect;

        //16:9보다 가로가 짧다면 4:3

        //if (heightRatio > widthRatio)
       //     widthRatio = 0.0f;
       // else
       //     heightRatio = 0.0f;

      //  mainCamera.rect = new Rect(
       //     mainCamera.rect.x+Mathf.Abs(widthadd),
      //      );

           
    }
}
