using Project.Logic.Grid;
using Project.Logic.Block;
using Project.Infrastructure.BootStateMachine.States.Interfaces;
using Project.Logic.BlockProvider;
using Project.Logic.Grid.Data;

namespace Project.Infrastructure.BootStateMachine.States
{
    public class FinishGameRoundState : IState
    {
        private readonly IBlocksProvider _blocksProvider;
        private readonly ITileGridMap _tileGridMap;
        private readonly IGameStateMachine _stateMachine;

        public FinishGameRoundState(IGameStateMachine stateMachine, IBlocksProvider blocksProvider, ITileGridMap tileGridMap)
        {
            _stateMachine = stateMachine;
            _blocksProvider = blocksProvider;
            _tileGridMap = tileGridMap;
        }

        public void Enter()
        {
            MoveAllBlocksDown();

            if (_tileGridMap.IsCrossedLastRow())
                _stateMachine.Enter<GameOverState>();
            else Next();
        }

        public void Next() => _stateMachine.Enter<StartGameRoundState>();

        private void MoveAllBlocksDown()
        {
            foreach (BlockBehavior block in _blocksProvider.Blocks) 
                block.BlockMovement.MoveTo(DirectionType.Down);
        }
    }
}