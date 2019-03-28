using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeanDotNetDocker.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Uid { get; set; }

        // User 타입 =>  1:학생,  2:교사 ... 
        [Column("UserType", TypeName = "Int(1)")]
        [DefaultValue(1)]
        public int UserType { get; set; }

        // User 등급 => 1 : 일반,  2 : 교육원관리자  9:사이트관리자...
        [Column("UserLevel", TypeName = "INT(1)")]
        [DefaultValue(1)]
        public int UserLevel { get; set; }

        [EmailAddress]
        [MaxLength(256)]
        [Column("Email", TypeName = "VarChar(256)")]
        public string Email { get; set; } = "";

        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Length of {0} field should be between {2} and {1}.")]
        [Column("Password", TypeName = "VarChar(256)")]
        public virtual string Password { get; set; } = "";

        [NotMapped]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Length of {0} field should be between {2} and {1}.")]
        public virtual string ConfirmPassword { get; set; } = "";

        [NotMapped]
        [MaxLength(10)]
        public string PhoneNumber1 { get; set; } = "010";

        [NotMapped]
        [StringLength(10, MinimumLength = 3,
            ErrorMessage = "Length of {0} field should be between {2} and {1}.")]
        public string PhoneNumber2 { get; set; } = "";

        [NotMapped]
        [StringLength(10, MinimumLength = 4,
            ErrorMessage = "Length of {0} field should be between {2} and {1}.")]
        public string PhoneNumber3 { get; set; } = "";

        [MaxLength(30)]
        [Column("CombinedPhoneNumber", TypeName = "VarChar(25)")]
        [DefaultValue(null)]
        public virtual string CombinedPhoneNumber { get; set; }

        [StringLength(20, MinimumLength = 5,
            ErrorMessage = "Length of {0} field should be between {2} and {1}..")]
        [Column("PostCode", TypeName = "VarChar(20)")]
        public virtual string PostCode { get; set; } = "";

        [StringLength(256, MinimumLength = 5,
            ErrorMessage = "Length of {0} field should be between {2} and {1}.")]
        [Column("Address", TypeName = "VarChar(256)")]
        public virtual string Address { get; set; } = "";

        [Column("Country", TypeName = "VarChar(128)")]
        public string Country { get; set; } = null;

        [NotMapped]
        public string State { get; set; }

        [NotMapped]
        public virtual string City { get; set; }

        // 구입 아이템 속성
        [Column("PerchasedItem", TypeName = "VarChar(256)")]
        [DefaultValue(null)]
        public string PerchasedItem { get; set; }

        [DataType(DataType.DateTime)]
        [Column("RegDate", TypeName = "DateTime")]
        public DateTime RegDate { get; set; } = DateTime.UtcNow;

        [StringLength(256, MinimumLength = 3,
            ErrorMessage = "Length of {0} field should be between {2} and {1}.")]
        [Column("UserName", TypeName = "VarChar(256)")]
        [DefaultValue(null)]
        public virtual string UserName { get; set; }

        [Column("SmsSend", TypeName = "Int(1)")]
        [DefaultValue(1)]
        public int SmsSend { get; set; } = 1;

        [Column("EmailSend", TypeName = "Int(1)")]
        [DefaultValue(1)]
        public int EmailSend { get; set; } = 1;

        // 계정 삭제 여부
        [Column("IsUserValid", TypeName = "Int(1)")]
        [DefaultValue(1)]
        public int IsUserValid { get; set; } = 1;

        [Column("LastLoginTime", TypeName = "DateTime")]
        [DefaultValue(null)]
        public DateTime LastLoginTime { get; set; } = DateTime.UtcNow;

        // 언어 (2글자 언어코드)
        [Column("LanguageCode", TypeName = "VarChar(2)")]
        [DefaultValue("ko")]
        public string LanguageCode { get; set; } = "ko";

        [Column("DeviceInfo", TypeName = "VarChar(256)")]
        [DefaultValue(null)]
        public string DeviceInfo { get; set; } = null;

        [NotMapped]
        public UserDeviceInfo DeviceInfoModel { get; set; }

        // JWT
        [NotMapped]
        public string Token { get; set; }
    }

    public class UserDeviceInfo
    {
        public string DeviceName { get; set; }
        public string DeviceUniqeId { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceType { get; set; }
        public string DeviceOS { get; set; }
    }
}
