using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

/// <summary>
/// 根据接触到的collider或者trigger，触发反馈效果，比如音效、屏幕抖动还有之后的显示文字都可以写在这
/// </summary>
public class TriggerFeedback : MonoBehaviour
{
    public MMFeedbacks onTriggerFeedback;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("接触了");
        onTriggerFeedback?.PlayFeedbacks();
    }
}
