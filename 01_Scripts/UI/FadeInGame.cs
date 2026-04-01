using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeInGame : MonoSingleton<FadeInGame>
{
    public bool isFade = false;

    private Image _fadeImage;
    private bool isUse;

    private void Awake()
    {
        if(gameObject.name != "Test")
            _fadeImage = GetComponent<Image>();
    }

    private void Start()
    {
        if (gameObject.name != "Test")
            _fadeImage.enabled = true;
    }

    private void Update()
    {
        if (gameObject.name != "Test")
        {
            if (!isUse)
            {
                LoadGameScene();
                isUse = true;
            }
        }
    }

    private void LoadGameScene()
    {
        isFade = true;
        Debug.Log("dd");
        _fadeImage.DOFade(0, 1f).OnComplete(() => 
        {
            _fadeImage.enabled = false;
            isFade = false;
        });
    }
}
