@echo off

REM リリースビルド
cd c:\repository_kaz_app\kaz_app\KazApp\KazApi.NET
dotnet publish -c Release -o build KazApi.sln

REM モンスタ－オートバトル
start "" "C:\repository_kaz_app\kaz_app\KazApp\AutoBattle\bin\Release\net8.0\AutoBattle.exe"

pause
