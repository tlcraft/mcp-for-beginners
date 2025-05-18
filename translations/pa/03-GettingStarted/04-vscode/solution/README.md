<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:20:08+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "pa"
}
-->
# ਨਮੂਨਾ ਚਲਾਉਣਾ

ਇੱਥੇ ਅਸੀਂ ਮੰਨਦੇ ਹਾਂ ਕਿ ਤੁਹਾਡੇ ਕੋਲ ਪਹਿਲਾਂ ਤੋਂ ਹੀ ਸਰਵਰ ਕੋਡ ਕੰਮ ਕਰ ਰਿਹਾ ਹੈ। ਕਿਰਪਾ ਕਰਕੇ ਪਹਿਲੇ ਅਧਿਆਇ ਵਿੱਚੋਂ ਇੱਕ ਸਰਵਰ ਲੱਭੋ।

## mcp.json ਸੈਟ ਅੱਪ ਕਰੋ

ਇੱਥੇ ਇੱਕ ਫਾਇਲ ਹੈ ਜਿਸਨੂੰ ਤੁਸੀਂ ਹਵਾਲੇ ਲਈ ਵਰਤਦੇ ਹੋ, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)।

ਸਰਵਰ ਐਨਟਰੀ ਨੂੰ ਲੋੜ ਅਨੁਸਾਰ ਬਦਲੋ ਤਾਂ ਜੋ ਤੁਹਾਡੇ ਸਰਵਰ ਤੱਕ ਪੂਰਾ ਰਸਤਾ ਅਤੇ ਚਲਾਉਣ ਲਈ ਲੋੜੀਂਦਾ ਪੂਰਾ ਕਮਾਂਡ ਦਰਸਾਇਆ ਜਾ ਸਕੇ।

ਉਪਰੋਕਤ ਉਦਾਹਰਨ ਫਾਇਲ ਵਿੱਚ ਸਰਵਰ ਐਨਟਰੀ ਕੁਝ ਇਸ ਤਰ੍ਹਾਂ ਦਿਖਾਈ ਦਿੰਦੀ ਹੈ:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

ਇਹ ਇੱਕ ਕਮਾਂਡ ਚਲਾਉਣ ਨਾਲ ਮੇਲ ਖਾਂਦੀ ਹੈ ਜਿਵੇਂ: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` ਕੁਝ ਇਸ ਤਰ੍ਹਾਂ ਟਾਈਪ ਕਰੋ "add 3 to 20"।

    ਤੁਹਾਨੂੰ ਚੈਟ ਟੈਕਸਟ ਬਾਕਸ ਉੱਪਰ ਇੱਕ ਟੂਲ ਦਿਖਾਈ ਦੇਣਾ ਚਾਹੀਦਾ ਹੈ ਜੋ ਤੁਹਾਨੂੰ ਟੂਲ ਚਲਾਉਣ ਲਈ ਚੁਣਨ ਲਈ ਕਹਿੰਦਾ ਹੈ, ਇਸ ਦ੍ਰਿਸ਼ ਵਿੱਚ:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.pa.png)

    ਟੂਲ ਚੁਣਨਾ ਇੱਕ ਸੰਖਿਆਤਮਕ ਨਤੀਜਾ ਉਤਪੰਨ ਕਰਨਾ ਚਾਹੀਦਾ ਹੈ ਜੋ "23" ਕਹਿੰਦਾ ਹੈ ਜੇ ਤੁਹਾਡੀ ਪ੍ਰੰਪਟ ਪਹਿਲਾਂ ਜਿਵੇਂ ਸੀ।

**ਅਸਵੀਕਤੀ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀ ਹੋਣ ਦੀ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਦਿਓ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸੁੱਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਇਸਦੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਮੂਲ ਦਸਤਾਵੇਜ਼ ਨੂੰ ਅਧਿਕਾਰਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਿਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੇ ਇਸਤੇਮਾਲ ਨਾਲ ਉਪਜਣ ਵਾਲੇ ਕਿਸੇ ਵੀ ਗਲਤ ਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।