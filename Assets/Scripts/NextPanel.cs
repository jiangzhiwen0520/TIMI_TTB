using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

public class NextPanel : MonoBehaviour
{
    public Button btn_nextLevel, btn_quit, btn_Back;
    [Header("下一关按钮跳转的场景")]
    public string nextLevelScene;
    private void Awake()
    {
        btn_nextLevel.onClick.AddListener(() =>
        {
            Scene scene = SceneManager.GetActiveScene();
            nextLevelScene = scene.name;
            string s = nextLevelScene.Substring(0, nextLevelScene.Length - 1);
            string l= nextLevelScene.Substring(nextLevelScene.Length - 1,1);
            nextLevelScene = s + (Convert.ToInt32(l)+1);
            if (nextLevelScene.Equals("Scene_05"))
            {
                nextLevelScene= "Scene_04";
            }
            SceneManager.LoadScene(nextLevelScene);
        });
        btn_quit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("UI");
            Time.timeScale = 1;
        });
        btn_Back.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("UI");
            Time.timeScale = 1;
            gameObject.transform.DOScale(Vector3.zero, 0.3f).OnComplete(() =>
            {
                gameObject.SetActive(false);
                gameObject.transform.DOScale(Vector3.one, 0.1f);
            });
        });
    }
}
