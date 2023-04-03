using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseDialog;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        Vector3 a = new Vector3(0, 0.1f, 0);
        transform.position += a;
    }
    private void OnMouseExit()
    {
        Vector3 a = new Vector3(0, 0.1f, 0);
        transform.position -= a;
    }
    private void OnMouseDown()
    {
        Time.timeScale = 0;
        if (GameObject.FindWithTag("PauseDialog")==null)
        {
            Instantiate(pauseDialog);
        }
    }
}
