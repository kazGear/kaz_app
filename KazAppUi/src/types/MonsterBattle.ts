export interface MetaDataDTO {
    TargetMonsterId: string;
    BeforeHp: number;
    ImpactPoint: number;
    StateName: string;
    EnableState: boolean;
    DisableState: boolean;
    SkillId: string;
    Message: string;
    IsStop: boolean;
    AllLoser: boolean;
    ExistWinner: boolean;
    WinnerMonsterId: string;
    WinnerMonsterName: string;
}

export interface MonsterDTO {
    MonsterId: string;
    MonsterName?: string;
    MonsterType: number;
    Hp: number;
    MaxHp: number;
    Attack: number;
    Speed: number;
    Week: number;
    Skills: SkillDTO[];
    Status: StateDTO[];
    StatusName: string[];
    BetScore: number;
    BetRate: number;
}

export interface SkillDTO {
    SkillId: string;
    SkillName: string;
    SkillType: number;
    ElementType: number;
    StateType: number;
    TargetType: number;
    Attack: number;
    Weight: number;
    Critical: bigint;
    Remarks?: string;
}

export interface StateDTO {
    CodeId: string;
    StateType: number;
    Name: string;
    MaxDuration: number;
    DurationCount: number;
}