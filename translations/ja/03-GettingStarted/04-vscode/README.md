<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "222e01c3002a33355806d60d558d9429",
  "translation_date": "2025-07-14T09:30:13+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "ja"
}
-->
次のセクションでは、ビジュアルインターフェースの使い方について詳しく説明します。

## アプローチ

大まかな流れは以下の通りです：

- MCPサーバーを見つけるための設定ファイルを作成する。
- サーバーを起動または接続し、その機能一覧を取得する。
- GitHub Copilot Chatインターフェースを通じてその機能を利用する。

流れが理解できたので、次はVisual Studio Codeを使ってMCPサーバーを利用する練習をしてみましょう。

## 演習：サーバーの利用

この演習では、Visual Studio CodeがあなたのMCPサーバーを見つけられるように設定し、GitHub Copilot Chatインターフェースから利用できるようにします。

### -0- 事前準備：MCPサーバーの検出を有効化する

MCPサーバーの検出を有効にする必要があるかもしれません。

1. Visual Studio Codeで `ファイル -> 設定 -> 設定` に移動します。

2. 「MCP」で検索し、settings.jsonファイル内の `chat.mcp.discovery.enabled` を有効にします。

### -1- 設定ファイルの作成

まず、プロジェクトのルートに設定ファイルを作成します。`.vscode` フォルダ内に `MCP.json` というファイルを作成してください。内容は以下のようになります：

```text
.vscode
|-- mcp.json
```

次に、サーバーのエントリを追加する方法を見てみましょう。

### -2- サーバーの設定

*mcp.json* に以下の内容を追加します：

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

上記はNode.jsで書かれたサーバーを起動する簡単な例です。その他のランタイムの場合は、`command` と `args` を使って適切な起動コマンドを指定してください。

### -3- サーバーの起動

エントリを追加したら、サーバーを起動しましょう：

1. *mcp.json* 内のエントリを見つけ、「再生」アイコンがあることを確認します：

  ![Visual Studio Codeでサーバーを起動](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.ja.png)  

2. 「再生」アイコンをクリックすると、GitHub Copilot Chatのツールアイコンに利用可能なツールの数が増えます。ツールアイコンをクリックすると登録されたツールの一覧が表示されます。GitHub Copilotにツールをコンテキストとして使わせたい場合は、チェックを入れたり外したりできます：

  ![Visual Studio Codeでツールを表示](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.ja.png)

3. ツールを実行するには、ツールの説明に合致するプロンプトを入力します。例えば「add 22 to 1」のようなプロンプトです：

  ![GitHub Copilotからツールを実行](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ja.png)

  23という応答が返ってくるはずです。

## 課題

*mcp.json* にサーバーのエントリを追加し、サーバーの起動・停止ができることを確認してください。また、GitHub Copilot Chatインターフェースを通じてサーバー上のツールと通信できることも確認しましょう。

## 解答例

[解答例](./solution/README.md)

## 重要なポイント

この章のポイントは以下の通りです：

- Visual Studio Codeは複数のMCPサーバーとそのツールを利用できる優れたクライアントです。
- GitHub Copilot Chatインターフェースがサーバーとのやり取りの窓口となります。
- APIキーなどの入力をユーザーに促し、それを *mcp.json* のサーバー設定に渡すことも可能です。

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 追加リソース

- [Visual Studio ドキュメント](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## 次に進む

- 次へ: [SSEサーバーの作成](../05-sse-server/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。