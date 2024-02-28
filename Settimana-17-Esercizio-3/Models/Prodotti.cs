using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Settimana_17_Esercizio_3.Models
{
    public class Prodotti
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Prezzo { get; set; }
        public string Descrizione { get; set; }
        public string ImmagineUno { get; set; }
        public string ImmagineDue { get; set; }
        public string ImmagineTre { get; set; }
        public bool InVendita { get; set; }

        public Prodotti() { }

        public Prodotti(
            int id,
            string nome,
            double prezzo,
            string descrizione,
            string immagineUno,
            string immagineDue,
            string immagineTre,
            bool inVendita
        )
        {
            Id = id;
            Nome = nome;
            Prezzo = prezzo;
            Descrizione = descrizione;
            ImmagineUno = immagineUno;
            ImmagineDue = immagineDue;
            ImmagineTre = immagineTre;
            InVendita = inVendita;
        }
    }
}
