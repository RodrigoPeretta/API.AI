# 🤖 API .NET Core usando Semantic Kernel + OpenAI

Este projeto é um exemplo de aplicação ASP.NET Core em C# que utiliza o [Microsoft Semantic Kernel](https://github.com/microsoft/semantic-kernel) para integrar com a API da OpenAI.
---

## 🚀 Pré-requisitos

- .NET 8.0+
- Conta na OpenAI
- Visual Studio ou VS Code
- Chave e Org ID da OpenAI configurados

---

## ⚙️ Variáveis de Ambiente

A aplicação utiliza variáveis de ambiente para acessar o serviço da Azure OpenAI com segurança.

Defina as seguintes variáveis **no ambiente do sistema operacional** (e **não no `launchSettings.json`**, por segurança):

| Variável              | Descrição                                           |
|-----------------------|-----------------------------------------------------|
| `OPENAI_API_KEY`      | A chave da API da Azure OpenAI                      |
| `OPENAI_ORGID`        | O endpoint da Azure OpenAI (ex: `https://...`)      |


> 💡 Para uso local no Windows, defina com `setx` no terminal, ou abra o Visual Studio a partir de um terminal com `start devenv` após definir as variáveis temporariamente com `$env:`.

---

## 🧪 Testando a aplicação

Execute a aplicação com o Visual Studio ou via CLI:

```bash
dotnet run
