<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notfound.aspx.cs" Inherits="UniversityGradeManager.Views.Errors.notfound" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Adicionar Curso" />

<h1 class="page-header">Página não econtrada</h1>

<p class="text-muted">Desculpe mas o que você procura não está aqui :/</p>

<ctrl:Footer runat="server" ID="ctrlFooter" />
