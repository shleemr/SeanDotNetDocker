using System.ComponentModel.DataAnnotations.Schema;

namespace SeanDotNetDocker.Models
{
    public class WebSettingModel
    {
        public int Id { get; set; }

        [Column("SettingKey", TypeName = "VarChar(256)")]
        public string SettingKey { get; set; }

        [Column("Value", TypeName = "VarChar(256)")]
        public string Value { get; set; }
    }
}
