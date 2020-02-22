using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
           try
            {
                int id = int.Parse(txtId.Text);
                string placa = txtPlaca.Text;
                string fabricante = txtFabricante.Text;
                string modelo = txtModelo.Text;
                int ano = int.Parse(txtAno.Text);
                double preco = double.Parse(txtPreco.Text);

                Veiculo objVeiculo = new Veiculo();
                objVeiculo.Id = id;
                objVeiculo.Placa = placa;
                objVeiculo.fabricante = fabricante;
                objVeiculo.Modelo = modelo;
                objVeiculo.Ano = ano;
                objVeiculo.Preco = preco;

                objVeiculo.Cadastrar();

                MessageBox.Show("Operação realizada com sucesso");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar " + ex.Message,
                    "Falha na operação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Veiculo objVeiculo = new Veiculo();

            dgvCarros.DataSource = objVeiculo.Listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);

                Veiculo objVeiculo = new Veiculo();
                objVeiculo.Id = id;

                objVeiculo.Excluir();

                MessageBox.Show("Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar excluir. " + ex.Message, "falha na operação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string placa = txtPreco.Text;
                string fabricante = txtFabricante.Text;
                string Modelo = txtModelo.Text;
                int ano = int.Parse(txtAno.Text);
                double preco = double.Parse(txtPreco.Text);

                Veiculo objJogo = new Veiculo();
                objJogo.Id = id;
                objJogo.Placa = placa;
                objJogo.fabricante = fabricante;
                objJogo.Modelo = Modelo;
                objJogo.Ano = ano;
                objJogo.Preco = preco;

                objJogo.Atualizar();

                MessageBox.Show("operação realizada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar atualizar. " + ex.Message, "falha na operação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
