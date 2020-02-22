using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ex10.Util;
using Npgsql;

namespace Ex10
{
    class Veiculo
    {
        public int Id { get; set;}
        public string Placa { get; set; }
        public string fabricante { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public double Preco { get; set; }

        public Veiculo(){}
        
        public Veiculo(int Id, string Placa, string fabricante, string Modelo, int Ano, double Preco )
        {
            this.Id = Id;
            this.Placa = Placa;
            this.fabricante = fabricante;
            this.Modelo = Modelo;
            this.Ano = Ano;
            this.Preco = Preco;
        }

        public void Cadastrar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();

                string sql = "INSERT INTO veiculo (id, placa, fabricante, modelo, ano, preco) VALUES " +
                    "('" + this.Id + "','" + this.Placa + "' , '" + this.fabricante + "','" + this.Modelo +
                    "','" + this.Ano + "' , '" + this.Preco + "')";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                if(conexao != null)
                {
                    conexao.Close();
                }
            }
        }

        public List<Veiculo> Listar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "SELECT * FROM veiculo";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                List<Veiculo> listaVeiculos = new List<Veiculo>();

                while(dr.Read())
                {
                    Veiculo novoVeiculo = new Veiculo();
                    novoVeiculo.Id = Convert.ToInt16(dr["id"]);
                    novoVeiculo.Placa = dr["placa"].ToString();
                    novoVeiculo.fabricante = dr["fabricante"].ToString();
                    novoVeiculo.Modelo = dr["modelo"].ToString();
                    novoVeiculo.Preco = Convert.ToDouble(dr["preco"]);

                    listaVeiculos.Add(novoVeiculo);
                }
                return listaVeiculos;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if(conexao!= null)
                {
                    conexao.Close();
                }
            }
        }

    public void Excluir()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "delete from veiculo where " + " id" + "=" + this.Id;
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@id", this.Id));
                cmd.ExecuteNonQuery();

            }
            catch ( Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                if(conexao != null)
                {
                    conexao.Close();
                }
            }
        }

        public void Atualizar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "update veiculo set " + " placa " + " = " + "'"+this.Placa+"'" + " , " + " fabricante " + " = " + "'"+this.fabricante+"'" + " , " + " modelo " + " = " + "'"+this.Modelo+"'" + " , " + " ano " + " = " + this.Ano + " , " + " preco " + " = " + this.Preco + " where " + " id " + " = " + this.Id;
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add(new NpgsqlParameter("@placa", this.Placa));
                cmd.Parameters.Add(new NpgsqlParameter("@fabricante", this.fabricante));
                cmd.Parameters.Add(new NpgsqlParameter("@modelo", this.Modelo));
                cmd.Parameters.Add(new NpgsqlParameter("@ano", this.Ano));
                cmd.Parameters.Add(new NpgsqlParameter("@preco", this.Preco));
                cmd.Parameters.Add(new NpgsqlParameter("@id", this.Id));


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }





    }
}
