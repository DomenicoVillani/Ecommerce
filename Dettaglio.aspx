<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Templates.Master" AutoEventWireup="true" CodeBehind="Dettaglio.aspx.cs" Inherits="Ecommerce.Dettaglio" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 ID="ttlProdotto" runat="server" class="text-center fw-bold fst-italic text-uppercase">Nome prodotto</h2>
        <div class="d-flex justify-content-center">
            <img ID="img" src="" alt="" class="" runat="server"/>
        </div>
        <p ID="txtDescrizione" runat="server" class="text-center"> </p>
        <p ID="txtPrezzo" runat="server" class="text-center"> </p>
        <div class="d-flex justify-content-center">
            <asp:Button ID="btnAcquista" runat="server" Text="Aggiungi al carrello" CssClass="btn btn-secondary" OnClick="btnAcquista_Click"/>
        </div>
    </div>    
</asp:Content>
