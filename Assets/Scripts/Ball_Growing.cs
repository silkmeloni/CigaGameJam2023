using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Growing : MonoBehaviour
{
    //public float growDuration = 2f;       // ���ĳ���ʱ��
    //public float maxScale = 2f;           // �����������ű���
    //private Vector3 initialScale;         // ��ʼ���ű���
    //private float currentScale;           // ��ǰ���ű���
    //private float timer;                  // ��ʱ��
    //private bool isGrowing;               // �Ƿ����ڱ��
    //private Coroutine growCoroutine;      // ����Э��

    //[SerializeField] GameObject Level_UP_Button;

    //void Start()
    //{
    //    initialScale = transform.localScale;
    //    currentScale = transform.localScale.x;
    //}

    ////Level_UP��ť���õĺ���
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

    //IEnumerator Grow()      //Я�̿������尴ʱ��������
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


    public float growDuration = 2f;       // ���ĳ���ʱ��
    public float shrinkDuration = 2f;     // ��С�ĳ���ʱ��
    public float maxScale = 2f;           // �����������ű���
    private Vector3 initialScale;         // ��ʼ���ű���
    private float currentScale;           // ��ǰ���ű���
    private float timer;                  // ��ʱ��
    private bool isGrowing;               // �Ƿ����ڱ��
    private Coroutine growCoroutine;      // ����Э��

    [SerializeField] GameObject Level_UP_Button;

    void Start()
    {
        initialScale = transform.localScale;
        currentScale = transform.localScale.x;
    }

    //Level_UP��ť���õĺ���
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

        // �ڱ���������СЭ��
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

        // ��С��ɺ�����״̬�ͱ���
        isGrowing = false;
        currentScale = 1f;
        transform.localScale = initialScale * currentScale;
    }
}
    
