<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "999c5e7623c1e2d5e5a07c2feb39eb67",
  "translation_date": "2025-06-10T06:31:05+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/README.md",
  "language_code": "th"
}
-->
# Weather MCP Server

นี่คือตัวอย่าง MCP Server ที่เขียนด้วย Python สำหรับเครื่องมือพยากรณ์อากาศที่ใช้การตอบกลับแบบจำลอง สามารถนำไปใช้เป็นโครงสร้างพื้นฐานสำหรับ MCP Server ของคุณเอง โดยมีฟีเจอร์ดังนี้:

- **Weather Tool**: เครื่องมือที่ให้ข้อมูลสภาพอากาศจำลองตามสถานที่ที่ระบุ
- **เชื่อมต่อกับ Agent Builder**: ฟีเจอร์ที่ช่วยให้คุณเชื่อมต่อ MCP Server กับ Agent Builder เพื่อทดสอบและดีบัก
- **ดีบักด้วย [MCP Inspector](https://github.com/modelcontextprotocol/inspector)**: ฟีเจอร์ที่ช่วยให้ดีบัก MCP Server ผ่าน MCP Inspector

## เริ่มต้นกับ Weather MCP Server template

> **สิ่งที่ต้องเตรียม**
>
> เพื่อรัน MCP Server บนเครื่องพัฒนาในเครื่องของคุณ คุณจะต้องมี:
>
> - [Python](https://www.python.org/)
> - (*ถ้าต้องการ - สำหรับ uv*) [uv](https://github.com/astral-sh/uv)
> - [Python Debugger Extension](https://marketplace.visualstudio.com/items?itemName=ms-python.debugpy)

## เตรียมสภาพแวดล้อม

มีสองวิธีในการตั้งค่าสภาพแวดล้อมสำหรับโปรเจกต์นี้ คุณสามารถเลือกวิธีใดก็ได้ตามที่สะดวก

> หมายเหตุ: ให้รีโหลด VSCode หรือเทอร์มินัลเพื่อให้แน่ใจว่าใช้ python จาก virtual environment หลังจากสร้าง virtual environment แล้ว

| วิธีการ | ขั้นตอน |
| -------- | ----- |
| ใช้ `uv` | 1. สร้าง virtual environment: `uv venv` <br>2. รันคำสั่งใน VSCode "***Python: Select Interpreter***" และเลือก python จาก virtual environment ที่สร้างขึ้น <br>3. ติดตั้ง dependencies (รวมถึง dev dependencies): `uv pip install -r pyproject.toml --extra dev` |
| ใช้ `pip` | 1. สร้าง virtual environment: `python -m venv .venv` <br>2. รันคำสั่งใน VSCode "***Python: Select Interpreter***" และเลือก python จาก virtual environment ที่สร้างขึ้น <br>3. ติดตั้ง dependencies (รวมถึง dev dependencies): `pip install -e .[dev]` |

หลังจากตั้งค่าสภาพแวดล้อมเสร็จแล้ว คุณสามารถรันเซิร์ฟเวอร์บนเครื่องพัฒนาของคุณผ่าน Agent Builder ในฐานะ MCP Client เพื่อเริ่มต้นได้:
1. เปิดแผง Debug ของ VS Code เลือก `Debug in Agent Builder` หรือกด `F5` เพื่อเริ่มดีบัก MCP server
2. ใช้ AI Toolkit Agent Builder เพื่อทดสอบเซิร์ฟเวอร์ด้วย [คำสั่งนี้](../../../../../../../../../../../open_prompt_builder) เซิร์ฟเวอร์จะเชื่อมต่อกับ Agent Builder อัตโนมัติ
3. คลิก `Run` เพื่อทดสอบเซิร์ฟเวอร์ด้วยคำสั่งนี้

**ยินดีด้วย!** คุณได้รัน Weather MCP Server บนเครื่องพัฒนาของคุณผ่าน Agent Builder ในฐานะ MCP Client สำเร็จแล้ว  
![DebugMCP](https://raw.githubusercontent.com/microsoft/windows-ai-studio-templates/refs/heads/dev/mcpServers/mcp_debug.gif)

## สิ่งที่รวมอยู่ใน template

| โฟลเดอร์ / ไฟล์ | เนื้อหา |
| ------------ | -------------------------------------------- |
| `.vscode`    | ไฟล์ VSCode สำหรับการดีบัก                   |
| `.aitk`      | การตั้งค่าสำหรับ AI Toolkit                |
| `src`        | โค้ดต้นฉบับสำหรับ weather mcp server   |

## วิธีดีบัก Weather MCP Server

> หมายเหตุ:
> - [MCP Inspector](https://github.com/modelcontextprotocol/inspector) เป็นเครื่องมือสำหรับนักพัฒนาที่ใช้ทดสอบและดีบัก MCP servers แบบภาพ
> - โหมดดีบักทุกโหมดรองรับ breakpoints คุณจึงสามารถเพิ่ม breakpoints ในโค้ดของเครื่องมือได้

| โหมดดีบัก | คำอธิบาย | ขั้นตอนการดีบัก |
| ---------- | ----------- | --------------- |
| Agent Builder | ดีบัก MCP server ใน Agent Builder ผ่าน AI Toolkit | 1. เปิดแผง Debug ของ VS Code เลือก `Debug in Agent Builder` และกด `F5` เพื่อเริ่มดีบัก MCP server<br>2. ใช้ AI Toolkit Agent Builder ทดสอบเซิร์ฟเวอร์ด้วย [คำสั่งนี้](../../../../../../../../../../../open_prompt_builder) เซิร์ฟเวอร์จะเชื่อมต่อกับ Agent Builder อัตโนมัติ<br>3. คลิก `Run` เพื่อทดสอบเซิร์ฟเวอร์ด้วยคำสั่งนี้ |
| MCP Inspector | ดีบัก MCP server โดยใช้ MCP Inspector | 1. ติดตั้ง [Node.js](https://nodejs.org/)<br> 2. ตั้งค่า Inspector: `cd inspector` && `npm install` <br> 3. เปิดแผง Debug ของ VS Code เลือก `Debug SSE in Inspector (Edge)` หรือ `Debug SSE in Inspector (Chrome)` กด F5 เพื่อเริ่มดีบัก<br> 4. เมื่อ MCP Inspector เปิดในเบราว์เซอร์ ให้คลิกปุ่ม `Connect` เพื่อเชื่อมต่อ MCP server นี้<br> 5. จากนั้นคุณสามารถ `List Tools`, เลือกเครื่องมือ, ป้อนพารามิเตอร์ และ `Run Tool` เพื่อดีบักโค้ดเซิร์ฟเวอร์ของคุณ<br> |

## พอร์ตเริ่มต้นและการปรับแต่ง

| โหมดดีบัก | พอร์ต | คำจำกัดความ | การปรับแต่ง | หมายเหตุ |
| ---------- | ----- | ------------ | -------------- |-------------- |
| Agent Builder | 3001 | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | แก้ไข [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) เพื่อเปลี่ยนพอร์ตข้างต้น | ไม่มี |
| MCP Inspector | 3001 (Server); 5173 และ 3000 (Inspector) | [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json) | แก้ไข [launch.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/launch.json), [tasks.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.vscode/tasks.json), [\_\_init\_\_.py](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/src/__init__.py), [mcp.json](../../../../../../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab3/code/weather_mcp/.aitk/mcp.json) เพื่อเปลี่ยนพอร์ตข้างต้น | ไม่มี |

## ข้อเสนอแนะ

หากคุณมีข้อเสนอแนะหรือติชมสำหรับ template นี้ กรุณาเปิด issue ใน [AI Toolkit GitHub repository](https://github.com/microsoft/vscode-ai-toolkit/issues)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้มีความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นฉบับควรถูกพิจารณาเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้