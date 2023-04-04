using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FileChoose : MonoBehaviour
{
    public float hoverScaleFactor = 1.2f; // ��ͣʱ����������
    private Vector3 originalScale; // ԭʼ����ֵ
    private bool isMouseOver = false; // �������Ƿ��ڶ�����

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
        isMouseOver = true;

         GameObject.Find("���").GetComponent<ShowInfo>().ShowObjectInfo(gameObject.name);
    }

    private void OnMouseExit()
    {
        isMouseOver = false;

        GameObject.Find("���").GetComponent<ShowInfo>().ClearText();
    }
}
