using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class CombatManager : MonoBehaviour
    {
        public static Sprite PlayerSprite;
        public static Sprite EnemySprite;
        public static IFighter PlayerFighter;
        public static IFighter EnemyFighter;
    }
}
