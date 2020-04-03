using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Genesys
{
    public partial class _Default : Page
    {
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // VinculaRegistros();
                cboxCampanha.Visible = false;
                lblCampanha.Visible = false;
            }
        }

        protected void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            if (TextInicial.Text =="" || TextInicial.Text == " ")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "datainicio();", true);
            }
            else if (TextFinal.Text =="" || TextFinal.Text == " ")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "datafim();", true);
            }
            else
            if (rbResultadoChama.Checked == false && rbCPF.Checked ==false && rbTelefone.Checked ==false)
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroSemEscolha();", true);
            }
            if (rbResultadoChama.Checked == true)
            {
                if (cboxCallResult.SelectedValue=="TODAS")
                {
                    string url;
                    url = "relResultadoChamadas1.aspx?dataInicial=" + TextInicial.Text + "&dataFinal=" + TextFinal.Text + "&campanha=" + cboxCampanha.SelectedValue;
                    Response.Redirect(url);
                }
                else
                {
                    string url;
                    url = "relResultadoChamadas.aspx?dataInicial=" + TextInicial.Text + "&dataFinal=" + TextFinal.Text + "&campanha=" + cboxCampanha.SelectedValue + "&call_result=" + cboxCallResult.SelectedValue;
                    Response.Redirect(url);
                }
                
            }

            else if (rbCPF.Checked == true)
            {
                string url;
                url = "relCPFCNPJ.aspx?dataInicial=" + TextInicial.Text + "&dataFinal=" + TextFinal.Text + "&campanha=" + cboxCampanha.SelectedValue + "&cpf_cnpj=" + TextCpfCnpj.Text;
                Response.Redirect(url);
            }
            else if (rbTelefone.Checked == true)
            {
                string url;
                url = "relTelefone.aspx?dataInicial=" + TextInicial.Text + "&dataFinal=" + TextFinal.Text + "&campanha=" + cboxCampanha.SelectedValue + "&phone=" + TextTelefone.Text;
                Response.Redirect(url);
            } /*
            else
            {
                if (rbChamaEntrada.Checked == true)
                {
                    string url;
                    url = "relChamadasURA.aspx?dataInicial=" + txtdataInicial.Text + "&dataFinal=" + txtdataFinal.Text + "&ura=" + cboxUra.SelectedValue;
                    Response.Redirect(url);
                }
            }
            if (rbResolvURA.Checked == false && rbChamaEntrada.Checked == false && rbChamadasAb.Checked == false)
            {
                painelErro.Visible = true;
                lblMensagemErro.Visible = true;
                lblMensagemErro.Text = "Selecione um Tipo de Relatório!";
            }
            if (txtdataInicial.Text == "")
            {
                painelErro.Visible = true;
                lblMensagemErro.Visible = true;
                lblMensagemErro.Text = "Selecione uma Data Inicial!";
            }
            if (txtdataFinal.Text == "")
            {
                painelErro.Visible = true;
                lblMensagemErro.Visible = true;
                lblMensagemErro.Text = "Selecione uma Data Final!";
            }
            if (cboxUra.SelectedIndex == 0)
            {
                painelErro.Visible = true;
                lblMensagemErro.Visible = true;
                lblMensagemErro.Text = "Selecione a URA na qual deseja gerar o Relatório";
            }*/
        }

        protected void rbResultadoChama_CheckedChanged(object sender, EventArgs e)
        {
            cboxCampanha.Visible = true;
            lblCampanha.Visible = true;
            
        }

        protected void rbCPF_CheckedChanged(object sender, EventArgs e)
        {
            cboxCampanha.Visible = false;
            lblCampanha.Visible = false;
        }

        protected void rbTelefone_CheckedChanged(object sender, EventArgs e)
        {
            cboxCampanha.Visible = false;
            lblCampanha.Visible = false;
        }
        /*
void VinculaRegistros()
{
ChartGraficos.Legends.Clear();
ChartGraficos.Series.Clear();
ChartGraficos.ChartAreas.Clear();
using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexaoGenesys"].ToString()))
{
using (SqlCommand cmd = new SqlCommand())
{
cmd.Connection = con;
cmd.CommandText = "SELECT COUNT('chain_id') as contatos FROM gen_ocs.dbo.CL_2895_229";
cmd.CommandType = System.Data.CommandType.Text;
using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
{
using (DataSet ds = new DataSet())
{
sda.Fill(ds);
if (ds.Tables.Count > 0)
{
List<string> ChartAreaList = new List<string>();
ChartAreaList.Add("Contatos");

int i = 0;
String xTitle = "";
String yTitle = "";
for (i = 0; i < ds.Tables.Count; i++)
{
if (ds.Tables[i].Rows.Count > 0)
{
    ChartGraficos.ChartAreas.Add(ChartAreaList[i]);
    xTitle = ""; yTitle = "";
    ChartGraficos.Series.Add(ChartAreaList[i]);
    if (ChartAreaList[i] == "Contatos")
    {
        xTitle = "contatos";
        yTitle = "contatos";
        ChartGraficos.Series[ChartAreaList[i]].ChartType = SeriesChartType.Column;
    }
    if (ChartAreaList[i] == "Country")
    {
        xTitle = "ShipCountry";
        yTitle = "orders";
        ChartGraficos.Series[ChartAreaList[i]].ChartType = SeriesChartType.SplineArea;
    }
    if (ChartAreaList[i] == "Employee")
    {
        xTitle = "Employee";
        yTitle = "orders";
        ChartGraficos.Series[ChartAreaList[i]].ChartType = SeriesChartType.Bubble;
    }
    if (ChartAreaList[i] == "Company")
    {
        xTitle = "Company";
        yTitle = "orders";
        ChartGraficos.Series[ChartAreaList[i]].ChartType = SeriesChartType.Range;
    }
    DefineCaracteristicasGrafico(0, ChartGraficos, ChartAreaList[i], xTitle, yTitle);
    ChartGraficos.ChartAreas[ChartAreaList[i]].AlignWithChartArea = ChartAreaList[i];
    ChartGraficos.Series[ChartAreaList[i]].IsValueShownAsLabel = true;
    ChartGraficos.Series[ChartAreaList[i]].Palette = ChartColorPalette.Bright;
    ChartGraficos.Series[ChartAreaList[i]].ChartArea = ChartAreaList[i];
    ChartGraficos.Series[ChartAreaList[i]]["DrawingStyle"] = "Cylinder";
    ChartGraficos.Series[ChartAreaList[i]].Points.DataBindXY(ds.Tables[i].DefaultView, xTitle, ds.Tables[i].DefaultView, yTitle);
}
}
}
}
}
}
}
}
void DefineCaracteristicasGrafico(int a, Chart tmpChart, String tmpArea, String xTitle, String yTitle)
{
if (a == 0)
{
tmpChart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
tmpChart.BorderlineColor = System.Drawing.Color.FromArgb(26, 59, 105);
tmpChart.BorderlineWidth = 2;
tmpChart.BackColor = Color.Silver;
}
if (a == 1)
{
tmpChart.ChartAreas[tmpArea].BorderDashStyle = ChartDashStyle.Solid;
tmpChart.ChartAreas[tmpArea].BorderWidth = 1;
tmpChart.ChartAreas[tmpArea].BackColor = Color.White;
tmpChart.ChartAreas[tmpArea].BorderColor = Color.Black;
tmpChart.ChartAreas[tmpArea].AxisX.Title = xTitle;
tmpChart.ChartAreas[tmpArea].AxisX.TitleFont = new System.Drawing.Font("Verdana", 10, System.Drawing.FontStyle.Bold);
tmpChart.ChartAreas[tmpArea].AxisX.Minimum = 0;
tmpChart.ChartAreas[tmpArea].AxisX.Interval = 1;
tmpChart.ChartAreas[tmpArea].AxisX.MajorGrid.Enabled = false;
tmpChart.ChartAreas[tmpArea].AxisY.Title = yTitle;
tmpChart.ChartAreas[tmpArea].AxisY.TitleFont = new System.Drawing.Font("Verdana", 10, System.Drawing.FontStyle.Bold);
tmpChart.ChartAreas[tmpArea].AxisY2.LineColor = Color.Black;
tmpChart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
tmpChart.ChartAreas[tmpArea].AxisX.LabelStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
tmpChart.ChartAreas[tmpArea].AxisY.LabelStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
tmpChart.ChartAreas[tmpArea].AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
tmpChart.ChartAreas[tmpArea].AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
}
} */
    } 
}

