using Assets;
using Assets.Scripts.Events;
using Assets.Scripts.Extensions;
using Assets.Scripts.FightingGear;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RewardBehavior : MonoBehaviour
{
    public Text newFightingGearText;
    public Button AddToInventoryButton;
    public SpriteRenderer NewFightingGearRenderer;

    private IFightingGear newFightingGear;
    private int nbAlienJuice;

    // Start is called before the first frame update
    void Start()
    {
        var currentEvent = SharedResources.CurrentEvent as JulieFightEvent;
        nbAlienJuice = currentEvent.AlienJuiceReward;

        if (nbAlienJuice > 0)
        {
            newFightingGearText.text = $"You gained {currentEvent.AlienJuiceReward} Alien Juice" + (currentEvent.AlienJuiceReward > 1 ? "s" : "");
        }
        else
        {
            newFightingGearText.text = "";
        }

        newFightingGear = currentEvent.GearReward;
        if (newFightingGear != null)
        {
            NewFightingGearRenderer.gameObject.SetActive(true);
            var fightingGearTexture = (Texture2D)Resources.Load(newFightingGear.SpriteName);
            NewFightingGearRenderer.sprite = fightingGearTexture.GetFighterSprite();
        }
        else
        {
            NewFightingGearRenderer.gameObject.SetActive(false);
        }

        var btn = AddToInventoryButton.GetComponent<Button>();
        btn.onClick.AddListener(AddToInventory);
    }

    private void AddToInventory()
    {
        //SharedResources.Inventory.FightingGears.Add(newFightingGear);
        SharedResources.PlayerFighters[0].FightingGears.Add(newFightingGear);
        SharedResources.Inventory.NbAlienJuice += nbAlienJuice;
        SceneManager.LoadScene(SharedResources.SceneToLoadAfter);
    }
}
