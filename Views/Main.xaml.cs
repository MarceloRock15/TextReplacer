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
        private readonly FileSelectionService _fileSelect = new FileSelectionService();
        private readonly TextReplacementService _text = new TextReplacementService();
        private FileSavingService _saving;
        public Main()
        {
            InitializeComponent();
        }

        // Abre o explorador de arquivos ao clicar no botão
        private void btnArquivo_Click(object sender, RoutedEventArgs e)
        {
            string nome = _fileSelect.SelecionarArquivo();
            lblCaminho.Content = nome;

            lblCaminho.Content = nome;
        }

        // Substituí os termos
        private void btnSubstituir_Click(object sender, RoutedEventArgs e)
        {
            _text.TermoASubstituir = TxtSubstituir.Text;
            _text.TermoSubstituto = TxtSubstituto.Text;

            var validation = new ValidationService();
            // Exibe uma mensagem caso o usuário não tenha selecionado nenhum arquivo
            if (!validation.ArquivoSelecionado(_fileSelect))
            {
                MessageBox.Show("Selecione um arquivo");
            }
            // Exibe uma mensagem caso o usuário não tenha digitado ambos os termos
            else if (!validation.TermoDigitado(_text))
            {
                MessageBox.Show("Digite ambos os termos");
            }
            // Exibe uma mensagem caso o termo digitado pelo usuário não exista no arquivo selecionado
            else if (!validation.TermoExiste(_text, _fileSelect))
            {
                MessageBox.Show($"O termo \"{_text.TermoASubstituir}\" não existe no arquivo");
            }
            else
            { 
                try
                {
                    _text.SubstituirNoArquivo(_fileSelect);
                    MessageBox.Show("Texto substituído com sucesso");
                }
                catch
                {
                    MessageBox.Show("Erro ao salvar o aquivo");
                }
            }
            TxtSubstituir.Clear();
            TxtSubstituto.Clear();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var validation = new ValidationService();
            var saving = new FileSavingService();
            if (!validation.ArquivoSelecionado(_fileSelect))
            {
                MessageBox.Show("Selecione um arquivo");
            }
            else
            {
                bool salvou = saving.SalvarArquivo(_text, _fileSelect);
                if (salvou) {
                    MessageBox.Show("Arquivo salvo com sucesso!"); 
                }
            }
            
        }
    }
}
