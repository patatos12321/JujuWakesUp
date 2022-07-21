using Assets;
using Assets.Scripts.Extensions;
using UnityEngine;

public class TeamViewerBehavior : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderers;
    void Start()
    {
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            if (i >= SharedResources.PlayerFighters.Count)
            {
                spriteRenderers[i].enabled = false;
            }
            else
            {

                spriteRenderers[i].sprite = (Resources.Load(SharedResources.PlayerFighters[i].SpriteName) as Texture2D).GetFighterSprite();
            }
        }
    }
}
