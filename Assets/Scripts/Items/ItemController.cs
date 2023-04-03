using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float h;
    public float itemH;
    private ContainCounter m_container;
    [SerializeField]
    private int capacity=0;
    private int m_start = 0;
    private float m_w, m_h, m_x, m_y;//容器大小
    private bool m_flash=false;
    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    void Update()
    {
        if (m_flash)
        {
            ShowItems();
        }
    }

    public void ShowItems()
    {
        ArrayList items =m_container.GetItems();
        int first = m_start;
        //Debug.Log("m_start  "+first);
        //Debug.Log("items.Count  " + items.Count);
        if (items.Count- first <= 6)
        {
            first = items.Count-6;
            if (first < 0) first = 0;
            m_start = first;
        }
        //Debug.Log("first  " + first);
        //float h=0;
        /*if (items.Count != 0)
        {
            //w = ((GameObject)items[0]).transform.localScale.x;
            h = ((GameObject)items[0]).transform.localScale.x;
        }*/
        float start = m_y + m_h / 2.0f- itemH / 2;
        float end = m_y - m_h / 2.0f;
        int i = 0;
        foreach (GameObject it in items)
        {
            if (i >= first && start >= end)
            {
                //if (start < end) break;//需要一块底部的掩码，遮住一部分
                it.SetActive(true);
                it.transform.position = new Vector2(m_x, start);
                start -= (itemH + 0.1f);
            }
            else it.SetActive(false);
            i++;
        }
        m_flash = false;
    }
    private void Init()
    {
        m_container = new ContainCounter(capacity);//初始化容器类
        Vector2 pos = transform.position;
        m_x = pos.x; m_y = pos.y;
        //pos = transform.localScale;
        m_h = h;
    }
    public ContainCounter GetContainCounter()
    {
        return m_container;
    }
    public void SetStart(bool up)
    {
        if (m_start > 0&&!up)
        {
            m_start--;
        }
        else if (up)
        {
            m_start++;
        }
        ShowItems();
    }
    public void SetFlash()
    {
        m_flash = true;
    }
}
