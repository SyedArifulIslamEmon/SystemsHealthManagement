using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Reflection;

namespace Integra.Repositorio.EF
{
    public class DaoBase<T> where T : new()
    {
        public List<SqlParameter> Parametros { get; private set; }
        public StringBuilder Comando { get; private set; }

        public DaoBase()
        {
            Comando = new StringBuilder();
            Parametros = new List<SqlParameter>();
        }
        protected void Limpar()
        {
            Comando.Remove(0, Comando.Length);
            Parametros.Clear();
        }
        public T criarItem()
        {
            return (T)typeof(T).GetConstructor(new Type[] { }).Invoke(new object[] { });
        }

        protected void AdicionarParametro(string parametro, object valor)
        {
            Parametros.Add(new SqlParameter(parametro, valor));
        }
        protected SqlDataReader ExecutarDataReader()
        {
            //Variáveis utilizadas para efetuar o retorno dos dados em um DataReader.
            SqlDataReader rdr = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            //Configura a conectionString do acesso a dados.
            con = GetConexaoBd();
            //Abre a conexão com o banco de dados.
            con.Open();
            //Configura o comando a ser executado.
            cmd = new SqlCommand(Comando.ToString());
            //Configura a conexão do comando.
            cmd.Connection = con;

            //----------------------Modo alternativo de parametros SQL-----------------------------------------//
            //
            //string sql = "SELECT ProductID, ProductName, UnitPrice" +
            //      " FROM Products" +
            //      " WHERE (ProductName LIKE @nomeProduto)" +
            //      " ORDER BY ProductID";
            //
            //cmd.Parameters.Add(new SqlParameter("@nomeProduto",System.Data.SqlDbType.NVarChar,20,"ProductName"));
            //cmd.Parameters.Add(new SqlParameter("","a"));
            //cmd.Parameters["@nomeProduto"].Value = txtProduto.Text + "%";
            //
            //----------------------Fim Modo alternativo de parametros SQL-------------------------------------//

            //Efe
            rdr = cmd.ExecuteReader();
            //Retorna os dados.
            return rdr;
        }
        public List<T> ExecutarLista()
        {
            int Contador = 0;
            SqlDataReader dr = ExecutarDataReader();
            var container = new List<T>();
            while (dr.Read())
            {
                T item = criarItem();
                foreach (PropertyInfo pinfo in item.GetType().GetProperties())
                {
                    //var attr = Attribute.GetCustomAttribute(pinfo, typeof(DaoCampo)) as DaoCampo;
                    //if (attr != null)
                    //pinfok.SetValue(item, Convert.ChangeType(dr[((DaoCampo)attr).Campo], pinfo.PropertyType), new object[] { });
                    pinfo.SetValue(item, Convert.ChangeType(dr[Contador].ToString(), pinfo.PropertyType), new object[] { });
                    Contador++;
                }
                Contador = 0;
                container.Add(item);
            }
            return container;
        }

        public SqlConnection GetConexaoBd()
        {
            //obtem a string de conexão do App.Config e retorna uma nova conexao
            string strConexao = ConfigurationManager.ConnectionStrings["IntegraReportConnectionString"].ConnectionString;
            return new SqlConnection(strConexao);
        }


        public List<T> ExecutarListaProcedure(string pstrProcedure)
        {
            int cont = 0;
            var dr = ExecutarDataReaderProcedure(pstrProcedure);
            var container = new List<T>();
            while (dr.Read())
            {
                T item = criarItem();
                foreach (PropertyInfo pinfo in item.GetType().GetProperties())
                {
                    //var attr = Attribute.GetCustomAttribute(pinfo, typeof(DaoCampo)) as DaoCampo;
                    //if (attr != null)
                    //pinfok.SetValue(item, Convert.ChangeType(dr[((DaoCampo)attr).Campo], pinfo.PropertyType), new object[] { });
                    pinfo.SetValue(item, Convert.ChangeType(dr[cont].ToString(), pinfo.PropertyType), new object[] { });
                    cont++;
                }
                cont = 0;
                container.Add(item);
            }
            return container;
        }

        public SqlDataReader ExecutarDataReaderProcedure(string pstrProcedure)
        {
            //Variáveis utilizadas para efetuar o retorno dos dados em um DataReader.
            SqlDataReader Sqldr = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
            
            con = GetConexaoBd();
            cmd = new SqlCommand(pstrProcedure, con) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddRange(Parametros.ToArray());
            con.Open();
            Sqldr = cmd.ExecuteReader();
            //Retorna os dados.
            return Sqldr;

        }

    }
    public class DaoCampo : System.Attribute
    {
        public string Campo { get; set; }
        public DaoCampo(string campo)
        {
            Campo = campo;
        }
    }
}
