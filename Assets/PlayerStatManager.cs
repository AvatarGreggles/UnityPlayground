using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatManager : MonoBehaviour
{
    [SerializeField] Text currencyText;

    Player player;

    public static PlayerStatManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        UpdateCurrencyUI();
    }

    public void UpdateCurrencyUI()
    {
        currencyText.text = player.currency.ToString();
    }
}
