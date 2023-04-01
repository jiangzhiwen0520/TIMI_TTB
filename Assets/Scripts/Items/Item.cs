using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected int _id;//道具id
    /*
     * 0:密钥
     * 1:粉碎机
     * 2:盔甲，庇护一次子弹射击
     */
    /*得到功能描述*/
    public abstract string GetStr();
    public abstract int GetID();

    /*功能实现*/
    public abstract void Func();
}
