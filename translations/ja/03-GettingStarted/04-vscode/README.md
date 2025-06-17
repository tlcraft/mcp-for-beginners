<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T15:25:33+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "ja"
}
-->
次のセクションでは、ビジュアルインターフェースの使い方についてさらに詳しく説明します。

## アプローチ

高レベルでのアプローチは以下の通りです：

- MCPサーバーを見つけるための設定ファイルを作成する。
- そのサーバーを起動/接続し、機能一覧を取得する。
- GitHub Copilot Chatインターフェースを通じてその機能を使う。

よし、流れがわかったので、Visual Studio Codeを使ってMCPサーバーを利用する練習をしてみましょう。

## 演習：サーバーの利用

この演習では、Visual Studio CodeがあなたのMCPサーバーを見つけられるように設定し、GitHub Copilot Chatインターフェースから利用できるようにします。

### -0- 事前準備、MCPサーバーの検出を有効化する

MCPサーバーの検出を有効にする必要があるかもしれません。

1. `File -> Preferences -> Settings` で `` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` を settings.json ファイル内で探します。

### -1- 設定ファイルの作成

まず、プロジェクトのルートに設定ファイルを作成します。MCP.jsonというファイルを.vscodeフォルダに置く必要があります。内容は以下のようになります：

```text
.vscode
|-- mcp.json
```

次に、サーバーのエントリを追加する方法を見てみましょう。

### -2- サーバーの設定

*mcp.json* に次の内容を追加します：

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

上記はNode.jsで書かれたサーバーを起動する簡単な例です。他のランタイムの場合は、`command` and `args` を使ってサーバー起動用の正しいコマンドを指定してください。

### -3- サーバーの起動

エントリを追加したので、サーバーを起動しましょう：

1. *mcp.json* のエントリを見つけて、「再生」アイコンを探します：

  ![Visual Studio Codeでのサーバー起動](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.ja.png)  

1. 「再生」アイコンをクリックすると、GitHub Copilot Chatのツールアイコンに利用可能なツール数が増えるはずです。そのツールアイコンをクリックすると、登録されたツールの一覧が表示されます。GitHub Copilotに使わせたいツールはチェックを入れ、使わせたくないツールはチェックを外せます：

  ![Visual Studio Codeでのツール表示](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.ja.png)

1. ツールを実行するには、ツールの説明に合致するプロンプトを入力します。例えば「add 22 to 1」のようなプロンプトです：

  ![GitHub Copilotからツールを実行](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ja.png)

  23という応答が返ってくるはずです。

## 課題

*mcp.json* にサーバーエントリを追加し、サーバーの起動・停止ができることを確認してください。また、GitHub Copilot Chatインターフェースを通じてサーバーのツールと通信できることも確認しましょう。

## 解答例

[解答例](./solution/README.md)

## 重要ポイント

この章の重要ポイントは以下の通りです：

- Visual Studio Codeは複数のMCPサーバーとそのツールを利用できる優れたクライアントです。
- GitHub Copilot Chatインターフェースがサーバーとのやり取りの窓口となります。
- *mcp.json*ファイルのサーバーエントリ設定時にAPIキーなどのユーザー入力を促し、それをMCPサーバーに渡すことも可能です。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 追加リソース

- [Visual Studio ドキュメント](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## 次にやること

- 次へ：[SSEサーバーの作成](/03-GettingStarted/05-sse-server/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用に起因するいかなる誤解や誤訳についても、当方は一切の責任を負いかねます。