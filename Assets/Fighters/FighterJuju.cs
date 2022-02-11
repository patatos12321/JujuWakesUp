using System.Collections.Generic;
using System.Linq;

public class FighterJuju : IFighter
{
    public FighterJuju()
    {
        CurrentHp = MaxHp;
    }

    public IFightingMove[] KnownMoves;
    public string FighterName => "Juju";

    public int MaxHp => 50;

    public int CurrentHp { get; set; }

    public List<IFightingMove> FightingMoves => KnownMoves.ToList();
}
