using cadastroProfessor.Models;
using cadastroProfessor.Mestre;
using Mysqlx.Crud;
using cadastroProfessor;
using MySql.Data.MySqlClient;
using System;
using ZstdSharp.Unsafe;

class Program
{
    static void Main(string[] args)
    {
        int opcao;
        do
        {
            Console.WriteLine("=== Menu Cadastro Professor ===");
            Console.WriteLine("");
            Console.WriteLine("1 - Cadastrar Professor");
            Console.WriteLine("2 - Listar Professores");
            Console.WriteLine("3 - Atualizar Professor");
            Console.WriteLine("4 - Deletar Professor");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("");
                    CadastrarProfessor();
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("");
                    ListarProfessores();
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("");
                    AtualizarProfessor();
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("");
                    DeletarProfessor();
                    Console.WriteLine("");
                    break;
                case 0:
                    Console.WriteLine("");
                    Console.WriteLine("Saindo...");
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }

        } while (opcao != 0);
    }

    static void CadastrarProfessor()
    {
        try
        {
            Conexao.Conectar();
            Professor prof = new Professor();

            Console.Write("Nome: ");
            prof.nome = Console.ReadLine();

            Console.Write("CPF: ");
            prof.Cpf = Console.ReadLine();

            Console.Write("Email: ");
            prof.Email = Console.ReadLine();

            Console.Write("Telefone: ");
            prof.telefone = Console.ReadLine();

            Console.Write("Data de Nascimento (AAAA-MM-DD): ");
            prof.dataNascimento = DateOnly.Parse(Console.ReadLine());

            Console.Write("Sexo: ");
            prof.sexo = Console.ReadLine();

            Console.Write("Formação: ");
            prof.formacao = Console.ReadLine();

            Cadastro_Professor cadastro_prof = new Cadastro_Professor();
            cadastro_prof.Insert(prof);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
    
    static void ListarProfessores()
    {
        try
        {
            Cadastro_Professor cadastro_prof = new Cadastro_Professor();
            var professores = cadastro_prof.List();

            foreach (var professor in professores)
            {
                Console.WriteLine($"ID: {professor.idProfessor}, Nome: {professor.nome}, CPF: {professor.Cpf}, Email: {professor.Email}, Telefone: {professor.telefone}, Data de Nascimento: {professor.dataNascimento}, Sexo: {professor.sexo}, Formação: {professor.formacao}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void AtualizarProfessor()
    {
        try
        {
            Conexao.Conectar();
            Professor prof = new Professor();

            Console.Write("ID do Professor a ser atualizado: ");
            prof.idProfessor = int.Parse(Console.ReadLine());

            Console.Write("Novo Nome: ");
            prof.nome = Console.ReadLine();

            Console.Write("Novo CPF: ");
            prof.Cpf = Console.ReadLine();

            Console.Write("Novo Email: ");
            prof.Email = Console.ReadLine();

            Console.Write("Novo Telefone: ");
            prof.telefone = Console.ReadLine();

            Console.Write("Nova Data de Nascimento (AAAA-MM-DD): ");
            prof.dataNascimento = DateOnly.Parse(Console.ReadLine());

            Console.Write("Novo Sexo: ");
            prof.sexo = Console.ReadLine();

            Console.Write("Nova Formação: ");
            prof.formacao = Console.ReadLine();

            Cadastro_Professor cadastro_prof = new Cadastro_Professor();
            cadastro_prof.Update(prof);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void DeletarProfessor()
    {
        try
        {
            Conexao.Conectar();
            Professor prof = new Professor();

            Console.Write("ID do Professor a ser deletado: ");
            prof.idProfessor = int.Parse(Console.ReadLine());

            Cadastro_Professor cadastro_prof = new Cadastro_Professor();
            cadastro_prof.Delete(prof);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}



















/*try
{
    Conexao.Conectar();
    Professor prof1 = new Professor();
    prof1.nome = "tatiana tati";
    prof1.Cpf = "0534";
    prof1.Email = "a";
    prof1.telefone = "123";
    prof1.dataNascimento = new DateOnly(2001, 07, 22);
    prof1.sexo = "Feminino";
    prof1.formacao = "Matematica";

    Cadastro_Professor cadastro_prof = new Cadastro_Professor();
    cadastro_prof.Insert(prof1);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    Conexao.Conectar();
    Professor prof1 = new Professor();
    prof1.idProfessor = 3;
    prof1.nome = "Marinete ";
    prof1.Cpf = "0534";
    prof1.Email = "jjjkk";
    prof1.telefone = "123";
    prof1.dataNascimento = new DateOnly(2001, 07, 22);
    prof1.sexo = "Feminino";
    prof1.formacao = "ingles ";

    Cadastro_Professor cadastro_prof = new Cadastro_Professor();
    cadastro_prof.Update(prof1);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    Conexao.Conectar();
    Professor prof1 = new Professor();
    prof1.idProfessor = 4;
    prof1.nome = "Joao";
    prof1.Cpf = "0534";
    prof1.Email = "t";
    prof1.telefone = "123";
    prof1.dataNascimento = new DateOnly(2001, 07, 22);
    prof1.sexo = "Masculino";
    prof1.formacao = "Portugues";

    Cadastro_Professor cadastro_prof = new Cadastro_Professor();
    cadastro_prof.Delete(prof1);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}*/


