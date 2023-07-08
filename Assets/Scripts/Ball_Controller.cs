using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    private bool isTouching = true;     //控制是否接触的布尔变量
    //public GameObject gameOverPanel;    //游戏结束页面
    [SerializeField] GameObject Level_UP_Button;

    //机关触发：
    public bool State = false;
    [SerializeField] GameObject[] State_1;  //状态1的机关组
    [SerializeField] GameObject[] State_2;  //状态2的机关组
    private void Update()
    {
        CheckContact();
        if (!isTouching)
        {
            //GameOver();//游戏结束的脚本
        }
    }

    //接触检测的方法
    private void CheckContact()
    {
        Collider2D[] colliders = new Collider2D[10]; // 存储接触的碰撞器列表

        // 指定需要检测接触的区域
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = false; // 不使用触发器进行检测

        // 执行接触检测
        int count = Physics2D.OverlapCollider(GetComponent<Collider2D>(), filter, colliders);

        if (count > 0)// 如果有碰撞器接触，则设置为正在接触状态
        {
            
            isTouching = true;
        }
        else// 如果没有碰撞器接触，则设置为非接触状态
        {
            isTouching = false;
            Debug.Log("没有发生接触！");
        }
        //for (int i = 0; i < count; i++)
        //{
        //    // 处理接触事件，例如打印接触对象的名称
        //    Debug.Log("发生接触的物体：" + colliders[i].gameObject.name);
        //}
    }

    //检测道具拾取
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //(1)变大道具收集
        if (collision.tag == "Item")
        {
            Destroy(collision.gameObject);
            Level_UP_Button.SetActive(true);
        }
        
    }

   

    //游戏结束
    //private void GameOver()
    //{
    //    gameOverPanel.SetActive(true);
    //    Time.timeScale = 0f;    //暂停游戏运行
    //}
}