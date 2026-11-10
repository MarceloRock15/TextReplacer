using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace TextReplacer.Services
{
    class FileSavingService
    {
        public string CaminhoSalvar { get; set; }
        public bool SalvarArquivo(TextReplacementService texto, FileSelectionService arquivo)
        {
            // Abre o explorador de arquivos para o usuário escolher onde salvar
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivo de texto|*.txt";
            saveFileDialog.FileName = arquivo.Nome + " corrigido";

            // Verifica se o usuário confirmou o salvamento
            if (saveFileDialog.ShowDialog() != true) { 
                return false; 
            }

            var CaminhoSalvar = System.IO.Path.GetFullPath(saveFileDialog.FileName);

            // Salva um novo arquivo de texto atualizado
            File.WriteAllText(CaminhoSalvar, texto.TextoAModificar);
            return true;
        }
    }
}
