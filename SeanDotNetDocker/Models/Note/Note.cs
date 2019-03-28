using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeanDotNetDocker.Models.Note
{
    /// <summary>
    /// Note 클래스: Notes 테이블과 일대일 매핑되는 ViewModel 클래스
    /// </summary>
    public class Note
    {
        [Key]
        [Display(Name = "번호")]
        public int Id { get; set; }

        [Column("Name", TypeName = "VARCHAR(25)")]
        [Display(Name = "작성자")]
        [Required(ErrorMessage = "* 이름을 작성해 주세요.")]
        public string Name { get; set; }

        [Column("Email", TypeName = "VARCHAR(100)")]
        [EmailAddress(ErrorMessage = "* 이메일을 정확히 입력하세요.")]
        public string Email { get; set; }

        [Column("Title", TypeName = "VARCHAR(150)")]
        [Display(Name = "제목")]
        [Required(ErrorMessage = "* 제목을 작성해 주세요.")]
        public string Title { get; set; }

        [Column("PostDate", TypeName = "DATETIME")]
        [Display(Name = "작성일")]
        public DateTime PostDate { get; set; } = DateTime.UtcNow;

        [Column("PostIp", TypeName = "VARCHAR(15)")]
        [Display(Name = "작성IP")]
        public string PostIp { get; set; }

        [Column("Content", TypeName = "TEXT")]
        [Display(Name = "내용")]
        [Required(ErrorMessage = "* 내용을 작성해 주세요.")]
        public string Content { get; set; }

        [Column("Password", TypeName = "VARCHAR(255)")]
        [Display(Name = "비밀번호")]
        [Required(ErrorMessage = "* 비밀번호를 작성해 주세요.")]
        public string Password { get; set; }

        [Column("ReadCount", TypeName = "INT(10)")]
        [Display(Name = "조회수")]
        public int ReadCount { get; set; }

        [Column("Encoding", TypeName = "VARCHAR(10)")]
        [Display(Name = "인코딩")]
        public string Encoding { get; set; } = "Text";

        [Column("Homepage", TypeName = "VARCHAR(100)")]
        [Display(Name = "홈페이지")]
        public string Homepage { get; set; }

        [Column("ModifyDate", TypeName = "DATETIME")]
        [Display(Name = "수정일")]
        public DateTime ModifyDate { get; set; }

        [Column("ModifyIp", TypeName = "VARCHAR(15)")]
        [Display(Name = "수정IP")]
        public string ModifyIp { get; set; }

        [Column("FileName", TypeName = "VARCHAR(255)")]
        [Display(Name = "파일")]
        public string FileName { get; set; }

        [Column("FileSize", TypeName = "INT(10)")]
        [Display(Name = "파일크기")]
        public int FileSize { get; set; }

        [Column("DownCount", TypeName = "INT(10)")]
        [Display(Name = "다운수")]
        public int DownCount { get; set; }

        [Column("Ref", TypeName = "INT(10)")]
        [Display(Name = "참조번호")]
        public int Ref { get; set; }

        [Column("Step", TypeName = "INT(10)")]
        [Display(Name = "들여쓰기")]
        public int Step { get; set; }

        [Column("RefOrder", TypeName = "INT(10)")]
        [Display(Name = "참조순서")]
        public int RefOrder { get; set; }
        
        [Column("AnswerNum", TypeName = "INT(10)")]
        [Display(Name = "답변수")]
        public int AnswerNum { get; set; }

        [Column("ParentNum", TypeName = "INT(10)")]
        [Display(Name = "부모번호")]
        public int ParentNum { get; set; }

        [Column("CommentCount", TypeName = "INT(10)")]
        [Display(Name = "댓글수")]
        public int CommentCount { get; set; }

        [Column("Category", TypeName = "VARCHAR(10)")]
        [Display(Name = "카테고리")]
        public string Category { get; set; } = "Free"; // 자유게시판(Free) 기본

        [Column("Num", TypeName = "INT(10)")]
        public int Num { get; set; }

        [Column("UserId", TypeName = "INT(10)")]
        public int UserId { get; set; }

        [Column("CategoryId", TypeName = "INT(10)")]
        public int CategoryId { get; set; }

        [Column("BoardId", TypeName = "INT(10)")]
        public int BoardId { get; set; }

        [Column("AplicationId", TypeName = "INT(10)")]
        public int AplicationId { get; set; }
    }
}
