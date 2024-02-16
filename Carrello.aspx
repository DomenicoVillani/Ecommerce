<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Templates.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="Ecommerce.Carrello" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-evenly mb-5">
        <h3 ID="txtTotale" runat="server">Totale Carrello: 0€</h3>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Rimuovi tutti i prodotti del carrello" OnClick="CancellaTuttiProdotti" CssClass="btn btn-danger"/>
        </div>
    </div>
    <ul ID="htmlContent" runat="server">
    </ul>
</asp:Content>
