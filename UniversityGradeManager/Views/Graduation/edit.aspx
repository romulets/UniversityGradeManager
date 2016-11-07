<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="UniversityGradeManager.Views.Graduation.edit" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Editar Curso" />

<h1 class="page-header">Editar Curso <%= Graduation.Name %></h1>

<form id="frmEdit" runat="server">
    <asp:label runat="server" id="lblErrorMessage" class="alert alert-danger"></asp:label>

    <div class="form-group">
        <asp:label runat="server" id="lblName" text="* Nome: "></asp:label>
        <asp:textbox runat="server" id="txtName" cssclass="form-control"></asp:textbox>
    </div>

    <asp:button runat="server" id="btnSave" text="Salvar" cssclass="btn btn-success" onclick="btnSave_Click" />
    <a href="/Views/Graduation/profile.aspx?Id=<%= Graduation.Id %>" class="btn btn-danger">Cancelar</a>
</form>

<ctrl:Footer runat="server" ID="ctrlFooter" />

