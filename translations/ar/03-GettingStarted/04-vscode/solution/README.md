<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:14:33+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "ar"
}
-->
# تشغيل المثال

نفترض هنا أنك تمتلك بالفعل كود سيرفر يعمل. يرجى العثور على سيرفر من أحد الفصول السابقة.

## إعداد mcp.json

إليك ملف يمكنك استخدامه كمرجع، [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

غيّر مدخل السيرفر حسب الحاجة ليشير إلى المسار الكامل المطلق لسيرفرك بما في ذلك الأمر الكامل اللازم للتشغيل.

في ملف المثال المشار إليه أعلاه، يبدو مدخل السيرفر كالتالي:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

هذا يعادل تشغيل أمر مثل: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` اكتب شيئًا مثل "add 3 to 20".

    يجب أن ترى أداة تظهر فوق مربع نص الدردشة تشير إلى أنه يمكنك اختيار تشغيل الأداة كما في هذا الشكل البصري:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ar.png)

    اختيار الأداة يجب أن ينتج نتيجة رقمية تقول "23" إذا كان الطلب الخاص بك كما ذكرنا سابقًا.

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالترجمة البشرية الاحترافية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.