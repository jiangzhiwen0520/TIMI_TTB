using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogContonller : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject o;
    private UiTimeBar uibar;
    void Start()
    {
        //o = GameObject.FindGameObjectWithTag("ShockDialog");
        //UiTimeBar uibar = o.GetComponent<UiTimeBar>();
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClickCallBack);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickCallBack()
    {
        o = GameObject.FindGameObjectWithTag("ShockDialog");
        UiTimeBar uibar = o.GetComponent<UiTimeBar>();
        if (!uibar.GetStart())
        {
            Debug.Log("É¾³ý³É¹¦");
            Destroy(o);
        }
    }
}
