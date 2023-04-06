using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WatchGuiding : MonoBehaviour
{
    private string[] text = new string[4]{ "���ǵ����������˲���������һ�����������ļ����ϴ������̣�����Ա����������������̿ռ䱻ռ��ǰ����Ҫ�ļ���������ȫ�㡣�����������",
    "�·��ǿռ������ϴ����������Կ���Ŀǰ�Ŀռ�ʹ���������һ�������ļ��ϴ��Ľ��ȡ������������",
    "�����ʾ�˵�ǰ�ؿ��������ļ���·���������Ը��������滮�ж��������������",
    "�Ҳ������ĵ����������õ����ܽ���������ѡ�"};
    private int pageNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClock()
    {
        Transform p = transform.parent;
        pageNum++;
        if (pageNum == 3) {
            p.GetChild(2).GetComponent<Image>().color = new Vector4(1, 1, 1,255);
            p.GetChild(2).GetComponent<Button>().enabled = true; 
        }
        else if (pageNum == 4)
        {
            pageNum = 0;
        }
        p.GetChild(1).GetComponent<TextMeshProUGUI>().text = text[pageNum];
        p.GetChild(4).GetComponent<TextMeshProUGUI>().text = pageNum + 1 + "/4";
    }
}
