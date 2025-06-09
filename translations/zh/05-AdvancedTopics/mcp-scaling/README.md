<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9730a53698bf9df8166d0080a8d5b61f",
  "translation_date": "2025-06-02T19:51:50+00:00",
  "source_file": "05-AdvancedTopics/mcp-scaling/README.md",
  "language_code": "zh"
}
-->
## 垂直扩展与资源优化

垂直扩展侧重于优化单个 MCP 服务器实例，以更高效地处理更多请求。可以通过微调配置、使用高效算法和有效管理资源来实现。例如，可以调整线程池、请求超时和内存限制以提升性能。

下面是一个优化 MCP 服务器以实现垂直扩展和资源管理的示例。

## 分布式架构

分布式架构涉及多个 MCP 节点协同工作，处理请求、共享资源并提供冗余。该方法通过允许节点通过分布式系统进行通信和协调，提升了可扩展性和容错能力。

下面是一个使用 Redis 进行协调，实现分布式 MCP 服务器架构的示例。

## 接下来

- [安全](../mcp-security/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意自动翻译可能存在错误或不准确之处。原始文件的原文版本应被视为权威来源。对于关键信息，建议采用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们概不负责。