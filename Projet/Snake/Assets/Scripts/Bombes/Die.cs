using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bombes
{
    public class Die : Bombe
    {
        internal static void AllDie(List<Bombe> bombes)
        {
            try
            {
                foreach (var bombe in bombes)
                {
                    Destroy(bombe.gameObject);
                    bombes.Remove(bombe);
                }
            }
            catch (Exception)
            {
                AllDie(bombes);
            }
        }
    }
}