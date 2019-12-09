using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RestApi.Models
{
    [JsonConverter(typeof(StringEnumConverter))] public enum Gender { [EnumMember(Value = "female")] Female, [EnumMember(Value = "male")] Male, [EnumMember(Value = "other")] Other }
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Gender? Gender { get; set; }

        public int Age { get; set; }
    }
}
