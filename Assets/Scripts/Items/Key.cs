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
        //�ı�����ļ���logo��Ŀǰ�����ڵ��������ʵ��
    }
}
