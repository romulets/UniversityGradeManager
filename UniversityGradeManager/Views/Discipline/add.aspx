<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="UniversityGradeManager.Views.Discipline.add" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Adicionar Disciplina" />

<h1 class="page-header">Adicionar Disciplina</h1>

<p class="text-muted"><%= Period.Number %>° período do curso <%= Period.Graduation.Name %></p>

<form id="frmAdd" runat="server">
    <asp:panel runat="server" id="pnErrorMessage" class="alert alert-danger"></asp:panel>

    <div class="form-group">
        <asp:label runat="server" id="lblCode" text="* Código: "></asp:label>
        <asp:textbox runat="server" id="txtCode" cssclass="form-control"></asp:textbox>
    </div>

    <div class="form-group">
        <asp:label runat="server" id="lblName" text="* Nome: "></asp:label>
        <asp:textbox runat="server" id="txtName" cssclass="form-control"></asp:textbox>
    </div>

    <div class="form-group">
        <asp:label runat="server" id="lblTheorycClassesCount" text="* Quantidade de Aulas Teoricas: "></asp:label>
        <asp:textbox runat="server" id="txtTheorycClassesCount" cssclass="form-control"></asp:textbox>
    </div>

    <div class="form-group">
        <asp:label runat="server" id="lblPractiseClassesCount" text="* Quantidade de Aulas Práticas: "></asp:label>
        <asp:textbox runat="server" id="txtPractiseClassesCount" cssclass="form-control"></asp:textbox>
    </div>

    <div class="form-group">
        <asp:label runat="server" id="lblNumberOfCredits" text="* Quantidade Créditos: "></asp:label>
        <asp:textbox runat="server" id="txtNumberOfCredits" cssclass="form-control"></asp:textbox>
    </div>

    <div class="form-group">
        <asp:label runat="server" id="lblWorkload" text="* Horas Aula: "></asp:label>
        <asp:textbox runat="server" id="txtWorkload" cssclass="form-control"></asp:textbox>
    </div>

    <div class="form-group">
        <asp:label runat="server" id="lblClockHours" text="* Horas Relógio: "></asp:label>
        <asp:textbox runat="server" id="txtClockHours" cssclass="form-control"></asp:textbox>
    </div>

    <asp:button runat="server" id="btnSave" text="Salvar" cssclass="btn btn-success" onclick="btnSave_Click" />
    <a href="../Period/profile.aspx?Graduation=<%= Period.Graduation.Id %>&Period=<%= Period.Number %>" class="btn btn-danger">Cancelar</a>
</form>

<ctrl:Footer runat="server" ID="ctrlFooter" />

