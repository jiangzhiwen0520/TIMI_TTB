using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteFileTest : MonoBehaviour
{
    public float longPressTime ; // �趨����ʱ��Ϊ 2 �� ��ȥ���ٶ�����ʱ��

    private bool isPressing = false;
    private float pressTimer = 0f;

    public Animator animator;

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null || GameObject.FindWithTag("ShockDialog") != null)
        {
            return;
        }
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
                //GameObject.Find("Ч����Ч").GetComponent<AudioContonller>().SetAudio(2);
                animator.SetTrigger("destroy");
                pressTimer = 0f;
                isPressing = false;
            }
        }

        
    }

    public void DestoryFile()
    {
        GameObject.Find("Ч����Ч").GetComponent<AudioContonller>().SetAudio(2);
        Destroy(gameObject);
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1))
        {
            GameObject a = GameObject.Find("Container").GetComponent<ItemController>().GetContainCounter().UseItems(1);
            if (a == null)
            {
                return;
            }
            else
            {
                
                a.GetComponent<Hammer>().Func();
                animator.SetTrigger("destroy");
                //Destroy(gameObject,1);
            }
        }
    }
}
