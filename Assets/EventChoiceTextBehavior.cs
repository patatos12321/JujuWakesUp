using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class EventChoiceTextBehavior : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = $"Step {Flags.CurrentStep}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
