﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Graduation.ascx.cs" Inherits="UniversityGradeManager.Views.Template.GraduationGrade.Graduation" %>
<%@ Register TagPrefix="ctrl" TagName="Period" Src="~/Views/Template/GraduationGrade/Period.ascx" %>

<div class="row">
    <h1 class="page-header"><a href="/Views/Graduation/profile.aspx?Id=<%= Entity.Id %>">Curso <%= Entity.Name %></a></h1>

    <asp:Repeater runat="server" ID="rptPeriods" DataSource="<%# Entity.Periods %>">
        <ItemTemplate>
            <ctrl:Period runat="server" ID="ctrlPeriod" Entity="<%# Container.DataItem %>" />
            <br />
        </ItemTemplate>
    </asp:Repeater>

</div>
