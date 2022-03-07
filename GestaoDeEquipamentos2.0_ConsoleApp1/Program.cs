using System;

namespace GestaoDeEquipamentos2._0_ConsoleApp1
{
    internal class Program
    {        
        static string[] nomeDoEquipamento = new string[100];
        static decimal[] precoDeAquisicao = new decimal[100];
        static string[] numeroDeSerie = new string[100];
        static string[] dataDeFabricacao = new string[100];
        static string[] fabricante = new string[100];
        static string[] equipamentoDaProblema = new string[100];

        static string[] tituloDoChamado = new string[100];
        static string[] descricaoDoChamado = new string[100];
        static DateTime[] dataDeAberturaDoChamado = new DateTime[100];
        static string[] ChamadoSolicitante = new string[100];
        static string[] ChamadosEncerrados = new string[100];

        static string[] nomeDoSolicitante = new string[100];
        static string[] emailDoSolicitante = new string[100];
        static string[] telefoneDoSolicitante = new string[100];        

        
        static void Main(string[] args)
        {
            string menu = "";
            while (menu != "0")
            {
                Console.WriteLine("1- Registrar Equipamento");
                Console.WriteLine("2- Visualizar Equipamento");
                Console.WriteLine("3- Editar Equipamento");
                Console.WriteLine("4- Excluir Equipamento");
                Console.WriteLine("5- Criar Chamado");
                Console.WriteLine("6- Visualizar Chamado");
                Console.WriteLine("7- Editar Chamado");
                Console.WriteLine("8- Excluir Chamado");
                Console.WriteLine("9- Visualizar Solicitantes");
                Console.WriteLine("10- Editar Solicitantes");
                Console.WriteLine("11- Excluir Solicitantes");
                Console.WriteLine("12- Chamados em aberto");
                Console.WriteLine("13- Equipamentos que podem dar problema");
                Console.WriteLine("");
                Console.WriteLine("0- Encerrar Programa");
                menu = Console.ReadLine();
                Console.Clear();
                switch (menu)
                {
                    
                    case "1":
                        RegistrarEquipamento(posicao());
                        break;
                    case "2":
                        VisualizarEquipamento(posicao());
                        break;
                    case "3":
                        EditarEquipamento(posicao());
                        break;
                    case "4":
                        DeletarEquipamento(posicao());
                        break;
                    case "5":
                        CriarChamado(posicao(),Solicitante());
                        break;
                    case "6":
                        VisualizarChamado(posicao());
                        break;
                    case "7":
                        EditarChamado(posicao());
                        break;
                    case "8":
                        DeletarChamado(posicao(), Solicitante());
                        break;
                    case "9":
                        VerIdSolicitantes(PosicaoSolicitante());
                        break;
                    case "10":
                        EditarSolicitante(PosicaoSolicitante());
                        break;
                    case "11":
                        ExcluirSolicitante(PosicaoSolicitante());
                        break;
                    case "12":
                        verChamados();
                        break;
                    case "13":
                        ListaEquipamentoQDaProblema();
                        break;
                }
            }
        }



        #region
        //Métodos
        static void MensagemDeErro()
        {
            Console.WriteLine("Opss, algo deu errado, certifique-se de colocar valores corretos");
            Console.ReadLine();
            Console.Clear();
        }
        static int Solicitante()
        {
            int solicitante = -1;
            for (int i = 0; i < nomeDoSolicitante.Length; i++)
            {
                if (nomeDoSolicitante[i] == null)
                {
                    solicitante = i;
                    RegistrarSolicitante(solicitante);                    
                    break;
                }
            }
            return solicitante;
        }
        static int posicao() 
        {
            int posicao = -1;
            int comeco = 0;
            int fim = 20;
            while (posicao < 0)
            {
                Console.Clear();                
                for (int i = comeco; i < fim; i++)
                {
                    Console.WriteLine(i + " " + nomeDoEquipamento[i]);
                }
                string pagina;
                Console.WriteLine("Escreva 'next' para proxima pagina");
                Console.WriteLine("Escreva 'prev' para voltar a pagina");
                Console.WriteLine("Aperte 'ENTER' para digitar a posição");
                pagina = Console.ReadLine();

                if(pagina == "next")
                {
                    if(fim == nomeDoEquipamento.Length)
                    {
                        comeco = 0;
                        fim = 20;
                        continue;
                    }
                    comeco += 20;
                    fim += 20;
                    continue;
                }
                if(pagina == "prev")
                {
                    if (comeco == 0)
                    {
                        comeco = 0;
                        fim = 20;
                        continue;
                    }
                    comeco -= 20;
                    fim -= 20;
                    continue;
                }

                Console.WriteLine("Digite a posição desejada ou enter para continuar");
                string strposicao = Console.ReadLine();
                if (Convert.ToInt32(strposicao) >= 0 && Convert.ToInt32(strposicao) <= 99)
                {
                    posicao = Convert.ToInt32(strposicao);
                }
                else
                {
                    continue;
                }
                
            }            
            Console.Clear();
            return posicao;

        }

        static void RegistrarEquipamento (int posicao)
        {
            Console.WriteLine("Minimo 6 caracteres.");
            Console.Write("Equipamento: ");
            nomeDoEquipamento[posicao] = Console.ReadLine();
            while(nomeDoEquipamento.Length < 6)
            {
                MensagemDeErro();
                Console.WriteLine("Minimo 6 caracteres.");
                Console.Write("Equipamento: ");
                nomeDoEquipamento[posicao] = Console.ReadLine();
            }

            Console.Write("Preço de Aquisiçao: R$ ");
            precoDeAquisicao[posicao] = decimal.Parse(Console.ReadLine());

            Console.Write("Numero de Série: ");
            numeroDeSerie[posicao] = (Console.ReadLine());

            Console.Write("Data de Fabricação: ");
            dataDeFabricacao[posicao] = (Console.ReadLine());

            Console.Write("Fabricante: ");
            fabricante[posicao] = Console.ReadLine();

            Console.WriteLine("Equipamento da problema?");
            Console.WriteLine("1- não da problema");
            Console.WriteLine("2- Pode dar problema");
            int problemas = int.Parse(Console.ReadLine());
            if(problemas == 2)
            {
                equipamentoDaProblema[posicao] = nomeDoEquipamento[posicao];
            }

            Console.Clear();
        }
        static void VisualizarEquipamento (int posicao)
        {
            string visualizar = "Nome: " + nomeDoEquipamento[posicao]+ "\n" +
                                "Preço de Aquisição: " + precoDeAquisicao[posicao] + "\n" +
                                "Numero de Série: " + numeroDeSerie[posicao]+ "\n" +
                                "Data de Fabricação: " + dataDeFabricacao[posicao]+ "\n" +
                                "Fabricante: " + fabricante[posicao];
            Console.WriteLine(visualizar);
            Console.ReadLine();
            Console.Clear();
        }
        static void EditarEquipamento (int posicao)
        {
            Console.Clear();
            string opcao= "";
            while (opcao != "6")
            {
                Console.WriteLine("1- Editar Nome do Equipamento: ");
                Console.WriteLine("2- Preço de Aquisição: ");
                Console.WriteLine("3- Numero de Série: ");
                Console.WriteLine("4- Data de Fabricação: ");
                Console.WriteLine("5- Fabricante: ");
                Console.WriteLine("6- sair");

                opcao = Console.ReadLine();
                Console.Clear();
                switch (opcao)
                {
                    case "1":
                        Console.Write("Escreva o novo 'Nome': ");
                        nomeDoEquipamento[posicao] = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Escreva o novo 'Preço de Aquisição': ");
                        precoDeAquisicao[posicao] = decimal.Parse(Console.ReadLine());
                        break;
                    case "3":
                        Console.Write("Escreva o novo 'Numero de Série': ");
                        numeroDeSerie[posicao] = (Console.ReadLine());
                        break;
                    case "4":
                        Console.Write("Escreva a nova 'Data de Fabricação': ");
                        dataDeFabricacao[posicao] = Console.ReadLine();
                        break;
                    case "5":
                        Console.Write("Escreva o novo 'Fabricante'");
                        fabricante[posicao] = Console.ReadLine();
                        break;
                }
                Console.Clear();
            }
            

        }
        static void DeletarEquipamento (int posicao)
        {
            if(tituloDoChamado[posicao] != "")
            {
                Console.WriteLine("Chamado em Andamento!");
                Console.WriteLine("Finalize o Chamado antes de excluir o Equipamento");
                Console.ReadLine();
            }
            else
            {
                nomeDoEquipamento[posicao] = "";
                precoDeAquisicao[posicao] = 0;
                numeroDeSerie[posicao] = "";
                dataDeFabricacao[posicao] = "";
                fabricante[posicao] = "";
                equipamentoDaProblema[posicao] = null;
                Console.WriteLine("EQUIPAMENTO EXCLUIDO COM SUCESSO!");
                Console.ReadLine();
            }
        }

        static void CriarChamado(int posicao, int solicitante)
        {
            ChamadoSolicitante[posicao] = nomeDoSolicitante[solicitante];
            Console.WriteLine("Data de Abertura do Chamado, dd/mm/aaaa");
            string strDataAbertura = Console.ReadLine();
            Console.WriteLine("Titulo do Chamado!: ");
            tituloDoChamado[posicao] = Console.ReadLine();
            Console.WriteLine("Descrição do Chamado: ");
            descricaoDoChamado[posicao] = Console.ReadLine();
            
            dataDeAberturaDoChamado[posicao] = Convert.ToDateTime(strDataAbertura);

            Console.Clear();
            Console.WriteLine("Chamado criado com sucesso");
            Console.ReadLine();

        }
        static void VisualizarChamado(int posicao)
        {

            TimeSpan diferenca = DateTime.Today - dataDeAberturaDoChamado[posicao];
            double dias = diferenca.TotalDays;

            string verChamado = "titulo do Chamado: " + tituloDoChamado[posicao] + "\n" +
                                "Equipamento: " + nomeDoEquipamento[posicao] + "\n" +
                                "Solicitante: " + ChamadoSolicitante[posicao] + "\n" +
                                "\n Descrição do Chamado: " + descricaoDoChamado[posicao] + "\n" +
                                "\n Tempo do Chamado: " + dias + " Dias";

            Console.WriteLine(verChamado);
            Console.ReadLine();
            Console.Clear();
        }
        static void EditarChamado(int posicao)
        {
            string strDataAbertura = "25/02/2022";
            string editarChamado = "";
            while (editarChamado != "0")
            {
                Console.WriteLine("1- Editar Titulo do Chamado");
                Console.WriteLine("2- Editar Descrição do Chamado");
                Console.WriteLine("3- Editar Nome do Solicitante");
                Console.WriteLine("0- Sair");
                editarChamado = Console.ReadLine();

                Console.Clear();

                switch (editarChamado)
                {
                    case "1":
                        Console.WriteLine("Escreva o Novo titulo do Chamado");
                        tituloDoChamado[posicao] = Console.ReadLine();
                        dataDeAberturaDoChamado[posicao] = Convert.ToDateTime(strDataAbertura);
                        break;
                    case "2":
                        Console.WriteLine("Escreva a nova Descrição");
                        descricaoDoChamado[posicao] = Console.ReadLine();
                        dataDeAberturaDoChamado[posicao] = Convert.ToDateTime(strDataAbertura);
                        break;
                    case "3":
                        Console.WriteLine("Escreva o Novo nome do Solicitante");
                        ChamadoSolicitante[posicao] = Console.ReadLine();
                        break;
                }
                if (editarChamado == "1" && editarChamado == "2")
                {
                    Console.WriteLine("Edição concluida!");
                    Console.ReadLine();
                    Console.Clear();
                }
                
            }
        }
        static void DeletarChamado(int posicao, int solicitante)
        {
            ChamadosEncerrados[solicitante] = tituloDoChamado[posicao] + " Encerrado";
            tituloDoChamado[posicao] = "";
            descricaoDoChamado[posicao] = "";
            Console.WriteLine("Chamado Excluido !");
            Console.ReadLine();
            Console.Clear();
        }

        static int PosicaoSolicitante()
        {
            int posicaoSolicitante = -1;
            int comeco = 0;
            int fim = 20;
            while (posicaoSolicitante < 0)
            {
                Console.Clear();
                for (int i = comeco; i < fim; i++)
                {
                    Console.WriteLine(i + " " + nomeDoSolicitante[i]);
                }
                string pagina;
                Console.WriteLine("Escreva 'next' para proxima pagina");
                Console.WriteLine("Escreva 'prev' para voltar a pagina");
                Console.WriteLine("Aperte 'ENTER' para digitar a posição");
                pagina = Console.ReadLine();

                if (pagina == "next")
                {
                    if (fim == nomeDoSolicitante.Length)
                    {
                        comeco = 0;
                        fim = 20;
                        continue;
                    }
                    comeco += 20;
                    fim += 20;
                    continue;
                }
                if (pagina == "prev")
                {
                    if (comeco == 0)
                    {
                        comeco = 0;
                        fim = 20;
                        continue;
                    }
                    comeco -= 20;
                    fim -= 20;
                    continue;
                }

                Console.WriteLine("Digite a posição desejada ou enter para continuar");
                string strposicao = Console.ReadLine();
                if (Convert.ToInt32(strposicao) >= 0 && Convert.ToInt32(strposicao) <= 99)
                {
                    posicaoSolicitante = Convert.ToInt32(strposicao);
                }
                else
                {
                    continue;
                }

            }
            Console.Clear();
            return posicaoSolicitante;
        }
        static void RegistrarSolicitante(int solicitante)
        {
            Console.WriteLine("Solicitante: ");
            nomeDoSolicitante[solicitante] = Console.ReadLine();
            Console.WriteLine("Email: ");
            emailDoSolicitante[solicitante] = Console.ReadLine();
            Console.WriteLine("Telefone: ");
            telefoneDoSolicitante[solicitante] = Console.ReadLine();
            Console.Clear();
        }
        static void VerIdSolicitantes(int posicaoSolicitante)
        {
            string visualizar = "Solicitante: " + nomeDoSolicitante[posicaoSolicitante] + "\n" +
                               "E-mail: " + emailDoSolicitante[posicaoSolicitante] + "\n" +
                               "Telefone: " + telefoneDoSolicitante[posicaoSolicitante];
            Console.WriteLine(visualizar);
            Console.ReadLine();
            Console.Clear();
        }
        static void EditarSolicitante(int posicaoSolicitante)
        {
            Console.Clear();
            string opcao = "";
            while (opcao != "0")
            {
                Console.WriteLine("1- Editar Nome do Socilitante: ");
                Console.WriteLine("2- Editar E-mail do Solicitante: ");
                Console.WriteLine("3- Editar Telefone do Solicitante: ");
                Console.WriteLine();
                Console.WriteLine("0- sair");

                opcao = Console.ReadLine();
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Novo nome para o Solicitante");
                        nomeDoSolicitante[posicaoSolicitante] = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Novo E-mail do Solicitante");
                        emailDoSolicitante[posicaoSolicitante] = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Novo Telefone do Solicitante");
                        telefoneDoSolicitante[posicaoSolicitante] = Console.ReadLine();
                        break;
                }                
            }
            Console.Clear();
        }
        static void ExcluirSolicitante(int posicaoSolicitante)
        {
            nomeDoSolicitante[posicaoSolicitante] = null;
            emailDoSolicitante[posicaoSolicitante] = null;
            telefoneDoSolicitante[posicaoSolicitante] = null;

            Console.WriteLine("Solicitante Excluido!");
            Console.ReadLine();
            Console.Clear();
        }
        static void verChamados()
        {
            Console.WriteLine("Chamados Encerrados");
            for (int i = 0; i < ChamadosEncerrados.Length; i++)
            {
                if(ChamadosEncerrados[i] != null)
                {
                    Console.WriteLine(ChamadosEncerrados[i]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Chamado em aberto");
            for (int i = 0; i < tituloDoChamado.Length; i++)
            {
                if(tituloDoChamado[i] != null)
                {
                    Console.WriteLine(tituloDoChamado[i]);
                }
            }
        }
        static void ListaEquipamentoQDaProblema()
        {
            if (equipamentoDaProblema != null)
            {
                for (int i = 0; i < equipamentoDaProblema.Length; i++)
                {
                    Console.WriteLine(equipamentoDaProblema[i]);
                }
            }
            Console.ReadLine();
        }
        #endregion
    }
}
