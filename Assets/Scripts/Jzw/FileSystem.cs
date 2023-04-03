using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSystem : MonoBehaviour
{
    private void Update()
    {
        // 检测鼠标右键是否按下
        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("按下右键");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider != null && hitCollider.transform == transform)
            {
                // 如果鼠标在矩形对象上，开始移动
                //Debug.Log("右键重要文件");
                
                
            }
        }

        // 如果正在移动，更新对象位置为鼠标位置
       
    }

}
