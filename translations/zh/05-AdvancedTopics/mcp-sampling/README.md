<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0de03f7a3ff0204d8356bc61325c459",
  "translation_date": "2025-06-02T20:00:42+00:00",
  "source_file": "05-AdvancedTopics/mcp-sampling/README.md",
  "language_code": "zh"
}
-->
## 确定性采样

对于需要输出一致性的应用，确定性采样确保结果可复现。它通过使用固定的随机种子并将温度设置为零来实现这一点。

下面的示例展示了如何在不同编程语言中实现确定性采样。

## 动态采样配置

智能采样会根据每个请求的上下文和需求调整参数。这意味着根据任务类型、用户偏好或历史表现，动态调整温度、top_p 和惩罚等参数。

下面展示了如何在不同编程语言中实现动态采样。

## 接下来是什么

- [Scaling](../mcp-scaling/README.md)

**免责声明**：  
本文件使用AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)进行翻译。尽管我们力求准确，但请注意自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们概不负责。