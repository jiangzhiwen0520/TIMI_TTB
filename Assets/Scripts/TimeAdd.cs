using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAdd : MonoBehaviour
{
    [SerializeField] private GameObject Counttime;
    private float targetFillAmount = 1f; // 目标填充量
    private float currentFillAmount = 0f; // 当前填充量
    private float fillSpeed = 0.05f; // 每秒填充的速度

    void Start()
    {
        Counttime.GetComponent<Image>().fillAmount = 0f;
    }

    void Update()
    {
        // 按每秒填充的速度增加填充量
        currentFillAmount += fillSpeed * Time.deltaTime;

        // 如果超过了目标填充量，则重置为0
        if (currentFillAmount >= targetFillAmount)
        {
            currentFillAmount = 0f;
        }

        // 更新填充量
        Counttime.GetComponent<Image>().fillAmount = currentFillAmount;
    }
}
