<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="UniversityGradeManager.Views.Discipline.edit" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Editar Disciplina" />

<h1 class="page-header">Editar Disciplina <%= Discipline.Code %> - <%= Discipline.Name %></h1>

<p class="text-muted"><%= Discipline.Period.Number %>° período do curso <%= Discipline.Period.Graduation.Name %></p>

<form id="frmAdd" runat="server">
    <asp:panel runat="server" id="pnErrorMessage" class="alert alert-danger"></asp:panel>

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
        <asp:label runat="server" id="lblNumberOfCredits" text="* Quantidade de Créditos: "></asp:label>
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
    <a href="profile.aspx?Graduation=<%= Discipline.Period.Graduation.Id %>&Discipline=<%= Discipline.Code %>" class="btn btn-danger">Cancelar</a>
</form>

<ctrl:Footer runat="server" ID="ctrlFooter" />
