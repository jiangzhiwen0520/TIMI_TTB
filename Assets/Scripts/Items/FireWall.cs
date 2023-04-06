using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : Item
{
    public override string GetStr()
    {
        return "防火墙：被病毒子弹攻击后自动使用，防止此次攻击并且无敌2秒";
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
        //设置无敌时间
        GetComponent<Animator>().SetTrigger("erase");
        GameObject.Find("效果音效").GetComponent<AudioContonller>().SetAudio(6);
        GameObject[] objects= GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject i in objects)
        {
            i.GetComponent<BulletController>().SetInvincible();
        }
        GameObject cursor = GameObject.Find("鼠标");
        cursor.GetComponent<CustomCursor>().Change(1,1.9f);
        
    }
    public void MyDestroy()
    {
        GameObject g = GameObject.Find("Container");
        g.GetComponent<ItemController>().SetFlash();
        Destroy(gameObject);
    }
}
