using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI SkorUI;
    static public int skor;

    private void Update()
    {
        SkorUI.text = "SKOR: " + skor.ToString();
    }
}
