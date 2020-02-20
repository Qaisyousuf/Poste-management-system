using OPMS.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class MessageContainerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le titre du message est requis")]
        [Display(Name = "Titre du message")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Le message Sous-titre est requis")]
        [Display(Name = "Sous-titre de Message")]
        public string SubTitle { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Le contenu du message est requis")]
        [Display(Name = "Contenu du message")]
        public string Content { get; set; }

        public string CreatedBy { get; set; }

    }
}
