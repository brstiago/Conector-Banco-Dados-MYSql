using System;
using System.Collections.Generic;
using System.IO;

//Etapa 1: Criação de uma Classe para manipular o arquivo sglinx.INI

namespace ConectorSGLinx
{
    //Iniciando Classe que vai ler o arquivo .INI e depois vai reescrevê-lo
    public class IniFile
    {
        //Caminho do arquivo INI
        private readonly string path;
       //private string[] lines;

        //Construtor que recebe o caminho do arquivo .INI
        public IniFile(string iniPath)
        {
            path = iniPath;
        }

        //Pra deteminar qual é o banco atual na chave sglinx.ini
        public string Read(string key)
        {
            //Verifica se o arquivo .INI existe
            if (!File.Exists(path))
                return "";

            //Lê todas as linhas do arquivo
            string[] lines = File.ReadAllLines(path);
            bool inSection = false;

            //Percorre cada linha do arquivo
            foreach (string line in lines)
            {
                //Verifica se a linha pecorrida começa como nomebanco
                if (line.Trim().StartsWith(key + "=", StringComparison.OrdinalIgnoreCase))
                    return line.Substring(key.Length + 1).Trim();

                //Se estiver na seção correta e a linha começar com a chave procurada
                if (inSection && line.StartsWith(key + "="))
                    //Retorna o valor associado a chave
                    return line.Substring(key.Length + 1).Trim();
            }
            //Retorna a Sting vazia se a chave não for encontrada, pra não dar erro
            return "";
        }

        //Método para escrever ou atualizar o valor de uma chave dentro da seção
        public void Write(string key, string value)
        {
            //Verifica se o arquivo existe
            if (!File.Exists(path))
                return;

            //Lê todas as linhas do arquivo
            string[] lines = File.ReadAllLines(path);
            bool keyFound = false;

            //Pecorre cada linha do arquivo
            for (int i = 0; i < lines.Length; i++)
            {
                // Se a linha começar com a chave, substitui o valor
                if (lines[i].Trim().StartsWith(key + "=", StringComparison.OrdinalIgnoreCase))
                {
                    lines[i] = key + "=" + value;
                    keyFound = true;
                    break;
                }
            }

            //Se o a chave não foi encontrada, mas está na seção correta, adicona a chave no final
            if (!keyFound)
            {
                // Adicionando...
                var list = new List<string>(lines);
                list.Add($"{key}={value}");
                lines = list.ToArray();
            }

            //Reescreve toda as linhas lidas no arquivo novamente
            File.WriteAllLines(path, lines);
        }
    }
}