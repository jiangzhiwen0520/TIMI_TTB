using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    private string[] ms;
    private Sprite[] imgs;
    private float[] times;
    // Start is called before the first frame update
    void Start()
    {

        //if (ms.Length != 0)
            
    }
    IEnumerator Count()
    {
        for (int i = 0; i < ms.Length; i++)
        {
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ms[i];
            transform.GetChild(2).GetComponent<Image>().sprite = imgs[i];
            yield return new WaitForSecondsRealtime(times[i]);
            if (i == ms.Length - 1)
                i = -1;
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {

    }
   
    public void MouseClick()
    {
        GameObject.Find("–ßπ˚“Ù–ß").GetComponent<AudioContonller>().SetAudio(0);
        GameObject g = GameObject.FindWithTag("ShockDialog");
        //Debug.Log("MouseClick");
        Time.timeScale = 1;
        Destroy(g);
        //gameObject.transform.parent.parent.gameObject.SetActive(false);
    }
    public void SetMs(string[] s, Sprite[] i,float[] t)
    {
        ms = s;
        imgs = i;
        times = t;
        //transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = ms[0];
        //transform.GetChild(2).GetComponent<Image>().sprite = imgs[0];
        if (gameObject.activeSelf)
        {
            StartCoroutine(Count());
        }
        else
        {
            return;
        }
        Time.timeScale = 0;
    }
}
