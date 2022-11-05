using Assets.Scripts.Extensions;
using Assets.Scripts.Fighters;
using System;
using UnityEngine;

public class FighterViewerBehavior : MonoBehaviour
{
    public TeamViewerBehavior TeamViewerBehavior;
    public HealthBarBehaviour HealthBar;
    
    private IFighter Fighter;
    private SpriteRenderer SpriteRenderer;

    private void Start()
    {
        SpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        TeamViewerBehavior.SelectFighter(Fighter);
    }

    public void SetFighter(IFighter fighter)
    {
        Fighter = fighter ?? throw new ArgumentNullException(nameof(fighter));
        HealthBar.gameObject.SetActive(true);
        SpriteRenderer.enabled = true;
        SpriteRenderer.sprite = (Resources.Load(Fighter.SpriteName) as Texture2D).GetFighterSprite();

        HealthBar.MaxHealth = Fighter.MaxHp;
        HealthBar.CurrentHealth = Fighter.CurrentHp;
    }
    public void Disable()
    {
        SpriteRenderer.enabled = false;
        HealthBar.gameObject.SetActive(false);
    }
}
