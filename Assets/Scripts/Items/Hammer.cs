using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * �������
 */
public class Hammer:Item
{
    public Hammer()
    {

    }
    public override string GetStr()
    {
        return "��������Ҽ������������ļ�ʱʹ�ã�˲��ɾ�������������ļ�";
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
        GameObject.Find("Ч����Ч").GetComponent<AudioContonller>().SetAudio(6);
        //���øı�ɾ���ٶȵĽӿڣ�Ŀǰ�����ڵ��������ʵ��
    }
    public void MyDestroy()
    {
        GameObject g = GameObject.Find("Container");
        g.GetComponent<ItemController>().SetFlash();
        Destroy(gameObject);
    }
}
