<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="UniversityGradeManager.Views.Graduation.list" %>
<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Graduation" Src="~/Views/Template/GraduationGrade/Graduation.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Listagem de Cursos"/>

    <ctrl:Graduation runat="server" ID="ctrlGraduation" Entity="<%# Graduation %>" />

<ctrl:Footer runat="server" ID="ctrlFooter"/>