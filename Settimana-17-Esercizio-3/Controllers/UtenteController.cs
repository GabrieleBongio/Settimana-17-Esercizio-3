using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Settimana_17_Esercizio_3.Models;

namespace Settimana_17_Esercizio_3.Controllers
{
    public class UtenteController : Controller
    {
        // GET: Utente
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utente u)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Utenti WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader.GetString(2) != u.Password)
                    {
                        this.Session["Errore"] = "Password sbagliata";
                        return View();
                    }
                    else
                    {
                        this.Session["Account"] = "user";
                        if (reader.GetBoolean(3))
                        {
                            this.Session["Account"] = "admin";
                        }
                        return RedirectToAction("Index", "Prodotti");
                    }
                }
                else
                {
                    conn.Close();

                    string connStringInsert = ConfigurationManager
                        .ConnectionStrings["myConnection"]
                        .ConnectionString.ToString();
                    SqlConnection connInsert = new SqlConnection(connStringInsert);

                    conn.Open();
                    string queryInsert =
                        "INSERT INTO Utenti (Email, Password) VALUES (@Email, @Password)";
                    SqlCommand cmdInsert = new SqlCommand(queryInsert, connInsert);
                    cmdInsert.Parameters.AddWithValue("@Email", u.Email);
                    cmdInsert.Parameters.AddWithValue("@Password", u.Password);
                    SqlDataReader readerInsert = cmd.ExecuteReader();
                    Session["Message"] =
                        "Nuova Email registrata, Inserisci i dati nuovamente per accedere";
                    return View();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                this.Session["Errore"] = "Errore nella Login";
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        public ActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout(string message)
        {
            Session.Clear();
            return RedirectToAction("Index", "Prodotti");
        }
    }
}
