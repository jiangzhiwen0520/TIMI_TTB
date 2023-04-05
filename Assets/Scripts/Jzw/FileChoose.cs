using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FileChoose : MonoBehaviour
{
    public float hoverScaleFactor = 1.2f; // 悬停时的缩放因子
    private Vector3 originalScale; // 原始缩放值
    public bool isMouseOver = false; // 标记鼠标是否在对象上

    private SpriteRenderer spriteRenderer;

    //[SerializeField] private ShowInfo showInfo;

  
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;

        
    }

    /*private void OnEnable()
    {
        if(originalScale!=null)
            transform.localScale = originalScale;
    }*/

    private void Update()
    {
        if (isMouseOver)
        {
            transform.localScale = originalScale * hoverScaleFactor;

           
        }
        else
        {
            transform.localScale = originalScale;
        }
    }

    private void OnMouseEnter()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null || GameObject.FindWithTag("ShockDialog") != null)
        {
            return;
        }
        isMouseOver = true;

         GameObject.Find("鼠标").GetComponent<ShowInfo>().ShowObjectInfo(gameObject.name);
    }

    private void OnMouseExit()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null || GameObject.FindWithTag("ShockDialog") != null)
        {
            return;
        }
        isMouseOver = false;

        GameObject.Find("鼠标").GetComponent<ShowInfo>().ClearText();
    }
}
