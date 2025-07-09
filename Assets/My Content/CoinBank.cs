using UnityEngine;
using TMPro;

namespace Unity.FPS.Game
{
    public class CoinBank : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI uiText;
        private int coinCount = 0;

        public void AddCoin()
		{
            coinCount += 1;
            
            if(uiText != null)
                uiText.text = $"{coinCount}";
        }
    }
}
