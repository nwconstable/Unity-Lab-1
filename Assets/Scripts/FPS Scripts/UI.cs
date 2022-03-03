using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text enemyCount;

    public void ShowHealthFraction(float fraction) {
        healthBar.fillAmount = fraction;
    }
    
    public void ShowEnemyCount(int count) {
        enemyCount.text = "Monkey Families Destroyed: " + count;
    }
}