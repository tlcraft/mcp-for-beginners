<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:41:29+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "uk"
}
-->
# Запуск прикладу

Тут припускаємо, що у вас вже є робочий код сервера. Будь ласка, знайдіть сервер з однієї з попередніх глав.

## Налаштування mcp.json

Ось файл, який ви використовуєте для довідки, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Змініть запис сервера за потреби, вказавши абсолютний шлях до вашого сервера разом із повною командою для запуску.

У прикладі файлу, на який посилаються вище, запис сервера виглядає так:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Це відповідає запуску команди такого вигляду: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` введіть щось на кшталт "add 3 to 20".

    Ви повинні побачити інструмент, який з’явиться над текстовим полем чату, що вказує на можливість вибрати запуск інструмента, як показано на цьому зображенні:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.uk.png)

    Вибір інструмента має дати числовий результат "23", якщо ваш запит був подібним до наведеного вище.

**Відмова від відповідальності**:  
Цей документ був перекладений за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.