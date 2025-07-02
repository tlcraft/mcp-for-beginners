<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:18:01+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "vi"
}
-->
# Model Context Protocol (MCP) Tích hợp với Azure AI Foundry

Hướng dẫn này trình bày cách tích hợp các máy chủ Model Context Protocol (MCP) với các agent của Azure AI Foundry, cho phép điều phối công cụ mạnh mẽ và khả năng AI doanh nghiệp.

## Giới thiệu

Model Context Protocol (MCP) là một tiêu chuẩn mở cho phép các ứng dụng AI kết nối an toàn với các nguồn dữ liệu và công cụ bên ngoài. Khi tích hợp với Azure AI Foundry, MCP cho phép các agent truy cập và tương tác với nhiều dịch vụ, API và nguồn dữ liệu bên ngoài theo cách chuẩn hóa.

Sự tích hợp này kết hợp sự linh hoạt của hệ sinh thái công cụ MCP với khung agent mạnh mẽ của Azure AI Foundry, cung cấp các giải pháp AI cấp doanh nghiệp với khả năng tùy chỉnh sâu rộng.

**Note:** Nếu bạn muốn sử dụng MCP trong Azure AI Foundry Agent Service, hiện tại chỉ hỗ trợ các vùng sau: westus, westus2, uaenorth, southindia và switzerlandnorth

## Mục tiêu học tập

Sau khi hoàn thành hướng dẫn này, bạn sẽ có thể:

- Hiểu về Model Context Protocol và những lợi ích của nó
- Thiết lập các máy chủ MCP để sử dụng với các agent Azure AI Foundry
- Tạo và cấu hình agent với tích hợp công cụ MCP
- Triển khai các ví dụ thực tế sử dụng các máy chủ MCP thật
- Xử lý phản hồi công cụ và trích dẫn trong các cuộc trò chuyện của agent

## Yêu cầu trước

Trước khi bắt đầu, hãy đảm bảo bạn có:

- Một subscription Azure với quyền truy cập AI Foundry
- Python 3.10 trở lên
- Azure CLI đã được cài đặt và cấu hình
- Quyền thích hợp để tạo tài nguyên AI

## Model Context Protocol (MCP) là gì?

Model Context Protocol là cách chuẩn hóa để các ứng dụng AI kết nối với các nguồn dữ liệu và công cụ bên ngoài. Những lợi ích chính bao gồm:

- **Tích hợp chuẩn hóa**: Giao diện nhất quán trên nhiều công cụ và dịch vụ khác nhau
- **Bảo mật**: Cơ chế xác thực và ủy quyền an toàn
- **Linh hoạt**: Hỗ trợ nhiều nguồn dữ liệu, API và công cụ tùy chỉnh
- **Khả năng mở rộng**: Dễ dàng thêm các tính năng và tích hợp mới

## Thiết lập MCP với Azure AI Foundry

### 1. Cấu hình môi trường

Đầu tiên, thiết lập các biến môi trường và các phụ thuộc:

```python
import os
import time
import json
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential


### 1. Initialize the AI Project Client

```python
project_client = AIProjectClient(
    endpoint="https://your-project-endpoint.services.ai.azure.com/api/projects/your-project",
    credential=DefaultAzureCredential(),
)
```

### 2. Create an Agent with MCP Tools

Configure an agent with MCP server integration:

```python
with project_client:
    agent = project_client.agents.create_agent(
        model="gpt-4.1-nano", 
        name="mcp_agent", 
        instructions="Bạn là một trợ lý hữu ích. Sử dụng các công cụ được cung cấp để trả lời câu hỏi. Hãy chắc chắn trích dẫn nguồn thông tin.",
        tools=[
            {
                "type": "mcp",
                "server_label": "microsoft_docs",
                "server_url": "https://learn.microsoft.com/api/mcp",
                "require_approval": "never"
            }
        ],
        tool_resources=None
    )
    print(f"Created agent, agent ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Định danh cho máy chủ MCP
    "server_url": "https://api.example.com/mcp", # Điểm cuối máy chủ MCP
    "require_approval": "never"                 # Chính sách phê duyệt: hiện chỉ hỗ trợ "never"
}
```

## Complete Example: Using Microsoft Learn MCP Server

Here's a complete example that demonstrates creating an agent with MCP integration and processing a conversation:

```python
import time
import json
import os
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential

def create_mcp_agent_example():

    project_client = AIProjectClient(
        endpoint="https://your-endpoint.services.ai.azure.com/api/projects/your-project",
        credential=DefaultAzureCredential(),
    )

    with project_client:
        # Tạo agent với công cụ MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Bạn là trợ lý chuyên về tài liệu Microsoft. Sử dụng máy chủ MCP Microsoft Learn để tìm kiếm thông tin chính xác và cập nhật. Luôn trích dẫn nguồn thông tin.",
            tools=[
                {
                    "type": "mcp",
                    "server_label": "mslearn",
                    "server_url": "https://learn.microsoft.com/api/mcp",
                    "require_approval": "never"
                }
            ],
            tool_resources=None
        )
        print(f"Created agent, agent ID: {agent.id}")    
        
        # Tạo luồng hội thoại
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # Gửi tin nhắn
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # Chạy agent
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Kiểm tra trạng thái hoàn thành
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # Kiểm tra các bước chạy và các cuộc gọi công cụ
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Chi tiết cuộc gọi công cụ:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Hiển thị cuộc trò chuyện
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Khắc phục sự cố phổ biến

### 1. Vấn đề kết nối
- Kiểm tra URL máy chủ MCP có thể truy cập được không
- Xác minh thông tin xác thực
- Đảm bảo kết nối mạng ổn định

### 2. Lỗi gọi công cụ
- Kiểm tra đối số và định dạng của công cụ
- Xem xét yêu cầu riêng của máy chủ
- Thực hiện xử lý lỗi phù hợp

### 3. Vấn đề hiệu suất
- Tối ưu hóa tần suất gọi công cụ
- Áp dụng caching khi cần thiết
- Giám sát thời gian phản hồi của máy chủ

## Các bước tiếp theo

Để nâng cao tích hợp MCP của bạn:

1. **Khám phá các máy chủ MCP tùy chỉnh**: Xây dựng máy chủ MCP riêng cho nguồn dữ liệu độc quyền
2. **Triển khai bảo mật nâng cao**: Thêm OAuth2 hoặc cơ chế xác thực tùy chỉnh
3. **Giám sát và phân tích**: Thực hiện ghi log và theo dõi việc sử dụng công cụ
4. **Mở rộng giải pháp**: Xem xét cân bằng tải và kiến trúc phân tán cho máy chủ MCP

## Tài nguyên bổ sung

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## Hỗ trợ

Để được hỗ trợ thêm và giải đáp thắc mắc:
- Xem lại [tài liệu Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Kiểm tra [tài nguyên cộng đồng MCP](https://modelcontextprotocol.io/)

## Tiếp theo

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn tham khảo chính thức. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.