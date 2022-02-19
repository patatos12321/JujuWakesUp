using UnityEngine;
using UnityEngine.UI;

public class StoryTextBehavior : MonoBehaviour
{
    public bool Clicked = false;
    public string[] TextsToDisplay;
    public int CurrentTextIndex = 0;

    public Button Button;
    public Text Text;

    // Start is called before the first frame update
    void Start()
    {
        Button.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (TextsToDisplay == null || TextsToDisplay.Length == 0)
        {
            return;
        }
        Text.text = TextsToDisplay[CurrentTextIndex];
    }

    void TaskOnClick()
    {
        if (CurrentTextIndex == TextsToDisplay.Length - 1)
        {
            Clicked = true;
        }
        else
        {
            CurrentTextIndex++;
        }
    }

    public void SetDisplayText(string text)
    {
        TextsToDisplay = new[] { text };
    }

    public void SetDisplayText(string[] texts)
    {
        TextsToDisplay = texts;
    }
}
