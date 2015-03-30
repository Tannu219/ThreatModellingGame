using System.ComponentModel.DataAnnotations;

namespace ThreatModelingGame.Web.Models
{
    public sealed class ChangePlayerNameModel
    {
        [Required]
        public string Name { get; set; }
    }
}