<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:16:07+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "fa"
}
-->
# اجرای نمونه

در اینجا فرض می‌کنیم که شما قبلاً کد سروری کارآمد دارید. لطفاً یک سرور را از یکی از فصل‌های قبلی پیدا کنید.

## تنظیم mcp.json

در اینجا فایلی است که می‌توانید به عنوان مرجع استفاده کنید، [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

ورودی سرور را در صورت نیاز تغییر دهید تا مسیر مطلق سرور شما به همراه دستور کامل لازم برای اجرا مشخص شود.

در فایل نمونه‌ای که اشاره شد، ورودی سرور به این شکل است:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

این معادل اجرای دستوری مانند این است: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` چیزی شبیه به "add 3 to 20" تایپ کنید.

    باید ابزاری بالای کادر متن چت نمایش داده شود که به شما اجازه می‌دهد برای اجرای ابزار انتخاب کنید، مانند این تصویر:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.fa.png)

    انتخاب این ابزار باید نتیجه عددی "23" را نشان دهد اگر پرامپت شما مشابه آنچه قبلاً گفتیم باشد.

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، توصیه می‌شود از ترجمه حرفه‌ای انسانی استفاده شود. ما مسئول هیچ گونه سوءتفاهم یا برداشت نادرستی که ناشی از استفاده از این ترجمه باشد، نیستیم.