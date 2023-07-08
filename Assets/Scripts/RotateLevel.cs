using System;
using UnityEngine;

/// <summary>
/// 把脚本拖到要旋转的物体上
/// 或者你把private改成public Transform targetTran;  代表要旋转的物体，然后加一句代码    
/// </summary>
public class RotateLevel : MonoBehaviour
{
    [Header("关卡旋转速度(建议先给我赋值1)")]
    public float rotateSpeed = 1f;
    //要旋转的物体(关卡的父物体)
    private Transform targetTransform;
    private void Awake()
    {
        targetTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //鼠标操作的优先级在键盘操作之上
        
        //获取鼠标移动
        float mouseX = Input.GetAxis("Mouse X");
        if (Math.Abs(mouseX) > 0.1f)
        {
            if (Input.GetMouseButtonDown(1))
            {
                MouseRotation(mouseX);
            }
        }
        else
        {
            KeyboardRotation();
        }
    }
    
    /// <summary>
    /// 鼠标左右移动来旋转
    /// </summary>
    private void MouseRotation(float mouseX)
    {
        Vector3 mousePosition = Input.mousePosition;
        float x = mousePosition.x - Screen.width / 2;
        float y = mousePosition.y - Screen.height / 2;
        Vector2 dir = new Vector2(x, y).normalized;  //鼠标当前位置相当于屏幕中心的方向向量
        float angle = -Vector2.SignedAngle(dir, Vector3.up);
        targetTransform.rotation = Quaternion.Euler(0,0,angle);
        Debug.Log(angle);
        //绕z轴(左右)旋转
        //targetTransform.Rotate(Vector3.back*mouseX*rotateSpeed);


        
    }

    /// <summary>
    /// 键盘QE来旋转
    /// </summary>
    private void KeyboardRotation()
    {
        int rotateAmount = 0;
        bool keyQ = Input.GetKey(KeyCode.Q);
        bool keyE = Input.GetKey(KeyCode.E);
        if(keyQ)
            rotateAmount = -1;
        else if(keyE)
            rotateAmount = 1;
        else if (keyQ && keyE)
            rotateAmount = 0;
        
        targetTransform.Rotate(Vector3.back * rotateAmount * rotateSpeed*0.1f);
    }
}
