using System.ComponentModel.DataAnnotations;
using ThreatModellingGame.Web.Resources;

namespace ThreatModellingGame.Web.ViewModels
{
    public sealed class NewGameViewModel
    {
        [Required(ErrorMessageResourceType = typeof(AllText), ErrorMessageResourceName = "Missing_Game_Name_Error")]
        [Display(ResourceType = typeof(AllText), Name = "New_Game_Label")]
        public string Name { get; set; }
    }
}