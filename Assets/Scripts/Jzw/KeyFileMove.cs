using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFileMove : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool isMoving = false;

    public Rect bounds; // �������ƣ�������Unity�༭��������
    public Camera mainCamera; // �����������Ҫ��Unity�༭����ָ��

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
                isMoving = true;
                transform.SetParent(GameObject.Find("�ļ�ϵͳ").transform);
                gameObject.GetComponent<FileChoose>().enabled = false;
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
}
