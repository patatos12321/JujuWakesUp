using Assets;
using Assets.Scripts;
using Assets.Scripts.Events;
using Assets.Scripts.Fighters;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventChoiceBehavior : MonoBehaviour
{
    public Button[] Choices;

    private JulieEventChoiceFactory JulieEventChoiceFactory;

    // Start is called before the first frame update
    void Start()
    {
        JulieEventChoiceFactory = new JulieEventChoiceFactory();
        var julieEvents = JulieEventChoiceFactory.GetNextPossibleEvents().ToList();
        
        for (int i = 0; i < Choices.Length; i++)
        {
            if (i >= julieEvents.Count)
            {
                Choices[i].gameObject.SetActive(false);
                continue;
            }
            var btnText = Choices[i].GetComponentInChildren<Text>();
            var julieEvent = julieEvents[i];
            btnText.text = julieEvent.Name + "\r\n\r\n" + julieEvent.Description;
            
            var button = Choices[i].GetComponent<Button>();
            button.onClick.AddListener(() => LoadJulieEvent(julieEvent));
        }
    }

    void LoadJulieEvent(JulieEvent julieEvent)
    {
        Flags.CurrentStep++;
        SharedResources.CurrentEvent = julieEvent;
        SharedResources.SceneToLoadAfter = SceneManager.GetActiveScene().name;

        switch (julieEvent.JulieEventType)
        {
            case JulieEventType.Fight:
                var julieFightEvent = julieEvent as JulieFightEvent;

                var enemyFighter = FighterFactory.GetFighter(julieFightEvent.FighterType);
                SharedResources.EnemyFighter = enemyFighter;

                SceneManager.LoadScene("Combat");
                break;
            case JulieEventType.NewFighter:
                SceneManager.LoadScene("NewFighter");
                break;
            case JulieEventType.Heal:
                SceneManager.LoadScene("Heal");
                break;
            default:
                break;
        }
    }

    public void LoadInventoryManager()
    {
        SharedResources.SceneToLoadAfter = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
