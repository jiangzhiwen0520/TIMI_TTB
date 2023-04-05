using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBgm : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip clips;
    private bool change;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if ((!GetComponent<AudioSource>().isPlaying|| GetComponent<AudioSource>().volume<=0)&& change) {
            GetComponent<AudioSource>().clip = clips;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().volume += Time.deltaTime*0.5f;
            if (GetComponent<AudioSource>().volume == 1) change = false;
        }
        else if (change)
        {
            if (GetComponent<AudioSource>().clip == clips)
            {
                GetComponent<AudioSource>().volume += Time.deltaTime * 0.5f;
                if (GetComponent<AudioSource>().volume == 1) change = false;
            }
            else
            {
                GetComponent<AudioSource>().volume -= Time.deltaTime * 0.5f;
            }
        }
        
    }
    public void SetClip()
    {
        if (GetComponent<AudioSource>().clip == clips) return;
        GetComponent<AudioSource>().loop=false;
        change = true;
    }
}
