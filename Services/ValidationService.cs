using System;
using System.Collections.Generic;
using System.Text;

namespace TextReplacer.Services
{
    internal class ValidationService
    {
        // Verifica se o usuário escolheu algum arquivo
        public bool ArquivoSelecionado(FileSelectionService file)
        {
            return file != null && !string.IsNullOrEmpty(file.Caminho);
        }

        // Verifica se o usuário digitou ambos os termos
        public bool TermoDigitado(TextReplacementService text)
        {
            return !string.IsNullOrEmpty(text.TermoASubstituir)
                && !string.IsNullOrEmpty(text.TermoSubstituto);
        }

        // Verifica se o termo a substituir existe no texto atual (já com as substituições anteriores)
        public bool TermoExiste(TextReplacementService text, FileSelectionService file)
        {
            text.CarregarSeNecessario(file);

            return text.TextoAModificar.IndexOf(
                text.TermoASubstituir,
                StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}