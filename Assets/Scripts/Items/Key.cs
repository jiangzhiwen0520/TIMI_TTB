using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item 
{
    public override string GetStr()
    {
        return "密钥：右键对加密文件夹使用，解锁加密文件夹";
    }
    public override int GetID()
    {
        return 0;
    }

    private void OnMouseOver()
    {
        //gameObject.GetComponent<TMPro.TextMeshPro>().SetText(GetStr());
    }
    private void OnMouseExit()
    {
        //gameObject.GetComponent<TMPro.TextMeshPro>().SetText("");
    }

    public override void Func()
    {
        //改变加密文件的logo，目前可能在点击处更好实现
    }
}
