using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
  
    public Texture2D[] cursorTexture; // 游戏内鼠标外观纹理
    public Vector2 hotSpot = Vector2.zero; // 鼠标纹理的 "热点"，即鼠标点击位置相对于纹理的坐标

    private float m_time=1.8f;
    private bool m_change = false;
    private void Start()
    {
        // 设置自定义鼠标纹理
        Cursor.SetCursor(cursorTexture[0], hotSpot, CursorMode.Auto);
        
    }
    public void Change(int i,float t)
    {
        m_change = true;
        Cursor.SetCursor(cursorTexture[i], hotSpot, CursorMode.Auto);
        m_time = t;
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
