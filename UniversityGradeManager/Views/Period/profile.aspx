<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="UniversityGradeManager.Views.Period.profile" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Period" Src="~/Views/Template/GraduationGrade/Period.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Perfil do período" />

<h1 class="page-header">Curso <%= Period.Graduation.Name %> - <%= Period.Number %>° período</h1>

<div class="row margin-bottom-md">
    <div class="col-md-6 text-left">
        <a href="../Graduation/profile.aspx?Id=<%= Period.Graduation.Id %>" class="btn btn-default">Voltar para o Curso</a>
    </div>

    <div class="col-md-6 text-right">
        <a href="../Discipline/add.aspx?Graduation=<%= Period.Graduation.Id %>&Period=<%= Period.Number %>" class="btn btn-success">Adicionar Disciplina</a>

        <a href="../Period/delete.aspx?Graduation=<%= Period.Graduation.Id %>&Period=<%= Period.Number %>" class="btn btn-danger">Deletar Período</a>
    </div>
</div>

<span class="clearfix"></span>

<ctrl:Period runat="server" ID="ctrlPeriod" Entity="<%# Period %>" />

<ctrl:Footer runat="server" ID="ctrlFooter" />
