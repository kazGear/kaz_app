using KazApi.Domain._Const;
using KazApi.Domain._Factory;
using KazApi.Domain._Monster;
using KazApi.Domain._Monster._State;
using KazApi.Domain.DTO;
using Xunit.Abstractions;

namespace UnitTest.KazApi.Domain._Factory
{
    public class StateFactoryTest
    {
        private readonly ITestOutputHelper _output;
        private readonly StateFactory _factory;
        private readonly StateDTO _stateDto;

        public StateFactoryTest(ITestOutputHelper output)
        {
            _output = output;

            var codeEntiteis = new List<CodeDTO>()
            {
                new CodeDTO() { Value = CStateType.NONE.VALUE },
                new CodeDTO() { Value = CStateType.POISON.VALUE },
                new CodeDTO() { Value = CStateType.SLEEP.VALUE },
                new CodeDTO() { Value = CStateType.CHARM.VALUE },
                new CodeDTO() { Value = CStateType.SLOW.VALUE },
                new CodeDTO() { Value = CStateType.POWERUP.VALUE },
                new CodeDTO() { Value = CStateType.DODGEUP.VALUE },
                new CodeDTO() { Value = CStateType.CRITICALUP.VALUE },
                new CodeDTO() { Value = CStateType.AUTOHEAL.VALUE },
                new CodeDTO() { Value = CStateType.DEADLY_POISON.VALUE }
            };
            _factory = new StateFactory(codeEntiteis);
            _stateDto = new StateDTO();
        }

        [Fact(DisplayName = "状態生成：無（状態CDより）")]
        public void UT001_1()
        {
            var state = _factory.Create(CStateType.NONE.VALUE);

            Assert.True(state is None);
        }

        [Fact(DisplayName = "状態生成：毒（状態CDより）")]

        public void UT001_2()
        {
            var state = _factory.Create(CStateType.POISON.VALUE);

            Assert.True(state is Poison);
        }

        [Fact(DisplayName = "状態生成：睡眠（状態CDより）")]
        public void UT001_3()
        {
            var state = _factory.Create(CStateType.SLEEP.VALUE);

            Assert.True(state is Sleep);
        }

        [Fact(DisplayName = "状態生成：魅了（状態CDより）")]
        public void UT001_4()
        {
            var state = _factory.Create(CStateType.CHARM.VALUE);

            Assert.True(state is Charm);
        }

        [Fact(DisplayName = "状態生成：スロー（状態CDより）")]
        public void UT001_5()
        {
            var state = _factory.Create(CStateType.SLOW.VALUE);

            Assert.True(state is Slow);
        }

        [Fact(DisplayName = "状態生成：攻撃力UP（状態CDより）")]
        public void UT001_6()
        {
            var state = _factory.Create(CStateType.POWERUP.VALUE);

            Assert.True(state is PowerUp);
        }

        [Fact(DisplayName = "状態生成：回避力UP（状態CDより）")]
        public void UT001_7()
        {
            var state = _factory.Create(CStateType.DODGEUP.VALUE);

            Assert.True(state is DodgeUp);
        }

        [Fact(DisplayName = "状態生成：会心UP（状態CDより）")]
        public void UT001_8()
        {
            var state = _factory.Create(CStateType.CRITICALUP.VALUE);

            Assert.True(state is CriticalUp);
        }
        [Fact(DisplayName = "状態生成：自働回復（状態CDより）")]

        public void UT001_9()
        {
            var state = _factory.Create(CStateType.AUTOHEAL.VALUE);

            Assert.True(state is AutoHeal);
        }

        [Fact(DisplayName = "状態生成：猛毒（状態CDより）")]
        public void UT001_10()
        {
            var state = _factory.Create(CStateType.DEADLY_POISON.VALUE);

            Assert.True(state is DeadlyPoison);
        }

        [Fact(DisplayName = "無効な状態生成（状態CDより）")]
        public void UT001_11()
        {
            try
            {
                var state = _factory.Create(-1);
                Assert.Fail();
            }
            catch { }
        }

        [Fact(DisplayName = "状態生成：無（状態DTOより）")]
        public void UT002_1()
        {
            var state = _factory.Create(CStateType.NONE.VALUE, _stateDto);

            Assert.True(state is None);
        }

        [Fact(DisplayName = "状態生成：毒（状態DTOより）")]
        public void UT002_2()
        {
            var state = _factory.Create(CStateType.POISON.VALUE, _stateDto);

            Assert.True(state is Poison);

        }

        [Fact(DisplayName = "状態生成：睡眠（状態DTOより）")]
        public void UT002_3()
        {
            var state = _factory.Create(CStateType.SLEEP.VALUE, _stateDto);

            Assert.True(state is Sleep);
        }

        [Fact(DisplayName = "状態生成：魅了（状態DTOより）")]
        public void UT002_4()
        {
            var state = _factory.Create(CStateType.CHARM.VALUE, _stateDto);

            Assert.True(state is Charm);
        }

        [Fact(DisplayName = "状態生成：スロー（状態DTOより）")]
        public void UT002_5()
        {
            var state = _factory.Create(CStateType.SLOW.VALUE, _stateDto);

            Assert.True(state is Slow);
        }

        [Fact(DisplayName = "状態生成：攻撃力UP（状態DTOより）")]
        public void UT002_6()
        {
            var state = _factory.Create(CStateType.POWERUP.VALUE, _stateDto);

            Assert.True(state is PowerUp);
        }

        [Fact(DisplayName = "状態生成：回避力UP（状態DTOより）")]
        public void UT002_7()
        {
            var state = _factory.Create(CStateType.DODGEUP.VALUE, _stateDto);

            Assert.True(state is DodgeUp);
        }

        [Fact(DisplayName = "状態生成：会心UP（状態DTOより）")]
        public void UT002_8()
        {
            var state = _factory.Create(CStateType.CRITICALUP.VALUE, _stateDto);

            Assert.True(state is CriticalUp);
        }

        [Fact(DisplayName = "状態生成：会心UP（状態DTOより）")]
        public void UT002_9()
        {
            var state = _factory.Create(CStateType.AUTOHEAL.VALUE, _stateDto);

            Assert.True(state is AutoHeal);
        }

        [Fact(DisplayName = "状態生成：猛毒（状態DTOより）")]
        public void UT002_10()
        {
            var state = _factory.Create(CStateType.DEADLY_POISON.VALUE, _stateDto);

            Assert.True(state is DeadlyPoison);
        }

        [Fact(DisplayName = "無効な状態生成（状態DTOより）")]
        public void UT002_11()
        {
            try
            {
                var state = _factory.Create(-1, _stateDto);
                Assert.Fail();
            }
            catch { }
        }
    }
}
