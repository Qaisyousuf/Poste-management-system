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

        [Required(ErrorMessage = "L'envoi de DateTime est obligatoire")]
        [Display(Name = "Envoi DateTimee")]
        public DateTime SendingDateTime { get; set; }

        [Required(ErrorMessage = "Rendez-vous DateTime est requiss")]
        [Display(Name = "Heure de rendez-vous")]
        public DateTime AppointmentDateTime { get; set; }

    }
}
