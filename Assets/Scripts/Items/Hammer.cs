using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 粉碎机类
 */
public class Hammer:Item
{
    public Hammer()
    {

    }
    public override string GetStr()
    {
        return "粉碎机：右键垃圾、病毒文件时使用，瞬间删除垃圾、病毒文件";
    }
    public override int GetID()
    {
        return 1;
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
        GetComponent<Animator>().SetTrigger("erase");
        GameObject.Find("效果音效").GetComponent<AudioContonller>().SetAudio(6);
        //调用改变删除速度的接口，目前可能在点击处更好实现
    }
    public void MyDestroy()
    {
        GameObject g = GameObject.Find("Container");
        g.GetComponent<ItemController>().SetFlash();
        Destroy(gameObject);
    }
}
