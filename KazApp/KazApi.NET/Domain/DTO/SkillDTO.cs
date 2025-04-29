using System.Text.Json.Serialization;
using KazApi.Domain._Monster._Skill;

namespace KazApi.Domain.DTO
{
    /// <summary>
    /// スキルパラメータクラス
    /// </summary>
    public class SkillDTO
    {
        [JsonPropertyName("SkillId")]
        public string SkillId { get; set; }
        
        [JsonPropertyName("SkillName")]
        public string SkillName { get; set; }
        
        [JsonPropertyName("SkillType")]
        public int SkillType { get; set; }
        
        [JsonPropertyName("ElementType")]
        public int ElementType { get; set; }
        
        [JsonPropertyName("StateType")]
        public int StateType { get; set; }
        
        [JsonPropertyName("TargetType")]
        public int TargetType { get; set; }
        
        [JsonPropertyName("Attack")]
        public int Attack { get; set; }
        
        [JsonPropertyName("Weight")]
        public int Weight { get; set; }

        [JsonPropertyName("DefaultCritical")]
        public double DefaultCritical { get; set; }

        [JsonPropertyName("Critical")]
        public double Critical { get; set; }

        [JsonPropertyName("HitRate")]
        public double HitRate { get; set; }

        [JsonPropertyName("Remarks")]
        public string? Remarks { get; set; } = string.Empty;

        [JsonPropertyName("EffectTime")]
        public int EffectTime { get; set; } = 1000;

        /// <summary>
        /// コンストラクタ
        /// デシリアライズのため必須
        /// </summary>
        public SkillDTO() { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SkillDTO(ISkill model)
        {
            SkillId = model.SkillId;
            SkillName = model.SkillName;
            SkillType = model.SkillType;
            ElementType = model.ElementType;
            StateType = model.StateType;
            TargetType = model.TargetType;
            Attack = model.Attack;
            Weight = model.Weight;
            DefaultCritical = model.DefaultCritical;
            Critical = model.Critical;
            HitRate = model.HitRate;
            Remarks = "";
        }
    }
}
