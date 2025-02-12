using Project.Logic.Grid.Data;

namespace Project.Logic.Grid
{
    public interface ITileGridMap
    {
        void Initialize();
        Tile[][] Tiles { get; }
        Tile GetRandomEmptyTile(int row);
        Tile GetTile(TileID tileID);
        Tile GetNextTile(Tile currentTile, DirectionType directionType);
        bool IsCrossedLastRow();
    }
}