<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="UniversityGradeManager.Views.Graduation.list" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Listagem de Cursos" />

<h1 class="pull-left">Graduações Cadastradas</h1>
<a href="/Views/Graduation/add.aspx" class="btn btn-default pull-right">Adicionar Curso</a>

<table class="table table-striped">
    <tr>
        <th>Código</th>
        <th>Nome</th>
        <th></th>
    </tr>

    <% foreach (UniversityGradeManager.Entities.Graduation graduation in Graduations) %>
    <% { %>
    <tr>
        <td><%= graduation.Id %></td>
        <td><%= graduation.Name %></td>
        <td class="text-right"><a href="/Views/Graduation/profile.aspx?Id=<%= graduation.Id %>" class="btn btn-info btn-xs">Ver Curso</a></td>
    </tr>
    <% } %>
</table>

<ctrl:Footer runat="server" ID="ctrlFooter" />
