using CSLib.Lib;

/*
 print util
 */
void Print(object o) => Console.WriteLine(o);
void PrintAll<T>(IEnumerable<T> os)
{
    foreach (T o in os) Console.WriteLine(o!.ToString());
}

/************************************************************
 * 
 * 汎用テストエリア
 * 
 ************************************************************/

bool doTest = true; // テスト稼働可否
if (!doTest) return;

// testtStart=======================
Print(">>> test info.");
UTimeMeasure.Start();
// =================================

// 復号
string result = UAes.AesDecrypt("oBE87gjbotORkFKy+qEjbQ==");
Console.WriteLine(result);
Console.WriteLine(result.Length);

string result2 = UAes.AesDecrypt("44oSRDDfZKdXGPimoJgZsA==");
Console.WriteLine(result2);
Console.WriteLine(result2.Length);

Print("確立の検証");
int hit = 0;
int rate = 10;

double hitDouble = 0.0;
double rateDouble = 0.10;

double loop = 1000000.0;
for (int i = 0; i < loop; i++)
{
    int randInt = new URandom().RandomInt(0, 100);
    if (randInt < rate) hit++;

    double randDouble = new URandom().RandomDouble(0.0, 1.0);
    if (randDouble < rateDouble) hitDouble += 1.0;
}
Print($"hit(int): {hit}, rate: {(hit / loop) * 100}%");
Print($"hit(double): {hitDouble}, rate: {(hitDouble / loop) * 100}%");







// ============================
UTimeMeasure.Stop();
Print(">>> test end...");
// testEnd======================

