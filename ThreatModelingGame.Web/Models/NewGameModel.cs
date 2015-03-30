using System.ComponentModel.DataAnnotations;

namespace ThreatModelingGame.Web.Models
{
    public sealed class NewGameModel
    {
        [Required]
        public string Name { get; set; }
    }
}