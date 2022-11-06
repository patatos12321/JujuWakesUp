using Assets.Scripts.Events;
using Assets.Scripts.Fighters;
using Assets.Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class SharedResources : MonoBehaviour
    {
        public static string SceneToLoadAfter;

        public static List<IFighter> PlayerFighters = new List<IFighter>();
        public static IFighter EnemyFighter;

        public static JulieEvent CurrentEvent;
        public static Inventory Inventory;
    }
}
