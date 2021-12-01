using System.ComponentModel.DataAnnotations;

namespace TestAcesso.Webapi.Controllers.SendTransfer
{
    public class SendTranferRequest
    {
        [Required]
        public string AccountOrigin { get; set; }

        [Required]
        public string AccountDestination { get; set; }

        [Required]
        public decimal Balance { get; set; }
    }
}
