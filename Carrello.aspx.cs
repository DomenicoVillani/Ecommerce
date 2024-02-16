using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<int> product = new List<int>();
            product = (List<int>)Session["ProductID"];
            string content = "";
            double PrezzoTotale = 0;
            if(product == null)
            {
                htmlContent.InnerHtml = @"<li class=""d-flex justify-content-center fw-bold"">
                                    <h3 class=""fw-bold"">Carrello Vuoto</h3>
                                   </li>";
            }
            else
            {
                foreach (int id in product)
                {
                    try
                    {
                        DBConn.conn.Open();
                        SqlCommand cmd = new SqlCommand($"SELECT * FROM Prodotti WHERE ID={id}", DBConn.conn);
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        if (dataReader.HasRows)
                        {
                            dataReader.Read();
                            content += $@"<li class=""d-flex justify-content-evenly align-items-baseline"">
                                        <p class=""fw-bold"">{dataReader["Nome"]}</p>
                                        <div class=""d-flex align-items-baseline"">
                                            <p class=""fw-bold"">{dataReader["Prezzo"]}€</p>
                                        </div> 
                                    </li>";
                            PrezzoTotale += double.Parse(dataReader["Prezzo"].ToString());
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
                htmlContent.InnerHtml = content;
                txtTotale.InnerHtml = "Totale Carrello: " + PrezzoTotale.ToString() + "€";
            }
        }
    }
}