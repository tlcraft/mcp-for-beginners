<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24531f2b6b0f7fa3839accf4dc10088a",
  "translation_date": "2025-05-17T10:46:54+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/python/README.md",
  "language_code": "bn"
}
-->
# এই নমুনাটি চালানো

আপনার `uv` ইনস্টল করা সুপারিশ করা হয় তবে এটি আবশ্যক নয়, [নির্দেশাবলী](https://docs.astral.sh/uv/#highlights) দেখুন

## -0- একটি ভার্চুয়াল পরিবেশ তৈরি করুন

```bash
python -m venv venv
```

## -1- ভার্চুয়াল পরিবেশ সক্রিয় করুন

```bash
venv\Scrips\activate
```

## -2- নির্ভরতাগুলি ইনস্টল করুন

```bash
pip install "mcp[cli]"
pip install openai
pip install azure-ai-inference
```

## -3- নমুনাটি চালান

```bash
python client.py
```

আপনার একটি আউটপুট দেখতে উচিত যা এরকম:

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

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ পরিষেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসম্ভব নির্ভুলতা বজায় রাখার চেষ্টা করি, তবে অনুগ্রহ করে সচেতন থাকুন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অসংগতি থাকতে পারে। এর মূল ভাষায় মূল নথিটি প্রামাণিক উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে উদ্ভূত কোনও ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়বদ্ধ নই।