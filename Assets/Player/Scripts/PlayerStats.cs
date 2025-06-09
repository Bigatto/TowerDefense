using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 350;
    [SerializeField] private TMP_Text moneyText;

    void Start()
    {
        Money = startMoney;
    }

    void Update()
    {
        moneyText.text = "$"+Money.ToString();
    }
}
