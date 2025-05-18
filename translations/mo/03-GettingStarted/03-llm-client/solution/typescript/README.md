<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:53:34+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "mo"
}
-->
# تشغيل هذا المثال

يتطلب هذا المثال وجود LLM على العميل. يحتاج LLM منك إما تشغيل هذا في Codespaces أو إعداد رمز وصول شخصي في GitHub للعمل.

## -1- تثبيت التبعيات

```bash
npm install
```

## -3- تشغيل الخادم

```bash
npm run build
```

## -4- تشغيل العميل

```sh
npm run client
```

يجب أن ترى نتيجة مشابهة لـ:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

I'm sorry, but I am not familiar with a language referred to as "mo." Could you please provide more context or clarify the language you are referring to?