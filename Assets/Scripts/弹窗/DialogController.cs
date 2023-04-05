using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Time.timeScale = 0;
    }
   
    public void MouseClick()
    {
        GameObject.Find("–ßπ˚“Ù–ß").GetComponent<AudioContonller>().SetAudio(0);
        GameObject g = GameObject.FindWithTag("Dialog");
        //Debug.Log("MouseClick");
        Time.timeScale = 1;
        Destroy(g);

    }
}
