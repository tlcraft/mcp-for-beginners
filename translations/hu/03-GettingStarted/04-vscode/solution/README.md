<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:07:43+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "hu"
}
-->
# A minta futtatása

Itt feltételezzük, hogy már rendelkezel működő szerverkóddal. Kérlek, keress egy szervert az előző fejezetek egyikéből.

## mcp.json beállítása

Itt egy fájl, amit referencia gyanánt használhatsz: [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Módosítsd a server bejegyzést úgy, hogy az a szervered abszolút elérési útjára mutasson, beleértve a futtatáshoz szükséges teljes parancsot.

A fent említett példafájlban a server bejegyzés így néz ki:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Ez megfelel egy olyan parancs futtatásának, mint: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add`, írj be valami olyasmit, hogy "add 3 to 20".

    A chat szövegdoboz felett meg kell jelennie egy eszköznek, ami jelzi, hogy válaszd ki a futtatáshoz, hasonlóan az alábbi képen látható módon:

    ![VS Code jelzi, hogy eszközt szeretne futtatni](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.hu.png)

    Az eszköz kiválasztásakor egy numerikus eredményt kell kapnod, ami "23" lesz, ha a promptod az előbb említettek szerint alakult.

**Nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum az anyanyelvén tekintendő hivatalos forrásnak. Fontos információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy téves értelmezésekért.