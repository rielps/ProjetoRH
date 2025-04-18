<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PessoaSalario.aspx.cs" Inherits="ProjetoRH1.PessoaSalario" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gerenciamento de Pessoas e Salários</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/estilos.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container p-4">

            <!-- Label para mensagens gerais -->
            <asp:Label ID="lblMensagem" runat="server" Visible="false" />

            <!-- Seção CRUD de Pessoas -->
            <div class="form-section">
                <h2>Cadastro e Gerenciamento de Pessoas</h2>
                <div class="row g-3 mb-3">

                    <div class="col-md-3">
                        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" Placeholder="Nome" />
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtCidade" runat="server" CssClass="form-control" Placeholder="Cidade" />
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" />
                    </div>

                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlCargo" runat="server" CssClass="form-select" />
                    </div>
                        
                </div>
                <asp:Button ID="btnAdicionarPessoa" runat="server" Text="Adicionar Pessoa" CssClass="btn btn-primary mb-3" OnClick="btnAdicionarPessoa_Click" />
                <asp:GridView ID="gvPessoas" runat="server" CssClass="grid-table" AutoGenerateColumns="False" DataKeyNames="id"
                    OnRowEditing="gvPessoas_RowEditing" OnRowCancelingEdit="gvPessoas_RowCancelingEdit"
                    OnRowUpdating="gvPessoas_RowUpdating" OnRowDeleting="gvPessoas_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="nome" HeaderText="Nome" />
                        <asp:BoundField DataField="cidade" HeaderText="Cidade" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:BoundField DataField="cargo_id" HeaderText="Cargo ID" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>

            <!-- Seção de Salários -->
            <div class="form-section">
                <h2>Lista de Salários</h2>
                <asp:Button ID="btnCalcularSalarios" runat="server" Text="Calcular Salários" CssClass="btn btn-success mb-3" OnClick="btnCalcularSalarios_Click" />
                <asp:GridView ID="gvSalarios" runat="server" AutoGenerateColumns="False" CssClass="grid-table">
                    <Columns>
                        <asp:BoundField DataField="pessoa_id" HeaderText="Pessoa ID" />
                        <asp:BoundField DataField="salario" HeaderText="Salário" DataFormatString="R$ {0:N2}" HtmlEncode="false" />
                        <asp:BoundField DataField="data_inicio" HeaderText="Data Início" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="data_fim" HeaderText="Data Fim" DataFormatString="{0:dd/MM/yyyy}" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </form>
</body>
</html>
