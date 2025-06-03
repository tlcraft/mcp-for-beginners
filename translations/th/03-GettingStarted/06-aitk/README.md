<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:39:34+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "th"
}
-->
# การใช้งานเซิร์ฟเวอร์จาก AI Toolkit extension สำหรับ Visual Studio Code

เมื่อคุณกำลังสร้างเอเจนต์ AI ไม่ใช่แค่การสร้างคำตอบที่ชาญฉลาดเท่านั้น แต่ยังรวมถึงการให้เอเจนต์ของคุณสามารถทำงานได้จริง นั่นคือที่มาของ Model Context Protocol (MCP) MCP ช่วยให้เอเจนต์เข้าถึงเครื่องมือและบริการภายนอกได้อย่างสม่ำเสมอ เปรียบเสมือนการเสียบเอเจนต์ของคุณเข้ากับกล่องเครื่องมือที่มัน *สามารถ* ใช้งานได้จริง

สมมติว่าคุณเชื่อมต่อเอเจนต์กับเซิร์ฟเวอร์ MCP เครื่องคิดเลข ทันใดนั้นเอเจนต์ของคุณก็สามารถทำการคำนวณได้โดยแค่รับคำถามอย่าง “47 คูณ 89 เท่ากับเท่าไหร่?” — ไม่จำเป็นต้องเขียนโค้ดลอจิกเองหรือสร้าง API แบบกำหนดเอง

## ภาพรวม

บทเรียนนี้ครอบคลุมวิธีการเชื่อมต่อเซิร์ฟเวอร์ MCP เครื่องคิดเลขกับเอเจนต์โดยใช้ [AI Toolkit](https://aka.ms/AIToolkit) extension ใน Visual Studio Code เพื่อให้เอเจนต์ของคุณสามารถทำการคำนวณเช่น บวก ลบ คูณ หาร ผ่านภาษาธรรมชาติได้

AI Toolkit เป็น extension ที่ทรงพลังสำหรับ Visual Studio Code ที่ช่วยให้นักพัฒนา AI สร้างแอปพลิเคชัน AI ได้อย่างรวดเร็วและง่ายดาย โดยการพัฒนาและทดสอบโมเดล AI สร้างสรรค์—ทั้งแบบโลคัลและบนคลาวด์ extension นี้รองรับโมเดลสร้างสรรค์หลักๆ ที่มีอยู่ในปัจจุบัน

*หมายเหตุ*: AI Toolkit รองรับ Python และ TypeScript ในตอนนี้

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ใช้งานเซิร์ฟเวอร์ MCP ผ่าน AI Toolkit
- ตั้งค่า agent configuration เพื่อให้เอเจนต์ค้นหาและใช้งานเครื่องมือที่เซิร์ฟเวอร์ MCP จัดให้
- ใช้เครื่องมือ MCP ผ่านภาษาธรรมชาติ

## วิธีการ

นี่คือวิธีการที่เราจะดำเนินการในระดับสูง:

- สร้างเอเจนต์และกำหนด system prompt ของมัน
- สร้างเซิร์ฟเวอร์ MCP พร้อมเครื่องคิดเลข
- เชื่อมต่อ Agent Builder กับเซิร์ฟเวอร์ MCP
- ทดสอบการเรียกใช้เครื่องมือของเอเจนต์ผ่านภาษาธรรมชาติ

เยี่ยมเลย ตอนนี้ที่เราเข้าใจกระบวนการแล้ว มาเริ่มตั้งค่าเอเจนต์ AI เพื่อใช้เครื่องมือภายนอกผ่าน MCP เพื่อเพิ่มความสามารถของมันกัน!

## สิ่งที่ต้องมี

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## แบบฝึกหัด: การใช้งานเซิร์ฟเวอร์

ในแบบฝึกหัดนี้ คุณจะสร้าง รัน และปรับปรุงเอเจนต์ AI ด้วยเครื่องมือจากเซิร์ฟเวอร์ MCP ภายใน Visual Studio Code โดยใช้ AI Toolkit

### -0- ขั้นตอนเตรียม เพิ่มโมเดล OpenAI GPT-4o ไปยัง My Models

แบบฝึกหัดนี้ใช้โมเดล **GPT-4o** โมเดลนี้ควรถูกเพิ่มเข้าไปใน **My Models** ก่อนสร้างเอเจนต์

![Screenshot of a model selection interface in Visual Studio Code's AI Toolkit extension. The heading reads "Find the right model for your AI Solution" with a subtitle encouraging users to discover, test, and deploy AI models. Below, under “Popular Models,” six model cards are displayed: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), and DeepSeek-R1 (Ollama-hosted). Each card includes options to “Add” the model or “Try in Playground](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.th.png)

1. เปิด **AI Toolkit** extension จาก **Activity Bar**
2. ในส่วน **Catalog** เลือก **Models** เพื่อเปิด **Model Catalog** การเลือก **Models** จะเปิดแท็บ editor ใหม่
3. ในแถบค้นหาของ **Model Catalog** พิมพ์ **OpenAI GPT-4o**
4. คลิก **+ Add** เพื่อเพิ่มโมเดลนี้ไปยังรายการ **My Models** ให้แน่ใจว่าเลือกโมเดลที่ **Hosted by GitHub**
5. ใน **Activity Bar** ตรวจสอบว่าโมเดล **OpenAI GPT-4o** ปรากฏในรายการแล้ว

### -1- สร้างเอเจนต์

**Agent (Prompt) Builder** ช่วยให้คุณสร้างและปรับแต่งเอเจนต์ AI ของคุณเองได้ ในส่วนนี้ คุณจะสร้างเอเจนต์ใหม่และกำหนดโมเดลเพื่อขับเคลื่อนการสนทนา

![Screenshot of the "Calculator Agent" builder interface in the AI Toolkit extension for Visual Studio Code. On the left panel, the model selected is "OpenAI GPT-4o (via GitHub)." A system prompt reads "You are a professor in university teaching math," and the user prompt says, "Explain to me the Fourier equation in simple terms." Additional options include buttons for adding tools, enabling MCP Server, and selecting structured output. A blue “Run” button is at the bottom. On the right panel, under "Get Started with Examples," three sample agents are listed: Web Developer (with MCP Server, Second-Grade Simplifier, and Dream Interpreter, each with brief descriptions of their functions.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.th.png)

1. เปิด **AI Toolkit** extension จาก **Activity Bar**
2. ในส่วน **Tools** เลือก **Agent (Prompt) Builder** การเลือกนี้จะเปิดแท็บ editor ใหม่
3. คลิกปุ่ม **+ New Agent** ระบบจะเปิด wizard ตั้งค่าผ่าน **Command Palette**
4. ใส่ชื่อ **Calculator Agent** แล้วกด **Enter**
5. ใน **Agent (Prompt) Builder** ที่ช่อง **Model** เลือกโมเดล **OpenAI GPT-4o (via GitHub)**

### -2- สร้าง system prompt สำหรับเอเจนต์

เมื่อสร้างโครงสร้างเอเจนต์แล้ว ถึงเวลากำหนดบุคลิกและวัตถุประสงค์ ในส่วนนี้ คุณจะใช้ฟีเจอร์ **Generate system prompt** เพื่อบรรยายพฤติกรรมที่ต้องการของเอเจนต์—ในกรณีนี้คือเอเจนต์เครื่องคิดเลข—และให้โมเดลเขียน system prompt ให้คุณ

![Screenshot of the "Calculator Agent" interface in the AI Toolkit for Visual Studio Code with a modal window open titled "Generate a prompt." The modal explains that a prompt template can be generated by sharing basic details and includes a text box with the sample system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Below the text box are "Close" and "Generate" buttons. In the background, part of the agent configuration is visible, including the selected model "OpenAI GPT-4o (via GitHub)" and fields for system and user prompts.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.th.png)

1. ในส่วน **Prompts** คลิกปุ่ม **Generate system prompt** ซึ่งจะเปิดตัวสร้าง prompt ที่ใช้ AI ช่วยสร้าง system prompt สำหรับเอเจนต์
2. ในหน้าต่าง **Generate a prompt** ให้ใส่ข้อความต่อไปนี้: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. คลิกปุ่ม **Generate** จะมีการแจ้งเตือนที่มุมล่างขวาว่ากำลังสร้าง system prompt เมื่อเสร็จแล้ว prompt จะปรากฏในช่อง **System prompt** ของ **Agent (Prompt) Builder**
4. ตรวจสอบ **System prompt** และแก้ไขถ้าจำเป็น

### -3- สร้างเซิร์ฟเวอร์ MCP

ตอนนี้ที่คุณกำหนด system prompt ให้เอเจนต์แล้ว เพื่อชี้นำพฤติกรรมและการตอบสนอง ถึงเวลาติดตั้งความสามารถจริงให้เอเจนต์ ในส่วนนี้ คุณจะสร้างเซิร์ฟเวอร์ MCP เครื่องคิดเลขที่มีเครื่องมือสำหรับบวก ลบ คูณ และ หาร เพื่อให้เอเจนต์สามารถคำนวณแบบเรียลไทม์เมื่อได้รับคำถามเป็นภาษาธรรมชาติ

!["Screenshot of the lower section of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. It shows expandable menus for “Tools” and “Structure output,” along with a dropdown menu labeled “Choose output format” set to “text.” To the right, there is a button labeled “+ MCP Server” for adding a Model Context Protocol server. An image icon placeholder is shown above the Tools section.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.th.png)

AI Toolkit มาพร้อมกับเทมเพลตที่ช่วยให้สร้างเซิร์ฟเวอร์ MCP ได้ง่าย เราจะใช้เทมเพลต Python สำหรับสร้างเซิร์ฟเวอร์ MCP เครื่องคิดเลขนี้

*หมายเหตุ*: AI Toolkit รองรับ Python และ TypeScript ในตอนนี้

1. ในส่วน **Tools** ของ **Agent (Prompt) Builder** คลิกปุ่ม **+ MCP Server** ระบบจะเปิด wizard ตั้งค่าผ่าน **Command Palette**
2. เลือก **+ Add Server**
3. เลือก **Create a New MCP Server**
4. เลือกเทมเพลต **python-weather**
5. เลือก **Default folder** เพื่อบันทึกเทมเพลตเซิร์ฟเวอร์ MCP
6. ตั้งชื่อเซิร์ฟเวอร์เป็น **Calculator**
7. หน้าต่าง Visual Studio Code ใหม่จะเปิดขึ้น เลือก **Yes, I trust the authors**
8. ใช้ terminal (**Terminal** > **New Terminal**) สร้าง virtual environment: `python -m venv .venv`
9. ใช้ terminal เปิดใช้งาน virtual environment:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. ใช้ terminal ติดตั้ง dependencies: `pip install -e .[dev]`
11. ในมุมมอง **Explorer** ของ **Activity Bar** ขยายโฟลเดอร์ **src** และเลือก **server.py** เพื่อเปิดไฟล์ใน editor
12. แทนที่โค้ดในไฟล์ **server.py** ด้วยโค้ดต่อไปนี้แล้วบันทึก:

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

### -4- รันเอเจนต์กับเซิร์ฟเวอร์ MCP เครื่องคิดเลข

ตอนนี้ที่เอเจนต์ของคุณมีเครื่องมือแล้ว ถึงเวลานำไปใช้! ในส่วนนี้ คุณจะส่งคำถามไปยังเอเจนต์เพื่อทดสอบและตรวจสอบว่าเอเจนต์เรียกใช้เครื่องมือที่ถูกต้องจากเซิร์ฟเวอร์ MCP เครื่องคิดเลขหรือไม่

![Screenshot of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. On the left panel, under “Tools,” an MCP server named local-server-calculator_server is added, showing four available tools: add, subtract, multiply, and divide. A badge shows that four tools are active. Below is a collapsed “Structure output” section and a blue “Run” button. On the right panel, under “Model Response,” the agent invokes the multiply and subtract tools with inputs {"a": 3, "b": 25} and {"a": 75, "b": 20} respectively. The final “Tool Response” is shown as 75.0. A “View Code” button appears at the bottom.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.th.png)

คุณจะรันเซิร์ฟเวอร์ MCP เครื่องคิดเลขบนเครื่องพัฒนาของคุณในฐานะลูกค้า MCP ผ่าน **Agent Builder**

1. กด `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` ค่าถูกกำหนดให้กับเครื่องมือ **subtract**
    - คำตอบจากแต่ละเครื่องมือจะแสดงในส่วน **Tool Response**
    - ผลลัพธ์สุดท้ายจากโมเดลจะแสดงในส่วน **Model Response**
2. ส่งคำถามเพิ่มเติมเพื่อทดสอบเอเจนต์ คุณสามารถแก้ไขคำถามในช่อง **User prompt** โดยคลิกและแทนที่คำถามเดิม
3. เมื่อทดสอบเสร็จแล้ว คุณสามารถหยุดเซิร์ฟเวอร์ได้โดยกด **CTRL/CMD+C** ใน terminal เพื่อออก

## การบ้าน

ลองเพิ่มเครื่องมือใหม่ในไฟล์ **server.py** ของคุณ (เช่น ฟังก์ชันหาค่ารากที่สองของตัวเลข) ส่งคำถามเพิ่มเติมที่ต้องใช้เครื่องมือใหม่ (หรือเครื่องมือเดิม) เพื่อให้เอเจนต์ใช้งาน อย่าลืมรีสตาร์ทเซิร์ฟเวอร์เพื่อโหลดเครื่องมือที่เพิ่มเข้ามาใหม่

## แนวทางแก้ไข

[Solution](./solution/README.md)

## ข้อสรุปสำคัญ

ข้อสรุปจากบทนี้คือ:

- AI Toolkit เป็น client ที่ยอดเยี่ยมที่ช่วยให้คุณใช้งาน MCP Servers และเครื่องมือของพวกเขาได้
- คุณสามารถเพิ่มเครื่องมือใหม่ให้กับเซิร์ฟเวอร์ MCP เพื่อขยายความสามารถของเอเจนต์ให้ตอบโจทย์ความต้องการที่เปลี่ยนแปลงได้
- AI Toolkit มีเทมเพลต (เช่น เทมเพลตเซิร์ฟเวอร์ MCP Python) ที่ช่วยให้ง่ายต่อการสร้างเครื่องมือแบบกำหนดเอง

## แหล่งข้อมูลเพิ่มเติม

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## ต่อไป

ถัดไป: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้มีความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลโดยอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำ เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่น่าเชื่อถือที่สุด สำหรับข้อมูลที่มีความสำคัญ ขอแนะนำให้ใช้บริการแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดใด ๆ ที่เกิดขึ้นจากการใช้การแปลนี้