<%@ Page Title="Controle Finanças - HandsOn" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandsOnUCondo.FinanceControl" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <html xmlns="http://www.w3.org/1999/xhtml">

    <body>
        <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" />
        <script src="Bootstrap/js/jquery-1.11.2.min.js"></script>
        <script src="Bootstrap/js/bootstrap.min.js"></script>

        <form id="formMain" class="flex-column">
            <div class="row col-md-12" style="display: flex; flex-direction: column">
            <div class="col-md-12 gap-4" style="display: flex; flex-direction: row;">
                <div id="filter" style="width: 20%; border-right: 1px solid; border-right-color: darkgrey;">
                    <h4 class="text-black-50">Filtros</h4>
                    <div style="margin-top: 5px;">
                        <div class="col-md-12">
                            <div class="col" style="margin-top: 5px; margin-right: 15px;">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="text-black fw-semibold" for="nameField">Id</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="tbIdFinancesFilter" CssClass="form-control rounded-2" Height="48" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 mt-1">
                                    <div class="form-group">
                                        <label class="text-black fw-semibold" for="nameField">Descrição</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="tbDescriptionFilter" CssClass="form-control rounded-2" Height="48" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 mt-1">
                                    <div class="form-group">
                                        <label class="text-black fw-semibold" for="nameField">Status</label>
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddlStatusFilter" CssClass="form-control rounded-2" Height="48" runat="server">
                                                <asp:ListItem Value="Todos" Text="Todos" Selected="True"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 mt-1">
                                    <div class="form-group">
                                        <label class="text-black fw-semibold" for="nameField">De</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="tbExpirationDate1Filter" TextMode="Date" CssClass="form-control rounded-2" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 mt-1">
                                    <div class="form-group">
                                        <label class="text-black fw-semibold" for="nameField">Até</label>
                                        <div class="input-group">
                                            <asp:TextBox ID="tbExpirationDate2Filter" TextMode="Date" CssClass="form-control rounded-2" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 mt-3" style="display: flex; flex-direction: row-reverse; justify-content: flex-start;">
                                    <asp:Button ID="btnFilter" runat="server" Text="Filtrar" CssClass="btn btn-success fw-semibold" OnClick="btnFilter_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="register" style="width: 80%; height: min-content">
                    <h4 class="text-black-50">Controle Financeiro</h4>
                    <div style="margin-top: 5px; border-bottom: 1px solid; border-bottom-color: darkgrey;">
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
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="text-black fw-semibold" for="nameField">Status</label>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddlStatus" CssClass="form-control rounded-2" Height="48" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="text-black fw-semibold" for="mailField">Descrição</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="tbDescription" CssClass="form-control rounded-2" Height="48" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="text-black fw-semibold" for="cpfField">Valor</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="tbValue" CssClass="form-control rounded-2" Height="48" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="text-black fw-semibold" for="passwordField">Dt. Vencimento</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="tbExpiration" TextMode="Date" CssClass="form-control rounded-2" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="text-black fw-semibold" for="passwordField">Periodicidade</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="tbPeriod" CssClass="form-control rounded-2" Height="48" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="text-black fw-semibold" for="nameField">Tipo</label>
                                            <div class="input-group">
                                                <asp:DropDownList ID="ddlType" CssClass="form-control rounded-2" Height="48" runat="server">
                                                    <asp:ListItem Value="1" Text="Receita"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Despesa"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--<div class="form-group">
                                            <label class="text-black fw-semibold" for="passwordField">Tipo</label>
                                            <div class="input-group">
                                                <asp:TextBox ID="tbType" CssClass="form-control rounded-2" runat="server"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>
                                <div class="col-md-12" style="margin-top: 15px;">
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
            <div id="gridUsers" style="margin-top: 10px;">
                <asp:GridView ID="GridViewFinances" DataSourceID="SqlDataSourceFinanceList" OnRowDataBound="GridViewFinances_RowDataBound" CssClass="table table-bordered table-hover table-responsive text-black" HeaderStyle-BackColor="#836dca" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnRowDeleting="GridViewFinances_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="#" InsertVisible="False" ReadOnly="True" SortExpression="UserId" />
                        <asp:BoundField DataField="IdStatus" HeaderText="Status" SortExpression="Status" />
                        <asp:BoundField DataField="Description" HeaderText="Descrição" SortExpression="Description" />
                        <asp:BoundField DataField="FinanceValue" HeaderText="Valor" SortExpression="FinanceValue" />
                        <asp:BoundField DataField="ExpirationDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Dt. Vencimento" SortExpression="ExpirationDate" />
                        <asp:BoundField DataField="FinancePeriod" HeaderText="Periodicidade" SortExpression="Periodicidade" />
                        <asp:BoundField DataField="FinanceType" HeaderText="Tipo" SortExpression="FinanceType" />
                        <asp:BoundField DataField="CreationDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Dt. Criação" SortExpression="CreationDate" />
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
                        <asp:ControlParameter ControlID="tbIdFinancesFilter" ConvertEmptyStringToNull="False" DefaultValue="" Name="Id" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="tbDescriptionFilter" ConvertEmptyStringToNull="False" DefaultValue="" Name="Description" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="ddlStatusFilter" ConvertEmptyStringToNull="False" DefaultValue="3" Name="IdStatus" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="tbExpirationDate1Filter" ConvertEmptyStringToNull="False" DefaultValue="" Name="ExpirationDate1" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="tbExpirationDate2Filter" ConvertEmptyStringToNull="False" DefaultValue="" Name="ExpirationDate2" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <asp:SqlDataSource ID="SqlDataSourceStatus" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM Status" SelectCommandType="Text" />
            </div>
            </div>
        </form>
    </body>
    </html>
</asp:Content>

