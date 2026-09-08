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
            if (file == null)
            {
                return false;
            }
            return true;
        }

        // Verifica se o usuário digitou ambos os termos
        public bool TermoDigitado(TextReplacementService text)
        {
            if (string.IsNullOrEmpty(text.TermoASubstituir) || string.IsNullOrEmpty(text.TermoSubstituto))
            {
                return false;
            };
            return true;
        }
    }
}
