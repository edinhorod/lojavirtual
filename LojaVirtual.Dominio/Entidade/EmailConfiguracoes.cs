using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LojaVirtual.Dominio.Entidade
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;

        public string ServidorSmtp = "mail.agiledw.com.br";

        public int ServidorPorta = 587;

        public string Usuario = "agiledw";

        public bool EscreverArquivo = false;

        public string PastaArquivo = @"c:\envioemail";

        public string De = "agiledw@agiledw.com.br";

        public string Para = "agiledw@agiledw.com.br";
    }
}
