using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class Lava : MonoBehaviour
    {
        [SerializeField] private float damagePerSecond = 1f;
        [SerializeField] private float damagePeriod = 0.5f;

        private List<Damageable> tagets = new List<Damageable>();
		private float timer = 0.5f;

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent<Damageable>(out Damageable target))
				tagets.Add(target);
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.TryGetComponent<Damageable>(out Damageable target))
				tagets.Remove(target);
		}

		private void Update()
		{
			timer -= Time.deltaTime;
			if(timer <= 0)
			{
				timer = damagePeriod;

				foreach (Damageable victim in tagets)
				{
					if (victim == null)
					{
						tagets.Remove(victim);
						timer = 0f;
						break;
					}

					victim.InflictDamage(damagePerSecond * damagePeriod, false, this.gameObject);
				}
			}
		}
	}
}