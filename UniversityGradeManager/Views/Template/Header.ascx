<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="UniversityGradeManager.Views.Template.Header" %>
<!DOCTYPE html>

<html lang="pt">

<head>
    <title><%= TitlePage %></title>

    <link rel="stylesheet" runat="server" media="screen" href="/resources/css/bootstrap.min.css" />
</head>

<body>

    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <div class="navbar-header">
                <a class="navbar-brand" href="/">GGU</a>
            </div>
            <div id="navbar" class="collapse navbar-collapse">
                <ul class="nav navbar-nav">
                    <li><a href="/">Cursos</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="container">
