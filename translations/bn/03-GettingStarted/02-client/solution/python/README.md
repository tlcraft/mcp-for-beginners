<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0ab9613fc9595f493847f91275859a18",
  "translation_date": "2025-05-17T10:00:19+00:00",
  "source_file": "03-GettingStarted/02-client/solution/python/README.md",
  "language_code": "bn"
}
-->
# এই নমুনা চালানো

আপনাকে `uv` ইনস্টল করার সুপারিশ করা হচ্ছে, তবে এটি আবশ্যিক নয়, বিস্তারিত জানার জন্য [নির্দেশনা](https://docs.astral.sh/uv/#highlights) দেখুন

## -0- একটি ভার্চুয়াল পরিবেশ তৈরি করুন

```bash
python -m venv venv
```

## -1- ভার্চুয়াল পরিবেশ সক্রিয় করুন

```bash
venv\Scrips\activate
```

## -2- নির্ভরশীলতাগুলি ইনস্টল করুন

```bash
pip install "mcp[cli]"
```

## -3- নমুনাটি চালান

```bash
python client.py
```

আপনি দেখতে পাবেন একটি আউটপুট যা এর মতো হবে:

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

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসম্ভব সঠিকতার জন্য চেষ্টা করি, তবে অনুগ্রহ করে সচেতন থাকুন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অসত্যতা থাকতে পারে। মূল ভাষায় থাকা নথিটিকে প্রামাণিক উৎস হিসেবে বিবেচনা করা উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে উদ্ভূত কোন ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।