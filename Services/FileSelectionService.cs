using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.IO;

namespace TextReplacer.Services
{
    class FileSelectionService
    {
        public string Caminho { get; set; }
        public string Nome { get; set; }
        public string SelecionarArquivo()
        {
            // Seleção do arquivo 
            var FileDialog  = new OpenFileDialog();
            FileDialog.ShowDialog();

            Caminho = FileDialog.FileName;
            Nome = Path.GetFileName(Caminho);
            return Nome;
        }
    }
}
