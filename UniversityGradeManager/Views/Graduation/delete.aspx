<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete.aspx.cs" Inherits="UniversityGradeManager.Views.Graduation.delete" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Deletar Curso" />

<h1 class="page-header">Deletar Curso <%= Graduation.Name %>?</h1>

<form id="frmEdit" runat="server">
    <asp:panel runat="server" id="pnErrorMessage" class="alert alert-danger"></asp:panel>

    <div class="alert alert-warning">
        <span><strong>Cuidado!</strong> As ações confirmadas aqui não poderão ser desfeitas. Deseja deletar o curso <strong><%= Graduation.Name %></strong> e todas as suas relações?</span>
    </div>

    <asp:button runat="server" id="btnYes" text="Sim" cssclass="btn btn-danger" onclick="btnYes_Click" />
    <a href="/Views/Graduation/profile.aspx?Id=<%= Graduation.Id %>" class="btn btn-warning">Não</a>
</form>

<ctrl:Footer runat="server" ID="ctrlFooter" />
