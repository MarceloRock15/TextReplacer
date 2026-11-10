using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.Win32;

namespace TextReplacer.Services
{
    class TextReplacementService
    {
        private string _caminhoCarregado;
        public string TermoASubstituir { get; set; }
        public string TermoSubstituto { get; set; }
        public string TextoAModificar { get; set; }

        public void CarregarSeNecessario(FileSelectionService file)
        {
            if (TextoAModificar == null || _caminhoCarregado != file.Caminho)
            {
                TextoAModificar = File.ReadAllText(file.Caminho);
                _caminhoCarregado = file.Caminho;
            }
        }
        public void SubstituirNoArquivo(FileSelectionService file)
        {
            CarregarSeNecessario(file);
            // Só lê do disco se ainda não carregou, ou se o arquivo mudou
            if (TextoAModificar == null || _caminhoCarregado != file.Caminho)
            {
                TextoAModificar = File.ReadAllText(file.Caminho);
                _caminhoCarregado = file.Caminho;
            }

            // Substituição dos termos
            TextoAModificar = Regex.Replace(TextoAModificar, Regex.Escape(TermoASubstituir), match =>
            {
                string encontrado = match.Value;

                if (char.IsUpper(encontrado[0]))
                {
                    // Primeira letra maiúscula: capitaliza o substituto
                    return char.ToUpper(TermoSubstituto[0]) + TermoSubstituto.Substring(1).ToLower();
                }
                else
                {
                    // Minúscula: mantém tudo minúsculo
                    return TermoSubstituto.ToLower();
                }
            }, RegexOptions.IgnoreCase);
        }
    }
}
