using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock: Item
{
    public override string GetStr()
    {
        return "时钟：在道具窗口点击或上传条右键点击使用，暂停5秒的文件上传";
    }
    public override int GetID()
    {
        return 3;
    }

    private void OnMouseOver()
    {
        //gameObject.GetComponent<TMPro.TextMeshPro>().SetText(GetStr());
    }
    private void OnMouseExit()
    {
        //gameObject.GetComponent<TMPro.TextMeshPro>().SetText("");
    }
    private void OnMouseDown()
    {
        if (GameObject.FindWithTag("ShockDialog") == null)
        {
            GameObject g = GameObject.Find("Container");
            ContainCounter counter = g.GetComponent<ItemController>().GetContainCounter();
            counter.UseItems(gameObject);
            //特效啥的
            Func();
        }
    }
    public override void Func()
    {
        Debug.Log("暂停上传");
        GetComponent<Animator>().SetTrigger("erase");
        //调用暂停文件5秒上传函数，可以设置个信号
        //
        //
    }
    public void MyDestroy()
    {
        GameObject g = GameObject.Find("Container");
        g.GetComponent<ItemController>().SetFlash();
        Destroy(gameObject);
    }
}
