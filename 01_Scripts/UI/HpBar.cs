using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Image _hpBar;
    [SerializeField] private Image _hpBarBg;
    [SerializeField] private TMP_Text _hpText;

    private float _maxHp;
    private float _currentHp;

    [SerializeField] private float delayTime = 0.5f;

    private void Awake()
    {

    }

    private void Start()
    {
        _maxHp = 100;
        _currentHp = _maxHp;
        _hpBar.fillAmount = 100 / 100;
        _hpBarBg.fillAmount = _hpBar.fillAmount;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _currentHp -= 5;
            SetHpBar(_maxHp, _currentHp);
        }
    }

    public void SetHpBar(float maxHealth, float currentHealth)
    {
        _currentHp = currentHealth;
        _maxHp = maxHealth;
        _hpBar.fillAmount = _currentHp / _maxHp;
        transform.DOScale(new Vector3(5.2f, 5.2f, 5.2f), 0.1f).OnComplete(() => transform.DOScale(new Vector3(5,5,5), 0.1f));
        _hpText.text = $"{(int)_currentHp} / {(int)_maxHp}";
        StartCoroutine(HpDelay());
    }

    private IEnumerator HpDelay()
    {
        yield return new WaitForSeconds(delayTime);
        _hpBarBg.DOFillAmount(_hpBar.fillAmount, 0.4f)
            .SetEase(Ease.InCubic);
    }
}
