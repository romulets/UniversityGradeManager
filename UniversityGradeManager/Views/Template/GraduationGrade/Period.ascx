<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Period.ascx.cs" Inherits="UniversityGradeManager.Views.Template.GraduationGrade.Period" %>
<%@ Register TagPrefix="ctrl" TagName="Discipline" Src="~/Views/Template/GraduationGrade/Discipline.ascx" %>

<table class="table table-striped">
    <tr>
        <th colspan="6"><%= Entity.Number %>° Período</th>
    </tr>
    <tr>
        <th>Disciplinas</th>
        <th>AT</th>
        <th>AP</th>
        <th>CRED</th>
        <th>HA</th>
        <th>HR</th>
    </tr>

     <asp:Repeater runat="server" ID="rptPeriods" DataSource="<%# Entity.Discplines %>">
        <ItemTemplate>
            <ctrl:Discipline runat="server" ID="ctrlDiscipline" Entity="<%# Container.DataItem %>" />
        </ItemTemplate>
    </asp:Repeater>

    <tr>
        <td><strong>Total</strong></td>
        <td><strong><%= Entity.TheorycClassesCount %></strong></td>
        <td><strong><%= Entity.PractiseClassesCount %></strong></td>
        <td><strong><%= Entity.NumberOfCredits %></strong></td>
        <td><strong><%= Entity.Workload %></strong></td>
        <td><strong><%= Entity.ClockHours %></strong></td>
    </tr>
</table>
