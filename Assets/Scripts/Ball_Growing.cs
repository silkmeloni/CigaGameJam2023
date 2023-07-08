using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Growing : MonoBehaviour
{
    //public float growDuration = 2f;       // 变大的持续时间
    //public float maxScale = 2f;           // 球体的最大缩放比例
    //private Vector3 initialScale;         // 初始缩放比例
    //private float currentScale;           // 当前缩放比例
    //private float timer;                  // 计时器
    //private bool isGrowing;               // 是否正在变大
    //private Coroutine growCoroutine;      // 变大的协程

    //[SerializeField] GameObject Level_UP_Button;

    //void Start()
    //{
    //    initialScale = transform.localScale;
    //    currentScale = transform.localScale.x;
    //}

    ////Level_UP按钮调用的函数
    //public void LevelUP()
    //{
    //    if (!isGrowing)
    //    {
    //        if (growCoroutine != null)
    //            StopCoroutine(growCoroutine);

    //        growCoroutine = StartCoroutine(Grow());
    //    }
    //    Level_UP_Button.SetActive(false);
    //}

    //IEnumerator Grow()      //携程控制球体按时间比例变大
    //{
    //    isGrowing = true;
    //    timer = 0f;

    //    while (timer < growDuration)
    //    {
    //        timer += Time.deltaTime;
    //        float t = timer / growDuration;
    //        float scale = Mathf.Lerp(currentScale, maxScale, t);
    //        transform.localScale = initialScale * scale;
    //        yield return null;
    //    }

    //    isGrowing = false;
    //    currentScale = maxScale;
    //    transform.localScale = initialScale * currentScale;
    //}


    public float growDuration = 2f;       // 变大的持续时间
    public float shrinkDuration = 2f;     // 缩小的持续时间
    public float maxScale = 2f;           // 球体的最大缩放比例
    private Vector3 initialScale;         // 初始缩放比例
    private float currentScale;           // 当前缩放比例
    private float timer;                  // 计时器
    private bool isGrowing;               // 是否正在变大
    private Coroutine growCoroutine;      // 变大的协程

    [SerializeField] GameObject Level_UP_Button;

    void Start()
    {
        initialScale = transform.localScale;
        currentScale = transform.localScale.x;
    }

    //Level_UP按钮调用的函数
    public void LevelUP()
    {
        if (!isGrowing)
        {
            if (growCoroutine != null)
                StopCoroutine(growCoroutine);

            growCoroutine = StartCoroutine(Grow());
        }
        Level_UP_Button.SetActive(false);
    }

    IEnumerator Grow()
    {
        isGrowing = true;
        timer = 0f;
        float startScale = currentScale;///

        while (timer < growDuration)
        {
            timer += Time.deltaTime;
            float t = timer / growDuration;
            float scale = Mathf.Lerp(currentScale, maxScale, t);
            transform.localScale = initialScale * scale;
            yield return null;
        }

        // 在变大后启动缩小协程
        StartCoroutine(Shrink(startScale));///
    }

    IEnumerator Shrink(float startScale)///
    {
        ///
        float timer = 0f;

        while (timer < shrinkDuration)
        {
            timer += Time.deltaTime;
            float t = timer / shrinkDuration;
            float scale = Mathf.Lerp(startScale, 1f, t);
            transform.localScale = initialScale * scale;
            yield return null;
        }

        // 缩小完成后重置状态和比例
        isGrowing = false;
        currentScale = 1f;
        transform.localScale = initialScale * currentScale;
    }
}
    
