<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:12:53+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "ru"
}
-->
# Запуск примера

Здесь предполагается, что у вас уже есть рабочий серверный код. Пожалуйста, найдите сервер из одной из предыдущих глав.

## Настройка mcp.json

Вот файл, который вы используете для справки, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Измените запись сервера по необходимости, указав абсолютный путь к вашему серверу, включая полный командный вызов для запуска.

В примере файла, на который мы ссылаемся выше, запись сервера выглядит так:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Это соответствует выполнению команды вида: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` — введите что-то вроде "add 3 to 20".

    Вы должны увидеть инструмент, появляющийся над полем ввода чата, предлагающий выбрать запуск инструмента, как показано на этом изображении:

    ![VS Code, показывающий запрос на запуск инструмента](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ru.png)

    Выбор инструмента должен выдать числовой результат "23", если ваш запрос был, как мы упоминали ранее.

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, имейте в виду, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для критически важной информации рекомендуется использовать профессиональный перевод, выполненный человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.