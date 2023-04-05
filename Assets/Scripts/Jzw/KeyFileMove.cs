using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFileMove : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool isMoving = false;
    public GameObject sourceParent;
    public Rect bounds; // 区域限制，可以在Unity编辑器中设置
    public Camera mainCamera; // 主摄像机，需要在Unity编辑器中指定

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
                isMoving = true;
                transform.SetParent(GameObject.Find("文件系统").transform);
                gameObject.GetComponent<FileChoose>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
                GameObject.Find("音频系统").GetComponent<changeBgm>().SetClip();
            }
        }

        // 如果正在移动，更新对象位置为鼠标位置
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
