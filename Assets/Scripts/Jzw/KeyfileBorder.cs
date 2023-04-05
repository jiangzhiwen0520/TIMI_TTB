using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyfileBorder : MonoBehaviour
{
    public Rect bounds; // 区域限制，可以在Unity编辑器中设置
    public Camera mainCamera; // 主摄像机，需要在Unity编辑器中指定


    void Update()
    {
        // 获取鼠标的屏幕坐标
        Vector3 mouseScreenPos = Input.mousePosition;

        // 将屏幕坐标转换为世界坐标
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        // 保持物体的z轴位置不变
        mouseWorldPos.z = transform.position.z;

        // 根据限制区域调整坐标
        mouseWorldPos.x = Mathf.Clamp(mouseWorldPos.x, bounds.xMin, bounds.xMax);
        mouseWorldPos.y = Mathf.Clamp(mouseWorldPos.y, bounds.yMin, bounds.yMax);

        // 设置游戏对象的位置
        //transform.position = mouseWorldPos;
    }

}
