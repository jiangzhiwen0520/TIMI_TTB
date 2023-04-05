using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseDialog;
    public Sprite[] sprites;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnMouseEnter()
    {
        Vector3 a = new Vector3(0, 0.1f, 0);
        transform.position += a;
    }
    private void OnMouseExit()
    {
        Vector3 a = new Vector3(0, 0.1f, 0);
        transform.position -= a;
    }*/
    private void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null)
        {
            return;
        }
        GameObject.Find("–ßπ˚“Ù–ß").GetComponent<AudioContonller>().SetAudio(0);
        GetComponent<SpriteRenderer>().sprite = sprites[1];
        Time.timeScale = 0;
        if (GameObject.FindWithTag("PauseDialog")==null)
        {
            Instantiate(pauseDialog);
        }
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[0];
        if (GameObject.FindGameObjectWithTag("PauseDialog") != null)
        {
            return;
        }
    }
}
