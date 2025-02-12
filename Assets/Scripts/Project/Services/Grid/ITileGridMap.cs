using Project.Services.Grid.Data;

namespace Project.Services.Grid
{
    public interface ITileGridMap
    {
        void Initialize();
        Tile[][] Tiles { get; }
        Tile GetRandomEmptyTile(int row);
        Tile GetTile(TileID tileID);
        Tile GetNextTile(TileID currentTile, DirectionType directionType);
        bool IsCrossedLastRow();
        Tile[] GetTilesAround(TileID tileID);
    }
}