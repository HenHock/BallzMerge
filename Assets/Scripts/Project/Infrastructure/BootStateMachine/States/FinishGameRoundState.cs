using Project.Infrastructure.BootStateMachine.States.Interfaces;
using Project.Logic.Block;
using Project.Logic.Grid;
using Project.Logic.Grid.Data;
using Project.Logic.LevelFactory;
using UnityEditorInternal;

namespace Project.Infrastructure.BootStateMachine.States
{
    public class FinishGameRoundState : IState
    {
        private readonly LevelFactory _levelFactory;
        private readonly ITileGridMap _tileGridMap;
        private readonly IGameStateMachine _stateMachine;

        public FinishGameRoundState(IGameStateMachine stateMachine, LevelFactory levelFactory, ITileGridMap tileGridMap)
        {
            _stateMachine = stateMachine;
            _levelFactory = levelFactory;
            _tileGridMap = tileGridMap;
        }

        public void Enter()
        {
            MoveBlocksDown();
            
            if (_tileGridMap.IsCrossedLastRow())
                _stateMachine.Enter<GameOverState>();
            else Next();
        }

        private void MoveBlocksDown()
        {
            foreach (BlockMovement block in _levelFactory.Blocks)
            {
                Tile currentTile = _tileGridMap.GetTile(block.TileID);
                Tile nextTile = _tileGridMap.GetNextTile(currentTile, DirectionType.Down);

                if (nextTile != null)
                {
                    currentTile.SetEmpty();
                    block.Move(nextTile);
                    nextTile.SetBusy();
                }
            }
        }

        public void Next() => _stateMachine.Enter<StartGameRoundState>();
    }
}