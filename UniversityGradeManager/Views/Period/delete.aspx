<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete.aspx.cs" Inherits="UniversityGradeManager.Views.Period.delete" %>


<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Deletar Período" />

<h1 class="page-header">Deletar <%= Period.Number %>° período do curso <%= Period.Graduation.Name %>?</h1>

<form id="frmEdit" runat="server">
    <asp:panel runat="server" id="pnErrorMessage" class="alert alert-danger"></asp:panel>

    <div class="alert alert-warning">
        <span><strong>Cuidado!</strong> As ações confirmadas aqui não poderão ser desfeitas. Deseja deletar o <strong><%= Period.Number %>° período do curso <%= Period.Graduation.Name %></strong> e todas as suas relações?</span>
    </div>

    <asp:button runat="server" id="btnYes" text="Sim" cssclass="btn btn-danger" onclick="btnYes_Click" />
    <a href="/Views/Period/profile.aspx?Graduation=<%= Period.Graduation.Id %>&Period=<%= Period.Number %>" class="btn btn-warning">Não</a>
</form>

<ctrl:Footer runat="server" ID="ctrlFooter" />
