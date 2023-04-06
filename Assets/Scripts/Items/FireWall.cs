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
        //gameObject.GetComponent<TMPro.TextMeshPro>().SetText(GetStr());
    }
    private void OnMouseExit()
    {
        //gameObject.GetComponent<TMPro.TextMeshPro>().SetText("");
    }

    public override void Func()
    {
        //�����޵�ʱ��
        GetComponent<Animator>().SetTrigger("erase");
        GameObject.Find("Ч����Ч").GetComponent<AudioContonller>().SetAudio(6);
        GameObject[] objects= GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject i in objects)
        {
            i.GetComponent<BulletController>().SetInvincible();
        }
        GameObject cursor = GameObject.Find("���");
        cursor.GetComponent<CustomCursor>().Change(1,1.9f);
        
    }
    public void MyDestroy()
    {
        GameObject g = GameObject.Find("Container");
        g.GetComponent<ItemController>().SetFlash();
        Destroy(gameObject);
    }
}
