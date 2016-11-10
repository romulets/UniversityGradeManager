<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fullgrade.aspx.cs" Inherits="UniversityGradeManager.Views.Graduation.fullgrade" %>

<%@ Register TagPrefix="ctrl" TagName="Header" Src="~/Views/Template/Header.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Footer" Src="~/Views/Template/Footer.ascx" %>
<%@ Register TagPrefix="ctrl" TagName="Graduation" Src="~/Views/Template/GraduationGrade/Graduation.ascx" %>

<ctrl:Header runat="server" ID="ctrlHeader" TitlePage="Grade Completa" />
<ctrl:Graduation runat="server" ID="ctrlGraduation" Entity="<%# Graduation %>" />
<ctrl:Footer runat="server" ID="ctrlFooter" />
