<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-27T16:22:33+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "cs"
}
-->
# Running the sample

Here we assume you already have a working server code. Please locate a server from one of the earlier chapters.

## Set up mcp.json

Here's a file you use for reference, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json). 

Change the server entry as needed to point out the absolute path to your server including the needed full command to run.

In the example file referred above the server entry looks like so:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

This corresponds to running a command like so: `cmd /c node <absolute path>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` type something like "add 3 to 20". 

    You should see a tool being presented above the chat text box indicating for you to select to run the tool like in this visual:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.cs.png)

    Selecting the tool should produce a numeric result saying "23" if your prompt was like we mentioned previously.

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.