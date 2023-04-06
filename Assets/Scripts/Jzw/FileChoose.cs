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

        string infoText = gameObject.name;
        if (gameObject.tag != "Folder")
        {
            infoText = infoText.Replace("普通垃圾（小）", "小垃圾：\n左键删除时间：1s\n占据空间：1");
            infoText = infoText.Replace("中垃圾", "中垃圾：\n左键删除时间：1.5s\n占据空间：2");
            infoText = infoText.Replace("大垃圾", "大垃圾：\n左键删除时间：3s\n占据空间：4");
            infoText = infoText.Replace("普通病毒（小）", "小病毒：\n左键删除时间：1s\n占据空间：1");
            infoText = infoText.Replace("中病毒", "中病毒：\n左键删除时间：1.5s\n占据空间：2");
            infoText = infoText.Replace("大病毒", "大病毒：\n左键删除时间：3s\n占据空间：4");
            infoText = infoText.Replace("普通文件", "普通文件：\n左键删除时间：无法删除\n占据空间：1");
            infoText = infoText.Replace("安全点", "安全点：\n功能：转移重要文件到此，点击左键");
            infoText = infoText.Replace("重要文件", "重要文件：\n功能：点击右键开始转移重要文件");
            infoText = infoText.Replace("云盾（防火墙(Clone)", "云盾：\n功能：自动使用，可以免疫一次病毒的攻击并短暂无敌");
            infoText = infoText.Replace("云盾", "云盾：\n功能：自动使用，可以免疫一次病毒的攻击并短暂无敌");
            infoText = infoText.Replace("时钟 1", "时钟：\n功能：从道具栏点击，可以冻结上传条，暂停文件的上传5s");
            infoText = infoText.Replace("时钟", "时钟：\n功能：从道具栏点击，可以冻结上传条，暂停文件的上传5s");
            infoText = infoText.Replace("砸瓦鲁多 1", "沙漏：\n功能：从道具栏点击，可以冻结文件与病毒的移动5s");
            infoText = infoText.Replace("砸瓦鲁多", "沙漏：\n功能：从道具栏点击，可以冻结文件与病毒的移动5s");
            infoText = infoText.Replace("粉碎机 1", "粉碎机：\n功能：右键点击文件，可以消耗道具将其瞬间删除");
            infoText = infoText.Replace("粉碎机", "粉碎机：\n功能：右键点击文件，可以消耗道具将其瞬间删除");
            infoText = infoText.Replace("钥匙 1", "密钥：\n功能：右键点击上锁文件夹，可以将其解锁");
            infoText = infoText.Replace("key", "密钥：\n功能：右键点击上锁文件夹，可以将其解锁");
            infoText = infoText.Replace("(Clone)", "");



            GameObject.Find("鼠标").GetComponent<ShowInfo>().ShowObjectInfo(infoText);

        }
        






        else
        {
            GameObject.Find("鼠标").GetComponent<ShowInfo>().ShowObjectInfo(gameObject.name);
        }
        
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
