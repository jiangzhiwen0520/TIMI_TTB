using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFileMove : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool isMoving = false;
    public GameObject sourceParent;
    public Rect bounds; // �������ƣ�������Unity�༭��������
    public Camera mainCamera; // �����������Ҫ��Unity�༭����ָ��

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null || GameObject.FindWithTag("ShockDialog") != null)
        {
            return;
        }
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
                isMoving = true;
                transform.SetParent(GameObject.Find("�ļ�ϵͳ").transform);
                gameObject.GetComponent<FileChoose>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
                GameObject.Find("��Ƶϵͳ").GetComponent<changeBgm>().SetClip();
            }
        }

        // ��������ƶ������¶���λ��Ϊ���λ��
        if (isMoving)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            mousePosition.x = Mathf.Clamp(mousePosition.x, bounds.xMin, bounds.xMax);
            mousePosition.y = Mathf.Clamp(mousePosition.y, bounds.yMin, bounds.yMax);

            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }
    public void Reset()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null)
        {
            return;
        }
        isMoving = false;
        transform.position = new Vector3(0, 0, 0);
        transform.SetParent(sourceParent.transform,false);
        gameObject.GetComponent<FileChoose>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        //Debug.Log(transform.position);
        //transform.position = new Vector3(0, 0, 0);
        //Debug.Log(transform.position);
    }
}
