using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Settimana_17_Esercizio_3.Models
{
    public class Utente
    {
        [Required]
        [MaxLength(100, ErrorMessage = "l'indirizzo Mail è troppo lungo")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "La password deve avere tra i 6 e i 50 caratteri")]
        [MaxLength(50, ErrorMessage = "La password deve avere tra i 6 e i 50 caratteri")]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        [Compare(
            "Password",
            ErrorMessage = "Questo campo deve essere uguale alla Password inserita sopra"
        )]
        [Display(Name = "Conferma Password")]
        public string ConfermaPassword { get; set; }
    }
}
