using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Dettaglio : System.Web.UI.Page
    {
        private string ProductId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["product"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            ProductId = Request.QueryString["product"].ToString();
            try
            {
                DBConn.conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Prodotti WHERE ID={ProductId}", DBConn.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if(dataReader.HasRows)
                {
                    dataReader.Read();
                    ttlProdotto.InnerText = dataReader["Nome"].ToString();
                    img.Src = dataReader["Immagine"].ToString();
                    txtDescrizione.InnerText = dataReader["Descrizione"].ToString();
                    txtPrezzo.InnerText = dataReader["Prezzo"].ToString() + "€";
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                if (DBConn.conn.State == ConnectionState.Open)
                {
                    DBConn.conn.Close();
                }
            }
        }

        protected void btnAcquista_Click(object sender, EventArgs e)
        {
            int prodId = int.Parse(ProductId);
            List<int> products;
            if (Session["ProductID"] == null)
            {
                products = new List<int>();
            }
            else
            {
                products = (List<int>)Session["ProductID"];
            }
            products.Add(prodId);
            Session["ProductID"] = products;
        }
    }
}