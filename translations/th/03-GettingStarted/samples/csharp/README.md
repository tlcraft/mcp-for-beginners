<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:59:52+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "th"
}
-->
# Basic Calculator MCP Service

บริการนี้ให้บริการการคำนวณพื้นฐานผ่าน Model Context Protocol (MCP) ถูกออกแบบมาเป็นตัวอย่างง่ายๆ สำหรับผู้เริ่มต้นที่เรียนรู้เกี่ยวกับการใช้งาน MCP

สำหรับข้อมูลเพิ่มเติม ดูที่ [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## คุณสมบัติ

บริการเครื่องคิดเลขนี้มีความสามารถดังต่อไปนี้:

1. **การดำเนินการทางคณิตศาสตร์พื้นฐาน**:
   - การบวกเลขสองจำนวน
   - การลบเลขจำนวนหนึ่งจากอีกจำนวนหนึ่ง
   - การคูณเลขสองจำนวน
   - การหารเลขจำนวนหนึ่งด้วยอีกจำนวนหนึ่ง (พร้อมตรวจสอบการหารด้วยศูนย์)

## การใช้ `stdio` Type

## การตั้งค่า

1. **ตั้งค่า MCP Servers**:
   - เปิด workspace ของคุณใน VS Code
   - สร้างไฟล์ `.vscode/mcp.json` ในโฟลเดอร์ workspace ของคุณเพื่อกำหนดค่า MCP servers ตัวอย่างการตั้งค่า:

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

   - คุณจะถูกขอให้ใส่ root ของ GitHub repository ซึ่งสามารถดึงได้จากคำสั่ง `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` โดยใช้ชื่อผู้ใช้ Docker Hub ของคุณ:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. หลังจากสร้าง image เสร็จแล้ว ให้ทำการอัปโหลดไปยัง Docker Hub โดยรันคำสั่งดังนี้:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## การใช้งานเวอร์ชัน Dockerized

1. ในไฟล์ `.vscode/mcp.json` ให้แทนที่การตั้งค่า server ด้วยค่าดังนี้:
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
   จากการดูการตั้งค่า คุณจะเห็นว่าคำสั่งคือ `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` และเหมือนเดิม คุณสามารถขอให้บริการเครื่องคิดเลขทำการคำนวณให้คุณได้เลย

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้ความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดขึ้นจากการใช้การแปลนี้