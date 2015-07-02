using System.ComponentModel.DataAnnotations;
using ThreatModellingGame.Web.Resources;

namespace ThreatModellingGame.Web.ViewModels
{
    public sealed class ChangePlayerNameViewModel
    {
        [Required(ErrorMessageResourceType = typeof(AllText), ErrorMessageResourceName = "Missing_Username_Error")]
        [Display(ResourceType = typeof(AllText), Name = "Change_Username_Label")]
        public string Name { get; set; }
    }
}