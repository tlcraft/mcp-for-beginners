<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T06:03:41+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "vi"
}
-->
# Dịch vụ Máy tính cơ bản MCP

Dịch vụ này cung cấp các phép toán cơ bản thông qua Model Context Protocol (MCP). Nó được thiết kế như một ví dụ đơn giản dành cho người mới bắt đầu tìm hiểu về các triển khai MCP.

Để biết thêm thông tin, xem [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Tính năng

Dịch vụ máy tính này cung cấp các chức năng sau:

1. **Các phép toán số học cơ bản**:
   - Cộng hai số
   - Trừ một số cho số khác
   - Nhân hai số
   - Chia một số cho số khác (có kiểm tra chia cho 0)

## Sử dụng `stdio` Type

## Cấu hình

1. **Cấu hình MCP Servers**:
   - Mở workspace của bạn trong VS Code.
   - Tạo một file `.vscode/mcp.json` trong thư mục workspace để cấu hình các MCP server. Ví dụ cấu hình:

     ```jsonc
     {
       "inputs": [
         {
           "type": "promptString",
           "id": "repository-root",
           "description": "The absolute path to the repository root"
         }
       ],
       "servers": {
         "calculator-mcp-dotnet": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
             "run",
             "--project",
             "${input:repository-root}/03-GettingStarted/samples/csharp/src/calculator.csproj"
           ]
         }
       }
     }
     ```

   - Bạn sẽ được yêu cầu nhập thư mục gốc của kho GitHub, có thể lấy bằng lệnh `git rev-parse --show-toplevel`.

## Using the Service

The service exposes the following API endpoints through the MCP protocol:

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- isPrime(n): Check if a number is prime

## Test with Github Copilot Chat in VS Code

1. Try making a request to the service using the MCP protocol. For example, you can ask:
   - "Add 5 and 3"
   - "Subtract 10 from 4"
   - "Multiply 6 and 7"
   - "Divide 8 by 2"
   - "Does 37854 prime?"
   - "What are the 3 prime numbers before after 4242?"
2. To make sure it's using the tools add #MyCalculator to the prompt. For example:
   - "Add 5 and 3 #MyCalculator"
   - "Subtract 10 from 4 #MyCalculator


## Containerized Version

The previous soultion is great when you have the .NET SDK installed, and all the dependencies are in place. However, if you would like to share the solution or run it in a different environment, you can use the containerized version.

1. Start Docker and make sure it's running.
1. From a terminal, navigate in the folder `03-GettingStarted\samples\csharp\src` 
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` với tên người dùng Docker Hub của bạn:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. Sau khi xây dựng xong image, hãy tải nó lên Docker Hub. Chạy lệnh sau:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Sử dụng phiên bản Dockerized

1. Trong file `.vscode/mcp.json`, thay thế cấu hình server bằng đoạn sau:
   ```json
    "mcp-calc": {
      "command": "docker",
      "args": [
        "run",
        "--rm",
        "-i",
        "<YOUR-DOCKER-USERNAME>/mcp-calc"
      ],
      "envFile": "",
      "env": {}
    }
   ```
   Nhìn vào cấu hình, bạn có thể thấy lệnh là `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, và giống như trước đây bạn có thể yêu cầu dịch vụ máy tính thực hiện các phép toán cho bạn.

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc sự không chính xác. Tài liệu gốc bằng ngôn ngữ bản địa nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu nhầm hay diễn giải sai nào phát sinh từ việc sử dụng bản dịch này.