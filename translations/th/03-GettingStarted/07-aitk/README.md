<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:34:29+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "th"
}
-->
# การใช้งานเซิร์ฟเวอร์จากส่วนขยาย AI Toolkit สำหรับ Visual Studio Code

เมื่อคุณกำลังสร้างเอเจนต์ AI ไม่ใช่แค่การสร้างคำตอบที่ชาญฉลาดเท่านั้น แต่ยังรวมถึงการให้เอเจนต์ของคุณสามารถดำเนินการบางอย่างได้ด้วย นั่นคือจุดที่ Model Context Protocol (MCP) เข้ามามีบทบาท MCP ช่วยให้เอเจนต์เข้าถึงเครื่องมือและบริการภายนอกได้อย่างสม่ำเสมอ คิดซะว่าเหมือนการเสียบเอเจนต์ของคุณเข้ากับกล่องเครื่องมือที่มัน *สามารถ* ใช้งานได้จริง

สมมติว่าคุณเชื่อมต่อเอเจนต์กับเซิร์ฟเวอร์ MCP เครื่องคิดเลข ทันใดนั้นเอเจนต์ของคุณก็สามารถทำการคำนวณทางคณิตศาสตร์ได้เพียงแค่รับคำสั่งเช่น “47 คูณ 89 เท่ากับเท่าไหร่?” — โดยไม่ต้องเขียนตรรกะแบบตายตัวหรือสร้าง API แบบกำหนดเอง

## ภาพรวม

บทเรียนนี้จะสอนวิธีเชื่อมต่อเซิร์ฟเวอร์ MCP เครื่องคิดเลขกับเอเจนต์โดยใช้ส่วนขยาย [AI Toolkit](https://aka.ms/AIToolkit) ใน Visual Studio Code เพื่อให้เอเจนต์ของคุณสามารถทำการคำนวณ เช่น การบวก ลบ คูณ และหาร ผ่านภาษาธรรมชาติได้

AI Toolkit เป็นส่วนขยายที่ทรงพลังสำหรับ Visual Studio Code ที่ช่วยให้นักพัฒนา AI สร้างแอปพลิเคชัน AI ได้อย่างรวดเร็วและง่ายดาย โดยสามารถพัฒนาและทดสอบโมเดล AI สร้างสรรค์ได้ทั้งในเครื่องและบนคลาวด์ ส่วนขยายนี้รองรับโมเดลสร้างสรรค์หลักๆ ที่มีอยู่ในปัจจุบัน

*หมายเหตุ*: AI Toolkit รองรับภาษา Python และ TypeScript ในขณะนี้

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ใช้งานเซิร์ฟเวอร์ MCP ผ่าน AI Toolkit
- กำหนดค่าเอเจนต์เพื่อให้ค้นหาและใช้เครื่องมือที่เซิร์ฟเวอร์ MCP ให้มาได้
- ใช้เครื่องมือ MCP ผ่านภาษาธรรมชาติ

## แนวทาง

นี่คือภาพรวมขั้นตอนที่เราจะทำ:

- สร้างเอเจนต์และกำหนด system prompt
- สร้างเซิร์ฟเวอร์ MCP ที่มีเครื่องมือเครื่องคิดเลข
- เชื่อมต่อ Agent Builder กับเซิร์ฟเวอร์ MCP
- ทดสอบการเรียกใช้เครื่องมือของเอเจนต์ผ่านภาษาธรรมชาติ

เยี่ยมเลย ตอนนี้ที่เราเข้าใจภาพรวมแล้ว มาตั้งค่าเอเจนต์ AI เพื่อใช้เครื่องมือภายนอกผ่าน MCP เพื่อเพิ่มขีดความสามารถกัน!

## สิ่งที่ต้องเตรียม

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit สำหรับ Visual Studio Code](https://aka.ms/AIToolkit)

## แบบฝึกหัด: การใช้งานเซิร์ฟเวอร์

ในแบบฝึกหัดนี้ คุณจะสร้าง รัน และพัฒนาเอเจนต์ AI ที่มีเครื่องมือจากเซิร์ฟเวอร์ MCP ภายใน Visual Studio Code โดยใช้ AI Toolkit

### -0- ขั้นตอนเตรียม เพิ่มโมเดล OpenAI GPT-4o ไปยัง My Models

แบบฝึกหัดนี้ใช้โมเดล **GPT-4o** โมเดลนี้ควรถูกเพิ่มเข้าไปใน **My Models** ก่อนสร้างเอเจนต์

![ภาพหน้าจออินเทอร์เฟซการเลือกโมเดลในส่วนขยาย AI Toolkit ของ Visual Studio Code หัวข้อเขียนว่า "Find the right model for your AI Solution" พร้อมคำอธิบายให้ค้นหา ทดสอบ และใช้งานโมเดล AI ด้านล่างในส่วน “Popular Models” มีการ์ดโมเดล 6 ตัว: DeepSeek-R1 (โฮสต์บน GitHub), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - เล็ก, เร็ว), และ DeepSeek-R1 (โฮสต์บน Ollama) แต่ละการ์ดมีตัวเลือก “Add” หรือ “Try in Playground”](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.th.png)

1. เปิดส่วนขยาย **AI Toolkit** จาก **Activity Bar**
2. ในส่วน **Catalog** เลือก **Models** เพื่อเปิด **Model Catalog** การเลือก **Models** จะเปิดแท็บใหม่ในตัวแก้ไข
3. ในแถบค้นหา **Model Catalog** ให้พิมพ์ **OpenAI GPT-4o**
4. คลิก **+ Add** เพื่อเพิ่มโมเดลไปยังรายการ **My Models** ให้แน่ใจว่าเลือกโมเดลที่ **Hosted by GitHub**
5. ใน **Activity Bar** ตรวจสอบว่าโมเดล **OpenAI GPT-4o** ปรากฏในรายการแล้ว

### -1- สร้างเอเจนต์

**Agent (Prompt) Builder** ช่วยให้คุณสร้างและปรับแต่งเอเจนต์ AI ของคุณเอง ในส่วนนี้ คุณจะสร้างเอเจนต์ใหม่และกำหนดโมเดลเพื่อขับเคลื่อนการสนทนา

![ภาพหน้าจออินเทอร์เฟซ "Calculator Agent" ในส่วนขยาย AI Toolkit ของ Visual Studio Code แผงซ้ายเลือกโมเดล "OpenAI GPT-4o (via GitHub)" มี system prompt ว่า "You are a professor in university teaching math" และ user prompt ว่า "Explain to me the Fourier equation in simple terms." มีปุ่มเพิ่มเครื่องมือ เปิดใช้งาน MCP Server และเลือก structured output ปุ่ม “Run” สีฟ้าอยู่ด้านล่าง แผงขวาแสดงตัวอย่างเอเจนต์สามตัว: Web Developer (มี MCP Server, Second-Grade Simplifier, และ Dream Interpreter พร้อมคำอธิบายสั้นๆ)](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.th.png)

1. เปิดส่วนขยาย **AI Toolkit** จาก **Activity Bar**
2. ในส่วน **Tools** เลือก **Agent (Prompt) Builder** การเลือกนี้จะเปิดแท็บใหม่ในตัวแก้ไข
3. คลิกปุ่ม **+ New Agent** ส่วนขยายจะเปิดตัวช่วยตั้งค่าผ่าน **Command Palette**
4. กรอกชื่อ **Calculator Agent** แล้วกด **Enter**
5. ใน **Agent (Prompt) Builder** สำหรับช่อง **Model** ให้เลือกโมเดล **OpenAI GPT-4o (via GitHub)**

### -2- สร้าง system prompt สำหรับเอเจนต์

เมื่อสร้างโครงร่างเอเจนต์แล้ว ถึงเวลากำหนดบุคลิกและวัตถุประสงค์ ในส่วนนี้ คุณจะใช้ฟีเจอร์ **Generate system prompt** เพื่ออธิบายพฤติกรรมที่ต้องการของเอเจนต์ ในกรณีนี้คือเอเจนต์เครื่องคิดเลข และให้โมเดลเขียน system prompt ให้คุณ

![ภาพหน้าจออินเทอร์เฟซ "Calculator Agent" ใน AI Toolkit ของ Visual Studio Code มีหน้าต่างโมดัลชื่อ "Generate a prompt" อธิบายว่าสามารถสร้าง prompt template โดยการกรอกรายละเอียดพื้นฐาน มีช่องข้อความตัวอย่าง system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." ด้านล่างมีปุ่ม "Close" และ "Generate" พื้นหลังเห็นการตั้งค่าเอเจนต์ รวมถึงโมเดลที่เลือก "OpenAI GPT-4o (via GitHub)" และช่อง system กับ user prompt](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.th.png)

1. ในส่วน **Prompts** คลิกปุ่ม **Generate system prompt** ปุ่มนี้จะเปิดตัวสร้าง prompt ที่ใช้ AI สร้าง system prompt ให้เอเจนต์
2. ในหน้าต่าง **Generate a prompt** ให้กรอกข้อความนี้: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. คลิกปุ่ม **Generate** จะมีการแจ้งเตือนที่มุมล่างขวายืนยันว่ากำลังสร้าง system prompt เมื่อเสร็จแล้ว prompt จะปรากฏในช่อง **System prompt** ของ **Agent (Prompt) Builder**
4. ตรวจสอบ **System prompt** และแก้ไขถ้าจำเป็น

### -3- สร้างเซิร์ฟเวอร์ MCP

เมื่อคุณกำหนด system prompt ของเอเจนต์แล้ว ซึ่งเป็นการกำหนดพฤติกรรมและการตอบสนอง ถึงเวลาติดตั้งความสามารถจริงให้เอเจนต์ ในส่วนนี้ คุณจะสร้างเซิร์ฟเวอร์ MCP เครื่องคิดเลขที่มีเครื่องมือสำหรับบวก ลบ คูณ และหาร เซิร์ฟเวอร์นี้จะช่วยให้เอเจนต์ทำการคำนวณแบบเรียลไทม์ตามคำสั่งภาษาธรรมชาติ

![ภาพหน้าจอส่วนล่างของอินเทอร์เฟซ Calculator Agent ใน AI Toolkit ของ Visual Studio Code แสดงเมนูขยาย “Tools” และ “Structure output” พร้อมเมนูแบบเลื่อนลง “Choose output format” ตั้งค่าเป็น “text” ด้านขวาเป็นปุ่ม “+ MCP Server” สำหรับเพิ่มเซิร์ฟเวอร์ Model Context Protocol มีไอคอนรูปภาพแสดงเหนือส่วน Tools](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.th.png)

AI Toolkit มีเทมเพลตช่วยให้สร้างเซิร์ฟเวอร์ MCP ได้ง่าย เราจะใช้เทมเพลต Python สำหรับสร้างเซิร์ฟเวอร์ MCP เครื่องคิดเลข

*หมายเหตุ*: AI Toolkit รองรับ Python และ TypeScript ในขณะนี้

1. ในส่วน **Tools** ของ **Agent (Prompt) Builder** คลิกปุ่ม **+ MCP Server** ส่วนขยายจะเปิดตัวช่วยตั้งค่าผ่าน **Command Palette**
2. เลือก **+ Add Server**
3. เลือก **Create a New MCP Server**
4. เลือกเทมเพลต **python-weather**
5. เลือก **Default folder** เพื่อบันทึกเทมเพลตเซิร์ฟเวอร์ MCP
6. กรอกชื่อเซิร์ฟเวอร์ว่า **Calculator**
7. หน้าต่าง Visual Studio Code ใหม่จะเปิดขึ้น เลือก **Yes, I trust the authors**
8. ใช้เทอร์มินัล (**Terminal** > **New Terminal**) สร้าง virtual environment: `python -m venv .venv`
9. ใช้เทอร์มินัล เปิดใช้งาน virtual environment:
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. ใช้เทอร์มินัล ติดตั้ง dependencies: `pip install -e .[dev]`
11. ในมุมมอง **Explorer** ของ **Activity Bar** ขยายโฟลเดอร์ **src** แล้วเลือกไฟล์ **server.py** เพื่อเปิดในตัวแก้ไข
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

เมื่อเอเจนต์ของคุณมีเครื่องมือแล้ว ถึงเวลานำไปใช้! ในส่วนนี้ คุณจะส่งคำสั่งไปยังเอเจนต์เพื่อตรวจสอบว่าเอเจนต์ใช้เครื่องมือจากเซิร์ฟเวอร์ MCP เครื่องคิดเลขได้ถูกต้องหรือไม่

![ภาพหน้าจออินเทอร์เฟซ Calculator Agent ใน AI Toolkit ของ Visual Studio Code แผงซ้ายใต้ “Tools” มีเซิร์ฟเวอร์ MCP ชื่อ local-server-calculator_server พร้อมเครื่องมือสี่ตัว: add, subtract, multiply, และ divide มีสัญลักษณ์แสดงว่าเครื่องมือสี่ตัวเปิดใช้งาน ด้านล่างเป็นส่วน “Structure output” ที่พับเก็บ และปุ่ม “Run” สีฟ้า แผงขวาใต้ “Model Response” เอเจนต์เรียกใช้เครื่องมือ multiply และ subtract โดยมีอินพุต {"a": 3, "b": 25} และ {"a": 75, "b": 20} ตามลำดับ ผลลัพธ์สุดท้าย “Tool Response” คือ 75.0 มีปุ่ม “View Code” อยู่ด้านล่าง](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.th.png)

คุณจะรันเซิร์ฟเวอร์ MCP เครื่องคิดเลขบนเครื่องพัฒนาของคุณผ่าน **Agent Builder** ในฐานะไคลเอนต์ MCP

1. กด `F5` เพื่อเริ่มดีบักเซิร์ฟเวอร์ MCP **Agent (Prompt) Builder** จะเปิดแท็บใหม่ในตัวแก้ไข สถานะเซิร์ฟเวอร์จะแสดงในเทอร์มินัล
2. ในช่อง **User prompt** ของ **Agent (Prompt) Builder** ให้กรอกคำสั่งนี้: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. คลิกปุ่ม **Run** เพื่อให้เอเจนต์ตอบกลับ
4. ตรวจสอบผลลัพธ์ของเอเจนต์ โมเดลควรสรุปว่าคุณจ่ายเงิน **$55**
5. นี่คือสิ่งที่จะเกิดขึ้น:
    - เอเจนต์เลือกใช้เครื่องมือ **multiply** และ **subtract** เพื่อช่วยคำนวณ
    - กำหนดค่า `a` และ `b` สำหรับเครื่องมือ **multiply**
    - กำหนดค่า `a` และ `b` สำหรับเครื่องมือ **subtract**
    - ผลลัพธ์จากแต่ละเครื่องมือจะแสดงใน **Tool Response**
    - ผลลัพธ์สุดท้ายจากโมเดลจะแสดงใน **Model Response**
6. ส่งคำสั่งเพิ่มเติมเพื่อทดสอบเอเจนต์ คุณสามารถแก้ไขคำสั่งในช่อง **User prompt** โดยคลิกและแทนที่ข้อความเดิม
7. เมื่อทดสอบเสร็จแล้ว คุณสามารถหยุดเซิร์ฟเวอร์ได้โดยกด **CTRL/CMD+C** ในเทอร์มินัล

## การบ้าน

ลองเพิ่มเครื่องมือใหม่ในไฟล์ **server.py** ของคุณ (เช่น คืนค่ารากที่สองของตัวเลข) ส่งคำสั่งเพิ่มเติมที่ต้องใช้เครื่องมือใหม่ (หรือเครื่องมือเดิม) ของเอเจนต์ อย่าลืมรีสตาร์ทเซิร์ฟเวอร์เพื่อโหลดเครื่องมือที่เพิ่มเข้ามา

## คำตอบ

[Solution](./solution/README.md)

## สรุปใจความสำคัญ

สิ่งที่ได้จากบทนี้คือ:

- ส่วนขยาย AI Toolkit เป็นไคลเอนต์ที่ยอดเยี่ยมที่ช่วยให้คุณใช้งานเซิร์ฟเวอร์ MCP และเครื่องมือของมันได้
- คุณสามารถเพิ่มเครื่องมือใหม่ให้กับเซิร์ฟเวอร์ MCP เพื่อขยายความสามารถของเอเจนต์ให้ตอบโจทย์ความต้องการที่เปลี่ยนแปลงได้
- AI Toolkit มีเทมเพลต (เช่น เทมเพลตเซิร์ฟเวอร์ MCP ภาษา Python) เพื่อช่วยให้สร้างเครื่องมือกำหนดเองได้ง่ายขึ้น

## แหล่งข้อมูลเพิ่มเติม

- [เอกสาร AI Toolkit](https://aka.ms/AIToolkit/doc)

## ต่อไปคือ
- ถัดไป: [การทดสอบและดีบัก](../08-testing/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้