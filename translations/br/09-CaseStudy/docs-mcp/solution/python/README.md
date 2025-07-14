<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:39:44+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "br"
}
-->
# Gerador de Plano de Estudos com Chainlit & Microsoft Learn Docs MCP

## Pré-requisitos

- Python 3.8 ou superior  
- pip (gerenciador de pacotes Python)  
- Acesso à internet para conectar ao servidor Microsoft Learn Docs MCP  

## Instalação

1. Clone este repositório ou baixe os arquivos do projeto.  
2. Instale as dependências necessárias:

   ```bash
   pip install -r requirements.txt
   ```

## Uso

### Cenário 1: Consulta Simples ao Docs MCP  
Um cliente de linha de comando que se conecta ao servidor Docs MCP, envia uma consulta e exibe o resultado.

1. Execute o script:  
   ```bash
   python scenario1.py
   ```  
2. Digite sua pergunta sobre a documentação no prompt.

### Cenário 2: Gerador de Plano de Estudos (App Web Chainlit)  
Uma interface web (usando Chainlit) que permite aos usuários gerar um plano de estudos personalizado, semana a semana, para qualquer tema técnico.

1. Inicie o app Chainlit:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Abra a URL local fornecida no terminal (ex: http://localhost:8000) no seu navegador.  
3. Na janela de chat, informe o tema de estudo e o número de semanas que deseja estudar (ex: "certificação AI-900, 8 semanas").  
4. O app responderá com um plano de estudos detalhado por semana, incluindo links para a documentação relevante do Microsoft Learn.

**Variáveis de Ambiente Necessárias:**

Para usar o Cenário 2 (app web Chainlit com Azure OpenAI), você deve configurar as seguintes variáveis de ambiente em um arquivo `.env` dentro do diretório `python`:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Preencha esses valores com os detalhes do seu recurso Azure OpenAI antes de executar o app.

> **Dica:** Você pode facilmente implantar seus próprios modelos usando o [Azure AI Foundry](https://ai.azure.com/).

### Cenário 3: Docs no Editor com MCP Server no VS Code

Em vez de alternar entre abas do navegador para buscar documentação, você pode trazer o Microsoft Learn Docs diretamente para o VS Code usando o servidor MCP. Isso permite que você:  
- Pesquise e leia a documentação dentro do VS Code sem sair do ambiente de desenvolvimento.  
- Referencie a documentação e insira links diretamente em seus arquivos README ou de curso.  
- Use o GitHub Copilot e o MCP juntos para um fluxo de trabalho integrado e com suporte de IA.

**Exemplos de Uso:**  
- Adicione rapidamente links de referência a um README enquanto escreve documentação de curso ou projeto.  
- Use o Copilot para gerar código e o MCP para encontrar e citar documentos relevantes instantaneamente.  
- Mantenha o foco no editor e aumente sua produtividade.

> [!IMPORTANT]  
> Certifique-se de ter uma configuração válida de [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) no seu workspace (localização: `.vscode/mcp.json`).

## Por que usar Chainlit no Cenário 2?

Chainlit é um framework moderno e open-source para construir aplicações web conversacionais. Ele facilita a criação de interfaces de chat que se conectam a serviços backend, como o servidor Microsoft Learn Docs MCP. Este projeto usa Chainlit para oferecer uma forma simples e interativa de gerar planos de estudo personalizados em tempo real. Com o Chainlit, você pode criar e implantar rapidamente ferramentas baseadas em chat que aumentam a produtividade e o aprendizado.

## O que este app faz

Este app permite que os usuários criem um plano de estudos personalizado apenas informando um tema e uma duração. O app interpreta sua entrada, consulta o servidor Microsoft Learn Docs MCP por conteúdos relevantes e organiza os resultados em um plano estruturado, semana a semana. As recomendações de cada semana são exibidas no chat, facilitando o acompanhamento do progresso. A integração garante que você sempre tenha acesso aos recursos de aprendizado mais atuais e relevantes.

## Exemplos de Consultas

Experimente estas consultas na janela de chat para ver como o app responde:

- `certificação AI-900, 8 semanas`  
- `Aprender Azure Functions, 4 semanas`  
- `Azure DevOps, 6 semanas`  
- `Engenharia de dados no Azure, 10 semanas`  
- `Fundamentos de segurança Microsoft, 5 semanas`  
- `Power Platform, 7 semanas`  
- `Serviços Azure AI, 12 semanas`  
- `Arquitetura de nuvem, 9 semanas`

Esses exemplos mostram a flexibilidade do app para diferentes objetivos e prazos de aprendizado.

## Referências

- [Documentação Chainlit](https://docs.chainlit.io/)  
- [Documentação MCP](https://github.com/MicrosoftDocs/mcp)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.