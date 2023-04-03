using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
  
    public Texture2D cursorTexture; // 游戏内鼠标外观纹理
    public Vector2 hotSpot = Vector2.zero; // 鼠标纹理的 "热点"，即鼠标点击位置相对于纹理的坐标

    private void Start()
    {
        // 设置自定义鼠标纹理
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }


    
}
