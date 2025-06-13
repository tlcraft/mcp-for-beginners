<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:20:51+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "th"
}
-->
# การใช้งานเซิร์ฟเวอร์จาก AI Toolkit extension สำหรับ Visual Studio Code

เมื่อคุณสร้างเอเย่นต์ AI ไม่ได้หมายความแค่การสร้างคำตอบที่ฉลาดเท่านั้น แต่ยังหมายถึงการมอบความสามารถให้เอเย่นต์ของคุณสามารถดำเนินการได้ด้วย นั่นคือที่มาของ Model Context Protocol (MCP) MCP ช่วยให้ง่ายต่อการเข้าถึงเครื่องมือและบริการภายนอกอย่างสม่ำเสมอ คิดซะว่าเหมือนกับการเสียบปลั๊กเอเย่นต์ของคุณเข้ากับกล่องเครื่องมือที่มัน *ใช้งานได้จริง*

สมมติว่าคุณเชื่อมต่อเอเย่นต์กับเซิร์ฟเวอร์ MCP เครื่องคิดเลข เอเย่นต์ของคุณก็จะสามารถทำการคำนวณได้ทันทีแค่รับคำถามเช่น “47 คูณ 89 เท่ากับเท่าไหร่?” โดยไม่ต้องเขียนโค้ดตรรกะหรือสร้าง API เอง

## ภาพรวม

บทเรียนนี้จะครอบคลุมวิธีการเชื่อมต่อเซิร์ฟเวอร์ MCP เครื่องคิดเลขกับเอเย่นต์โดยใช้ [AI Toolkit](https://aka.ms/AIToolkit) extension ใน Visual Studio Code เพื่อให้เอเย่นต์ของคุณสามารถทำการคำนวณ เช่น การบวก ลบ คูณ หาร ผ่านภาษาธรรมชาติ

AI Toolkit เป็น extension ที่ทรงพลังสำหรับ Visual Studio Code ที่ช่วยให้การพัฒนาเอเย่นต์เป็นเรื่องง่าย วิศวกร AI สามารถสร้างและทดสอบโมเดล generative AI ได้อย่างรวดเร็วทั้งในเครื่องและบนคลาวด์ Extension นี้รองรับโมเดล generative หลักๆ ที่มีในปัจจุบัน

*หมายเหตุ*: AI Toolkit รองรับ Python และ TypeScript ในขณะนี้

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ใช้งานเซิร์ฟเวอร์ MCP ผ่าน AI Toolkit
- กำหนดค่า agent configuration เพื่อให้สามารถค้นหาและใช้งานเครื่องมือที่เซิร์ฟเวอร์ MCP จัดหาให้
- ใช้เครื่องมือ MCP ผ่านภาษาธรรมชาติ

## วิธีการ

นี่คือขั้นตอนในภาพรวมที่เราต้องทำ:

- สร้างเอเย่นต์และกำหนด system prompt ของมัน
- สร้างเซิร์ฟเวอร์ MCP พร้อมเครื่องมือเครื่องคิดเลข
- เชื่อมต่อ Agent Builder กับเซิร์ฟเวอร์ MCP
- ทดสอบการเรียกใช้งานเครื่องมือของเอเย่นต์ผ่านภาษาธรรมชาติ

เยี่ยมมาก ตอนนี้ที่เราเข้าใจขั้นตอนแล้ว มาตั้งค่าเอเย่นต์ AI ให้ใช้เครื่องมือภายนอกผ่าน MCP เพื่อเพิ่มความสามารถกันเถอะ!

## สิ่งที่ต้องเตรียม

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## แบบฝึกหัด: การใช้งานเซิร์ฟเวอร์

ในแบบฝึกหัดนี้ คุณจะสร้าง รัน และปรับปรุงเอเย่นต์ AI ด้วยเครื่องมือจากเซิร์ฟเวอร์ MCP ภายใน Visual Studio Code โดยใช้ AI Toolkit

### -0- ขั้นตอนเตรียมตัว เพิ่มโมเดล OpenAI GPT-4o ลงใน My Models

แบบฝึกหัดนี้ใช้โมเดล **GPT-4o** โมเดลนี้ควรถูกเพิ่มใน **My Models** ก่อนสร้างเอเย่นต์

![Screenshot of a model selection interface in Visual Studio Code's AI Toolkit extension. The heading reads "Find the right model for your AI Solution" with a subtitle encouraging users to discover, test, and deploy AI models. Below, under “Popular Models,” six model cards are displayed: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), and DeepSeek-R1 (Ollama-hosted). Each card includes options to “Add” the model or “Try in Playground](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.th.png)

1. เปิด **AI Toolkit** extension จาก **Activity Bar**
2. ในส่วน **Catalog** เลือก **Models** เพื่อเปิด **Model Catalog** การเลือก **Models** จะเปิดแท็บ editor ใหม่สำหรับ **Model Catalog**
3. ในแถบค้นหา **Model Catalog** พิมพ์ **OpenAI GPT-4o**
4. คลิก **+ Add** เพื่อเพิ่มโมเดลนี้ในรายการ **My Models** ตรวจสอบให้แน่ใจว่าได้เลือกโมเดลที่ **Hosted by GitHub**
5. ใน **Activity Bar** ตรวจสอบว่าโมเดล **OpenAI GPT-4o** ปรากฏในรายการแล้ว

### -1- สร้างเอเย่นต์

**Agent (Prompt) Builder** ช่วยให้คุณสร้างและปรับแต่งเอเย่นต์ AI ของตัวเองได้ ในส่วนนี้คุณจะสร้างเอเย่นต์ใหม่และกำหนดโมเดลเพื่อขับเคลื่อนการสนทนา

![Screenshot of the "Calculator Agent" builder interface in the AI Toolkit extension for Visual Studio Code. On the left panel, the model selected is "OpenAI GPT-4o (via GitHub)." A system prompt reads "You are a professor in university teaching math," and the user prompt says, "Explain to me the Fourier equation in simple terms." Additional options include buttons for adding tools, enabling MCP Server, and selecting structured output. A blue “Run” button is at the bottom. On the right panel, under "Get Started with Examples," three sample agents are listed: Web Developer (with MCP Server, Second-Grade Simplifier, and Dream Interpreter, each with brief descriptions of their functions.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.th.png)

1. เปิด **AI Toolkit** extension จาก **Activity Bar**
2. ในส่วน **Tools** เลือก **Agent (Prompt) Builder** การเลือกนี้จะเปิดแท็บ editor ใหม่สำหรับ **Agent (Prompt) Builder**
3. คลิกปุ่ม **+ New Agent** ระบบจะเปิดตัวช่วยตั้งค่าผ่าน **Command Palette**
4. กรอกชื่อ **Calculator Agent** แล้วกด **Enter**
5. ใน **Agent (Prompt) Builder** ที่ช่อง **Model** เลือกโมเดล **OpenAI GPT-4o (via GitHub)**

### -2- สร้าง system prompt สำหรับเอเย่นต์

เมื่อเอเย่นต์ถูกสร้างขึ้นแล้ว ถึงเวลากำหนดบุคลิกและวัตถุประสงค์ ในส่วนนี้คุณจะใช้ฟีเจอร์ **Generate system prompt** เพื่อบอกพฤติกรรมที่ต้องการของเอเย่นต์ ในกรณีนี้คือเอเย่นต์เครื่องคิดเลข และให้โมเดลเขียน system prompt ให้คุณ

![Screenshot of the "Calculator Agent" interface in the AI Toolkit for Visual Studio Code with a modal window open titled "Generate a prompt." The modal explains that a prompt template can be generated by sharing basic details and includes a text box with the sample system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Below the text box are "Close" and "Generate" buttons. In the background, part of the agent configuration is visible, including the selected model "OpenAI GPT-4o (via GitHub)" and fields for system and user prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.th.png)

1. ในส่วน **Prompts** คลิกปุ่ม **Generate system prompt** ปุ่มนี้จะเปิดตัวช่วยสร้าง prompt ที่ใช้ AI สร้าง system prompt ให้เอเย่นต์
2. ในหน้าต่าง **Generate a prompt** ให้กรอกข้อความดังนี้: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. คลิกปุ่ม **Generate** จะมีการแจ้งเตือนที่มุมล่างขวาเพื่อยืนยันว่ากำลังสร้าง system prompt เมื่อสร้างเสร็จ prompt จะปรากฏในช่อง **System prompt** ของ **Agent (Prompt) Builder**
4. ตรวจสอบและแก้ไข **System prompt** ตามต้องการ

### -3- สร้างเซิร์ฟเวอร์ MCP

ตอนนี้ที่คุณได้กำหนด system prompt ของเอเย่นต์แล้ว ซึ่งเป็นการชี้นำพฤติกรรมและการตอบสนอง ถึงเวลามอบความสามารถที่ใช้งานได้จริง ในส่วนนี้คุณจะสร้างเซิร์ฟเวอร์ MCP เครื่องคิดเลขที่มีเครื่องมือสำหรับการบวก ลบ คูณ หาร เซิร์ฟเวอร์นี้จะช่วยให้เอเย่นต์ของคุณทำการคำนวณแบบเรียลไทม์ตอบกลับคำถามภาษาธรรมชาติได้

!["Screenshot of the lower section of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. It shows expandable menus for “Tools” and “Structure output,” along with a dropdown menu labeled “Choose output format” set to “text.” To the right, there is a button labeled “+ MCP Server” for adding a Model Context Protocol server. An image icon placeholder is shown above the Tools section.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.th.png)

AI Toolkit มีเทมเพลตช่วยให้สร้างเซิร์ฟเวอร์ MCP ได้ง่าย เราจะใช้เทมเพลต Python เพื่อสร้างเซิร์ฟเวอร์ MCP เครื่องคิดเลข

*หมายเหตุ*: AI Toolkit รองรับ Python และ TypeScript ในขณะนี้

1. ในส่วน **Tools** ของ **Agent (Prompt) Builder** คลิกปุ่ม **+ MCP Server** ระบบจะเปิดตัวช่วยตั้งค่าผ่าน **Command Palette**
2. เลือก **+ Add Server**
3. เลือก **Create a New MCP Server**
4. เลือกเทมเพลต **python-weather**
5. เลือก **Default folder** เพื่อบันทึกเทมเพลตเซิร์ฟเวอร์ MCP
6. กรอกชื่อเซิร์ฟเวอร์ว่า **Calculator**
7. จะเปิดหน้าต่าง Visual Studio Code ใหม่ เลือก **Yes, I trust the authors**
8. ใช้เทอร์มินัล (**Terminal** > **New Terminal**) สร้าง virtual environment: `python -m venv .venv`
9. ใช้เทอร์มินัล เปิดใช้งาน virtual environment:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. ใช้เทอร์มินัล ติดตั้ง dependencies: `pip install -e .[dev]`
11. ในมุมมอง **Explorer** ของ **Activity Bar** ขยายโฟลเดอร์ **src** และเลือกไฟล์ **server.py** เพื่อเปิดใน editor
12. แทนที่โค้ดในไฟล์ **server.py** ด้วยโค้ดนี้แล้วบันทึก:

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

### -4- รันเอเย่นต์กับเซิร์ฟเวอร์ MCP เครื่องคิดเลข

ตอนนี้เอเย่นต์ของคุณมีเครื่องมือแล้ว ถึงเวลานำไปใช้งาน ในส่วนนี้คุณจะส่ง prompt ไปยังเอเย่นต์เพื่อทดสอบว่าเอเย่นต์เรียกใช้เครื่องมือจากเซิร์ฟเวอร์ MCP เครื่องคิดเลขอย่างถูกต้องหรือไม่

![Screenshot of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. On the left panel, under “Tools,” an MCP server named local-server-calculator_server is added, showing four available tools: add, subtract, multiply, and divide. A badge shows that four tools are active. Below is a collapsed “Structure output” section and a blue “Run” button. On the right panel, under “Model Response,” the agent invokes the multiply and subtract tools with inputs {"a": 3, "b": 25} and {"a": 75, "b": 20} respectively. The final “Tool Response” is shown as 75.0. A “View Code” button appears at the bottom.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.th.png)

คุณจะรันเซิร์ฟเวอร์ MCP เครื่องคิดเลขบนเครื่องพัฒนาของคุณโดยใช้ **Agent Builder** ในฐานะ MCP client

1. กด `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` ค่าต่างๆ ถูกกำหนดให้กับเครื่องมือ **subtract**
    - คำตอบจากแต่ละเครื่องมือจะแสดงในส่วน **Tool Response**
    - ผลลัพธ์สุดท้ายจากโมเดลจะแสดงในส่วน **Model Response**
2. ส่ง prompt เพิ่มเติมเพื่อทดสอบเอเย่นต์ต่อไป คุณสามารถแก้ไข prompt เดิมในช่อง **User prompt** โดยคลิกและแทนที่ข้อความได้
3. เมื่อทดสอบเสร็จแล้ว คุณสามารถหยุดเซิร์ฟเวอร์ได้โดยใช้คำสั่ง **CTRL/CMD+C** ในเทอร์มินัล

## การบ้าน

ลองเพิ่มเครื่องมือใหม่ในไฟล์ **server.py** ของคุณ (เช่น คืนค่ารากที่สองของตัวเลข) ส่ง prompt เพิ่มเติมที่ต้องการให้เอเย่นต์ใช้เครื่องมือใหม่ (หรือเครื่องมือเดิม) อย่าลืมรีสตาร์ทเซิร์ฟเวอร์เพื่อโหลดเครื่องมือที่เพิ่มใหม่

## ตัวอย่างคำตอบ

[Solution](./solution/README.md)

## ข้อคิดสำคัญ

ข้อคิดที่ได้จากบทนี้คือ:

- AI Toolkit เป็นไคลเอนต์ที่ยอดเยี่ยมสำหรับใช้งาน MCP Servers และเครื่องมือของพวกเขา
- คุณสามารถเพิ่มเครื่องมือใหม่ให้กับ MCP servers เพื่อขยายความสามารถของเอเย่นต์ให้ตอบโจทย์ความต้องการที่เปลี่ยนแปลงได้
- AI Toolkit มีเทมเพลต (เช่น เทมเพลตเซิร์ฟเวอร์ MCP Python) เพื่อช่วยให้การสร้างเครื่องมือแบบกำหนดเองง่ายขึ้น

## แหล่งข้อมูลเพิ่มเติม

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## ต่อไปคืออะไร
- ต่อไป: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารฉบับนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใด ๆ ที่เกิดจากการใช้การแปลนี้