using Assets;
using Assets.Scripts.Fighters;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryManagerBehavior : MonoBehaviour
{
    public GearListViewerBehavior InventoryGearViewerBehavior;
    public GearListViewerBehavior FighterGearViewerBehavior;
    public TeamViewerBehavior TeamViewerBehavior;
    private IFighter selectedFighter;
    public Text FighterGearText; 

    // Start is called before the first frame update
    private void Start()
    {
        InventoryGearViewerBehavior.FightingGears = SharedResources.Inventory.FightingGears;
        selectedFighter = TeamViewerBehavior.SelectedFighter;
        ShowPlayerGear();
    }

    // Update is called once per frame
    private void Update()
    {
        if (TeamViewerBehavior.SelectedFighter == null)
            return;

        if (TeamViewerBehavior.SelectedFighter != selectedFighter)
        {
            selectedFighter = TeamViewerBehavior.SelectedFighter;
            ShowPlayerGear();
        }   
    }

    private void ShowPlayerGear()
    {
        if (selectedFighter == null)
        {
            FighterGearViewerBehavior.FightingGears = new List<Assets.Scripts.FightingGear.IFightingGear>();
            FighterGearText.text = "";
            return;
        }

        FighterGearViewerBehavior.FightingGears = selectedFighter.FightingGears;
        FighterGearText.text = $"{selectedFighter.FightingGears.Count}/{selectedFighter.MaxInventorySize}";
    }

    public void AddToInventory()
    {
        var gearToSwitch = FighterGearViewerBehavior.SelectedGear;
        TeamViewerBehavior.SelectedFighter.FightingGears.Remove(gearToSwitch);
        SharedResources.Inventory.FightingGears.Add(gearToSwitch);

        ShowPlayerGear();
    }

    public void AddToFighter()
    {
        var gearToSwitch = InventoryGearViewerBehavior.SelectedGear;
        SharedResources.Inventory.FightingGears.Remove(gearToSwitch);
        TeamViewerBehavior.SelectedFighter.FightingGears.Add(gearToSwitch);

        ShowPlayerGear();
    }

    public void Return() 
    {
        SceneManager.LoadScene(SharedResources.SceneToLoadAfter);
    }
}
