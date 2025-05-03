using KazApi.Common._Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.KazApi.Common
{
    public class BattleLoggerTest
    {
        public BattleLoggerTest()
        {
            new BattleLogger().DumpMemory(); // ログ初期化
        }

        [Fact(DisplayName = "ログ出力　データ無し")]
        public void UT001()
        {
            var logger = new BattleLogger();

            var log = logger.DumpMemory();

            Assert.True(log.Count() == 0);
        }

        [Fact(DisplayName = "ログ出力　データ有り")]
        public void UT002()
        {
            var logger = new BattleLogger();
            logger.Logging(new BattleMetaData());

            var log = logger.DumpMemory();
            var log2 = logger.DumpMemory();

            Assert.True(log.Count() == 1);
            Assert.True(log2.Count() == 0);
        }

        [Fact(DisplayName = "ログ出力　データ大量")]
        public void UT003()
        {
            var logger = new BattleLogger();
            for (int i = 0; i < 1000; i++)
                logger.Logging(new BattleMetaData());

            var log = logger.DumpMemory();
            var log2 = logger.DumpMemory();

            Assert.True(log.Count() == 1000);
            Assert.True(log2.Count() == 0);
        }

        [Fact(DisplayName = "ログ出力　データダンプ")]
        public void UT004()
        {
            var logger = new BattleLogger();
            for (int i = 0; i < 1000; i++)
                logger.Logging(new BattleMetaData());

            var log = logger.DumpAll();
            var log2 = logger.DumpAll();

            Assert.True(log.Count == 1000);
            Assert.True(log2.Count == 1000);
        }
    }
}
