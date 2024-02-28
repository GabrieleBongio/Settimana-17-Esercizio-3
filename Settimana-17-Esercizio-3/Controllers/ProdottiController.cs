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
    public class ProdottiController : Controller
    {
        // GET: Prodotti
        public ActionResult Index()
        {
            List<Prodotti> listaProdotti = new List<Prodotti>();

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaProdotti.Add(
                        new Prodotti(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetSqlMoney(2).ToDouble(),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.GetBoolean(7)
                        )
                    );
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return View(listaProdotti);
        }

        public ActionResult Dettagli()
        {
            string id = Request.QueryString["IdProdotto"];

            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Prodotti Prodotto = new Prodotti();

            string connString = ConfigurationManager
                .ConnectionStrings["myConnection"]
                .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti WHERE IdProdotto = " + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Prodotto.Id = reader.GetInt32(0);
                    Prodotto.Nome = reader.GetString(1);
                    Prodotto.Prezzo = reader.GetSqlMoney(2).ToDouble();
                    Prodotto.Descrizione = reader.GetString(3);
                    Prodotto.ImmagineUno = reader.GetString(4);
                    Prodotto.ImmagineDue = reader.GetString(5);
                    Prodotto.ImmagineTre = reader.GetString(6);
                    Prodotto.InVendita = reader.GetBoolean(7);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return View(Prodotto);
        }
    }
}
