<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:20:33+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "pt"
}
-->
# Consumindo um servidor da extensão AI Toolkit para Visual Studio Code

Ao construir um agente de IA, não se trata apenas de gerar respostas inteligentes; é também sobre dar ao seu agente a capacidade de agir. É aí que entra o Protocolo de Contexto de Modelo (MCP). O MCP facilita o acesso dos agentes a ferramentas e serviços externos de maneira consistente. Pense nisso como conectar seu agente a uma caixa de ferramentas que ele pode *realmente* usar.

Vamos supor que você conecte um agente ao seu servidor MCP de calculadora. De repente, seu agente pode realizar operações matemáticas apenas recebendo um comando como "Qual é o resultado de 47 vezes 89?"—sem necessidade de codificar lógica ou construir APIs personalizadas.

## Visão Geral

Esta lição aborda como conectar um servidor MCP de calculadora a um agente com a extensão [AI Toolkit](https://aka.ms/AIToolkit) no Visual Studio Code, permitindo que seu agente realize operações matemáticas como adição, subtração, multiplicação e divisão por meio de linguagem natural.

AI Toolkit é uma extensão poderosa para Visual Studio Code que simplifica o desenvolvimento de agentes. Engenheiros de IA podem facilmente construir aplicações de IA desenvolvendo e testando modelos de IA generativa—localmente ou na nuvem. A extensão suporta a maioria dos modelos generativos principais disponíveis hoje.

*Nota*: Atualmente, o AI Toolkit suporta Python e TypeScript.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Consumir um servidor MCP via AI Toolkit.
- Configurar uma configuração de agente para permitir que ele descubra e utilize ferramentas fornecidas pelo servidor MCP.
- Utilizar ferramentas MCP via linguagem natural.

## Abordagem

Aqui está como precisamos abordar isso em um nível alto:

- Criar um agente e definir seu prompt de sistema.
- Criar um servidor MCP com ferramentas de calculadora.
- Conectar o Builder de Agente ao servidor MCP.
- Testar a invocação de ferramentas do agente via linguagem natural.

Ótimo, agora que entendemos o fluxo, vamos configurar um agente de IA para aproveitar ferramentas externas através do MCP, aprimorando suas capacidades!

## Pré-requisitos

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit para Visual Studio Code](https://aka.ms/AIToolkit)

## Exercício: Consumindo um servidor

Neste exercício, você irá construir, executar e aprimorar um agente de IA com ferramentas de um servidor MCP dentro do Visual Studio Code usando o AI Toolkit.

### -0- Pré-passo, adicionar o modelo OpenAI GPT-4o aos Meus Modelos

O exercício utiliza o modelo **GPT-4o**. O modelo deve ser adicionado aos **Meus Modelos** antes de criar o agente.

1. Abra a extensão **AI Toolkit** na **Barra de Atividades**.
1. Na seção **Catálogo**, selecione **Modelos** para abrir o **Catálogo de Modelos**. Selecionar **Modelos** abre o **Catálogo de Modelos** em uma nova aba do editor.
1. Na barra de pesquisa do **Catálogo de Modelos**, digite **OpenAI GPT-4o**.
1. Clique em **+ Adicionar** para adicionar o modelo à sua lista de **Meus Modelos**. Certifique-se de que você selecionou o modelo que está **Hospedado pelo GitHub**.
1. Na **Barra de Atividades**, confirme que o modelo **OpenAI GPT-4o** aparece na lista.

### -1- Criar um agente

O **Agent (Prompt) Builder** permite que você crie e personalize seus próprios agentes com inteligência artificial. Nesta seção, você criará um novo agente e atribuirá um modelo para alimentar a conversa.

1. Abra a extensão **AI Toolkit** na **Barra de Atividades**.
1. Na seção **Ferramentas**, selecione **Agent (Prompt) Builder**. Selecionar **Agent (Prompt) Builder** abre o **Agent (Prompt) Builder** em uma nova aba do editor.
1. Clique no botão **+ Novo Builder**. A extensão lançará um assistente de configuração via o **Command Palette**.
1. Insira o nome **Calculator Agent** e pressione **Enter**.
1. No **Agent (Prompt) Builder**, para o campo **Modelo**, selecione o modelo **OpenAI GPT-4o (via GitHub)**.

### -2- Criar um prompt de sistema para o agente

Com o agente estruturado, é hora de definir sua personalidade e propósito. Nesta seção, você usará o recurso **Generate system prompt** para descrever o comportamento pretendido do agente—neste caso, um agente de calculadora—e fará com que o modelo escreva o prompt de sistema para você.

1. Para a seção **Prompts**, clique no botão **Generate system prompt**. Este botão abre o builder de prompt que utiliza IA para gerar um prompt de sistema para o agente.
1. Na janela **Generate a prompt**, insira o seguinte: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Clique no botão **Generate**. Uma notificação aparecerá no canto inferior direito confirmando que o prompt de sistema está sendo gerado. Uma vez que a geração do prompt estiver completa, o prompt aparecerá no campo **System prompt** do **Agent (Prompt) Builder**.
1. Revise o **System prompt** e modifique se necessário.

### -3- Criar um servidor MCP

Agora que você definiu o prompt de sistema do seu agente—orientando seu comportamento e respostas—é hora de equipar o agente com capacidades práticas. Nesta seção, você criará um servidor MCP de calculadora com ferramentas para executar cálculos de adição, subtração, multiplicação e divisão. Este servidor permitirá que seu agente realize operações matemáticas em tempo real em resposta a prompts de linguagem natural.

AI Toolkit está equipado com templates para facilitar a criação de seu próprio servidor MCP. Usaremos o template Python para criar o servidor MCP de calculadora.

*Nota*: Atualmente, o AI Toolkit suporta Python e TypeScript.

1. Na seção **Ferramentas** do **Agent (Prompt) Builder**, clique no botão **+ MCP Server**. A extensão lançará um assistente de configuração via o **Command Palette**.
1. Selecione **+ Adicionar Servidor**.
1. Selecione **Criar um Novo Servidor MCP**.
1. Selecione **python-weather** como o template.
1. Selecione **Pasta padrão** para salvar o template do servidor MCP.
1. Insira o seguinte nome para o servidor: **Calculator**
1. Uma nova janela do Visual Studio Code será aberta. Selecione **Sim, confio nos autores**.
1. Usando o terminal (**Terminal** > **Novo Terminal**), crie um ambiente virtual: `python -m venv .venv`
1. Usando o terminal, ative o ambiente virtual:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Usando o terminal, instale as dependências: `pip install -e .[dev]`
1. Na visão **Explorer** da **Barra de Atividades**, expanda o diretório **src** e selecione **server.py** para abrir o arquivo no editor.
1. Substitua o código no arquivo **server.py** pelo seguinte e salve:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- Executar o agente com o servidor MCP de calculadora

Agora que seu agente possui ferramentas, é hora de usá-las! Nesta seção, você enviará prompts ao agente para testar e validar se o agente utiliza a ferramenta apropriada do servidor MCP de calculadora.

Você executará o servidor MCP de calculadora na sua máquina de desenvolvimento local via o **Agent Builder** como cliente MCP.

1. Pressione `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Comprei 3 itens com preço de $25 cada, e então usei um desconto de $20. Quanto eu paguei?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` valores são atribuídos para a ferramenta **subtrair**.
    - A resposta de cada ferramenta é fornecida na respectiva **Resposta da Ferramenta**.
    - A saída final do modelo é fornecida na **Resposta do Modelo** final.
1. Envie prompts adicionais para testar ainda mais o agente. Você pode modificar o prompt existente no campo **User prompt** clicando no campo e substituindo o prompt existente.
1. Quando terminar de testar o agente, você pode parar o servidor via o **terminal** digitando **CTRL/CMD+C** para sair.

## Tarefa

Tente adicionar uma entrada de ferramenta adicional ao seu arquivo **server.py** (ex: retornar a raiz quadrada de um número). Envie prompts adicionais que exijam que o agente utilize sua nova ferramenta (ou ferramentas existentes). Certifique-se de reiniciar o servidor para carregar as ferramentas recém-adicionadas.

## Solução

[Solução](./solution/README.md)

## Principais Aprendizados

Os aprendizados deste capítulo são os seguintes:

- A extensão AI Toolkit é um ótimo cliente que permite consumir Servidores MCP e suas ferramentas.
- Você pode adicionar novas ferramentas a servidores MCP, expandindo as capacidades do agente para atender a requisitos em evolução.
- O AI Toolkit inclui templates (ex: templates de servidor MCP em Python) para simplificar a criação de ferramentas personalizadas.

## Recursos Adicionais

- [Documentação do AI Toolkit](https://aka.ms/AIToolkit/doc)

## O que vem a seguir

Próximo: [Lição 4 Implementação Prática](/04-PracticalImplementation/README.md)

**Aviso Legal**:
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritária. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.