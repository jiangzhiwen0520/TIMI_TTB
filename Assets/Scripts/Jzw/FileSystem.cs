using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSystem : MonoBehaviour
{
    private void Update()
    {
        // �������Ҽ��Ƿ���
        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("�����Ҽ�");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider != null && hitCollider.transform == transform)
            {
                // �������ھ��ζ����ϣ���ʼ�ƶ�
                //Debug.Log("�Ҽ���Ҫ�ļ�");
                
                
            }
        }

        // ��������ƶ������¶���λ��Ϊ���λ��
       
    }

}
