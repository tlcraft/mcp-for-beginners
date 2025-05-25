<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c37fabfbc0dcbc9a4afb6d17e7d3be9f",
  "translation_date": "2025-05-16T15:14:06+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "ja"
}
-->
次のセクションでは、ビジュアルインターフェースの使い方についてさらに詳しく説明します。

## アプローチ

大まかな流れは次の通りです：

- MCPサーバーを見つけるための設定ファイルを作成する。
- そのサーバーを起動／接続し、機能の一覧を取得する。
- GitHub Copilotのチャットインターフェースを通じてその機能を利用する。

流れが分かったところで、Visual Studio Codeを使ってMCPサーバーを操作する演習に挑戦してみましょう。

## 演習：サーバーの利用

この演習では、Visual Studio CodeがMCPサーバーを見つけられるように設定し、GitHub Copilotのチャットインターフェースから使えるようにします。

### -0- 事前準備：MCPサーバーの検出を有効化

MCPサーバーの検出機能を有効にする必要があるかもしれません。

1. `File -> Preferences -> Settings` から設定を開き、settings.jsonファイル内の` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled を有効にします。

### -1- 設定ファイルの作成

まずはプロジェクトのルートに設定ファイルを作成します。`.vscode`というフォルダを作り、その中にMCP.jsonというファイルを配置してください。内容は次のようになります：

```text
.vscode
|-- mcp.json
```

次に、サーバーのエントリを追加する方法を見てみましょう。

### -2- サーバーの設定

*mcp.json* に次の内容を追加してください：

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "cmd",
           "args": [
               "/c", "node", "<absolute path>\\build\\index.js"
           ]
       }
    }
}
```

上記はNode.jsで書かれたサーバーを起動する簡単な例です。他のランタイムの場合は、`command` and `args` を使って適切な起動コマンドを指定してください。

### -3- サーバーの起動

エントリを追加したら、サーバーを起動しましょう：

1. *mcp.json* のエントリを見つけ、「再生」アイコンを探します：

  ![Visual Studio Codeでのサーバー起動](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.ja.png)  

2. 「再生」アイコンをクリックすると、GitHub Copilotチャットのツールアイコンの利用可能なツール数が増えます。ツールアイコンをクリックすると、登録されているツールの一覧が表示されます。各ツールをチェック／チェック解除して、GitHub Copilotがコンテキストとして使うかどうかを選べます：

  ![Visual Studio Codeでのツール表示](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.ja.png)

3. ツールを実行するには、その説明に合うプロンプトを入力します。例えば「add 22 to 1」のようなプロンプトです：

  ![GitHub Copilotからツールを実行](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ja.png)

  23という応答が返ってくるはずです。

## 課題

*mcp.json* にサーバーエントリを追加し、サーバーの起動と停止ができることを確認してください。また、GitHub Copilotのチャットインターフェースを通じてサーバーのツールと通信できることも確認してください。

## 解答例

[解答例](./solution/README.md)

## 重要なポイント

この章のポイントは以下の通りです：

- Visual Studio Codeは複数のMCPサーバーとそのツールを利用できる優れたクライアントです。
- GitHub Copilotのチャットインターフェースがサーバーとのやりとりの手段です。
- ユーザーにAPIキーなどの入力を促し、それを*mcp.json*のサーバー設定に渡すことができます。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 追加リソース

- [Visual Studio ドキュメント](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## 次に進む

- 次へ: [SSEサーバーの作成](/03-GettingStarted/05-sse-server/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期していますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や解釈の違いについて、当方は一切の責任を負いません。