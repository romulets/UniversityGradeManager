<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="UniversityGradeManager.Views.Graduation.profile" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="<%# Graduation.Name %>" />

<h1 class="page-header"><%= Graduation.Name %></h1>
<div class="text-right">
    <a href="/Views/Graduation/edit.aspx?Id=<%= Graduation.Id %>" class="btn btn-success">Editar Curso</a>
    <a href="/Views/Graduation/delete.aspx?Id=<%= Graduation.Id %>" class="btn btn-danger">Deletar Curso</a>
</div>

<hr />

<div class="panel panel-primary">
    <div class="panel-heading">
        <h3 class="panel-title pull-left">Períodos</h3>
        <a href="/Views/Period/add.aspx?Graduation=<%= Graduation.Id %>" class="btn btn-default btn-xs pull-right">Adicionar Período</a>
        <span class="clearfix"></span>
    </div>
    <div class="panel-body">

        <table class="table table-striped">
            <tr>
                <th>Período</th>
                <th></th>
            </tr>

            <% foreach (UniversityGradeManager.Entities.Period period in Graduation.Periods) %>
            <% { %>
            <tr>
                <td><%= period.Number %>° Período</td>
                <td class="text-right"><a href="/Views/Period/profile.aspx?Graduation=<%= Graduation.Id %>&Period=<%= period.Number %>" class="btn btn-info btn-xs">Ver Período</a></td>
            </tr>
            <% } %>
        </table>

    </div>
</div>

<ctrl:Footer runat="server" ID="ctrlFooter" />

