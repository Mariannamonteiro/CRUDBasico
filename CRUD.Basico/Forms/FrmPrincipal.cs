﻿using CRUD.Basico.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.Basico
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
           
            try
            {
                Aluno novoAluno = new Aluno(TxbNome.Text, DtpDtNascimento.Value, CkbAtivo.Checked);
                novoAluno.Cadastrar();
                MessageBox.Show($"Aluno cadastrado com sucesso:\n {novoAluno.Nome}\nId inserido pelo banco: {novoAluno.Id}");
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                List<Aluno> alunos = new Aluno().ObterAlunos();
                DgvAlunos.DataSource = alunos.Where(a => a.Ativo).ToList();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
