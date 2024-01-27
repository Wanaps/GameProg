using Serpent;
using UnityEngine;

namespace Spawners
{
    public class SpawnPlayer : MonoBehaviour
    {
        public GameObject player;
        public GameObject corps;

        void Awake()
        {
            Instantiate(player);
            Player.Score = 0;
        }
    }
}