using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock: Item
{
    public override string GetStr()
    {
        return "ʱ�ӣ��ڵ��ߴ��ڵ�����ϴ����Ҽ����ʹ�ã���ͣ5����ļ��ϴ�";
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
            //��Чɶ��
            Func();
        }
    }
    public override void Func()
    {
        Debug.Log("��ͣ�ϴ�");
        GetComponent<Animator>().SetTrigger("erase");
        //������ͣ�ļ�5���ϴ��������������ø��ź�
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
