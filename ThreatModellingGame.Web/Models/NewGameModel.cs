using System.ComponentModel.DataAnnotations;

namespace ThreatModellingGame.Web.Models
{
    public sealed class NewGameModel
    {
        [Required]
        public string Name { get; set; }
    }
}