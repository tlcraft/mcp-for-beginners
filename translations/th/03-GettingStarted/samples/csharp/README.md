<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T13:00:39+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "th"
}
-->
# บริการเครื่องคิดเลขพื้นฐาน MCP

บริการนี้ให้บริการการดำเนินการเครื่องคิดเลขพื้นฐานผ่าน Model Context Protocol (MCP) ออกแบบมาเป็นตัวอย่างง่าย ๆ สำหรับผู้เริ่มต้นเรียนรู้เกี่ยวกับการใช้งาน MCP

สำหรับข้อมูลเพิ่มเติม ดูที่ [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## คุณสมบัติ

บริการเครื่องคิดเลขนี้มีความสามารถดังต่อไปนี้:

1. **การดำเนินการทางคณิตศาสตร์พื้นฐาน**:
   - การบวกของตัวเลขสองตัว
   - การลบของตัวเลขหนึ่งจากอีกตัวหนึ่ง
   - การคูณของตัวเลขสองตัว
   - การหารของตัวเลขหนึ่งด้วยอีกตัวหนึ่ง (พร้อมตรวจสอบการหารด้วยศูนย์)

## การใช้ `stdio` Type
  
## การตั้งค่า

1. **ตั้งค่าเซิร์ฟเวอร์ MCP**:
   - เปิดพื้นที่ทำงานของคุณใน VS Code
   - สร้างไฟล์ `.vscode/mcp.json` ในโฟลเดอร์พื้นที่ทำงานของคุณเพื่อกำหนดค่าเซิร์ฟเวอร์ MCP ตัวอย่างการตั้งค่า:
     ```json
     {
       "servers": {
         "MyCalculator": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
                "run",
                "--project",
                "D:\\source\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj"
            ],
           "env": {}
         }
       }
     }
     ```
	- เปลี่ยนเส้นทางด้วยเส้นทางไปยังโปรเจคของคุณ เส้นทางควรเป็นแบบสัมบูรณ์และไม่ใช่แบบสัมพัทธ์ต่อโฟลเดอร์พื้นที่ทำงาน (ตัวอย่าง: D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj)

## การใช้บริการ

บริการนี้เปิดเผย API endpoints ต่อไปนี้ผ่าน MCP protocol:

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` ด้วยชื่อผู้ใช้ Docker Hub ของคุณ:
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. หลังจากที่สร้างภาพแล้ว ให้เราอัปโหลดมันไปยัง Docker Hub รันคำสั่งต่อไปนี้:
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## การใช้เวอร์ชั่น Docker

1. ในไฟล์ `.vscode/mcp.json` แทนที่การตั้งค่าเซิร์ฟเวอร์ด้วยสิ่งต่อไปนี้:
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
   มองดูการตั้งค่า คุณจะเห็นว่าคำสั่งคือ `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`, และเหมือนกับก่อนหน้านี้คุณสามารถขอให้บริการเครื่องคิดเลขทำคณิตศาสตร์บางอย่างให้คุณได้

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามอย่างเต็มที่เพื่อความถูกต้อง แต่โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญ แนะนำให้ใช้บริการแปลภาษามนุษย์ที่มีความเชี่ยวชาญ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่เกิดจากการใช้การแปลนี้