using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour
{
    private Image _fadeImage;

    private void Awake()
    {
        _fadeImage = GetComponent<Image>();
    }

    private void Start()
    {
        _fadeImage.enabled = false;
    }

    public void LoadScene()
    {
        _fadeImage.enabled = true;
        _fadeImage.DOFade(1, 1f).OnComplete(() => SceneManager.LoadScene("GameScene"));
    }

}
