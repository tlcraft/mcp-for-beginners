<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:14:17+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "bg"
}
-->
# Стартиране на примера

Тук приемаме, че вече имате работещ сървър. Моля, намерете сървър от някоя от по-ранните глави.

## Настройване на mcp.json

Ето един файл, който можете да използвате за справка, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Променете записа за сървъра според нуждите, като посочите абсолютния път до вашия сървър, включително необходимата пълна команда за стартиране.

В примерния файл, споменат по-горе, записът за сървъра изглежда по следния начин:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Това съответства на изпълнението на команда като: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` напишете нещо като "add 3 to 20".

    Трябва да видите инструмент, който се появява над текстовото поле за чат, указващ да изберете да стартирате инструмента, както на тази снимка:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.bg.png)

    Изборът на инструмента трябва да даде числов резултат "23", ако вашият въпрос беше като споменатия по-рано.

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия първоначален език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.