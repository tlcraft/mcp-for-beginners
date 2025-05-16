<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-16T14:58:29+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "zh"
}
-->
# 运行此示例

此示例涉及在客户端使用 LLM。LLM 需要你在 Codespaces 中运行，或者在 GitHub 上设置个人访问令牌才能正常工作。

## -1- 安装依赖项

```bash
npm install
```

## -3- 运行服务器

```bash
npm run build
```

## -4- 运行客户端

```sh
npm run client
```

你应该会看到类似的结果：

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。尽管我们力求准确，但请注意，自动翻译可能存在错误或不准确之处。原始语言版本的文件应被视为权威来源。对于关键信息，建议使用专业人工翻译。因使用本翻译而产生的任何误解或错误解释，我们概不负责。