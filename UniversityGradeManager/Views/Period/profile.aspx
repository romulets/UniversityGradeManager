<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="UniversityGradeManager.Views.Period.profile" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Period" Src="~/Views/Template/GraduationGrade/Period.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Perfil do período" />

<h1 class="page-header">Curso <%= Period.Graduation.Name %> - <%= Period.Number %>° período</h1>

<ctrl:Period runat="server" ID="ctrlPeriod" Entity="<%# Period %>" />

<ctrl:Footer runat="server" ID="ctrlFooter" />
