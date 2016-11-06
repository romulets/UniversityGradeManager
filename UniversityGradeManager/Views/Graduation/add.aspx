<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="UniversityGradeManager.Views.Graduation.add" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Adicionar Curso" />

<h1 class="page-header">Adicionar Curso</h1>

<form id="frmAdd" runat="server">
    <asp:label runat="server" id="lblErrorMessage" class="alert alert-danger"></asp:label>

    <div class="form-group">
        <asp:label runat="server" id="lblName" text="* Nome: "></asp:label>
        <asp:textbox runat="server" id="txtName" cssclass="form-control"></asp:textbox>
    </div>

    <asp:button runat="server" id="btnSave" text="Salvar" cssclass="btn btn-default" onclick="btnSave_Click" />
</form>

<ctrl:Footer runat="server" ID="ctrlFooter" />

