using Assets;
using Assets.Scripts.Events;
using Assets.Scripts.Extensions;
using Assets.Scripts.Fighters;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewFighterBehavior : MonoBehaviour
{
    public SpriteRenderer NewFighterRenderer;
    public Text NewFighterText;
    public Button AddToTeamButton;

    private IFighter newFighter;
    // Start is called before the first frame update
    void Start()
    {
        var currentEvent = SharedResources.CurrentEvent as JulieNewFighterEvent;
        newFighter = currentEvent.NewFighter;

        var playerTexture = (Texture2D)Resources.Load(newFighter.SpriteName);
        
        NewFighterRenderer.sprite = playerTexture.GetFighterSprite();
        NewFighterText.text = $"{newFighter.FighterName} wants to join the team!";

        Button btn = AddToTeamButton.GetComponent<Button>();
        btn.onClick.AddListener(AddToTeam);
    }

    void AddToTeam()
    {
        SharedResources.PlayerFighters.Add(newFighter);
        SceneManager.LoadScene(SharedResources.SceneToLoadAfter);
    }
}
