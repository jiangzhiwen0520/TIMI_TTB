using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected int _id;//����id
    /*
     * 0:��Կ
     * 1:�����
     * 2:���ף��ӻ�һ���ӵ����
     */
    /*�õ���������*/
    public abstract string GetStr();
    public abstract int GetID();

    /*����ʵ��*/
    public abstract void Func();
}
