<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3cb0da3badd51d73ab78ebade2827d98",
  "translation_date": "2025-07-14T02:19:27+00:00",
  "source_file": "05-AdvancedTopics/mcp-sampling/README.md",
  "language_code": "zh"
}
-->
## 确定性采样

对于需要一致输出的应用，确定性采样确保结果可复现。它通过使用固定的随机种子并将温度设置为零来实现这一点。

下面的示例展示了如何在不同编程语言中实现确定性采样。

## 动态采样配置

智能采样会根据每个请求的上下文和需求调整参数。这意味着根据任务类型、用户偏好或历史表现，动态调整温度、top_p 和惩罚参数。

下面展示了如何在不同编程语言中实现动态采样。

## 接下来

- [5.7 扩展](../mcp-scaling/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们概不负责。