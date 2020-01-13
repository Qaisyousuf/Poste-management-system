﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace OPMS.ViewModels
{
    public class SidebarViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nom de la barre latérale")]
        [Required(ErrorMessage = "Le nom de la barre latérale est obligatoire")]
        public string Name { get; set; }

        [AllowHtml]
        [Display(Name = "Contenu de la barre latérale")]
        [Required(ErrorMessage = "Le contenu de la barre latérale est requis")]
        public string Content { get; set; }

        [Display(Name = "Date de publication")]
        public DateTime PublishDate { get; set; }
    }
}
