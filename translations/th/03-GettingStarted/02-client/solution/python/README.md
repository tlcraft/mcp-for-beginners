<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:02:11+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "th"
}
-->
# การรันตัวอย่างนี้

แนะนำให้ติดตั้ง `uv` แต่ไม่จำเป็นต้องทำตาม ดู [คำแนะนำ](https://docs.astral.sh/uv/#highlights)

## -0- สร้าง virtual environment

```bash
python -m venv venv
```

## -1- เปิดใช้งาน virtual environment

```bash
venv\Scrips\activate
```

## -2- ติดตั้ง dependencies

```bash
pip install "mcp[cli]"
```

## -3- รันตัวอย่าง


```bash
python client.py
```

คุณควรเห็นผลลัพธ์ที่คล้ายกับ:

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
READING RESOURCE
                    INFO     Processing request of type ReadResourceRequest                                                                            server.py:534
CALL TOOL
                    INFO     Processing request of type CallToolRequest                                                                                server.py:534
[TextContent(type='text', text='8', annotations=None)]
```

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษา AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้ว่าเราจะพยายามให้เกิดความถูกต้อง แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางควรถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ แนะนำให้ใช้การแปลโดยมนุษย์มืออาชีพ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความที่ผิดพลาดที่เกิดจากการใช้การแปลนี้