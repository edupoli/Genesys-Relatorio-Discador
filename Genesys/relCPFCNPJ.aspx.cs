using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Genesys
{
    public partial class relCPFCNPJ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dataInicial;
                string dataFinal;
                string campanha;
                string cpf_cnpj;

                dataInicial = Request.QueryString["dataInicial"];
                dataFinal = Request.QueryString["dataFinal"];
                campanha = Request.QueryString["campanha"];
                cpf_cnpj = Request.QueryString["cpf_cnpj"];
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/relCPFCNPJ.rdlc");
                ReportParameter[] parametros = new ReportParameter[4];
                parametros[0] = new ReportParameter("p_dataInicial", dataInicial);
                parametros[1] = new ReportParameter("p_dataFinal", dataFinal);
                parametros[2] = new ReportParameter("p_campanha", campanha);
                parametros[3] = new ReportParameter("p_cpf_cnpj", cpf_cnpj);

                ReportViewer1.LocalReport.SetParameters(parametros);
            }

            ReportViewer1.LocalReport.Refresh();
        }
    }
}