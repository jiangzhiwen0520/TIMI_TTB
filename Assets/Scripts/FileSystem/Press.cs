using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null || GameObject.FindWithTag("ShockDialog") != null)
        {
            return;
        }
        GetComponent<SpriteRenderer>().sprite = sprites[1];
    }
    private void OnMouseUp()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null || GameObject.FindWithTag("ShockDialog") != null)
        {
            return;
        }
        GetComponent<SpriteRenderer>().sprite = sprites[0];
    }
}
