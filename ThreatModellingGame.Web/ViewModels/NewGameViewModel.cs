using System.ComponentModel.DataAnnotations;

namespace ThreatModellingGame.Web.ViewModels
{
    public sealed class NewGameViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}