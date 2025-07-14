<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:22:31+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "bg"
}
-->
# Стартиране на този пример

Ето как да стартирате класическия HTTP стрийминг сървър и клиент, както и MCP стрийминг сървър и клиент с помощта на Python.

### Преглед

- Ще настроите MCP сървър, който изпраща известия за напредъка към клиента, докато обработва елементи.
- Клиентът ще показва всяко известие в реално време.
- Това ръководство обхваща изискванията, настройката, стартирането и отстраняването на проблеми.

### Изисквания

- Python 3.9 или по-нова версия
- Python пакетът `mcp` (инсталирайте с `pip install mcp`)

### Инсталация и настройка

1. Клонирайте хранилището или изтеглете файловете на решението.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Създайте и активирайте виртуална среда (препоръчително):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Инсталирайте необходимите зависимости:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Файлове

- **Сървър:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Клиент:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Стартиране на класическия HTTP стрийминг сървър

1. Отидете в директорията на решението:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Стартирайте класическия HTTP стрийминг сървър:

   ```pwsh
   python server.py
   ```

3. Сървърът ще стартира и ще покаже:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Стартиране на класическия HTTP стрийминг клиент

1. Отворете нов терминал (активирайте същата виртуална среда и директория):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Трябва да видите последователно отпечатани стрийминг съобщения:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### Стартиране на MCP стрийминг сървър

1. Отидете в директорията на решението:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Стартирайте MCP сървъра с транспорта streamable-http:
   ```pwsh
   python server.py mcp
   ```
3. Сървърът ще стартира и ще покаже:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Стартиране на MCP стрийминг клиент

1. Отворете нов терминал (активирайте същата виртуална среда и директория):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Трябва да видите известия, отпечатани в реално време, докато сървърът обработва всеки елемент:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### Основни стъпки при имплементацията

1. **Създайте MCP сървър с FastMCP.**
2. **Дефинирайте инструмент, който обработва списък и изпраща известия чрез `ctx.info()` или `ctx.log()`.**
3. **Стартирайте сървъра с `transport="streamable-http"`.**
4. **Имплементирайте клиент с обработчик на съобщения, който показва известията веднага щом пристигнат.**

### Преглед на кода
- Сървърът използва async функции и MCP контекст за изпращане на актуализации за напредъка.
- Клиентът имплементира async обработчик на съобщения, който отпечатва известията и крайния резултат.

### Съвети и отстраняване на проблеми

- Използвайте `async/await` за неблокиращи операции.
- Винаги обработвайте изключения както в сървъра, така и в клиента за по-голяма стабилност.
- Тествайте с няколко клиента, за да наблюдавате актуализации в реално време.
- Ако срещнете грешки, проверете версията на Python и се уверете, че всички зависимости са инсталирани.

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.