﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApp.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public int Ra { get; set; }

        public List<Aluno> ListarAlunos()
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = File.ReadAllText(caminhoArquivo);
            var listaAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json);

            return listaAlunos;
        }

        public bool ReescreverArquivo(List<Aluno> listaAlunos)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");
            var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);

            File.WriteAllText(caminhoArquivo, json);

            return true;
        }

        public Aluno Inserir(Aluno aluno)
        {
            var listaAlunos = this.ListarAlunos();

            var maxId = listaAlunos.Max(p => p.Id);
            aluno.Id = maxId + 1;
            listaAlunos.Add(aluno);

            ReescreverArquivo(listaAlunos);

            return aluno;
        }

        public Aluno Atualizar(int id, Aluno aluno)
        {
            var listaAlunos = this.ListarAlunos();

            var itemIndex = listaAlunos.FindIndex(p => p.Id == aluno.Id);

            if (itemIndex >= 0)
            {
                aluno.Id = id;
                listaAlunos[itemIndex] = aluno;
            }
            else
            {
                return null;
            }

            ReescreverArquivo(listaAlunos);

            return aluno;
        }

        public bool Excluir(int id)
        {
            var listaAlunos = this.ListarAlunos();

            var itemIndex = listaAlunos.FindIndex(p => p.Id == id);

            if (itemIndex >= 0)
            {
                listaAlunos.RemoveAt(itemIndex);
            }
            else
            {
                return false;
            }

            ReescreverArquivo(listaAlunos);

            return true;
        }
    }
}