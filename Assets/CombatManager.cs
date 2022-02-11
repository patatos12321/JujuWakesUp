using UnityEngine;

namespace Assets
{
    public class CombatManager : MonoBehaviour
    {
        public static string SceneToLoadAfterCombat;
        public static Vector3 playerPosition;

        public static Sprite PlayerSprite;
        public static Sprite EnemySprite;
        public static IFighter PlayerFighter;
        public static IFighter EnemyFighter;
    }
}
