<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24531f2b6b0f7fa3839accf4dc10088a",
  "translation_date": "2025-05-17T10:45:41+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/python/README.md",
  "language_code": "fa"
}
-->
# اجرای این نمونه

پیشنهاد می‌شود که `uv` را نصب کنید، اما ضروری نیست، به [دستورالعمل‌ها](https://docs.astral.sh/uv/#highlights) مراجعه کنید.

## -0- ایجاد یک محیط مجازی

```bash
python -m venv venv
```

## -1- فعال‌سازی محیط مجازی

```bash
venv\Scrips\activate
```

## -2- نصب وابستگی‌ها

```bash
pip install "mcp[cli]"
pip install openai
pip install azure-ai-inference
```

## -3- اجرای نمونه

```bash
python client.py
```

شما باید خروجی مشابهی ببینید:

```text
LISTING RESOURCES
Resource:  ('meta', None)
Resource:  ('nextCursor', None)
Resource:  ('resources', [])
                    INFO     Processing request of type ListToolsRequest                                                                               server.py:534
LISTING TOOLS
Tool:  add
Tool {'a': {'title': 'A', 'type': 'integer'}, 'b': {'title': 'B', 'type': 'integer'}}
CALLING LLM
TOOL:  {'function': {'arguments': '{"a":2,"b":20}', 'name': 'add'}, 'id': 'call_BCbyoCcMgq0jDwR8AuAF9QY3', 'type': 'function'}
[05/08/25 21:04:55] INFO     Processing request of type CallToolRequest                                                                                server.py:534
TOOLS result:  [TextContent(type='text', text='22', annotations=None)]
```

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌ها باشند. سند اصلی به زبان مادری آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئولیتی در قبال سوء تفاهم‌ها یا تفسیرهای نادرست ناشی از استفاده از این ترجمه نداریم.