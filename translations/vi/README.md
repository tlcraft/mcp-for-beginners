<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3ede7f051090bd4acfe5b068bab9f6b0",
  "translation_date": "2025-06-10T04:32:25+00:00",
  "source_file": "README.md",
  "language_code": "vi"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.vi.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Làm theo các bước sau để bắt đầu sử dụng các tài nguyên này:
1. **Fork Repository**: Nhấn vào [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clone Repository**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Tham gia Azure AI Foundry Discord và gặp gỡ các chuyên gia cùng các nhà phát triển khác**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Hỗ trợ đa ngôn ngữ

#### Hỗ trợ qua GitHub Action (Tự động & Luôn cập nhật)

# 🚀 Giáo trình Model Context Protocol (MCP) dành cho người mới bắt đầu

## **Học MCP qua các ví dụ mã thực hành bằng C#, Java, JavaScript, Python và TypeScript**

## 🧠 Tổng quan về giáo trình Model Context Protocol

**Model Context Protocol (MCP)** là một framework tiên tiến được thiết kế để chuẩn hóa tương tác giữa các mô hình AI và ứng dụng khách. Giáo trình mã nguồn mở này cung cấp lộ trình học tập có cấu trúc, kèm theo các ví dụ mã thực tế và các trường hợp sử dụng thực tế, trải dài trên các ngôn ngữ lập trình phổ biến như C#, Java, JavaScript, TypeScript và Python.

Dù bạn là nhà phát triển AI, kiến trúc sư hệ thống hay kỹ sư phần mềm, hướng dẫn này là tài nguyên toàn diện giúp bạn nắm vững các kiến thức cơ bản và chiến lược triển khai MCP.

## 🔗 Tài nguyên chính thức của MCP

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Hướng dẫn chi tiết và tài liệu người dùng  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Kiến trúc giao thức và tham khảo kỹ thuật  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – SDK mã nguồn mở, công cụ và ví dụ mã  

## 🧭 Cấu trúc đầy đủ của giáo trình MCP

| Ch | Tiêu đề | Mô tả | Liên kết |
|--|--|--|--|
| 00 | **Giới thiệu về MCP** | Tổng quan về Model Context Protocol và tầm quan trọng của nó trong pipeline AI, bao gồm MCP là gì, vì sao chuẩn hóa lại quan trọng, cùng các trường hợp sử dụng và lợi ích thực tế | [Introduction](./00-Introduction/README.md) |
| 01 | **Giải thích các khái niệm cốt lõi** | Khám phá sâu các khái niệm cốt lõi của MCP, bao gồm kiến trúc client-server, các thành phần chính của giao thức, và các mẫu tin nhắn | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **Bảo mật trong MCP** | Nhận diện các mối đe dọa bảo mật trong hệ thống dựa trên MCP, kỹ thuật và các phương pháp tốt nhất để bảo vệ triển khai | [Security](/02-Security/README.md) |
| 03 | **Bắt đầu với MCP** | Thiết lập môi trường và cấu hình, tạo các server và client MCP cơ bản, tích hợp MCP với các ứng dụng hiện có | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **Server đầu tiên** | Thiết lập một server cơ bản sử dụng giao thức MCP, hiểu cách tương tác giữa server và client, và kiểm thử server | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Client đầu tiên**  | Thiết lập một client cơ bản sử dụng giao thức MCP, hiểu cách tương tác giữa client và server, và kiểm thử client | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Client với LLM**  | Thiết lập client sử dụng MCP với Large Language Model (LLM) | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Sử dụng server với Visual Studio Code** | Thiết lập Visual Studio Code để sử dụng các server qua giao thức MCP | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Tạo server dùng SSE** | SSE giúp chúng ta mở server ra internet. Phần này sẽ hướng dẫn bạn tạo server dùng SSE | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Sử dụng AI Toolkit** | AI Toolkit là công cụ tuyệt vời giúp bạn quản lý quy trình AI và MCP | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Kiểm thử server của bạn** | Kiểm thử là phần quan trọng trong quá trình phát triển. Phần này sẽ giúp bạn kiểm thử với nhiều công cụ khác nhau | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Triển khai server của bạn** | Làm thế nào để chuyển từ phát triển cục bộ sang sản xuất? Phần này sẽ hướng dẫn bạn phát triển và triển khai server | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Triển khai thực tế** | Sử dụng SDK trên nhiều ngôn ngữ, gỡ lỗi, kiểm thử và xác nhận, tạo mẫu prompt và quy trình làm việc có thể tái sử dụng | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **Chủ đề nâng cao trong MCP** | Quy trình AI đa phương thức và khả năng mở rộng, chiến lược mở rộng an toàn, MCP trong hệ sinh thái doanh nghiệp | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **Tích hợp MCP với Azure** | Trình bày tích hợp với Azure | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Đa phương thức** | Hướng dẫn làm việc với các phương thức khác nhau như hình ảnh và hơn thế nữa | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **Demo MCP OAuth2** | Ứng dụng Spring Boot tối giản trình bày OAuth2 với MCP, cả vai trò Authorization và Resource Server. Minh họa phát hành token an toàn, endpoint bảo vệ, triển khai Azure Container Apps, và tích hợp API Management | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Tìm hiểu thêm về root context và cách triển khai chúng | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Tìm hiểu các loại routing khác nhau | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Học cách làm việc với sampling | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Scaling** | Tìm hiểu về cách mở rộng server MCP, bao gồm chiến lược mở rộng ngang và dọc, tối ưu tài nguyên và điều chỉnh hiệu năng | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Bảo mật** | Bảo vệ MCP Server của bạn, bao gồm xác thực, phân quyền và chiến lược bảo vệ dữ liệu | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Server và client MCP bằng Python tích hợp với SerpAPI để tìm kiếm web, tin tức, sản phẩm và hỏi đáp theo thời gian thực. Minh họa phối hợp đa công cụ, tích hợp API bên ngoài và xử lý lỗi hiệu quả | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 06 | **Đóng góp cộng đồng** | Cách đóng góp mã và tài liệu, hợp tác qua GitHub, cải tiến và phản hồi từ cộng đồng | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **Bài học từ những người dùng đầu tiên** | Các triển khai thực tế và những gì đã hiệu quả, xây dựng và triển khai giải pháp dựa trên MCP, xu hướng và lộ trình tương lai | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Thực hành tốt nhất cho MCP** | Tinh chỉnh và tối ưu hiệu năng, thiết kế hệ thống MCP chịu lỗi, kiểm thử và chiến lược đảm bảo độ bền | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Nghiên cứu trường hợp MCP** | Phân tích sâu kiến trúc giải pháp MCP, bản thiết kế triển khai và mẹo tích hợp, sơ đồ chú thích và hướng dẫn dự án | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Tối ưu hóa Quy trình AI: Xây dựng MCP Server với AI Toolkit** | Hội thảo thực hành toàn diện kết hợp MCP với AI Toolkit của Microsoft cho VS Code. Học cách xây dựng ứng dụng thông minh kết nối mô hình AI với công cụ thực tế qua các module thực tiễn bao gồm kiến thức cơ bản, phát triển server tùy chỉnh và chiến lược triển khai sản xuất. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Dự án mẫu

### 🧮 Dự án mẫu Máy tính MCP:
<details>
  <summary><strong>Khám phá Mã nguồn theo Ngôn ngữ</strong></summary>

  - [C# MCP Server Example](./03-GettingStarted/samples/csharp/README.md)
  - [Java MCP Calculator](./03-GettingStarted/samples/java/calculator/README.md)
  - [JavaScript MCP Demo](./03-GettingStarted/samples/javascript/README.md)
  - [Python MCP Server](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [TypeScript MCP Example](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Dự án Máy tính MCP Nâng cao:
<details>
  <summary><strong>Khám phá các mẫu Nâng cao</strong></summary>

  - [Advanced C# Sample](./04-PracticalImplementation/samples/csharp/README.md)
  - [Java Container App Example](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [JavaScript Advanced Sample](./04-PracticalImplementation/samples/javascript/README.md)
  - [Python Complex Implementation](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [TypeScript Container Sample](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Yêu cầu cần có để học MCP

Để tận dụng tối đa chương trình này, bạn nên có:

- Kiến thức cơ bản về C#, Java hoặc Python
- Hiểu biết về mô hình client-server và API
- (Tùy chọn) Quen thuộc với các khái niệm học máy

## 🛠️ Cách sử dụng chương trình học hiệu quả

Mỗi bài học trong hướng dẫn này bao gồm:

1. Giải thích rõ ràng về các khái niệm MCP  
2. Ví dụ mã nguồn trực tiếp bằng nhiều ngôn ngữ  
3. Bài tập xây dựng ứng dụng MCP thực tế  
4. Tài nguyên bổ sung dành cho người học nâng cao  

## 📜 Thông tin bản quyền

Nội dung này được cấp phép theo **MIT License**. Điều khoản và điều kiện xem tại [LICENSE](../../LICENSE).

## 🤝 Hướng dẫn đóng góp

Dự án này hoan nghênh các đóng góp và đề xuất. Phần lớn các đóng góp yêu cầu bạn đồng ý với Thỏa thuận Cấp phép Người đóng góp (CLA) xác nhận bạn có quyền và thực sự cấp quyền sử dụng đóng góp của mình cho chúng tôi. Chi tiết xem tại <https://cla.opensource.microsoft.com>.

Khi bạn gửi pull request, bot CLA sẽ tự động xác định xem bạn có cần cung cấp CLA không và đánh dấu PR phù hợp (ví dụ: kiểm tra trạng thái, bình luận). Chỉ cần làm theo hướng dẫn của bot. Bạn chỉ cần thực hiện điều này một lần cho tất cả các kho sử dụng CLA của chúng tôi.

Dự án này đã áp dụng [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).  
Để biết thêm thông tin, xem [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) hoặc liên hệ [opencode@microsoft.com](mailto:opencode@microsoft.com) nếu có câu hỏi hoặc góp ý.

## 🎒 Các khóa học khác
Nhóm chúng tôi còn có các khóa học khác! Hãy xem:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for AI Paired Programming](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for C#/.NET Developers](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Choose Your Own Copilot Adventure](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Thông báo Nhãn hiệu

Dự án này có thể chứa nhãn hiệu hoặc logo của các dự án, sản phẩm hoặc dịch vụ. Việc sử dụng nhãn hiệu hoặc logo Microsoft được phép phải tuân theo  
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).  
Việc sử dụng nhãn hiệu hoặc logo Microsoft trong các phiên bản chỉnh sửa của dự án này không được gây nhầm lẫn hoặc ngụ ý có sự tài trợ của Microsoft.  
Mọi việc sử dụng nhãn hiệu hoặc logo của bên thứ ba đều phải tuân theo chính sách của bên thứ ba đó.

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được coi là nguồn thông tin chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.