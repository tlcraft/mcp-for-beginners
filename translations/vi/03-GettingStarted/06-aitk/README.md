<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:44:57+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "vi"
}
-->
# Sử dụng một server từ phần mở rộng AI Toolkit cho Visual Studio Code

Khi bạn xây dựng một agent AI, không chỉ đơn thuần là tạo ra các phản hồi thông minh; mà còn là khả năng để agent đó thực hiện hành động. Đó chính là vai trò của Model Context Protocol (MCP). MCP giúp các agent dễ dàng truy cập các công cụ và dịch vụ bên ngoài một cách nhất quán. Hãy tưởng tượng nó như việc bạn kết nối agent của mình với một hộp công cụ mà agent *thực sự* có thể sử dụng.

Giả sử bạn kết nối một agent với server MCP máy tính của bạn. Đột nhiên, agent có thể thực hiện các phép toán chỉ bằng cách nhận một câu hỏi như “47 nhân 89 bằng bao nhiêu?” — không cần phải mã hóa cứng logic hay xây dựng API tùy chỉnh.

## Tổng quan

Bài học này hướng dẫn cách kết nối một server MCP máy tính với agent thông qua phần mở rộng [AI Toolkit](https://aka.ms/AIToolkit) trên Visual Studio Code, giúp agent thực hiện các phép toán như cộng, trừ, nhân, chia bằng ngôn ngữ tự nhiên.

AI Toolkit là một phần mở rộng mạnh mẽ cho Visual Studio Code giúp đơn giản hóa việc phát triển agent. Các kỹ sư AI có thể dễ dàng xây dựng ứng dụng AI bằng cách phát triển và thử nghiệm các mô hình AI sinh tạo — cục bộ hoặc trên đám mây. Phần mở rộng hỗ trợ hầu hết các mô hình sinh tạo phổ biến hiện nay.

*Lưu ý*: AI Toolkit hiện hỗ trợ Python và TypeScript.

## Mục tiêu học tập

Kết thúc bài học này, bạn sẽ có thể:

- Sử dụng một server MCP thông qua AI Toolkit.
- Cấu hình agent để nó có thể phát hiện và sử dụng các công cụ do server MCP cung cấp.
- Sử dụng các công cụ MCP qua ngôn ngữ tự nhiên.

## Phương pháp

Dưới đây là cách tiếp cận tổng quan:

- Tạo một agent và xác định prompt hệ thống cho nó.
- Tạo một server MCP với các công cụ máy tính.
- Kết nối Agent Builder với server MCP.
- Kiểm tra việc gọi công cụ của agent qua ngôn ngữ tự nhiên.

Tuyệt vời, bây giờ khi đã hiểu được quy trình, hãy cấu hình một agent AI để tận dụng các công cụ bên ngoài qua MCP, nâng cao khả năng của nó!

## Yêu cầu trước

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit cho Visual Studio Code](https://aka.ms/AIToolkit)

## Bài tập: Sử dụng một server

Trong bài tập này, bạn sẽ xây dựng, chạy và nâng cấp một agent AI với các công cụ từ server MCP bên trong Visual Studio Code sử dụng AI Toolkit.

### -0- Bước chuẩn bị, thêm mô hình OpenAI GPT-4o vào My Models

Bài tập sử dụng mô hình **GPT-4o**. Mô hình này cần được thêm vào **My Models** trước khi tạo agent.

![Ảnh chụp màn hình giao diện chọn mô hình trong phần mở rộng AI Toolkit của Visual Studio Code. Tiêu đề là "Find the right model for your AI Solution" với phụ đề khuyến khích người dùng khám phá, thử nghiệm và triển khai các mô hình AI. Dưới phần “Popular Models” có sáu thẻ mô hình: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), và DeepSeek-R1 (Ollama-hosted). Mỗi thẻ có tùy chọn “Add” hoặc “Try in Playground”.](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.vi.png)

1. Mở phần mở rộng **AI Toolkit** từ **Activity Bar**.
2. Trong phần **Catalog**, chọn **Models** để mở **Model Catalog**. Việc chọn **Models** sẽ mở **Model Catalog** trong một tab trình soạn thảo mới.
3. Trong thanh tìm kiếm của **Model Catalog**, nhập **OpenAI GPT-4o**.
4. Nhấn **+ Add** để thêm mô hình vào danh sách **My Models**. Đảm bảo bạn chọn mô hình được **Hosted by GitHub**.
5. Trên **Activity Bar**, xác nhận rằng mô hình **OpenAI GPT-4o** đã xuất hiện trong danh sách.

### -1- Tạo một agent

**Agent (Prompt) Builder** cho phép bạn tạo và tùy chỉnh các agent AI của riêng mình. Ở phần này, bạn sẽ tạo một agent mới và gán mô hình để hỗ trợ cuộc hội thoại.

![Ảnh chụp màn hình giao diện "Calculator Agent" trong phần mở rộng AI Toolkit cho Visual Studio Code. Bên trái là mô hình được chọn "OpenAI GPT-4o (via GitHub)." Prompt hệ thống là "You are a professor in university teaching math," và prompt người dùng là "Explain to me the Fourier equation in simple terms." Có các nút thêm công cụ, bật MCP Server, và chọn output có cấu trúc. Nút “Run” màu xanh ở dưới. Bên phải là phần "Get Started with Examples" với ba agent mẫu: Web Developer (có MCP Server), Second-Grade Simplifier, và Dream Interpreter, mỗi agent có mô tả ngắn về chức năng.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.vi.png)

1. Mở phần mở rộng **AI Toolkit** từ **Activity Bar**.
2. Trong phần **Tools**, chọn **Agent (Prompt) Builder**. Việc chọn này sẽ mở **Agent (Prompt) Builder** trong một tab mới.
3. Nhấn nút **+ New Agent**. Phần mở rộng sẽ khởi chạy một trình hướng dẫn qua **Command Palette**.
4. Nhập tên **Calculator Agent** và nhấn **Enter**.
5. Trong **Agent (Prompt) Builder**, tại trường **Model**, chọn mô hình **OpenAI GPT-4o (via GitHub)**.

### -2- Tạo prompt hệ thống cho agent

Sau khi đã tạo khung cho agent, đã đến lúc xác định tính cách và mục đích của nó. Ở phần này, bạn sẽ sử dụng tính năng **Generate system prompt** để mô tả hành vi mong muốn của agent — ở đây là một agent máy tính — và để mô hình viết prompt hệ thống cho bạn.

![Ảnh chụp màn hình giao diện "Calculator Agent" trong AI Toolkit với cửa sổ modal "Generate a prompt." Cửa sổ giải thích có thể tạo template prompt bằng cách chia sẻ các thông tin cơ bản và có ô nhập văn bản với prompt mẫu: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Dưới ô nhập có nút "Close" và "Generate." Phía sau cửa sổ modal là cấu hình agent với mô hình "OpenAI GPT-4o (via GitHub)" và các trường prompt hệ thống và người dùng.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.vi.png)

1. Trong phần **Prompts**, nhấn nút **Generate system prompt**. Nút này sẽ mở trình tạo prompt sử dụng AI để tạo prompt hệ thống cho agent.
2. Trong cửa sổ **Generate a prompt**, nhập nội dung sau: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Nhấn nút **Generate**. Một thông báo sẽ hiện ở góc dưới bên phải xác nhận prompt hệ thống đang được tạo. Khi hoàn tất, prompt sẽ xuất hiện trong trường **System prompt** của **Agent (Prompt) Builder**.
4. Xem lại prompt hệ thống và chỉnh sửa nếu cần.

### -3- Tạo một server MCP

Giờ bạn đã xác định prompt hệ thống cho agent — hướng dẫn hành vi và phản hồi của nó — đã đến lúc trang bị cho agent các khả năng thực tế. Ở phần này, bạn sẽ tạo một server MCP máy tính với các công cụ thực hiện các phép tính cộng, trừ, nhân, chia. Server này sẽ cho phép agent thực hiện các phép toán thời gian thực dựa trên các câu lệnh ngôn ngữ tự nhiên.

![Ảnh chụp màn hình phần dưới giao diện Calculator Agent trong AI Toolkit cho Visual Studio Code. Hiển thị các menu mở rộng cho “Tools” và “Structure output,” cùng menu thả xuống “Choose output format” đang chọn “text.” Bên phải có nút “+ MCP Server” để thêm Model Context Protocol server. Có biểu tượng hình ảnh đại diện phía trên phần Tools.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.vi.png)

AI Toolkit có sẵn các template giúp dễ dàng tạo server MCP riêng. Ở đây ta sẽ dùng template Python để tạo server MCP máy tính.

*Lưu ý*: AI Toolkit hiện hỗ trợ Python và TypeScript.

1. Trong phần **Tools** của **Agent (Prompt) Builder**, nhấn nút **+ MCP Server**. Phần mở rộng sẽ khởi chạy trình hướng dẫn qua **Command Palette**.
2. Chọn **+ Add Server**.
3. Chọn **Create a New MCP Server**.
4. Chọn template **python-weather**.
5. Chọn **Default folder** để lưu template server MCP.
6. Đặt tên cho server: **Calculator**
7. Một cửa sổ Visual Studio Code mới sẽ mở. Chọn **Yes, I trust the authors**.
8. Dùng terminal (**Terminal** > **New Terminal**), tạo môi trường ảo: `python -m venv .venv`
9. Kích hoạt môi trường ảo trong terminal:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. Cài đặt các phụ thuộc qua terminal: `pip install -e .[dev]`
11. Trong phần **Explorer** trên **Activity Bar**, mở rộng thư mục **src** và chọn **server.py** để mở file trong trình soạn thảo.
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

Giờ agent đã có công cụ, hãy sử dụng chúng! Ở phần này, bạn sẽ gửi prompt đến agent để kiểm tra và xác nhận agent có sử dụng đúng công cụ từ server MCP máy tính hay không.

![Ảnh chụp màn hình giao diện Calculator Agent trong AI Toolkit cho Visual Studio Code. Bên trái, dưới “Tools,” có một MCP server tên local-server-calculator_server với bốn công cụ: add, subtract, multiply, và divide. Có badge cho biết có bốn công cụ đang hoạt động. Phần “Structure output” bị thu gọn và nút “Run” màu xanh. Bên phải, phần “Model Response” hiển thị agent gọi công cụ multiply và subtract với các đầu vào {"a": 3, "b": 25} và {"a": 75, "b": 20}. Kết quả “Tool Response” cuối cùng là 75.0. Có nút “View Code” bên dưới.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.vi.png)

Bạn sẽ chạy server MCP máy tính trên máy phát triển cục bộ thông qua **Agent Builder** như một client MCP.

1. Nhấn `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Tôi đã mua 3 món với giá 25 đô mỗi món, rồi được giảm 20 đô. Tôi đã trả bao nhiêu tiền?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` giá trị được gán cho công cụ **subtract**.
    - Phản hồi từ từng công cụ sẽ hiển thị trong phần **Tool Response** tương ứng.
    - Kết quả cuối cùng từ mô hình sẽ hiển thị trong phần **Model Response**.
2. Gửi thêm các prompt khác để kiểm tra agent. Bạn có thể chỉnh sửa prompt hiện tại trong trường **User prompt** bằng cách nhấp vào và thay thế nội dung.
3. Khi hoàn thành kiểm tra, bạn có thể dừng server qua **terminal** bằng cách nhấn **CTRL/CMD+C** để thoát.

## Bài tập về nhà

Hãy thử thêm một công cụ mới vào file **server.py** của bạn (ví dụ: trả về căn bậc hai của một số). Gửi thêm các prompt để agent có thể sử dụng công cụ mới (hoặc các công cụ hiện có). Nhớ khởi động lại server để tải các công cụ mới thêm vào.

## Giải pháp

[Solution](./solution/README.md)

## Những điểm cần nhớ

Các điểm chính trong chương này:

- Phần mở rộng AI Toolkit là một client tuyệt vời giúp bạn sử dụng các server MCP và công cụ của chúng.
- Bạn có thể thêm công cụ mới vào các server MCP, mở rộng khả năng của agent để đáp ứng các yêu cầu thay đổi.
- AI Toolkit có các template (ví dụ: template server MCP Python) giúp đơn giản hóa việc tạo các công cụ tùy chỉnh.

## Tài nguyên bổ sung

- [Tài liệu AI Toolkit](https://aka.ms/AIToolkit/doc)

## Tiếp theo

Tiếp theo: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Tuyên bố miễn trừ trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được xem là nguồn chính thức. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.