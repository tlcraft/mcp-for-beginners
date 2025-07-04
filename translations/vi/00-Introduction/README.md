<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "105c2ddbb77bc38f7e9df009e1b06e45",
  "translation_date": "2025-07-04T18:03:28+00:00",
  "source_file": "00-Introduction/README.md",
  "language_code": "vi"
}
-->
# Giới thiệu về Model Context Protocol (MCP): Tại sao nó quan trọng đối với các ứng dụng AI có khả năng mở rộng

Các ứng dụng AI tạo sinh là một bước tiến lớn khi chúng thường cho phép người dùng tương tác với ứng dụng bằng các câu lệnh ngôn ngữ tự nhiên. Tuy nhiên, khi đầu tư nhiều thời gian và tài nguyên vào các ứng dụng này, bạn sẽ muốn đảm bảo rằng có thể dễ dàng tích hợp các chức năng và tài nguyên sao cho dễ mở rộng, ứng dụng có thể phục vụ nhiều mô hình cùng lúc và xử lý các đặc thù khác nhau của mô hình. Nói tóm lại, việc xây dựng ứng dụng Gen AI ban đầu khá đơn giản, nhưng khi chúng phát triển và trở nên phức tạp hơn, bạn cần bắt đầu định nghĩa kiến trúc và rất có thể phải dựa vào một tiêu chuẩn để đảm bảo các ứng dụng được xây dựng một cách nhất quán. Đây chính là vai trò của MCP trong việc tổ chức và cung cấp một tiêu chuẩn.

---

## **🔍 Model Context Protocol (MCP) là gì?**

**Model Context Protocol (MCP)** là một **giao diện mở, tiêu chuẩn hóa** cho phép các Mô hình Ngôn ngữ Lớn (LLMs) tương tác mượt mà với các công cụ bên ngoài, API và nguồn dữ liệu. Nó cung cấp một kiến trúc nhất quán để nâng cao chức năng của mô hình AI vượt ra ngoài dữ liệu huấn luyện, giúp hệ thống AI thông minh hơn, có khả năng mở rộng và phản hồi nhanh hơn.

---

## **🎯 Tại sao tiêu chuẩn hóa trong AI lại quan trọng**

Khi các ứng dụng AI tạo sinh ngày càng phức tạp, việc áp dụng các tiêu chuẩn để đảm bảo **khả năng mở rộng, khả năng mở rộng chức năng** và **dễ bảo trì** là điều cần thiết. MCP đáp ứng những nhu cầu này bằng cách:

- Thống nhất việc tích hợp mô hình với công cụ
- Giảm thiểu các giải pháp tùy chỉnh dễ hỏng hóc, chỉ dùng một lần
- Cho phép nhiều mô hình cùng tồn tại trong một hệ sinh thái

---

## **📚 Mục tiêu học tập**

Sau khi đọc bài viết này, bạn sẽ có thể:

- Định nghĩa **Model Context Protocol (MCP)** và các trường hợp sử dụng của nó
- Hiểu cách MCP tiêu chuẩn hóa giao tiếp giữa mô hình và công cụ
- Nhận diện các thành phần cốt lõi trong kiến trúc MCP
- Khám phá các ứng dụng thực tế của MCP trong doanh nghiệp và phát triển

---

## **💡 Tại sao Model Context Protocol (MCP) là bước đột phá**

### **🔗 MCP giải quyết sự phân mảnh trong tương tác AI**

Trước MCP, việc tích hợp mô hình với công cụ đòi hỏi:

- Mã tùy chỉnh cho từng cặp công cụ-mô hình
- API không tiêu chuẩn cho từng nhà cung cấp
- Thường xuyên bị gián đoạn do cập nhật
- Khả năng mở rộng kém khi có nhiều công cụ hơn

### **✅ Lợi ích của việc tiêu chuẩn hóa MCP**

| **Lợi ích**              | **Mô tả**                                                                    |
|--------------------------|------------------------------------------------------------------------------|
| Tương tác đa nền tảng    | LLM hoạt động mượt mà với các công cụ từ nhiều nhà cung cấp khác nhau        |
| Tính nhất quán           | Hành vi đồng nhất trên các nền tảng và công cụ                               |
| Tái sử dụng              | Công cụ xây dựng một lần có thể dùng lại trong nhiều dự án và hệ thống       |
| Tăng tốc phát triển      | Giảm thời gian phát triển nhờ sử dụng giao diện tiêu chuẩn, cắm là chạy      |

---

## **🧱 Tổng quan kiến trúc MCP ở cấp độ cao**

MCP tuân theo mô hình **client-server**, trong đó:

- **MCP Hosts** chạy các mô hình AI
- **MCP Clients** khởi tạo các yêu cầu
- **MCP Servers** cung cấp ngữ cảnh, công cụ và khả năng

### **Các thành phần chính:**

- **Resources** – Dữ liệu tĩnh hoặc động cho mô hình  
- **Prompts** – Các quy trình làm việc được định nghĩa sẵn để hướng dẫn tạo sinh  
- **Tools** – Các hàm thực thi như tìm kiếm, tính toán  
- **Sampling** – Hành vi tác nhân thông qua các tương tác đệ quy

---

## Cách MCP Servers hoạt động

MCP servers hoạt động theo cách sau:

- **Luồng yêu cầu**:  
    1. MCP Client gửi yêu cầu đến Mô hình AI đang chạy trên MCP Host.  
    2. Mô hình AI xác định khi nào cần công cụ hoặc dữ liệu bên ngoài.  
    3. Mô hình giao tiếp với MCP Server theo giao thức tiêu chuẩn.

- **Chức năng của MCP Server**:  
    - Đăng ký công cụ: Quản lý danh mục các công cụ và khả năng của chúng.  
    - Xác thực: Kiểm tra quyền truy cập công cụ.  
    - Xử lý yêu cầu: Xử lý các yêu cầu công cụ từ mô hình.  
    - Định dạng phản hồi: Cấu trúc kết quả công cụ theo định dạng mô hình có thể hiểu.

- **Thực thi công cụ**:  
    - Server chuyển tiếp yêu cầu đến các công cụ bên ngoài phù hợp  
    - Công cụ thực hiện chức năng chuyên biệt (tìm kiếm, tính toán, truy vấn cơ sở dữ liệu, v.v.)  
    - Kết quả được trả về mô hình theo định dạng nhất quán.

- **Hoàn thành phản hồi**:  
    - Mô hình AI tích hợp kết quả công cụ vào phản hồi của mình.  
    - Phản hồi cuối cùng được gửi lại ứng dụng client.

```mermaid
---
title: MCP Server Architecture and Component Interactions
description: A diagram showing how AI models interact with MCP servers and various tools, depicting the request flow and server components including Tool Registry, Authentication, Request Handler, and Response Formatter
---
graph TD
    A[AI Model in MCP Host] <-->|MCP Protocol| B[MCP Server]
    B <-->|Tool Interface| C[Tool 1: Web Search]
    B <-->|Tool Interface| D[Tool 2: Calculator]
    B <-->|Tool Interface| E[Tool 3: Database Access]
    B <-->|Tool Interface| F[Tool 4: File System]
    
    Client[MCP Client/Application] -->|Sends Request| A
    A -->|Returns Response| Client
    
    subgraph "MCP Server Components"
        B
        G[Tool Registry]
        H[Authentication]
        I[Request Handler]
        J[Response Formatter]
    end
    
    B <--> G
    B <--> H
    B <--> I
    B <--> J
    
    style A fill:#f9d5e5,stroke:#333,stroke-width:2px
    style B fill:#eeeeee,stroke:#333,stroke-width:2px
    style Client fill:#d5e8f9,stroke:#333,stroke-width:2px
    style C fill:#c2f0c2,stroke:#333,stroke-width:1px
    style D fill:#c2f0c2,stroke:#333,stroke-width:1px
    style E fill:#c2f0c2,stroke:#333,stroke-width:1px
    style F fill:#c2f0c2,stroke:#333,stroke-width:1px    
```

## 👨‍💻 Cách xây dựng MCP Server (kèm ví dụ)

MCP servers cho phép bạn mở rộng khả năng của LLM bằng cách cung cấp dữ liệu và chức năng.

Sẵn sàng thử? Dưới đây là các ví dụ tạo MCP server đơn giản bằng các ngôn ngữ khác nhau:

- **Ví dụ Python**: https://github.com/modelcontextprotocol/python-sdk

- **Ví dụ TypeScript**: https://github.com/modelcontextprotocol/typescript-sdk

- **Ví dụ Java**: https://github.com/modelcontextprotocol/java-sdk

- **Ví dụ C#/.NET**: https://github.com/modelcontextprotocol/csharp-sdk

## 🌍 Các trường hợp sử dụng thực tế của MCP

MCP mở rộng khả năng AI cho nhiều ứng dụng khác nhau:

| **Ứng dụng**               | **Mô tả**                                                                    |
|----------------------------|------------------------------------------------------------------------------|
| Tích hợp dữ liệu doanh nghiệp | Kết nối LLM với cơ sở dữ liệu, CRM hoặc công cụ nội bộ                        |
| Hệ thống AI tác nhân        | Cho phép các tác nhân tự động truy cập công cụ và quy trình ra quyết định    |
| Ứng dụng đa phương thức     | Kết hợp công cụ văn bản, hình ảnh và âm thanh trong một ứng dụng AI duy nhất |
| Tích hợp dữ liệu thời gian thực | Đưa dữ liệu trực tiếp vào tương tác AI để có kết quả chính xác và cập nhật  |

### 🧠 MCP = Tiêu chuẩn chung cho tương tác AI

Model Context Protocol (MCP) hoạt động như một tiêu chuẩn chung cho các tương tác AI, tương tự như USB-C đã tiêu chuẩn hóa kết nối vật lý cho thiết bị. Trong thế giới AI, MCP cung cấp một giao diện nhất quán, cho phép các mô hình (client) tích hợp mượt mà với các công cụ và nhà cung cấp dữ liệu bên ngoài (server). Điều này loại bỏ nhu cầu về các giao thức tùy chỉnh đa dạng cho từng API hoặc nguồn dữ liệu.

Theo MCP, một công cụ tương thích MCP (gọi là MCP server) tuân theo một tiêu chuẩn thống nhất. Các server này có thể liệt kê các công cụ hoặc hành động mà họ cung cấp và thực thi các hành động đó khi được tác nhân AI yêu cầu. Các nền tảng tác nhân AI hỗ trợ MCP có khả năng phát hiện các công cụ có sẵn từ server và gọi chúng thông qua giao thức tiêu chuẩn này.

### 💡 Hỗ trợ truy cập kiến thức

Ngoài việc cung cấp công cụ, MCP còn hỗ trợ truy cập kiến thức. Nó cho phép ứng dụng cung cấp ngữ cảnh cho các mô hình ngôn ngữ lớn (LLMs) bằng cách liên kết chúng với nhiều nguồn dữ liệu khác nhau. Ví dụ, một MCP server có thể đại diện cho kho tài liệu của một công ty, cho phép các tác nhân truy xuất thông tin liên quan khi cần. Một server khác có thể xử lý các hành động cụ thể như gửi email hoặc cập nhật hồ sơ. Với tác nhân, đây đơn giản là các công cụ mà nó có thể sử dụng — một số công cụ trả về dữ liệu (ngữ cảnh kiến thức), trong khi số khác thực hiện hành động. MCP quản lý hiệu quả cả hai loại này.

Một tác nhân khi kết nối với MCP server sẽ tự động học được các khả năng và dữ liệu có thể truy cập của server thông qua định dạng tiêu chuẩn. Việc tiêu chuẩn hóa này cho phép công cụ có thể được thêm vào một cách linh hoạt. Ví dụ, khi thêm một MCP server mới vào hệ thống của tác nhân, các chức năng của server đó sẽ được sử dụng ngay lập tức mà không cần tùy chỉnh thêm hướng dẫn cho tác nhân.

Việc tích hợp này được minh họa trong sơ đồ mermaid, nơi các server cung cấp cả công cụ và kiến thức, đảm bảo sự phối hợp liền mạch giữa các hệ thống.

### 👉 Ví dụ: Giải pháp tác nhân có khả năng mở rộng

```mermaid
---
title: Scalable Agent Solution with MCP
description: A diagram illustrating how a user interacts with an LLM that connects to multiple MCP servers, with each server providing both knowledge and tools, creating a scalable AI system architecture
---
graph TD
    User -->|Prompt| LLM
    LLM -->|Response| User
    LLM -->|MCP| ServerA
    LLM -->|MCP| ServerB
    ServerA -->|Universal connector| ServerB
    ServerA --> KnowledgeA
    ServerA --> ToolsA
    ServerB --> KnowledgeB
    ServerB --> ToolsB

    subgraph Server A
        KnowledgeA[Knowledge]
        ToolsA[Tools]
    end

    subgraph Server B
        KnowledgeB[Knowledge]
        ToolsB[Tools]
    end
```

### 🔄 Các kịch bản MCP nâng cao với tích hợp LLM phía client

Ngoài kiến trúc MCP cơ bản, còn có các kịch bản nâng cao khi cả client và server đều chứa LLM, cho phép tương tác phức tạp hơn:

```mermaid
---
title: Advanced MCP Scenarios with Client-Server LLM Integration
description: A sequence diagram showing the detailed interaction flow between user, client application, client LLM, multiple MCP servers, and server LLM, illustrating tool discovery, user interaction, direct tool calling, and feature negotiation phases
---
sequenceDiagram
    autonumber
    actor User as 👤 User
    participant ClientApp as 🖥️ Client App
    participant ClientLLM as 🧠 Client LLM
    participant Server1 as 🔧 MCP Server 1
    participant Server2 as 📚 MCP Server 2
    participant ServerLLM as 🤖 Server LLM
    
    %% Discovery Phase
    rect rgb(220, 240, 255)
        Note over ClientApp, Server2: TOOL DISCOVERY PHASE
        ClientApp->>+Server1: Request available tools/resources
        Server1-->>-ClientApp: Return tool list (JSON)
        ClientApp->>+Server2: Request available tools/resources
        Server2-->>-ClientApp: Return tool list (JSON)
        Note right of ClientApp: Store combined tool<br/>catalog locally
    end
    
    %% User Interaction
    rect rgb(255, 240, 220)
        Note over User, ClientLLM: USER INTERACTION PHASE
        User->>+ClientApp: Enter natural language prompt
        ClientApp->>+ClientLLM: Forward prompt + tool catalog
        ClientLLM->>-ClientLLM: Analyze prompt & select tools
    end
    
    %% Scenario A: Direct Tool Calling
    alt Direct Tool Calling
        rect rgb(220, 255, 220)
            Note over ClientApp, Server1: SCENARIO A: DIRECT TOOL CALLING
            ClientLLM->>+ClientApp: Request tool execution
            ClientApp->>+Server1: Execute specific tool
            Server1-->>-ClientApp: Return results
            ClientApp->>+ClientLLM: Process results
            ClientLLM-->>-ClientApp: Generate response
            ClientApp-->>-User: Display final answer
        end
    
    %% Scenario B: Feature Negotiation (VS Code style)
    else Feature Negotiation (VS Code style)
        rect rgb(255, 220, 220)
            Note over ClientApp, ServerLLM: SCENARIO B: FEATURE NEGOTIATION
            ClientLLM->>+ClientApp: Identify needed capabilities
            ClientApp->>+Server2: Negotiate features/capabilities
            Server2->>+ServerLLM: Request additional context
            ServerLLM-->>-Server2: Provide context
            Server2-->>-ClientApp: Return available features
            ClientApp->>+Server2: Call negotiated tools
            Server2-->>-ClientApp: Return results
            ClientApp->>+ClientLLM: Process results
            ClientLLM-->>-ClientApp: Generate response
            ClientApp-->>-User: Display final answer
        end
    end
```

## 🔐 Lợi ích thực tiễn của MCP

Dưới đây là các lợi ích thực tế khi sử dụng MCP:

- **Thông tin cập nhật**: Mô hình có thể truy cập thông tin mới nhất ngoài dữ liệu huấn luyện  
- **Mở rộng khả năng**: Mô hình có thể tận dụng các công cụ chuyên biệt cho các nhiệm vụ chưa được huấn luyện  
- **Giảm ảo tưởng**: Nguồn dữ liệu bên ngoài cung cấp cơ sở thực tế  
- **Bảo mật**: Dữ liệu nhạy cảm có thể được giữ trong môi trường an toàn thay vì nhúng vào câu lệnh

## 📌 Những điểm chính cần nhớ

Dưới đây là những điểm chính khi sử dụng MCP:

- **MCP** tiêu chuẩn hóa cách mô hình AI tương tác với công cụ và dữ liệu  
- Thúc đẩy **khả năng mở rộng, tính nhất quán và tương tác đa nền tảng**  
- MCP giúp **rút ngắn thời gian phát triển, cải thiện độ tin cậy và mở rộng khả năng mô hình**  
- Kiến trúc client-server **cho phép xây dựng các ứng dụng AI linh hoạt và dễ mở rộng**

## 🧠 Bài tập

Hãy nghĩ về một ứng dụng AI mà bạn quan tâm muốn xây dựng.

- Những **công cụ hoặc dữ liệu bên ngoài** nào có thể nâng cao khả năng của nó?  
- MCP có thể giúp việc tích hợp trở nên **đơn giản và đáng tin cậy hơn** như thế nào?

## Tài nguyên bổ sung

- [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## Tiếp theo

Tiếp theo: [Chương 1: Các khái niệm cốt lõi](../01-CoreConcepts/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.