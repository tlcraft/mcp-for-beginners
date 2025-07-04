<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T18:06:52+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "vi"
}
-->
# Sử dụng server từ phần mở rộng AI Toolkit cho Visual Studio Code

Khi bạn xây dựng một agent AI, không chỉ là tạo ra các phản hồi thông minh; mà còn là giúp agent có khả năng thực hiện hành động. Đó chính là vai trò của Model Context Protocol (MCP). MCP giúp các agent dễ dàng truy cập các công cụ và dịch vụ bên ngoài một cách nhất quán. Hãy tưởng tượng như bạn đang kết nối agent của mình với một hộp công cụ mà nó *thực sự* có thể sử dụng.

Giả sử bạn kết nối một agent với server MCP máy tính của bạn. Đột nhiên, agent có thể thực hiện các phép toán chỉ bằng cách nhận một câu hỏi như “47 nhân 89 bằng bao nhiêu?” — không cần phải mã hóa cứng logic hay xây dựng API tùy chỉnh.

## Tổng quan

Bài học này hướng dẫn cách kết nối một server MCP máy tính với một agent sử dụng phần mở rộng [AI Toolkit](https://aka.ms/AIToolkit) trong Visual Studio Code, cho phép agent thực hiện các phép toán như cộng, trừ, nhân, chia thông qua ngôn ngữ tự nhiên.

AI Toolkit là một phần mở rộng mạnh mẽ cho Visual Studio Code giúp đơn giản hóa việc phát triển agent. Các kỹ sư AI có thể dễ dàng xây dựng ứng dụng AI bằng cách phát triển và thử nghiệm các mô hình AI sinh tạo — cả trên máy cục bộ hoặc trên đám mây. Phần mở rộng hỗ trợ hầu hết các mô hình sinh tạo phổ biến hiện nay.

*Lưu ý*: AI Toolkit hiện hỗ trợ Python và TypeScript.

## Mục tiêu học tập

Sau bài học này, bạn sẽ có thể:

- Sử dụng một server MCP qua AI Toolkit.
- Cấu hình agent để nó có thể phát hiện và sử dụng các công cụ do server MCP cung cấp.
- Sử dụng các công cụ MCP thông qua ngôn ngữ tự nhiên.

## Cách tiếp cận

Dưới đây là cách tiếp cận tổng quan:

- Tạo một agent và định nghĩa prompt hệ thống cho nó.
- Tạo một server MCP với các công cụ máy tính.
- Kết nối Agent Builder với server MCP.
- Kiểm tra việc gọi công cụ của agent qua ngôn ngữ tự nhiên.

Tuyệt vời, giờ khi đã hiểu quy trình, hãy cấu hình một agent AI để tận dụng các công cụ bên ngoài qua MCP, nâng cao khả năng của nó!

## Yêu cầu trước

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit cho Visual Studio Code](https://aka.ms/AIToolkit)

## Bài tập: Sử dụng một server

Trong bài tập này, bạn sẽ xây dựng, chạy và nâng cấp một agent AI với các công cụ từ server MCP bên trong Visual Studio Code sử dụng AI Toolkit.

### -0- Bước chuẩn bị, thêm mô hình OpenAI GPT-4o vào My Models

Bài tập sử dụng mô hình **GPT-4o**. Mô hình này cần được thêm vào **My Models** trước khi tạo agent.

![Ảnh chụp màn hình giao diện chọn mô hình trong phần mở rộng AI Toolkit của Visual Studio Code. Tiêu đề là "Find the right model for your AI Solution" với phụ đề khuyến khích người dùng khám phá, thử nghiệm và triển khai mô hình AI. Dưới phần “Popular Models,” có sáu thẻ mô hình: DeepSeek-R1 (host trên GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Nhỏ, Nhanh), và DeepSeek-R1 (host trên Ollama). Mỗi thẻ có tùy chọn “Add” hoặc “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.vi.png)

1. Mở phần mở rộng **AI Toolkit** từ **Activity Bar**.
2. Trong phần **Catalog**, chọn **Models** để mở **Model Catalog**. Việc chọn **Models** sẽ mở **Model Catalog** trong một tab trình soạn thảo mới.
3. Trong thanh tìm kiếm của **Model Catalog**, nhập **OpenAI GPT-4o**.
4. Nhấn **+ Add** để thêm mô hình vào danh sách **My Models**. Đảm bảo bạn chọn mô hình được **host bởi GitHub**.
5. Kiểm tra trong **Activity Bar** để xác nhận mô hình **OpenAI GPT-4o** đã xuất hiện trong danh sách.

### -1- Tạo một agent

**Agent (Prompt) Builder** cho phép bạn tạo và tùy chỉnh các agent AI của riêng mình. Trong phần này, bạn sẽ tạo một agent mới và gán một mô hình để hỗ trợ cuộc trò chuyện.

![Ảnh chụp màn hình giao diện "Calculator Agent" trong phần mở rộng AI Toolkit cho Visual Studio Code. Bảng bên trái chọn mô hình "OpenAI GPT-4o (via GitHub)." Prompt hệ thống là "Bạn là một giáo sư đại học dạy toán," và prompt người dùng là "Giải thích cho tôi phương trình Fourier một cách đơn giản." Có các nút thêm công cụ, bật MCP Server, chọn đầu ra có cấu trúc. Nút “Run” màu xanh ở dưới cùng. Bảng bên phải liệt kê ba agent mẫu: Web Developer (với MCP Server, Second-Grade Simplifier, Dream Interpreter, mỗi agent có mô tả chức năng).](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.vi.png)

1. Mở phần mở rộng **AI Toolkit** từ **Activity Bar**.
2. Trong phần **Tools**, chọn **Agent (Prompt) Builder**. Việc chọn này sẽ mở **Agent (Prompt) Builder** trong một tab trình soạn thảo mới.
3. Nhấn nút **+ New Agent**. Phần mở rộng sẽ khởi chạy trình hướng dẫn qua **Command Palette**.
4. Nhập tên **Calculator Agent** và nhấn **Enter**.
5. Trong **Agent (Prompt) Builder**, ở trường **Model**, chọn mô hình **OpenAI GPT-4o (via GitHub)**.

### -2- Tạo prompt hệ thống cho agent

Khi agent đã được tạo khung, đã đến lúc định nghĩa tính cách và mục đích của nó. Trong phần này, bạn sẽ sử dụng tính năng **Generate system prompt** để mô tả hành vi mong muốn của agent — trong trường hợp này là một agent máy tính — và để mô hình tự viết prompt hệ thống cho bạn.

![Ảnh chụp màn hình giao diện "Calculator Agent" trong AI Toolkit với cửa sổ modal "Generate a prompt." Cửa sổ giải thích rằng một mẫu prompt có thể được tạo bằng cách chia sẻ các thông tin cơ bản và có hộp văn bản với prompt mẫu: "Bạn là một trợ lý toán học hữu ích và hiệu quả. Khi được giao một bài toán liên quan đến số học cơ bản, bạn trả lời với kết quả chính xác." Dưới hộp văn bản có nút "Close" và "Generate." Phía sau, phần cấu hình agent hiển thị mô hình "OpenAI GPT-4o (via GitHub)" và các trường prompt hệ thống và người dùng.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.vi.png)

1. Ở phần **Prompts**, nhấn nút **Generate system prompt**. Nút này mở trình tạo prompt sử dụng AI để tạo prompt hệ thống cho agent.
2. Trong cửa sổ **Generate a prompt**, nhập: `Bạn là một trợ lý toán học hữu ích và hiệu quả. Khi được giao một bài toán liên quan đến số học cơ bản, bạn trả lời với kết quả chính xác.`
3. Nhấn nút **Generate**. Một thông báo sẽ xuất hiện ở góc dưới bên phải xác nhận prompt đang được tạo. Khi hoàn tất, prompt sẽ xuất hiện trong trường **System prompt** của **Agent (Prompt) Builder**.
4. Xem lại prompt hệ thống và chỉnh sửa nếu cần.

### -3- Tạo một server MCP

Khi bạn đã định nghĩa prompt hệ thống cho agent — hướng dẫn hành vi và phản hồi của nó — đã đến lúc trang bị cho agent những khả năng thực tế. Trong phần này, bạn sẽ tạo một server MCP máy tính với các công cụ thực hiện phép cộng, trừ, nhân, chia. Server này sẽ cho phép agent thực hiện các phép toán thời gian thực dựa trên các câu hỏi bằng ngôn ngữ tự nhiên.

![Ảnh chụp màn hình phần dưới của giao diện Calculator Agent trong AI Toolkit cho Visual Studio Code. Hiển thị các menu mở rộng “Tools” và “Structure output,” cùng menu thả xuống “Choose output format” đặt ở “text.” Bên phải có nút “+ MCP Server” để thêm một server Model Context Protocol. Có biểu tượng hình ảnh đại diện phía trên phần Tools.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.vi.png)

AI Toolkit được trang bị các mẫu để dễ dàng tạo server MCP của riêng bạn. Chúng ta sẽ sử dụng mẫu Python để tạo server MCP máy tính.

*Lưu ý*: AI Toolkit hiện hỗ trợ Python và TypeScript.

1. Trong phần **Tools** của **Agent (Prompt) Builder**, nhấn nút **+ MCP Server**. Phần mở rộng sẽ khởi chạy trình hướng dẫn qua **Command Palette**.
2. Chọn **+ Add Server**.
3. Chọn **Create a New MCP Server**.
4. Chọn mẫu **python-weather**.
5. Chọn **Default folder** để lưu mẫu server MCP.
6. Nhập tên cho server: **Calculator**
7. Một cửa sổ Visual Studio Code mới sẽ mở. Chọn **Yes, I trust the authors**.
8. Sử dụng terminal (**Terminal** > **New Terminal**), tạo môi trường ảo: `python -m venv .venv`
9. Kích hoạt môi trường ảo trong terminal:
    - Windows - `.venv\Scripts\activate`
    - macOS/Linux - `source venv/bin/activate`
10. Cài đặt các phụ thuộc: `pip install -e .[dev]`
11. Trong phần **Explorer** của **Activity Bar**, mở rộng thư mục **src** và chọn **server.py** để mở file trong trình soạn thảo.
12. Thay thế mã trong file **server.py** bằng đoạn mã sau và lưu lại:

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

### -4- Chạy agent với server MCP máy tính

Khi agent đã có công cụ, đã đến lúc sử dụng chúng! Trong phần này, bạn sẽ gửi các câu hỏi đến agent để kiểm tra và xác nhận agent có sử dụng đúng công cụ từ server MCP máy tính hay không.

![Ảnh chụp màn hình giao diện Calculator Agent trong AI Toolkit cho Visual Studio Code. Bảng bên trái, dưới “Tools,” có một server MCP tên local-server-calculator_server được thêm vào, hiển thị bốn công cụ có sẵn: add, subtract, multiply, divide. Có huy hiệu cho biết bốn công cụ đang hoạt động. Dưới là phần “Structure output” đang thu gọn và nút “Run” màu xanh. Bảng bên phải, dưới “Model Response,” agent gọi công cụ multiply và subtract với đầu vào {"a": 3, "b": 25} và {"a": 75, "b": 20} tương ứng. Phản hồi cuối cùng của công cụ là 75.0. Có nút “View Code” ở dưới cùng.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.vi.png)

Bạn sẽ chạy server MCP máy tính trên máy phát triển cục bộ qua **Agent Builder** như một client MCP.

1. Nhấn `F5` để bắt đầu gỡ lỗi server MCP. **Agent (Prompt) Builder** sẽ mở trong tab trình soạn thảo mới. Trạng thái server hiển thị trong terminal.
2. Trong trường **User prompt** của **Agent (Prompt) Builder**, nhập câu hỏi: `Tôi đã mua 3 món hàng với giá 25 đô mỗi món, sau đó được giảm giá 20 đô. Tôi đã trả bao nhiêu tiền?`
3. Nhấn nút **Run** để tạo phản hồi của agent.
4. Xem lại kết quả của agent. Mô hình nên kết luận bạn đã trả **55 đô**.
5. Đây là diễn biến chi tiết:
    - Agent chọn công cụ **multiply** và **subtract** để hỗ trợ tính toán.
    - Các giá trị `a` và `b` được gán cho công cụ **multiply**.
    - Các giá trị `a` và `b` được gán cho công cụ **subtract**.
    - Phản hồi từ mỗi công cụ được hiển thị trong phần **Tool Response** tương ứng.
    - Kết quả cuối cùng từ mô hình được hiển thị trong phần **Model Response**.
6. Gửi thêm các câu hỏi khác để kiểm tra agent. Bạn có thể chỉnh sửa prompt hiện tại trong trường **User prompt** bằng cách nhấp vào và thay thế nội dung.
7. Khi hoàn tất kiểm tra, bạn có thể dừng server trong **terminal** bằng cách nhấn **CTRL/CMD+C** để thoát.

## Bài tập về nhà

Thử thêm một công cụ mới vào file **server.py** của bạn (ví dụ: trả về căn bậc hai của một số). Gửi các câu hỏi yêu cầu agent sử dụng công cụ mới (hoặc các công cụ hiện có). Nhớ khởi động lại server để tải các công cụ mới thêm vào.

## Giải pháp

[Giải pháp](./solution/README.md)

## Những điểm chính cần nhớ

Những điểm chính từ chương này bao gồm:

- Phần mở rộng AI Toolkit là một client tuyệt vời giúp bạn sử dụng các server MCP và công cụ của chúng.
- Bạn có thể thêm công cụ mới vào server MCP, mở rộng khả năng của agent để đáp ứng các yêu cầu thay đổi.
- AI Toolkit bao gồm các mẫu (ví dụ: mẫu server MCP Python) giúp đơn giản hóa việc tạo công cụ tùy chỉnh.

## Tài nguyên bổ sung

- [Tài liệu AI Toolkit](https://aka.ms/AIToolkit/doc)

## Tiếp theo
- Tiếp theo: [Kiểm thử & Gỡ lỗi](../08-testing/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.