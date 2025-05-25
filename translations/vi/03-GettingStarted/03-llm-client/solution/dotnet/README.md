<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:42:48+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "vi"
}
-->
# Chạy mẫu này

> [!NOTE]
> Mẫu này giả định rằng bạn đang sử dụng một phiên bản GitHub Codespaces. Nếu bạn muốn chạy nó trên máy tính cá nhân, bạn cần thiết lập một mã truy cập cá nhân trên GitHub.

## Cài đặt thư viện

```sh
dotnet restore
```

Nên cài đặt các thư viện sau: Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtocol

## Chạy

```sh 
dotnet run
```

Bạn nên thấy đầu ra tương tự như:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

Phần lớn đầu ra chỉ là gỡ lỗi nhưng điều quan trọng là bạn đang liệt kê công cụ từ MCP Server, biến chúng thành công cụ LLM và bạn sẽ có phản hồi từ MCP client "Sum 6".

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn thông tin chính thống. Đối với thông tin quan trọng, khuyến nghị sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm cho bất kỳ hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.