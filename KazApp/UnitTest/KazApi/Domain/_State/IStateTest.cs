using KazApi.Common._Log;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._State;
using KazApi.Domain.DTO;
using Microsoft.CodeAnalysis.CSharp;
using Mono.TextTemplating;
using UnitTest.Mock;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._State
{
    public class IStateTest
    {
        private readonly ITestOutputHelper _output;
        private readonly IMonster _monster;
        private readonly IState _state;

        public IStateTest(ITestOutputHelper output)
        {
            _output = output;
            _state = MockStatus.AUTOHEAL;
            _monster = new Monster
                (
                    MockMonsterParams.Normal,
                    MockSkillSets.AbsHitOnly,
                    [MockStatus.AUTOHEAL]
                );
            new BattleLogger().DumpMemory(); // ログ初期化
        }

        [Fact(DisplayName = "DTOへ変換")]
        public void UT001()
        {
            IList<StateDTO> dto = 
                (IList<StateDTO>)IState.ModelToDTO([_state]);

            Assert.True(dto[0].Name == _state.Name);
            Assert.True(dto[0].ShortName == _state.ShortName);
            Assert.True(dto[0].StateType == _state.StateType);
            Assert.True(dto[0].CancelRate == _state.CancelRate);
            Assert.True(dto[0].Activate == _state.Activate);
        }
    }
}
