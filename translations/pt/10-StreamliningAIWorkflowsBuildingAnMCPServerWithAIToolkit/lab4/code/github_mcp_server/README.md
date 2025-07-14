<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-07-14T08:56:07+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "pt"
}
-->
# Weather MCP Server

Este é um exemplo de MCP Server em Python que implementa ferramentas meteorológicas com respostas simuladas. Pode ser usado como base para o seu próprio MCP Server. Inclui as seguintes funcionalidades:

- **Weather Tool**: Uma ferramenta que fornece informações meteorológicas simuladas com base na localização fornecida.
- **Git Clone Tool**: Uma ferramenta que clona um repositório git para uma pasta especificada.
- **VS Code Open Tool**: Uma ferramenta que abre uma pasta no VS Code ou VS Code Insiders.
- **Connect to Agent Builder**: Uma funcionalidade que permite ligar o MCP server ao Agent Builder para testes e depuração.
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: Uma funcionalidade que permite depurar o MCP Server usando o MCP Inspector.

## Começar com o template Weather MCP Server

> **Pré-requisitos**
>
> Para executar o MCP Server na sua máquina de desenvolvimento local, vai precisar de:
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/) (Necessário para a ferramenta git_clone_repo)
> - [VS Code](https://code.visualstudio.com/) ou [VS Code Insiders](https://code.visualstudio.com/insiders/) (Necessário para a ferramenta open_in_vscode)
> - (*Opcional - se preferir uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## Preparar o ambiente

Existem duas formas de configurar o ambiente para este projeto. Pode escolher a que preferir.

> Nota: Recarregue o VSCode ou o terminal para garantir que o python do ambiente virtual é usado após criar o ambiente virtual.

| Abordagem | Passos |
| --------- | ------ |
| Usando `uv` | 1. Criar ambiente virtual: `uv venv` <br>2. Executar o comando do VSCode "***Python: Select Interpreter***" e selecionar o python do ambiente virtual criado <br>3. Instalar dependências (incluindo dependências de desenvolvimento): `uv pip install -r pyproject.toml --extra dev` |
| Usando `pip` | 1. Criar ambiente virtual: `python -m venv .venv` <br>2. Executar o comando do VSCode "***Python: Select Interpreter***" e selecionar o python do ambiente virtual criado<br>3. Instalar dependências (incluindo dependências de desenvolvimento): `pip install -e .[dev]` |

Depois de configurar o ambiente, pode executar o servidor na sua máquina local via Agent Builder como MCP Client para começar:
1. Abra o painel de Debug do VS Code. Selecione `Debug in Agent Builder` ou pressione `F5` para iniciar a depuração do MCP server.
2. Use o AI Toolkit Agent Builder para testar o servidor com [este prompt](../../../../../../../../../../open_prompt_builder). O servidor será ligado automaticamente ao Agent Builder.
3. Clique em `Run` para testar o servidor com o prompt.

**Parabéns**! Conseguiu executar com sucesso o Weather MCP Server na sua máquina local via Agent Builder como MCP Client.
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## O que está incluído no template

| Pasta / Ficheiro | Conteúdos                                  |
| ---------------- | ----------------------------------------- |
| `.vscode`        | Ficheiros do VSCode para depuração        |
| `.aitk`          | Configurações para o AI Toolkit            |
| `src`            | Código fonte do weather mcp server         |

## Como depurar o Weather MCP Server

> Notas:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) é uma ferramenta visual para desenvolvedores para testar e depurar MCP servers.
> - Todos os modos de depuração suportam breakpoints, por isso pode adicionar breakpoints no código da implementação das ferramentas.

## Ferramentas Disponíveis

### Weather Tool
A ferramenta `get_weather` fornece informações meteorológicas simuladas para uma localização especificada.

| Parâmetro | Tipo   | Descrição                                      |
| --------- | ------ | ---------------------------------------------- |
| `location` | string | Localização para obter o tempo (ex.: nome da cidade, estado ou coordenadas) |

### Git Clone Tool
A ferramenta `git_clone_repo` clona um repositório git para uma pasta especificada.

| Parâmetro      | Tipo   | Descrição                                  |
| -------------- | ------ | ------------------------------------------ |
| `repo_url`     | string | URL do repositório git a clonar            |
| `target_folder` | string | Caminho para a pasta onde o repositório será clonado |

A ferramenta retorna um objeto JSON com:
- `success`: Booleano que indica se a operação foi bem-sucedida
- `target_folder` ou `error`: O caminho do repositório clonado ou uma mensagem de erro

### VS Code Open Tool
A ferramenta `open_in_vscode` abre uma pasta na aplicação VS Code ou VS Code Insiders.

| Parâmetro     | Tipo    | Descrição                                      |
| ------------- | ------- | ---------------------------------------------- |
| `folder_path` | string  | Caminho para a pasta a abrir                    |
| `use_insiders` | boolean (opcional) | Indica se deve usar o VS Code Insiders em vez do VS Code normal |

A ferramenta retorna um objeto JSON com:
- `success`: Booleano que indica se a operação foi bem-sucedida
- `message` ou `error`: Uma mensagem de confirmação ou uma mensagem de erro

## Modo de Depuração | Descrição | Passos para depurar |
| ----------------- | --------- | ------------------- |
| Agent Builder | Depurar o MCP server no Agent Builder via AI Toolkit. | 1. Abra o painel de Debug do VS Code. Selecione `Debug in Agent Builder` e pressione `F5` para iniciar a depuração do MCP server.<br>2. Use o AI Toolkit Agent Builder para testar o servidor com [este prompt](../../../../../../../../../../open_prompt_builder). O servidor será ligado automaticamente ao Agent Builder.<br>3. Clique em `Run` para testar o servidor com o prompt. |
| MCP Inspector | Depurar o MCP server usando o MCP Inspector. | 1. Instale o [Node.js](https://nodejs.org/)<br> 2. Configure o Inspector: `cd inspector` && `npm install` <br> 3. Abra o painel de Debug do VS Code. Selecione `Debug SSE in Inspector (Edge)` ou `Debug SSE in Inspector (Chrome)`. Pressione F5 para iniciar a depuração.<br> 4. Quando o MCP Inspector abrir no navegador, clique no botão `Connect` para ligar este MCP server.<br> 5. Depois pode `List Tools`, selecionar uma ferramenta, inserir parâmetros e `Run Tool` para depurar o código do servidor.<br> |

## Portas padrão e personalizações

| Modo de Depuração | Portas | Definições | Personalizações | Nota |
| ----------------- | ------ | ---------- | --------------- | ----- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Edite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) para alterar as portas acima. | N/A |
| MCP Inspector | 3001 (Servidor); 5173 e 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | Edite [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json) para alterar as portas acima. | N/A |

## Feedback

Se tiver algum feedback ou sugestões para este template, por favor abra uma issue no [repositório AI Toolkit no GitHub](https://github.com/microsoft/vscode-ai-toolkit/issues)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.