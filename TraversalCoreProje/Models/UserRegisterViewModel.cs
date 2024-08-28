using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage ="Lütfen adınız giriniz")]
        public string Name { get; set; }
		[Required(ErrorMessage = "Lütfen soyadınız giriniz")]
		public string Surname { get; set; }
		[Required(ErrorMessage = "Lütfen kullanıcı adınız giriniz")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Lütfen mail adresini giriniz")]
		public string Mail { get; set; }
		[Required(ErrorMessage = "Lütfen şifreyi giriniz")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz")]
		[Compare("Password",ErrorMessage ="şifreler uyumlu değil")]
		public string ConfirmPassword { get; set; }
	}
}
