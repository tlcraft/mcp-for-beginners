<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:29:51+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "ko"
}
-->
# Visual Studio Code용 AI Toolkit 확장 프로그램에서 서버 사용하기

AI 에이전트를 만들 때, 단순히 똑똑한 응답을 생성하는 것만이 중요한 게 아닙니다. 에이전트가 직접 행동할 수 있는 능력을 부여하는 것도 중요하죠. 바로 이때 Model Context Protocol(MCP)이 등장합니다. MCP는 에이전트가 외부 도구와 서비스를 일관된 방식으로 쉽게 접근할 수 있도록 도와줍니다. 마치 에이전트를 실제로 사용할 수 있는 도구 상자에 연결하는 것과 같습니다.

예를 들어, 에이전트를 계산기 MCP 서버에 연결했다고 가정해 봅시다. 그러면 “47 곱하기 89는 얼마야?” 같은 질문을 받기만 해도 에이전트가 직접 계산을 수행할 수 있습니다. 별도의 로직을 하드코딩하거나 맞춤 API를 만들 필요가 없습니다.

## 개요

이 강의에서는 Visual Studio Code의 [AI Toolkit](https://aka.ms/AIToolkit) 확장을 사용해 계산기 MCP 서버를 에이전트에 연결하는 방법을 다룹니다. 이를 통해 에이전트가 자연어를 이용해 덧셈, 뺄셈, 곱셈, 나눗셈 등의 수학 연산을 수행할 수 있게 됩니다.

AI Toolkit은 Visual Studio Code에서 에이전트 개발을 간소화하는 강력한 확장 프로그램입니다. AI 엔지니어는 생성 AI 모델을 로컬이나 클라우드에서 쉽게 개발하고 테스트하여 AI 애플리케이션을 구축할 수 있습니다. 이 확장은 현재 대부분의 주요 생성 모델을 지원합니다.

*참고*: AI Toolkit은 현재 Python과 TypeScript를 지원합니다.

## 학습 목표

이 강의를 마치면 다음을 할 수 있습니다:

- AI Toolkit을 통해 MCP 서버를 활용하는 방법.
- MCP 서버가 제공하는 도구를 발견하고 사용할 수 있도록 에이전트 설정 구성.
- 자연어를 통해 MCP 도구 활용하기.

## 접근 방식

전체적인 흐름은 다음과 같습니다:

- 에이전트를 만들고 시스템 프롬프트를 정의합니다.
- 계산기 도구가 포함된 MCP 서버를 만듭니다.
- Agent Builder를 MCP 서버에 연결합니다.
- 자연어를 사용해 에이전트가 도구를 호출하는지 테스트합니다.

이제 흐름을 이해했으니, MCP를 통해 외부 도구를 활용하도록 AI 에이전트를 설정해 기능을 확장해 봅시다!

## 사전 준비

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code용 AI Toolkit](https://aka.ms/AIToolkit)

## 실습: 서버 사용하기

이번 실습에서는 Visual Studio Code 내 AI Toolkit을 사용해 MCP 서버의 도구로 AI 에이전트를 만들고 실행하며 개선해 봅니다.

### -0- 사전 단계: OpenAI GPT-4o 모델을 My Models에 추가하기

이번 실습에서는 **GPT-4o** 모델을 사용합니다. 에이전트를 만들기 전에 **My Models**에 해당 모델을 추가해야 합니다.

![Visual Studio Code AI Toolkit 확장 프로그램의 모델 선택 인터페이스 스크린샷. "Find the right model for your AI Solution"라는 제목과 AI 모델을 발견, 테스트, 배포하라는 부제목이 있습니다. “Popular Models” 아래에 GitHub 호스팅 DeepSeek-R1, OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), Ollama 호스팅 DeepSeek-R1 등 6개의 모델 카드가 표시됩니다. 각 카드에는 “Add”와 “Try in Playground” 옵션이 있습니다.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.ko.png)

1. **Activity Bar**에서 **AI Toolkit** 확장을 엽니다.
1. **Catalog** 섹션에서 **Models**를 선택해 **Model Catalog**를 엽니다. Models를 선택하면 새 편집기 탭에서 Model Catalog가 열립니다.
1. Model Catalog 검색창에 **OpenAI GPT-4o**를 입력합니다.
1. **+ Add**를 클릭해 모델을 **My Models** 목록에 추가합니다. GitHub에서 호스팅되는 모델을 선택했는지 확인하세요.
1. Activity Bar에서 **OpenAI GPT-4o** 모델이 목록에 나타나는지 확인합니다.

### -1- 에이전트 만들기

**Agent (Prompt) Builder**를 사용하면 자신만의 AI 기반 에이전트를 만들고 맞춤 설정할 수 있습니다. 이 단계에서는 새 에이전트를 만들고 대화를 담당할 모델을 지정합니다.

![Visual Studio Code AI Toolkit 확장 프로그램의 "Calculator Agent" 빌더 인터페이스 스크린샷. 왼쪽 패널에 "OpenAI GPT-4o (via GitHub)" 모델이 선택되어 있고, 시스템 프롬프트는 "You are a professor in university teaching math"이며, 사용자 프롬프트는 "Explain to me the Fourier equation in simple terms"입니다. 도구 추가, MCP Server 활성화, 구조화된 출력 선택 버튼도 보입니다. 하단에 파란색 “Run” 버튼이 있습니다. 오른쪽 패널에는 "Get Started with Examples" 아래에 Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter 등 기능 설명 포함)라는 샘플 에이전트 세 개가 나열되어 있습니다.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.ko.png)

1. **Activity Bar**에서 **AI Toolkit** 확장을 엽니다.
1. **Tools** 섹션에서 **Agent (Prompt) Builder**를 선택합니다. 선택하면 새 편집기 탭에서 Agent (Prompt) Builder가 열립니다.
1. **+ New Agent** 버튼을 클릭합니다. 확장이 **Command Palette**를 통해 설정 마법사를 실행합니다.
1. 이름에 **Calculator Agent**를 입력하고 **Enter**를 누릅니다.
1. **Agent (Prompt) Builder**에서 **Model** 필드에 **OpenAI GPT-4o (via GitHub)** 모델을 선택합니다.

### -2- 에이전트 시스템 프롬프트 생성하기

에이전트 골격이 완성되었으니, 이제 성격과 목적을 정의할 차례입니다. 이 단계에서는 **Generate system prompt** 기능을 사용해 계산기 에이전트로서 에이전트가 수행할 행동을 설명하고, 모델이 시스템 프롬프트를 작성하도록 합니다.

![Visual Studio Code AI Toolkit의 "Calculator Agent" 인터페이스 스크린샷. "Generate a prompt"라는 제목의 모달 창이 열려 있습니다. 모달에는 기본 정보를 공유하면 프롬프트 템플릿을 생성할 수 있다는 설명과 함께, "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result."라는 예시 시스템 프롬프트가 텍스트 박스에 있습니다. 아래에 "Close"와 "Generate" 버튼이 있습니다. 배경에는 선택된 모델 "OpenAI GPT-4o (via GitHub)"와 시스템 및 사용자 프롬프트 필드가 보입니다.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.ko.png)

1. **Prompts** 섹션에서 **Generate system prompt** 버튼을 클릭합니다. 이 버튼을 누르면 AI를 활용해 시스템 프롬프트를 생성하는 프롬프트 빌더가 열립니다.
1. **Generate a prompt** 창에 다음을 입력하세요: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate** 버튼을 클릭합니다. 오른쪽 아래에 시스템 프롬프트 생성 중이라는 알림이 나타납니다. 생성이 완료되면 생성된 프롬프트가 **Agent (Prompt) Builder**의 **System prompt** 필드에 표시됩니다.
1. 시스템 프롬프트를 검토하고 필요하면 수정하세요.

### -3- MCP 서버 만들기

에이전트의 시스템 프롬프트를 정의해 행동과 응답 방식을 정했으니, 이제 실질적인 기능을 갖추도록 하겠습니다. 이번 단계에서는 덧셈, 뺄셈, 곱셈, 나눗셈 계산을 수행하는 도구가 포함된 계산기 MCP 서버를 만듭니다. 이 서버를 통해 에이전트는 자연어 프롬프트에 실시간으로 수학 연산을 수행할 수 있습니다.

![Visual Studio Code AI Toolkit 확장 프로그램의 Calculator Agent 인터페이스 하단 부분 스크린샷. “Tools”와 “Structure output” 확장 메뉴가 보이고, “Choose output format” 드롭다운은 “text”로 설정되어 있습니다. 오른쪽에는 Model Context Protocol 서버를 추가하는 “+ MCP Server” 버튼이 있습니다. 도구 섹션 위에는 이미지 아이콘 자리 표시자가 있습니다.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.ko.png)

AI Toolkit에는 MCP 서버를 쉽게 만들 수 있는 템플릿이 포함되어 있습니다. 여기서는 Python 템플릿을 사용해 계산기 MCP 서버를 만듭니다.

*참고*: AI Toolkit은 현재 Python과 TypeScript를 지원합니다.

1. **Agent (Prompt) Builder**의 **Tools** 섹션에서 **+ MCP Server** 버튼을 클릭합니다. 확장이 **Command Palette**를 통해 설정 마법사를 실행합니다.
1. **+ Add Server**를 선택합니다.
1. **Create a New MCP Server**를 선택합니다.
1. 템플릿으로 **python-weather**를 선택합니다.
1. MCP 서버 템플릿을 저장할 **Default folder**를 선택합니다.
1. 서버 이름으로 **Calculator**를 입력합니다.
1. 새 Visual Studio Code 창이 열리면 **Yes, I trust the authors**를 선택합니다.
1. 터미널에서 가상 환경을 생성합니다: `python -m venv .venv`
1. 터미널에서 가상 환경을 활성화합니다:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. 터미널에서 의존성을 설치합니다: `pip install -e .[dev]`
1. **Activity Bar**의 **Explorer** 뷰에서 **src** 디렉터리를 확장하고 **server.py**를 선택해 편집기로 엽니다.
1. **server.py** 파일의 코드를 다음 내용으로 교체하고 저장합니다:

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

### -4- 계산기 MCP 서버와 함께 에이전트 실행하기

이제 에이전트에 도구가 추가되었으니, 직접 사용해 볼 차례입니다! 이 단계에서는 에이전트에 프롬프트를 보내 계산기 MCP 서버의 적절한 도구를 제대로 활용하는지 테스트하고 검증합니다.

![Visual Studio Code AI Toolkit 확장 프로그램의 Calculator Agent 인터페이스 스크린샷. 왼쪽 패널의 “Tools” 아래에는 local-server-calculator_server라는 MCP 서버가 추가되어 있고, add, subtract, multiply, divide 네 가지 도구가 활성화되어 있습니다. 도구 4개가 활성화됐다는 배지도 보입니다. 아래에는 접힌 “Structure output” 섹션과 파란색 “Run” 버튼이 있습니다. 오른쪽 패널 “Model Response”에는 에이전트가 multiply와 subtract 도구를 각각 입력값 {"a": 3, "b": 25}와 {"a": 75, "b": 20}으로 호출한 기록이 있습니다. 최종 “Tool Response”는 75.0입니다. 하단에 “View Code” 버튼이 있습니다.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.ko.png)

계산기 MCP 서버는 **Agent Builder**를 통해 MCP 클라이언트로서 로컬 개발 머신에서 실행합니다.

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` 값이 **subtract** 도구에 할당됩니다.
    - 각 도구에서 받은 응답은 해당 **Tool Response**에 표시됩니다.
    - 모델의 최종 출력은 최종 **Model Response**에 표시됩니다.
1. 추가 프롬프트를 제출해 에이전트를 더 테스트할 수 있습니다. **User prompt** 필드를 클릭해 기존 프롬프트를 수정하면 됩니다.
1. 테스트가 끝나면 **터미널**에서 **CTRL/CMD+C**를 눌러 서버를 종료할 수 있습니다.

## 과제

**server.py** 파일에 추가 도구 항목(예: 숫자의 제곱근 반환)을 추가해 보세요. 에이전트가 새 도구(또는 기존 도구)를 활용하도록 하는 추가 프롬프트를 제출해 보세요. 새 도구를 반영하려면 서버를 반드시 재시작해야 합니다.

## 솔루션

[Solution](./solution/README.md)

## 주요 내용 정리

이번 장에서 배운 핵심 내용은 다음과 같습니다:

- AI Toolkit 확장은 MCP 서버와 도구를 쉽게 활용할 수 있는 훌륭한 클라이언트입니다.
- MCP 서버에 새로운 도구를 추가해 에이전트의 기능을 확장할 수 있습니다.
- AI Toolkit에는 Python MCP 서버 템플릿 등 맞춤 도구 생성에 도움을 주는 템플릿이 포함되어 있습니다.

## 추가 자료

- [AI Toolkit 문서](https://aka.ms/AIToolkit/doc)

## 다음 단계

다음: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있음을 유의하시기 바랍니다. 원본 문서는 해당 언어로 된 원문이 권위 있는 자료로 간주되어야 합니다. 중요한 정보의 경우, 전문적인 인간 번역을 권장합니다. 본 번역의 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.