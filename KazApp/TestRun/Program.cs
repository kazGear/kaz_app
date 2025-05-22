using CSLib.Lib;
using KazApi.Common._Filter;
using TestRun;

// Start=======================
Console.WriteLine(">>> test start.");
UTimeMeasure.Start();
// =================================

var monsterBattle = new MonsterBattle();
monsterBattle.Run();

// End ========================
UTimeMeasure.Stop();
Console.WriteLine(">>> test end...");
// ============================

