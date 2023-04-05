using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyfileBorder : MonoBehaviour
{
    public Rect bounds; // �������ƣ�������Unity�༭��������
    public Camera mainCamera; // �����������Ҫ��Unity�༭����ָ��


    void Update()
    {
        // ��ȡ������Ļ����
        Vector3 mouseScreenPos = Input.mousePosition;

        // ����Ļ����ת��Ϊ��������
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        // ���������z��λ�ò���
        mouseWorldPos.z = transform.position.z;

        // �������������������
        mouseWorldPos.x = Mathf.Clamp(mouseWorldPos.x, bounds.xMin, bounds.xMax);
        mouseWorldPos.y = Mathf.Clamp(mouseWorldPos.y, bounds.yMin, bounds.yMax);

        // ������Ϸ�����λ��
        //transform.position = mouseWorldPos;
    }

}
