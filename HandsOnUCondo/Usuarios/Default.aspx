<%@ Page Title="Usuarios - HandsOn" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandsOnUCondo.Usuarios" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <html xmlns="http://www.w3.org/1999/xhtml">

    <body>
        <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" />
        <script src="Bootstrap/js/jquery-1.11.2.min.js"></script>
        <script src="Bootstrap/js/bootstrap.min.js"></script>

        <form id="formMain">
            <div id="pageHeader">
                <h4 class="text-black-50">Usuarios</h4>
            </div>
            <div id="formCRUD" class="col-md-12">
                <div class="row" style="margin-top: 10px; margin-bottom: 10px;">
                    <div class="row gap-2" style="display: flex; flex-wrap: wrap; flex-direction: row; justify-content: flex-start;">
                        <div class="col-md-3" hidden="hidden">
                            <div class="form-group">
                                <label class="text-black fw-semibold" for="nameField">#</label>
                                <div class="input-group">
                                    <asp:TextBox ID="tbId" CssClass="form-control rounded-2" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="text-black fw-semibold" for="nameField">Nome</label>
                                <div class="input-group">
                                    <asp:TextBox ID="tbName" CssClass="form-control rounded-2" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="text-black fw-semibold" for="mailField">E-Mail</label>
                                <div class="input-group">
                                    <asp:TextBox ID="tbMail" CssClass="form-control rounded-2" TextMode="Email" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="text-black fw-semibold" for="cpfField">CPF</label>
                                <div class="input-group">
                                    <asp:TextBox ID="tbCPF" CssClass="form-control rounded-2" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="text-black fw-semibold" for="passwordField">Senha</label>
                                <div class="input-group">
                                    <asp:TextBox ID="tbPassword" CssClass="form-control rounded-2" TextMode="Password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" style="margin-top: 10px;">
                        <div class="col-md-12 gap-2" style="display: flex; flex-direction: row-reverse; justify-content: flex-start">
                            <asp:Button ID="btnRegister" runat="server" Text="Cadastrar" CssClass="btn btn-success fw-semibold" Enabled="true" OnClick="btnRegister_Click" />
                            <asp:Button ID="btnSave" runat="server" Text="Salvar Alterações" CssClass="btn btn-success fw-semibold" Visible="false" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="gridUsers">
                <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover table-responsive text-black" HeaderStyle-BackColor="#836dca" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="#" InsertVisible="False" ReadOnly="True" SortExpression="UserId" />
                        <asp:BoundField DataField="UserName" HeaderText="Nome" SortExpression="UserName" />
                        <asp:BoundField DataField="UserMail" HeaderText="Email" SortExpression="UserMail" />
                        <asp:BoundField DataField="UserCPF" HeaderText="CPF" SortExpression="UserCPF" />
                        <asp:TemplateField HeaderText="Ações" HeaderStyle-Width="142px">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" Text="Editar" runat="server" ControlStyle-CssClass="bg-primary border w-auto flex-wrap" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnDelete" Text="Deletar" runat="server" ControlStyle-CssClass="bg-danger border w-auto" CommandName="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="SELECT * FROM [Users]"
                    InsertCommand="INSERT INTO [Users] ([UserName], [UserMail], [UserCPF], [UserPassword]) VALUES (@UserName, @UserMail, @UserCPF, @UserPassword)"
                    UpdateCommand="UPDATE [Users] SET [UserName] = @UserName, [UserMail] = @UserMail, [UserCPF] = @UserCPF, [UserPassword] = @UserPassword WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="UserName" Type="String" />
                        <asp:Parameter Name="UserMail" Type="String" />
                        <asp:Parameter Name="UserCPF" Type="String" />
                        <asp:Parameter Name="UserPassword" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </div>
        </form>
    </body>
    </html>
</asp:Content>

