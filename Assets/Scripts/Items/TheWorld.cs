using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : Item
{
    public override string GetStr()
    {
        return "����³�ࣺ�ڵ��ߴ��ڵ��ʹ�ã������ļ��Ͳ����ӵ�ֹͣ�ж�5��";
    }
    public override int GetID()
    {
        return 4;
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
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null)
        {
            return;
        }
        if (GameObject.FindWithTag("ShockDialog") == null)
        {
            Func();
            GameObject g = GameObject.Find("Container");
            ContainCounter counter = g.GetComponent<ItemController>().GetContainCounter();
            counter.UseItems(gameObject);
            //g.GetComponent<ItemController>().ShowItems();
            //Destroy(gameObject, 0.583f);
        }
    }

    public override void Func()
    {
        GetComponent<Animator>().SetTrigger("erase");
        //�����ļ��Ͳ����ӵ�ֹͣ�ƶ�
        GameObject[] objects= GameObject.FindGameObjectsWithTag("Bullet"); 
        foreach(GameObject i in objects)
        {
            i.GetComponent<BulletController>().SetStop();
        }
        objects = GameObject.FindGameObjectsWithTag("RemovableFiles");
        foreach (GameObject i in objects)
        {
            i.GetComponent<fileMove>().SetStop();
        }
        objects = GameObject.FindGameObjectsWithTag("RVFiles");
        foreach (GameObject i in objects)
        {
            i.GetComponent<fileMove>().SetStop();
        }
    }
    public void MyDestroy()
    {
        GameObject g = GameObject.Find("Container");
        g.GetComponent<ItemController>().SetFlash();
        Destroy(gameObject);
    }
}
