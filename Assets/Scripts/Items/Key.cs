using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item 
{
    public override string GetStr()
    {
        return "��Կ���Ҽ��Լ����ļ���ʹ�ã����������ļ���";
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
        GetComponent<Animator>().SetTrigger("erase");
        GameObject.Find("Ч����Ч").GetComponent<AudioContonller>().SetAudio(6);
        //�ı�����ļ���logo��Ŀǰ�����ڵ��������ʵ��
    }
    public void MyDestroy()
    {
        GameObject g = GameObject.Find("Container");
        g.GetComponent<ItemController>().SetFlash();
        Destroy(gameObject);
    }
}
