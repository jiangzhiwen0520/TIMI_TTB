using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : Item
{
    public override string GetStr()
    {
        return "����ǽ���������ӵ��������Զ�ʹ�ã���ֹ�˴ι��������޵�2��";
    }
    public override int GetID()
    {
        return 2;
    }

    private void OnMouseOver()
    {
        gameObject.GetComponent<TMPro.TextMeshPro>().SetText(GetStr());
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<TMPro.TextMeshPro>().SetText("");
    }

    public override void Func()
    {
        //�����޵�ʱ��
        GameObject[] objects= GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject i in objects)
        {
            i.GetComponent<BulletController>().SetInvincible();
        }
    }
}
