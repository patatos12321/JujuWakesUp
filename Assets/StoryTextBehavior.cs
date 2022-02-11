using UnityEngine;
using UnityEngine.UI;

public class StoryTextBehavior : MonoBehaviour
{
    public bool Clicked = false;
    public string TextToDisplay;
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
        Text.text = TextToDisplay;
    }

    void TaskOnClick()
    {
        Clicked = true;
    }
}
