using KazApi.Domain._Monster._State;

namespace UnitTest.Mock
{
    public static class MockStatus
    {
        public static readonly IState NONE =
            new None(MockStateParams.NONE);

        public static readonly IState POISON =
            new Poison(MockStateParams.POISON);

        public static readonly IState SLEEP =
            new Sleep(MockStateParams.SLEEP);
         
        public static readonly IState CHARM =
            new Charm(MockStateParams.CHARM);

        public static readonly IState SLOW =
            new Slow(MockStateParams.SLOW);

        public static readonly IState POWERUP =
            new PowerUp(MockStateParams.POWERUP);

        public static readonly IState DODGEUP =
            new DodgeUp(MockStateParams.DODGEUP);

        public static readonly IState CRITICALUP =
            new CriticalUp(MockStateParams.CRITICALUP);

        public static readonly IState AUTOHEAL =
            new AutoHeal(MockStateParams.AUTOHEAL);

        public static readonly IState DEADLY_POISON =
            new DeadlyPoison(MockStateParams.DEADLY_POISON);
    }
}
