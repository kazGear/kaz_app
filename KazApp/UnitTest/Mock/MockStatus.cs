using KazApi.Domain._Monster._Skill;
using KazApi.Domain._Monster._State;
using KazApi.Domain._Monster;
using KazApi.Domain.DTO;
using KazApi.Domain._Const;

namespace UnitTest.Mock
{
    public static class MockStatus
    {
        public static readonly IState NONE =
            new None("無", "無", CStateType.NONE.VALUE, 0);

        public static readonly IState POISON =
            new Poison("毒", "毒", CStateType.POISON.VALUE, 0.25);

        public static readonly IState SLEEP =
            new Sleep("睡眠", "眠", CStateType.SLEEP.VALUE, 0.8);

        public static readonly IState CHARM =
            new Charm("魅了", "魅", CStateType.CHARM.VALUE, 1.0);

        public static readonly IState SLOW =
            new Slow("スロー", "遅", CStateType.SLOW.VALUE, 0.3);

        public static readonly IState POWERUP =
            new PowerUp("攻撃力UP", "攻↑", CStateType.POWERUP.VALUE, 0.2);

        public static readonly IState DODGEUP =
            new DodgeUp("回避力UP", "回↑", CStateType.DODGEUP.VALUE, 0.2);

        public static readonly IState CRITICALUP =
            new CriticalUp("会心UP", "会UP", CStateType.CRITICALUP.VALUE, 0.35);

        public static readonly IState AUTOHEAL =
            new AutoHeal("自動回復", "癒", CStateType.AUTOHEAL.VALUE, 0.2);

        public static readonly IState DEADLY_POISON =
            new DeadlyPoison("猛毒", "猛", CStateType.DEADLY_POISON.VALUE, 0.5);
    }
}
