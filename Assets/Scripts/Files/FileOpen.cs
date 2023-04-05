using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] names;
    public Sprite[] sprites;
    private int m_num;
    private SpriteRenderer m_sr;
    void Start()
    {
        m_num = names.Length;
        m_sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && m_num > 0)
        {
            Debug.Log("ср╩В");
            GameObject a = GameObject.Find("Container").GetComponent<ItemController>().GetContainCounter().UseItems(0);
            if (a != null)
            {
                a.GetComponent<Key>().Func();
                m_num--;
                m_sr.sprite = sprites[m_num - 1];
                gameObject.name = names[m_num - 1];
                if (m_num == 1)
                {
                    gameObject.tag = "Folder";
                }
            }
        }
    }
}
