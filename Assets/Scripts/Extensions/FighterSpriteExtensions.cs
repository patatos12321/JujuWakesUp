using System;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class FighterSpriteExtensions
    {
        public static Sprite GetFighterSprite(this Texture2D fighterTexture)
        {
            return Sprite.Create(fighterTexture
            , new Rect(new Vector2(0, 0)
            , new Vector2(fighterTexture.width, fighterTexture.height))
            , new Vector2(0.5f, 0.5f)
            , Math.Max(16, fighterTexture.width));
        }
    }
}
