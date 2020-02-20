using OPMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OPMS.ViewModels
{
    public class SiteSettingsViewModel
    {
      
        public int Id { get; set; }

        [Required]
        [Display(Name ="Site name")]
        public string SiteName { get; set; }


        [Display(Name = "Is Register")]
        public bool IsRegister { get; set; }

        [Required]
        [Display(Name = "Site Footer")]
        public string SiteFooter { get; set; }


        [Display(Name = "Fav Icon Url")]
        public string FavIconURL { get; set; }

        [Required]
        [Display(Name = "Site Owner")]
        public string SiteOwner { get; set; }

        [Display(Name = "Site Verification")]
        public string GoogleSiteVerification { get; set; }

        [Display(Name = "Google Ads")]
        public string GoogleAds { get; set; }

     

        [Display(Name = "Custom CSS")]
        public string CustomCSS { get; set; }


        [Display(Name = "Is Custom CSS")]
        public bool IsCustomCSSOn { get; set; }


        [Display(Name = "Custom JS")]
        public string CustomJS { get; set; }

        [Display(Name = "Is Custom JS")]
        public bool IsCustomJsOn { get; set; }

        [Display(Name = "Lst Updated")]
        public DateTime SiteLastUpdated { get; set; }

        [Display(Name = "Created By")]
        public string UpdateBy { get; set; }

        [Required]
        [Display(Name = "Home Footer")]
        public string HomeFooter { get; set; }


        [Required]
        [Display(Name = "Home Url")]
        public string HomeUrl { get; set; }


        [Required]
        [Display(Name = "About Footer")]
        public string AboutFooter { get; set; }


        [Required]
        [Display(Name = "About Url")]
        public string AboutUrl { get; set; }


        [Required]
        [Display(Name = "Contact Footer")]
        public string ContactFooter { get; set; }


        [Required]
        [Display(Name = "Contact Url")]
        public string ContactUrl { get; set; }

        [Required]
        [Display(Name = "Roles Footer")]
        public string RolesFooter { get; set; }


        [Required]
        [Display(Name = "Roles Url")]
        public string RolesUrl { get; set; }


        [Display(Name = "Contact Number")]
        public string ContactNumberFooter { get; set; }


        [Required]
        [Display(Name = " Email Footer")]
        public string EmailFooter { get; set; }


        [Required]
        [Display(Name = "Addres Footer")]
        public string AddresFooter { get; set; }


        [Required]
        [AllowHtml]
        [Display(Name = "Content Footer")]
        public string ContentFooter { get; set; }


        [Required]
        [Display(Name = "Copyright Footer")]
        public string CopyrightFooter { get; set; }


        [Display(Name = "Login Url")]
        public string LoginUrl { get; set; }

        [Display(Name = "Login Footer")]
        public string LoginFooter { get; set; }
    }
}
