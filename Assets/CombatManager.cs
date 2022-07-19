using Assets.Scripts.Fighters;
using UnityEngine;

namespace Assets
{
    public class CombatManager : MonoBehaviour
    {
        public static string SceneToLoadAfterCombat;

        public static IFighter PlayerFighter;
        public static IFighter EnemyFighter;
    }
}
