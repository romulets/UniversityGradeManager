<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="UniversityGradeManager.Views.Template.Header" %>
<!DOCTYPE html>

<html lang="pt">

<head>
    <title><%= TitlePage %></title>

    <link rel="stylesheet" runat="server" media="screen" href="/resources/css/bootstrap.min.css" />
    <link rel="stylesheet" runat="server" media="screen" href="/resources/css/bootstrap-theme.min.css" />
</head>

<body>

    <nav class="navbar navbar-inverse">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
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
