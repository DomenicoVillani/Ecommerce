using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;

namespace Ecommerce
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DBConn.conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Prodotti", DBConn.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                string content = "";
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        content += $@"<div class=""col-3"">
                                        <div class=""card h-100 d-flex flex-column justify-content-between"">
                                         <div>
                                        <img src=""{dataReader["Immagine"]}"" class=""card-img-top"" alt=""{dataReader["Nome"]}"">
                                        <div class=""card-body "">
                                        <h5 class=""card-title"">{dataReader["Nome"]}</h5>
                                        <p class=""card-text"">{dataReader["Descrizione"]}</p>
                                        </div>
                                        </div>
                                        <div class=""border-top d-flex justify-content-around align-items-baseline p-3"">
                                        <p class=""card-text me-2"">{dataReader["Prezzo"]}€</p>
                                        <a href=""Dettaglio.aspx?product={dataReader["ID"]}"" class=""btn btn-primary"">Dettaglio</a>
                                        </div>
                                        </div>
                                        </div> ";
                    }
                }
                contentHtml.InnerHtml = content;
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
    }
}