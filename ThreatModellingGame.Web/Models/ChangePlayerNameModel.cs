using System.ComponentModel.DataAnnotations;

namespace ThreatModellingGame.Web.Models
{
    public sealed class ChangePlayerNameModel
    {
        [Required]
        public string Name { get; set; }
    }
}