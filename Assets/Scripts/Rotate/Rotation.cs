
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private bool isRotating = false;            //��¼�Ƿ�������ת�ı���
    private Vector3 mouseStartPos;              //��¼��꿪ʼ�����λ��
    [SerializeField] float rotationSpeed = 1f;  // ������ת���ٶ�

    void Update()
    {
        // ����������
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            mouseStartPos = Input.mousePosition;
        }

        // ������̧��
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }

        // ���������²����ƶ�
        if (isRotating && Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - mouseStartPos.x;     //x��仯����

            // ������껬���ľ��������ת
            transform.Rotate(Vector3.forward, -deltaX * rotationSpeed);

            mouseStartPos = Input.mousePosition;
        }
    }
}