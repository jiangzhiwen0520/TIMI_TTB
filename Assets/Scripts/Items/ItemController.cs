using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private ContainCounter m_container;
    [SerializeField]
    private int capacity=0;

    private float m_w, m_h, m_x, m_y;//容器大小
    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowItems()
    {
        ArrayList items =m_container.GetItems();
        float h=0;
        if (items.Count != 0)
        {
            //w = ((GameObject)items[0]).transform.localScale.x;
            h = ((GameObject)items[0]).transform.localScale.x;
        }
        float start = m_y + m_h / 2.0f-h/2 - 0.1f;
        float end = m_y - m_h / 2.0f;
        foreach (GameObject it in items)
        {
            if (start < end) break;//需要一块底部的掩码，遮住一部分
            it.SetActive(true);
            it.transform.position=new Vector2(m_x,start);
            start -= (h + 0.1f);
        }
    }
    private void Init()
    {
        m_container = new ContainCounter(capacity);//初始化容器类
        Vector2 pos = transform.position;
        m_x = pos.x; m_y = pos.y;
        pos = transform.localScale;
        m_w = pos.x; m_h = pos.y;
    }
    public ContainCounter GetContainCounter()
    {
        return m_container;
    }
}
