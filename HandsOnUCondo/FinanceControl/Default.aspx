<%@ Page Title="Controle Finanças - HandsOn" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandsOnUCondo.FinanceControl" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <html xmlns="http://www.w3.org/1999/xhtml">

    <body>
        <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" />
        <script src="Bootstrap/js/jquery-1.11.2.min.js"></script>
        <script src="Bootstrap/js/bootstrap.min.js"></script>

        <form id="formMain" class="flex-column">
            <div class="col-md-12 gap-4" style="display: flex; flex-direction: row;">
                <div id="filter" style="width: 20%; border-right: 1px solid; border-right-color: darkgrey; ">
                    <h4 class="text-black-50">Filtros</h4>
                    <div style="margin-top: 5px;">
                        <div class="col-md-12">
                            <div class="col" style="margin-top: 5px; margin-right: 15px;">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="text-black fw-semibold" for="nameField">Id</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="tbIdFinances" CssClass="form-control rounded-2" Height="48" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 mt-1">
                                    <div class="form-group">
                                        <label class="text-black fw-semibold" for="nameField">Descrição</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="tbDescription" CssClass="form-control rounded-2" Height="48" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 mt-1">
                                    <div class="form-group">
                                        <label class="text-black fw-semibold" for="nameField">Status</label>
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddlStatus" CssClass="form-control rounded-2" Height="48" runat="server">
                                                <asp:ListItem Value="Todos" Text="Todos" Selected="True"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 mt-1">
                                    <div class="form-group">
                                        <label class="text-black fw-semibold" for="nameField">De</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="tbExpirationDate1" CssClass="form-control rounded-2" ReadOnly="true" runat="server"></asp:TextBox>
                                            <asp:ImageButton ID="iBtnFrom" runat="server" OnClick="iBtnFrom_Click" ImageUrl="~/assets/icons/calendar.png" CssClass="btn fw-semibold h-25 w-25" />
                                        </div>
                                        <asp:Calendar ID="ExpirationDate1" CssClass="form-control rounded-2" OnSelectionChanged="ExpirationDate1_SelectionChanged" Visible="false" runat="server"></asp:Calendar>
                                    </div>
                                </div>
                                <div class="col-md-12 mt-1">
                                    <div class="form-group">
                                        <label class="text-black fw-semibold" for="nameField">Até</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="tbExpirationDate2" CssClass="form-control rounded-2" ReadOnly="true" runat="server"></asp:TextBox>
                                            <asp:ImageButton ID="iBtnUntil" runat="server" OnClick="iBtnUntil_Click" ImageUrl="~/assets/icons/calendar.png" CssClass="btn fw-semibold h-25 w-25" />
                                        </div>
                                        <asp:Calendar ID="ExpirationDate2" CssClass="form-control rounded-2" OnSelectionChanged="ExpirationDate2_SelectionChanged" Visible="false" runat="server"></asp:Calendar>
                                    </div>
                                </div>
                                <div class="col-md-12 mt-3" style="display: flex; flex-direction: row-reverse; justify-content: flex-start;">
                                    <asp:Button ID="btnFilter" runat="server" Text="Filtrar" CssClass="btn btn-success fw-semibold" OnClick="btnFilter_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="register" style="width: 80%;">
                    <h4 class="text-black-50">Controle Financeiro</h4>
                    <div style="border-color: darkgrey; border-width: thin; border-style: outset; margin-top: 5px;">
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
                    </div>
                </div>
            </div>

            <div id="gridUsers">
                <asp:GridView ID="GridViewFinances" DataSourceID="SqlDataSourceFinanceList" CssClass="table table-bordered table-hover table-responsive text-black" HeaderStyle-BackColor="#836dca" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="#" InsertVisible="False" ReadOnly="True" SortExpression="UserId" />
                        <asp:BoundField DataField="IdStatus" HeaderText="Status" SortExpression="Status" />
                        <asp:BoundField DataField="Description" HeaderText="Descrição" SortExpression="Description" />
                        <asp:TemplateField HeaderText="Dt. Criação">
                            <ItemTemplate>
                                <asp:Calendar runat="server"></asp:Calendar>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FinanceValue" HeaderText="Valor" SortExpression="FinanceValue" />
                        <asp:BoundField DataField="ExpirationDate" HeaderText="Dt. Vencimento" SortExpression="ExpirationDate" />
                        <asp:BoundField DataField="FinancePeriod" HeaderText="Periodicidade" SortExpression="Periodicidade" />
                        <asp:BoundField DataField="FinanceType" HeaderText="Tipo Receita" SortExpression="Periodicidade" />
                        <asp:TemplateField HeaderText="Ações" HeaderStyle-Width="142px">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" Text="Editar" runat="server" ControlStyle-CssClass="bg-primary border w-auto flex-wrap" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnDelete" Text="Deletar" runat="server" ControlStyle-CssClass="bg-danger border w-auto" CommandName="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <asp:SqlDataSource ID="SqlDataSourceFinanceList" runat="server"
                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="FinanceList"
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="tbIdFinances" ConvertEmptyStringToNull="False" DefaultValue="" Name="Id" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="tbDescription" ConvertEmptyStringToNull="False" DefaultValue="" Name="Description" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="ddlStatus" ConvertEmptyStringToNull="False" DefaultValue="3" Name="IdStatus" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="tbExpirationDate1" ConvertEmptyStringToNull="False" DefaultValue="" Name="ExpirationDate1" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="tbExpirationDate2" ConvertEmptyStringToNull="False" DefaultValue="" Name="ExpirationDate2" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="SqlDataSourceStatus" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM Status" SelectCommandType="Text" />
            </div>
        </form>
    </body>
    </html>
</asp:Content>

