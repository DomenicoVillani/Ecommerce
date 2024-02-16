<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Templates.Master" AutoEventWireup="true" CodeBehind="Dettaglio.aspx.cs" Inherits="Ecommerce.Dettaglio" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <h2 ID="ttlProdotto" runat="server" class="text-center fw-bold fst-italic text-uppercase">Nome prodotto</h2>
        <div class="d-flex justify-content-center">
            <img ID="img" src="" alt="" class="" runat="server"/>
        </div>
        <p ID="txtDescrizione" runat="server" class="text-center my-5"> </p>
        <p ID="txtPrezzo" runat="server" class="text-center mb-5"> </p>
        <div class="d-flex justify-content-center mb-5">
            <asp:Button ID="btnAcquista" runat="server" Text="Aggiungi al carrello" CssClass="btn btn-success" OnClick="btnAcquista_Click"/>
        </div>
    </div>    
</asp:Content>
