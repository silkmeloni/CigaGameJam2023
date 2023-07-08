using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    private bool State = false;
    [SerializeField] GameObject[] State_1;  //״̬1�Ļ�����
    [SerializeField] GameObject[] State_2;  //״̬2�Ļ�����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Switch")
        {
            //�����󿪵�
            collision.transform.GetChild(0).gameObject.SetActive(true);
            
            if (State)
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
                State = false;
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
                State = true;
            }
           
        }
        
    }
}
