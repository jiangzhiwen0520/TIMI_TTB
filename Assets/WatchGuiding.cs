using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WatchGuiding : MonoBehaviour
{
    private string[] text = new string[4]{ "我们的云盘遭受了病毒攻击！一批批的垃圾文件被上传到云盘，管理员先生，请务必在云盘空间被占满前将重要文件运送至安全点。（左键继续）",
    "下方是空间条与上传条。您可以看到目前的空间使用情况与下一次垃圾文件上传的进度。（左键继续）",
    "左侧显示了当前关卡的总体文件夹路径。您可以根据它来规划行动。（左键继续）",
    "右侧是您的道具栏，善用道具能解决不少困难。"};
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
