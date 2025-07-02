<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T09:41:45+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "vi"
}
-->
# Các Chủ Đề Nâng Cao trong MCP

Chương này nhằm giới thiệu một loạt các chủ đề nâng cao trong việc triển khai Model Context Protocol (MCP), bao gồm tích hợp đa phương thức, khả năng mở rộng, các thực hành bảo mật tốt nhất và tích hợp doanh nghiệp. Những chủ đề này rất quan trọng để xây dựng các ứng dụng MCP mạnh mẽ và sẵn sàng cho môi trường sản xuất, đáp ứng được yêu cầu của các hệ thống AI hiện đại.

## Tổng Quan

Bài học này khám phá các khái niệm nâng cao trong triển khai Model Context Protocol, tập trung vào tích hợp đa phương thức, khả năng mở rộng, các thực hành bảo mật tốt nhất và tích hợp doanh nghiệp. Những chủ đề này là thiết yếu để xây dựng các ứng dụng MCP đạt chuẩn sản xuất, có thể xử lý các yêu cầu phức tạp trong môi trường doanh nghiệp.

## Mục Tiêu Học Tập

Kết thúc bài học này, bạn sẽ có khả năng:

- Triển khai các tính năng đa phương thức trong các framework MCP
- Thiết kế kiến trúc MCP có khả năng mở rộng cho các tình huống đòi hỏi cao
- Áp dụng các thực hành bảo mật tốt nhất phù hợp với nguyên tắc bảo mật của MCP
- Tích hợp MCP với các hệ thống và framework AI doanh nghiệp
- Tối ưu hóa hiệu suất và độ tin cậy trong môi trường sản xuất

## Bài Học và Dự Án Mẫu

| Link | Tiêu đề | Mô tả |
|------|---------|--------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Tích hợp với Azure | Học cách tích hợp MCP Server của bạn trên Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Mẫu đa phương thức MCP | Mẫu cho phản hồi âm thanh, hình ảnh và đa phương thức |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Ứng dụng Spring Boot tối giản trình bày OAuth2 với MCP, vừa là Authorization Server vừa là Resource Server. Minh họa phát hành token an toàn, các endpoint được bảo vệ, triển khai Azure Container Apps và tích hợp API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Tìm hiểu thêm về root context và cách triển khai chúng |
| [5.5 Routing](./mcp-routing/README.md) | Định tuyến | Tìm hiểu các loại định tuyến khác nhau |
| [5.6 Sampling](./mcp-sampling/README.md) | Lấy mẫu | Học cách làm việc với sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Mở rộng | Tìm hiểu về mở rộng |
| [5.8 Security](./mcp-security/README.md) | Bảo mật | Bảo vệ MCP Server của bạn |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Tìm kiếm Web MCP | MCP server và client Python tích hợp với SerpAPI để tìm kiếm web, tin tức, sản phẩm và hỏi đáp theo thời gian thực. Minh họa phối hợp nhiều công cụ, tích hợp API bên ngoài và xử lý lỗi hiệu quả. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Truyền dữ liệu theo thời gian thực trở nên thiết yếu trong thế giới dữ liệu ngày nay, nơi doanh nghiệp và ứng dụng cần truy cập thông tin ngay lập tức để ra quyết định kịp thời. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Tìm kiếm Web | Tìm kiếm web theo thời gian thực: MCP biến đổi cách tìm kiếm web bằng cách cung cấp phương pháp chuẩn hóa quản lý context giữa các mô hình AI, công cụ tìm kiếm và ứng dụng. |
| [5.12 Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Xác thực Entra ID | Microsoft Entra ID cung cấp giải pháp quản lý danh tính và truy cập dựa trên đám mây mạnh mẽ, giúp đảm bảo chỉ người dùng và ứng dụng được phép mới có thể tương tác với MCP server của bạn. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Tích hợp Azure AI Foundry | Tìm hiểu cách tích hợp các server Model Context Protocol với các agent Azure AI Foundry, cho phép phối hợp công cụ mạnh mẽ và khả năng AI doanh nghiệp với kết nối nguồn dữ liệu bên ngoài theo chuẩn. |

## Tham Khảo Bổ Sung

Để có thông tin cập nhật nhất về các chủ đề nâng cao MCP, tham khảo:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Những Điểm Chính Cần Nhớ

- Triển khai MCP đa phương thức mở rộng khả năng AI vượt ra ngoài xử lý văn bản
- Khả năng mở rộng rất quan trọng cho các triển khai doanh nghiệp và có thể được giải quyết qua mở rộng ngang và dọc
- Các biện pháp bảo mật toàn diện bảo vệ dữ liệu và đảm bảo kiểm soát truy cập đúng cách
- Tích hợp doanh nghiệp với các nền tảng như Azure OpenAI và Microsoft AI Foundry nâng cao khả năng MCP
- Các triển khai MCP nâng cao hưởng lợi từ kiến trúc tối ưu và quản lý tài nguyên cẩn thận

## Bài Tập

Thiết kế một triển khai MCP chuẩn doanh nghiệp cho một trường hợp sử dụng cụ thể:

1. Xác định các yêu cầu đa phương thức cho trường hợp của bạn
2. Phác thảo các biện pháp kiểm soát bảo mật cần thiết để bảo vệ dữ liệu nhạy cảm
3. Thiết kế kiến trúc có khả năng mở rộng để xử lý tải biến đổi
4. Lập kế hoạch các điểm tích hợp với hệ thống AI doanh nghiệp
5. Ghi lại các điểm nghẽn hiệu suất tiềm năng và chiến lược khắc phục

## Tài Nguyên Bổ Sung

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Tiếp theo

- [5.1 MCP Integration](./mcp-integration/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn tham khảo chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hay diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.