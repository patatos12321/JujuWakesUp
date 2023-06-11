using Assets;
using Assets.Scripts.Fighters;
using System.Linq;
using UnityEngine;

public class TeamViewerBehavior : MonoBehaviour
{
    public FighterViewerBehavior[] FighterViewers;
    public IFighter SelectedFighter;
    public bool FilterAliveFighters = false;
    void Start()
    {
        ResetFighters();
    }

    private IFighter[] GetFilteredFighters()
    {
        return SharedResources.PlayerFighters.Where(p => p.IsAlive() || !FilterAliveFighters).ToArray();
    }

    public void SelectFighter(IFighter fighter)
    {
        SelectedFighter = fighter;
    }

    public void UnselectFighter()
    {
        SelectedFighter = null;
    }

    public void ResetFighters()
    {
        var filteredFighters = GetFilteredFighters();

        for (int i = 0; i < FighterViewers.Length; i++)
        {
            if (i >= filteredFighters.Length)
            {
                var viewer = FighterViewers[i];
                if (viewer != null)
                    FighterViewers[i].Disable();
            }
            else
            {
                FighterViewers[i].SetFighter(filteredFighters[i]);
            }
        }
    }
}
