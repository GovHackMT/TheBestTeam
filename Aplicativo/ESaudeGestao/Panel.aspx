<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Panel.aspx.cs" Inherits="ESaudeGestao.Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="/content/Panel.css" type="text/css" />
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet">

    <div class="nav-side-menu">
        <div class="logo">
            <img src="Content/logo.png" style="width: 300px; height: 100px" />
        </div>
        <i class="fa fa-bars fa-2x toggle-btn" data-toggle="collapse" data-target="#menu-content"></i>

        <div class="menu-list">

            <ul id="menu-content" class="menu-content collapse out">
                <li>
                    <a href="#">
                        <i class="fa fa-comment fa-lg"></i>Denúncias
                  </a>
                </li>

                <li data-toggle="collapse" data-target="#gerenciamento" class="collapsed active">
                    <a href="#"><i class="fa fa-gear fa-lg"></i>Gerenciamento<span class="arrow"></span></a>
                </li>
                <ul class="sub-menu collapse" id="gerenciamento">
                    <li><a href="#">Tipos de Denúncias</a></li>
                    <li><a href="#">Agentes Fiscais</a></li>
                </ul>

                <li>
                    <a href="#">
                        <i class="fa fa-sign-out fa-lg"></i>Sair
                  </a>
                </li>
            </ul>
        </div>

    </div>

    <div class="page-content inset content-ativo">
        <div class="row">
            <div class="col-md-12">
                <p class="well lead">Teste</p>
            </div>
        </div>
    </div>


</asp:Content>
