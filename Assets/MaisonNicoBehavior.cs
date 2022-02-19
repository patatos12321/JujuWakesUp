using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaisonNicoBehavior : MonoBehaviour
{
    public StoryTextBehavior StoryTextBehavior;
    public Player Player;
    public GameObject Pieuvre;
    public GameObject Peanut;

    // Start is called before the first frame update
    void Start()
    {
        if (!Flags.WakeUpTextDelivered)
        {
            Flags.IsPaused = true;
            StoryTextBehavior.SetDisplayText("What is happening? Why is there an octupus in my room??");
            Destroy(Peanut);
        }
        else if (Flags.FirstEnemyDefeated)
        {
            Destroy(Pieuvre);
            StoryTextBehavior.SetDisplayText(new string[] { "Oh my god! Peanut! are you Okay?", "Ouaf!", "Stay with me! I'm too scared.", "Ouaf Ouaf!", "*Peanut joins your team*" });
        }
        else { StoryTextBehavior.gameObject.SetActive(false); }

        if (CombatManager.playerPosition != new Vector3())
        {
            Player.transform.position = CombatManager.playerPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StoryTextBehavior.Clicked)
        {
            StoryTextBehavior.Clicked = false;
            StoryTextBehavior.gameObject.SetActive(false);
            Flags.IsPaused = false;
            Flags.WakeUpTextDelivered = true;
            
            if (Flags.FirstEnemyDefeated)
            {
                Destroy(Peanut);
            }
        }
    }
}
