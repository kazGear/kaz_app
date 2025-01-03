﻿using KazApi.Domain._Const;
using KazApi.Domain._Monster._State;
using System.Text.Json.Serialization;

namespace KazApi.Domain.DTO
{
    public class StateDTO
    {
        [JsonPropertyName("CodeId")]
        public string CodeId { get; set; }
      
        [JsonPropertyName("StateType")]
        public int StateType { get; set; }
        
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("ShortName")]
        public string ShortName { get; set; }

        [JsonPropertyName("CancelRate")]
        public double CancelRate { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StateDTO() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StateDTO(IState model)
        {
            CodeId = CCodeType.STATE.VALUE;
            StateType = model.StateType;
            Name = model.Name;
            ShortName = model.ShortName;
            CancelRate = model.CancelRate;
        }

        /// <summary>
        /// DTOへ変換
        /// </summary>
        public static IEnumerable<StateDTO> ModelToDTO(IEnumerable<IState> models)
        {
            IList<StateDTO> result = [];

            foreach (IState model in models)
                result.Add(new StateDTO(model));

            return result;
        }
    }
}
