using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFileMove : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isMoving = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
                isMoving = !isMoving;
            }
        }

        // ��������ƶ������¶���λ��Ϊ���λ��
        if (isMoving)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }
}
