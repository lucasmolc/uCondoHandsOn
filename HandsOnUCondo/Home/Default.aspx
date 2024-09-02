<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandsOnUCondo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="pageTitle">
            <h1 id="pageTitle">HandsOn uCondo - Lucas Mol</h1>
            <p class="lead">Projeto criado para a terceira etapa do processo seletivo da uCondo!</p>
            <p style="font-size: small;">O projeto pode ser acessado através do GitHub! Solicite ao criador que o adicione como colaborador.</p>
            <p><a href="https://github.com/lucasmolc/uCondoHandsOn" class="btn btn-md" style="background-color: rgb(135,113,209)">Github &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-12" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Getting started</h2>
                <ul style="list-style-type: disclosure-closed">
                    <li>O projeto consiste das seguintes telas: Login, Usuários e Controle Financeiro.</li>
                    <li>O Login é realizado por 'E-Mail' e 'Senha' (Senha criptografada utilizando MD5Security).</li>
                    <li>Na tela de usuários é possivel cadastrar novos usuários, editar e excluir. Esta tela só é acessada após o usuario se autenticar na tela de Login.</li>
                    <li>Na tela de Controle Financeiro, pode cadastrar novos lançamentos de Receita (Saldo Positivo) e lançamentos de Despesas (Saldo Negativo). Estes lançamentos devem conter:<br />
                        Data de Vencimento, Valor, Descrição, Status (Aberto ou Quitado), Periodicidade (Unica ou Mensal. Mensal deve se repetir no mesmo dia todo mês por pelo menos 24 meses).
                        <br />Na tela também contém um filtro onde o usuário pode selecionar todas receitas e despesas do mês ou dia selecionado.</li>
                    <li>Técnologias utilizadas: ASP.NET, C#, MasterPages, HTML, Bootstrap, JavaScript, CSS e SQLServer</li>
                </ul>
            </section>
        </div>
    </main>

</asp:Content>
