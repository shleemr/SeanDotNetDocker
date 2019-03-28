using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeanDotNetDocker.Models.Note
{
    /// <summary>
    /// 댓글 뷰 모델
    /// NoteComment 클래스: NoteComments 테이블과 일대일 매핑되는 ViewModel 클래스
    /// </summary>
    public class NoteComment
    {
        [Key]
        public int Id { get; set; }

        [Column("BoardName", TypeName = "VARCHAR(50)")]
        public string BoardName { get; set; }

        [Column("BoardId", TypeName = "INT(10)")]
        public int BoardId { get; set; }

        [Column("Name", TypeName = "VARCHAR(25)")]
        [Required(ErrorMessage = "이름을 입력하세요.")]
        public string Name { get; set; }

        [Column("Opinion", TypeName = "VARCHAR(4000)")]
        [Required(ErrorMessage = "의견을 입력하세요.")]
        public string Opinion { get; set; }

        [Column("PostDate", TypeName = "DATETIME")]
        public DateTime PostDate { get; set; }

        [Required(ErrorMessage = "암호를 입력하세요.")]
        [Column("Password", TypeName = "VARCHAR(255)")]
        public string Password { get; set; }
    }
}
