using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpContorller : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isUp=true;
    private ItemController m_ic;
    void Start()
    {
        m_ic = GameObject.Find("Container").GetComponent<ItemController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        m_ic.SetStart(!isUp);
    }
}
