<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Discipline.ascx.cs" Inherits="UniversityGradeManager.Views.Template.GraduationGrade.Discipline" %>

<tr>
    <td><a href="/Views/Discipline/profile.aspx?Graduation=<%= Entity.Period.Graduation.Id %>&Discipline=<%=Entity.Code %>"><%= Entity.Name %></a></td>
    <td><%= Entity.TheorycClassesCount %></td>
    <td><%= Entity.PractiseClassesCount %></td>
    <td><%= Entity.NumberOfCredits %></td>
    <td><%= Entity.Workload %></td>
    <td><%= Entity.ClockHours %></td>
</tr>
