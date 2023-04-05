using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteFileTest : MonoBehaviour
{
    public float longPressTime ; // 设定长按时间为 2 秒 减去销毁动画的时长

    private bool isPressing = false;
    private float pressTimer = 0f;

    public Animator animator;

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null || GameObject.FindWithTag("ShockDialog") != null)
        {
            return;
        }
        // 检测鼠标左键是否按下
        if (Input.GetMouseButtonDown(0))
        {
            // 获取鼠标点击位置并转换为世界坐标
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 检测鼠标点击位置是否在矩形对象的 Collider 内
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
            if (hitCollider != null && hitCollider.transform == transform)
            {
                isPressing = true;
            }
        }

        // 检测鼠标左键是否释放
        if (Input.GetMouseButtonUp(0))
        {
            isPressing = false;
            pressTimer = 0f;
        }

        // 如果正在按下，更新计时器
        if (isPressing)
        {
            pressTimer += Time.deltaTime;

            // 如果计时器达到长按时间，删除对象并重置计时器
            if (pressTimer >= longPressTime)
            {
                //GameObject.Find("效果音效").GetComponent<AudioContonller>().SetAudio(2);
                animator.SetTrigger("destroy");
                pressTimer = 0f;
                isPressing = false;
            }
        }

        
    }

    public void DestoryFile()
    {
        GameObject.Find("效果音效").GetComponent<AudioContonller>().SetAudio(2);
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
