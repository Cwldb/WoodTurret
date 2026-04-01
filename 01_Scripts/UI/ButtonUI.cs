using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using DG.Tweening;


public class ButtonUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _selectBtn;
    [SerializeField] private GameObject _txtSize;

    private SettingUI _setting;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
        _setting = FindAnyObjectByType<SettingUI>();
    }

    #region 버튼 선택 표시
    public void EnterUI()
    {
        _selectBtn.SetActive(true);
    }

    public void ExitUI()
    {
        _selectBtn.SetActive(false);
    }
    #endregion

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeText();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DiscardText();
    }

    public void ChangeText()
    {
        _text.color = Color.red;
        _txtSize.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
    }

    public void DiscardText()
    {
        _text.color = Color.white;
        _txtSize.transform.DOScale(Vector3.one, 0.1f);
    }
}
