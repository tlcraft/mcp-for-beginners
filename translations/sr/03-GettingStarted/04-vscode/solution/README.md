<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:15:54+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "sr"
}
-->
# Покретање примера

Овде претпостављамо да већ имате радни серверски код. Молимо пронађите сервер из једног од претходних поглавља.

## Подешавање mcp.json

Ево датотеке коју користите као референцу, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Промените унос за сервер по потреби тако да указује на апсолутну путању до вашег сервера укључујући потребну целу команду за покретање.

У пример датотеци која је наведена изнад, унос за сервер изгледа овако:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Ово одговара покретању команде као што је: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` укуцајте нешто као „add 3 to 20“.

    Требало би да видите алат који се појављује изнад поља за текст у чету, што вам указује да изаберете покретање алата као на овој слици:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sr.png)

    Избор алата треба да да бројчани резултат „23“ ако је ваш упит био као што смо раније навели.

**Одрицање одговорности**:  
Овај документ је преведен помоћу АИ сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, имајте у виду да аутоматизовани преводи могу садржати грешке или нетачности. Изворни документ на оригиналном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било какве неспоразуме или погрешна тумачења која произилазе из коришћења овог превода.