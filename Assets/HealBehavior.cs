using Assets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealBehavior : MonoBehaviour
{
    public Button healButton;
    // Start is called before the first frame update
    void Start()
    {
        healButton.onClick.AddListener(HealTeam);
    }

    private void HealTeam()
    {
        foreach (var fighter in SharedResources.PlayerFighters)
        {
            fighter.CurrentHp = fighter.MaxHp;
        }
        SceneManager.LoadScene(SharedResources.SceneToLoadAfter);
    }
}
