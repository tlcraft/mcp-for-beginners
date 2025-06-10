<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3f252a62f059360855de5331a575898",
  "translation_date": "2025-06-10T07:05:13+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/README.md",
  "language_code": "ja"
}
-->
# Weather MCP Server

これは、モックレスポンスを使った天気ツールを実装したPythonのサンプルMCPサーバーです。ご自身のMCPサーバーの足がかりとして利用できます。以下の機能が含まれています：

- **Weather Tool**：指定された場所に基づいてモックされた天気情報を提供するツール。
- **Git Clone Tool**：指定したフォルダーにGitリポジトリをクローンするツール。
- **VS Code Open Tool**：VS CodeまたはVS Code Insidersでフォルダーを開くツール。
- **Connect to Agent Builder**：MCPサーバーをAgent Builderに接続してテストやデバッグができる機能。
- **Debug in [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**：MCP Inspectorを使ってMCPサーバーをデバッグする機能。

## Weather MCP Serverテンプレートの始め方

> **前提条件**
>
> ローカル開発環境でMCPサーバーを動かすには、以下が必要です：
>
> - [Python](https://www.python.org/)
> - [Git](https://git-scm.com/)（git_clone_repoツール用）
> - [VS Code](https://code.visualstudio.com/) または [VS Code Insiders](https://code.visualstudio.com/insiders/)（open_in_vscodeツール用）
> - （任意 - uvを好む場合）[uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## 環境準備

このプロジェクトの環境設定には2つの方法があります。お好みに合わせて選択してください。

> 注意：仮想環境作成後は、VSCodeまたはターミナルをリロードして仮想環境のPythonが使用されていることを確認してください。

| 方法 | 手順 |
| -------- | ----- |
| `uv`を使用 | 1. 仮想環境作成: `uv venv` <br>2. VSCodeのコマンド「***Python: Select Interpreter***」を実行し、作成した仮想環境のPythonを選択<br>3. 依存関係（開発依存含む）をインストール: `uv pip install -r pyproject.toml --extra dev` |
| `pip`を使用 | 1. 仮想環境作成: `python -m venv .venv` <br>2. VSCodeのコマンド「***Python: Select Interpreter***」を実行し、作成した仮想環境のPythonを選択<br>3. 依存関係（開発依存含む）をインストール: `pip install -e .[dev]` |

環境設定が完了したら、Agent BuilderをMCPクライアントとして使い、ローカル開発環境でサーバーを起動して始めましょう：
1. VS Codeのデバッグパネルを開き、`Debug in Agent Builder`を選択するか、`F5`を押してMCPサーバーのデバッグを開始します。
2. AI Toolkit Agent Builderを使って[このプロンプト](../../../../../../../../../../../open_prompt_builder)でサーバーをテストします。サーバーは自動的にAgent Builderに接続されます。
3. `Run`をクリックして、プロンプトでサーバーをテストします。

**おめでとうございます**！Agent BuilderをMCPクライアントとして使い、ローカル開発環境でWeather MCP Serverを正常に起動できました。
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## テンプレートに含まれるもの

| フォルダー / ファイル | 内容                                     |
| ------------ | -------------------------------------------- |
| `.vscode`    | デバッグ用のVSCodeファイル                   |
| `.aitk`      | AI Toolkit用の設定ファイル                |
| `src`        | Weather MCP Serverのソースコード           |

## Weather MCP Serverのデバッグ方法

> 注意：
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector)はMCPサーバーのテストやデバッグ用のビジュアル開発ツールです。
> - すべてのデバッグモードはブレークポイントをサポートしているため、ツールの実装コードにブレークポイントを設定できます。

## 利用可能なツール

### Weather Tool  
`get_weather`ツールは指定された場所のモック天気情報を提供します。

| パラメーター | 型 | 説明 |
| --------- | ---- | ----------- |
| `location` | string | 天気情報を取得する場所（例：都市名、州、座標など） |

### Git Clone Tool  
`git_clone_repo`ツールは指定されたフォルダーにGitリポジトリをクローンします。

| パラメーター | 型 | 説明 |
| --------- | ---- | ----------- |
| `repo_url` | string | クローンするGitリポジトリのURL |
| `target_folder` | string | リポジトリをクローンするフォルダーのパス |

ツールは以下のJSONオブジェクトを返します：
- `success`：操作が成功したかどうかのBoolean値
- `target_folder` または `error`：クローンしたリポジトリのパスまたはエラーメッセージ

### VS Code Open Tool  
`open_in_vscode`ツールはフォルダーをVS CodeまたはVS Code Insidersアプリで開きます。

| パラメーター | 型 | 説明 |
| --------- | ---- | ----------- |
| `folder_path` | string | 開くフォルダーのパス |
| `use_insiders` | boolean (オプション) | 通常のVS CodeではなくVS Code Insidersを使うかどうか |

ツールは以下のJSONオブジェクトを返します：
- `success`：操作が成功したかどうかのBoolean値
- `message` または `error`：確認メッセージまたはエラーメッセージ

## デバッグモード | 説明 | デバッグ手順 |
| ---------- | ----------- | --------------- |
| Agent Builder | AI ToolkitのAgent Builderを通じてMCPサーバーをデバッグします。 | 1. VS Codeのデバッグパネルを開き、`Debug in Agent Builder`を選択して`F5`を押し、MCPサーバーのデバッグを開始します。<br>2. AI Toolkit Agent Builderを使って[このプロンプト](../../../../../../../../../../../open_prompt_builder)でサーバーをテストします。サーバーは自動的にAgent Builderに接続されます。<br>3. `Run`をクリックしてプロンプトでサーバーをテストします。 |
| MCP Inspector | MCP Inspectorを使ってMCPサーバーをデバッグします。 | 1. [Node.js](https://nodejs.org/)をインストール<br> 2. Inspectorのセットアップ: `cd inspector` && `npm install` <br> 3. VS Codeのデバッグパネルを開き、`Debug SSE in Inspector (Edge)`または`Debug SSE in Inspector (Chrome)`を選択。F5を押してデバッグ開始。<br> 4. MCP Inspectorがブラウザで起動したら、`Connect`ボタンを押してこのMCPサーバーに接続。<br> 5. その後、`List Tools`し、ツールを選択、パラメーターを入力して`Run Tool`し、サーバーコードをデバッグできます。<br> |

## デフォルトポートとカスタマイズ

| デバッグモード | ポート | 定義ファイル | カスタマイズ方法 | 備考 |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)、[\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json)を編集してポートを変更可能 | なし |
| MCP Inspector | 3001 (サーバー); 5173 と 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json) | [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/launch.json)、[tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.vscode/tasks.json)、[\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/src/__init__.py)、[mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/code/github_mcp_server/.aitk/mcp.json)を編集してポートを変更可能 | なし |

## フィードバック

このテンプレートに関するご意見や提案がありましたら、[AI Toolkit GitHubリポジトリ](https://github.com/microsoft/vscode-ai-toolkit/issues)にてIssueをお開きください。

**免責事項**:  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。正式な内容については、原文の言語で記載された文書を権威ある情報源としてご参照ください。重要な情報については、専門の人間翻訳を推奨します。本翻訳の使用により生じたいかなる誤解や誤訳についても、当方は一切責任を負いかねます。