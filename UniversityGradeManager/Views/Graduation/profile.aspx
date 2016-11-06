<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="UniversityGradeManager.Views.Graduation.profile" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="<%# Graduation.Name %>" />

<h1 class="page-header"><%= Graduation.Name %></h1>
<div class="text-right">
    <a href="/Views/Graduation/edit.aspx?Id=<%= Graduation.Id %>" class="btn btn-success">Editar Curso</a>
    <a href="/Views/Graduation/delete.aspx?Id=<%= Graduation.Id %>" class="btn btn-danger">Deletar Curso</a>
</div>

<ctrl:Footer runat="server" ID="ctrlFooter" />

