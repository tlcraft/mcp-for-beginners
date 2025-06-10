<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:25:33+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "ja"
}
-->
# Weather MCP Server

これはモックレスポンスを使った天気ツールを実装したPythonのサンプルMCPサーバーです。ご自身のMCPサーバーの足がかりとして利用できます。以下の機能が含まれています：

- **Weather Tool**：指定した場所に基づいてモックされた天気情報を提供するツール。
- **Agent Builderへの接続**：MCPサーバーをAgent Builderに接続してテストやデバッグができる機能。
- **[MCP Inspector](https://github.com/modelcontextprotocol/inspector)でのデバッグ**：MCP Inspectorを使ってMCPサーバーをデバッグする機能。

## Weather MCP Serverテンプレートの始め方

> **前提条件**
>
> ローカル開発環境でMCPサーバーを実行するには以下が必要です：
>
> - [Python](https://www.python.org/)
> - （任意 - uvを使いたい場合）[uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## 環境準備

このプロジェクトの環境設定には2つの方法があります。お好みに応じてどちらかを選択してください。

> 注意：仮想環境作成後、VSCodeまたはターミナルを再読み込みして仮想環境のPythonが使用されるようにしてください。

| 方法 | 手順 |
| -------- | ----- |
| `uv` を使用 | 1. 仮想環境を作成：`uv venv` <br>2. VSCodeのコマンド「***Python: Select Interpreter***」を実行し、作成した仮想環境のPythonを選択 <br>3. 依存関係（開発用依存関係含む）をインストール：`uv pip install -r pyproject.toml --extra dev` |
| `pip` を使用 | 1. 仮想環境を作成：`python -m venv .venv` <br>2. VSCodeのコマンド「***Python: Select Interpreter***」を実行し、作成した仮想環境のPythonを選択 <br>3. 依存関係（開発用依存関係含む）をインストール：`pip install -e .[dev]` |

環境設定が完了したら、Agent BuilderをMCPクライアントとして使い、ローカル開発環境でサーバーを起動して始めましょう：
1. VS Codeのデバッグパネルを開きます。`Debug in Agent Builder`を選択するか、`F5`を押してMCPサーバーのデバッグを開始します。
2. AI Toolkit Agent Builderを使って[このプロンプト](../../../../../../../../../../../open_prompt_builder)でサーバーをテストします。サーバーは自動的にAgent Builderに接続されます。
3. `Run`をクリックしてプロンプトでサーバーをテストします。

**おめでとうございます**！Agent BuilderをMCPクライアントとして使い、ローカル環境でWeather MCP Serverを正常に起動できました。
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## テンプレートに含まれるもの

| フォルダー / ファイル | 内容                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | デバッグ用のVSCodeファイル                   |
| `.aitk`      | AI Toolkitの設定ファイル                |
| `src`        | weather mcp serverのソースコード   |

## Weather MCP Serverのデバッグ方法

> 注意：
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector)はMCPサーバーのテストとデバッグ用のビジュアル開発ツールです。
> - すべてのデバッグモードはブレークポイントに対応しているため、ツール実装コードにブレークポイントを設定できます。

| デバッグモード | 説明 | デバッグ手順 |
| ---------- | ----------- | --------------- |
| Agent Builder | AI ToolkitのAgent Builder内でMCPサーバーをデバッグする。 | 1. VS Codeのデバッグパネルを開きます。`Debug in Agent Builder`を選択し、`F5`を押してMCPサーバーのデバッグを開始します。<br>2. AI Toolkit Agent Builderを使って[このプロンプト](../../../../../../../../../../../open_prompt_builder)でサーバーをテストします。サーバーは自動的にAgent Builderに接続されます。<br>3. `Run`をクリックしてプロンプトでサーバーをテストします。 |
| MCP Inspector | MCP Inspectorを使ってMCPサーバーをデバッグする。 | 1. [Node.js](https://nodejs.org/)をインストール<br> 2. Inspectorのセットアップ：`cd inspector` && `npm install` <br> 3. VS Codeのデバッグパネルを開き、`Debug SSE in Inspector (Edge)`または`Debug SSE in Inspector (Chrome)`を選択。F5キーを押してデバッグ開始。<br> 4. ブラウザでMCP Inspectorが起動したら、`Connect`ボタンをクリックしてこのMCPサーバーに接続。<br> 5. その後、`List Tools`し、ツールを選択、パラメータを入力し、`Run Tool`してサーバーコードをデバッグできます。<br> |

## デフォルトポートとカスタマイズ

| デバッグモード | ポート | 定義ファイル | カスタマイズ箇所 | 備考 |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json)、[__init__.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json)を編集してポートを変更可能 | なし |
| MCP Inspector | 3001（サーバー）；5173および3000（Inspector） | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json)、[__init__.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json)を編集してポートを変更可能 | なし |

## フィードバック

このテンプレートについてご意見や提案がありましたら、[AI Toolkit GitHubリポジトリ](https://github.com/microsoft/vscode-ai-toolkit/issues)でIssueを開いてください。

**免責事項**:  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知おきください。原文の母国語版が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。