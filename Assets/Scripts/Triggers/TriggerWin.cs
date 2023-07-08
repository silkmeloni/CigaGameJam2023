using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    [Header("需要的钥匙数量")]
    public int keysToWin = 3;

    private Dictionary<string, bool> visKey = new Dictionary<string, bool>();
    //当前拥有的钥匙数量
    private int currentKeyNumber = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("CheckPoint"))
        {
            //如果该检查点没访问过
            if (!visKey.ContainsKey(col.gameObject.name))
            {
                visKey[col.gameObject.name] = true;
                currentKeyNumber++;
                Debug.Log("拿到了一个，当前的transform为:"+col.gameObject);
                //TODO:反馈
                
                //胜利判定
                if (currentKeyNumber == keysToWin)
                {
                    Win();
                }
            }
        }
    }

    /// <summary>
    /// 获胜后的表现效果
    /// </summary>
    private void Win()
    {
        Debug.Log("你赢了!!!!");
    }
}
