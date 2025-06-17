<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:38:01+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "pa"
}
-->
# ਸੈਂਪਲ ਚਲਾਉਣਾ

ਇੱਥੇ ਅਸੀਂ ਮੰਨਦੇ ਹਾਂ ਕਿ ਤੁਹਾਡੇ ਕੋਲ ਪਹਿਲਾਂ ਹੀ ਕੋਈ ਕੰਮ ਕਰਦਾ ਸਰਵਰ ਕੋਡ ਹੈ। ਕਿਰਪਾ ਕਰਕੇ ਪਹਿਲਾਂ ਦੇ ਕਿਸੇ ਚੈਪਟਰ ਵਿੱਚੋਂ ਇੱਕ ਸਰਵਰ ਲੱਭੋ।

## mcp.json ਸੈੱਟਅਪ ਕਰੋ

ਇੱਥੇ ਇੱਕ ਫਾਇਲ ਹੈ ਜਿਸਨੂੰ ਤੁਸੀਂ ਰੈਫਰੈਂਸ ਵਜੋਂ ਵਰਤ ਸਕਦੇ ਹੋ, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)।

ਸਰਵਰ ਐਂਟਰੀ ਨੂੰ ਜਰੂਰਤ ਮੁਤਾਬਕ ਬਦਲੋ ਤਾਂ ਜੋ ਤੁਹਾਡੇ ਸਰਵਰ ਦਾ ਪੂਰਾ ਪਾਥ ਅਤੇ ਚਲਾਉਣ ਲਈ ਲੋੜੀਂਦਾ ਪੂਰਾ ਕਮਾਂਡ ਦਰਸਾਇਆ ਜਾ ਸਕੇ।

ਉਪਰ ਦਿੱਤੀ ਉਦਾਹਰਨ ਫਾਇਲ ਵਿੱਚ ਸਰਵਰ ਐਂਟਰੀ ਕੁਝ ਇਸ ਤਰ੍ਹਾਂ ਦਿਖਾਈ ਦਿੰਦੀ ਹੈ:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

ਇਹ ਕੁਝ ਇਸ ਤਰ੍ਹਾਂ ਕਮਾਂਡ ਚਲਾਉਣ ਦੇ ਬਰਾਬਰ ਹੈ: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` ਜਿਸਦਾ ਮਤਲਬ ਹੈ "20 ਵਿੱਚ 3 ਜੋੜੋ" ਵਰਗਾ ਕੁਝ ਟਾਈਪ ਕਰੋ।

    ਤੁਹਾਨੂੰ ਚੈਟ ਟੈਕਸਟ ਬਾਕਸ ਦੇ ਉੱਪਰ ਇੱਕ ਟੂਲ ਦਿਖਾਈ ਦੇਣਾ ਚਾਹੀਦਾ ਹੈ ਜੋ ਇਹ ਦਰਸਾਉਂਦਾ ਹੈ ਕਿ ਤੁਸੀਂ ਟੂਲ ਚਲਾਉਣ ਲਈ ਇਸਨੂੰ ਚੁਣ ਸਕਦੇ ਹੋ, ਜਿਵੇਂ ਇਸ ਤਸਵੀਰ ਵਿੱਚ ਹੈ:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.pa.png)

    ਟੂਲ ਚੁਣਨ 'ਤੇ ਤੁਹਾਨੂੰ ਇੱਕ ਨੰਬਰ ਦਿੱਤਾ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ ਜੋ "23" ਹੋਵੇਗਾ ਜੇ ਤੁਹਾਡਾ ਪ੍ਰਾਂਪਟ ਪਿਛਲੇ ਵਾਕ ਦੀ ਤਰ੍ਹਾਂ ਸੀ।

**ਡਿਸਕਲੇਮਰ**:  
ਇਸ ਦਸਤਾਵੇਜ਼ ਦਾ ਅਨੁਵਾਦ ਏਆਈ ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਆਟੋਮੈਟਿਕ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਣਸਹੀ ਗਲਤਫਹਿਮੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਿਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਨਾਲ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭ੍ਰਮਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।