using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 350;
    public static int Lives;
    public int startLives = 20;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text livesText;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }

    void Update()
    {
        moneyText.text = "$" + Money.ToString();
        livesText.text = Lives.ToString() + " Lives";
    }

    
}
