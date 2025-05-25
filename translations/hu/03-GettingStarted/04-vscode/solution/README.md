<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:23:25+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "hu"
}
-->
# A példa futtatása

Itt feltételezzük, hogy már van működő szerverkódod. Kérlek, keress egy szervert az egyik korábbi fejezetből.

## Az mcp.json beállítása

Itt van egy fájl, amit referenciaként használhatsz, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Módosítsd a szerver bejegyzést, hogy az a szervered abszolút útvonalára mutasson, beleértve a futtatáshoz szükséges teljes parancsot.

A fent említett példafájlban a szerver bejegyzés így néz ki:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Ez megfelel egy olyan parancs futtatásának, mint például: `cmd /c node <abszolút útvonal>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add`, írj be valami olyasmit, mint "add 3 to 20".

    A chat szövegdoboz fölött meg kell jelennie egy eszköznek, ami arra utal, hogy válaszd ki az eszköz futtatását, ahogy az alábbi képen látható:

    ![VS Code jelzi, hogy egy eszközt akar futtatni](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.hu.png)

    Az eszköz kiválasztása egy numerikus eredményt kell, hogy adjon, amely "23"-at mond, ha a kérdésed olyan volt, mint amit korábban említettünk.

**Jogi nyilatkozat**:  
Ezt a dokumentumot az AI fordítási szolgáltatással, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Fontos információk esetén ajánlott a professzionális emberi fordítás. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félremagyarázásokért.