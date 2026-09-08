using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using TextReplacer.Services;

namespace TextReplacer
{
    public partial class Main : Window
    {
        // Recebe as classes de seleção de arquivo e substituição de texto
        private FileSelectionService _fileSelect;
        private TextReplacementService _text;
        public Main()
        {
            InitializeComponent();
        }

        // Abre o explorador de arquivos ao clicar no botão
        private void btnArquivo_Click(object sender, RoutedEventArgs e)
        {
            _fileSelect = new FileSelectionService();
            string nome = _fileSelect.SelecionarArquivo();

            lblCaminho.Content = nome;
        }

        // Substituí os termos e já abre o explorador de arquivos para o usuário salvar
        private void btnSubstituir_Click(object sender, RoutedEventArgs e)
        {
            var validation = new ValidationService();
            _text = new TextReplacementService
            {
                TermoASubstituir = TxtSubstituir.Text,
                TermoSubstituto = TxtSubstituto.Text,
            };

            if (!validation.ArquivoSelecionado(_fileSelect))
            {
                MessageBox.Show("Selecione um arquivo");
            }
            else if (!validation.TermoDigitado(_text))
            {
                MessageBox.Show("Digite ambos os termos");
            }
            else
            { 
                try
                {
                    _text.SubstituirNoArquivo(_fileSelect);
                    MessageBox.Show("Arquivo salvo com sucesso");
                }
                catch
                {
                    MessageBox.Show("Erro ao salvar o aquivo");
                }
            }
            
        }
    }
}
