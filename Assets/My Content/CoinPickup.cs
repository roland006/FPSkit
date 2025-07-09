using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class CoinPickup : Pickup
    {
        protected override void OnPicked(PlayerCharacterController player)
        {
            CoinBank bank = player.GetComponent<CoinBank>();
            if (bank)
            {
                bank.AddCoin();
                PlayPickupFeedback();
                Destroy(gameObject);
            }
        }
    }
}
