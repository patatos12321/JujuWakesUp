using Assets.Scripts.FightingGear;
using System.Collections.Generic;
using UnityEngine;

public class GearListViewerBehavior : MonoBehaviour
{
    //Visual Stuff
    public int NbColumns = 10;
    public int NbRows = 2;
    public float Padding = 0.01f;
    public int Width = 10;
    public int Height = 2;
    public GearViewerBehavior SelectableGearBehaviorPrefab;
    //Functional Stuff
    public IFightingGear SelectedGear { get; private set; }
    public List<IFightingGear> FightingGears
    {
        get { return _fightingGears; }
        set
        {
            CleanupViewers();
            _fightingGears = value;
            DrawGear();
        }
    }
    //Private stuff
    private List<IFightingGear> _fightingGears;
    private List<GearViewerBehavior> _gearViewers = new List<GearViewerBehavior>();
    private float GearWidth => (Width / NbColumns) - Padding;
    private float GearHeight => (Height / NbRows) - Padding;
    private Vector2 GearSize => new Vector2(GearWidth, GearHeight);
    private void Start()
    {
        
    }

    public void SelectGear(IFightingGear selectedGear)
    {
        SelectedGear = selectedGear;
        foreach (var gearViewer in _gearViewers)
        {
            if (gearViewer.Gear != selectedGear)
                gearViewer.Unselect();
        }
    }

    private void DrawGear()
    {
        if (_fightingGears == null)
            return;

        for (int index = 0; index < _fightingGears.Count; index++)
        {
            var gear = _fightingGears[index];
            var gearViewer = Instantiate(SelectableGearBehaviorPrefab);
            gearViewer.GearListViewerBehavior = this;
            gearViewer.transform.parent = this.transform;
            int row = index / NbColumns;
            gearViewer.transform.localPosition = new Vector3((index % NbColumns) * (GearWidth + Padding), row * (GearHeight + Padding));
            gearViewer.transform.localScale = GearSize;
            gearViewer.SetGear(gear);
            _gearViewers.Add(gearViewer);
        }
    }

    private void CleanupViewers()
    {
        foreach (var gearViewer in _gearViewers)
            DestroyImmediate(gearViewer.gameObject);
    }

    private void OnDrawGizmos()
    {
        var cubeHalfWidth = GearWidth / 2;
        var cubeHalfHeight = GearHeight / 2;
        var cubeSize = new Vector3(GearWidth, GearHeight);

        float currentYLocation = 0;
        for (int row = 0; row < NbRows; row++)
        {
            float currentXLocation = 0;
            for (int column = 0; column < NbColumns; column++)
            {
                var cubeCenter = new Vector3(transform.position.x + currentXLocation + cubeHalfWidth, transform.position.y + currentYLocation - cubeHalfHeight);
                Gizmos.DrawWireCube(cubeCenter, cubeSize);

                currentXLocation += GearWidth + Padding;
            }
            currentYLocation += GearHeight + Padding;
        }
    }
}
