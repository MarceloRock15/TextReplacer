using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.Win32;

namespace TextReplacer.Services
{
    internal class TextReplacementService
    {
        public string TermoASubstituir { get; set; }
        public string TermoSubstituto { get; set; }
        public void SubstituirNoArquivo(FileSelectionService file)
        {
            // Lê todo o texto do arquivo e transforma em uma string
            string texto = File.ReadAllText(file.Caminho);

            // Substituição dos termos
            texto = Regex.Replace(texto, Regex.Escape(TermoASubstituir), match =>
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

            // Abre o explorador de arquivos para o usuário escolher onde salvar
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivo de texto|*.txt";
            saveFileDialog.ShowDialog();
            var CaminhoSalvar = System.IO.Path.GetFullPath(saveFileDialog.FileName);

            // Salva um novo arquivo de texto atualizado
            File.WriteAllText(CaminhoSalvar, texto);
        }
    }
}
