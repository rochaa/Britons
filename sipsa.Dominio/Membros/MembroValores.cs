namespace sipsa.Dominio.Membros {
    public static class MembroEstadoCivil {
        public static string SOLTEIRO;
        public static string CASADO;
        public static string DIVORCIADO;
        public static string VIUVO;
        public static string[] Permitidas = {
            nameof (SOLTEIRO),
            nameof (CASADO),
            nameof (DIVORCIADO),
            nameof (VIUVO)
        };
    }

    public static class MembroEscolaridade {
        public static string EDUCACAOINFANTIL;
        public static string FUNDAMENTAL;
        public static string MEDIO;
        public static string SUPERIOR;
        public static string POSGRADUACAO;
        public static string MESTRADO;
        public static string DOUTORADO;
        public static string[] Permitidas = {
            nameof (EDUCACAOINFANTIL),
            nameof (FUNDAMENTAL),
            nameof (MEDIO),
            nameof (SUPERIOR),
            nameof (POSGRADUACAO),
            nameof (MESTRADO),
            nameof (DOUTORADO)
        };
    }

    public static class MembroTitulo {
        public static string MEMBRO;
        public static string DIACONO;
        public static string PRESBITERO;
        public static string PASTOR;
        public static string[] Permitidas = {
            nameof (MEMBRO),
            nameof (DIACONO),
            nameof (PRESBITERO),
            nameof (PASTOR)
        };
    }

    public static class MembroIgreja {
        public static string SANTOAMARO;
        public static string HORIZONTEAZUL;
        public static string GRAJAU;
        public static string JARDIMDASFONTES;
        public static string[] Permitidas = {
            nameof (SANTOAMARO),
            nameof (HORIZONTEAZUL),
            nameof (GRAJAU),
            nameof (JARDIMDASFONTES)
        };
    }

    public static class MembroAdmissaoRecepcao {
        public static string BATISMO;
        public static string PROFISSAOFE;
        public static string BATISMOPROFISSAOFE;
        public static string JURISDICAO;
        public static string CT;
        public static string[] Permitidas = {
            nameof (BATISMO),
            nameof (PROFISSAOFE),
            nameof (BATISMOPROFISSAOFE),
            nameof (JURISDICAO),
            nameof (CT)
        };
    }
}