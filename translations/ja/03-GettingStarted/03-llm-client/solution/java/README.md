<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:22:34+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "ja"
}
-->
# Calculator LLM Client

LangChain4j を使って MCP（Model Context Protocol）電卓サービスに GitHub Models 統合で接続する方法を示す Java アプリケーションです。

## 前提条件

- Java 21 以上
- Maven 3.6+（または同梱の Maven ラッパーを使用）
- GitHub Models にアクセスできる GitHub アカウント
- `http://localhost:8080` で動作している MCP 電卓サービス

## GitHub トークンの取得

このアプリケーションは GitHub Models を使用するため、GitHub のパーソナルアクセストークンが必要です。トークン取得手順は以下の通りです。

### 1. GitHub Models にアクセス
1. [GitHub Models](https://github.com/marketplace/models) にアクセス
2. GitHub アカウントでサインイン
3. まだアクセス申請していなければ、GitHub Models へのアクセスをリクエスト

### 2. パーソナルアクセストークンを作成
1. [GitHub 設定 → 開発者設定 → パーソナルアクセストークン → トークン（クラシック）](https://github.com/settings/tokens) に移動
2. 「新しいトークンを生成」→「新しいトークンを生成（クラシック）」をクリック
3. トークンに分かりやすい名前を付ける（例: 「MCP Calculator Client」）
4. 有効期限を必要に応じて設定
5. 以下のスコープを選択：
   - `repo`（プライベートリポジトリにアクセスする場合）
   - `user:email`
6. 「トークンを生成」をクリック
7. **重要**：トークンはこの時点で必ずコピーしてください。再度表示できません！

### 3. 環境変数の設定

#### Windows（コマンドプロンプト）:
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows（PowerShell）:
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## セットアップとインストール

1. **プロジェクトディレクトリをクローンまたは移動**

2. **依存関係をインストール**:
   ```cmd
   mvnw clean install
   ```
   または Maven がグローバルにインストールされている場合：
   ```cmd
   mvn clean install
   ```

3. **環境変数を設定**（「GitHub トークンの取得」セクションを参照）

4. **MCP 電卓サービスを起動**:
   `http://localhost:8080/sse` で chapter 1 の MCP 電卓サービスが起動していることを確認してください。クライアント起動前にサービスが動作している必要があります。

## アプリケーションの実行

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## アプリケーションの動作内容

このアプリケーションは電卓サービスとの主な3つのやり取りを示します：

1. **加算**：24.5 と 17.3 の合計を計算
2. **平方根**：144 の平方根を計算
3. **ヘルプ**：利用可能な電卓関数を表示

## 期待される出力

正常に実行されると、以下のような出力が表示されます：

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## トラブルシューティング

### よくある問題

1. **"GITHUB_TOKEN 環境変数が設定されていません"**
   - `GITHUB_TOKEN` を正しく設定したか確認してください。

### デバッグ

デバッグログを有効にするには、実行時に以下の JVM 引数を追加してください：
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## 設定

アプリケーションの設定内容：
- GitHub Models を `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse` で使用
- リクエストのタイムアウトは 60 秒
- デバッグ用にリクエスト/レスポンスのログを有効化

## 依存関係

このプロジェクトで使用している主な依存関係：
- **LangChain4j**：AI 統合とツール管理用
- **LangChain4j MCP**：Model Context Protocol サポート用
- **LangChain4j GitHub Models**：GitHub Models 統合用
- **Spring Boot**：アプリケーションフレームワークと依存性注入用

## ライセンス

このプロジェクトは Apache License 2.0 の下でライセンスされています。詳細は [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) ファイルを参照してください。

**免責事項**:  
本書類はAI翻訳サービス[Co-op Translator](https://github.com/Azure/co-op-translator)を使用して翻訳されています。正確性の確保に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご了承ください。原文の言語による文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。