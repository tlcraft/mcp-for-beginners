<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "584c4d6b470d865ad04746f5da3574b6",
  "translation_date": "2025-05-17T14:56:08+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "bn"
}
-->
# নমুনা

এটি একটি পাইটন নমুনা একটি এমসিপি সার্ভারের জন্য।

এই মডিউলটি দেখায় কিভাবে একটি সাধারণ এমসিপি সার্ভার বাস্তবায়ন করতে হয় যা সম্পূর্ণতা অনুরোধগুলি পরিচালনা করতে পারে। এটি একটি মক বাস্তবায়ন প্রদান করে যা বিভিন্ন এআই মডেলের সাথে ইন্টারঅ্যাকশন অনুকরণ করে।

এখানে টুল নিবন্ধন প্রক্রিয়াটি কেমন দেখতে তা দেওয়া হল:

```python
completion_tool = ToolDefinition(
    name="completion",
    description="Generate completions using AI models",
    parameters={
        "model": {
            "type": "string",
            "enum": self.models,
            "description": "The AI model to use for completion"
        },
        "prompt": {
            "type": "string",
            "description": "The prompt text to complete"
        },
        "temperature": {
            "type": "number",
            "description": "Sampling temperature (0.0 to 1.0)"
        },
        "max_tokens": {
            "type": "number",
            "description": "Maximum number of tokens to generate"
        }
    },
    required=["model", "prompt"]
)

# Register the tool with its handler
self.server.tools.register(completion_tool, self._handle_completion)
```

## ইনস্টল

নিম্নলিখিত কমান্ডটি চালান:

```bash
pip install mcp
```

## চালান

```bash
python mcp_sample.py
```

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনুবাদ করা হয়েছে। আমরা যথাসাধ্য সঠিকতার জন্য চেষ্টা করি, তবে অনুগ্রহ করে সচেতন থাকুন যে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল ভাষায় থাকা নথিটি প্রামাণিক উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য, পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদ ব্যবহারের ফলে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যা উদ্ভূত হলে আমরা দায়ী থাকব না।