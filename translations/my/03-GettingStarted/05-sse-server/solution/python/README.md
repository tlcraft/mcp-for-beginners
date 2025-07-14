<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-07-13T20:17:40+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "my"
}
-->
# ဤနမူနာကို chạyခြင်း

`uv` ကို 설치ရန် 권장하지만 필수는 아니며, 자세한 내용은 [instructions](https://docs.astral.sh/uv/#highlights)에서 확인하세요။

## -0- 가상 환경 생성하기

```bash
python -m venv venv
```

## -1- 가상 환경 활성화하기

```bash
venv\Scrips\activate
```

## -2- 의존성 설치하기

```bash
pip install "mcp[cli]"
```

## -3- 샘플 실행하기

```bash
mcp run server.py
```

## -4- 샘플 테스트하기

서버가 한 터미널에서 실행 중일 때, 다른 터미널을 열고 다음 명령어를 실행하세요:

```bash
mcp dev server.py
```

이 명령어는 시각적 인터페이스가 있는 웹 서버를 시작하여 샘플을 테스트할 수 있게 합니다.

서버가 연결되면:

- 도구 목록을 확인하고 `add`를 인수 2와 4와 함께 실행해 보세요. 결과로 6이 보여야 합니다.
- resources와 resource template로 이동하여 get_greeting을 호출하고 이름을 입력하면 입력한 이름이 포함된 인사말을 볼 수 있습니다.

### CLI 모드에서 테스트하기

실행한 inspector는 사실 Node.js 앱이며 `mcp dev`는 이를 감싸는 래퍼입니다.

다음 명령어를 실행하여 CLI 모드에서 직접 실행할 수 있습니다:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

이 명령어는 서버에서 사용 가능한 모든 도구를 나열합니다. 다음과 같은 출력이 보여야 합니다:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

도구를 호출하려면 다음과 같이 입력하세요:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

다음과 같은 출력이 보여야 합니다:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> 일반적으로 브라우저보다 CLI 모드에서 inspector를 실행하는 것이 훨씬 빠릅니다.
> inspector에 대해 더 알아보려면 [여기](https://github.com/modelcontextprotocol/inspector)를 참고하세요.

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။