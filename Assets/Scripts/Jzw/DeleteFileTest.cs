using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteFileTest : MonoBehaviour
{
    public float longPressTime = 2f; // �趨����ʱ��Ϊ 2 �� ��ȥ���ٶ�����ʱ��

    private bool isPressing = false;
    private float pressTimer = 0f;

    public Animator animator;

    private void Update()
    {
        // ����������Ƿ���
        if (Input.GetMouseButtonDown(0))
        {
            // ��ȡ�����λ�ò�ת��Ϊ��������
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ��������λ���Ƿ��ھ��ζ���� Collider ��
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
            if (hitCollider != null && hitCollider.transform == transform)
            {
                isPressing = true;
            }
        }

        // ����������Ƿ��ͷ�
        if (Input.GetMouseButtonUp(0))
        {
            isPressing = false;
            pressTimer = 0f;
        }

        // ������ڰ��£����¼�ʱ��
        if (isPressing)
        {
            pressTimer += Time.deltaTime;

            // �����ʱ���ﵽ����ʱ�䣬ɾ���������ü�ʱ��
            if (pressTimer >= longPressTime)
            {

                
                animator.SetTrigger("destroy");
                pressTimer = 0f;
                isPressing = false;
            }
        }
    }

    public void DestoryFile()
    {
        Destroy(gameObject);
    }
}
