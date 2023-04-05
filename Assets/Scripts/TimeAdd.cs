using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeAdd : MonoBehaviour
{
    [SerializeField] private GameObject Counttime;
    private float targetFillAmount = 1f; // 目标填充量
    private float currentFillAmount = 0f; // 当前填充量
    private float fillSpeed = 0.05f; // 每秒填充的速度

    public bool isUpload = false;

    public TextMeshProUGUI countText;


    //zf添加停止上传脚本
    private bool stopUpload=false;
    [SerializeField] private GameObject iceBar;
    public float m_time=5;
    private float m_deltaTime;
    void Start()
    {
        Counttime.GetComponent<Image>().fillAmount = 0f;

        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        for (int i = 0; i <=20; i++)
        {
            if (stopUpload)
            {
                yield return new WaitForSeconds(m_deltaTime);
            }
            if (i < 10)
            {
                countText.text = "0"+i.ToString() + "/20";
                yield return new WaitForSeconds(1);
            }
            else
            {
                countText.text = i.ToString() + "/20";
                if(i!=20)
                    yield return new WaitForSeconds(1);
            }
        }
    }
    void Update()
    {
        if (!stopUpload)
        {
            //Debug.Log("更新");

            // 按每秒填充的速度增加填充量
            currentFillAmount += fillSpeed * Time.deltaTime;


            // 如果超过了目标填充量，则重置为0
            if (currentFillAmount >= targetFillAmount)
            {
                StartCoroutine(Count());
                isUpload = true;
                GameObject.Find("效果音效").GetComponent<AudioContonller>().SetAudio(1);
                currentFillAmount = 0f;
            }

            // 更新填充量
            Counttime.GetComponent<Image>().fillAmount = currentFillAmount;
        }
        else
        {
            //Debug.Log("暂停更新");
            m_deltaTime -= Time.deltaTime;
            if (m_deltaTime <= 0)
            {
                stopUpload = false;
                iceBar.SetActive(false);
                //取消冰图层

            }
        }
    }
    public void SetStopUpload()
    {
        m_deltaTime = m_time;
        stopUpload = true;
        iceBar.SetActive(true);
        //冻结进度条
    }
}
