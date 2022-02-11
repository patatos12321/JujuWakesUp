using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaisonNicoBehavior : MonoBehaviour
{
    public StoryTextBehavior StoryTextBehavior;
    public Player Player;
    public GameObject Pieuvre;

    // Start is called before the first frame update
    void Start()
    {
        if (!Flags.WakeUpTextDelivered)
        {
            Flags.IsPaused = true;
            StoryTextBehavior.TextToDisplay = "What is happening? Why is there an octupus in my room??";
        }
        else { StoryTextBehavior.gameObject.SetActive(false); }

        if (Flags.FirstEnemyDefeated)
        {
            Destroy(Pieuvre);
        }

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
        }
    }
}
