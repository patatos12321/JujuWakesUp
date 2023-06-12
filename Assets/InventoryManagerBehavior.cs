using Assets;
using Assets.Scripts.Fighters;
using Assets.Scripts.FightingGear;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryManagerBehavior : MonoBehaviour
{
    public GearListViewerBehavior InventoryGearViewerBehavior;
    public GearListViewerBehavior FighterGearViewerBehavior;
    public TeamViewerBehavior TeamViewerBehavior;
    private IFighter selectedFighter;
    private IFightingGear selectedGear;
    public Text FighterGearText;
    public Text GearDescriptionText;

    // Start is called before the first frame update
    private void Start()
    {
        selectedFighter = TeamViewerBehavior.SelectedFighter;
        FighterGearViewerBehavior.InventoryManagerBehavior = this;
        InventoryGearViewerBehavior.InventoryManagerBehavior = this;
        ShowPlayerGear();
        ShowInventoryGear();
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

    public void SelectGear(IFightingGear fightingGear)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("ITEM\r\nDescription\r\n----------------------");
        if (fightingGear.FightingMove != null)
        {
            sb.AppendLine($"Gives attack \"{fightingGear.FightingMove.MoveName}\"");
            sb.AppendLine($"•Damage : {fightingGear.FightingMove.Damage}");
            sb.AppendLine($"•Duration : {fightingGear.FightingMove.Duration}");
        }
        GearDescriptionText.text = sb.ToString();
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
        FighterGearText.color = Color.green;
    }

    private void ShowInventoryGear()
    {
        InventoryGearViewerBehavior.FightingGears = SharedResources.Inventory.FightingGears;
    }

    private void RefreshAllGear()
    {
        ShowPlayerGear();
        ShowInventoryGear();
    }

    public void AddToInventory()
    {
        var gearToSwitch = FighterGearViewerBehavior.SelectedGear;
        if (gearToSwitch == null)
        {
            return;
        }
        SharedResources.Inventory.FightingGears.Add(gearToSwitch);
        TeamViewerBehavior.SelectedFighter.FightingGears.Remove(gearToSwitch);

        RefreshAllGear();
    }

    public void AddToFighter()
    {

        var gearToSwitch = InventoryGearViewerBehavior.SelectedGear;
        if (gearToSwitch == null)
        {
            return;
        }
        if (TeamViewerBehavior.SelectedFighter.FightingGears.Count >= TeamViewerBehavior.SelectedFighter.MaxInventorySize)
        {
            FighterGearText.color = Color.red;
            return;
        }
        SharedResources.Inventory.FightingGears.Remove(gearToSwitch);
        TeamViewerBehavior.SelectedFighter.FightingGears.Add(gearToSwitch);

        RefreshAllGear();
    }

    public void Return() 
    {
        SceneManager.LoadScene(SharedResources.SceneToLoadAfter);
    }
}
