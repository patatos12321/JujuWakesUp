using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehaviour : MonoBehaviour
{
    public GameObject FilledHealthBar;
    public float MaxHealth;
    public float CurrentHealth;

    private Vector2 InitialScale;
    private Vector2 InitialPosition;

    void Start()
    {
        InitialScale = FilledHealthBar.transform.localScale;
        InitialPosition = FilledHealthBar.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var xScale = InitialScale.x * CurrentHealth / MaxHealth;
        FilledHealthBar.transform.localScale = new Vector3(xScale, FilledHealthBar.transform.localScale.y, FilledHealthBar.transform.localScale.z);

    }
}
