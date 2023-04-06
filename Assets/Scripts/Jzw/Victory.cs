using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Victory : MonoBehaviour
{
    public Button btn_quit;
    //[Header("Ê¤Àû")]
    //public string restartScene;
    private void Awake()
    {
        btn_quit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("UI");
            Time.timeScale = 1;
        });


    }
}
