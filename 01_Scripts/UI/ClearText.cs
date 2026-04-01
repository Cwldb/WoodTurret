using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        text.text = $"ÃÑ ¾òÀº ³ª¹« : {GameManager.Instance.TotalWoodCount}";
    }
}
