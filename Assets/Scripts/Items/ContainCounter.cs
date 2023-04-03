using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainCounter 
{
    private ArrayList m_items;//存储道具的数组
    private int m_capacity;//可存储的容量
    public ContainCounter(int capacity)
    {
        m_items = new ArrayList();
        m_capacity = capacity;
    }
    //存入物体，成功返回true；如果空间已满，返回false，
    public bool SetItems(GameObject item)
    {
        if (m_items.Count< m_capacity)
        {
            m_items.Add(item);
            return true;
        }
        return false;
    }

    //根据id来表示使用的是什么道具
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
