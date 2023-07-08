
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private bool isRotating = false;            //记录是否正在旋转的变量
    private Vector3 mouseStartPos;              //记录鼠标开始点击的位置
    [SerializeField] float rotationSpeed = 1f;  // 控制旋转的速度

    void Update()
    {
        // 鼠标左键按下
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            mouseStartPos = Input.mousePosition;
        }

        // 鼠标左键抬起
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        // 鼠标左键按下并且移动
        if (isRotating && Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - mouseStartPos.x;     //x轴变化距离

            // 根据鼠标滑动的距离进行旋转
            transform.Rotate(Vector3.forward, -deltaX * rotationSpeed);

            mouseStartPos = Input.mousePosition;
        }
    }
}