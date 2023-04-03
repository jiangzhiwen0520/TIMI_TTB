using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
  
    public Texture2D cursorTexture; // ��Ϸ������������
    public Vector2 hotSpot = Vector2.zero; // �������� "�ȵ�"���������λ����������������

    private void Start()
    {
        // �����Զ����������
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }


    
}
