using Assets.Scripts.FightingMoves;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Fighters
{
    public class FighterPieuvre : IFighter
    {
        public FighterPieuvre()
        {
            CurrentHp = MaxHp;
        }
        public IFightingMove[] KnownMoves;
        public string FighterName => "Pieuvre";
        public int MaxHp => 30;
        public int CurrentHp { get; set; }
        public List<IFightingMove> FightingMoves => KnownMoves.ToList();
        //Todo: Metter le nom de la tune à loader pendant la bataille
        public string BattleSongName => throw new System.NotImplementedException();

        public string SpriteName => "pieuvre_de_chambre";
    }
}