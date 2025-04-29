using System.Text.Json.Serialization;

namespace KazApi.Domain.DTO
{
    /// <summary>
    /// モンスターパラメータクラス
    /// </summary>
    public class EditMonsterDTO
    {
        [JsonPropertyName("MonsterId")]
        public string MonsterId { get; set; }
        [JsonPropertyName("MonsterName")]
        public string MonsterName { get; set; }
        [JsonPropertyName("MonsterType")]
        public int MonsterType { get; set; }
        [JsonPropertyName("MonsterTypeName")]
        public string MonsterTypeName { get; set; }
        [JsonPropertyName("Hp")]
        public int Hp { get; set; }
        [JsonPropertyName("Attack")]
        public int Attack { get; set; }
        [JsonPropertyName("Speed")]
        public int Speed { get; set; }
        [JsonPropertyName("Week")]
        public int Week { get; set; }
        [JsonPropertyName("WeekName")]
        public string WeekName { get; set; }
        [JsonPropertyName("IsDisabled")]
        public string IsDisabled { get; set; }

        // 変更後パラメータ

        [JsonPropertyName("AfterName")]
        public string? AfterName { get; set; }
        [JsonPropertyName("AfterHp")]
        public int? AfterHp { get; set; }
        [JsonPropertyName("AfterAttack")]
        public int? AfterAttack { get; set; }
        [JsonPropertyName("AfterSpeed")]
        public int? AfterSpeed { get; set; }
        [JsonPropertyName("AfterWeek")]
        public int? AfterWeek { get; set; }
        [JsonPropertyName("IsChanged")]
        public bool? IsChanged { get; set; }
    }
}
