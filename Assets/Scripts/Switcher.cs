using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    private bool State = true;
    [SerializeField] GameObject[] State_1;  //状态1的机关组
    [SerializeField] GameObject[] State_2;  //状态2的机关组

    public Color newColor;
    public Color orgColor;

    public GameObject[] button;

    public SpriteRenderer[] renderer;

    private void Start()
    {
        //renderer = button.GetComponent<SpriteRenderer>();
        //orgColor = renderer.material.color;

        //for (int i = 0; i < renderer.Length; i++)
        //{
        //    renderer[i] = button[i].GetComponent<SpriteRenderer>();
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Switch")
        {
            //遇到后开灯
            collision.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Switch")
        {

            //遇到后开灯
            collision.transform.GetChild(0).gameObject.SetActive(true);
            
            if (!State)
            {
                //(1)机关切换
                for (int i = 0; i < State_1.Length; i++)
                {
                    State_1[i].SetActive(false);
                }
                for (int i = 0; i < State_2.Length; i++)
                {
                    State_2[i].SetActive(true);
                }
                //(2)状态切换
                State = true;
                //(3)切换颜色
                //renderer.color = orgColor;
                for (int i = 0; i < renderer.Length; i++)
                {
                    renderer[i].color = orgColor;
                }


            }
            else
            {
                //(1)机关切换
                for (int i = 0; i < State_1.Length; i++)
                {
                    State_1[i].SetActive(true);
                }
                for (int i = 0; i < State_2.Length; i++)
                {
                    State_2[i].SetActive(false);
                }
                //(2)状态切换
                State = false;
                //(3)切换颜色
                //renderer.color = newColor;
                for (int i = 0; i < renderer.Length; i++)
                {
                    renderer[i].color = newColor;
                }
            }
           
        }
        
    }
}
