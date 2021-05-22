using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text coinText, livesText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CoinDisplay(int coins)
    {
        coinText.text = "Coins : " + coins;
    }
    public void LivesDisplay(int lives)
    {
        livesText.text = "Lives : " + lives;
    }
}
