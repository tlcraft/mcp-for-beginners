<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:29:03+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "ja"
}
-->
# Visual Studio CodeのAI Toolkit拡張機能でサーバーを利用する

AIエージェントを作るとき、賢い応答を生成するだけでなく、エージェントに行動を起こす能力を持たせることも重要です。そこで登場するのがModel Context Protocol（MCP）です。MCPは、エージェントが外部のツールやサービスに一貫した方法でアクセスできるようにします。まるでエージェントを実際に使えるツールボックスに接続するようなイメージです。

例えば、エージェントを計算機のMCPサーバーに接続すると、「47かける89は？」というプロンプトを受け取るだけで計算ができるようになり、ロジックをハードコードしたりカスタムAPIを作成したりする必要がなくなります。

## 概要

このレッスンでは、Visual Studio Codeの[AI Toolkit](https://aka.ms/AIToolkit)拡張機能を使って、計算機のMCPサーバーをエージェントに接続し、自然言語を通じて加算、減算、乗算、除算などの計算を実行できるようにする方法を解説します。

AI Toolkitは、エージェント開発を効率化する強力なVisual Studio Code拡張機能です。AIエンジニアはローカルやクラウド上で生成AIモデルを開発・テストしながら、簡単にAIアプリケーションを構築できます。現在利用可能な主要な生成モデルのほとんどに対応しています。

*注意*: AI Toolkitは現在、PythonとTypeScriptをサポートしています。

## 学習目標

このレッスンを終えると、以下ができるようになります：

- AI Toolkitを使ってMCPサーバーを利用する方法
- エージェント設定を構成し、MCPサーバーが提供するツールを検出・活用できるようにする方法
- 自然言語を通じてMCPツールを利用する方法

## アプローチ

全体の流れは以下の通りです：

- エージェントを作成し、システムプロンプトを定義する
- 計算機ツールを持つMCPサーバーを作成する
- Agent BuilderをMCPサーバーに接続する
- 自然言語を使ってエージェントのツール呼び出しをテストする

流れがわかったところで、MCPを通じて外部ツールを活用できるようエージェントを設定し、その能力を高めましょう！

## 前提条件

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code用AI Toolkit](https://aka.ms/AIToolkit)

## 演習：サーバーの利用

この演習では、Visual Studio Code内でAI Toolkitを使い、MCPサーバーのツールを備えたAIエージェントを構築、実行、拡張します。

### -0- 事前準備：My ModelsにOpenAI GPT-4oモデルを追加する

演習では**GPT-4o**モデルを使用します。エージェントを作成する前に、**My Models**にモデルを追加してください。

![Visual Studio CodeのAI Toolkit拡張機能でのモデル選択画面のスクリーンショット。見出しは「Find the right model for your AI Solution」、サブタイトルはAIモデルの発見、テスト、展開を促しています。「Popular Models」にはDeepSeek-R1（GitHubホスト）、OpenAI GPT-4o、OpenAI GPT-4.1、OpenAI o1、Phi 4 Mini（CPU - 小型、高速）、DeepSeek-R1（Ollamaホスト）の6つのモデルカードが表示されており、それぞれ「Add」や「Try in Playground」ボタンがあります。](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.ja.png)

1. **Activity Bar**から**AI Toolkit**拡張機能を開く。
1. **Catalog**セクションで**Models**を選択し、**Model Catalog**を開く。**Models**を選ぶと新しいエディタタブで**Model Catalog**が表示される。
1. 検索バーに**OpenAI GPT-4o**と入力する。
1. **+ Add**をクリックしてモデルを**My Models**リストに追加する。**Hosted by GitHub**のモデルを選んでいることを確認する。
1. **Activity Bar**で**OpenAI GPT-4o**モデルがリストに表示されていることを確認する。

### -1- エージェントの作成

**Agent (Prompt) Builder**を使うと、自分だけのAIエージェントを作成・カスタマイズできます。このセクションでは新しいエージェントを作成し、会話を担当するモデルを割り当てます。

![Visual Studio CodeのAI Toolkit拡張機能での「Calculator Agent」ビルダー画面のスクリーンショット。左パネルには「OpenAI GPT-4o (via GitHub)」モデルが選択されており、システムプロンプトは「You are a professor in university teaching math」、ユーザープロンプトは「Explain to me the Fourier equation in simple terms」と表示。ツール追加やMCP Server有効化、構造化出力選択のボタンがあり、下部に青い「Run」ボタン。右パネルには「Get Started with Examples」としてWeb Developerなど3つのサンプルエージェントがリストアップされている。](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.ja.png)

1. **Activity Bar**から**AI Toolkit**拡張機能を開く。
1. **Tools**セクションで**Agent (Prompt) Builder**を選択し、新しいエディタタブで開く。
1. **+ New Agent**ボタンをクリック。コマンドパレットでセットアップウィザードが起動する。
1. 名前に**Calculator Agent**と入力し、Enterを押す。
1. **Agent (Prompt) Builder**の**Model**欄で**OpenAI GPT-4o (via GitHub)**モデルを選択する。

### -2- エージェントのシステムプロンプトを作成する

エージェントの枠組みができたら、その性格や目的を定義します。このセクションでは**Generate system prompt**機能を使い、計算機エージェントとしての振る舞いを説明するシステムプロンプトをモデルに作成してもらいます。

![Visual Studio CodeのAI Toolkitでの「Calculator Agent」画面のスクリーンショット。モーダルウィンドウ「Generate a prompt」が開いており、プロンプトテンプレートを基本情報を共有して生成できると説明。テキストボックスには「You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.」という例のシステムプロンプトが入力されている。下に「Close」と「Generate」ボタン。背景にはエージェント設定の一部が見え、選択モデル「OpenAI GPT-4o (via GitHub)」やシステム・ユーザープロンプト欄がある。](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.ja.png)

1. **Prompts**セクションで**Generate system prompt**ボタンをクリック。プロンプトビルダーが開き、AIがシステムプロンプトを生成する。
1. **Generate a prompt**ウィンドウで次の内容を入力：`You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. **Generate**ボタンをクリック。右下に生成中の通知が表示される。完了すると、生成されたプロンプトが**Agent (Prompt) Builder**の**System prompt**欄に表示される。
1. **System prompt**を確認し、必要に応じて修正する。

### -3- MCPサーバーの作成

エージェントのシステムプロンプトを定義して行動を導いたら、次は実用的な機能を持たせましょう。このセクションでは、加算、減算、乗算、除算の計算ツールを持つ計算機MCPサーバーを作成します。これにより、エージェントは自然言語の指示に応じてリアルタイムで計算を実行できるようになります。

![Visual Studio CodeのAI Toolkit拡張機能でのCalculator Agent画面下部のスクリーンショット。「Tools」と「Structure output」の展開可能なメニュー、出力形式選択のドロップダウンが「text」に設定されている。「+ MCP Server」ボタンが右側にあり、ツールセクションの上には画像アイコンのプレースホルダーが表示されている。](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.ja.png)

AI ToolkitにはMCPサーバーを簡単に作成できるテンプレートが用意されています。ここではPythonテンプレートを使って計算機MCPサーバーを作成します。

*注意*: AI Toolkitは現在PythonとTypeScriptをサポートしています。

1. **Agent (Prompt) Builder**の**Tools**セクションで**+ MCP Server**ボタンをクリック。コマンドパレットでセットアップウィザードが起動する。
1. **+ Add Server**を選択。
1. **Create a New MCP Server**を選択。
1. テンプレートに**python-weather**を選択。
1. MCPサーバーテンプレートの保存先に**Default folder**を選択。
1. サーバー名に**Calculator**を入力。
1. 新しいVisual Studio Codeウィンドウが開く。**Yes, I trust the authors**を選択。
1. ターミナル（**Terminal** > **New Terminal**）で仮想環境を作成：`python -m venv .venv`
1. ターミナルで仮想環境を有効化：
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. ターミナルで依存関係をインストール：`pip install -e .[dev]`
1. **Activity Bar**の**Explorer**ビューで**src**ディレクトリを展開し、**server.py**を開く。
1. **server.py**のコードを以下に置き換え、保存する：

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

### -4- 計算機MCPサーバーを使ってエージェントを実行する

ツールを持ったエージェントができたので、実際に使ってみましょう。このセクションでは、エージェントにプロンプトを送信し、計算機MCPサーバーの適切なツールを活用しているかテスト・検証します。

![Visual Studio CodeのAI Toolkit拡張機能でのCalculator Agent画面のスクリーンショット。左パネルの「Tools」にはlocal-server-calculator_serverというMCPサーバーが追加されており、add、subtract、multiply、divideの4つのツールが表示。4つのツールがアクティブなバッジあり。下には折りたたまれた「Structure output」セクションと青い「Run」ボタン。右パネルの「Model Response」では、エージェントがmultiplyとsubtractツールを呼び出し、それぞれ{"a": 3, "b": 25}と{"a": 75, "b": 20}を入力。最終的な「Tool Response」は75.0。下部に「View Code」ボタンがある。](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.ja.png)

ローカル開発環境でAgent BuilderをMCPクライアントとして使い、計算機MCPサーバーを実行します。

1. `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b`の値が**subtract**ツールに割り当てられます。
    - 各ツールの応答はそれぞれの**Tool Response**に表示されます。
    - モデルの最終出力は最終的な**Model Response**に表示されます。
1. 追加のプロンプトを送信し、エージェントの動作をさらにテストしてください。**User prompt**欄をクリックして既存のプロンプトを書き換えられます。
1. テストが終わったら、**terminal**で**CTRL/CMD+C**を入力してサーバーを停止してください。

## 課題

**server.py**ファイルに新しいツール（例：数値の平方根を返す）を追加してみましょう。新しいツール（または既存のツール）を使うための追加プロンプトを送信してください。ツールを追加したらサーバーを再起動し、新しいツールを読み込むのを忘れずに。

## 解答例

[解答例](./solution/README.md)

## まとめ

この章のポイントは以下の通りです：

- AI Toolkit拡張機能は、MCPサーバーとそのツールを簡単に利用できる優れたクライアントです。
- MCPサーバーに新しいツールを追加することで、エージェントの機能を拡張し、変化する要件に対応できます。
- AI ToolkitにはPythonのMCPサーバーテンプレートなど、カスタムツール作成を簡単にするテンプレートが含まれています。

## 追加リソース

- [AI Toolkitドキュメント](https://aka.ms/AIToolkit/doc)

## 次に進む

次へ：[Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**免責事項**:  
本書類はAI翻訳サービス「Co-op Translator」（https://github.com/Azure/co-op-translator）を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。