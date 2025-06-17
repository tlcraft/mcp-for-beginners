<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:17:51+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "ur"
}
-->
# سیمپل چلانا

یہاں ہم فرض کرتے ہیں کہ آپ کے پاس پہلے سے ایک کام کرنے والا سرور کوڈ موجود ہے۔ براہ کرم پہلے کے کسی باب سے ایک سرور تلاش کریں۔

## mcp.json سیٹ اپ کریں

یہاں ایک فائل ہے جسے آپ حوالہ کے طور پر استعمال کر سکتے ہیں، [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)۔

سرور انٹری کو اپنی ضرورت کے مطابق تبدیل کریں تاکہ آپ کے سرور کا مکمل راستہ اور چلانے کا مکمل کمانڈ شامل ہو۔

مثال کے طور پر مذکورہ فائل میں سرور انٹری کچھ یوں نظر آتی ہے:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

یہ اس کمانڈ کو چلانے کے مترادف ہے: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add`، کچھ ایسا لکھیں جیسے "add 3 to 20"۔

    آپ کو چیٹ ٹیکسٹ باکس کے اوپر ایک ٹول نظر آئے گا جو آپ کو ٹول چلانے کے لیے منتخب کرنے کا اشارہ دے گا، جیسا کہ اس تصویر میں دکھایا گیا ہے:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ur.png)

    اگر آپ کا پرامپٹ ویسا ہی تھا جیسا ہم نے پہلے ذکر کیا، تو ٹول منتخب کرنے پر نتیجہ "23" کے طور پر ظاہر ہوگا۔

**ڈسکلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غیر یقینی معلومات ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔