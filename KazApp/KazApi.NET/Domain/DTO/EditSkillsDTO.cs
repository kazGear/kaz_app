using System.Text.Json.Serialization;

namespace KazApi.Domain.DTO
{
    public class EditSkillsDTO
    {
        // モンスターステータス

        [JsonPropertyName("ItemId")]
        public string ItemId { get; set; }
    
        [JsonPropertyName("MonsterId")]
        public string MonsterId { get; set; }
        
        [JsonPropertyName("MonsterName")]
        public string MonsterName { get; set; }
        
        [JsonPropertyName("Hp")]
        public int Hp { get; set; }
        
        [JsonPropertyName("MonsterAttack")]
        public int MonsterAttack { get; set; }
        
        [JsonPropertyName("Speed")]
        public int Speed { get; set; }
        
        [JsonPropertyName("WeekName")]
        public string WeekName { get; set; }

        [JsonPropertyName("MySkillId")]
        public string? MySkillId { get; set; }

        [JsonPropertyName("SkillId")]
        public string? SkillId { get; set; }
        
        [JsonPropertyName("SkillName")]
        public string? SkillName { get; set; }
        
        [JsonPropertyName("SkillAttack")]
        public int SkillAttack { get; set; }
        
        [JsonPropertyName("SkillElementName")]
        public string? SkillElementName { get; set; }
        
        [JsonPropertyName("IsChanged")]
        public bool IsChanged { get; set; }

        // 各スキル
        [JsonPropertyName("MySkillIds")]
        public IList<string> MySkillIds { get; set; } = [];

        [JsonPropertyName("SkillIds")]
        public IList<string> SkillIds { get; set; } = [];
        
        [JsonPropertyName("SkillNames")]
        public IList<string> SkillNames { get; set; } = [];
        
        [JsonPropertyName("SkillAttacks")]
        public IList<int> SkillAttacks { get; set; } = [];
        
        [JsonPropertyName("SkillElementNames")]
        public IList<string> SkillElementNames { get; set; } = [];
    }
}
