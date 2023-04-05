using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FolderDialog : MonoBehaviour
{
    public string[] message;
    public Sprite[] picture;
    public float[] showTime;
    public GameObject dialog;
    public bool isFirst=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        if (isFirst)
        {
            GameObject a=Instantiate(dialog);
            a.transform.GetChild(0).GetComponent<DialogController>().SetMs(message, picture,showTime);
            
            isFirst = false;
        }
    }
}
