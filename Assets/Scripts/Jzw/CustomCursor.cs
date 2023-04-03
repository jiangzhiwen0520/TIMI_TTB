using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
  
    public Texture2D[] cursorTexture; // ��Ϸ������������
    public Vector2 hotSpot = Vector2.zero; // �������� "�ȵ�"���������λ����������������

    private float m_time=1.8f;
    private bool m_change = false;
    private void Start()
    {
        // �����Զ����������
        Cursor.SetCursor(cursorTexture[0], hotSpot, CursorMode.Auto);
    }
    public void Change()
    {
        m_change = true;
        Cursor.SetCursor(cursorTexture[1], hotSpot, CursorMode.Auto);
    }

    private void Update()
    {
        if (m_change)
        {
            m_time -= Time.deltaTime;
            if (m_time <= 0)
            {
                Cursor.SetCursor(cursorTexture[0], hotSpot, CursorMode.Auto);
                m_time = 1.8f;
                m_change = false;
            }


        }
    }

}
