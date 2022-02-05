using UnityEngine;

public class Pieuvre : MonoBehaviour
{
    public AudioSource CombatStartSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CombatStartSound.Play();
    }
}
