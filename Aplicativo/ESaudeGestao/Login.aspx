<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ESaudeGestao.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
     <link rel="stylesheet" href="/content/Login.css" type="text/css" />

    <div class="container">
        <div class="card card-container">
            <h3>E-Saúde - Login Gestão</h3>
            <form class="form-signin">
                <span id="reauth-email" class="reauth-email"></span>

                <div style="margin-bottom: 25px" class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <input id="login-username" type="text" class="form-control" name="user" value="" placeholder="Informe seu Usuário">
                </div>

                <div style="margin-bottom: 25px" class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                    <input id="login-password" type="password" class="form-control" name="password" placeholder="Informe sua Senha">
                </div>

                <div id="remember" class="checkbox">
                    <label>
                        <input type="checkbox" value="remember-me">
                        Lembrar meu acesso?
                   
                    </label>
                </div>
                <button class="btn btn-lg btn-primary btn-block btn-signin" type="submit">Acessar</button>
            </form>
        </div>
    </div>
</asp:Content>
