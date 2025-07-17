<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:31:56+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "ja"
}
-->
# 完全な MCP クライアント例

このディレクトリには、さまざまなプログラミング言語で動作する完全な MCP クライアントの例が含まれています。各クライアントは、メインの README.md チュートリアルで説明されている全機能を示しています。

## 利用可能なクライアント

### 1. Java クライアント (`client_example_java.java`)
- **トランスポート**: HTTP 上の SSE (Server-Sent Events)
- **対象サーバー**: `http://localhost:8080`
- **特徴**: 
  - 接続確立と ping
  - ツール一覧取得
  - 計算機操作（加算、減算、乗算、除算、ヘルプ）
  - エラー処理と結果抽出

**実行方法:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# クライアント (`client_example_csharp.cs`)
- **トランスポート**: 標準入出力 (Stdio)
- **対象サーバー**: dotnet run で起動するローカル .NET MCP サーバー
- **特徴**:
  - stdio トランスポートによる自動サーバー起動
  - ツールおよびリソース一覧取得
  - 計算機操作
  - JSON 結果解析
  - 包括的なエラー処理

**実行方法:**
```bash
dotnet run
```

### 3. TypeScript クライアント (`client_example_typescript.ts`)
- **トランスポート**: 標準入出力 (Stdio)
- **対象サーバー**: ローカル Node.js MCP サーバー
- **特徴**:
  - MCP プロトコルの完全サポート
  - ツール、リソース、プロンプト操作
  - 計算機操作
  - リソース読み取りとプロンプト実行
  - 強力なエラー処理

**実行方法:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python クライアント (`client_example_python.py`)
- **トランスポート**: 標準入出力 (Stdio)  
- **対象サーバー**: ローカル Python MCP サーバー
- **特徴**:
  - 非同期/await パターンによる操作
  - ツールおよびリソースの検出
  - 計算機操作のテスト
  - リソース内容の読み取り
  - クラスベースの構成

**実行方法:**
```bash
python client_example_python.py
```

## すべてのクライアントに共通する機能

各クライアント実装は以下を示しています：

1. **接続管理**
   - MCP サーバーへの接続確立
   - 接続エラーの処理
   - 適切なクリーンアップとリソース管理

2. **サーバー検出**
   - 利用可能なツールの一覧取得
   - 利用可能なリソースの一覧取得（対応している場合）
   - 利用可能なプロンプトの一覧取得（対応している場合）

3. **ツール呼び出し**
   - 基本的な計算機操作（加算、減算、乗算、除算）
   - サーバー情報のヘルプコマンド
   - 適切な引数の渡し方と結果の処理

4. **エラー処理**
   - 接続エラー
   - ツール実行時のエラー
   - 優雅な失敗処理とユーザーへのフィードバック

5. **結果処理**
   - レスポンスからのテキスト内容抽出
   - 読みやすい出力フォーマット
   - 異なるレスポンス形式の処理

## 前提条件

これらのクライアントを実行する前に、以下を確認してください：

1. **対応する MCP サーバーが起動していること**（`../01-first-server/` から）
2. **選択した言語の必要な依存関係がインストールされていること**
3. **適切なネットワーク接続があること**（HTTP ベースのトランスポートの場合）

## 実装間の主な違い

| 言語       | トランスポート | サーバー起動方法 | 非同期モデル | 主なライブラリ       |
|------------|---------------|------------------|--------------|---------------------|
| Java       | SSE/HTTP      | 外部起動         | 同期         | WebFlux, MCP SDK    |
| C#         | Stdio         | 自動             | Async/Await  | .NET MCP SDK        |
| TypeScript | Stdio         | 自動             | Async/Await  | Node MCP SDK        |
| Python     | Stdio         | 自動             | AsyncIO      | Python MCP SDK      |

## 次のステップ

これらのクライアント例を確認した後は：

1. **クライアントを修正して新機能や操作を追加する**
2. **独自のサーバーを作成し、これらのクライアントでテストする**
3. **異なるトランスポート（SSE と Stdio）を試す**
4. **MCP 機能を統合したより複雑なアプリケーションを構築する**

## トラブルシューティング

### よくある問題

1. **接続拒否**: MCP サーバーが期待するポートやパスで起動しているか確認してください
2. **モジュールが見つからない**: 言語に対応した MCP SDK をインストールしてください
3. **権限拒否**: stdio トランスポートのファイル権限を確認してください
4. **ツールが見つからない**: サーバーが期待するツールを実装しているか確認してください

### デバッグのヒント

1. **MCP SDK の詳細ログを有効にする**
2. **サーバーログでエラーメッセージを確認する**
3. **クライアントとサーバー間でツール名やシグネチャが一致しているか確認する**
4. **まず MCP Inspector でサーバー機能を検証する**

## 関連ドキュメント

- [Main Client Tutorial](./README.md)
- [MCP Server Examples](../../../../03-GettingStarted/01-first-server)
- [MCP with LLM Integration](../../../../03-GettingStarted/03-llm-client)
- [Official MCP Documentation](https://modelcontextprotocol.io/)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。