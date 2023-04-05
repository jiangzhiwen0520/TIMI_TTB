using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContonller : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] audios;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAudio(int i)
    {
        if (i < audios.Length)
        {
            GetComponent<AudioSource>().PlayOneShot(audios[i]);
        }
    }
}
