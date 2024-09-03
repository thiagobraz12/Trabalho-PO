using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cadastroProfessor.Models;
using MySql.Data.MySqlClient;


namespace cadastroProfessor.Mestre
{
    internal class Cadastro_Professor
    {
        public void Insert(Professor professor)
        {
            try
            {
                string dataNascimento = professor.dataNascimento.ToString("yy-MM-dd");
                string sql = "INSERT INTO professor (nome,cpf,email,telefone,dataNascimento,sexo,formacao) VALUES(@nome,@cpf,@email,@telefone,@dataNascimento,@sexo,@formacao)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@nome", professor.nome);
                comando.Parameters.AddWithValue("@cpf", professor.Cpf);
                comando.Parameters.AddWithValue("@email", professor.Email);
                comando.Parameters.AddWithValue("@telefone", professor.telefone);
                comando.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                comando.Parameters.AddWithValue("@sexo" , professor.sexo);
                comando.Parameters.AddWithValue("@formacao", professor.formacao);
                comando.ExecuteNonQuery();
                Console.WriteLine("");
                Console.WriteLine("Professor cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                Console.WriteLine("erro " + ex.Message);
            }
        }
        public void Delete(Professor professor)
        {
            try
            {
                string sql = " DELETE FROM professor WHERE id_professor = @id_professor";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_professor", professor.idProfessor);
                comando.ExecuteNonQuery();
                Console.WriteLine("");
                Console.WriteLine("-- Professor excluido --");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {

                throw new Exception($"erro: {ex.Message}");
            }
        }
        public void Update(Professor professor)
        {
            try
            {
                string dataNascimento = professor.dataNascimento.ToString("yyyy-MM-dd");
                string sql = "UPDATE professor SET nome = @nome, Cpf = @cpf, Email = @email, " +
                             "telefone = @telefone, dataNascimento = @dataNascimento, sexo = @sexo, formacao = @formacao where id_professor = @id_professor" +
                             "";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome", professor.nome);
                comando.Parameters.AddWithValue("@cpf", professor.Cpf);
                comando.Parameters.AddWithValue("@email", professor.Email);
                comando.Parameters.AddWithValue("@telefone", professor.telefone);
                comando.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                comando.Parameters.AddWithValue("@sexo", professor.sexo);
                comando.Parameters.AddWithValue("@formacao", professor.formacao);
                comando.Parameters.AddWithValue("@id_professor", professor.idProfessor);

                comando.ExecuteNonQuery();
                Console.WriteLine("");
                Console.WriteLine("-- Professor atualizado com sucesso --");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }
        public List<Professor> List()
        {
            List<Professor> professors = new List<Professor>();

            try
            {
                var sql = "SELECT * FROM professor ORDER BY nome";
                MySqlCommand command = new MySqlCommand(sql, Conexao.Conectar());
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Professor professor = new Professor();
                        professor.idProfessor = dr.GetInt32("id_professor");
                        professor.nome = dr.GetString("nome");
                        professor.Email = dr.GetString("email");
                        professor.Cpf = dr.GetString("cpf");
                        professor.telefone = dr.GetString("telefone");
                        professor.dataNascimento = DateOnly.FromDateTime(dr.GetDateTime("dataNascimento"));
                        professor.sexo = dr.GetString("sexo");
                        professor.formacao = dr.GetString("formacao");
                        professors.Add(professor);
                    }

                }
                Conexao.FecharConexao();

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro{ex.Message}");
            }
            return professors;
        }
    }
}

