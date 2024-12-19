export interface EditMonsterDTO {
    MonsterId: string;
    MonsterName: string;
    MonsterType: number;
    MonsterTypeName: string;
    Hp: number;
    Attack: number;
    Speed: number;
    Week: number;
    WeekName: string;
    // 変更後パラメータ
    AfterName: string | undefined;
    AfterHp: number | undefined;
    AfterAttack: number | undefined;
    AfterSpeed: number | undefined;
    AfterWeek: number |  undefined;
    IsChanged: boolean;
}