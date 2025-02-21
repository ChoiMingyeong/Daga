using System.ComponentModel.DataAnnotations;

namespace OpsCommon
{
    public class Login
    {
        [Required]
        [EmailAddress(ErrorMessage = "이메일 형식에 맞게 작성해주세요. (예: example123@abc.com)")]
        public string Email { get; set; } = string.Empty;

        [Required, Length(8, 15, ErrorMessage = "8~15자 사이의 비밀번호를 입력해주세요.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
