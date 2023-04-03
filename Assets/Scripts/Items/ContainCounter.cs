using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainCounter 
{
    private ArrayList m_items;//�洢���ߵ�����
    private int m_capacity;//�ɴ洢������
    public ContainCounter(int capacity)
    {
        m_items = new ArrayList();
        m_capacity = capacity;
    }
    //�������壬�ɹ�����true������ռ�����������false��
    public bool SetItems(GameObject item)
    {
        if (m_items.Count< m_capacity)
        {
            m_items.Add(item);
            return true;
        }
        return false;
    }

    //����id����ʾʹ�õ���ʲô����
    public GameObject UseItems(int id)
    {
        foreach(GameObject it in m_items)
        {
            if (id==0&&it.GetComponent<Key>() != null)
            {
                m_items.Remove(it);
                return it;
            }
            else if(id==1&& it.GetComponent<Hammer>() != null)
            {
                m_items.Remove(it);
                return it;
            }
            else if(id==2&& it.GetComponent<FireWall>() != null)
            {
                m_items.Remove(it);
                return it;
            }
            else if(id==3&&it.GetComponent<Clock>() != null)
            {
                m_items.Remove(it);
                return it;
            }
            else if (id == 4 && it.GetComponent<TheWorld>() != null)
            {
                m_items.Remove(it);
                return it;
            }
        }
        return null;
    }


    public void UseItems(GameObject o)
    {
         
         m_items.Remove(o);

    }
    public ArrayList GetItems()
    {
        return m_items;
    }

}
