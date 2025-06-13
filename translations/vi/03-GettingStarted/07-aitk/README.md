<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:24:17+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "vi"
}
-->
# Sử dụng server từ phần mở rộng AI Toolkit cho Visual Studio Code

Khi bạn xây dựng một agent AI, không chỉ là tạo ra các phản hồi thông minh; mà còn là trao cho agent khả năng thực hiện hành động. Đó chính là lúc Model Context Protocol (MCP) phát huy tác dụng. MCP giúp các agent dễ dàng truy cập các công cụ và dịch vụ bên ngoài một cách nhất quán. Hãy tưởng tượng như bạn đang kết nối agent của mình với một hộp công cụ mà nó *thực sự* có thể sử dụng được.

Giả sử bạn kết nối một agent với server MCP máy tính của bạn. Đột nhiên, agent có thể thực hiện các phép toán chỉ bằng cách nhận một câu hỏi như “47 nhân 89 bằng bao nhiêu?” — không cần phải mã cứng logic hay xây dựng API riêng.

## Tổng quan

Bài học này hướng dẫn cách kết nối server MCP máy tính với agent bằng phần mở rộng [AI Toolkit](https://aka.ms/AIToolkit) trong Visual Studio Code, cho phép agent thực hiện các phép toán như cộng, trừ, nhân, chia thông qua ngôn ngữ tự nhiên.

AI Toolkit là một phần mở rộng mạnh mẽ cho Visual Studio Code giúp đơn giản hóa việc phát triển agent. Các kỹ sư AI có thể dễ dàng xây dựng ứng dụng AI bằng cách phát triển và thử nghiệm các mô hình AI tạo sinh — cả trên máy cục bộ hoặc đám mây. Phần mở rộng hỗ trợ hầu hết các mô hình tạo sinh phổ biến hiện nay.

*Lưu ý*: AI Toolkit hiện hỗ trợ Python và TypeScript.

## Mục tiêu học tập

Sau bài học này, bạn sẽ có thể:

- Sử dụng một server MCP thông qua AI Toolkit.
- Cấu hình agent để nó có thể phát hiện và sử dụng các công cụ do server MCP cung cấp.
- Sử dụng các công cụ MCP thông qua ngôn ngữ tự nhiên.

## Cách tiếp cận

Dưới đây là cách chúng ta sẽ tiến hành ở mức độ tổng quát:

- Tạo một agent và định nghĩa lời nhắc hệ thống cho nó.
- Tạo một server MCP với các công cụ máy tính.
- Kết nối Agent Builder với server MCP.
- Kiểm tra việc gọi công cụ của agent qua ngôn ngữ tự nhiên.

Tuyệt vời, giờ khi đã hiểu được quy trình, hãy cấu hình một agent AI để tận dụng các công cụ bên ngoài qua MCP, nâng cao khả năng của nó!

## Yêu cầu chuẩn bị

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit cho Visual Studio Code](https://aka.ms/AIToolkit)

## Bài tập: Sử dụng server

Trong bài tập này, bạn sẽ xây dựng, chạy và nâng cấp một agent AI với các công cụ từ server MCP bên trong Visual Studio Code sử dụng AI Toolkit.

### -0- Bước chuẩn bị, thêm mô hình OpenAI GPT-4o vào My Models

Bài tập sử dụng mô hình **GPT-4o**. Mô hình này cần được thêm vào **My Models** trước khi tạo agent.

![Ảnh chụp màn hình giao diện chọn mô hình trong phần mở rộng AI Toolkit của Visual Studio Code. Tiêu đề là "Find the right model for your AI Solution" với dòng phụ khuyến khích người dùng khám phá, thử nghiệm và triển khai mô hình AI. Dưới phần “Popular Models,” có sáu thẻ mô hình: DeepSeek-R1 (host trên GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Nhỏ, Nhanh), và DeepSeek-R1 (host trên Ollama). Mỗi thẻ có nút “Add” và “Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.vi.png)

1. Mở phần mở rộng **AI Toolkit** từ **Activity Bar**.
2. Trong phần **Catalog**, chọn **Models** để mở **Model Catalog**. Việc chọn **Models** sẽ mở tab trình soạn thảo mới chứa **Model Catalog**.
3. Trong thanh tìm kiếm của **Model Catalog**, nhập **OpenAI GPT-4o**.
4. Nhấn **+ Add** để thêm mô hình vào danh sách **My Models**. Đảm bảo bạn chọn mô hình **Hosted by GitHub**.
5. Trong **Activity Bar**, kiểm tra xem mô hình **OpenAI GPT-4o** đã xuất hiện trong danh sách chưa.

### -1- Tạo một agent

**Agent (Prompt) Builder** cho phép bạn tạo và tùy chỉnh các agent AI của riêng mình. Ở phần này, bạn sẽ tạo một agent mới và gán mô hình để điều khiển cuộc trò chuyện.

![Ảnh chụp màn hình giao diện "Calculator Agent" trong AI Toolkit của Visual Studio Code. Bảng bên trái chọn mô hình "OpenAI GPT-4o (via GitHub)". Lời nhắc hệ thống là "You are a professor in university teaching math," và lời nhắc người dùng là "Explain to me the Fourier equation in simple terms." Có các nút thêm công cụ, bật MCP Server, và chọn đầu ra có cấu trúc. Nút “Run” màu xanh ở dưới cùng. Bảng bên phải liệt kê ba agent mẫu: Web Developer (có MCP Server), Second-Grade Simplifier, và Dream Interpreter với mô tả ngắn gọn chức năng của từng agent.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.vi.png)

1. Mở phần mở rộng **AI Toolkit** từ **Activity Bar**.
2. Trong phần **Tools**, chọn **Agent (Prompt) Builder**. Việc chọn này sẽ mở tab trình soạn thảo mới cho **Agent (Prompt) Builder**.
3. Nhấn nút **+ New Agent**. Phần mở rộng sẽ khởi chạy trình hướng dẫn thiết lập qua **Command Palette**.
4. Nhập tên **Calculator Agent** và nhấn **Enter**.
5. Trong **Agent (Prompt) Builder**, ở trường **Model**, chọn mô hình **OpenAI GPT-4o (via GitHub)**.

### -2- Tạo lời nhắc hệ thống cho agent

Khi agent đã được tạo, đã đến lúc định nghĩa tính cách và mục đích của nó. Ở phần này, bạn sẽ dùng tính năng **Generate system prompt** để mô tả hành vi dự kiến của agent — trong trường hợp này là một agent máy tính — và để mô hình viết lời nhắc hệ thống cho bạn.

![Ảnh chụp màn hình giao diện "Calculator Agent" trong AI Toolkit với cửa sổ modal "Generate a prompt" mở. Modal giải thích rằng bạn có thể tạo mẫu lời nhắc bằng cách cung cấp thông tin cơ bản và có một hộp văn bản chứa lời nhắc mẫu: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Dưới hộp văn bản có nút "Close" và "Generate". Phía sau, phần cấu hình agent vẫn hiện, gồm mô hình "OpenAI GPT-4o (via GitHub)" và các trường lời nhắc hệ thống và người dùng.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.vi.png)

1. Ở phần **Prompts**, nhấn nút **Generate system prompt**. Nút này mở trình tạo lời nhắc, sử dụng AI để tạo lời nhắc hệ thống cho agent.
2. Trong cửa sổ **Generate a prompt**, nhập: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Nhấn nút **Generate**. Một thông báo sẽ xuất hiện ở góc dưới bên phải xác nhận lời nhắc đang được tạo. Khi hoàn tất, lời nhắc sẽ hiện trong trường **System prompt** của **Agent (Prompt) Builder**.
4. Xem lại lời nhắc hệ thống và chỉnh sửa nếu cần.

### -3- Tạo server MCP

Sau khi đã định nghĩa lời nhắc hệ thống cho agent — hướng dẫn hành vi và phản hồi — giờ là lúc trang bị cho agent các khả năng thực tế. Ở phần này, bạn sẽ tạo một server MCP máy tính với các công cụ thực hiện phép cộng, trừ, nhân, chia. Server này sẽ giúp agent thực hiện các phép toán thời gian thực dựa trên các câu hỏi bằng ngôn ngữ tự nhiên.

![Ảnh chụp màn hình phần dưới của giao diện Calculator Agent trong AI Toolkit của Visual Studio Code. Hiển thị các menu có thể mở rộng “Tools” và “Structure output,” cùng menu thả xuống “Choose output format” đang chọn “text.” Bên phải có nút “+ MCP Server” để thêm Model Context Protocol server. Phía trên phần Tools có biểu tượng hình ảnh giữ chỗ.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.vi.png)

AI Toolkit có sẵn các mẫu để dễ dàng tạo server MCP của riêng bạn. Ở đây ta sẽ dùng mẫu Python để tạo server MCP máy tính.

*Lưu ý*: AI Toolkit hiện hỗ trợ Python và TypeScript.

1. Trong phần **Tools** của **Agent (Prompt) Builder**, nhấn nút **+ MCP Server**. Phần mở rộng sẽ khởi chạy trình hướng dẫn thiết lập qua **Command Palette**.
2. Chọn **+ Add Server**.
3. Chọn **Create a New MCP Server**.
4. Chọn mẫu **python-weather**.
5. Chọn **Default folder** để lưu mẫu server MCP.
6. Nhập tên server: **Calculator**
7. Một cửa sổ Visual Studio Code mới sẽ mở ra. Chọn **Yes, I trust the authors**.
8. Dùng terminal (**Terminal** > **New Terminal**), tạo môi trường ảo: `python -m venv .venv`
9. Dùng terminal, kích hoạt môi trường ảo:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Dùng terminal, cài đặt các phụ thuộc: `pip install -e .[dev]`
11. Trong **Explorer** của **Activity Bar**, mở rộng thư mục **src** và chọn **server.py** để mở trong trình soạn thảo.
12. Thay thế mã trong file **server.py** bằng đoạn sau và lưu lại:

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

Giờ agent đã có công cụ, hãy sử dụng chúng! Ở phần này, bạn sẽ gửi các câu hỏi đến agent để kiểm tra và xác nhận agent có sử dụng đúng công cụ từ server MCP máy tính hay không.

![Ảnh chụp màn hình giao diện Calculator Agent trong AI Toolkit của Visual Studio Code. Bên trái, trong phần “Tools,” có server MCP tên local-server-calculator_server với bốn công cụ: add, subtract, multiply, và divide. Có biểu tượng cho thấy bốn công cụ đang hoạt động. Phần “Structure output” đang thu gọn và nút “Run” màu xanh. Bên phải, phần “Model Response” hiển thị agent gọi các công cụ multiply và subtract với đầu vào {"a": 3, "b": 25} và {"a": 75, "b": 20}. Phản hồi cuối cùng của công cụ là 75.0. Có nút “View Code” ở dưới cùng.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.vi.png)

Bạn sẽ chạy server MCP máy tính trên máy phát triển cục bộ thông qua **Agent Builder** như client MCP.

1. Nhấn `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Tôi đã mua 3 món đồ, mỗi món giá 25 đô la, sau đó được giảm giá 20 đô la. Tôi đã trả bao nhiêu?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` giá trị được gán cho công cụ **subtract**.
    - Phản hồi từ từng công cụ sẽ được hiển thị trong phần **Tool Response** tương ứng.
    - Kết quả cuối cùng từ mô hình sẽ hiển thị trong phần **Model Response**.
2. Gửi thêm các câu hỏi khác để thử nghiệm agent. Bạn có thể thay đổi câu hỏi hiện có trong trường **User prompt** bằng cách nhấp vào và nhập câu hỏi mới.
3. Khi kết thúc thử nghiệm, bạn có thể dừng server bằng cách vào **terminal** và nhấn **CTRL/CMD+C** để thoát.

## Bài tập về nhà

Thử thêm một công cụ mới vào file **server.py** của bạn (ví dụ: trả về căn bậc hai của một số). Gửi thêm các câu hỏi cần agent sử dụng công cụ mới (hoặc các công cụ hiện có). Nhớ khởi động lại server để tải các công cụ mới.

## Giải pháp

[Solution](./solution/README.md)

## Những điểm cần ghi nhớ

Những điểm chính từ chương này là:

- Phần mở rộng AI Toolkit là một client tuyệt vời cho phép bạn sử dụng MCP Servers và các công cụ của chúng.
- Bạn có thể thêm công cụ mới vào các server MCP, mở rộng khả năng của agent để đáp ứng các yêu cầu thay đổi.
- AI Toolkit bao gồm các mẫu (ví dụ: mẫu server MCP Python) giúp đơn giản hóa việc tạo các công cụ tùy chỉnh.

## Tài nguyên bổ sung

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Tiếp theo
- Tiếp theo: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn tham khảo chính xác nhất. Đối với thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.