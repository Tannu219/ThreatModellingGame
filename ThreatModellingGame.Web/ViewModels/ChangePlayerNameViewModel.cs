using System.ComponentModel.DataAnnotations;

namespace ThreatModellingGame.Web.ViewModels
{
    public sealed class ChangePlayerNameViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}