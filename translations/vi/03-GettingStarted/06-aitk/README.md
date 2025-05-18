<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:25:57+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "vi"
}
-->
# Sử dụng một máy chủ từ tiện ích mở rộng AI Toolkit cho Visual Studio Code

Khi bạn xây dựng một tác nhân AI, không chỉ đơn giản là tạo ra các phản hồi thông minh; mà còn là việc cho phép tác nhân của bạn có khả năng thực hiện hành động. Đó là lúc Giao thức Ngữ cảnh Mô hình (MCP) ra đời. MCP giúp các tác nhân dễ dàng truy cập vào các công cụ và dịch vụ bên ngoài một cách nhất quán. Hãy tưởng tượng như bạn đang cắm tác nhân của mình vào một hộp công cụ mà nó có thể *thực sự* sử dụng.

Giả sử bạn kết nối một tác nhân với máy chủ MCP máy tính của bạn. Đột nhiên, tác nhân của bạn có thể thực hiện các phép toán chỉ bằng cách nhận một câu hỏi như “47 nhân với 89 là bao nhiêu?”—không cần mã hóa logic hay xây dựng các API tùy chỉnh.

## Tổng quan

Bài học này bao gồm cách kết nối một máy chủ MCP máy tính với một tác nhân bằng tiện ích mở rộng [AI Toolkit](https://aka.ms/AIToolkit) trong Visual Studio Code, cho phép tác nhân của bạn thực hiện các phép toán như cộng, trừ, nhân, và chia thông qua ngôn ngữ tự nhiên.

AI Toolkit là một tiện ích mở rộng mạnh mẽ cho Visual Studio Code giúp đơn giản hóa việc phát triển tác nhân. Kỹ sư AI có thể dễ dàng xây dựng các ứng dụng AI bằng cách phát triển và kiểm thử các mô hình AI sinh tạo—trên máy cục bộ hoặc trên đám mây. Tiện ích mở rộng hỗ trợ hầu hết các mô hình sinh tạo lớn có sẵn ngày nay.

*Lưu ý*: AI Toolkit hiện hỗ trợ Python và TypeScript.

## Mục tiêu học tập

Khi hoàn thành bài học này, bạn sẽ có thể:

- Sử dụng một máy chủ MCP qua AI Toolkit.
- Cấu hình một cấu hình tác nhân để cho phép nó khám phá và sử dụng các công cụ được cung cấp bởi máy chủ MCP.
- Sử dụng các công cụ MCP qua ngôn ngữ tự nhiên.

## Phương pháp

Đây là cách chúng ta cần tiếp cận ở cấp độ cao:

- Tạo một tác nhân và định nghĩa lời nhắc hệ thống của nó.
- Tạo một máy chủ MCP với các công cụ máy tính.
- Kết nối Trình tạo Tác nhân với máy chủ MCP.
- Kiểm tra việc gọi công cụ của tác nhân qua ngôn ngữ tự nhiên.

Tuyệt vời, bây giờ chúng ta đã hiểu quy trình, hãy cấu hình một tác nhân AI để tận dụng các công cụ bên ngoài qua MCP, tăng cường khả năng của nó!

## Yêu cầu

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit cho Visual Studio Code](https://aka.ms/AIToolkit)

## Bài tập: Sử dụng một máy chủ

Trong bài tập này, bạn sẽ xây dựng, chạy, và cải thiện một tác nhân AI với các công cụ từ một máy chủ MCP trong Visual Studio Code bằng AI Toolkit.

### -0- Bước chuẩn bị, thêm mô hình OpenAI GPT-4o vào Mô hình của tôi

Bài tập sử dụng mô hình **GPT-4o**. Mô hình này cần được thêm vào **Mô hình của tôi** trước khi tạo tác nhân.

1. Mở tiện ích mở rộng **AI Toolkit** từ **Thanh Hoạt động**.
1. Trong phần **Danh mục**, chọn **Mô hình** để mở **Danh mục Mô hình**. Việc chọn **Mô hình** sẽ mở **Danh mục Mô hình** trong một tab biên tập mới.
1. Trong thanh tìm kiếm **Danh mục Mô hình**, nhập **OpenAI GPT-4o**.
1. Nhấp vào **+ Thêm** để thêm mô hình vào danh sách **Mô hình của tôi**. Đảm bảo rằng bạn đã chọn mô hình **Được lưu trữ bởi GitHub**.
1. Trong **Thanh Hoạt động**, xác nhận rằng mô hình **OpenAI GPT-4o** xuất hiện trong danh sách.

### -1- Tạo một tác nhân

**Trình tạo Tác nhân (Lời nhắc)** cho phép bạn tạo và tùy chỉnh các tác nhân được hỗ trợ bởi AI của riêng bạn. Trong phần này, bạn sẽ tạo một tác nhân mới và gán một mô hình để cung cấp sức mạnh cho cuộc trò chuyện.

1. Mở tiện ích mở rộng **AI Toolkit** từ **Thanh Hoạt động**.
1. Trong phần **Công cụ**, chọn **Trình tạo Tác nhân (Lời nhắc)**. Việc chọn **Trình tạo Tác nhân (Lời nhắc)** sẽ mở **Trình tạo Tác nhân (Lời nhắc)** trong một tab biên tập mới.
1. Nhấp vào nút **+ Trình tạo Mới**. Tiện ích mở rộng sẽ khởi chạy một trình hướng dẫn thiết lập qua **Bảng Lệnh**.
1. Nhập tên **Tác nhân Máy tính** và nhấn **Enter**.
1. Trong **Trình tạo Tác nhân (Lời nhắc)**, đối với trường **Mô hình**, chọn mô hình **OpenAI GPT-4o (qua GitHub)**.

### -2- Tạo lời nhắc hệ thống cho tác nhân

Với khung tác nhân đã được tạo, đã đến lúc xác định tính cách và mục đích của nó. Trong phần này, bạn sẽ sử dụng tính năng **Tạo lời nhắc hệ thống** để mô tả hành vi dự định của tác nhân—trong trường hợp này là tác nhân máy tính—và để mô hình viết lời nhắc hệ thống cho bạn.

1. Đối với phần **Lời nhắc**, nhấp vào nút **Tạo lời nhắc hệ thống**. Nút này mở trong trình tạo lời nhắc sử dụng AI để tạo một lời nhắc hệ thống cho tác nhân.
1. Trong cửa sổ **Tạo một lời nhắc**, nhập vào: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Nhấp vào nút **Tạo**. Một thông báo sẽ xuất hiện ở góc dưới bên phải xác nhận rằng lời nhắc hệ thống đang được tạo. Khi quá trình tạo lời nhắc hoàn tất, lời nhắc sẽ xuất hiện trong trường **Lời nhắc hệ thống** của **Trình tạo Tác nhân (Lời nhắc)**.
1. Xem xét **Lời nhắc hệ thống** và sửa đổi nếu cần.

### -3- Tạo một máy chủ MCP

Bây giờ bạn đã định nghĩa lời nhắc hệ thống của tác nhân—hướng dẫn hành vi và phản hồi của nó—đã đến lúc trang bị cho tác nhân các khả năng thực tế. Trong phần này, bạn sẽ tạo một máy chủ MCP máy tính với các công cụ để thực hiện các phép tính cộng, trừ, nhân, và chia. Máy chủ này sẽ cho phép tác nhân của bạn thực hiện các phép toán thời gian thực để đáp lại các câu hỏi bằng ngôn ngữ tự nhiên.

AI Toolkit được trang bị các mẫu để dễ dàng tạo máy chủ MCP của riêng bạn. Chúng ta sẽ sử dụng mẫu Python để tạo máy chủ MCP máy tính.

*Lưu ý*: AI Toolkit hiện hỗ trợ Python và TypeScript.

1. Trong phần **Công cụ** của **Trình tạo Tác nhân (Lời nhắc)**, nhấp vào nút **+ Máy chủ MCP**. Tiện ích mở rộng sẽ khởi chạy một trình hướng dẫn thiết lập qua **Bảng Lệnh**.
1. Chọn **+ Thêm Máy chủ**.
1. Chọn **Tạo một Máy chủ MCP Mới**.
1. Chọn **python-weather** làm mẫu.
1. Chọn **Thư mục mặc định** để lưu mẫu máy chủ MCP.
1. Nhập tên sau cho máy chủ: **Máy tính**
1. Một cửa sổ Visual Studio Code mới sẽ mở ra. Chọn **Có, tôi tin tưởng các tác giả**.
1. Sử dụng terminal (**Terminal** > **Terminal Mới**), tạo một môi trường ảo: `python -m venv .venv`
1. Sử dụng terminal, kích hoạt môi trường ảo:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Sử dụng terminal, cài đặt các phụ thuộc: `pip install -e .[dev]`
1. Trong chế độ xem **Explorer** của **Thanh Hoạt động**, mở rộng thư mục **src** và chọn **server.py** để mở tệp trong trình biên tập.
1. Thay thế mã trong tệp **server.py** bằng nội dung sau và lưu lại:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- Chạy tác nhân với máy chủ MCP máy tính

Bây giờ tác nhân của bạn đã có công cụ, đã đến lúc sử dụng chúng! Trong phần này, bạn sẽ gửi các câu hỏi đến tác nhân để kiểm tra và xác thực xem liệu tác nhân có sử dụng công cụ thích hợp từ máy chủ MCP máy tính hay không.

Bạn sẽ chạy máy chủ MCP máy tính trên máy phát triển cục bộ của mình qua **Trình tạo Tác nhân** như một khách hàng MCP.

1. Nhấn `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Tôi đã mua 3 món hàng giá $25 mỗi cái, và sau đó dùng một mã giảm giá $20. Tôi đã trả bao nhiêu?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` các giá trị được gán cho công cụ **trừ**.
    - Phản hồi từ mỗi công cụ được cung cấp trong **Phản hồi Công cụ** tương ứng.
    - Kết quả cuối cùng từ mô hình được cung cấp trong **Phản hồi Mô hình** cuối cùng.
1. Gửi thêm các câu hỏi để kiểm tra thêm tác nhân. Bạn có thể sửa đổi câu hỏi hiện có trong trường **Lời nhắc người dùng** bằng cách nhấp vào trường và thay thế câu hỏi hiện có.
1. Khi bạn đã hoàn tất việc kiểm tra tác nhân, bạn có thể dừng máy chủ qua **terminal** bằng cách nhập **CTRL/CMD+C** để thoát.

## Bài tập

Hãy thử thêm một mục công cụ bổ sung vào tệp **server.py** của bạn (ví dụ: trả về căn bậc hai của một số). Gửi thêm các câu hỏi yêu cầu tác nhân sử dụng công cụ mới của bạn (hoặc các công cụ hiện có). Hãy chắc chắn khởi động lại máy chủ để tải các công cụ mới được thêm vào.

## Giải pháp

[Giải pháp](./solution/README.md)

## Những điểm chính cần ghi nhớ

Những điểm chính từ chương này là:

- Tiện ích mở rộng AI Toolkit là một khách hàng tuyệt vời cho phép bạn sử dụng các Máy chủ MCP và các công cụ của chúng.
- Bạn có thể thêm các công cụ mới vào các máy chủ MCP, mở rộng khả năng của tác nhân để đáp ứng các yêu cầu phát triển.
- AI Toolkit bao gồm các mẫu (ví dụ: mẫu máy chủ MCP Python) để đơn giản hóa việc tạo các công cụ tùy chỉnh.

## Tài nguyên bổ sung

- [Tài liệu AI Toolkit](https://aka.ms/AIToolkit/doc)

## Tiếp theo

Tiếp theo: [Bài học 4 Thực hiện Thực tế](/04-PracticalImplementation/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn thông tin chính thức. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp của con người. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.