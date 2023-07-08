using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    private bool State = true;
    [SerializeField] GameObject[] State_1;  //״̬1�Ļ�����
    [SerializeField] GameObject[] State_2;  //״̬2�Ļ�����

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
            //�����󿪵�
            collision.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Switch")
        {

            //�����󿪵�
            collision.transform.GetChild(0).gameObject.SetActive(true);
            
            if (!State)
            {
                //(1)�����л�
                for (int i = 0; i < State_1.Length; i++)
                {
                    State_1[i].SetActive(false);
                }
                for (int i = 0; i < State_2.Length; i++)
                {
                    State_2[i].SetActive(true);
                }
                //(2)״̬�л�
                State = true;
                //(3)�л���ɫ
                //renderer.color = orgColor;
                for (int i = 0; i < renderer.Length; i++)
                {
                    renderer[i].color = orgColor;
                }


            }
            else
            {
                //(1)�����л�
                for (int i = 0; i < State_1.Length; i++)
                {
                    State_1[i].SetActive(true);
                }
                for (int i = 0; i < State_2.Length; i++)
                {
                    State_2[i].SetActive(false);
                }
                //(2)״̬�л�
                State = false;
                //(3)�л���ɫ
                //renderer.color = newColor;
                for (int i = 0; i < renderer.Length; i++)
                {
                    renderer[i].color = newColor;
                }
            }
           
        }
        
    }
}
