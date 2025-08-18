<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "aa5122c6d9868b4b566586f27577ca47",
  "translation_date": "2025-08-18T19:04:45+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/rust/calculator-httpclient/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို အလုပ်လုပ်စေခြင်း

## -1- Streamable HTTP server ကို အလုပ်လုပ်စေပါ

ဒီ project ရဲ့ root directory မှ terminal တစ်ခုကို ဖွင့်ပြီး အောက်ပါ command များကို run လုပ်ပါ။

```bash
cd ../calculator-httpserver
cargo run
```

ဒီ terminal ကို ဖွင့်ထားပါ၊ အကြောင်းမှာ client က ဆက်သွယ်မယ့် HTTP server ကို run လုပ်နေမှာဖြစ်ပါတယ်။ နောက်ထပ်အဆင့်များအတွက် terminal အသစ်တစ်ခု ဖွင့်ပါ။

## -2- Dependencies များကို install လုပ်ပြီး project ကို build လုပ်ပါ

```bash
cargo build
```

## -3- နမူနာကို အလုပ်လုပ်စေပါ

```bash
cargo run
```

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတရ အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအမှားများ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။