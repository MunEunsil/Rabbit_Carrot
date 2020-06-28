using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_Camera_Move : MonoBehaviour
{
    private Vector3 pastTouch;
    private Vector3 destinationCamera;
    private bool touchStartFlag;
    private readonly float MAX_HEIGHT = 58;
    private readonly float MIN_HEIGHT = 0f;
    private readonly float CAMERA_SPEED = 0.1f;
    private readonly float CAMERA_Z = -10f;
    private readonly float CAMERA_X =  0f;
    public Camera mainCamera;
    public GameObject debugText;
    //터치 위치를 배열로 생성
    //Vector2?[] touchPrevPos = {null,null }; //?
    //Vector2 touchPrevVector;
    //float touchPrevDist;


    //private void Start()
    //{
    //    Screen.orientation = ScreenOrientation.Portrait;
    //}
    //private void LateUpdate()
    //{
    //    //터치가 없다 null로 초기화 
    //    if (Input.touchCount == 0)
    //    {
    //        touchPrevPos[0] = null;
    //        touchPrevPos[1] = null;

    //    }
    //    else
    //    {
    //        Debug.Log(Input.GetTouch(0));
    //        Vector2 touchNwePos = Input.GetTouch(0).position;
    //        transform.position += transform.TransformDirection
    //            ((Vector3)((touchPrevPos[0] -touchNwePos)*Camera.main.orthographicSize/Camera.main.pixelHeight*2f));

    //        //MoveLimit();

    //        touchPrevPos[0] = touchNwePos;
    //    }
    //}

    //void MoveLimit()
    //{
    //    //Vector3 temp;
    //  //  temp.x = Mathf.Clamp()
    //}
    private void Start()
    {
        pastTouch = Vector3.zero;
        destinationCamera = mainCamera.transform.position;
        touchStartFlag = false;
    }

    private void Update()
    {
        DetectTouch();
        MoveCamera();
    }

    // 터치를 감지하여 명령을 수행합니다.
    private void DetectTouch()
    {
        //TestText($"touch count = {Input.touchCount}");
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    switch (touch.phase)
        //    {
        //        case TouchPhase.Began:
        //            pastTouch = touch.position;
        //            touchStartFlag = true;
        //            break;
        //        case TouchPhase.Moved:
        //            if (touch.position.y - pastTouch.y > 0)
        //            {
        //                // 화면이 내려감
        //                AddDestinationCamera(-1);
        //            }
        //            else if (touch.position.y - pastTouch.y < 0)
        //            {
        //                // 화면이 올라감
        //                AddDestinationCamera(1);
        //            }
        //            break;
        //        case TouchPhase.Ended:
        //            touchStartFlag = false;
        //            break;
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            pastTouch = Input.mousePosition;
            touchStartFlag = true;
        }
        if (Input.GetMouseButton(0))
        {
            if (touchStartFlag)
            {
                if (Input.mousePosition.y - pastTouch.y > 0)
                {
                    // 화면이 내려감
                    AddDestinationCamera(-1);
                }
                else if (Input.mousePosition.y - pastTouch.y < 0)
                {
                    // 화면이 올라감
                    AddDestinationCamera(1);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            touchStartFlag = false;
        }

    }

    // 카메라의 목적 위치에 value를 더합니다.
    private void AddDestinationCamera(int value)
    {
        // 카메라의 움직임 범위 내에 있다면 변경합니다.
        if (destinationCamera.y <= MAX_HEIGHT && destinationCamera.y >= MIN_HEIGHT)
        {
            destinationCamera += new Vector3(0, value, 0);
        }

        // 카메라 이동 범위를 벗어나면 조절한다.
        if (destinationCamera.y < MIN_HEIGHT)
        {
            destinationCamera = new Vector3(CAMERA_X, MIN_HEIGHT, CAMERA_Z);
        }
        else if (destinationCamera.y > MAX_HEIGHT)
        {
            destinationCamera = new Vector3(CAMERA_X, MAX_HEIGHT, CAMERA_Z);
        }
    }

    // 카메라의 움직임을 조절합니다.
    private void MoveCamera()
    {
        // 지금 카메라의 y좌표 값과 목적지의 y좌표의 차가 EPS보다 클 때 이동시킨다.
        if (Mathf.Abs(destinationCamera.y - mainCamera.transform.position.y) > Mathf.Epsilon)
        {
            mainCamera.transform.position = Vector3.Slerp(mainCamera.transform.position, destinationCamera, CAMERA_SPEED);
        }
    }

    private void TestText(string text)
    {
        debugText.GetComponent<Text>().text = text;
    }
}
