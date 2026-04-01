using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WoodCurrency : MonoBehaviour
{
    private Image _woodIcon;
    private TMP_Text _woodText;

    private void Awake()
    {
        _woodIcon = transform.Find("TreeIcon").GetComponent<Image>();
        _woodText = transform.Find("TreeCountText").GetComponent<TMP_Text>();
        
        GameManager.Instance.woodCurrency.OnValueChanged += HandleChangeWoodEffectEvent;
        _woodText.text = $"{GameManager.Instance.woodCurrency.Value}";
    }
    
    private void HandleChangeWoodEffectEvent(int prev, int next)
    {
        _woodText.text = next.ToString();
        _woodText.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f),0.1f).OnComplete(() => _woodText.transform.DOScale(Vector3.one,0.1f));
    }
}
