<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T16:02:11+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "vi"
}
-->
# Các Chủ Đề Nâng Cao trong MCP

Chương này nhằm trình bày một loạt các chủ đề nâng cao trong việc triển khai Model Context Protocol (MCP), bao gồm tích hợp đa phương thức, khả năng mở rộng, các thực hành bảo mật tốt nhất và tích hợp doanh nghiệp. Những chủ đề này rất quan trọng để xây dựng các ứng dụng MCP vững chắc và sẵn sàng cho môi trường sản xuất, đáp ứng yêu cầu của các hệ thống AI hiện đại.

## Tổng Quan

Bài học này khám phá các khái niệm nâng cao trong triển khai Model Context Protocol, tập trung vào tích hợp đa phương thức, khả năng mở rộng, các thực hành bảo mật tốt nhất và tích hợp doanh nghiệp. Những chủ đề này cần thiết để xây dựng các ứng dụng MCP đạt chuẩn sản xuất, có khả năng xử lý các yêu cầu phức tạp trong môi trường doanh nghiệp.

## Mục Tiêu Học Tập

Sau bài học này, bạn sẽ có thể:

- Triển khai các khả năng đa phương thức trong các framework MCP
- Thiết kế kiến trúc MCP có khả năng mở rộng cho các tình huống có nhu cầu cao
- Áp dụng các thực hành bảo mật phù hợp với nguyên tắc bảo mật của MCP
- Tích hợp MCP với các hệ thống và framework AI doanh nghiệp
- Tối ưu hiệu suất và độ tin cậy trong môi trường sản xuất

## Bài Học và Dự Án Mẫu

| Link | Tiêu Đề | Mô Tả |
|------|---------|-------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Tích hợp với Azure | Học cách tích hợp MCP Server của bạn trên Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Mẫu MCP đa phương thức | Mẫu cho phản hồi âm thanh, hình ảnh và đa phương thức |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Ứng dụng Spring Boot tối giản trình bày OAuth2 với MCP, vừa làm Authorization vừa làm Resource Server. Minh họa phát hành token an toàn, các endpoint được bảo vệ, triển khai Azure Container Apps và tích hợp API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Tìm hiểu thêm về root context và cách triển khai chúng |
| [5.5 Routing](./mcp-routing/README.md) | Định tuyến | Tìm hiểu các loại định tuyến khác nhau |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Học cách làm việc với sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Khả năng mở rộng | Tìm hiểu về khả năng mở rộng |
| [5.8 Security](./mcp-security/README.md) | Bảo mật | Bảo vệ MCP Server của bạn |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Tìm kiếm Web MCP | MCP server và client Python tích hợp với SerpAPI cho tìm kiếm web, tin tức, sản phẩm và hỏi đáp theo thời gian thực. Minh họa phối hợp đa công cụ, tích hợp API bên ngoài và xử lý lỗi hiệu quả. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming dữ liệu thời gian thực đã trở nên thiết yếu trong thế giới dựa trên dữ liệu ngày nay, nơi doanh nghiệp và ứng dụng cần truy cập thông tin ngay lập tức để đưa ra quyết định kịp thời. |

## Tham Khảo Bổ Sung

Để cập nhật thông tin mới nhất về các chủ đề nâng cao MCP, tham khảo:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Những Điểm Chính

- Triển khai MCP đa phương thức mở rộng khả năng AI vượt ra ngoài xử lý văn bản
- Khả năng mở rộng là yếu tố thiết yếu cho triển khai doanh nghiệp và có thể giải quyết qua mở rộng theo chiều ngang và chiều dọc
- Các biện pháp bảo mật toàn diện bảo vệ dữ liệu và đảm bảo kiểm soát truy cập hợp lý
- Tích hợp doanh nghiệp với các nền tảng như Azure OpenAI và Microsoft AI Foundry nâng cao khả năng của MCP
- Các triển khai MCP nâng cao được hưởng lợi từ kiến trúc tối ưu và quản lý tài nguyên cẩn thận

## Bài Tập

Thiết kế một triển khai MCP đạt chuẩn doanh nghiệp cho một trường hợp sử dụng cụ thể:

1. Xác định các yêu cầu đa phương thức cho trường hợp sử dụng của bạn
2. Phác thảo các biện pháp kiểm soát bảo mật cần thiết để bảo vệ dữ liệu nhạy cảm
3. Thiết kế kiến trúc có khả năng mở rộng để xử lý tải thay đổi
4. Lập kế hoạch các điểm tích hợp với hệ thống AI doanh nghiệp
5. Ghi lại các nút thắt hiệu suất tiềm năng và chiến lược giảm thiểu

## Tài Nguyên Bổ Sung

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Tiếp Theo

- [5.1 MCP Integration](./mcp-integration/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc nên được coi là nguồn tham khảo chính xác nhất. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.