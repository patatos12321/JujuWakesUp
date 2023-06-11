using Assets.Scripts.Extensions;
using Assets.Scripts.FightingGear;
using System;
using UnityEngine;

public class GearViewerBehavior : MonoBehaviour
{
    public GearListViewerBehavior GearListViewerBehavior;
    public GameObject SelectedObjectHighLight;
    public IFightingGear Gear { get; private set; }
    private SpriteRenderer SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SelectedObjectHighLight.SetActive(false);
    }

    public void SetGear(IFightingGear gear)
    {
        Gear = gear ?? throw new ArgumentNullException(nameof(gear));
        SpriteRenderer = this.GetComponent<SpriteRenderer>();
        SpriteRenderer.enabled = true;
        SpriteRenderer.sprite = (Resources.Load(gear.SpriteName) as Texture2D).GetGearSprite();
    }

    public void Unselect()
    {
        SelectedObjectHighLight.SetActive(false);
    }

    void OnMouseDown()
    {
        GearListViewerBehavior.SelectGear(Gear);
        SelectedObjectHighLight.SetActive(true);
    }
}
