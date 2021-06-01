﻿using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string opecaoUsuario = ObterOpcaoUsuario();

            while (opecaoUsuario.ToUpper() != "X")
            {
                switch (opecaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno: ");

                        //var é uma funcionalidade do c# que se chama inferência de tipo, não precisa especificar o tipo. 
                        // convertendo string para decimal, sem tratar o conteúdo da string
                        // var nota = decimal.Parse(Console.ReadLine());

                        //tratando o conteúdo da string, ver se é possível converter
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota)) {
                            aluno.Nota = nota;
                        } else{
                             throw new ArgumentException("Valor da nota deve ser decimal");
                        }
                      
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        
                        break;
                    case "2":
                        
                        foreach(var a in alunos){
                            if(!string.IsNullOrEmpty(a.Nome)){  
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                           
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for(int i=0; i<alunos.Length;i++){
                             if(!string.IsNullOrEmpty(alunos[i].Nome)){  
                                 notaTotal = notaTotal + alunos[i].Nota;
                                 nrAlunos ++;
                             }
                        }

                        var mediaGeral = notaTotal /nrAlunos;
                        ConceitoEnum conceitoGeral;

                        if(mediaGeral < 2 ){
                            conceitoGeral = ConceitoEnum.E;
                        }
                        else if(mediaGeral < 4){
                             conceitoGeral = ConceitoEnum.D;
                        }
                        else if(mediaGeral < 6){
                             conceitoGeral = ConceitoEnum.C;
                        }
                        else if(mediaGeral < 8){
                             conceitoGeral = ConceitoEnum.D;
                        }
                        else{
                            conceitoGeral = ConceitoEnum.A;
                        }


                        Console.WriteLine($"Média geral: {mediaGeral} - Conceito Geral: {conceitoGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opecaoUsuario = ObterOpcaoUsuario();
            }


        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opçãos desejada: ");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            String opecaoUsuario = Console.ReadLine();
            return opecaoUsuario;
        }
    }
}
