<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="UniversityGradeManager.Views.Discipline.profile" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Perfil da disciplina" />

<h1 class="page-header">Disciplina <%= Discipline.Code %> - <%= Discipline.Name %> </h1>

<div class="row margin-bottom-md">

    <div class="col-md-12 text-right">
        <a href="edit.aspx?Graduation=<%= Discipline.Period.Graduation.Id %>&Discipline=<%= Discipline.Code %>" class="btn btn-success">Editar Disciplina</a>

        <a href="delete.aspx?Graduation=<%= Discipline.Period.Graduation.Id %>&Discipline=<%= Discipline.Code%>" class="btn btn-danger">Deletar Disciplina</a>
    </div>

    <div class="col-md-6">

        <div class="panel">
            <p class="text-muted">Curso:</p>
            <p><strong><a href="../Graduation/profile.aspx?Id=<%= Discipline.Period.Graduation.Id %>"><%= Discipline.Period.Graduation.Name %></a></strong></p>
        </div>

        <div class="panel">
            <p class="text-muted">Período:</p>
            <p><strong><a href="../Period/profile.aspx?Graduation=<%= Discipline.Period.Graduation.Id %>&Period=<%= Discipline.Period.Number %>"><%= Discipline.Period.Number %>° período</a></strong></p>
        </div>

        <div class="panel">
            <p class="text-muted">Quantidade de Aulas Teoricas:</p>
            <p><strong><%= Discipline.TheorycClassesCount %></strong></p>
        </div>

        <div class="panel">
            <p class="text-muted">Quantidade de Aulas Práticas:</p>
            <p><strong><%= Discipline.PractiseClassesCount %></strong></p>
        </div>

    </div>

    <div class="col-md-6">

        <div class="panel">
            <p class="text-muted">Quantidade de Créditos:</p>
            <p><strong><%= Discipline.NumberOfCredits %></strong></p>
        </div>

        <div class="panel">
            <p class="text-muted">Horas Aula:</p>
            <p><strong><%= Discipline.Workload %></strong></p>
        </div>

        <div class="panel">
            <p class="text-muted">Horas Relógio:</p>
            <p><strong><%= Discipline.ClockHours %></strong></p>
        </div>

    </div>
</div>

<span class="clearfix"></span>

<ctrl:Footer runat="server" ID="ctrlFooter" />
