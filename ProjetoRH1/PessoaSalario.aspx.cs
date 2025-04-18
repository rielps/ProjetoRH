using System;
using System.Data;
using System.Web.UI.WebControls;
using Npgsql;

namespace ProjetoRH1
{
    public partial class PessoaSalario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarCargos();
                CarregarPessoas();
                CarregarSalarios();
            }
        }

        private void CarregarCargos()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConn"].ConnectionString;
            string query = "SELECT id, nome FROM cargo ORDER BY nome";
            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    ddlCargo.Items.Clear();
                    while (reader.Read())
                        ddlCargo.Items.Add(new ListItem(reader["nome"].ToString(), reader["id"].ToString()));
                }
            }
        }

        private void CarregarPessoas()
        {
            try
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConn"].ConnectionString;
                string query = "SELECT id, nome, cidade, email, cargo_id FROM pessoa ORDER BY id";
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    var da = new NpgsqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    da.Fill(dt);
                    gvPessoas.DataSource = dt;
                    gvPessoas.DataBind();
                }
            }
            catch (Exception ex)
            {
                MostrarMensagem("Erro ao carregar pessoas: " + ex.Message, false);
            }
        }

        protected void btnAdicionarPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string cidade = txtCidade.Text;
                string email = txtEmail.Text;
                int cargoId = int.Parse(ddlCargo.SelectedValue);

                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConn"].ConnectionString;
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO pessoa (nome, cidade, email, cargo_id) VALUES (@nome, @cidade, @email, @cargo_id)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("nome", nome);
                        cmd.Parameters.AddWithValue("cidade", cidade);
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("cargo_id", cargoId);
                        cmd.ExecuteNonQuery();
                    }
                }

                CarregarPessoas();
                MostrarMensagem("Pessoa cadastrada com sucesso!", true);
            }
            catch (Exception ex)
            {
                MostrarMensagem("Erro ao adicionar pessoa: " + ex.Message, false);
            }
        }

        protected void gvPessoas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPessoas.EditIndex = e.NewEditIndex;
            CarregarPessoas();
        }

        protected void gvPessoas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPessoas.EditIndex = -1;
            CarregarPessoas();
        }

        protected void gvPessoas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvPessoas.DataKeys[e.RowIndex].Value);
            string nome = e.NewValues["nome"].ToString();
            string cidade = e.NewValues["cidade"].ToString();
            string email = e.NewValues["email"].ToString();
            int cargoId = Convert.ToInt32(e.NewValues["cargo_id"]);

            try
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConn"].ConnectionString;
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    string query = "UPDATE pessoa SET nome=@nome, cidade=@cidade, email=@email, cargo_id=@cargo_id WHERE id=@id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("nome", nome);
                        cmd.Parameters.AddWithValue("cidade", cidade);
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("cargo_id", cargoId);
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                gvPessoas.EditIndex = -1;
                CarregarPessoas();
                MostrarMensagem("Pessoa atualizada com sucesso!", true);
            }
            catch (Exception ex)
            {
                MostrarMensagem("Erro ao atualizar pessoa: " + ex.Message, false);
            }
        }

        protected void gvPessoas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvPessoas.DataKeys[e.RowIndex].Value);
            try
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConn"].ConnectionString;
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();

                    // Excluir salários primeiro
                    string deleteSalarios = "DELETE FROM pessoasalario WHERE pessoa_id = @id";
                    using (var cmd = new NpgsqlCommand(deleteSalarios, conn))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }

                    // Excluir a pessoa
                    string deletePessoa = "DELETE FROM pessoa WHERE id = @id";
                    using (var cmd = new NpgsqlCommand(deletePessoa, conn))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                CarregarPessoas();
                MostrarMensagem("Pessoa excluída com sucesso!", true);
            }
            catch (Exception ex)
            {
                MostrarMensagem("Erro ao excluir pessoa: " + ex.Message, false);
            }
        }

        protected void btnCalcularSalarios_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConn"].ConnectionString;
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT calcular_salarios();", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                CarregarSalarios();
                MostrarMensagem("Salários recalculados com sucesso!", true);
            }
            catch (Exception ex)
            {
                MostrarMensagem("Erro ao calcular salários: " + ex.Message, false);
            }
        }

        private void CarregarSalarios()
        {
            try
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSqlConn"].ConnectionString;
                string query = "SELECT pessoa_id, salario, data_inicio, data_fim FROM pessoasalario ORDER BY pessoa_id";
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    var da = new NpgsqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    da.Fill(dt);
                    gvSalarios.DataSource = dt;
                    gvSalarios.DataBind();
                }
            }
            catch (Exception ex)
            {
                MostrarMensagem("Erro ao carregar salários: " + ex.Message, false);
            }
        }

        private void MostrarMensagem(string texto, bool sucesso)
        {
            lblMensagem.Visible = true;
            lblMensagem.Text = texto;
            lblMensagem.CssClass = sucesso ? "msg-sucesso" : "msg-erro";
        }
    }
}
