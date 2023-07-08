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
    [Header("反馈事件")]
    public MMFeedbacks onTriggerFeedback;

    [Header("按顺序播放的音效列表")] 
    public AudioClip[] audioClips;

    private int currentAudioIndex = 0;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (currentAudioIndex > 0)
        {
            //按顺序更改音效
            MMFeedbackSound feedbackSound = onTriggerFeedback.Feedbacks[0] as MMFeedbackSound;
            feedbackSound.Sfx = audioClips[(currentAudioIndex++)%audioClips.Length];
        }

        //播放反馈
        onTriggerFeedback?.PlayFeedbacks();
    }
}
