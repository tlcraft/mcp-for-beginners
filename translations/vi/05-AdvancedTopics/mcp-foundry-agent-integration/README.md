<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:58:19+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "vi"
}
-->
# Model Context Protocol (MCP) Tích hợp với Azure AI Foundry

Hướng dẫn này trình bày cách tích hợp các máy chủ Model Context Protocol (MCP) với các agent của Azure AI Foundry, giúp điều phối công cụ mạnh mẽ và khả năng AI doanh nghiệp.

## Giới thiệu

Model Context Protocol (MCP) là một tiêu chuẩn mở cho phép các ứng dụng AI kết nối an toàn với các nguồn dữ liệu và công cụ bên ngoài. Khi tích hợp với Azure AI Foundry, MCP cho phép các agent truy cập và tương tác với nhiều dịch vụ, API và nguồn dữ liệu bên ngoài theo một cách chuẩn hóa.

Sự tích hợp này kết hợp sự linh hoạt của hệ sinh thái công cụ MCP với khung agent mạnh mẽ của Azure AI Foundry, cung cấp các giải pháp AI cấp doanh nghiệp với khả năng tùy chỉnh rộng rãi.

**Note:** Nếu bạn muốn sử dụng MCP trong Azure AI Foundry Agent Service, hiện tại chỉ hỗ trợ các khu vực sau: westus, westus2, uaenorth, southindia và switzerlandnorth

## Mục tiêu học tập

Sau khi hoàn thành hướng dẫn này, bạn sẽ có thể:

- Hiểu về Model Context Protocol và lợi ích của nó
- Thiết lập các máy chủ MCP để sử dụng với các agent Azure AI Foundry
- Tạo và cấu hình agent với tích hợp công cụ MCP
- Triển khai các ví dụ thực tế sử dụng các máy chủ MCP thật
- Xử lý phản hồi công cụ và trích dẫn trong các cuộc hội thoại của agent

## Yêu cầu trước

Trước khi bắt đầu, hãy đảm bảo bạn có:

- Một đăng ký Azure với quyền truy cập AI Foundry
- Python 3.10 trở lên
- Azure CLI đã được cài đặt và cấu hình
- Quyền phù hợp để tạo tài nguyên AI

## Model Context Protocol (MCP) là gì?

Model Context Protocol là một phương thức chuẩn hóa để các ứng dụng AI kết nối với các nguồn dữ liệu và công cụ bên ngoài. Các lợi ích chính bao gồm:

- **Tích hợp chuẩn hóa**: Giao diện nhất quán cho các công cụ và dịch vụ khác nhau
- **Bảo mật**: Cơ chế xác thực và ủy quyền an toàn
- **Linh hoạt**: Hỗ trợ nhiều nguồn dữ liệu, API và công cụ tùy chỉnh
- **Mở rộng**: Dễ dàng thêm các tính năng và tích hợp mới

## Thiết lập MCP với Azure AI Foundry

### 1. Cấu hình môi trường

Trước tiên, thiết lập các biến môi trường và các phụ thuộc:

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
        instructions="Bạn là một trợ lý hữu ích. Sử dụng các công cụ được cung cấp để trả lời câu hỏi. Hãy chắc chắn trích dẫn nguồn thông tin của bạn.",
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
    print(f"Đã tạo agent, ID agent: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Định danh cho máy chủ MCP
    "server_url": "https://api.example.com/mcp", # Địa chỉ máy chủ MCP
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
            instructions="Bạn là một trợ lý hữu ích chuyên về tài liệu Microsoft. Sử dụng máy chủ Microsoft Learn MCP để tìm kiếm thông tin chính xác và cập nhật. Luôn trích dẫn nguồn thông tin.",
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
        print(f"Đã tạo agent, ID agent: {agent.id}")    
        
        # Tạo luồng hội thoại
        thread = project_client.agents.threads.create()
        print(f"Đã tạo luồng, ID luồng: {thread.id}")

        # Gửi tin nhắn
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content=".NET MAUI là gì? Nó so sánh như thế nào với Xamarin.Forms?",
        )
        print(f"Đã tạo tin nhắn, ID tin nhắn: {message.id}")

        # Chạy agent
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Kiểm tra trạng thái hoàn thành
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Trạng thái chạy: {run.status}")

        # Xem xét các bước chạy và các cuộc gọi công cụ
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Bước chạy: {step.id}, trạng thái: {step.status}, loại: {step.type}")
            if step.type == "tool_calls":
                print("Chi tiết cuộc gọi công cụ:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Hiển thị hội thoại
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
- Kiểm tra thông tin xác thực
- Đảm bảo kết nối mạng ổn định

### 2. Lỗi khi gọi công cụ
- Kiểm tra đối số và định dạng của công cụ
- Xem xét các yêu cầu riêng của máy chủ
- Thực hiện xử lý lỗi phù hợp

### 3. Vấn đề hiệu năng
- Tối ưu tần suất gọi công cụ
- Áp dụng bộ nhớ đệm khi cần thiết
- Giám sát thời gian phản hồi của máy chủ

## Bước tiếp theo

Để nâng cao tích hợp MCP của bạn:

1. **Khám phá máy chủ MCP tùy chỉnh**: Xây dựng máy chủ MCP riêng cho các nguồn dữ liệu độc quyền
2. **Triển khai bảo mật nâng cao**: Thêm OAuth2 hoặc cơ chế xác thực tùy chỉnh
3. **Giám sát và phân tích**: Thực hiện ghi nhật ký và giám sát việc sử dụng công cụ
4. **Mở rộng giải pháp**: Xem xét cân bằng tải và kiến trúc máy chủ MCP phân tán

## Tài nguyên bổ sung

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## Hỗ trợ

Để được hỗ trợ và giải đáp thắc mắc thêm:
- Xem lại [tài liệu Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Kiểm tra [tài nguyên cộng đồng MCP](https://modelcontextprotocol.io/)

## Tiếp theo

- [6. Đóng góp từ cộng đồng](../../06-CommunityContributions/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.