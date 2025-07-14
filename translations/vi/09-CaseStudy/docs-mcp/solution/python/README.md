<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:42:14+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "vi"
}
-->
# Trình tạo kế hoạch học tập với Chainlit & Microsoft Learn Docs MCP

## Yêu cầu trước

- Python 3.8 trở lên  
- pip (trình quản lý gói Python)  
- Kết nối Internet để truy cập máy chủ Microsoft Learn Docs MCP  

## Cài đặt

1. Sao chép kho lưu trữ này hoặc tải xuống các tệp dự án.  
2. Cài đặt các thư viện cần thiết:  

   ```bash
   pip install -r requirements.txt
   ```  

## Cách sử dụng

### Tình huống 1: Truy vấn đơn giản tới Docs MCP  
Một ứng dụng dòng lệnh kết nối với máy chủ Docs MCP, gửi truy vấn và in kết quả ra màn hình.  

1. Chạy script:  
   ```bash
   python scenario1.py
   ```  
2. Nhập câu hỏi về tài liệu của bạn tại dấu nhắc.  

### Tình huống 2: Trình tạo kế hoạch học tập (ứng dụng web Chainlit)  
Giao diện web (sử dụng Chainlit) cho phép người dùng tạo kế hoạch học tập cá nhân theo tuần cho bất kỳ chủ đề kỹ thuật nào.  

1. Khởi động ứng dụng Chainlit:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Mở URL địa phương được cung cấp trong terminal (ví dụ: http://localhost:8000) trên trình duyệt của bạn.  
3. Trong cửa sổ chat, nhập chủ đề học và số tuần bạn muốn học (ví dụ: "Chứng chỉ AI-900, 8 tuần").  
4. Ứng dụng sẽ trả về kế hoạch học tập theo tuần, kèm theo các liên kết đến tài liệu Microsoft Learn phù hợp.  

**Biến môi trường cần thiết:**  

Để sử dụng Tình huống 2 (ứng dụng web Chainlit với Azure OpenAI), bạn phải thiết lập các biến môi trường sau trong tệp `.env` trong thư mục `python`:  

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```  

Điền các giá trị này với thông tin tài nguyên Azure OpenAI của bạn trước khi chạy ứng dụng.  

> **Mẹo:** Bạn có thể dễ dàng triển khai mô hình của riêng mình bằng cách sử dụng [Azure AI Foundry](https://ai.azure.com/).  

### Tình huống 3: Tài liệu trong trình soạn thảo với MCP Server trong VS Code  

Thay vì chuyển tab trình duyệt để tìm kiếm tài liệu, bạn có thể đưa Microsoft Learn Docs trực tiếp vào VS Code bằng MCP server. Điều này cho phép bạn:  
- Tìm kiếm và đọc tài liệu ngay trong VS Code mà không phải rời khỏi môi trường lập trình.  
- Tham khảo tài liệu và chèn liên kết trực tiếp vào README hoặc các tệp khóa học.  
- Sử dụng GitHub Copilot và MCP cùng nhau để có quy trình làm việc tài liệu được hỗ trợ bởi AI liền mạch.  

**Ví dụ sử dụng:**  
- Nhanh chóng thêm liên kết tham khảo vào README khi viết tài liệu khóa học hoặc dự án.  
- Dùng Copilot để tạo mã và MCP để tìm và trích dẫn tài liệu liên quan ngay lập tức.  
- Giữ tập trung trong trình soạn thảo và tăng năng suất làm việc.  

> [!IMPORTANT]  
> Đảm bảo bạn có cấu hình [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) hợp lệ trong workspace của mình (vị trí là `.vscode/mcp.json`).  

## Tại sao chọn Chainlit cho Tình huống 2?  

Chainlit là một framework mã nguồn mở hiện đại để xây dựng các ứng dụng web hội thoại. Nó giúp bạn dễ dàng tạo giao diện chat kết nối với các dịch vụ backend như Microsoft Learn Docs MCP server. Dự án này sử dụng Chainlit để cung cấp cách đơn giản, tương tác nhằm tạo kế hoạch học tập cá nhân theo thời gian thực. Nhờ Chainlit, bạn có thể nhanh chóng xây dựng và triển khai các công cụ chat giúp nâng cao hiệu quả học tập và làm việc.  

## Ứng dụng này làm gì  

Ứng dụng cho phép người dùng tạo kế hoạch học tập cá nhân chỉ bằng cách nhập chủ đề và thời gian học. Ứng dụng sẽ phân tích đầu vào, truy vấn Microsoft Learn Docs MCP server để lấy nội dung liên quan, rồi tổ chức kết quả thành kế hoạch theo tuần. Mỗi tuần sẽ có các đề xuất hiển thị trong cửa sổ chat, giúp bạn dễ dàng theo dõi và tiến độ học tập. Việc tích hợp đảm bảo bạn luôn nhận được tài nguyên học tập mới nhất và phù hợp nhất.  

## Ví dụ truy vấn  

Thử các truy vấn sau trong cửa sổ chat để xem ứng dụng phản hồi như thế nào:  

- `Chứng chỉ AI-900, 8 tuần`  
- `Học Azure Functions, 4 tuần`  
- `Azure DevOps, 6 tuần`  
- `Kỹ thuật dữ liệu trên Azure, 10 tuần`  
- `Kiến thức cơ bản về bảo mật Microsoft, 5 tuần`  
- `Power Platform, 7 tuần`  
- `Dịch vụ AI Azure, 12 tuần`  
- `Kiến trúc đám mây, 9 tuần`  

Những ví dụ này thể hiện sự linh hoạt của ứng dụng cho các mục tiêu học tập và khung thời gian khác nhau.  

## Tài liệu tham khảo  

- [Chainlit Documentation](https://docs.chainlit.io/)  
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.