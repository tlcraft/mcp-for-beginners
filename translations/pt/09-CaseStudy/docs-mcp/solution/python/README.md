<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:39:32+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "pt"
}
-->
# Gerador de Plano de Estudo com Chainlit & Microsoft Learn Docs MCP

## Pré-requisitos

- Python 3.8 ou superior  
- pip (gestor de pacotes Python)  
- Acesso à Internet para conectar ao servidor Microsoft Learn Docs MCP  

## Instalação

1. Clone este repositório ou descarregue os ficheiros do projeto.  
2. Instale as dependências necessárias:  

   ```bash
   pip install -r requirements.txt
   ```

## Utilização

### Cenário 1: Consulta Simples ao Docs MCP  
Um cliente de linha de comandos que se conecta ao servidor Docs MCP, envia uma consulta e imprime o resultado.

1. Execute o script:  
   ```bash
   python scenario1.py
   ```  
2. Insira a sua pergunta sobre a documentação no prompt.

### Cenário 2: Gerador de Plano de Estudo (App Web Chainlit)  
Uma interface web (usando Chainlit) que permite aos utilizadores gerar um plano de estudo personalizado, semana a semana, para qualquer tema técnico.

1. Inicie a app Chainlit:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Abra a URL local fornecida no seu terminal (ex.: http://localhost:8000) no seu navegador.  
3. Na janela de chat, escreva o seu tema de estudo e o número de semanas que pretende estudar (ex.: "certificação AI-900, 8 semanas").  
4. A app responderá com um plano de estudo detalhado por semanas, incluindo links para a documentação relevante do Microsoft Learn.

**Variáveis de Ambiente Necessárias:**  

Para usar o Cenário 2 (a app web Chainlit com Azure OpenAI), deve definir as seguintes variáveis de ambiente num ficheiro `.env` na pasta `python`:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Preencha estes valores com os detalhes do seu recurso Azure OpenAI antes de executar a app.

> **Dica:** Pode facilmente implementar os seus próprios modelos usando [Azure AI Foundry](https://ai.azure.com/).

### Cenário 3: Docs no Editor com MCP Server no VS Code

Em vez de alternar entre separadores do navegador para pesquisar documentação, pode trazer o Microsoft Learn Docs diretamente para o seu VS Code usando o servidor MCP. Isto permite-lhe:  
- Pesquisar e ler documentação dentro do VS Code sem sair do ambiente de programação.  
- Referenciar documentação e inserir links diretamente nos seus ficheiros README ou de curso.  
- Usar o GitHub Copilot e o MCP em conjunto para um fluxo de trabalho de documentação assistido por IA, fluido e eficiente.

**Exemplos de Utilização:**  
- Adicionar rapidamente links de referência a um README enquanto escreve documentação de um curso ou projeto.  
- Usar o Copilot para gerar código e o MCP para encontrar e citar documentação relevante instantaneamente.  
- Manter o foco no editor e aumentar a produtividade.

> [!IMPORTANT]  
> Certifique-se de que tem uma configuração válida de [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) no seu workspace (localização: `.vscode/mcp.json`).

## Porquê o Chainlit para o Cenário 2?

O Chainlit é um framework moderno e open-source para construir aplicações web conversacionais. Facilita a criação de interfaces de chat que se ligam a serviços backend como o servidor Microsoft Learn Docs MCP. Este projeto usa o Chainlit para oferecer uma forma simples e interativa de gerar planos de estudo personalizados em tempo real. Ao tirar partido do Chainlit, pode construir e implementar rapidamente ferramentas baseadas em chat que aumentam a produtividade e o aprendizado.

## O que isto faz

Esta app permite aos utilizadores criar um plano de estudo personalizado simplesmente introduzindo um tema e uma duração. A app interpreta a sua entrada, consulta o servidor Microsoft Learn Docs MCP para conteúdo relevante e organiza os resultados num plano estruturado, semana a semana. As recomendações de cada semana são apresentadas no chat, facilitando o acompanhamento e o progresso. A integração garante que tem sempre acesso aos recursos de aprendizagem mais recentes e relevantes.

## Exemplos de Consultas

Experimente estas consultas na janela de chat para ver como a app responde:

- `certificação AI-900, 8 semanas`  
- `Aprender Azure Functions, 4 semanas`  
- `Azure DevOps, 6 semanas`  
- `Engenharia de dados no Azure, 10 semanas`  
- `Fundamentos de segurança Microsoft, 5 semanas`  
- `Power Platform, 7 semanas`  
- `Serviços Azure AI, 12 semanas`  
- `Arquitetura cloud, 9 semanas`

Estes exemplos demonstram a flexibilidade da app para diferentes objetivos de aprendizagem e prazos.

## Referências

- [Documentação Chainlit](https://docs.chainlit.io/)  
- [Documentação MCP](https://github.com/MicrosoftDocs/mcp)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.