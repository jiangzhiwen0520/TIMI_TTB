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

    void Start()
    {
        Counttime.GetComponent<Image>().fillAmount = 0f;

        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        for (int i = 0; i <=20; i++)
        {
            if (i < 10)
            {
                countText.text = "0"+i.ToString() + "/20";
                yield return new WaitForSeconds(1);
            }
            else
            {
                countText.text = i.ToString() + "/20";
                yield return new WaitForSeconds(1);
            }
        }
    }
    void Update()
    {
        
        // 按每秒填充的速度增加填充量
        currentFillAmount += fillSpeed * Time.deltaTime;
       

        // 如果超过了目标填充量，则重置为0
        if (currentFillAmount >= targetFillAmount)
        {
            isUpload = true;
            currentFillAmount = 0f;
        }

        // 更新填充量
        Counttime.GetComponent<Image>().fillAmount = currentFillAmount;
    }
}
