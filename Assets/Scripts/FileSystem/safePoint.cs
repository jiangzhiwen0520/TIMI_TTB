using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safePoint : MonoBehaviour
{
    public GameObject endDialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (GameObject.Find("��Ҫ�ļ�").GetComponent<KeyFileMove>().isMoving)
        {
            Instantiate(endDialog);
        }
    }
}
