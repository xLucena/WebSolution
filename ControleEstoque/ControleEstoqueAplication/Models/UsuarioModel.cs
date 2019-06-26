using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoqueAplication.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login,string senha)
        {
            var ret = false;
            using (var conexao = new SqlConnection())
            {
                //ADO.NET

                //Criando a conexao, informando o banco com a string de conexao
                //Conexao string serve pra realizar a conexao com banco de dados, para acessa-lo, usuario e senha
                //foi passado o nome do banco, o login, e a senha do BD
                conexao.ConnectionString = @"Data Source = DESKTOP-TMOPBME\LUCENA;Initial Catalog=controle-estoque;User Id=admin;Password=123";
                conexao.Open();
                //criando um comando SQlcomamnd para realizar um comando em sql
                using (var comando = new SqlCommand())
                {
                    //Associando a conexao e colocando o comando que vai buscar do banco, usuario dentro do sistema, pra entrar na tela de login
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("select count(*) from usuario where login = '{0}' and senha = '{1}'", login, senha);
                    //retornando um valor inteiro com Scalar, vendo se O RETORNO EH MAIOR QUE 0
                    ret=((int)comando.ExecuteScalar() > 0);
                }
            }
            return ret;
        }
    }
}