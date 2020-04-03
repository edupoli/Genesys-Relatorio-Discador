﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Genesys
{
    public partial class usuarios1 : System.Web.UI.Page
    {
        int id;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridUsuarios.Visible = false;
            painelErroGrid.Visible = false;
            Listar();
        }
        private void Listar()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["genesysConnectionString"].ConnectionString;
            //using (MySqlConnection cn = new MySqlConnection(connStr))
            MySqlConnection cn = new MySqlConnection(connStr);
            string sql;
            MySqlCommand cmd;
            //con.AbrirCon();
            cn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "SELECT * FROM usuarios ORDER BY nome ASC";
            cmd = new MySqlCommand(sql, cn);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GridUsuarios.Visible = true;
                GridUsuarios.DataSource = dt;
                GridUsuarios.DataBind();
            }
            else
            {
                GridUsuarios.Visible = false;
                painelErroGrid.Visible = true;
                gridMensagemErro.Text = "Não existem Usuários Cadastrados!";
            }
            con.FecharCon();

        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //envia para a pagina addUser o ID como parametro
            id = Convert.ToInt32((sender as Button).CommandArgument);
            Response.Redirect("addUser.aspx?id=" + id);


        }


        protected void btnExcluir_Click(object sender, EventArgs e)
        {

            id = Convert.ToInt32((sender as Button).CommandArgument);
            Excluir();
            Listar();
        }
        public void Excluir()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["genesysConnectionString"].ConnectionString;
            MySqlConnection cn = new MySqlConnection(connStr);
            string sql;
            MySqlCommand cmd;
            //con.AbrirCon();
            cn.Open();
            sql = "DELETE FROM usuarios WHERE userId =@id";
            cmd = new MySqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            ClientScript.RegisterStartupScript(GetType(), "Popup", "Sucesso();", true);
            return;
            con.FecharCon();
            Response.Redirect("pabx.aspx");
        }
    }
}