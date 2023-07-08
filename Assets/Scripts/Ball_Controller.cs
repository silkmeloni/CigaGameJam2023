using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    private bool isTouching = true;     //�����Ƿ�Ӵ��Ĳ�������
    //public GameObject gameOverPanel;    //��Ϸ����ҳ��
    [SerializeField] GameObject Level_UP_Button;

    //���ش�����
    public bool State = false;
    [SerializeField] GameObject[] State_1;  //״̬1�Ļ�����
    [SerializeField] GameObject[] State_2;  //״̬2�Ļ�����
    private void Update()
    {
        CheckContact();
        if (!isTouching)
        {
            //GameOver();//��Ϸ�����Ľű�
        }
    }

    //�Ӵ����ķ���
    private void CheckContact()
    {
        Collider2D[] colliders = new Collider2D[10]; // �洢�Ӵ�����ײ���б�

        // ָ����Ҫ���Ӵ�������
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = false; // ��ʹ�ô��������м��

        // ִ�нӴ����
        int count = Physics2D.OverlapCollider(GetComponent<Collider2D>(), filter, colliders);

        if (count > 0)// �������ײ���Ӵ���������Ϊ���ڽӴ�״̬
        {
            
            isTouching = true;
        }
        else// ���û����ײ���Ӵ���������Ϊ�ǽӴ�״̬
        {
            isTouching = false;
            Debug.Log("û�з����Ӵ���");
        }
        //for (int i = 0; i < count; i++)
        //{
        //    // ����Ӵ��¼��������ӡ�Ӵ����������
        //    Debug.Log("�����Ӵ������壺" + colliders[i].gameObject.name);
        //}
    }

    //������ʰȡ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //(1)�������ռ�
        if (collision.tag == "Item")
        {
            Destroy(collision.gameObject);
            Level_UP_Button.SetActive(true);
        }
        
    }

   

    //��Ϸ����
    //private void GameOver()
    //{
    //    gameOverPanel.SetActive(true);
    //    Time.timeScale = 0f;    //��ͣ��Ϸ����
    //}
}