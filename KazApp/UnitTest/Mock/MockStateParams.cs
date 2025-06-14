using KazApi.Domain.DTO;
using KazApi.Domain._Const;

namespace UnitTest.Mock
{
    public static class MockStateParams
    {
        public static readonly StateDTO NONE =
            new StateDTO()
            { 
                CodeId = "code002",
                Name = "無",
                ShortName = "無",
                StateType = CStateType.NONE.Value, 
                CancelRate = 0,
                Activate = true
            };

        public static readonly StateDTO POISON =
            new StateDTO()
            {
                CodeId = "code002",
                Name = "毒",
                ShortName = "毒",
                StateType = CStateType.POISON.Value,
                CancelRate = 0.25,
                Activate = true
            };

        public static readonly StateDTO SLEEP =
            new StateDTO()
            {
                CodeId = "code002",
                Name = "睡眠",
                ShortName = "眠",
                StateType = CStateType.SLEEP.Value,
                CancelRate = 0.8,
                Activate = true
            };

        public static readonly StateDTO CHARM =
            new StateDTO()
            {
                CodeId = "code002",
                Name = "魅了",
                ShortName = "魅",
                StateType = CStateType.CHARM.Value,
                CancelRate = 1.0,
                Activate = true
            };

        public static readonly StateDTO SLOW =
            new StateDTO()
            {
                CodeId = "code002",
                Name = "スロー",
                ShortName = "遅", 
                StateType = CStateType.SLOW.Value,
                CancelRate = 0.3,
                Activate = true
            };

        public static readonly StateDTO POWERUP =
            new StateDTO()
            {
                CodeId = "code002",
                Name = "攻撃力UP",
                ShortName = "攻↑",
                StateType = CStateType.POWERUP.Value,
                CancelRate = 0.2,
                Activate = true
            };

        public static readonly StateDTO DODGEUP =
            new StateDTO()
            {
                CodeId = "code002",
                Name = "回避力UP",
                ShortName = "回↑",
                StateType = CStateType.DODGEUP.Value,
                CancelRate = 0.2,
                Activate = true
            };

        public static readonly StateDTO CRITICALUP =
            new StateDTO()
            {
                CodeId = "code002",
                Name = "会心UP",
                ShortName = "会UP",
                StateType = CStateType.CRITICALUP.Value,
                CancelRate = 0.35,
                Activate = true
            };

        public static readonly StateDTO AUTOHEAL =
            new StateDTO()
            {
                CodeId = "code002",
                Name = "自動回復",
                ShortName = "癒",
                StateType = CStateType.AUTOHEAL.Value,
                CancelRate = 0.2,
                Activate = true
            };

        public static readonly StateDTO DEADLY_POISON =
            new StateDTO()
            {
                CodeId = "code002",
                Name = "猛毒",
                ShortName = "猛",
                StateType = CStateType.DEADLY_POISON.Value,
                CancelRate = 0.5,
                Activate = true
            };
    }
}
