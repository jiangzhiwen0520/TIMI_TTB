using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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

        Debug.Log("µã»÷");
    }
}
