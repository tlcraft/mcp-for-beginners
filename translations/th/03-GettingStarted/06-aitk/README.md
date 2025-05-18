<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:22:45+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "th"
}
-->
# การใช้งานเซิร์ฟเวอร์จากส่วนขยาย AI Toolkit สำหรับ Visual Studio Code

เมื่อคุณสร้างเอเจนต์ AI ไม่ใช่แค่เรื่องของการสร้างการตอบสนองที่ชาญฉลาด แต่ยังเกี่ยวกับการให้เอเจนต์ของคุณมีความสามารถในการดำเนินการด้วย นั่นคือที่มาของ Model Context Protocol (MCP) MCP ทำให้ง่ายต่อการเข้าถึงเครื่องมือและบริการภายนอกในลักษณะที่สม่ำเสมอ คิดว่ามันเหมือนการเชื่อมต่อเอเจนต์ของคุณเข้ากับกล่องเครื่องมือที่สามารถใช้งานได้จริง

สมมติว่าคุณเชื่อมต่อเอเจนต์กับเซิร์ฟเวอร์ MCP ของเครื่องคิดเลข ทันทีที่เอเจนต์ของคุณสามารถทำการคำนวณทางคณิตศาสตร์ได้เพียงแค่รับคำถามเช่น "47 คูณ 89 เท่าไหร่?"—ไม่จำเป็นต้องเขียนโค้ดลอจิกหรือสร้าง API เอง

## ภาพรวม

บทเรียนนี้ครอบคลุมวิธีการเชื่อมต่อเซิร์ฟเวอร์ MCP ของเครื่องคิดเลขกับเอเจนต์ด้วย [AI Toolkit](https://aka.ms/AIToolkit) ส่วนขยายใน Visual Studio Code เพื่อให้เอเจนต์ของคุณสามารถทำการคำนวณทางคณิตศาสตร์เช่น การบวก ลบ คูณ และหาร ผ่านภาษาธรรมชาติ

AI Toolkit เป็นส่วนขยายที่ทรงพลังสำหรับ Visual Studio Code ที่ช่วยให้การพัฒนาเอเจนต์เป็นไปอย่างราบรื่น วิศวกร AI สามารถสร้างแอปพลิเคชัน AI ได้ง่ายๆ โดยการพัฒนาและทดสอบโมเดล AI เชิงสร้างสรรค์—ในเครื่องหรือในคลาวด์ ส่วนขยายนี้รองรับโมเดลเชิงสร้างสรรค์ที่สำคัญที่สุดที่มีอยู่ในปัจจุบัน

*หมายเหตุ*: AI Toolkit ปัจจุบันรองรับ Python และ TypeScript

## วัตถุประสงค์การเรียนรู้

เมื่อจบบทเรียนนี้ คุณจะสามารถ:

- ใช้เซิร์ฟเวอร์ MCP ผ่าน AI Toolkit
- กำหนดค่าเอเจนต์เพื่อให้สามารถค้นหาและใช้เครื่องมือที่เซิร์ฟเวอร์ MCP ให้มา
- ใช้เครื่องมือ MCP ผ่านภาษาธรรมชาติ

## วิธีการ

นี่คือวิธีที่เราต้องดำเนินการในระดับสูง:

- สร้างเอเจนต์และกำหนดข้อความระบบของมัน
- สร้างเซิร์ฟเวอร์ MCP พร้อมเครื่องมือเครื่องคิดเลข
- เชื่อมต่อ Agent Builder กับเซิร์ฟเวอร์ MCP
- ทดสอบการเรียกใช้เครื่องมือของเอเจนต์ผ่านภาษาธรรมชาติ

ดีมาก ตอนนี้เราเข้าใจการไหลแล้ว มาตั้งค่าเอเจนต์ AI เพื่อใช้เครื่องมือภายนอกผ่าน MCP เพื่อเพิ่มประสิทธิภาพของมัน!

## ข้อกำหนดเบื้องต้น

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## การฝึก: การใช้เซิร์ฟเวอร์

ในแบบฝึกหัดนี้ คุณจะสร้าง รัน และปรับปรุงเอเจนต์ AI ด้วยเครื่องมือจากเซิร์ฟเวอร์ MCP ภายใน Visual Studio Code โดยใช้ AI Toolkit

### -0- ขั้นตอนก่อนหน้า เพิ่มโมเดล OpenAI GPT-4o ไปยัง My Models

แบบฝึกหัดนี้ใช้โมเดล **GPT-4o** โมเดลควรจะถูกเพิ่มไปยัง **My Models** ก่อนที่จะสร้างเอเจนต์

1. เปิดส่วนขยาย **AI Toolkit** จาก **Activity Bar**
1. ในส่วน **Catalog** เลือก **Models** เพื่อเปิด **Model Catalog** การเลือก **Models** จะเปิด **Model Catalog** ในแท็บตัวแก้ไขใหม่
1. ในแถบค้นหา **Model Catalog** ใส่ **OpenAI GPT-4o**
1. คลิก **+ Add** เพื่อเพิ่มโมเดลไปยังรายการ **My Models** ของคุณ ตรวจสอบให้แน่ใจว่าคุณได้เลือกโมเดลที่ **Hosted by GitHub**
1. ใน **Activity Bar** ยืนยันว่าโมเดล **OpenAI GPT-4o** ปรากฏในรายการ

### -1- สร้างเอเจนต์

**Agent (Prompt) Builder** ช่วยให้คุณสร้างและปรับแต่งเอเจนต์ที่ใช้พลังงานจาก AI ของคุณเอง ในส่วนนี้ คุณจะสร้างเอเจนต์ใหม่และกำหนดโมเดลเพื่อขับเคลื่อนการสนทนา

1. เปิดส่วนขยาย **AI Toolkit** จาก **Activity Bar**
1. ในส่วน **Tools** เลือก **Agent (Prompt) Builder** การเลือก **Agent (Prompt) Builder** จะเปิด **Agent (Prompt) Builder** ในแท็บตัวแก้ไขใหม่
1. คลิกปุ่ม **+ New Builder** ส่วนขยายจะเปิดตัวช่วยสร้างการตั้งค่าผ่าน **Command Palette**
1. ใส่ชื่อ **Calculator Agent** แล้วกด **Enter**
1. ใน **Agent (Prompt) Builder** สำหรับฟิลด์ **Model** เลือกโมเดล **OpenAI GPT-4o (via GitHub)**

### -2- สร้างข้อความระบบสำหรับเอเจนต์

เมื่อเอเจนต์ถูกสร้างขึ้นแล้ว ก็ถึงเวลาที่จะกำหนดบุคลิกภาพและวัตถุประสงค์ของมัน ในส่วนนี้ คุณจะใช้ฟีเจอร์ **Generate system prompt** เพื่ออธิบายพฤติกรรมที่ตั้งใจของเอเจนต์—ในกรณีนี้คือเอเจนต์เครื่องคิดเลข—และให้โมเดลเขียนข้อความระบบให้คุณ

1. สำหรับส่วน **Prompts** คลิกปุ่ม **Generate system prompt** ปุ่มนี้เปิดในตัวสร้างข้อความซึ่งใช้ AI ในการสร้างข้อความระบบสำหรับเอเจนต์
1. ในหน้าต่าง **Generate a prompt** ใส่ข้อมูลดังนี้ `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. คลิกปุ่ม **Generate** จะมีการแจ้งเตือนปรากฏขึ้นที่มุมล่างขวาเพื่อยืนยันว่ากำลังสร้างข้อความระบบ เมื่อการสร้างข้อความเสร็จสิ้น ข้อความจะปรากฏในฟิลด์ **System prompt** ของ **Agent (Prompt) Builder**
1. ทบทวน **System prompt** และปรับปรุงหากจำเป็น

### -3- สร้างเซิร์ฟเวอร์ MCP

เมื่อคุณได้กำหนดข้อความระบบของเอเจนต์แล้ว—ชี้นำพฤติกรรมและการตอบสนอง—ถึงเวลาที่จะให้เอเจนต์มีความสามารถที่เป็นประโยชน์ ในส่วนนี้ คุณจะสร้างเซิร์ฟเวอร์ MCP เครื่องคิดเลขพร้อมเครื่องมือในการดำเนินการบวก ลบ คูณ และหาร การคำนวณนี้จะทำให้เอเจนต์ของคุณสามารถทำการคำนวณทางคณิตศาสตร์แบบเรียลไทม์ในตอบสนองต่อคำถามภาษาธรรมชาติ

AI Toolkit มีเทมเพลตสำหรับการสร้างเซิร์ฟเวอร์ MCP ของคุณเองได้ง่ายๆ เราจะใช้เทมเพลต Python สำหรับการสร้างเซิร์ฟเวอร์ MCP เครื่องคิดเลข

*หมายเหตุ*: AI Toolkit ปัจจุบันรองรับ Python และ TypeScript

1. ในส่วน **Tools** ของ **Agent (Prompt) Builder** คลิกปุ่ม **+ MCP Server** ส่วนขยายจะเปิดตัวช่วยสร้างการตั้งค่าผ่าน **Command Palette**
1. เลือก **+ Add Server**
1. เลือก **Create a New MCP Server**
1. เลือก **python-weather** เป็นเทมเพลต
1. เลือก **Default folder** เพื่อบันทึกเทมเพลตเซิร์ฟเวอร์ MCP
1. ใส่ชื่อเซิร์ฟเวอร์ดังนี้: **Calculator**
1. หน้าต่าง Visual Studio Code ใหม่จะเปิดขึ้น เลือก **Yes, I trust the authors**
1. ใช้ terminal (**Terminal** > **New Terminal**) สร้างสภาพแวดล้อมเสมือน `python -m venv .venv`
1. ใช้ terminal เปิดใช้งานสภาพแวดล้อมเสมือน:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. ใช้ terminal ติดตั้ง dependencies `pip install -e .[dev]`
1. ใน **Explorer** view ของ **Activity Bar** ขยายไดเรกทอรี **src** และเลือก **server.py** เพื่อเปิดไฟล์ในตัวแก้ไข
1. แทนที่โค้ดในไฟล์ **server.py** ด้วยข้อมูลต่อไปนี้และบันทึก:

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

ตอนนี้เอเจนต์ของคุณมีเครื่องมือแล้ว ถึงเวลาที่จะใช้มัน! ในส่วนนี้ คุณจะส่งคำถามไปยังเอเจนต์เพื่อทดสอบและตรวจสอบว่าเอเจนต์ใช้เครื่องมือที่เหมาะสมจากเซิร์ฟเวอร์ MCP เครื่องคิดเลขหรือไม่

คุณจะรันเซิร์ฟเวอร์ MCP เครื่องคิดเลขบนเครื่องพัฒนาในพื้นที่ของคุณผ่าน **Agent Builder** เป็น MCP client

1. กด `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` ค่าเหล่านี้จะถูกกำหนดสำหรับเครื่องมือ **subtract**
    - การตอบสนองจากแต่ละเครื่องมือจะถูกให้ใน **Tool Response** ที่เกี่ยวข้อง
    - ผลลัพธ์สุดท้ายจากโมเดลจะถูกให้ใน **Model Response** สุดท้าย
1. ส่งคำถามเพิ่มเติมเพื่อทดสอบเอเจนต์เพิ่มเติม คุณสามารถปรับเปลี่ยนคำถามที่มีอยู่ในฟิลด์ **User prompt** โดยคลิกเข้าไปในฟิลด์และแทนที่คำถามที่มีอยู่
1. เมื่อคุณเสร็จสิ้นการทดสอบเอเจนต์ คุณสามารถหยุดเซิร์ฟเวอร์ผ่าน **terminal** โดยการใส่ **CTRL/CMD+C** เพื่อออก

## การมอบหมาย

ลองเพิ่มเครื่องมือเพิ่มเติมในไฟล์ **server.py** ของคุณ (เช่น การคืนค่ารากที่สองของตัวเลข) ส่งคำถามเพิ่มเติมที่ต้องการให้เอเจนต์ใช้เครื่องมือใหม่ของคุณ (หรือเครื่องมือที่มีอยู่) อย่าลืมรีสตาร์ทเซิร์ฟเวอร์เพื่อโหลดเครื่องมือที่เพิ่มใหม่

## คำตอบ

[Solution](./solution/README.md)

## ประเด็นสำคัญ

ประเด็นสำคัญจากบทนี้คือ:

- ส่วนขยาย AI Toolkit เป็น client ที่ยอดเยี่ยมที่ให้คุณใช้เซิร์ฟเวอร์ MCP และเครื่องมือของมัน
- คุณสามารถเพิ่มเครื่องมือใหม่ให้กับเซิร์ฟเวอร์ MCP ขยายความสามารถของเอเจนต์เพื่อให้ตรงกับความต้องการที่เปลี่ยนแปลง
- AI Toolkit มีเทมเพลต (เช่น เทมเพลตเซิร์ฟเวอร์ MCP Python) เพื่อทำให้การสร้างเครื่องมือที่กำหนดเองง่ายขึ้น

## แหล่งข้อมูลเพิ่มเติม

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## อะไรต่อไป

ต่อไป: [บทที่ 4 การนำไปใช้จริง](/04-PracticalImplementation/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปล AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้มีความถูกต้อง โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นฉบับควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้การแปลโดยมนุษย์มืออาชีพ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดที่เกิดจากการใช้การแปลนี้